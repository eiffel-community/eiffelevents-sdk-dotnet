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
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Eiffel.Net.Validation
{
    /// <summary>
    /// NestedObjectAttribute used to mark complex type property,
    /// to enable DataAnnotation to validate its internal properties.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class NestedObjectAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return ValidationResult.Success;

            var membersValidationContext = new ValidationContext(value, null, null);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(value, membersValidationContext, validationResults, true);

            return isValid
                ? ValidationResult.Success
                : new ValidationResult($"{validationContext.MemberName} errors: {validationResults.ListToString()}");
        }
    }
}