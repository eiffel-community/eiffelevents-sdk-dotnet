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

namespace EiffelEvents.Net.Events.Edition_Paris.Shared.Enums
{
    /// <summary>
    /// A terse standardized conclusion of the test suite, designed to be machine readable.
    /// </summary>
    public enum EiffelTestSuiteOutcomeConclusion
    {
        /// <summary>
        /// Signifies that the test suite was successfully concluded.
        /// Note that this does not imply that the item under test passed the tests.
        /// </summary>
        SUCCESSFUL,

        /// <summary>
        /// Signifies that the test suite could not be successfully executed. To exemplify,
        /// one or more tests failed to run due to required environments being unavailable.  
        /// </summary>
        FAILED,

        /// <summary>
        /// Signifies that the test suite was aborted before it could be concluded.  
        /// </summary>
        ABORTED,

        /// <summary>
        /// signifies that the test suite did not conclude within the allowed time frame.
        /// </summary>
        TIMED_OUT,

        /// <summary>
        /// signifies that the outcome of the test suite could not be determined.
        /// </summary>
        INCONCLUSIVE
    }
}