﻿//    Copyright (c) 2021 ICT Cube, doWhile, and Eiffel Community collaborators.
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

namespace Eiffel.Net.Events.Edition_Paris
{
    /// <summary>
    /// The strategy used to select the test cases and generate the recipe collection
    /// </summary>
    public record EiffelSelectionStrategy
    {
        /// <summary>
        /// The name of the selection strategy that generated the test execution recipe collection.
        /// </summary>
        public string Tracker { get; init; }

        /// <summary>
        /// The unique identity of the selection strategy that generated the test execution recipe collection.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string Id { get; init; }

        /// <summary>
        /// The URI at which the the selection strategy that generated the test execution recipe collection can be
        /// retrieved.
        /// </summary>
        public string Uri { get; init; }
    }
}