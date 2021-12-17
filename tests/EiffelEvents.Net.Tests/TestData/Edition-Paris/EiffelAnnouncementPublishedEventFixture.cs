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

using System;
using System.Collections.Generic;
using EiffelEvents.Net.Events.Edition_Paris;
using EiffelEvents.Net.Events.Edition_Paris.Shared.Enums;
using EiffelEvents.Net.Events.Edition_Paris.Shared.Security;

namespace EiffelEvents.Net.Tests.TestData.Edition_Paris
{
    public class EiffelAnnouncementPublishedEventFixture
    {
        /// <summary>
        /// Get a complete valid instance of EiffelAnnouncementPublishedEvent.
        /// </summary>
        /// <returns></returns>
        public EiffelAnnouncementPublishedEvent GetValidCompleteEvent()
        {
            return new EiffelAnnouncementPublishedEvent
            {
                Data = new()
                {
                    Heading = "heading-1",
                    Body = "body -1 ",
                    Severity = EiffelAnnouncementSeverity.MAJOR,
                    Uri = "uri.xyz",
                    CustomData = new()
                    {
                        { "key1", "test" },
                        { "key2", new[] { 1, 2, 3 } }
                    }
                },
                Meta = new()
                {
                    Id = Guid.NewGuid().ToString(),
                    Tags = new List<string> { "docker env" },
                    Security = new EiffelSecurity()
                    {
                        AuthorIdentity = "Flower"
                    }
                },
                Links = new()
                {
                    ModifiedAnnouncement = Guid.NewGuid().ToString(),
                    Context = Guid.NewGuid().ToString(),
                    Cause = new()
                    {
                        Guid.NewGuid().ToString(),
                        Guid.NewGuid().ToString()
                    },
                    FlowContext = new()
                    {
                        Guid.NewGuid().ToString(),
                        Guid.NewGuid().ToString()
                    }
                }
            };
        }
    }
}