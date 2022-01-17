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
using EiffelEvents.Net.Events.Edition_Lyon.Shared;
using EiffelEvents.Net.Events.Edition_Lyon.Shared.Links;
using EiffelEvents.Net.Validation;

namespace EiffelEvents.Net.Events.Edition_Lyon
{
    public record EiffelArtifactReusedLinks : EiffelSharedLinks
    {
        /// <summary>
        /// Identifies the composition for which an already existing artifact (identified by REUSED_ARTIFACT)
        /// is declared reused.
        /// Legal targets: EiffelCompositionDefinedEvent
        /// </summary>
        [Required]
        [NestedObject]
        public EiffelCompositionLink Composition { get; init; }
        
        /// <summary>
        /// This link identifies the EiffelArtifactCreatedEvent that is reused for the composition identified by
        /// COMPOSITION; in other words, the artifact that is not rebuilt for a that composition.
        /// Legal targets: EiffelArtifactCreatedEvent
        /// </summary>
        [Required]
        [NestedObject]
        public EiffelReusedArtifactLink ReusedArtifact { get; init; }
    }
}