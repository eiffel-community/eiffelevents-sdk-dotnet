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
using EiffelEvents.Net.Events.Edition_Paris.Shared.Data;
using EiffelEvents.Net.Events.Edition_Paris.Shared.Enums;
using EiffelEvents.Net.Validation;

namespace EiffelEvents.Net.Events.Edition_Paris
{
    public record EiffelTestCaseOutcome
    {
        /// <summary>
        /// A terse standardized verdict on the item or items under test.
        /// </summary>
        [Required]
        public EiffelTestVerdict? Verdict { get; init; }

        /// <summary>
        /// A terse standardized conclusion of the test case, designed to be machine readable.
        /// </summary>
        [Required]
        public EiffelTestCaseOutcomeConclusion? Conclusion { get; init; }

        /// <summary>
        /// A verbose description of the test case outcome, designed to provide human readers with further information.
        /// </summary>
        public string Description { get; init; }

        /// <summary>
        /// A list of metrics collected during the test case execution.
        /// Note that while complete freedom is allowed in metrics names and value types,
        /// it is highly recommended to keep reported metrics concise and consistent.
        /// In other words, do not include excessive amounts of data (use data.persistentLogs for that),
        /// and avoid unnecessary variations in value names or types over time.
        /// </summary>
        [NestedList]
        public List<EiffelTestCaseOutcomeMetric> Metrics { get; init; }
    }
}