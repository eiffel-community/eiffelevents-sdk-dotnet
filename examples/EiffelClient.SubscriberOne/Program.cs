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
using System.Threading;
using EiffelEvents.Net.Clients;
using EiffelEvents.Net.Events.Core;
using EiffelEvents.Net.Events.Edition_Lyon;
using EiffelEvents.RabbitMq.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;


namespace EiffelClient.SubscriberOne
{
    class Program
    {
        // Create a client
        private static IEiffelClient _client;
        private static RabbitMqConfig _rabbitMqConfig;
        private static string _subscriptionId = string.Empty;
        private static string _queueIdentifier = "autor";

        public static void Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();
            _client = new RabbitMqEiffelClient(_rabbitMqConfig);


            Console.WriteLine("Started ....");

            // Subscribe to events
            _subscriptionId = _client.Subscribe<EiffelTestCaseFinishedEvent>(_queueIdentifier, GeneralHandleEvent);
            Console.WriteLine($"Subscription done to event {nameof(EiffelTestCaseFinishedEvent)} !");

            while (true)
            {
                Console.WriteLine($"{nameof(SubscriberOne)} Waiting ....");
                Thread.Sleep(3000);
            }
        }

        #region Event Handlers

        static void GeneralHandleEvent<T>(T eiffelEvent, ulong deliveryTag) where T : IEiffelEvent
        {
            Console.WriteLine("========= Callback called ========= ");

            Console.WriteLine($"Event Received {typeof(T).Name} \nDelivery Tag : {deliveryTag} \n========");
            var verified = eiffelEvent.VerifySignature();
            Console.WriteLine($" ======== Event signature verified: {verified} ==============");
            Console.WriteLine(eiffelEvent.ToJson());

            Console.WriteLine("========= Processing Done ===========");

            _client.Ack(deliveryTag);
            Console.WriteLine($"========= Ack Done for Delivery Tag : {deliveryTag} ===========");
        }

        #endregion

        #region Configuration

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((_, configuration) =>
                {
                    configuration.Sources.Clear();
                    configuration
                        .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true)
                        .AddEnvironmentVariables();

                    var configurationRoot = configuration.Build();

                    _rabbitMqConfig = configurationRoot.GetSection(nameof(RabbitMqConfig)).Get<RabbitMqConfig>();
                });

        #endregion
    }
}