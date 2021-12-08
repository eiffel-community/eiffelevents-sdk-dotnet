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
using Eiffel.Net.Events.Edition_Paris;
using Eiffel.Net.Events.Edition_Paris.Shared.Data;
using Eiffel.Net.Events.Edition_Paris.Shared.Enums;
using Eiffel.Net.Events.Edition_Paris.Shared.Security;

namespace EiffelEvents.Net.Tests.TestData
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
                    TestCaseExecution = Guid.NewGuid().ToString()
                }
            };
        }
    }
}