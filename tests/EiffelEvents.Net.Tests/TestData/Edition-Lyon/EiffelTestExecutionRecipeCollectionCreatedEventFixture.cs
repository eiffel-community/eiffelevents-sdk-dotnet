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
using EiffelEvents.Net.Events.Edition_Lyon;
using EiffelEvents.Net.Events.Edition_Paris.Shared.Security;

namespace EiffelEvents.Net.Tests.TestData.Edition_Lyon
{
    public class EiffelTestExecutionRecipeCollectionCreatedEventFixture
    {
        /// <summary>
        /// Get a complete valid instance of EiffelTestExecutionRecipeCollectionCreatedEvent.
        /// </summary>
        /// <returns></returns>
        public EiffelTestExecutionRecipeCollectionCreatedEvent GetValidCompleteEvent()
        {
               return new EiffelTestExecutionRecipeCollectionCreatedEvent
            {
                Data = new()
                {
                    SelectionStrategy = new()
                    {
                        Tracker = "My Test Selector",
                        Id = "TCSS-1234/5",
                        Uri = "https://tm.company.com/browse/TCSS-1234?version=5"
                    },
                    Batches = new()
                    {
                        new()
                        {
                            Name = "First batch",
                            Priority = 1,
                            Recipes = new()
                            {
                                new()
                                {
                                    Id = "aaaaaaaa-bbbb-5ccc-addd-eeeeeeeeeee0",
                                    TestCase = new()
                                    {
                                        Tracker = "My Test Management System",
                                        Id = "TC-1234",
                                        Uri = "https://tm.company.com/browse/TC-1234"
                                    },
                                    Constraints = new()
                                    {
                                        { "load", 10000 },
                                        {
                                            "environment",
                                            new { Os = "ubuntu-15.04", MyPath = "/home/lt-work" }
                                        }
                                    }
                                },
                                new()
                                {
                                    Id = "aaaaaaaa-bbbb-5ccc-addd-eeeeeeeeeee1",
                                    TestCase = new()
                                    {
                                        Tracker = "My Test Management System",
                                        Id = "TC-1234",
                                        Uri = "https://tm.company.com/browse/TC-1234"
                                    },
                                    Constraints = new()
                                    {
                                        { "load", 500 },
                                        {
                                            "environment",
                                            new { Os = "ubuntu-16.04.1", MyPath = "/home/cpt-picard" }
                                        }
                                    }
                                }
                            },
                            Dependencies = new()
                            {
                                new()
                                {
                                    Dependency = "aaaaaaaa-bbbb-5ccc-addd-eeeeeeeeeee1",
                                    Dependent = "aaaaaaaa-bbbb-5ccc-addd-eeeeeeeeeee0"
                                }
                            }
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
                    Tags = new List<string> { "docker env" },
                    Security = new EiffelSecurity()
                    {
                        AuthorIdentity = "Flower"
                    }
                },
                Links = new()
                {
                    Context = new(Guid.NewGuid().ToString(),"test-domain-id")
                }
            };
        }
    }
}