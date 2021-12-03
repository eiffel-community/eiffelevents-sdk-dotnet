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

using Eiffel.Net.Common;
using FluentResults;

namespace Eiffel.Net.Events.Core
{
    /// <summary>
    /// Represents an Eiffel event of any type
    /// </summary>
    public interface IEiffelEvent
    {
        /// <summary>
        /// Returns a copy of this event that is signed
        /// </summary>
        /// <returns>Signed copy</returns>
        TEvent Sign<TEvent>() where TEvent : class, IEiffelEvent;

        /// <summary>
        /// Validate all event's attributes that marked by validation attributes.
        /// </summary>
        /// <returns>A Result object that holds validation results and error messages.</returns>
        Result Validate();

        /// <summary>
        /// Validate event signature
        /// </summary>
        /// <returns>true if the signature was valid. Otherwise, false</returns>
        bool VerifySignature();

        /// <summary>
        /// Returns a JSON representation of the event in the format given.
        /// </summary>
        /// <param name="format">Format of JSON output, default indented</param>
        /// <returns>JSON content as string</returns>
        string ToJson(JsonFormat format = JsonFormat.INDENTED);

        /// <summary>
        /// Returns event version.
        /// </summary>
        /// <returns>Event version number</returns>
        string GetVersion();

        /// <summary>
        /// Creates an event from a JSON string representation
        /// </summary>
        /// <param name="json">JSON string</param>
        /// <returns>Event</returns>
        IEiffelEvent FromJson(string json);
    }
}