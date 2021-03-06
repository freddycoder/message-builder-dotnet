/**
 * Copyright 2013 Canada Health Infoway, Inc.
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
 * Author:        $LastChangedBy: gng $
 * Last modified: $LastChangedDate: 2015-11-19 18:20:12 -0500 (Fri, 30 Jan 2015) $
 * Revision:      $LastChangedRevision: 9755 $
 */


using System.IO;
using Ca.Infoway.Messagebuilder.Util.Xml;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Transport.Mohawk
{
	/// <summary>sharpen.ignore - test - translated manually</summary>
	[TestFixture]
	public class Hl7MessageExtractorTest
	{

        [Test]
		public virtual void ShouldExtractResponseMessage()
		{
			var b = LoadResponse("soapResponse.xml");

			var document = new Hl7MessageExtractor().GetHl7Message(new MemoryStream(b));
			
            Assert.IsTrue(document.Contains("<hl7:PRPA_IN101104CA"), "string");

            var documentElement = new DocumentFactory().CreateFromString(document).DocumentElement;

            var localName = documentElement.LocalName;

            Assert.AreEqual("PRPA_IN101104CA", localName, "root");
		}

        [Test]
        public virtual void ShouldExtractResponseMessageAlt()
        {
            var b = LoadResponse("soapResponseAlt.xml");

            var document = new Hl7MessageExtractor().GetHl7Message(new MemoryStream(b));

            Assert.IsTrue(document.Contains("<hl7:PRPA_IN101104CA"), "string");
        }

	    private byte[] LoadResponse(string doc)
		{
			var input = Platform.ResourceLoader.GetResource(GetType(), doc);

			try
			{
			    return ReadFully(input);
			}
			finally
			{
				IOUtils.CloseQuietly(input);
			}
		}

        private static byte[] ReadFully(Stream input)
        {
            var buffer = new byte[16 * 1024];

            using (var ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
	}
}
