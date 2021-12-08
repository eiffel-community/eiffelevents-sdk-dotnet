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

namespace EiffelEvents.Net.Events.Edition_Paris
{
    /// <summary>
    /// A summary of the change.
    /// </summary>
    public class EiffelSourceChange
    {
        /// <summary>
        /// The number of inserted lines in the change.
        /// </summary>
        public int Insertions { get; init; }

        /// <summary>
        /// The number of deleted lines in the change.
        /// </summary>
        public int Deletions { get; init; }

        /// <summary>
        /// A URI to a list of files changed, on JSON String array format.
        /// </summary>
        public string Files { get; init; }

        /// <summary>
        /// A URI to further details about the change. These details are not assumed to be on any standardized format,
        /// and may be intended for human and/or machine consumption.
        /// Examples include e.g. Gerrit patch set descriptions or GitHub commit pages.
        /// It is recommended to also include data.change.tracker to provide a hint as to the nature of the linked
        /// details.
        /// </summary>
        public string Details { get; init; }

        /// <summary>
        /// The name of the tracker, if any, of the change. Examples include e.g. Gerrit or GitHub.
        /// </summary>
        public string Tracker { get; init; }

        /// <summary>
        /// The unique identity, if any, of the change (apart from what is expressed in the identifier object).
        /// Examples include e.g. Gerrit Change-Ids or GitHub Pull Requests.
        /// It is recommended to also include data.change.tracker to provide a hint as to the nature of the identity.
        /// </summary>
        public string Id { get; init; }
    }
}