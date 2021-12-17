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
using System.Security.Cryptography;
using EiffelEvents.Net.Common;
using EiffelEvents.Net.Events.Core;
using EiffelEvents.Net.Events.Core.Data;
using EiffelEvents.Net.Events.Core.Links;
using EiffelEvents.Net.Events.Edition_Paris.Shared.Security;
using EiffelEvents.Net.Exceptions;
using EiffelEvents.Net.Validation;
using FluentResults;
using Newtonsoft.Json;

namespace EiffelEvents.Net.Events.Edition_Paris.Shared
{
    /// <summary>
    /// Represents an abstract Eiffel event
    /// </summary>
    /// <typeparam name="TData">Type of data carried by this event</typeparam>
    /// <typeparam name="TMeta">Type of meta carried by this event</typeparam>
    /// <typeparam name="TLinks">Type of links carried by this event</typeparam>
    public abstract record EiffelEvent<TData, TMeta, TLinks> : IEiffelEvent
        where TData : EiffelData where TMeta : EiffelSharedMeta, new() where TLinks : EiffelLinks
    {
        #region Props

        /// <summary>
        /// Data carried by this event
        /// </summary>
        [NestedObject]
        public abstract TData Data { get; init; }

        /// <summary>
        /// Meta carried by this event
        /// </summary>
        [NestedObject]
        public abstract TMeta Meta { get; init; }

        /// <summary>
        /// Links carried by this event
        /// </summary>
        [JsonIgnore]
        [NestedObject]
        public abstract TLinks Links { get; init; }

        [JsonProperty("links")]
        internal virtual IEiffelSerializedLinkCollection SerializedLinks { get; init; } =
            new EiffelSerializedLinkCollection();

        #endregion

        #region Methods

        /// <summary>
        /// Returns a copy of this event that is signed
        /// </summary>
        /// <returns>Signed copy</returns>
        public TEvent Sign<TEvent>() where TEvent : class, IEiffelEvent
        {
            /*
            1- Generate the entire event, but with the meta.security.integrityProtection.signature 
            value set to an empty string.
            */
            var rsa = RSA.Create();
            var thisCopied = this with
            {
                Meta = Meta with
                {
                    Security = Meta.Security != null
                        ? Meta.Security with
                        {
                            IntegrityProtection = new EiffelIntegrityProtection
                            {
                                Alg = "RS256",
                                Signature = string.Empty,
                                PublicKey = Convert.ToBase64String(rsa.ExportRSAPublicKey())
                            }
                        }
                        : new EiffelSecurity()
                        {
                            IntegrityProtection = new EiffelIntegrityProtection
                            {
                                Alg = "RS256",
                                Signature = string.Empty,
                                PublicKey = Convert.ToBase64String(rsa.ExportRSAPublicKey())
                            }
                        }
                }
            };

            // 2- Serialize the event on Canonical JSON Form.
            var json = thisCopied.ToJson(JsonFormat.CANONICAL);
            var hashedBytes = DigitalSignatureHelper.GetSHA256Hash(json);

            //3 - Generate the signature using the meta.security.integrityProtection.alg algorithm.
            RSAPKCS1SignatureFormatter formatter = new(rsa);
            formatter.SetHashAlgorithm(nameof(SHA256));
            var signedValue = formatter.CreateSignature(hashedBytes);

            /*4 - Set the meta.security.integrityProtection.signature value to the resulting signature
            while maintaining Canonical JSON Form.*/
            return thisCopied with
            {
                Meta = thisCopied.Meta with
                {
                    Security = thisCopied.Meta.Security with
                    {
                        IntegrityProtection = thisCopied.Meta.Security.IntegrityProtection with
                        {
                            Signature = Convert.ToBase64String(signedValue)
                        }
                    }
                }
            } as TEvent;
        }

        /// <summary>
        /// Validate event signature
        /// </summary>
        /// <returns>true if the signature was valid. Otherwise, false</returns>
        public bool VerifySignature()
        {
            /*
            To verify the integrity of the event, the consumer then resets 
            meta.security.integrityProtection.signature to an empty string and ensures 
            Canonical JSON Form before verifying the signature.
             */
            var signature = Meta?.Security?.IntegrityProtection?.Signature;
            var publicKey = Meta?.Security?.IntegrityProtection?.PublicKey;

            if (string.IsNullOrWhiteSpace(signature) || string.IsNullOrWhiteSpace(publicKey))
            {
                throw new
                    EiffelSecurityException(
                        "Can't verify signature as Public Key or Signature is null or empty string");
            }

            var signedHashValue = Convert.FromBase64String(signature);

            var thisCopied = this with
            {
                Meta = Meta with
                {
                    Security = Meta.Security with
                    {
                        IntegrityProtection = Meta.Security.IntegrityProtection with
                        {
                            Signature = string.Empty
                        }
                    }
                }
            };
            var rsaPublicKeyInfo = DigitalSignatureHelper.GetRSAParameters(publicKey);

            var rsa = RSA.Create();
            rsa.ImportParameters(rsaPublicKeyInfo);
            var rsaDeformatter = new RSAPKCS1SignatureDeformatter(rsa);
            rsaDeformatter.SetHashAlgorithm(nameof(SHA256));

            var json = thisCopied.ToJson(JsonFormat.CANONICAL);
            var hashedBytes = DigitalSignatureHelper.GetSHA256Hash(json);

            return rsaDeformatter.VerifySignature(hashedBytes, signedHashValue);
        }

        /// <summary>
        /// Validate all event's attributes that marked/annotated by validation attributes.
        /// </summary>
        public Result Validate()
        {
            var validationContext = new ValidationContext(this, null, null);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(this, validationContext, validationResults, true);

            if (isValid)
                return Result.Ok();

            return Result.Fail($"Validation Errors: ")
                .WithErrors(validationResults.Select(r => new Error(r.ErrorMessage)));
        }

        /// <inheritdoc/>
        public string GetVersion()
        {
            return Meta == null ? new TMeta().Version : Meta.Version;
        }

        /// <inheritdoc/>
        public virtual string ToJson(JsonFormat format = JsonFormat.INDENTED)
        {
            return this.Serialize(format);
        }

        #endregion

        #region Abstracts

        /// <inheritdoc/>
        public abstract IEiffelEvent FromJson(string json);

        #endregion

        #region Event Serialization / Deserialization

        private string Serialize(JsonFormat format = JsonFormat.INDENTED)
        {
            var jsonFormat = format == JsonFormat.INDENTED ? Formatting.Indented : Formatting.None;

            if (SerializedLinks.Count > 0 || Links == null)
                return JsonHelper.Serialize(this, jsonFormat);

            SerializeLinks();

            return JsonHelper.Serialize(this, jsonFormat);
        }

        protected virtual void SerializeLinks()
        {
            foreach (var propertyInfo in Links.GetType().GetProperties())
            {
                if (propertyInfo.PropertyType == typeof(string))
                {
                    var val = propertyInfo.GetValue(Links)?.ToString();
                    if (!string.IsNullOrWhiteSpace(val))
                        SerializedLinks.Add(new EiffelSerializedLink
                            {
                                Type = propertyInfo.Name.ToUpperUnderscoreSeparated(),
                                Target = val
                            }
                        );
                }
                else if (propertyInfo.PropertyType == typeof(List<string>))
                {
                    var items = (List<string>)propertyInfo.GetValue(Links);

                    if (items is { Count: > 0 })
                        ((EiffelSerializedLinkCollection)SerializedLinks).AddRange(items.Select(x =>
                            new EiffelSerializedLink
                            {
                                Type = propertyInfo.Name.ToUpperUnderscoreSeparated(),
                                Target = x
                            }));
                }
                else
                {
                    throw new EiffelUnhandledLinkTypeException(propertyInfo.PropertyType);
                }
            }
        }

        protected virtual IEiffelEvent Deserialize<T>(string json) where T : EiffelEvent<TData, TMeta, TLinks>
        {
            /*
            * 1 take instance from Link type
            * 2 for all properties, according property type call FirstOrDefault/Select list
            */
            var eventObj = JsonHelper.Deserialize<T>(json);

            if (eventObj == null) return null;

            var objectInstance = DeserializeLinks(eventObj.SerializedLinks);

            var copied = eventObj with { Links = objectInstance };
            return copied;
        }

        protected virtual TLinks DeserializeLinks(IEiffelSerializedLinkCollection serializedLinks)
        {
            var links = (EiffelSerializedLinkCollection)serializedLinks;
            var objectInstance = Activator.CreateInstance(typeof(TLinks));
            foreach (var propertyInfo in typeof(TLinks).GetProperties())
            {
                if (propertyInfo.PropertyType == typeof(string))
                {
                    propertyInfo.SetValue(objectInstance,
                        links
                        .FirstOrDefault(x => x.Type == propertyInfo.Name.ToUpperUnderscoreSeparated())?
                        .Target);
                }
                else if (propertyInfo.PropertyType == typeof(List<string>))
                {
                    propertyInfo.SetValue(objectInstance,
                        links
                        .Where(x => x.Type == propertyInfo.Name.ToUpperUnderscoreSeparated())
                        .Select(x => x.Target).ToList());
                }
                else
                {
                    throw new EiffelUnhandledLinkTypeException(propertyInfo.PropertyType);
                }
            }

            return objectInstance as TLinks;
        }

        #endregion
    }
}