using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using EiffelEvents.Net.Common;
using EiffelEvents.Net.Events.Core;
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

        /// <summary>
        /// Returns a JSON representation of the event in the format given.
        /// </summary>
        /// <param name="format">Format of JSON output, default indented</param>
        /// <returns>JSON content as string</returns>
        public override string ToJson(JsonFormat format = JsonFormat.INDENTED)
        {
            return Serialize(format);
        }

        /// <inheritdoc/>
        public abstract override IEiffelEvent FromJson(string json);


        #region Event Serialization / Deserialization

        private string Serialize(JsonFormat format = JsonFormat.INDENTED)
        {
            var jsonFormat = format == JsonFormat.INDENTED ? Formatting.Indented : Formatting.None;

            if (SerializedLinks.Count > 0 || Links == null)
                return JsonHelper.Serialize(this, jsonFormat);

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

            return JsonHelper.Serialize(this, jsonFormat);
        }

        protected IEiffelEvent Deserialize<T>(string json, Func<string, List<EiffelSerializedLink>, object> mapLink)
            where T : EiffelEvent<TData, TMeta, TLinks>
        {
            var eventObj = JsonHelper.Deserialize<T>(json);

            if (eventObj == null) return null;

            var objectInstance = Activator.CreateInstance(typeof(TLinks));
            foreach (var propertyInfo in typeof(TLinks).GetProperties())
            {
                if (propertyInfo.PropertyType.IsSubclassOf(typeof(EiffelLink)) ||
                    propertyInfo.PropertyType.GetInterface(nameof(IList)) != null)
                {
                    var serializeLink = ((EiffelSerializedLinkCollection)eventObj.SerializedLinks)
                        .Where(x => x.Type == propertyInfo.Name.ToUpperUnderscoreSeparated())
                        .ToList();

                    var linkInstance = mapLink(propertyInfo.Name, serializeLink);
                    propertyInfo.SetValue(objectInstance, linkInstance);
                }
                // if (propertyInfo.PropertyType.IsSubclassOf(typeof(EiffelLink))) // is single link object
                // {
                //     var serializedLink = ((EiffelSerializedLinkCollection)eventObj.SerializedLinks)
                //         .FirstOrDefault(x => x.Type == propertyInfo.Name.ToUpperUnderscoreSeparated());
                //
                //     if (serializedLink == null) continue;
                //
                //     var linkInstance =
                //         Activator.CreateInstance(propertyInfo.PropertyType, serializedLink.Target,
                //             serializedLink.DomainId);
                //
                //     propertyInfo.SetValue(objectInstance, linkInstance);
                // }
                // else if (propertyInfo.PropertyType.GetInterface(nameof(IList)) != null) // is collection of link objects
                // {
                //     var serializeLink = ((EiffelSerializedLinkCollection)eventObj.SerializedLinks)
                //         .Where(x => x.Type == propertyInfo.Name.ToUpperUnderscoreSeparated())
                //         .ToList();
                //
                //     if (serializeLink.Count <= 0) continue;
                //
                //     var linkInstance = Activator.CreateInstance(propertyInfo.PropertyType) as IList;
                //
                //     foreach (var item in serializeLink)
                //     {
                //         linkInstance?.Add(Activator.CreateInstance(propertyInfo.PropertyType.GenericTypeArguments[0],
                //             item.Target, item.DomainId));
                //     }
                //
                //     propertyInfo.SetValue(objectInstance, linkInstance);
                // }
                else
                {
                    throw new EiffelUnhandledLinkTypeException(propertyInfo.PropertyType);
                }
            }

            var copied = eventObj with { Links = objectInstance as TLinks };
            return copied;
        }

        #endregion
    };
}