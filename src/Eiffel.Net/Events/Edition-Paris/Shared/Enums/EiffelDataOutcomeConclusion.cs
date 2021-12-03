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
    public enum EiffelDataOutcomeConclusion
    {
        /// <summary>
        /// Signifies that the activity was concluded and the outcome matched expectations.
        /// </summary>
        SUCCESSFUL, 
        
        /// <summary>
        /// Signifies that the activity was concluded, but the outcome did not match expectations.
        /// To exemplify, a compilation job was successfully invoked, but compilation failed.  
        /// </summary>
        UNSUCCESSFUL, 
        
        /// <summary>
        /// signifies that the activity could not be successfully executed.
        /// To exemplify, a compilation could not be invoked, e.g. due to misconfiguration or environment issues.  
        /// </summary>
        FAILED, 
        
        /// <summary>
        /// Signifies that the activity was aborted before it could be concluded.  
        /// </summary>
        ABORTED, 
        
        /// <summary>
        /// Signifies that the activity did not conclude within the allowed time frame.
        /// </summary>
        TIMED_OUT, 
        
        /// <summary>
        /// Signifies that the outcome of the activity could not be determined.
        /// </summary>
        INCONCLUSIVE
    }
}