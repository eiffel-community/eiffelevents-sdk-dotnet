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

namespace EiffelEvents.Net.Events.Edition_Lyon.Shared.Links
{
    /// <summary>
    /// Identifies an issue that has failed verification.
    /// </summary>
    public record EiffelFailedIssueLink : EiffelLink
    {
        /// <inheritdoc/>
        public override string Type => "FAILED_ISSUE";

        /// <inheritdoc cref="EiffelFailedIssueLink"/>
        public EiffelFailedIssueLink()
        {
        }

        /// <inheritdoc cref="EiffelFailedIssueLink"/>
        /// <inheritdoc cref="EiffelLink(string, string)"/>
        public EiffelFailedIssueLink(string target, string domainId = "") : base(target, domainId)
        {
        }

    }
}