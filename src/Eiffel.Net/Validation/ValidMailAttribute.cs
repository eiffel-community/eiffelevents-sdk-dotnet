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
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Eiffel.Net.Validation
{
    /// <summary>
    /// Validate email format.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ValidMailAttribute: ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var inputString = (string)value!;
            if (string.IsNullOrWhiteSpace(inputString)) return true;
            
            var regexString = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                              @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" + 
                              @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            var regex = new Regex(regexString);
            return regex.IsMatch(inputString);
        }
    }
}