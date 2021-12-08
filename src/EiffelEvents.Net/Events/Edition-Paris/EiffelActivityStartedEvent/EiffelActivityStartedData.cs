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
using EiffelEvents.Net.Events.Edition_Paris.Shared.Data;
using EiffelEvents.Net.Validation;

namespace EiffelEvents.Net.Events.Edition_Paris
{
    public record EiffelActivityStartedData : EiffelData
    {
        /// <summary>
        /// Any URI at which further information about the execution may be found;
        /// a typical use case is to link a CI server job execution page.
        /// </summary>
        public string ExecutionUri { get; init; }

        /// <summary>
        /// An array of live log files available during execution
        /// </summary>
        [NestedList]
        public List<EiffelLiveLog> LiveLogs { get; init; }
    }
}