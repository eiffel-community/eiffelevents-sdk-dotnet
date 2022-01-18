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
using EiffelEvents.Net.Events.Edition_Paris.Shared.Data;
using EiffelEvents.Net.Events.Edition_Paris.Shared.Enums;

namespace EiffelEvents.Net.Tests.TestData.Edition_Lyon
{
    public class EiffelTestCaseFinishedEventFixture
    {
        /// <summary>
        /// Get a complete valid instance of EiffelTestCaseFinishedEvent.
        /// </summary>
        /// <returns></returns>
        public EiffelTestCaseFinishedEvent GetValidCompleteEvent()
        {
            return new EiffelTestCaseFinishedEvent
            {
                Data = new()
                {
                    Outcome = new()
                    {
                        Conclusion = EiffelTestCaseOutcomeConclusion.SUCCESSFUL,
                        Verdict = EiffelTestVerdict.PASSED,
                        Description = "blah blah blah",
                        Metrics = new()
                        {
                            new()
                            {
                                Name = "Metric 1",
                                Value = 95.5
                            }
                        }
                    },
                    PersistentLogs = new()
                    {
                        new()
                        {
                            Name = "Log", 
                            MediaType = "Type 1",
                            Uri = "https://test-uri"
                        }
                    },
                    CustomData = new()
                    {
                        {
                            "key1", "test"
                        },
                        { "key2", new[] { 1, 2, 3 } }
                    }
                },
                Meta = new()
                {
                    Id = Guid.NewGuid().ToString(),
                    Tags = new List<string> { "docker env" },
                    Security = new()
                    {
                        AuthorIdentity = "Flower"
                    }
                },
                Links = new()
                {
                    TestCaseExecution = new(Guid.NewGuid().ToString())
                }
            };
        }
    }
}