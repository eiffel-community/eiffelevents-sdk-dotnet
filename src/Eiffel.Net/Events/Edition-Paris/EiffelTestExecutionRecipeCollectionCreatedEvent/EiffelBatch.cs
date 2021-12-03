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

namespace Eiffel.Net.Events.Edition_Paris
{
    public record EiffelBatch
    {
        /// <summary>
        /// The name of the recipe batch.
        /// </summary>
        public string Name { get; init; }

        /// <summary>
        /// The execution priority of the batch, as compared to other batches in the collection.
        /// A lower value SHALL be interpreted as a higher priority.
        /// </summary>
        [Required]
        public int Priority { get; init; }

        /// <summary>
        /// The collection of test execution recipes within the batch.
        /// </summary>
        [Required]
        [NestedList]
        public List<EiffelTestExecutionRecipe> Recipes { get; init; }

        /// <summary>
        /// A list of test case execution dependencies. Ideally, test cases are atomic and can be executed in isolation.
        /// In cases where a test case assumes that another test case has been executed previously in the same
        /// environment, however, this property can be used to specify that. It serves as an instruction to the test
        /// executor to place two executions subsequent to one another in the same environment.
        /// </summary>
        [NestedList]
        public List<EiffelTestExecutionDependency> Dependencies { get; init; }
    }
}