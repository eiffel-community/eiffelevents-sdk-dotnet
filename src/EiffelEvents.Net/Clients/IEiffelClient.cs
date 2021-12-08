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
using EiffelEvents.Net.Events.Core;
using FluentResults;

namespace EiffelEvents.Net.Clients
{
    /// <summary>
    /// Provides publishing and subscription of Eiffel events.
    /// </summary>
    public interface IEiffelClient
    {
        /// <summary>
        /// Publish an event to the Eiffel event bus represented by this client.
        /// </summary>
        /// <typeparam name="T">The type of event to send</typeparam>
        /// <param name="eiffelEvent">Event to send</param>
        /// <param name="validateBeforePublish">
        /// boolean to indicate that if the event will be validated before publish or not
        /// </param>
        /// <returns>
        /// Result object that indicates if the event published successfully (Result.IsSuccess).
        /// It may hold validation errors in case of failed event validation (Result.IsFailed).
        /// If publish succeed, result object will hold event sent on the bus,
        /// which may be different from the input event (e.g. signed).
        /// </returns>
        Result<T> Publish<T>(T eiffelEvent, bool validateBeforePublish = true) where T : IEiffelEvent;

        /// <summary>
        /// Subscribes to events of the given type on the given topic
        /// </summary>
        /// <typeparam name="T">Type of event to subscribe to</typeparam>
        /// <param name="serviceIdentifier">string identifier for each service to be included in queue name</param>
        /// <param name="callback">Callback that will be invoked when new events are received where
        /// T is events of the given type and ulong for deliveryTag</param>
        /// <returns>string for subscriptionId can later be used to UnSubscribe</returns>
        string Subscribe<T>(string serviceIdentifier, Action<T, ulong> callback) where T : IEiffelEvent, new();

        /// <summary>
        /// Acknowledge receiving the message(event), used for positive acknowledgements. 
        /// </summary>
        /// <param name="deliveryTag">A growing positive integers uniquely identifies the delivery on a channel.</param>
        void Ack(ulong deliveryTag);

        /// <summary>
        /// Reject the message(event), used for negative acknowledgements
        /// </summary>
        /// <param name="deliveryTag">A growing positive integers uniquely identifies the delivery on a channel.</param>
        /// <param name="requeue">Flag to requeue the message(event)</param>
        void Reject(ulong deliveryTag, bool requeue);

        /// <summary>
        /// Cancel subscription.
        /// </summary>
        /// <param name="subscriptionId">subscriptionId is a subscription ID for a consumer it is returned by Subscribe method
        /// on the callback.</param>
        void Unsubscribe(string subscriptionId);
    }
}