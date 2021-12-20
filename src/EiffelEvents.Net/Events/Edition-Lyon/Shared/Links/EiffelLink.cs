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
using EiffelEvents.Net.Validation;

namespace EiffelEvents.Net.Events.Edition_Lyon.Shared.Links
{
    public abstract record EiffelLink
    {
        /// <summary>
        /// Link type
        /// </summary>
        public abstract string Type { get; }

        /// <summary>
        /// UUID corresponding to the meta.id of the target event, on string format
        /// </summary>
        [ValidGuid(IsMultiple = false)]
        [Required(AllowEmptyStrings = false)]
        public string Target { get; init; }

        /// <summary>
        /// Optionally the id of the domain where the target event was published (i.e. its meta.source.domainId member).
        /// The absence of a domain id means that the target event was sent in, or can at least be retrieved from,
        /// the same domain as the current event.
        /// </summary>
        public string DomainId { get; init; }

        protected EiffelLink()
        {
        }

        protected EiffelLink(string target, string domainId = "")
        {
            Target = target;
            if (!string.IsNullOrWhiteSpace(domainId)) 
                DomainId = domainId;
        }
    }
}