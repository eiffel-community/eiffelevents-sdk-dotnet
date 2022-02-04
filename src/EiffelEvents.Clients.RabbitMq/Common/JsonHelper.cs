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

using Newtonsoft.Json.Linq;

namespace EiffelEvents.Clients.RabbitMq.Common
{
    internal static class JsonHelper
    {
        /// <summary>
        /// Get type and version from specified JSON eiffel event
        /// </summary>
        /// <param name="json">JSON string</param>
        /// <returns>Tuple of (type, version). Returns empty strings in case of failure.</returns>
        public static (string type, string version) GetTypeAndVersion(string json)
        {
            // parse JSON
            var eventObj = JObject.Parse(json);

            // try to get meta obj
            var metaObj = eventObj["meta"];
            if (metaObj == null) return (string.Empty, string.Empty);

            // try to get type and version
            var type = metaObj["type"]?.ToString();
            var version = metaObj["version"]?.ToString();

            return (type, version);
        }
    }
}