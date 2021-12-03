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
using Eiffel.Net.Events.Edition_Paris.Shared;
using Eiffel.Net.Validation;

namespace Eiffel.Net.Events.Edition_Paris
{
    public record EiffelTestCaseCanceledLinks : EiffelSharedLinks
    {
        /// <summary>
        /// Identifies the relevant test case execution.
        /// In other words, EiffelTestCaseTriggeredEvent acts as a handle for a particular test case execution.
        /// This differs from CONTEXT. In TEST_CASE_EXECUTION the source carries information pertaining to the target
        /// (i.e. the test case execution started, finished or was canceled). In CONTEXT, on the other hand,
        /// the source constitutes a subset of the target (e.g. this test case was executed as part of that activity or test suite).
        /// Legal targets: EiffelTestCaseTriggeredEvent
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [ValidGuid]
        public string TestCaseExecution { get; init; }
    }
}