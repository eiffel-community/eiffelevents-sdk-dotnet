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
    /// <summary>
    /// Data for an activity triggered event
    /// </summary>
    public record EiffelActivityTriggeredData : EiffelData
    {
        /// <summary>
        /// Name of activity.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string Name { get; init; }

        /// <summary>
        /// Categories applicable to the activity.
        /// </summary>
        public List<string> Categories { get; init; }

        /// <summary>
        /// Information on what triggered the activity.
        /// </summary>
        [NestedList]
        public List<EiffelDataTrigger> Triggers { get; init; }

        /// <summary>
        /// How this activity will be executed.
        /// </summary>
        public EiffelDataExecutionType? ExecutionType { get; init; }
    }
}