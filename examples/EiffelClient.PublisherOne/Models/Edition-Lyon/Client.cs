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

using EiffelEvents.Net.Clients;
using EiffelEvents.Net.Clients.Validation;
using EiffelEvents.Net.Events.Edition_Lyon;
using EiffelEvents.RabbitMq.Client;

namespace EiffelClient.PublisherOne.Models.Edition_Lyon
{
    public class TryClient
    {
        // Create a client
        public static IEiffelClient Eiffelclient = new RabbitMqEiffelClient(new ()
        {
            RabbitMqConfig = new()
            {
                HostName = "localhost",
                UserName = "admin",
                Password = "admin",
                Port = 5672
            },
            ValidationConfig = new ()
            {
                SchemaValidationOnPublish = SchemaValidationOnPublish.ON,
                SchemaValidationOnSubscribe = SchemaValidationOnSubscribe.ALWAYS
            }
        }, 1);

        public static T? GetEvent<T>() where T : class
        {
            return typeof(T).Name switch
            {
                nameof(EiffelActivityTriggeredEvent) => ActivityTriggered.GetEvent() as T,

                nameof(EiffelActivityStartedEvent) => ActivityStarted.GetEvent() as T,
                nameof(EiffelActivityCanceledEvent) => ActivityCanceled.GetEvent() as T,
                nameof(EiffelActivityFinishedEvent) => ActivityFinished.GetEvent() as T,
                nameof(EiffelArtifactCreatedEvent) => ArtifactCreated.GetEvent() as T,
                nameof(EiffelArtifactReusedEvent) => ArtifactReused.GetEvent() as T,
                nameof(EiffelArtifactPublishedEvent) => ArtifactPublished.GetEvent() as T,
                nameof(EiffelConfidenceLevelModifiedEvent) => ConfidenceLevelModified.GetEvent() as T,
                nameof(EiffelEnvironmentDefinedEvent) => EnvironmentDefined.GetEvent() as T,
                nameof(EiffelSourceChangeCreatedEvent) => SourceChangeCreated.GetEvent() as T,
                nameof(EiffelCompositionDefinedEvent) => CompositionDefined.GetEvent() as T,
                // nameof(EiffelSourceChangeSubmittedEvent) => SourceChangeSubmitted.GetEvent() as T,
                // nameof(EiffelFlowContextDefinedEvent) => FlowContextDefined.GetEvent() as T,
                // nameof(EiffelTestCaseTriggeredEvent) => TestCaseTriggered.GetEvent() as T,
                // nameof(EiffelTestSuiteStartedEvent) => TestSuiteStarted.GetEvent() as T,
                // nameof(EiffelTestSuiteFinishedEvent) => TestSuiteFinished.GetEvent() as T,
                // nameof(EiffelTestCaseCanceledEvent) => TestCaseCanceled.GetEvent() as T,
                // nameof(EiffelTestCaseFinishedEvent) => TestCaseFinished.GetEvent() as T,
                // nameof(EiffelIssueVerifiedEvent) => IssueVerified.GetEvent() as T,
                // nameof(EiffelTestCaseStartedEvent) => TestCaseStarted.GetEvent() as T,
                // nameof(EiffelIssueDefinedEvent) => IssueDefined.GetEvent() as T,
                // nameof(EiffelAnnouncementPublishedEvent) => AnnouncementPublished.GetEvent() as T,
                // nameof(EiffelTestExecutionRecipeCollectionCreatedEvent) =>
                //     TestExecutionRecipeCollectionCreated.GetEvent() as T,
                _ => null
            };
        }
    }
}