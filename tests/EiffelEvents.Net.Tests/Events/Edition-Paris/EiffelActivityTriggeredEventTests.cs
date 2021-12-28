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
using EiffelEvents.Net.Events.Core;
using EiffelEvents.Net.Events.Edition_Paris;
using EiffelEvents.Net.Tests.TestData;
using EiffelEvents.Net.Tests.TestData.Edition_Paris;
using FluentAssertions;
using FluentResults;
using Xunit;

namespace EiffelEvents.Net.Tests.Events.Edition_Paris
{
    public class EiffelActivityTriggeredEventTests : IClassFixture<EiffelActivityTriggeredEventFixture>
    {
        private readonly EiffelActivityTriggeredEventFixture _eventFixture;

        public EiffelActivityTriggeredEventTests(EiffelActivityTriggeredEventFixture eventFixture)
        {
            _eventFixture = eventFixture;
        }

        [Fact]
        public void Validate_CompleteAttributes_Success()
        {
            //Arrange
            var activityTriggeredEvent = _eventFixture.GetValidCompleteEvent();

            //Act
            Result result = activityTriggeredEvent.Validate();

            //Assert
            result.IsSuccess.Should().BeTrue();
        }
        
        [Fact]
        public void Validate_NotValidGuid_Failed()
        {
            //Arrange
            var activityTriggeredEvent = _eventFixture.GetEventWithInvalidGuid();

            //Act
            Result result = activityTriggeredEvent.Validate();

            //Assert
            result.IsSuccess.Should().BeFalse();
        }
        
        [Fact]
        public void Validate_EmptyGuid_Failed()
        {
            //Arrange
            var activityTriggeredEvent = _eventFixture.GetEventWithEmptyGuid();

            //Act
            Result result = activityTriggeredEvent.Validate();

            //Assert
            result.IsSuccess.Should().BeFalse();
        }
        
        [Fact]
        public void Validate_NotValidGuidList_Failed()
        {
            //Arrange
            var activityTriggeredEvent = _eventFixture.GetEventWithInvalidGuidList();

            //Act
            Result result = activityTriggeredEvent.Validate();

            //Assert
            result.IsSuccess.Should().BeFalse();
        }

        [Fact]
        public void Validate_MissingRequired_Failed()
        {
            //Arrange
            var activityTriggeredEvent = new EiffelActivityTriggeredEvent();

            //Act
            var result = activityTriggeredEvent.Validate();

            //Assert
            result.IsSuccess.Should().BeFalse();
        }

        [Fact]
        public void VerifySignature_ValidSignature_Success()
        {
            //Arrange
            var activityTriggeredEvent = _eventFixture.GetValidCompleteEvent();

            //Act
            var activityTriggeredEventSigned = activityTriggeredEvent.Sign<EiffelActivityTriggeredEvent>();

            //Assert
            activityTriggeredEventSigned.VerifySignature().Should().BeTrue();
        }

        [Fact]
        public void VerifySignature_CorruptedObject_Failed()
        {
            //Arrange
            var activityTriggeredEvent = _eventFixture.GetValidCompleteEvent();

            //Act
            var activityTriggeredEventSigned = activityTriggeredEvent.Sign<EiffelActivityTriggeredEvent>();
            activityTriggeredEventSigned = activityTriggeredEventSigned with
            {
                Meta = activityTriggeredEventSigned.Meta with
                {
                    Id = Guid.NewGuid().ToString()
                }
            };

            //Assert
            activityTriggeredEventSigned.VerifySignature().Should().BeFalse();
        }

