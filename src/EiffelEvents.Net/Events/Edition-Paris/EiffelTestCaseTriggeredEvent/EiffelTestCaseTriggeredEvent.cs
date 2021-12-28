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
    /// The <a href="https://github.com/eiffel-community/eiffel/blob/edition-paris/eiffel-vocabulary/EiffelTestCaseTriggeredEvent.md">
    /// EiffelTestCaseTriggeredEvent
    /// </a>
    /// declares that the execution of a test case has been triggered,
    /// but not yet started. This can either be declared stand-alone or as part of an activity or test suite,
    /// using either a CAUSE or a CONTEXT link type, respectively.
    /// </summary>
    public record EiffelTestCaseTriggeredEvent :
        EiffelEvent<EiffelTestCaseTriggeredData, EiffelTestCaseTriggeredMeta, EiffelTestCaseTriggeredLinks>
    {
        /// <inheritdoc/>
        public override EiffelTestCaseTriggeredData Data { get; init; } = new();

        /// <inheritdoc/>
        public override EiffelTestCaseTriggeredMeta Meta { get; init; } = new();

        /// <inheritdoc/>
        public override EiffelTestCaseTriggeredLinks Links { get; init; } = new();

        /// <inheritdoc/>
        public override IEiffelEvent FromJson(string json)
        {
            return Deserialize<EiffelTestCaseTriggeredEvent>(json);
        }
    }
}