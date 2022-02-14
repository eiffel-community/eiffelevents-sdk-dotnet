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

namespace EiffelEvents.Net.Clients.Validation
{
    /// <summary>
    /// Set whether to validate against JSON schema while subscribing to an event
    /// </summary>
    public enum SchemaValidationOnSubscribe
    {
        /// <summary>
        /// Never validate upcoming event against JSON schema
        /// </summary>
        NONE = 0,
        /// <summary>
        /// Validate upcoming event against JSON schema only if deserialization failed
        /// </summary>
        ON_DESERIALIZATION_FAIL = 1,
        /// <summary>
        /// Always validate upcoming event against JSON schema
        /// </summary>
        ALWAYS = 2
    }
}