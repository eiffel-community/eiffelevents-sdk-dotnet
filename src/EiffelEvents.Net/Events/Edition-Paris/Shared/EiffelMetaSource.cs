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

using EiffelEvents.Net.Common;

namespace EiffelEvents.Net.Events.Edition_Paris.Shared
{
    /// <summary>
    /// Eiffel meta source
    /// </summary>
    public record EiffelMetaSource
    {
        /// <summary>
        /// Identifies the domain that produced an event
        /// </summary>
        public string DomainId { get; init; }

        /// <summary>
        /// The hostname of the event sender
        /// </summary>
        public string Host { get; init; }

        /// <summary>
        /// The name of the event sender
        /// </summary>
        public string Name { get; init; }

        /// <summary>
        /// The identity of the serializer software used to construct the event, in purl format.
        /// </summary>
        public string Serializer { get; init; } = $"pkg:nuget/EiffelEvents.Net@{AssemblyHelper.GetAssemblyVersion()}";

        /// <summary>
        /// The URI of, related to or describing the event sender
        /// </summary>
        public string Uri { get; init; }
    }
}