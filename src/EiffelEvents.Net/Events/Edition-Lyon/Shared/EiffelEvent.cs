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
using EiffelEvents.Net.Common;
using EiffelEvents.Net.Events.Core.Data;
using EiffelEvents.Net.Events.Core.Links;
using EiffelEvents.Net.Events.Edition_Lyon.Shared.Links;
using EiffelEvents.Net.Exceptions;
using Newtonsoft.Json;

namespace EiffelEvents.Net.Events.Edition_Lyon.Shared
{
    public abstract record EiffelEvent<TData, TMeta, TLinks> :
        Edition_Paris.Shared.EiffelEvent<TData, TMeta, TLinks>
        where TData : EiffelData where TMeta : EiffelSharedMeta, new() where TLinks : EiffelLinks
    {
        #region Props

        [JsonProperty("links")]
        internal override IEiffelSerializedLinkCollection SerializedLinks { get; init; } =
            new EiffelSerializedLinkCollection();

        #endregion

        #region Event Serialization / Deserialization

        /// <inheritdoc/>
        protected override void PopulateSerializedLinks()
        {
            foreach (var propertyInfo in
                     Links.GetType().GetProperties().Where(x => x.GetValue(Links) != null))
            {
                var currentLink = propertyInfo.GetValue(Links);
                switch (currentLink)
                {
                    case EiffelLink val:
                        SerializedLinks.Add(new EiffelSerializedLink
                        {
                            Type = val.Type,
                            Target = val.Target,
                            DomainId = val.DomainId
                        });
                        break;
                    case IList items when items is not { Count: > 0 }:
                        continue;
                    case IList items when items[0] is not EiffelLink:
                        continue;
                    case IList items:
                    {
                        var eiffelLinks = (IEnumerable<EiffelLink>)items;
                        ((EiffelSerializedLinkCollection)SerializedLinks).AddRange(
                            eiffelLinks.Select(x => new EiffelSerializedLink
                            {
                                Type = x.Type,
                                Target = x.Target,
                                DomainId = x.DomainId
                            }));
                        break;
                    }
                    default:
                        throw new EiffelUnhandledLinkTypeException(propertyInfo.PropertyType);
                }
            }
        }

        /// <inheritdoc/>
        protected override TLinks GetLinksObject(IEiffelSerializedLinkCollection serializedLinks)
        {
            var links = (EiffelSerializedLinkCollection)serializedLinks;

            var objectInstance = Activator.CreateInstance(typeof(TLinks));

            foreach (var propertyInfo in typeof(TLinks).GetProperties())
            {
                if (propertyInfo.PropertyType.IsSubclassOf(typeof(EiffelLink))) // is single link object
                {
                    var serializedLink = links
                        .FirstOrDefault(x => x.Type == propertyInfo.Name.ToUpperUnderscoreSeparated());

                    if (serializedLink == null) continue;

                    var linkInstance =
                        Activator.CreateInstance(propertyInfo.PropertyType, serializedLink.Target,
                            serializedLink.DomainId);

                    propertyInfo.SetValue(objectInstance, linkInstance);
                }
                else if (propertyInfo.PropertyType.GetInterface(nameof(IList)) != null) // is collection of link objects
                {
                    var serializeLink = links
                        .Where(x => x.Type == propertyInfo.Name.ToUpperUnderscoreSeparated())
                        .ToList();

                    var linkInstance = Activator.CreateInstance(propertyInfo.PropertyType) as IList;

                    foreach (var item in serializeLink)
                    {
                        linkInstance?.Add(Activator.CreateInstance(propertyInfo.PropertyType.GenericTypeArguments[0],
                            item.Target, item.DomainId));
                    }

                    propertyInfo.SetValue(objectInstance, linkInstance);
                }
                else
                {
                    throw new EiffelUnhandledLinkTypeException(propertyInfo.PropertyType);
                }
            }
            return objectInstance as TLinks;
        }

        #endregion
    };
}