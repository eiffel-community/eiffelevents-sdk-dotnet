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
using EiffelEvents.Net.Common;
using EiffelEvents.RabbitMq.Client.Common;
using EiffelEvents.RabbitMq.Client.Exceptions;
using FluentResults;

namespace EiffelEvents.RabbitMq.Client
{
    /// <summary>
    /// Provides publishing and subscription of Eiffel events on RabbitMQ.
    /// </summary>
    public class RabbitMqEiffelClient : IEiffelClient, IDisposable
    {
        private readonly IRabbitMqWrapper _rabbitMqWrapper;

        private RabbitMqEiffelClient()
        {
        }


        /// <summary>
        /// Construct a new object from RabbitMqEiffelClient
        /// </summary>
        /// <param name="config">RabbitMQ instance connection configurations</param>
        /// <param name="connectionRetries">Number od retries used to establish RabbitMQ connection</param>
        public RabbitMqEiffelClient(RabbitMqConfig config, int connectionRetries = 10)
        {
            _rabbitMqWrapper = new RabbitMqWrapper(config, connectionRetries);
        }

        /// <inheritdoc/>
        public Result<T> Publish<T>(T eiffelEvent, bool validateBeforePublish = true) where T : IEiffelEvent
        {
            try
            {
                if (validateBeforePublish)
                {
                    var validationResult = eiffelEvent.Validate();
                    if (validationResult.IsFailed)
                        return validationResult.ToResult(eiffelEvent);
                }


                var json = eiffelEvent.ToJson();
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
        public string Subscribe<T>(string serviceIdentifier, Action<T, ulong> callback) where T : IEiffelEvent, new()
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
                        var content = Encoding.UTF8.GetString(eventArgs.Body.Span);

                        var typeObj = (T)Activator.CreateInstance(typeof(T));
                        if (typeObj == null) return;

                        var eiffelEvent = (T)typeObj.FromJson(content);
                        ValidationHelper.ValidateEventVersion(eiffelEvent);

                        callback(eiffelEvent, eventArgs.DeliveryTag);
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