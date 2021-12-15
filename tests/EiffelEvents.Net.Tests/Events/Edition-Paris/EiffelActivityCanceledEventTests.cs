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
using EiffelEvents.Net.Tests.TestData;
using EiffelEvents.Net.Tests.TestData.Edition_Paris;
using FluentAssertions;
using FluentResults;
using Xunit;

namespace EiffelEvents.Net.Tests.Events.Edition_Paris
{
    public class EiffelActivityCanceledEventTests:IClassFixture<EiffelActivityCanceledEventFixture>
    {
        private readonly EiffelActivityCanceledEventFixture _eventFixture;
        public EiffelActivityCanceledEventTests(EiffelActivityCanceledEventFixture fixture)
        {
            _eventFixture = fixture;
        }
        
        [Fact]
        public void Validate_CompleteAttributes_Success()
        {
            //Arrange
            var activityCanceledEvent = _eventFixture.GetValidCompleteEvent();

            //Act
            Result result = activityCanceledEvent.Validate();

            //Assert
            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void Validate_MissingRequired_Failed()
        {
            //Arrange
            var activityCanceledEvent = new EiffelActivityCanceledEvent();

            //Act
            var result = activityCanceledEvent.Validate();

            //Assert
            result.IsSuccess.Should().BeFalse();
        }

        [Fact]
        public void VerifySignature_ValidSignature_Success()
        {
            //Arrange
            var activityCanceledEvent = _eventFixture.GetValidCompleteEvent();

            //Act
            var activityCanceledEventSigned = activityCanceledEvent.Sign<EiffelActivityCanceledEvent>();

            //Assert
            activityCanceledEventSigned.VerifySignature().Should().BeTrue();
        }

        [Fact]
        public void VerifySignature_CorruptedObject_Failed()
        {
            //Arrange
            var activityCanceledEvent = _eventFixture.GetValidCompleteEvent();

            //Act
            var activityCanceledEventSigned = activityCanceledEvent.Sign<EiffelActivityCanceledEvent>();
            activityCanceledEventSigned = activityCanceledEventSigned with
            {
                Meta = activityCanceledEventSigned.Meta with
                {
                    Id = Guid.NewGuid().ToString()
                }
            };
            
            //Assert
            activityCanceledEventSigned.VerifySignature().Should().BeFalse();
        }
    }
}