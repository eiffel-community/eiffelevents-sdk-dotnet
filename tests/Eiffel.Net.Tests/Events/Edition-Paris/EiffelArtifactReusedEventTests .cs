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
using Eiffel.Net.Events.Edition_Paris;
using Eiffel.Net.Tests.TestData;
using FluentAssertions;
using FluentResults;
using Xunit;

namespace Eiffel.Net.Tests.Events.Edition_Paris
{
    public class EiffelArtifactReusedEventTests : IClassFixture<EiffelArtifactReusedEventFixture>
    {
        private readonly EiffelArtifactReusedEventFixture _eventFixture;
        public EiffelArtifactReusedEventTests(EiffelArtifactReusedEventFixture fixture)
        {
            _eventFixture = fixture;
        }
        
        [Fact]
        public void Validate_CompleteAttributes_Success()
        {
            //Arrange
            var artifactReusedEvent = _eventFixture.GetValidCompleteEvent();
            
            //Act
            Result result = artifactReusedEvent.Validate();

            //Assert
            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void Validate_MissingRequired_Failed()
        {
            //Arrange
            var artifactReusedEvent = new EiffelArtifactReusedEvent();

            //Act
            var result = artifactReusedEvent.Validate();

            //Assert
            result.IsSuccess.Should().BeFalse();
        }
        
        [Fact]
        public void VerifySignature_ValidSignature_Success()
        {
            //Arrange
            var artifactReusedEvent = _eventFixture.GetValidCompleteEvent();

            //Act
            var artifactReusedEventSigned = artifactReusedEvent.Sign<EiffelArtifactReusedEvent>();

            //Assert
            artifactReusedEventSigned.VerifySignature().Should().BeTrue();
        }

        [Fact]
        public void VerifySignature_CorruptedObject_Failed()
        {
            //Arrange
            var artifactReusedEvent = _eventFixture.GetValidCompleteEvent();

            //Act
            var artifactReusedEventSigned = artifactReusedEvent.Sign<EiffelArtifactReusedEvent>();
            artifactReusedEventSigned = artifactReusedEventSigned with
            {
                Meta = artifactReusedEventSigned.Meta with
                {
                    Id = Guid.NewGuid().ToString()
                }
            };
            
            //Assert
            artifactReusedEventSigned.VerifySignature().Should().BeFalse();
        }
    }
}