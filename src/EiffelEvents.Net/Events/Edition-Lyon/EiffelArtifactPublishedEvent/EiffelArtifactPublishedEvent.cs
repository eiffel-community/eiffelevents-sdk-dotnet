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


using EiffelEvents.Net.Events.Core;
using EiffelEvents.Net.Events.Edition_Lyon.Shared;

namespace EiffelEvents.Net.Events.Edition_Lyon
{
    /// <summary>
    /// The <a href="https://github.com/eiffel-community/eiffel/blob/edition-lyon/eiffel-vocabulary/EiffelArtifactPublishedEvent.md">
    /// EiffelArtifactPublishedEvent
    /// </a> declares that a software artifact (declared by EiffelArtifactCreatedEvent) has been published
    /// and is consequently available for retrieval at one or more locations.
    /// </summary>
    public record EiffelArtifactPublishedEvent
        : EiffelEvent<EiffelArtifactPublishedData, EiffelArtifactPublishedMeta, EiffelArtifactPublishedLinks>
    {
        /// <inheritdoc/>
        public override EiffelArtifactPublishedData Data { get; init; } = new();

        /// <inheritdoc/>
        public override EiffelArtifactPublishedMeta Meta { get; init; } = new();

        /// <inheritdoc/>
        public override EiffelArtifactPublishedLinks Links { get; init; } = new();

        /// <inheritdoc/>
        public override IEiffelEvent FromJson(string json)
        {
            return Deserialize<EiffelArtifactPublishedEvent>(json);
        }
    }
}