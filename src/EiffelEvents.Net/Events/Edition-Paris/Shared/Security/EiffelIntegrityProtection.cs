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

namespace EiffelEvents.Net.Events.Edition_Paris.Shared.Security
{
    /// <summary>
    /// Integrity protection / signature information
    /// </summary>
    public record EiffelIntegrityProtection
    {
        /// <summary>
        /// Cryptographic algorithm used to digitally sign the event.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string Alg { get; init; }

        /// <summary>
        /// Content signature
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string Signature { get; init; }

        /// <summary>
        /// Public key corresponding to the private key used to sign the event.
        /// </summary>
        public string PublicKey { get; init; }
    }
}