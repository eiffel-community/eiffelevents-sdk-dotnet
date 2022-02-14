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
    /// The <a href="https://github.com/eiffel-community/eiffel/blob/edition-paris/eiffel-vocabulary/EiffelEnvironmentDefinedEvent.md">
    /// EiffelEnvironmentDefinedEvent
    /// </a> declares an environment which may be referenced from other events in order to secure traceability to
    /// the conditions under which an artifact was created or a test was executed. Depending on the technology domain,
    /// the nature of an environment varies greatly however: it may be a virtual image, a complete mechatronic system
    /// of millions of independent parts, or anything in between.
    /// Consequently, a concise yet complete and generic syntax for describing any environment is futile.
    /// </summary>
    public record EiffelEnvironmentDefinedEvent :
        EiffelEvent<EiffelEnvironmentDefinedData, EiffelEnvironmentDefinedMeta, EiffelEnvironmentDefinedLinks>
    {
        
        /// <inheritdoc/>
        public override EiffelEnvironmentDefinedData Data { get; init; } = new();

        /// <inheritdoc/>
        public override EiffelEnvironmentDefinedMeta Meta { get; init; } = new();

        /// <inheritdoc/>
        public override EiffelEnvironmentDefinedLinks Links { get; init; } = new();

        public override IEiffelEvent FromJson(string json)
        {
            return this.Deserialize<EiffelEnvironmentDefinedEvent>(json);
        }

    }
}