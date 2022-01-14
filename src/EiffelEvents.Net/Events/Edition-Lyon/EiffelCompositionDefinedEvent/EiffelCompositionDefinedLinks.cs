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
    public record EiffelCompositionDefinedLinks : EiffelSharedLinks
    {
        /// <summary>
        /// Identifies an element and/or sub-composition of this composition. The latter is particularly useful for
        /// documenting large and potentially decentralized compositions, and may be used to reduce the need to repeat
        /// large compositions in which only small parts are subject to frequent change.
        /// Legal targets: EiffelCompositionDefinedEvent, EiffelSourceChangeCreatedEvent,
        /// EiffelSourceChangeSubmittedEvent, EiffelArtifactCreatedEvent
        /// </summary>
        [NestedList]
        public List<EiffelElementLink> Element { get; init; }

        /// <summary>
        /// Identifies a latest previous version (there may be more than one in case of merges) of the composition.
        /// Legal targets: EiffelCompositionDefinedEvent
        /// </summary>
        [NestedList]
        public List<EiffelPreviousVersionLink> PreviousVersion { get; init; }

    }
}