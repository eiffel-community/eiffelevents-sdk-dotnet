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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Eiffel.Net.Common
{
    /// <summary>
    /// Provides helper methods to serialize and deserialize objects
    /// </summary>
    internal static class JsonHelper
    {
        private static readonly JsonSerializerSettings _jsonSerializerSettings;

        static JsonHelper()
        {
            _jsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = CustomContractResolver.Instance,
                Converters = new List<JsonConverter>
                {
                    new StringEnumConverter()
                },
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Populate
            };
        }

        /// <summary>
        /// Serialize the passed object to JSON string (with its properties in camel case)
        /// </summary>
        /// <param name="obj">object to be serialized</param>
        /// <param name="format">specify the indentation format</param>
        /// <returns>A JSON string representation of the object</returns>
        public static string Serialize(object obj, Formatting format)
        {
            _jsonSerializerSettings.Formatting = format;
            var json = JsonConvert.SerializeObject(obj, _jsonSerializerSettings);

            return json;
        }

        /// <summary>
        /// Deserializes the JSON to the specified type (with its properties in camel case)
        /// </summary>
        /// <param name="json">The object to deserialize</param>
        /// <typeparam name="T">The type of the object to deserialize to</typeparam>
        /// <returns>The deserialized object from the JSON string</returns>
        public static T Deserialize<T>(string json)
        {
            var eventObj = JsonConvert.DeserializeObject<T>(json, _jsonSerializerSettings);

            return eventObj;
        }
    }


    internal class CustomContractResolver : CamelCasePropertyNamesContractResolver
    {
        public static readonly CustomContractResolver Instance = new();

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);

            //Ignore Empty collection in serialization/deserialization
            if (property.PropertyType?.GetInterface(nameof(ICollection)) != null)
            {
                // Only Serialize Collections when they have values.
                property.ShouldSerialize =
                    instance =>
                        property.UnderlyingName != null &&
                        (instance?.GetType().GetProperty(property.UnderlyingName,
                                BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)?
                            .GetValue(instance) as ICollection)?
                        .Count > 0;

                // CollectionValueProvider for ICollection types to be set by empty object when not provided in JSON.
                property.ValueProvider = new CollectionValueProvider(property.ValueProvider, property.PropertyType);
            }

            return property;
        }
    }


    internal class CollectionValueProvider : IValueProvider
    {
        private readonly IValueProvider _innerProvider;
        private readonly object _defaultValue;

        public CollectionValueProvider(IValueProvider innerProvider, Type collectionType)
        {
            _innerProvider = innerProvider;
            _defaultValue = Activator.CreateInstance(collectionType);
        }

        public void SetValue(object target, object value)
        {
            // Initialize collection with empty object in deserialization.
            _innerProvider.SetValue(target, value ?? _defaultValue);
        }

        public object GetValue(object target)
        {
            return _innerProvider.GetValue(target);
        }
    }
}