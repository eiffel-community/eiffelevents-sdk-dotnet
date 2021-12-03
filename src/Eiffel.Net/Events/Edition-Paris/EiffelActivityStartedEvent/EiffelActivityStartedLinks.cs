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

using System.ComponentModel.DataAnnotations;
using Eiffel.Net.Events.Edition_Paris.Shared;
using Eiffel.Net.Validation;

namespace Eiffel.Net.Events.Edition_Paris
{
    public record EiffelActivityStartedLinks : EiffelSharedLinks
    {
        /// <summary>
        /// Declares the activity execution that was started.
        /// Legal targets: EiffelActivityTriggeredEvent
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [ValidGuid]
        public string ActivityExecution { get; init; }

        /// <summary>
        /// Identifies the latest previous execution of the activity.
        /// Legal targets: EiffelActivityTriggeredEvent
        /// </summary>
        [ValidGuid]
        public string PreviousActivityExecution { get; init; }
    }
}