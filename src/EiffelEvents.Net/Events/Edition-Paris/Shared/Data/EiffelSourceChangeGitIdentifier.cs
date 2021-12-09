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

namespace EiffelEvents.Net.Events.Edition_Paris.Shared.Data
{
    /// <summary>
    /// Identifier of a Git change.
    /// </summary>
    public record EiffelSourceChangeGitIdentifier
    {
        /// <summary>
        /// The commit identity (hash) of the change.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string CommitId { get; init; }

        /// <summary>
        /// The name of the branch where the change was made.
        /// </summary>
        public string Branch { get; init; }

        /// <summary>
        /// The name of the repository containing the change.
        /// </summary>
        public string RepoName { get; init; }

        /// <summary>
        /// The URI of the repository containing the change.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string RepoUri { get; init; }
    }
}