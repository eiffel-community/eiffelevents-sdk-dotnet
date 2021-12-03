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
using Eiffel.Net.Events.Edition_Paris.Shared;
using Eiffel.Net.Validation;

namespace Eiffel.Net.Events.Edition_Paris
{
    public record EiffelSourceChangeCreatedLinks : EiffelSharedLinks
    {
        /// <summary>
        /// Identifies the base revision of the created source change.
        /// Legal targets: EiffelSourceChangeSubmittedEvent
        /// </summary>
        [ValidGuid]
        public string Base { get; init; }

        /// <summary>
        /// Identifies a latest previous version (there may be more than one in case of merges) of the created source
        /// change.
        /// Legal targets: EiffelSourceChangeCreatedEvent
        /// </summary>
        [ValidGuid(IsMultiple = true)]
        public List<string> PreviousVersion { get; init; }

        /// <summary>
        /// Identifies an issue that this event partially resolves. That is, this SCC introduces some change that
        /// has advanced an issue towards a resolved state, but not completely resolved.
        /// Legal targets: EiffelIssueDefinedEvent
        /// </summary>
        [ValidGuid(IsMultiple = true)]
        public List<string> PartiallyResolvedIssue { get; init; }

        /// <summary>
        /// Identifies an issue that this SCC is claiming it has done enough to resolve.
        /// This is not an authoritative resolution, only a claim.
        /// The issue may or may not change status as a consequence this, e.g. through a successful verification, 
        ///<see cref="EiffelIssueVerifiedEvent"/>
        /// or  a manual update on the issue tracker.
        /// Legal targets: EiffelIssueDefinedEvent
        /// </summary>
        [ValidGuid(IsMultiple = true)]
        public List<string> ResolvedIssue { get; init; }

        /// <summary>
        /// Identifies an issue which was previously resolved, but that this SCC claims it has made changes to
        /// warrant removing the resolved status. For example, if an issue "Feature X" was resolved,
        /// but this SCC removed the implementation that led to "Feature X" being resolved,
        /// that issue should no longer be considered resolved.
        /// Legal targets: EiffelIssueDefinedEvent
        /// </summary>
        [ValidGuid(IsMultiple = true)]
        public List<string> DeresolvedIssue { get; init; }
    }
}