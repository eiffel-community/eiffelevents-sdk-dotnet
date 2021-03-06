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
using EiffelEvents.Net.Events.Core.Links;
using EiffelEvents.Net.Validation;

namespace EiffelEvents.Net.Events.Edition_Paris.Shared
{
    public abstract record EiffelSharedLinks : EiffelLinks
    {
        /// <summary>
        /// Identifies a cause of the event occurring.
        /// Legal targets: Any
        /// </summary>
        [ValidGuid(IsMultiple = true)]
        public List<string> Cause { get; init; }

        /// <summary>
        /// Identifies the activity or test suite of which this event constitutes a part.
        /// Legal targets: EiffelActivityTriggeredEvent, EiffelTestSuiteStartedEvent
        /// </summary>
        [ValidGuid]
        public string Context { get; init; }

        /// <summary>
        /// Identifies the flow context of the event.
        /// Legal targets: EiffelFlowContextDefinedEvent
        /// </summary>
        [ValidGuid(IsMultiple = true)]
        public List<string> FlowContext { get; init; }
    }
}