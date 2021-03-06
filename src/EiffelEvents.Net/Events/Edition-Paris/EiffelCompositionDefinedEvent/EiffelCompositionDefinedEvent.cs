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
    /// The <a href="https://github.com/eiffel-community/eiffel/blob/edition-paris/eiffel-vocabulary/EiffelCompositionDefinedEvent.md">
    /// EiffelCompositionDefinedEvent
    /// </a> EiffelCompositionDefinedEvent declares a composition of items (artifacts, sources and other compositions)
    /// has been defined, typically with the purpose of enabling further downstream artifacts to be generated.
    /// </summary>
    public record EiffelCompositionDefinedEvent :
        EiffelEvent<EiffelCompositionDefinedData, EiffelCompositionDefinedMeta, EiffelCompositionDefinedLinks>
    {
        /// <inheritdoc/>
        public override EiffelCompositionDefinedData Data { get; init; } = new();
        
        /// <inheritdoc/>
        public override EiffelCompositionDefinedMeta Meta { get; init; } = new();
        
        /// <inheritdoc/>
        public override EiffelCompositionDefinedLinks Links { get; init; } = new();
        
        public override IEiffelEvent FromJson(string json)
        {
            return Deserialize<EiffelCompositionDefinedEvent>(json);
        }
    }
}