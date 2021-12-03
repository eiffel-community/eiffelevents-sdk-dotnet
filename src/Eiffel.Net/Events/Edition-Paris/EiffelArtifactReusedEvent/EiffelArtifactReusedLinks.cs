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
    public record EiffelArtifactReusedLinks : EiffelSharedLinks
    {
        /// <summary>
        /// Identifies the composition for which an already existing artifact (identified by REUSED_ARTIFACT) reused.
        /// Legal targets: EiffelCompositionDefinedEvent 
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [ValidGuid]
        public string Composition { get; init; }

        /// <summary>
        /// This link identifies the EiffelArtifactCreatedEvent, that is reused for the composition identified by COMPOSITION; 
        /// in other words, the artifact that is not rebuilt for a that composition.
        /// Legal targets: EiffelArtifactCreatedEvent
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [ValidGuid]
        public string ReusedArtifact { get; init; }
    }
}