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
using Eiffel.Net.Events.Core.Data;
using Eiffel.Net.Events.Edition_Paris.Shared.Data;
using Eiffel.Net.Validation;

namespace Eiffel.Net.Events.Edition_Paris
{
    public record EiffelTestExecutionRecipeCollectionCreatedData : EiffelData
    {
        /// <summary>
        /// The strategy used to select the test cases and generate the recipe collection
        /// </summary>
        [Required]
        [NestedObject]
        public EiffelSelectionStrategy SelectionStrategy { get; init; }

        /// <summary>
        /// A URI at which at which the array of test execution batches can be fetched.
        /// The format of the document at this URI SHALL be on the format prescribed by
        /// data.batches (i.e. [ { "name": "Batch 1", ...}, {...}]).
        /// Each event SHALL include one and only one of data.batches and data.batchesUri.
        /// </summary>
        public string BatchesUri { get; init; }

        /// <summary>
        /// A list of batches of recipes. Each event SHALL include one and only one of data.batches and data.batchesUri.
        /// In the interest of keeping message sizes small, it is recommended to use data.batches only for limited
        /// numbers of test cases (on the order of ten executions). For larger numbers of executions,
        /// data.batchesUri SHOULD be used instead.
        /// </summary>
        [NestedList]
        public List<EiffelBatch> Batches { get; init; }
    }
}