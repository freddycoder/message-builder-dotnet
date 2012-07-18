/**
 * Copyright 2012 Canada Health Infoway, Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *        http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 * Author:        $LastChangedBy: tmcgrady $
 * Last modified: $LastChangedDate: 2011-05-17 11:48:36 -0400 (Tue, 17 May 2011) $
 * Revision:      $LastChangedRevision: 2666 $
 */

using System.Text;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Platform
{
    [TestFixture]
    public class Base64Test
    {
        [Test]
        public void ShouldEncodeAndDecode()
        {
            const string original = "atlantis";

            var encodeBase64String = Base64.EncodeBase64String(Encoding.ASCII.GetBytes(original));

            var decodedBytes = Base64.DecodeBase64(Encoding.ASCII.GetBytes(encodeBase64String));

            var recovered = Encoding.ASCII.GetString(decodedBytes);


            Assert.AreEqual(original,recovered,"base64 encoding/decoding doesn't work");
            
        }
    }
}
