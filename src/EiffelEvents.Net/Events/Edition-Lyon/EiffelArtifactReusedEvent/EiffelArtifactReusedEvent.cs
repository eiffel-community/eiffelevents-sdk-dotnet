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
    /// The <a href="https://github.com/eiffel-community/eiffel/blob/edition-lyon/eiffel-vocabulary/EiffelArtifactReusedEvent.md">
    /// EiffelArtifactReusedEvent
    /// </a> declares that an identified EiffelArtifactCreatedEvent has been reused for
    /// an identified EiffelCompositionDefinedEvent. 
    /// </summary>
    public record EiffelArtifactReusedEvent :
        EiffelEvent<EiffelArtifactReusedData, EiffelArtifactReusedMeta, EiffelArtifactReusedLinks>
    {
        /// <inheritdoc/>
        public override EiffelArtifactReusedData Data { get; init; }
        
        /// <inheritdoc/>
        public override EiffelArtifactReusedMeta Meta { get; init; }
        
        /// <inheritdoc/>
        public override EiffelArtifactReusedLinks Links { get; init; }
        
        /// <inheritdoc/>
        public override IEiffelEvent FromJson(string json)
        {
            return Deserialize<EiffelArtifactReusedEvent>(json);
        }
    }
}