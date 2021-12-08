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

using EiffelEvents.Net.Events.Edition_Paris.Shared;
using EiffelEvents.Net.Validation;

namespace EiffelEvents.Net.Events.Edition_Paris
{
    public record EiffelAnnouncementPublishedLinks : EiffelSharedLinks
    {
        /// <summary>
        /// Identifies an announcement of which this event represents an update or modification, if any.
        /// Example usage is to declare the end to a previously announced situation.
        /// Legal target: EiffelAnnouncementPublishedEvent
        /// </summary>
        [ValidGuid]
        public string ModifiedAnnouncement { get; init; }
    }
}