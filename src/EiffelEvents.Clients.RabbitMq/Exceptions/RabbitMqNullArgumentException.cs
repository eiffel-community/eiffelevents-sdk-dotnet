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

namespace EiffelEvents.Clients.RabbitMq.Exceptions
{
    /// <summary>
    /// RabbitMqNullArgumentException is an exception wrapper for RabbitMQ null argument exceptions.
    /// </summary>
    public class RabbitMqNullArgumentException : RabbitMqException
    {
        public RabbitMqNullArgumentException(string propertyName) : 
            base($"Argument '{propertyName}' can't be null")
        {
        }

        
    }
}