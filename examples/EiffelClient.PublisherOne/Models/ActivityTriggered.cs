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
using EiffelEvents.Net.Events.Edition_Lyon.Shared.Links;
using EiffelEvents.Net.Events.Edition_Paris.Shared.Enums;

namespace EiffelClient.PublisherOne.Models
{
    public class ActivityTriggered
    {
        public static EiffelActivityTriggeredEvent GetEvent()
        {
            return new EiffelActivityTriggeredEvent()
            {
                Data = new ()
                {
                    Name = "My activity",
                    Categories = new () { "category 1", "category 2" },
                    Triggers = new ()
                    {
                        new() { Type = EiffelDataTriggerType.SOURCE_CHANGE, Description = "Description" }
                    },
                    ExecutionType = EiffelDataExecutionType.AUTOMATED,
                    CustomData = new()
                    {
                        { "key1", "test" },
                        { "key2", new[] { 1, 2, 3 } }
                    }
                },
                Meta = new ()
                {
                    Id = Guid.NewGuid().ToString(),
                    Tags = new () { "activity_block" },
                    Security = new ()
                    {
                        AuthorIdentity = "Flower"
                    }
                },
                Links = new ()
                {
                    Cause = new ()
                    {
                        new()
                        {
                            Target = Guid.NewGuid().ToString(),
                            DomainId = "12345" 
                        },
                        new()
                        {
                            Target = Guid.NewGuid().ToString(),
                            DomainId = "987654" 
                        }
                    },
                    Context = new ()
                    {
                        Target = "82f11609-bd5b-4c82-a5f2-c2a9d982cdbd",
                        DomainId = "oiyturew"
                    },
                    FlowContext = new ()
                    {
                        new ()
                        {
                            Target = "cf056717-201b-43f6-9f2c-839b33b71baf"
                        },
                        new ()
                        {
                            Target = "82f11609-bd5b-4c82-a5f2-c2a9d982cdbd",
                            DomainId = "oiyturew"
                        }
                    }
                }
            };
        }
    }
}