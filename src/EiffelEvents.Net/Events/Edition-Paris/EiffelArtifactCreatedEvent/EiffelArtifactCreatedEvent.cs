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
using EiffelEvents.Net.Events.Core;
using EiffelEvents.Net.Events.Edition_Paris.Shared;

namespace EiffelEvents.Net.Events.Edition_Paris
{
    /// <summary>
    /// The <a href="https://github.com/eiffel-community/eiffel/blob/edition-paris/eiffel-vocabulary/EiffelArtifactCreatedEvent.md">
    /// EiffelArtifactCreatedEvent
    /// </a>
    /// declares that a software artifact has been created, what its coordinates are, what it contains and how it was created.
    /// </summary>
    public record EiffelArtifactCreatedEvent :
        EiffelEvent<EiffelArtifactCreatedData, EiffelArtifactCreatedMeta, EiffelArtifactCreatedLinks>
    {
        /// <inheritdoc/>
        public override EiffelArtifactCreatedData Data { get; init; } = new();

        /// <inheritdoc/>
        public override EiffelArtifactCreatedMeta Meta { get; init; } = new();

        /// <inheritdoc/>
        public override EiffelArtifactCreatedLinks Links { get; init; } = new();

        public override IEiffelEvent FromJson(string json)
        {
            return Deserialize<EiffelArtifactCreatedEvent>(json);
        }
    }
}