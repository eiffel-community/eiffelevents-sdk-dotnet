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
using EiffelEvents.Net.Events.Edition_Paris.Shared.Enums;

namespace EiffelEvents.Net.Tests.TestData.Edition_Lyon
{
    public class EiffelActivityFinishedEventFixture
    {
        /// <summary>
        /// Get a complete valid instance of EiffelActivityFinishedEvent.
        /// </summary>
        /// <returns></returns>
        public EiffelActivityFinishedEvent GetValidCompleteEvent()
        {
             return new EiffelActivityFinishedEvent()
            {
                Data = new()
                {
                    Outcome = new()
                    {
                        Conclusion = EiffelDataOutcomeConclusion.SUCCESSFUL,
                        Description = "blah blah blah"
                    },
                    PersistentLogs = new()
                    {
                        new()
                        {
                            Name = "test",
                            Uri = "test-uri",
                            MediaType = "type 1"
                        },
                        new()
                        {
                            Name = "test2",
                            Uri = "test2-uri",
                            Tags = new(){"error log"}
                        }
                    },

                    CustomData = new()
                    {
                        { "key1", "test" },
                        { "key2", 1 }
                    }
                },
                Meta = new()
                {
                    Id = Guid.NewGuid().ToString(),
                    Time = 1637001247776,
                    Tags = new() { "activity_block" },
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
                    ActivityExecution = new(Guid.NewGuid().ToString(), "test-domain-id")
                }
            };
        }
    }
}