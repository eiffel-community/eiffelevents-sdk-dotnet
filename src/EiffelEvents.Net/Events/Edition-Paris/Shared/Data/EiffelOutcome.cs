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
using EiffelEvents.Net.Events.Edition_Paris.Shared.Enums;

namespace EiffelEvents.Net.Events.Edition_Paris.Shared.Data
{
    public record EiffelOutcome
    {
        /// <summary>
        /// A terse standardized conclusion of the activity, designed to be machine readable.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public EiffelDataOutcomeConclusion? Conclusion { get; init; }

        /// <summary>
        /// A verbose description of the activity outcome, designed to provide human readers with further information.
        /// </summary>
        public string Description { get; init; }  
    }
}