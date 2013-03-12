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
 * Author:        $LastChangedBy: tmcgrady $
 * Last modified: $LastChangedDate: 2011-05-17 11:48:36 -0400 (Tue, 17 May 2011) $
 * Revision:      $LastChangedRevision: 2666 $
 */

using System.Xml;
using Ca.Infoway.Messagebuilder.Transport;
using Ca.Infoway.Messagebuilder.Util.Xml;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Transport
{
	/// <summary>sharpen.ignore - test - translated manually</summary>
	[TestFixture]
	public class SimpleRequestMessageTest
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldRenderDocumentToCreateStringVersionOfMessage()
		{
			XmlDocument document = new DocumentFactory().CreateFromString("<myMessage></myMessage>");
			RequestMessage message = SimpleRequestMessage.Create(document);
			Assert.IsTrue(message.GetMessageAsString().Contains("<myMessage"), "message");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldParseDocumentToCreateDomVersionOfMessage()
		{
			RequestMessage message = SimpleRequestMessage.Create("<myMessage></myMessage>");
			Assert.IsNotNull(message.GetMessageAsDocument(), "document");
//			Assert.AreEqual("myMessage", message.GetMessageAsDocument().DocumentElement.TagName, "document element");
		}

//		/// <exception cref="System.Exception"></exception>
//		[Test(Expected = typeof(TransportLayerException))]
//		public virtual void ShouldThrowExceptionIfMessageIsInvalid()
//		{
//			SimpleRequestMessage.Create("<myMessage>Fred");
//		}
	}
}
