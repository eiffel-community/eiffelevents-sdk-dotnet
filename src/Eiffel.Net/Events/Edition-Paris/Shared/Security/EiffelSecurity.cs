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
using Eiffel.Net.Validation;

namespace Eiffel.Net.Events.Edition_Paris.Shared.Security
{
    /// <summary>
    /// Eiffel event security information
    /// </summary>
    public record EiffelSecurity
    {
        /// <summary>
        /// Identity of the author that signs this event, in Distinguished Name format.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string AuthorIdentity { get; init; }

        /// <summary>
        /// Integrity protection / signature of the event
        /// </summary>
        [NestedObject]
        public EiffelIntegrityProtection IntegrityProtection { get; init; }

        /// <summary>
        /// Sequence protection of the event
        /// </summary>
        [NestedList]
        public List<EiffelSequenceProtection> SequenceProtection { get; init; }
    }
}
