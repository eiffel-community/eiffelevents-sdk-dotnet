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
using System.Linq;
using EiffelClient.PublisherOne.Models;
using  EiffelEvents.Net.Events.Edition_Lyon;

namespace EiffelClient.PublisherOne
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Started !!");

            // Create a raw event
            var eiffelEvent = TryClient.GetEvent<EiffelActivityTriggeredEvent>();
            var signedEvent = eiffelEvent?.Sign<EiffelActivityTriggeredEvent>();
            /*for (int i = 0; i < 10000; i++)
           {*/
            var result = TryClient.Eiffelclient.Publish(signedEvent);
            Console.WriteLine(
                result.IsFailed
                    ? $"Failed to publish!! - errors: {string.Join(", ", result.Errors.Select(x => x.Message))}"
                    : $"Event {signedEvent?.Meta.Type} published to RabbitMQ  !!");

            if (!result.IsFailed) 
                Console.WriteLine(signedEvent?.ToJson());
            //}
        }
    }
}