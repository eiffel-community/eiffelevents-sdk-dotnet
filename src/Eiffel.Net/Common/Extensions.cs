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

using System.Text.RegularExpressions;

namespace Eiffel.Net.Common
{
    public static class Extensions
    {
        /// <summary>
        /// Replace every upper case letter with (_) then the letter removing the underscore in index 0.
        /// Example: "FirstName" will be "First_Name"
        /// </summary>
        /// <param name="str">String to be converted</param>
        /// <returns></returns>
        public static string ToUnderscoreSeparated(this string str)
        {
            var replaced = Regex.Replace(str, @"(?<!_)([A-Z])", "_$1");

            var result = replaced[0] == '_' ? replaced.Remove(0, 1) : replaced;

            return result;
        }
        
        /// <summary>
        /// Replace every upper case letter with (_) then the letter removing the underscore in index 0.
        /// Then convert output to upper case.
        /// Example: "FirstName" will be "FIRST_NAME"
        /// </summary>
        /// <param name="str">String to be converted</param>
        /// <returns></returns>
        public static string ToUpperUnderscoreSeparated(this string str)
        {
            return str.ToUnderscoreSeparated().ToUpper();
        }
    }
}