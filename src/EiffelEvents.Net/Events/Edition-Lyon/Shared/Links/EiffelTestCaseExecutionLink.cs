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

namespace EiffelEvents.Net.Events.Edition_Lyon.Shared.Links
{
    /// <summary>
    /// Identifies the relevant test case execution. In other words, <see cref="EiffelTestCaseTriggeredEvent"> acts as a handle for
    /// a particular test case execution.  This differs from <see cref="EiffelContextLink"/>.
    /// In EiffelTestCaseExecutionLink the source carries information pertaining to the target (i.e. the test case execution started, finished or was canceled).
    /// </summary>
    public record EiffelTestCaseExecutionLink : EiffelLink
    {
        /// <inheritdoc/>
        public override string Type => "TEST_CASE_EXECUTION";

        /// <inheritdoc cref="EiffelTestCaseExecutionLink"/>
        public EiffelTestCaseExecutionLink()
        {
        }

        /// <inheritdoc cref="EiffelTestCaseExecutionLink"/>
        /// <inheritdoc cref="EiffelLink(string, string)"/>
        public EiffelTestCaseExecutionLink(string target, string domainId = "") : base(target, domainId)
        {
        }

    }
}