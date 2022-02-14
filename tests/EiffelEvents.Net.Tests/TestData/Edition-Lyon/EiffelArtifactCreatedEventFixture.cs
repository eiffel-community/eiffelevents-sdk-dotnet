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

namespace EiffelEvents.Net.Tests.TestData.Edition_Lyon
{
    public class EiffelArtifactCreatedEventFixture
    {
        /// <summary>
        /// Get a complete valid instance of EiffelArtifactCreatedEvent.
        /// </summary>
        /// <returns></returns>
        public EiffelArtifactCreatedEvent GetValidCompleteEvent()
        {
            return new EiffelArtifactCreatedEvent()
            {
                Data = new ()
                {
                    Name = "My Artifact",
                    Identity = "Test 1",
                    CustomData = new()
                    {
                        { "key1", "test" },
                        { "key2", new[] { 1, 2, 3 } }
                    }
                },
                Meta = new()
                {
                    Id = Guid.NewGuid().ToString(),
                    Time = 1637001247776,
                    Tags = new() { "package" },
                    Security = new()
                    {
                        AuthorIdentity = "Flower"
                    }
                },
                Links = new()
                {
                    Cause = new()
                    {
                        new()
                        {
                            Target = Guid.NewGuid().ToString(),
                            DomainId = "test-domain-id"
                        },
                        new()
                        {
                            Target = Guid.NewGuid().ToString()
                        }
                    },
                    Context = new()
                    {
                        Target = Guid.NewGuid().ToString(),
                        DomainId = "test-domain-id"
                    },
                    FlowContext = new()
                    {
                        new()
                        {
                            Target = Guid.NewGuid().ToString(),
                            DomainId = "test-domain-id"
                        }
                    },
                    Composition = new(Guid.NewGuid().ToString(), "test-domain-id"),
                    PreviousVersion = new()
                    {
                        new(Guid.NewGuid().ToString(), "test-domain-id"),
                        new(Guid.NewGuid().ToString(), "test-domain-id")
                    },
                    Environment = new()
                    {
                        Target = Guid.NewGuid().ToString(),
                        DomainId = "test-domain-id"
                    }
                }
            };
        }
    }
}