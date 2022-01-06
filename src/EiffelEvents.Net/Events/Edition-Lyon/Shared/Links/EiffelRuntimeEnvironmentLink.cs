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

namespace EiffelEvents.Net.Events.Edition_Lyon.Shared.Links
{
    /// <summary>
    /// Identifies a description of a runtime environment within which an activity has taken place. The target event could
    /// e.g. identify a Docker image, a JVM distribution archive, or a composition of operating system packages that were installed on the host system.
    /// This link type has the same purpose as the `data.image` member but allows richer and less ambiguous descriptions.
    /// </summary>
    public record EiffelRuntimeEnvironmentLink : EiffelLink
    {
        /// <inheritdoc/>
        public override string Type => "RUNTIME_ENVIRONMENT";

        /// <inheritdoc cref="EiffelRuntimeEnvironmentLink"/>
        public EiffelRuntimeEnvironmentLink()
        {
        }

        /// <inheritdoc cref="EiffelRuntimeEnvironmentLink"/>
        /// <inheritdoc cref="EiffelLink(string, string)"/>
        public EiffelRuntimeEnvironmentLink(string target, string domainId = "") : base(target, domainId)
        {
        }

    }
}