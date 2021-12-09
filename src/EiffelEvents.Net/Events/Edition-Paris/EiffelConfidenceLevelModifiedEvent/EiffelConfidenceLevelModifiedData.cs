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
using EiffelEvents.Net.Events.Core.Data;
using EiffelEvents.Net.Events.Edition_Paris.Shared.Enums;
using EiffelEvents.Net.Validation;

namespace EiffelEvents.Net.Events.Edition_Paris
{
    public record EiffelConfidenceLevelModifiedData : EiffelData
    {
        /// <summary>
        /// The name of the confidence level. The name of the confidence level. It is recommended for confidence level names
        /// to conform with camelCase formatting, in line with the format of key names of the Eiffel protocol as a whole.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string Name { get; init; }

        /// <summary>
        /// The value of the confidence level.
        /// </summary>
        [Required]
        public EiffelDataConfidenceLevelValue? Value { get; init; }

        /// <summary>
        /// The individual or entity issuing the confidence level
        /// </summary>
        [NestedObject]
        public EiffelConfidenceLevelModifiedIssuer Issuer { get; init; }
    }
}