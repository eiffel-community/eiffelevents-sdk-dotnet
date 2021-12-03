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
using Eiffel.Net.Events.Core;
using Eiffel.Net.Events.Edition_Paris.Shared;

namespace Eiffel.Net.Events.Edition_Paris
{
    /// <summary>
    /// Announces that an activity has been started.
    /// <a href="https://github.com/eiffel-community/eiffel/blob/edition-paris/eiffel-vocabulary/EiffelActivityStartedEvent.md">
    /// EiffelActivityStartedEvent
    /// </a>
    /// for details.
    /// </summary>
    public record EiffelActivityStartedEvent
        : EiffelEvent<EiffelActivityStartedData, EiffelActivityStartedMeta, EiffelActivityStartedLinks>
    {
        #region Props

        /// <inheritdoc/>
        [Required]
        public override EiffelActivityStartedData Data { get; init; }
        
        /// <inheritdoc/>
        [Required]
        public override EiffelActivityStartedMeta Meta { get; init; }

        /// <inheritdoc/>
        [Required]
        public override EiffelActivityStartedLinks Links { get; init; }
        #endregion

        public override IEiffelEvent FromJson(string json)
        {
            return Deserialize<EiffelActivityStartedEvent>(json);
        }
    }
}