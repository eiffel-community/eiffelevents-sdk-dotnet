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

using Eiffel.Net.Events.Core.Data;

namespace Eiffel.Net.Events.Edition_Paris
{
    public record EiffelFlowContextDefinedData : EiffelData
    {
        /// <summary>
        /// A product context which other events can relate to
        /// (e.g. "This activity is part of the Product X continuous integration system.").
        /// </summary>
        public string Product { get; init; }

        /// <summary>
        /// A project context which other events can relate to
        /// (e.g. "This test is part of the Killer Feature project.").
        /// </summary>
        public string Project { get; init; }

        /// <summary>
        /// A program context which other events can relate to
        /// (e.g. "This source change was made for the Zero Bugs program.").
        /// </summary>
        public string Program { get; init; }

        /// <summary>
        /// A track context which other events can relate to
        /// (e.g. "This feature was implemented in the Customer X Adaptations track.").
        /// </summary>
        public string Track { get; init; }

        /// <summary>
        /// A version context which other events can relate to.
        /// This member SHOULD be used in tandem with one of the other optional members -
        /// a version by itself is not very informative.
        /// </summary>
        public string Version { get; init; }
    }
}