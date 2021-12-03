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

using Eiffel.Net.Common;
using Eiffel.Net.Validation;

namespace Eiffel.Net.Events.Core.Data
{
    /// <summary>
    /// Represents abstract Eiffel data
    /// </summary>
    public abstract record EiffelData
    {
        /// <summary>
        /// Optional member of key-value pairs where value must be in serializable object.
        /// (for example: delegates are not serializable).
        /// <seealso cref="EiffelDictionary" />
        /// </summary>
        [ValidDictionary]
        public EiffelDictionary CustomData { get; init; }
    }
}
