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
using System.ComponentModel.DataAnnotations;
using EiffelEvents.Net.Events.Core.Data;
using EiffelEvents.Net.Events.Edition_Lyon.Shared.Data;
using EiffelEvents.Net.Events.Edition_Paris.Shared.Enums;
using EiffelEvents.Net.Validation;

namespace EiffelEvents.Net.Events.Edition_Lyon
{
    public record EiffelTestSuiteStartedData : EiffelData
    {
        /// <summary>
        /// The name of the test suite. Uniqueness is not required or checked, but is useful.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string Name { get; init; }

        /// <summary>
        /// The category or categories of the test suite. This can be used to group multiple similar test suites for
        /// analysis and visualization purposes. Example usage is to categorize test suites required before release
        /// as "Pre-release tests".
        /// </summary>
        public List<string> Categories { get; init; }

        /// <summary>
        /// The type or types of testing performed by the test suite, as  defined by
        /// <a href="http://www.softwaretestingstandard.org"> ISO 29119</a>
        /// </summary>
        public List<EiffelDataTestingType> Types { get; init; }

        /// <summary>
        /// An array of live log files available during execution. These shall not be presumed to be stored persistently;
        /// in other words, once the test suite has finished there is no guarantee that these links are valid.
        /// Persistently stored logs shall be (re-)declared by <see cref="EiffelTestSuiteFinishedEvent"/>
        /// </summary>
        [NestedList]
        public List<EiffelLiveLog> LiveLogs { get; init; }
    }
}