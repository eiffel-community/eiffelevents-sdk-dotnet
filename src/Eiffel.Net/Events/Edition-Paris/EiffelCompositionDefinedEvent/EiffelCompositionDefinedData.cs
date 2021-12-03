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
using Eiffel.Net.Events.Core.Data;

namespace Eiffel.Net.Events.Edition_Paris
{
    public record EiffelCompositionDefinedData : EiffelData
    {
        /// <summary>
        /// The name of the composition.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string Name { get; init; }

        /// <summary>
        /// The version of the composition, if any. This is in a sense redundant, as relationships between compositions
        /// can be tracked via the PREVIOUS_VERSION link type, but can be used for improved clarity and semantics.
        /// </summary>
        public string Version { get; init; }
    }
}