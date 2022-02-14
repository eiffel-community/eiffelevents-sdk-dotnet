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

namespace EiffelEvents.Net.Events.Edition_Lyon.Shared.Data
{
    public record EiffelLiveLog : Edition_Paris.Shared.Data.EiffelLiveLog
    {
        /// <summary>
        /// The <a href="https://en.wikipedia.org/wiki/Media_type">media type</a> of the URI's payload.
        /// Can be used to differentiate between various representations of the same log, e.g. text/html for human consumption and text/plain or application/json for the machine-readable form.
        /// </summary>
        public string MediaType { get; init; }

        /// <summary>
        /// Arbitrary tags and keywords that describe this log.
        /// </summary>
        public List<string> Tags { get; init; }
    }
}