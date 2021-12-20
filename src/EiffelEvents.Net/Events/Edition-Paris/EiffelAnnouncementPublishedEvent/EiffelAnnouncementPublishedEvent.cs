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

using System.ComponentModel.DataAnnotations;
using EiffelEvents.Net.Events.Core;
using EiffelEvents.Net.Events.Edition_Paris.Shared;

namespace EiffelEvents.Net.Events.Edition_Paris
{
    /// <summary>
    /// The <a href="https://github.com/eiffel-community/eiffel/blob/edition-paris/eiffel-vocabulary/EiffelAnnouncementPublishedEvent.md">
    /// EiffelAnnouncementPublishedEvent
    /// </a> represents an announcement, technically regarding any topic but typically used to communicate
    /// any incidents or status updates regarding the continuous integration and delivery pipeline.
    /// This information can then be favorably displayed in visualization and dash-boarding applications.
    /// </summary>
    public record EiffelAnnouncementPublishedEvent :
        EiffelEvent<EiffelAnnouncementPublishedData, EiffelAnnouncementPublishedMeta, EiffelAnnouncementPublishedLinks>
    {
        /// <inheritdoc/>
        public override EiffelAnnouncementPublishedData Data { get; init; }

        /// <inheritdoc/>
        public override EiffelAnnouncementPublishedMeta Meta { get; init; }

        /// <inheritdoc/>
        public override EiffelAnnouncementPublishedLinks Links { get; init; }

        /// <inheritdoc/>
        public override IEiffelEvent FromJson(string json)
        {
            return Deserialize<EiffelAnnouncementPublishedEvent>(json);
        }
    }
}