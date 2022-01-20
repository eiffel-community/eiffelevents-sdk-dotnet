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

using System.Collections.Generic;
using System.IO;
using System.Linq;
using EiffelEvents.Net.Exceptions;
using FluentResults;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace EiffelEvents.Net.Validation
{
    public static class SchemaValidationHelper
    {
        /// <summary>
        /// Validate json string of Eiffel event with the corresponding protocol Event json schema
        /// </summary>
        /// <param name="eiffelEventJson">JSON to be validated</param>
        /// <param name="type">Event type</param>
        /// <param name="version">Event version</param>
        /// <returns>
        /// <see cref="Result"/> object that holds the validation results with errors array in case of not valid JSON.
        /// </returns>
        public static Result ValidateEvent(string eiffelEventJson, string type, string version)
        {
            // load schema
            var jsonSchema = GetSchemaFromFileSystem(type, version);
            var schema = JSchema.Parse(jsonSchema);

            // parse json
            var json = JToken.Parse(eiffelEventJson);

            // validate json
            var valid = json.IsValid(schema, out IList<ValidationError> validationErrors);

            return valid
                ? Result.Ok()
                : Result.Fail(string.Join(", ", validationErrors.Select(x => $"{x.Message} - Path: {x.Path}")));
        }

        private static string GetSchemaFromFileSystem(string type, string version)
        {
            var path = Path.Join("Schemas", type);
            if (!Directory.Exists(path))
                throw new SchemaNotFoundException(type, version);

            path = Path.Join(path, $"{version}.json");
            if (!File.Exists(path))
                throw new SchemaNotFoundException(type, version);

            return File.ReadAllText(path);
        }
    }
}