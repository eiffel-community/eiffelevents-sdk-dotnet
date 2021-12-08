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
using Eiffel.Net.Events.Edition_Paris;
using Eiffel.Net.Events.Edition_Paris.Shared.Enums;

namespace EiffelEvents.Net.Tests.TestData
{
    public class EiffelActivityFinishedEventFixture
    {
        public EiffelActivityFinishedEvent GetValidCompleteEvent()
        {
            return new EiffelActivityFinishedEvent
            {
                Data = new ()
                {
                    Outcome = new ()
                    {
                        Conclusion = EiffelDataOutcomeConclusion.FAILED,
                        Description = "bla bla bla"
                    }
                },
                Meta = new ()
                {
                    Id = Guid.NewGuid().ToString(),
                    Security = new ()
                    {
                        AuthorIdentity = "Flower"
                    }
                },
                Links = new ()
                {
                    ActivityExecution = "aaaaaaaa-bbbb-5ccc-8ddd-eeeeeeeeeee1",
                    Cause = new () { "aaaaaaaa-bbbb-5ccc-8ddd-eeeeeeeeeee2" }
                }
            };
        }
    }
}