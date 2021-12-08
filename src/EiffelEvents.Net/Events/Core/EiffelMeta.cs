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
using System.ComponentModel.DataAnnotations;
using EiffelEvents.Net.Validation;
using Newtonsoft.Json;

namespace EiffelEvents.Net.Events.Core
{
    public abstract record EiffelMeta
    {
        /// <summary>
        /// Event ID. Auto-generated but can be overridden during event creation.
        /// </summary>
        [ValidGuid]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        /// <summary>
        /// Event type
        /// </summary>
        public abstract string Type { get; init; }

        /// <summary>
        /// Event version
        /// </summary>
        [RegularExpression(
            @"^(0|[1-9]\d*)\.(0|[1-9]\d*)\.(0|[1-9]\d*)$",
            ErrorMessage = "Invalid format for semantic versioning")]
        public abstract string Version { get; init; }

        /// <summary>
        /// Event time in UTC. Auto-generated but can be overridden during event creation.
        /// </summary>
        public long Time { get; init; } = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        /// <summary>
        /// DateTime representation of the event time in UTC.
        /// </summary>
        [JsonIgnore]
        public DateTime InfoTimeAsDate =>
            new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(Time);
    }
}