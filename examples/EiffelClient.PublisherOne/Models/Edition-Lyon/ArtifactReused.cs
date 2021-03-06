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
using EiffelEvents.Net.Events.Edition_Lyon;

namespace EiffelClient.PublisherOne.Models.Edition_Lyon
{
    public class ArtifactReused
    {
        public static EiffelArtifactReusedEvent GetEvent()
        {
            return new EiffelArtifactReusedEvent
            {
                Data = new()
                {
                    CustomData = new()
                    {
                        { "key1", "test" },
                        { "key2", new[] { 1, 2, 3 } }
                    }
                },
                Meta = new()
                {
                    Id = Guid.NewGuid().ToString(),
                    Tags = new() { "artifact reused" },
                    Security = new()
                    {
                        AuthorIdentity = "Flower"
                    }
                },
                Links = new EiffelArtifactReusedLinks
                {
                    Composition = new("82f11609-bd5b-4c82-a5f2-c2a9d982cdbd"),
                    ReusedArtifact = new("cf056717-201b-43f6-9f2c-839b33b71baf"),
                    Cause = new()
                    {
                        new(Guid.NewGuid().ToString()),
                        new(Guid.NewGuid().ToString()),
                        new(Guid.NewGuid().ToString())
                    }
                }
            };
        }
    }
}