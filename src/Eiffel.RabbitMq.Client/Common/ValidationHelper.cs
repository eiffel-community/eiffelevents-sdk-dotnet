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
using Eiffel.Net.Events.Core;
using Eiffel.Net.Exceptions;

namespace Eiffel.RabbitMq.Client.Common
{
    internal static class ValidationHelper
    {
        /// <summary>
        /// Validate Event instance Version against event type version
        /// </summary>
        /// <param name="eiffelEvent">Instance to be checked</param>
        /// <typeparam name="T">Type to check against</typeparam>
        /// <exception cref="InvalidEiffelEventException">Thrown if the versions are not equal</exception>
        public static void ValidateEventVersion<T>(T eiffelEvent) where T : IEiffelEvent
        {
            var typeObj = (T)Activator.CreateInstance(typeof(T));
            if (eiffelEvent.GetVersion() != typeObj?.GetVersion())
                throw new InvalidEiffelEventException(typeof(T).Name, eiffelEvent.GetVersion());
        }
    }
}