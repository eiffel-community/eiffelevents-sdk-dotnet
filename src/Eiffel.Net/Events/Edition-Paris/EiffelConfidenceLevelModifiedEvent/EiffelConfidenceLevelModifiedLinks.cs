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
using Eiffel.Net.Events.Edition_Paris.Shared;
using Eiffel.Net.Validation;

namespace Eiffel.Net.Events.Edition_Paris
{
    public record EiffelConfidenceLevelModifiedLinks : EiffelSharedLinks
    {
        /// <summary>
        /// Identifies a subject of the confidence level; in other words, what the confidence level applies to.
        /// Legal targets: EiffelCompositionDefinedEvent, EiffelArtifactCreatedEvent, EiffelSourceChangeCreatedEvent,
        /// EiffelSourceChangeSubmittedEvent
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [ValidGuid(IsMultiple = true)]
        public List<string> Subject { get; init; }

        /// <summary>
        /// Used in events summarizing multiple confidence levels.
        /// Example use case: the confidence level "allTestsOk" summarizes the confidence levels "unitTestsOk,
        /// "scenarioTestsOk" and "deploymentTestsOk", and consequently links to them via SUB_CONFIDENCE_LEVEL.
        /// This is intended for purely descriptive, rather than prescriptive, use.
        /// Legal targets: EiffelConfidenceLevelModifiedEvent
        /// </summary>
        [ValidGuid(IsMultiple = true)]
        public List<string> SubConfidenceLevel { get; init; }
    }
}