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
    /// The <a href="https://github.com/eiffel-community/eiffel/blob/edition-lyon/eiffel-vocabulary/EiffelTestCaseFinishedEvent.md">
    /// EiffelTestCaseFinishedEvent </a> declares that a previously started test case
    /// (declared by <see cref="EiffelTestCaseStartedEvent"/> ) has finished and reports the outcome.
    /// </summary>
    public record EiffelTestCaseFinishedEvent :
        EiffelEvent<EiffelTestCaseFinishedData, EiffelTestCaseFinishedMeta, EiffelTestCaseFinishedLinks>
    {
        /// <inheritdoc/>
        public override EiffelTestCaseFinishedData Data { get; init; } = new();
        
        /// <inheritdoc/>
        public override EiffelTestCaseFinishedMeta Meta { get; init; } = new();
        
        /// <inheritdoc/>
        public override EiffelTestCaseFinishedLinks Links { get; init; } = new();

        /// <inheritdoc/>
        public override IEiffelEvent FromJson(string json)
        {
            return Deserialize<EiffelTestCaseFinishedEvent>(json);
        }
    }
}