//    Copyright (c) 2021 ICT Cube, doWhile, and Eiffel Community collaborators.
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.

using EiffelEvents.Net.Events.Core;
using System.Text;
using EiffelEvents.Net.Clients;
using EiffelEvents.Net.Clients.Validation;
using EiffelEvents.Net.Validation;
using EiffelEvents.RabbitMq.Client.Common;
using EiffelEvents.RabbitMq.Client.Config;
using EiffelEvents.RabbitMq.Client.Exceptions;
using FluentResults;
using Newtonsoft.Json;

namespace EiffelEvents.RabbitMq.Client
{
    /// <summary>
    /// Provides publishing and subscription of Eiffel events on RabbitMQ.
    /// </summary>
    public class RabbitMqEiffelClient : IEiffelClient, IDisposable
    {
        private readonly IRabbitMqWrapper _rabbitMqWrapper;
        private readonly ValidationConfig _validationConfig;

        private RabbitMqEiffelClient()
        {
        }


        /// <summary>
        /// Construct a new object from RabbitMqEiffelClient
        /// </summary>
        /// <param name="config">
        /// Client configurations used to connect to RabbitMq instance and while validating events
        /// </param>
        /// <param name="connectionRetries">Number od retries used to establish RabbitMQ connection</param>
        public RabbitMqEiffelClient(ClientConfig config, int connectionRetries = 10)
        {
            _rabbitMqWrapper = new RabbitMqWrapper(config.RabbitMqConfig, connectionRetries);
            _validationConfig = config.ValidationConfig;
        }

        /// <inheritdoc/>
        public Result<T> Publish<T>(T eiffelEvent, SchemaValidationOnPublish validateOnPublish) 
            where T : IEiffelEvent, new()
        {
            try
            {
                // validate against c# schema 
                var attributeValidationResult = eiffelEvent.Validate();
                if (attributeValidationResult.IsFailed)
                    return attributeValidationResult.ToResult(eiffelEvent);

                string json;
                if (validateOnPublish == SchemaValidationOnPublish.ON)
                {
                    json = eiffelEvent.ToJson();
                    var schemaValidationResult = SchemaValidationHelper.ValidateEvent<T>(json);
                    if (schemaValidationResult.IsFailed)
                        return GetResultFromValidationErrors<T>(schemaValidationResult);
                }
                else
                {
                    json = eiffelEvent.ToJson();
                }

                var body = Encoding.UTF8.GetBytes(json);
                var routingKey = _rabbitMqWrapper.GetRoutingKey(typeof(T).Name);
                var sent = _rabbitMqWrapper.Publish(routingKey, body);

                return sent
                    ? Result.Ok(eiffelEvent)
                    : throw new RabbitMqException($"Error occurred while sending {json}");
            }
            catch (Exception e)
            {
                throw new RabbitMqException("Error occurred while publishing a message", e);
            }
        }

        /// <inheritdoc/>
        public Result<T> Publish<T>(T eiffelEvent) where T : IEiffelEvent, new()
        {
            return Publish(eiffelEvent, _validationConfig.SchemaValidationOnPublish);
        }

        /// <inheritdoc/>
        public string Subscribe<T>(string serviceIdentifier, Action<Result<T>, ulong> callback)
            where T : IEiffelEvent, new()
        {
            return Subscribe(serviceIdentifier, callback, _validationConfig.SchemaValidationOnSubscribe);
        }

        /// <inheritdoc/>
        public string Subscribe<T>(string serviceIdentifier, Action<Result<T>, ulong> callback,
            SchemaValidationOnSubscribe validateOnSubscribe) where T : IEiffelEvent, new()
        {
            try
            {
                var eventName = typeof(T).Name;
                var routingKey = _rabbitMqWrapper.GetRoutingKey(eventName);
                var queueName = string.IsNullOrWhiteSpace(serviceIdentifier)
                    ? string.Empty
                    : $"{serviceIdentifier}_{eventName}";

                _rabbitMqWrapper.CreateQueue(queueName, routingKey);
                var subscriptionId = _rabbitMqWrapper.Consume(queueName, (_, eventArgs) =>
                    {
                        try
                        {
                            var content = Encoding.UTF8.GetString(eventArgs.Body.Span);

                            var typeObj = (T)Activator.CreateInstance(typeof(T));
                            if (typeObj == null) return;

                            var result = ValidateEvent(validateOnSubscribe, typeObj, content);
                            callback(result, eventArgs.DeliveryTag);
                        }
                        catch (Exception e)
                        {
                            var failedResult = Result.Fail<T>(e.Message);
                            callback(failedResult, eventArgs.DeliveryTag);
                        }
                    }
                );
                return subscriptionId;
            }
            catch (Exception e)
            {
                throw new RabbitMqException($"Error occurred while subscribing to {typeof(T).Name}", e);
            }
        }

        private Result<T> ValidateEvent<T>(SchemaValidationOnSubscribe validateOnSubscribe, T typeObj, string content)
            where T : IEiffelEvent, new()
        {
            T eiffelEvent;
            Result validJsonResult;
            switch (validateOnSubscribe)
            {
                case SchemaValidationOnSubscribe.ON_DESERIALIZATION_FAIL:
                    try
                    {
                        eiffelEvent = (T)typeObj.FromJson(content);
                        return Result.Ok(eiffelEvent);
                    }
                    catch (JsonSerializationException)
                    {
                        validJsonResult = SchemaValidationHelper.ValidateEvent<T>(content);
                        return GetResultFromValidationErrors<T>(validJsonResult);
                    }
                case SchemaValidationOnSubscribe.ALWAYS:
                    validJsonResult = SchemaValidationHelper.ValidateEvent<T>(content);
                    if (validJsonResult.IsSuccess)
                    {
                        eiffelEvent = (T)typeObj.FromJson(content);
                        return Result.Ok(eiffelEvent);
                    }
                    else
                    {
                        return GetResultFromValidationErrors<T>(validJsonResult);
                    }
                case SchemaValidationOnSubscribe.NONE:
                default:
                    eiffelEvent = (T)typeObj.FromJson(content);
                    return Result.Ok(eiffelEvent);
            }
        }

        private Result<T> GetResultFromValidationErrors<T>(Result validJsonResult) where T : IEiffelEvent, new()
        {
            var errorMessage = "JSON validation against the corresponding JSON schema was failed. ";
            var validationErrors = string.Join(", ", validJsonResult.Errors.Select(x => x.Message));
            errorMessage += $"Errors: {validationErrors}";
            return Result.Fail<T>(errorMessage);
        }

        /// <inheritdoc/>
        public void Ack(ulong deliveryTag)
        {
            _rabbitMqWrapper.Ack(deliveryTag);
        }

        /// <inheritdoc/>
        public void Reject(ulong deliveryTag, bool requeue)
        {
            _rabbitMqWrapper.Reject(deliveryTag, requeue);
        }

        /// <inheritdoc/>
        public void Unsubscribe(string subscriptionId)
        {
            _rabbitMqWrapper.Unsubscribe(subscriptionId);
        }

        public void Dispose() => _rabbitMqWrapper.Dispose();
    }
}