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
    /// Identifies the composition from which this artifact was built.
    /// </summary>
    public record EiffelCompositionLink : EiffelLink
    {
        /// <inheritdoc/>
        public override string Type => "COMPOSITION";

        /// <inheritdoc cref="EiffelCompositionLink"/>
        public EiffelCompositionLink()
        {
        }

        /// <inheritdoc cref="EiffelCompositionLink"/>
        /// <inheritdoc cref="EiffelLink(string, string)"/>
        public EiffelCompositionLink(string target, string domainId = "") : base(target, domainId)
        {
        }

    }
}