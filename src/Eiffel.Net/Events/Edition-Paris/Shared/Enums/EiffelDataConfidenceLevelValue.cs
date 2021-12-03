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
    /// The value of the confidence level.
    /// </summary>
    public enum EiffelDataConfidenceLevelValue
    {
        /// <summary>
        /// signifies that the confidence level has been successfully achieved
        /// </summary>
        SUCCESS, 
        
        /// <summary>
        /// signifies that the confidence level could not be achieved
        /// </summary>
        FAILURE,
        
        /// <summary>
        /// signifies that achievement of the confidence level could not be determined
        /// </summary>
        INCONCLUSIVE
    }
}