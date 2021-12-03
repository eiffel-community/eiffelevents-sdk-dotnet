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
    /// The
    /// <a href="https://github.com/eiffel-community/eiffel/blob/edition-paris/eiffel-vocabulary/EiffelTestCaseStartedEvent.md">
    /// EiffelTestCaseStartedEvent
    /// </a>
    /// declares that the execution of a test case has commenced.
    /// This event SHALL be preceded by a EiffelTestCaseTriggeredEvent,
    /// and appropriately linked to via TEST_CASE_EXECUTION.
    /// </summary>
    public record EiffelTestCaseStartedEvent :
        EiffelEvent<EiffelTestCaseStartedData, EiffelTestCaseStartedMeta, EiffelTestCaseStartedLinks>
    {
        /// <inheritdoc/>
        public override EiffelTestCaseStartedData Data { get; init; }

        /// <inheritdoc/>
        [Required]
        public override EiffelTestCaseStartedMeta Meta { get; init; }

        /// <inheritdoc/>
        [Required]
        public override EiffelTestCaseStartedLinks Links { get; init; }

        /// <inheritdoc/>
        public override IEiffelEvent FromJson(string json)
        {
            return Deserialize<EiffelTestCaseStartedEvent>(json);
        }
    }
}