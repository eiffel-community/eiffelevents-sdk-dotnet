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
    /// The <a href="https://github.com/eiffel-community/eiffel/blob/edition-paris/eiffel-vocabulary/EiffelTestCaseCanceledEvent.md">EiffelTestCaseCanceledEvent</a>
    /// declares that a previously triggered test case execution
    /// (represented by <see cref="EiffelTestCaseTriggeredEvent"/>) has been canceled before it has started.
    /// This is typically used in queuing situations where a queued execution is dequeued.
    /// It is recommended that CAUSE links be used to indicate the reason.
    /// </summary>
    public record EiffelTestCaseCanceledEvent :
        EiffelEvent<EiffelTestCaseCanceledData, EiffelTestCaseCanceledMeta, EiffelTestCaseCanceledLinks>
    {
        /// <inheritdoc/>
        public override EiffelTestCaseCanceledData Data { get; init; } = new();
        
        /// <inheritdoc/>
        public override EiffelTestCaseCanceledMeta Meta { get; init; } = new();
        
        /// <inheritdoc/>
        public override EiffelTestCaseCanceledLinks Links { get; init; } = new();
        public override IEiffelEvent FromJson(string json)
        {
            return Deserialize<EiffelTestCaseCanceledEvent>(json);
        }
    }
}