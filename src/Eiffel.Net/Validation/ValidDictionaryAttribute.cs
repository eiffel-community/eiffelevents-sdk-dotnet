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
using System.Linq;
using Eiffel.Net.Common;

namespace Eiffel.Net.Validation
{
    /// <summary>
    /// ValidDictionaryAttribute used to validate on Dictionaries to have valid value for dictionary top-level elements,
    /// with non-null object or empty, whitespace, and null string values.
    /// </summary>
    public class ValidDictionaryAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null) return ValidationResult.Success;
            var input = (EiffelDictionary)value;
            
            var invalidKeys = input
                .Where(x => x.Value is string valueString ? string.IsNullOrWhiteSpace(valueString) : x.Value == null)
                .Select(x => x.Key).ToList();

            if (!invalidKeys.Any())
                return ValidationResult.Success;

            return new ValidationResult(
                $"{validationContext.MemberName} error: Dictionary has invalid values for keys: {string.Join(",", invalidKeys)}.");
        }
    }
}