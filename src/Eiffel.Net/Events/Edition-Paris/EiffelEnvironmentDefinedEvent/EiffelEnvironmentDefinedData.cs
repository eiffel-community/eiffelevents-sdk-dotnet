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
using Eiffel.Net.Validation;

namespace Eiffel.Net.Events.Edition_Paris
{
    public record EiffelEnvironmentDefinedData : EiffelData
    {
        /// <summary>
        /// The name of the environment.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string Name { get; init; }

        /// <summary>
        /// The version of the environment.
        /// </summary>
        public string Version { get; init; }

        /// <summary>
        /// A string identifying e.g. a Docker image.
        /// </summary>
        public string Image { get; init; }

        /// <summary>
        /// An object identifying a host.
        /// </summary>
        [Required]
        [NestedObject]
        public EiffelEnvironmentHost Host { get; init; }

        /// <summary>
        /// A URI identifying the environment description.
        /// </summary>
        public string Uri { get; init; }
    }
}