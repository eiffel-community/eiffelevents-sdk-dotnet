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
using EiffelEvents.Net.Events.Core.Data;
using EiffelEvents.Net.Events.Edition_Paris.Shared.Data;
using EiffelEvents.Net.Validation;

namespace EiffelEvents.Net.Events.Edition_Paris
{
    public record EiffelActivityFinishedData : EiffelData
    {
        [NestedObject]
        [Required(AllowEmptyStrings = false)]
        public EiffelOutcome Outcome { get; init; }

        [NestedList]
        public List<EiffelPersistentLog> PersistentLogs { get; init; }
    }
}