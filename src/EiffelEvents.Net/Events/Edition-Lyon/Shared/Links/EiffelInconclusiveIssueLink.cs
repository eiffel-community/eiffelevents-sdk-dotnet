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
    /// Identifies an issue for which this verification was inconclusive.
    /// </summary>
    public record EiffelInconclusiveIssueLink : EiffelLink
    {
        /// <inheritdoc/>
        public override string Type => "INCONCLUSIVE_ISSUE";

        /// <inheritdoc cref="EiffelInconclusiveIssueLink"/>
        public EiffelInconclusiveIssueLink()
        {
        }

        /// <inheritdoc cref="EiffelInconclusiveIssueLink"/>
        /// <inheritdoc cref="EiffelLink(string, string)"/>
        public EiffelInconclusiveIssueLink(string target, string domainId = "") : base(target, domainId)
        {
        }

    }
}