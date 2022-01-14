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
    /// The <a href="https://github.com/eiffel-community/eiffel/blob/edition-lyon/eiffel-vocabulary/EiffelCompositionDefinedEvent.md">
    /// EiffelCompositionDefinedEvent</a> declares that an entity has achieved (or failed to achieve) a certain level of confidence,
    /// or in a broader sense to annotate it as being applicable or relevant to a certain case (e.g. fit for release to
    /// a certain customer segment or having passed certain criteria). This is particularly useful for promoting various engineering artifacts,
    /// such as product revisions, through the continuous integration and delivery pipeline.
    /// </summary>
    public record EiffelCompositionDefinedEvent
        : EiffelEvent<EiffelCompositionDefinedData, EiffelCompositionDefinedMeta, EiffelCompositionDefinedLinks>
    {
        /// <inheritdoc/>
        public override EiffelCompositionDefinedData Data { get; init; } = new();

        /// <inheritdoc/>
        public override EiffelCompositionDefinedMeta Meta { get; init; } = new();

        /// <inheritdoc/>
        public override EiffelCompositionDefinedLinks Links { get; init; } = new();

        /// <inheritdoc/>
        public override IEiffelEvent FromJson(string json)
        {
            return Deserialize<EiffelCompositionDefinedEvent>(json);
        }
    }
}