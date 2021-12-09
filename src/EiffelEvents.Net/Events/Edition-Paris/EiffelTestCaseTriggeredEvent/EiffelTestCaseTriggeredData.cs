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
using EiffelEvents.Net.Events.Core.Data;
using EiffelEvents.Net.Events.Edition_Paris.Shared.Data;
using EiffelEvents.Net.Events.Edition_Paris.Shared.Enums;
using EiffelEvents.Net.Validation;

namespace EiffelEvents.Net.Events.Edition_Paris
{
    public record EiffelTestCaseTriggeredData : EiffelData
    {
        /// <summary>
        /// Identification of the test case to be executed.
        /// </summary>
        [Required]
        [NestedObject]
        public EiffelTestCase TestCase { get; init; }

        /// <summary>
        /// If triggering this test case execution was the result of an Execution Recipe, as defined by an
        /// EiffelTestExecutionRecipeCollectionCreatedEvent, this UUID SHALL match the relevant
        /// data.batches.recipes.id in that event.
        /// </summary>
        [ValidGuid]
        public string RecipeId { get; init; }

        /// <summary>
        /// The circumstances triggering the test case execution.
        /// </summary>
        [NestedList]
        public List<EiffelDataTrigger> Triggers { get; init; }

        /// <summary>
        /// The type of execution (often related to, but ultimately separate from, data.triggers.type).
        /// </summary>
        public EiffelDataExecutionType? ExecutionType { get; init; }

        /// <summary>
        /// A list of parameters to be passed to the test case execution.
        /// </summary>
        [NestedList]
        public List<EiffelParameter> Parameters { get; init; }
    }
}