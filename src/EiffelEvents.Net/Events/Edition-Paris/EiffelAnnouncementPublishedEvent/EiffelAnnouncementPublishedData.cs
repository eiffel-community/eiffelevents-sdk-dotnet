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

using System.ComponentModel.DataAnnotations;
using EiffelEvents.Net.Events.Core.Data;
using EiffelEvents.Net.Events.Edition_Paris.Shared.Enums;

namespace EiffelEvents.Net.Events.Edition_Paris
{
    public record EiffelAnnouncementPublishedData : EiffelData
    {
        /// <summary>
        /// The heading of the announcement.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string Heading { get; init; }


        /// <summary>
        /// The body of the announcement.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string Body { get; init; }
        
        /// <summary>
        /// A URI where further information can be obtained, if applicable.
        /// </summary>
        public string Uri { get; init; }
        
        /// <summary>
        /// The severity of the announcement.
        /// The CLOSED and CANCELED values SHOULD only be used when following up
        /// a previous announcement, i.e. in conjunction with a MODIFIED_ANNOUNCEMENT link.
        /// </summary>
        [Required]
        public EiffelAnnouncementSeverity? Severity { get; init; }


    }
}