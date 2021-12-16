using System;
using EiffelEvents.Net.Events.Core;
using EiffelEvents.Net.Events.Edition_Lyon;
using EiffelEvents.Net.Tests.TestData.Edition_Lyon;
using FluentAssertions;
using FluentResults;
using Xunit;

namespace EiffelEvents.Net.Tests.Events.Edition_Lyon;

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
}