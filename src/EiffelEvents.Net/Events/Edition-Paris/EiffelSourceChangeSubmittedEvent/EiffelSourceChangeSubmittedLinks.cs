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
using EiffelEvents.Net.Events.Edition_Paris.Shared;
using EiffelEvents.Net.Validation;

namespace EiffelEvents.Net.Events.Edition_Paris
{
    public record EiffelSourceChangeSubmittedLinks : EiffelSharedLinks
    {
        /// <summary>
        /// Identifies the change that was submitted.
        /// Legal targets: EiffelSourceChangeCreatedEvent
        /// </summary>
        [ValidGuid]
        public string Change { get; init; }

        /// <summary>
        /// Identifies a latest previous version (there may be more than one in case of merges) of
        /// the submitted source change.
        /// Legal targets: EiffelSourceChangeSubmittedEvent
        /// </summary>
        [ValidGuid(IsMultiple = true)]
        public List<string> PreviousVersion { get; init; }
    }
}