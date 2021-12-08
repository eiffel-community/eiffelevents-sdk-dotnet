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
using EiffelEvents.Net.Common;
using EiffelEvents.Net.Validation;

namespace EiffelEvents.Net.Events.Edition_Paris
{
    public record EiffelTestExecutionRecipe
    {
        /// <summary>
        /// A UUID identifying the unique execution. Note that this is different from the id of a test case, in two ways.
        /// First, a test case is a (presumably) persistant entity, whereas an execution is transient in nature.
        /// Second, a test case may be executed any number of times in any given recipe collection.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [ValidGuid]
        public string Id { get; init; }

        /// <summary>
        /// The test case to be executed in this execution recipe.
        /// </summary>
        [Required]
        [NestedObject]
        public EiffelTestExecutionTestCase TestCase { get; init; }

        /// <summary>
        /// Any constraints of the execution. The nature of such constraints is highly dependent on technology domain
        /// and test execution framework. Consequently, there are no pre-defined or required constraints.
        /// Instead, this property is a list of key-value pairs on the same format as data.customData.
        /// That being said, there are three questions that typically need to be answered: what is the item under test,
        /// in what kind of environment is it to be tested, and what are the test parameters?
        /// </summary>
        [ValidDictionary]
        public EiffelDictionary Constraints { get; init; }
    }
}