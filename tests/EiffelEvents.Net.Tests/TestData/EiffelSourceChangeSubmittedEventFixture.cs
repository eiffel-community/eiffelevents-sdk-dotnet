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
using Eiffel.Net.Events.Edition_Paris.Shared.Security;

namespace EiffelEvents.Net.Tests.TestData
{
    public class EiffelSourceChangeSubmittedEventFixture
    {
        /// <summary>
        /// Get a complete valid instance of EiffelSourceChangeSubmittedEvent.
        /// </summary>
        /// <returns></returns>
        public EiffelSourceChangeSubmittedEvent GetValidCompleteEvent()
        {
            return new EiffelSourceChangeSubmittedEvent
            {
                Data = new()
                {
                    Submitter = new()
                    {
                        Email = "test@example.com"
                    },
                    GitIdentifier = new()
                    {
                        Branch = "test",
                        CommitId = "test",
                        RepoUri = "https://test.com/"
                    },
                    HgIdentifier = new()
                    {
                        Branch = "test",
                        CommitId = "test",
                        RepoUri = "https://test.com/"
                    },
                    SvnIdentifier = new()
                    {
                        Directory = "test",
                        RepoUri = "https://test.com/"
                    },
                    CcCompositeIdentifier = new()
                    {
                        Branch = "test",
                        Vobs = new List<string> { "test" },
                        ConfigSpec = "test"
                    }
                },
                Links = new()
                {
                    Change = Guid.NewGuid().ToString()
                },
                Meta = new()
                {
                    Id = Guid.NewGuid().ToString(),
                    Tags = new List<string> { "docker env" },
                    Security = new EiffelSecurity()
                    {
                        AuthorIdentity = "Flower"
                    }
                }
            };
        }
    }
}