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

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Eiffel.Net.Events.Edition_Paris.Shared.Data
{
    public record EiffelFileInformation
    {
        /// <summary>
        /// The name (including relative path from the root of the artifact) on syntax appropriate
        /// for the artifact packaging type.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string Name { get; init; }

        /// <summary>
        /// Any tags associated with the file, to support navigation and identification of items of interest.
        /// </summary>
        public List<string> Tags { get; init; }
    }
}