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
    /// Trigger types.
    /// </summary>
    public enum EiffelDataTriggerType
    {
        /// <summary>
        /// Signifies that the activity was manually triggered.  
        /// </summary>
        MANUAL, 
        
        /// <summary>
        /// signifies that the activity was triggered by one or more Eiffel events.
        /// These events should be represented via CAUSE links. 
        /// </summary>
        EIFFEL_EVENT, 
        
        /// <summary>
        /// Signifies that the activity was triggered as a consequence of a detected source change not represented
        /// by Eiffel events.  
        /// </summary>
        SOURCE_CHANGE, 
        
        /// <summary>
        /// Signifies that the activity was triggered by a timer.  
        /// </summary>
        TIMER, 
        
        /// <summary>
        /// Signifies any other triggering cause.
        /// </summary>
        OTHER
        
        
    }
}
