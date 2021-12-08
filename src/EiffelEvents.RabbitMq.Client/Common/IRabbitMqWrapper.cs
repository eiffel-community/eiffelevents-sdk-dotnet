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

using System;
using RabbitMQ.Client.Events;

namespace EiffelEvents.RabbitMq.Client.Common
{
    internal interface IRabbitMqWrapper : IDisposable
    {
        /// <summary>
        /// Create a queue for a specific name and routing key
        /// </summary>
        /// <param name="queueName"></param>
        /// <param name="routingKey"></param>
        public void CreateQueue(string queueName, string routingKey);

        /// <summary>
        /// Consume/subscribe to message/event.
        /// </summary>
        /// <param name="queueName">queueName</param>
        /// <param name="eventHandler">method or code block to be executed after receive message/event.</param>
        /// <returns>subscription Id</returns>
        public string Consume(string queueName, EventHandler<BasicDeliverEventArgs> eventHandler);

        /// <summary>
        /// Publish message to an exchangeName defined in RabbitMqConfig
        /// </summary>
        /// <param name="routingKey">routingKey</param>
        /// <param name="body">message</param>
        /// <returns></returns>
        public bool Publish(string routingKey, byte[] body);

        /// <summary>
        /// Acknowledge receiving message successfully
        /// </summary>
        /// <param name="deliveryTag">A growing positive integers uniquely identifies the delivery on a channel.</param>
        public void Ack(ulong deliveryTag);

        /// <summary>
        /// Reject the message(event), used for negative acknowledgements
        /// </summary>
        /// <param name="deliveryTag">A growing positive integers uniquely identifies the delivery on a channel.</param>
        /// <param name="requeue">Flag to requeue the message(event)</param>
        public void Reject(ulong deliveryTag, bool requeue);

        /// <summary>
        /// Cancel subscription.
        /// </summary>
        /// <param name="subscriptionId">subscriptionId is a subscription ID for a consumer it is returned by Subscribe method
        /// on the callback.</param>
        public void Unsubscribe(string subscriptionId);

        /// <summary>
        /// Construct RabbitMQ routing key string as following : eiffel._.{eventType}._._
        /// template-> [segment1].[segment2].[segment3].[segment4].[segment5]
        /// segment1: Fixed prefix
        /// segment2: Implementation defined family or underscore if no exists
        /// segment3: eventType
        /// segment4: Implementation defined tag or underscore if no exists
        /// segment5: Eiffel domain of event or underscore if no exists
        /// </summary>
        /// <param name="eventType">Published event type</param>
        /// <returns>RabbitMQ routing key</returns>
        public string GetRoutingKey(string eventType);
    }
}