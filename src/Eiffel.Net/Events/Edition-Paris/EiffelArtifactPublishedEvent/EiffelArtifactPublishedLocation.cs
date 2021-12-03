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
using Eiffel.Net.Events.Edition_Paris.Shared.Enums;

namespace Eiffel.Net.Events.Edition_Paris
{
    /// <summary>
    /// Location of an artifact
    /// </summary>
    public record EiffelArtifactPublishedLocation
    {
        /// <summary>
        /// Identifies the name of the file within the artifact for which this location provides the URI.
        /// Must correspond to a <b> data.fileInformation.name </b> value in
        /// the EiffelArtifactCreatedEvent connected via the ARTIFACT link.
        /// </summary>
        public string Name { get; init; }

        /// <summary>
        /// The type of location. May be used by (automated) readers to understand the method of retrieval,
        /// particularly with regards to authentication.
        /// </summary>
        [Required]
        public EiffelArtifactLocationType? Type { get; init; }

        /// <summary>
        /// The URI at which the artifact can be retrieved.
        /// </summary>
        [Required]
        public string Uri { get; init; }
    }
}