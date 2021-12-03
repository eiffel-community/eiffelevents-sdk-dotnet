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

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Eiffel.Net.Events.Core.Data;
using Eiffel.Net.Events.Edition_Paris.Shared.Data;
using Eiffel.Net.Events.Edition_Paris.Shared.Enums;
using Eiffel.Net.Validation;

namespace Eiffel.Net.Events.Edition_Paris
{
    public record EiffelArtifactCreatedData : EiffelData
    {
        /// <summary>
        /// The identity of the created artifact, in
        /// <a href="https://github.com/package-url/purl-spec">
        /// purl format.
        /// </a>
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string Identity { get; init; }

        /// <summary>
        /// A list of the artifact file contents.
        /// </summary>
        [NestedList]
        public List<EiffelFileInformation> FileInformation { get; init; }

        /// <summary>
        /// The command used to build the artifact within the identified environment.
        /// </summary>
        public string BuildCommand { get; init; }

        /// <summary>
        /// Defines whether this artifact requires an implementing artifact. 
        /// </summary>
        public EiffelDataRequiresImplementation? RequiresImplementation { get; init; }
        
        /// <summary>
        /// An array of
        /// <a href="https://github.com/package-url/purl-spec">
        /// purl identified
        /// </a>
        /// entities this artifact implements.
        /// </summary>
        public List<string> Implements { get; init; }

        /// <summary>
        /// An array of
        /// <a href="https://github.com/package-url/purl-spec">
        /// purl identified
        /// </a>
        /// entities this artifact depends on.
        /// </summary>
        public List<string> DependsOn { get; init; }

        /// <summary>
        /// Any (colloquial) name of the artifact. Unlike "data.identity",
        /// this is not intended as an unambiguous identifier of the artifact, but as a descriptive and human readable name.
        /// </summary>
        public string Name { get; init; }
    }
}