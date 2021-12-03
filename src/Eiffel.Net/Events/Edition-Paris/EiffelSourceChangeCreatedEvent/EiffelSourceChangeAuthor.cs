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

using Eiffel.Net.Validation;

namespace Eiffel.Net.Events.Edition_Paris
{
    /// <summary>
    /// The author of the change.
    /// </summary>
    public record EiffelSourceChangeAuthor
    {
        /// <summary>
        /// The name of the author.
        /// </summary>
        public string Name { get; init; }

        /// <summary>
        /// The email address of the author.
        /// </summary>
        [ValidMail]
        public string Email { get; init; }

        /// <summary>
        /// Any identity, username or alias of the author.
        /// </summary>
        public string Id { get; init; }

        /// <summary>
        /// Any group or organization to which the contributor belongs.
        /// </summary>
        public string Group { get; init; }
    }
}