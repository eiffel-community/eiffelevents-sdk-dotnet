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
    /// The <a href="https://github.com/eiffel-community/eiffel/blob/edition-paris/eiffel-vocabulary/EiffelTestSuiteFinishedEvent.md">
    /// EiffelTestSuiteFinishedEvent
    /// </a> declares that a previously started test suite
    /// (declared by <see cref="EiffelTestSuiteStartedEvent"/> has finished and reports the outcome.
    /// </summary>
    public record EiffelTestSuiteFinishedEvent :
        EiffelEvent<EiffelTestSuiteFinishedData, EiffelTestSuiteFinishedMeta, EiffelTestSuiteFinishedLinks>
    {
        /// <inheritdoc/>
        public override EiffelTestSuiteFinishedData Data { get; init; }

        /// <inheritdoc/>
        [Required]
        public override EiffelTestSuiteFinishedMeta Meta { get; init; }

        /// <inheritdoc/>
        [Required]
        public override EiffelTestSuiteFinishedLinks Links { get; init; }

        /// <inheritdoc/>
        public override IEiffelEvent FromJson(string json)
        {
            return Deserialize<EiffelTestSuiteFinishedEvent>(json);
        }
    }
}