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
using EiffelEvents.Net.Events.Core;
using EiffelEvents.Net.Events.Edition_Paris.Shared.Security;
using EiffelEvents.Net.Validation;


namespace EiffelEvents.Net.Events.Edition_Paris.Shared
{
    /// <summary>
    /// Represents Eiffel meta
    /// </summary>
    public abstract record EiffelSharedMeta : EiffelMeta
    {
        /// <summary>
        /// Tags connected to this event.
        /// </summary>
        public List<string> Tags { get; init; }

        /// <summary>
        /// Event source/sender information
        /// </summary>
        [NestedObject]
        public EiffelMetaSource Source { get; init; } = new();

        /// <summary>
        /// Eiffel event security information
        /// </summary>
        [NestedObject]
        public EiffelSecurity Security { get; init; }
    }
}