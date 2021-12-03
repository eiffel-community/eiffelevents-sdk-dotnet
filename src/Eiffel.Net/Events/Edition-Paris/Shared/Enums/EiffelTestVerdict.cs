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

namespace Eiffel.Net.Events.Edition_Paris.Shared.Enums
{
    /// <summary>
    /// A terse standardized verdict on the item or items under test.
    /// </summary>
    public enum EiffelTestVerdict
    {
        /// <summary>
        /// Signifies that the item or items under test successfully passed the test.
        /// </summary>
        PASSED,

        /// <summary>
        /// Signifies that the item or items under test failed to pass the test.
        /// </summary>
        FAILED,

        /// <summary>
        /// Signifies that the verdict of the test was inconclusive.
        /// This SHOULD be the case if data.outcome.conclusion is not SUCCESSFUL, but may in combination
        /// with a SUCCESSFUL conclusion be used to represent unreliability or flakiness.
        /// </summary>
        INCONCLUSIVE
    }
}