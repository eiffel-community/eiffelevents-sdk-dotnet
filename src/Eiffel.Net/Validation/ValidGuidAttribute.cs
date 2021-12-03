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
using System.Linq;

namespace Eiffel.Net.Validation
{
    /// <summary>
    /// ValidGuidAttribute used to validate on strings if it hold a valid guid.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ValidGuidAttribute : ValidationAttribute
    {
        public bool IsMultiple { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null) return ValidationResult.Success;

            switch (IsMultiple)
            {
                case true:
                    var valueLst = (value as IEnumerable<string>)?.ToList();
                    if (valueLst == null)
                        return ValidationResult.Success;

                    var invalidIndices = new List<int>();

                    for (var i = 0; i < valueLst.Count; i++)
                        if (!IsValid(valueLst[i]))
                            invalidIndices.Add(i);

                    return invalidIndices.Count == 0
                        ? ValidationResult.Success
                        : new ValidationResult(
                            $"{validationContext.MemberName} error: Invalid UUID at indices: {string.Join(",", invalidIndices)}.");
                case false:
                    return IsValid((string)value)
                        ? ValidationResult.Success
                        : new ValidationResult(
                            $"{validationContext.MemberName} error: Invalid UUID.");
            }
        }

        private bool IsValid(string value)
        {
            var parsed = Guid.TryParse(value, out var guidValue);
            if (parsed)
                return guidValue != Guid.Empty;
            return false;
        }
    }
}