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

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EiffelEvents.Net.Events.Edition_Lyon.Shared;
using EiffelEvents.Net.Events.Edition_Lyon.Shared.Links;
using EiffelEvents.Net.Validation;
using Newtonsoft.Json;

namespace EiffelEvents.Net.Events.Edition_Lyon
{
    [JsonArray]
    public record EiffelActivityStartedLinks : EiffelSharedLinks
    {
        /// <summary>
        /// Declares the activity execution that was canceled.
        /// In other words, <see cref="EiffelActivityTriggeredEvent"/> acts as a handle for the activity execution.
        /// This differs from <see cref="EiffelContextLink"/>.
        /// </summary>
        [Required]
        [NestedObject]
        public EiffelActivityExecutionLink ActivityExecution { get; init; }
        
        /// <summary>
        /// Identifies the latest previous execution of the activity.
        /// </summary>
        [NestedObject]
        public EiffelPreviousActivityExecutionLink PreviousActivityExecution { get; init; }

    }
}