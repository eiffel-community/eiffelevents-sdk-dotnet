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
using EiffelEvents.Clients.RabbitMq.Common;
using EiffelEvents.Clients.RabbitMq.Config;
using EiffelEvents.Clients.RabbitMq.Exceptions;
using FluentResults;
using Newtonsoft.Json;

namespace EiffelEvents.Clients.RabbitMq
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
            where T : IEiffelEvent
        {
            try
            {
                // validate against c# schema 
                var eventType = eiffelEvent.GetType().Name;
                var attributeValidationResult = eiffelEvent.Validate();
                if (attributeValidationResult.IsFailed)
                    return attributeValidationResult.ToResult(eiffelEvent);

                string json;
                if (validateOnPublish == SchemaValidationOnPublish.ON)
                {
                    json = eiffelEvent.ToJson();
                    var schemaValidationResult =
                        SchemaValidationHelper.ValidateEvent(json, eventType, eiffelEvent.GetVersion());

                    if (schemaValidationResult.IsFailed)
                        return GetResultFromValidationErrors<T>(schemaValidationResult);
                }
                else
                {
                    json = eiffelEvent.ToJson();
                }

                var body = Encoding.UTF8.GetBytes(json);
                var routingKey = _rabbitMqWrapper.GetRoutingKey(eventType);
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

        /// <summary>
        /// Publish an event to the Eiffel event bus represented by this client. SchemaValidationOnPublish will be ON
        /// by default configurations if user didn't pass it in <see cref="ClientConfig"/>, otherwise, it will depend on
        /// the value configured in <see cref="ClientConfig"/> that passed to the
        /// constructor of <see cref="RabbitMqEiffelClient"/>
        /// </summary>
        /// <typeparam name="T">The type of event to send</typeparam>
        /// <param name="eiffelEvent">Event to send</param>
        /// <returns>
        /// Result object that indicates if the event published successfully (Result.IsSuccess).
        /// It may hold validation errors in case of failed event validation (Result.IsFailed).
        /// If publish succeed, result object will hold event sent on the bus,
        /// which may be different from the input event (e.g. signed).
        /// </returns>
        public Result<T> Publish<T>(T eiffelEvent) where T : IEiffelEvent
        {
            return Publish(eiffelEvent, _validationConfig.SchemaValidationOnPublish);
        }

        /// <summary>
        /// Subscribes to events of the given Eiffel type. SchemaValidationOnSubscribe will be NONE by default
        /// configurations if user didn't pass it in <see cref="ClientConfig"/>, otherwise, it will depend on
        /// the value configured in <see cref="ClientConfig"/> that passed to the
        /// constructor of <see cref="RabbitMqEiffelClient"/>
        /// </summary>
        /// <typeparam name="T">Type of event to subscribe to</typeparam>
        /// <param name="serviceIdentifier">string identifier for each service to be included in queue name</param>
        /// <param name="callback">
        /// Callback that will be invoked when new events are received where
        /// <see cref="Result{TValue}"/> is Fluent result object of subscribed event. "IsSuccess" flag will be "true"
        /// if the received JSON was a valid event according to the respective schema and the event object can be found
        /// in "Value" property. "IsSuccess" flag will be "false" if the received JSON wasn't valid according to the
        /// respective schema and the validation errors can be found using `Errors` property.
        /// And, ulong for deliveryTag.
        /// </param>
        /// <returns>string for subscriptionId can later be used to UnSubscribe</returns>
        public string Subscribe<T>(string serviceIdentifier, Action<Result<T>, ulong> callback)
            where T : IEiffelEvent
        {
            return Subscribe(serviceIdentifier, callback, _validationConfig.SchemaValidationOnSubscribe);
        }

        /// <inheritdoc/>
        public string Subscribe<T>(string serviceIdentifier, Action<Result<T>, ulong> callback,
            SchemaValidationOnSubscribe validateOnSubscribe) where T : IEiffelEvent
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

                            var result = TryDeserializeEvent(validateOnSubscribe, typeObj, content);
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

        /// <inheritdoc/>
        public string Subscribe(Type eventType, string serviceIdentifier, Action<Result<IEiffelEvent>, ulong> callback, 
            SchemaValidationOnSubscribe validateOnSubscribe)
        {
            try
            {
                var eventTypeName = eventType.Name;
                var routingKey = _rabbitMqWrapper.GetRoutingKey(eventTypeName);

                var queueName = string.IsNullOrWhiteSpace(serviceIdentifier)
                    ? string.Empty
                    : $"{serviceIdentifier}_{eventTypeName}";

                _rabbitMqWrapper.CreateQueue(queueName, routingKey);
                var subscriptionId = _rabbitMqWrapper.Consume(queueName, (_, eventArgs) =>
                    {
                        try
                        {
                            var content = Encoding.UTF8.GetString(eventArgs.Body.Span);

                            var typeObj = Activator.CreateInstance(eventType) as IEiffelEvent;

                            if (typeObj == null) return;

                            var result = TryDeserializeEvent(validateOnSubscribe, typeObj, content);
                            callback(result, eventArgs.DeliveryTag);
                        }
                        catch (Exception e)
                        {
                            var failedResult = Result.Fail(e.Message);
                            callback(failedResult, eventArgs.DeliveryTag);
                        }
                    }
                );
                return subscriptionId;
            }
            catch (Exception e)
            {
                throw new RabbitMqException($"Error occurred while subscribing to {eventType}", e);
            }
        }

        /// <inheritdoc/>
        public string Subscribe(Type eventType, string serviceIdentifier, Action<Result<IEiffelEvent>, ulong> callback)
        {
            return Subscribe(eventType, serviceIdentifier, callback, _validationConfig.SchemaValidationOnSubscribe);
        }

        /// <summary>
        /// Try deserialize JSON string to the corresponding C# type.
        /// </summary>
        /// <param name="validateOnSubscribe">Set configuration to validate against JSON schema or not</param>
        /// <param name="typeObj">Object to deserialize to</param>
        /// <param name="content">JSON content to be deserialized</param>
        /// <typeparam name="T">C# event type</typeparam>
        /// <returns>
        /// <see cref="Result"/> of the deserialization process with event in Result.Value property if deserialization
        /// was succeeded. Result.Errors will hold the error messages in case of failures.
        /// </returns>
        private Result<T> TryDeserializeEvent<T>(SchemaValidationOnSubscribe validateOnSubscribe, T typeObj,
            string content) where T : IEiffelEvent
        {
            var (type, version) = JsonHelper.GetTypeAndVersion(content);

            if (string.IsNullOrWhiteSpace(type) ||
                string.IsNullOrWhiteSpace(version))
                return Result.Fail<T>("Not valid JSON event. Can't find meta.type or meta.version.");

            if (version != typeObj.GetVersion() ||
                type != typeObj.GetType().Name)
                return Result.Fail<T>($"Inconsistent event versions found: a subscription to event {typeof(T).Name} " +
                                      $"with version: {typeObj.GetVersion()} but received event {type} with version: {version}");

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
                        validJsonResult = SchemaValidationHelper.ValidateEvent(content, type, version);
                        return GetResultFromValidationErrors<T>(validJsonResult);
                    }
                case SchemaValidationOnSubscribe.ALWAYS:
                    validJsonResult = SchemaValidationHelper.ValidateEvent(content, type, version);
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

        private Result<T> GetResultFromValidationErrors<T>(Result validJsonResult) where T : IEiffelEvent
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