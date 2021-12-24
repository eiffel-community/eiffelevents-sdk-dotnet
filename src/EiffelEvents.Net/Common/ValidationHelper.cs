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
using System.IO;
using System.Linq;
using System.Reflection;
using EiffelEvents.Net.Events.Core;
using EiffelEvents.Net.Exceptions;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace EiffelEvents.Net.Common
{
    public static class ValidationHelper
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

        public static bool ValidateEventSchema<T>(string eiffelEventJson, out List<string> errors)
            where T : IEiffelEvent
        {
            // load schema
            var eventName = typeof(T).Name;
            var edition = typeof(T).Namespace?.Split('.').Last().Replace('_', '-');

            var jsonSchema = GetSchemaFromFileSystem(edition, eventName);
            var schema = JSchema.Parse(jsonSchema);

            // parse json
            var json = JToken.Parse(eiffelEventJson);

            // validate json
            var valid = json.IsValid(schema, out IList<ValidationError> validationErrors);
            errors = valid
                ? new List<string>()
                : validationErrors.Select(x => $"{x.Message} - Path: {x.Path}").ToList();

            return valid;
        }

        private static string GetSchemaFromFileSystem(string edition, string eventName)
        {
            var currentAssemblyPath =
                Path.GetDirectoryName(Assembly.GetAssembly(typeof(ValidationHelper))!.Location);

            var path = Path.Combine(currentAssemblyPath!, "Schemas", edition, eventName);
            var schemaFiles = Directory.GetFiles(path, "*.json");

            if (schemaFiles.Length == 0)
                throw new Exception($"Event json schema is not found for {eventName}, {edition}");

            return File.ReadAllText(schemaFiles[0]);
        }
    }
}