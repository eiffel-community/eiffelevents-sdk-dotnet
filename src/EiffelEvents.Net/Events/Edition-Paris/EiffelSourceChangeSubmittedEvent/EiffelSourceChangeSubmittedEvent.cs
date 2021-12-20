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
using EiffelEvents.Net.Events.Core;
using EiffelEvents.Net.Events.Edition_Paris.Shared;

namespace EiffelEvents.Net.Events.Edition_Paris
{
    /// <summary>
    /// The <a href="https://github.com/eiffel-community/eiffel/blob/edition-paris/eiffel-vocabulary/EiffelSourceChangeSubmittedEvent.md">
    /// EiffelSourceChangeSubmittedEvent</a> declares that a change has been integrated into to a shared source branch
    /// of interest (e.g. "master", "dev" or "mainline") as opposed to a private or local branch.
    /// Note that it does not describe what has changed, but instead uses the CHANGE link type to
    /// reference <see cref="EiffelSourceChangeCreatedEvent"/>.
    /// </summary>
    public record EiffelSourceChangeSubmittedEvent :
        EiffelEvent<EiffelSourceChangeSubmittedData, EiffelSourceChangeSubmittedMeta, EiffelSourceChangeSubmittedLinks>
    {
        /// <inheritdoc/>
        public override EiffelSourceChangeSubmittedData Data { get; init; }

        /// <inheritdoc/>
        public override EiffelSourceChangeSubmittedMeta Meta { get; init; }

        /// <inheritdoc/>
        public override EiffelSourceChangeSubmittedLinks Links { get; init; }

        /// <inheritdoc/>
        public override IEiffelEvent FromJson(string json)
        {
            return Deserialize<EiffelSourceChangeSubmittedEvent>(json);
        }
    }
}