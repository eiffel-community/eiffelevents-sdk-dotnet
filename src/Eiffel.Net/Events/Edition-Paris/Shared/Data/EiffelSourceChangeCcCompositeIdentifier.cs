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
    /// <summary>
    /// Identifier of a composite ClearCase change – in other words, not single file commit, but analogous
    /// of repository-wide commits of e.g. SVN or Git.
    /// </summary>
    public record EiffelSourceChangeCcCompositeIdentifier
    {
        /// <summary>
        /// The names of the changed ClearCase VOBs.
        /// </summary>
        [Required]
        public List<string> Vobs { get; init; }

        /// <summary>
        /// The branch of the change.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string Branch { get; init; }

        /// <summary>
        /// The URI of the relevant ClearCase config spec.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string ConfigSpec { get; init; }
    }
}