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
    /// The EiffelSourceChangeCreatedEvent declares that a change to sources has been made, but not yet submitted.
    /// This can be used to represent a change done on a private branch, undergoing review or made in a forked repository.
    /// <a href="https://github.com/eiffel-community/eiffel/blob/edition-paris/eiffel-vocabulary/EiffelSourceChangeCreatedEvent.md">
    /// EiffelSourceChangeCreatedEvent
    /// </a>
    /// for details.
    /// </summary>
    public record EiffelSourceChangeCreatedEvent :
        EiffelEvent<EiffelSourceChangeCreatedData, EiffelSourceChangeCreatedMeta, EiffelSourceChangeCreatedLinks>
    {
        /// <inheritdoc/>
        public override EiffelSourceChangeCreatedData Data { get; init; } = new();
        
        /// <inheritdoc/>
        public override EiffelSourceChangeCreatedMeta Meta { get; init; } = new();
        
        /// <inheritdoc/>
        public override EiffelSourceChangeCreatedLinks Links { get; init; } = new();
        
        /// <inheritdoc/>
        public override IEiffelEvent FromJson(string json)
        {
            return Deserialize<EiffelSourceChangeCreatedEvent>(json);
        }
    }
}