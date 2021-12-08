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

namespace EiffelEvents.Net.Events.Edition_Paris
{
    public record EiffelTestExecutionDependency
    {
        /// <summary>
        /// The UUID of the dependency execution (data.batches.recipes.id), i.e. the execution that shall be
        /// performed prior to that of the dependent.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [ValidGuid]
        public string Dependency { get; init; }

        /// <summary>
        /// The UUID of the dependent execution (data.batches.recipes.id), i.e. the execution that shall be
        /// performed only after that of the dependency.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [ValidGuid]
        public string Dependent { get; init; }
    }
}