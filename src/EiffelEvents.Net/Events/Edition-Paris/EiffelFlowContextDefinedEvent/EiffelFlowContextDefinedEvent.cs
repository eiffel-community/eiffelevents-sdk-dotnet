﻿//    Copyright (c) 2021 ICT Cube, doWhile, and Eiffel Community collaborators.
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
    /// The
    /// <a href="https://github.com/eiffel-community/eiffel/blob/edition-paris/eiffel-vocabulary/EiffelFlowContextDefinedEvent.md">
    /// EiffelFlowContextDefinedEvent
    /// </a> describes the context of other events,
    /// answering questions such as "Which project is this change part of?" or
    /// "Which track does this artifact belong to?".
    /// In this way it offers a method of classifying and structuring one's continuous integration and delivery
    /// system and thereby facilitating traceability and searchability.
    /// </summary>
    public record EiffelFlowContextDefinedEvent :
        EiffelEvent<EiffelFlowContextDefinedData, EiffelFlowContextDefinedMeta, EiffelFlowContextDefinedLinks>
    {
        /// <inheritdoc/>
        public override EiffelFlowContextDefinedData Data { get; init; } = new();

        /// <inheritdoc/>
        public override EiffelFlowContextDefinedMeta Meta { get; init; } = new();

        /// <inheritdoc/>
        public override EiffelFlowContextDefinedLinks Links { get; init; } = new();

        /// <inheritdoc/>
        public override IEiffelEvent FromJson(string json)
        {
            return Deserialize<EiffelFlowContextDefinedEvent>(json);
        }
    }
}