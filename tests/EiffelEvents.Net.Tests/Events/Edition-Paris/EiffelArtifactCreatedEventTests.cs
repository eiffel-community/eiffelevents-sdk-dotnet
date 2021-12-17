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
using EiffelEvents.Net.Events.Edition_Paris;
using EiffelEvents.Net.Tests.TestData;
using EiffelEvents.Net.Tests.TestData.Edition_Paris;
using FluentAssertions;
using FluentResults;
using Xunit;

namespace EiffelEvents.Net.Tests.Events.Edition_Paris
{
    public class EiffelArtifactCreatedEventTests : IClassFixture<EiffelArtifactCreatedEventFixture>
    {
        private readonly EiffelArtifactCreatedEventFixture _eventFixture;
        public EiffelArtifactCreatedEventTests(EiffelArtifactCreatedEventFixture fixture)
        {
            _eventFixture = fixture;
        }
        
        [Fact]
        public void Validate_CompleteAttributes_Success()
        {
            //Arrange
            var artifactCreatedEvent = _eventFixture.GetValidCompleteEvent();
            
            //Act
            Result result = artifactCreatedEvent.Validate();

            //Assert
            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void Validate_MissingRequired_Failed()
        {
            //Arrange
            var artifactCreatedEvent = new EiffelArtifactCreatedEvent();

            //Act
            var result = artifactCreatedEvent.Validate();

            //Assert
            result.IsSuccess.Should().BeFalse();
        }
        
        [Fact]
        public void VerifySignature_ValidSignature_Success()
        {
            //Arrange
            var artifactCreatedEvent = _eventFixture.GetValidCompleteEvent();

            //Act
            var artifactCreatedEventSigned = artifactCreatedEvent.Sign<EiffelArtifactCreatedEvent>();

            //Assert
            artifactCreatedEventSigned.VerifySignature().Should().BeTrue();
        }

        [Fact]
        public void VerifySignature_CorruptedObject_Failed()
        {
            //Arrange
            var artifactCreatedEvent = _eventFixture.GetValidCompleteEvent();

            //Act
            var artifactCreatedEventSigned = artifactCreatedEvent.Sign<EiffelArtifactCreatedEvent>();
            artifactCreatedEventSigned = artifactCreatedEventSigned with
            {
                Meta = artifactCreatedEventSigned.Meta with
                {
                    Id = Guid.NewGuid().ToString()
                }
            };
            
            //Assert
            artifactCreatedEventSigned.VerifySignature().Should().BeFalse();
        }
    }
}