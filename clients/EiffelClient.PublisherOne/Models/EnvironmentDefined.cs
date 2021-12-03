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

namespace EiffelClient.PublisherOne.Models
{
    public class EnvironmentDefined
    {
        public static EiffelEnvironmentDefinedEvent GetEvent()
        {
            return new EiffelEnvironmentDefinedEvent
            {
                Data = new()
                {
                    Name = "env name",
                    Image = "docker/image",
                    Version = "2",
                    Host = new()
                    {
                        Name = "name-1",
                        User = "user-1"
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
                    Tags = new() { "docker env" },
                    Security = new()
                    {
                        AuthorIdentity = "Flower"
                    }
                },
                Links = new()
                {
                    PreviousVersion = new() { "cf056717-201b-43f6-9f2c-839b33b71baf" }
                }
            };
        }
    }
}