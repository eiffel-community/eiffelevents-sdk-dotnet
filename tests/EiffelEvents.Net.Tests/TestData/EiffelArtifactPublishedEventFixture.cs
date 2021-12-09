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
using EiffelEvents.Net.Events.Edition_Paris;
using EiffelEvents.Net.Events.Edition_Paris.Shared.Enums;

namespace EiffelEvents.Net.Tests.TestData
{
    public class EiffelArtifactPublishedEventFixture
    {
        /// <summary>
        /// Get a complete valid instance of EiffelArtifactPublishedEvent.
        /// </summary>
        /// <returns></returns>
        public EiffelArtifactPublishedEvent GetValidCompleteEvent()
        {
            return new EiffelArtifactPublishedEvent
            {
                Data = new ()
                {
                    Locations = new ()
                    {
                        new ()
                        {
                            Name = "location-name",
                            Type = EiffelArtifactLocationType.NEXUS,
                            Uri = "sample.URI"
                        }
                    },
                    CustomData = new()
                    {
                        { "key1", "test" },
                        { "key2", new[] { 1, 2, 3 } }
                    }
                },

                Meta = new()
                {
                    Id = Guid.NewGuid().ToString(),
                    Tags = new () { "artifactPublished" },
                    Security = new ()
                    {
                        AuthorIdentity = "Flower"
                    }
                },
                Links = new ()
                {
                    Artifact = "cf056717-201b-43f6-9f2c-839b33b71baf"
                }
            };
        }
    }
}