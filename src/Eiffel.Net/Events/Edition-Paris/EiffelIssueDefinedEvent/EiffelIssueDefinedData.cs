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
using Eiffel.Net.Events.Core.Data;
using Eiffel.Net.Events.Edition_Paris.Shared.Enums;

namespace Eiffel.Net.Events.Edition_Paris
{
    public record EiffelIssueDefinedData : EiffelData
    {
        /// <summary>
        /// The type of issue.
        /// </summary>
        [Required]
        public EiffelIssueType? Type { get; init; }

        /// <summary>
        /// The name of the issue tracker.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string Tracker { get; init; }

        /// <summary>
        /// The identity of the issue. This is tracker dependent - most trackers have their own issue naming schemes.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string Id { get; init; }

        /// <summary>
        /// A URI that links to a document describing the issue in depth.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string Uri { get; init; }

        /// <summary>
        /// A one-line title or summary of the issue. This exists mostly for human consumption,
        /// as "Implement widget X" is much more meaningful to a human when viewing a graph of Eiffel events than "1302".
        /// This is not meant  to be a detailed description, as such information should be accessible by following URI.
        /// </summary>
        public string Title { get; init; }
    }
}