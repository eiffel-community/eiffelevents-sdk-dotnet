﻿//    Copyright (c) 2021 ICT Cube, doWhile, and Eiffel Community collaborators.
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
using Eiffel.Net.Clients;
using Eiffel.Net.Events.Edition_Paris;
using Eiffel.Net.Events.Edition_Paris.Shared.Enums;
using Eiffel.RabbitMq.Client;

namespace EiffelClient.BasicPublisher
{
    class Program
    {
        // Init client (globally)
        private static readonly IEiffelClient _eiffelClient = new RabbitMqEiffelClient(new RabbitMqConfig
        {
            HostName = "localhost",
            UserName = "admin",
            Password = "admin",
            Port = 5672
        }, 1);

        public static void Main(string[] args)
        {
            // 1. Declare event object
            var activityTriggeredEvent = new EiffelActivityTriggeredEvent
            {
                Data = new()
                {
                    Name = "My activity",
                    Categories = new() { "category 1", "category 2" },
                    Triggers = new()
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
                Meta = new()
                {
                    Id = Guid.NewGuid().ToString(),
                    Tags = new() { "activity_block" },
                    Security = new()
                    {
                        AuthorIdentity = "Flower"
                    }
                },
                Links = new()
                {
                    Context = "82f11609-bd5b-4c82-a5f2-c2a9d982cdbd",
                    FlowContext = new List<string> { "cf056717-201b-43f6-9f2c-839b33b71baf" }
                }
            };

            // 2. Sign event Object
            var signedEvent = activityTriggeredEvent.Sign<EiffelActivityTriggeredEvent>();

            // 3.Publish event to RabbitMQ
            var result = _eiffelClient.Publish(signedEvent);
            if (!result.IsFailed) Console.WriteLine(signedEvent.ToJson());

            // 4.Print results
            Console.WriteLine(
                result.IsFailed
                    ? $"Failed to publish!! - errors: {string.Join(", ", result.Errors)}"
                    : $"Event {signedEvent.Meta.Type} published to RabbitMQ  !!");
        }
    }
}