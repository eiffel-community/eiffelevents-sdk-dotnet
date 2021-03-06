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

using System.Collections.Generic;
using EiffelEvents.Net.Events.Core.Data;
using EiffelEvents.Net.Events.Edition_Lyon.Shared.Data;
using EiffelEvents.Net.Validation;

namespace EiffelEvents.Net.Events.Edition_Lyon
{
    public record EiffelTestCaseStartedData : EiffelData
    {
        /// <summary>
        /// The name of the test case executor, if applicable.
        /// This property can be used to identify tests executed by a particular test framework.
        /// </summary>
        public string Executor { get; init; }
        
        /// <summary>
        /// An array of live log files available during execution. These shall not be presumed to be stored
        /// persistently; in other words, once the test case execution has finished there is no guarantee that these
        /// links are valid. Persistently stored logs shall be (re-)declared by EiffelTestCaseFinishedEvent.
        /// </summary>
        [NestedList]
        public List<EiffelLiveLog> LiveLogs { get; init; }
    }    
}

