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
    /// The <a href="https://github.com/eiffel-community/eiffel/blob/edition-paris/eiffel-vocabulary/EiffelIssueVerifiedEvent.md">
    /// EiffelIssueVerifiedEvent
    /// </a> declares that an issue, typically a requirement, has been verified by some means. It is different from
    /// <see cref="EiffelTestCaseFinishedEvent"/> in that multiple test case executions may serve as the basis for
    /// a single verification or, conversely, multiple issues may be verified based on a single test case execution.
    /// </summary>
    public record EiffelIssueVerifiedEvent :
        EiffelEvent<EiffelIssueVerifiedData, EiffelIssueVerifiedMeta, EiffelIssueVerifiedLinks>
    {
        /// <inheritdoc/>
        public override EiffelIssueVerifiedData Data { get; init; } = new();

        /// <inheritdoc/>
        [Required]
        public override EiffelIssueVerifiedMeta Meta { get; init; }

        /// <inheritdoc/>
        [Required]
        public override EiffelIssueVerifiedLinks Links { get; init; }

        /// <inheritdoc/>
        public override IEiffelEvent FromJson(string json)
        {
            return Deserialize<EiffelIssueVerifiedEvent>(json);
        }
    }
}