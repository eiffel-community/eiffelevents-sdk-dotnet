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

namespace EiffelClient.PublisherOne.Models.Edition_Paris
{
    public class CompositionDefined
    {
        public static EiffelCompositionDefinedEvent GetEvent()
        {
            return new EiffelCompositionDefinedEvent
            {
                Data = new()
                {
                    Name = "Test",
                    CustomData = new()
                    {
                        { "key1", "test" },
                        { "key2", new[] { 1, 2, 3 } }
                    }
                },
                Meta = new()
                {
                    Id = Guid.NewGuid().ToString(),
                    Tags = new() { "Confidence Level Modified" },
                    Security = new()
                    {
                        AuthorIdentity = "Flower"
                    }
                },
                Links = new()
                {
                    Element = new() { "82f11609-bd5b-4c82-a5f2-c2a9d982cdbd" },
                    PreviousVersion = new() { "82f11609-bd5b-4c82-a5f2-c2a9d982cdbd" }
                }
            };
        }
    }
}