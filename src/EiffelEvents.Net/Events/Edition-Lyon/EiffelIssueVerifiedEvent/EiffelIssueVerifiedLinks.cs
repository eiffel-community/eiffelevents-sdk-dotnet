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

using System.ComponentModel.DataAnnotations;
using EiffelEvents.Net.Events.Edition_Lyon.Shared;
using EiffelEvents.Net.Events.Edition_Lyon.Shared.Links;
using EiffelEvents.Net.Validation;


namespace EiffelEvents.Net.Events.Edition_Lyon
{
    public record EiffelIssueVerifiedLinks : EiffelSharedLinks
    {
        /// <summary>
        /// Identifies an issue that has been successfully verified.
        /// Legal target: EiffelIssueDefinedEvent
        /// </summary>
        [NestedObject]
        public EiffelSuccessfulIssueLink SuccessfulIssue { get; init; }

        /// <summary>
        /// Identifies an issue that has failed verification.
        /// Legal target: EiffelIssueDefinedEvent
        /// </summary>
        [NestedObject]
        public EiffelFailedIssueLink FailedIssue { get; init; }

        /// <summary>
        /// Identifies an issue for which this verification was inconclusive.
        /// Legal target: EiffelIssueDefinedEvent
        /// </summary>
        [NestedObject]
        public EiffelInconclusiveIssueLink InconclusiveIssue { get; init; }

        /// <summary>
        /// Identifies the Item Under Test; in other words, the entity for which the issue has been verified.
        /// Legal target: EiffelArtifactCreatedEvent, EiffelCompositionDefinedEvent.
        /// </summary>
        [Required]
        [NestedObject]
        public EiffelIutLink Iut { get; init; }

        /// <summary>
        /// Used to declare the basis on which the verification statement(s) of this event have been issued.
        /// Legal target: EiffelTestCaseFinishedEvent, EiffelTestSuiteFinishedEvent.
        /// </summary>
        [NestedObject]
        public EiffelVerificationBasisLink VerificationBasis { get; init; }

        /// <summary>
        /// Identifies the environment in which the issue was verified.
        /// Legal target: EiffelEnvironmentDefinedEvent.
        /// </summary>
        [NestedObject]
        public EiffelEnvironmentLink Environment { get; init; }
  
    }
}