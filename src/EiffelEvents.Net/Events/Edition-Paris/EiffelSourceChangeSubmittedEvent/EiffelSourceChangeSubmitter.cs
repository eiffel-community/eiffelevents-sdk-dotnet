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

using EiffelEvents.Net.Validation;

namespace EiffelEvents.Net.Events.Edition_Paris
{
    /// <summary>
    /// The agent (individual, group or machine) submitting the change. This is crucially different from the
    /// data.author field of EiffelSourceChangeCreatedEvent.
    /// </summary>
    public record EiffelSourceChangeSubmitter
    {
        /// <summary>
        /// The name of the submitter
        /// </summary>
        public string Name { get; init; }

        /// <summary>
        /// The email address of the submitter
        /// </summary>
        [ValidMail]
        public string Email { get; init; }

        /// <summary>
        /// Any identity, username or alias of the submitter
        /// </summary>
        public string Id { get; init; }

        /// <summary>
        /// Any group or organization to which the submitter belongs
        /// </summary>
        public string Group { get; init; }
    }
}