        [Fact]
        public void ToJson_Serialize_Completed_Event_Success()
        {
            //Arrange
            var activityTriggeredEvent = _eventFixture.GetValidCompleteEvent();
            var expected = _eventFixture.GetCompletedEventSerialized();

            //Act
            var actualSerializedEvent = activityTriggeredEvent.ToJson();

            //Assert
            actualSerializedEvent.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void FromJson_Deserialize_Completed_Event_Success()
        {
            //Arrange
            var json = _eventFixture.GetCompletedEventSerialized();
            var expected = _eventFixture.GetCompletedEventDeserialized();

            //Act
            IEiffelEvent activityTriggeredEvent = new EiffelActivityTriggeredEvent();
            var actualDeserializedEvent = (EiffelActivityTriggeredEvent)activityTriggeredEvent.FromJson(json);

            //Assert
            actualDeserializedEvent.Meta.Should().BeEquivalentTo(expected.Meta);
            actualDeserializedEvent.Data.Should().BeEquivalentTo(expected.Data);
            actualDeserializedEvent.Links.Should().BeEquivalentTo(expected.Links);
        }


        [Fact]
        public void ToJson_Serialize_Ignore_Null_Objects_Success()
        {
            //Arrange
            var activityTriggeredEvent = _eventFixture.GetEventWithNullProperties();
            var expected = _eventFixture.GetEventWithNullPropertiesSerialized();

            //Act
            var actualSerializedEvent = activityTriggeredEvent.ToJson();

            //Assert
            actualSerializedEvent.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void FromJson_Deserialize_Missed_Properties_with_Defaults_Success()
        {
            //Arrange
            var json = _eventFixture.GetEventWithNullPropertiesSerialized();
            var expected = _eventFixture.GetEventWithNullPropertiesDeserialized();

            //Act
            IEiffelEvent activityTriggeredEvent = new EiffelActivityTriggeredEvent();
            var actualDeserializedEvent = (EiffelActivityTriggeredEvent)activityTriggeredEvent.FromJson(json);

            //Assert
            actualDeserializedEvent.Meta.Should().BeEquivalentTo(expected.Meta);
            actualDeserializedEvent.Data.Should().BeEquivalentTo(expected.Data);
            actualDeserializedEvent.Links.Should().BeEquivalentTo(expected.Links);
        }

        [Fact]
        public void ToJson_Serialize_Ignore_Null_Collections_Success()
        {
            //Arrange
            var activityTriggeredEvent = _eventFixture.GetEventWithNullCollections();
            var expected = _eventFixture.GetEventWithNullCollectionsSerialized();

            //Act
            var actualSerializedEvent = activityTriggeredEvent.ToJson();

            //Assert
            actualSerializedEvent.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void FromJson_Deserialize_Missed_Collections_with_Empty_Success()
        {
            //Arrange
            var json = _eventFixture.GetEventWithNullCollectionsSerialized();
            var expected = _eventFixture.GetEventWithNullCollectionsDeserialized();

            //Act
            IEiffelEvent activityTriggeredEvent = new EiffelActivityTriggeredEvent();
            var actualDeserializedEvent = (EiffelActivityTriggeredEvent)activityTriggeredEvent.FromJson(json);

            //Assert
            actualDeserializedEvent.Meta.Should().BeEquivalentTo(expected.Meta);
            actualDeserializedEvent.Data.Should().BeEquivalentTo(expected.Data);
            actualDeserializedEvent.Links.Should().BeEquivalentTo(expected.Links);
        }

        [Fact]
        public void ToJson_Serialize_Ignore_Empty_Collections_Success()
        {
            //Arrange
            var activityTriggeredEvent = _eventFixture.GetEventWithEmptyCollections();
            var expected = _eventFixture.GetEventWithEmptyCollectionsSerialized();

            //Act
            var actualSerializedEvent = activityTriggeredEvent.ToJson();

            //Assert
            actualSerializedEvent.Should().BeEquivalentTo(expected);
        }
        
        [Fact]
        public void ToJson_Serialize_Empty_Links_Success()
        {
            //Arrange
            var activityTriggeredEvent = _eventFixture.GetEventWithEmptyLinks();
            var expected = _eventFixture.GetEventWithEmptyLinksSerialized();

            //Act
            var actualSerializedEvent = activityTriggeredEvent.ToJson();

            //Assert
            actualSerializedEvent.Should().BeEquivalentTo(expected);
        }
    }
}