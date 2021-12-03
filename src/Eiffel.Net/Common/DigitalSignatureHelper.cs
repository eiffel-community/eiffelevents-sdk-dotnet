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
using System.Security.Cryptography;
using System.Text;

namespace Eiffel.Net.Common
{
    internal static class DigitalSignatureHelper
    {
        /// <summary>
        /// Get exponent and modulous parameters using specified public key
        /// </summary>
        /// <param name="publicKey">Public key that used to get exponent and modulous parameters</param>
        /// <returns>RSAParameters with exponent and modulous values</returns>
        public static RSAParameters GetRSAParameters(string publicKey)
        {
            byte[] publicKeyBytes = Convert.FromBase64String(publicKey);
            RSA rsa = RSA.Create();
            rsa.ImportRSAPublicKey(publicKeyBytes, out var _);
            RSAParameters rsaKeyInfo = rsa.ExportParameters(false);
            return rsaKeyInfo;
        }

        /// <summary>
        /// Hash the passed string using SHA256 algorithm
        /// </summary>
        /// <param name="plainText">Plain text to be hashed</param>
        /// <returns>Hashing result as array of bytes</returns>
        public static byte[] GetSHA256Hash(string plainText)
        {
            using SHA256 mySHA256 = SHA256.Create();
            var plainTextBytes = Encoding.ASCII.GetBytes(plainText);
            return mySHA256.ComputeHash(plainTextBytes);
        }
    }
}
