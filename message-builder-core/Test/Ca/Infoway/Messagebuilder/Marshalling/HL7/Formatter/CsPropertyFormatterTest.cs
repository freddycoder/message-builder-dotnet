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
 * Last modified: $LastChangedDate: 2011-05-04 16:47:15 -0300 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
using System.Collections.Generic;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Util.Xml;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class CsPropertyFormatterTest : FormatterTestCase
	{
		internal class FakeCode : Code
		{
			public FakeCode(CsPropertyFormatterTest _enclosing)
			{
				this._enclosing = _enclosing;
			}

			public virtual string CodeSystem
			{
				get
				{
					return "1.1";
				}
			}

			public virtual string CodeValue
			{
				get
				{
					return "code";
				}
			}

			private readonly CsPropertyFormatterTest _enclosing;
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsNullValue()
		{
			IDictionary<string, string> result = new CsPropertyFormatter().GetAttributeNameValuePairs(new FormatContextImpl(new ModelToXmlResult
				(), null, "name", null, null), null, null);
			Assert.AreEqual(0, result.Count, "map size");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsEnum()
		{
			// used as expected: an enumerated object is passed in
			IDictionary<string, string> result = new CsPropertyFormatter().GetAttributeNameValuePairs(new FormatContextImpl(new ModelToXmlResult
				(), null, "name", null, null), CeRxDomainTestValues.CENTIMETRE, null);
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("code"), "key as expected");
			Assert.AreEqual("cm", result.SafeGet("code"), "value as expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsWithoutCodeSystem()
		{
			IDictionary<string, string> result = new CsPropertyFormatter().GetAttributeNameValuePairs(new FormatContextImpl(new ModelToXmlResult
				(), null, "name", null, null), new MockCodeImpl("fred", "The Flintstones"), null);
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsFalse(result.ContainsKey("codeSystem"), "key as expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsWithOriginalText()
		{
			CSImpl cs = new CSImpl(new CsPropertyFormatterTest.FakeCode(this));
			cs.OriginalText = "The Flintstones";
			string result = new CsPropertyFormatter().Format(GetContext("character"), cs);
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			Assert.IsTrue(this.result.GetHl7Errors()[0].GetMessage().StartsWith("Could not locate a registered domain type to match "
				));
			XmlDocument document = new DocumentFactory().CreateFromString(result);
			XmlNodeList list = document.GetElementsByTagName("originalText");
			Assert.AreEqual(1, list.Count, "originalText");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatNull()
		{
			string result = new CsPropertyFormatter().Format(GetContext("option"), new CSImpl(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor
				.OTHER));
			Assert.IsTrue(this.result.IsValid());
			XmlDocument document = new DocumentFactory().CreateFromString(result);
			XmlNodeList list = document.GetElementsByTagName("option");
			Assert.AreEqual(1, list.Count, "option");
			XmlElement element = ((XmlElement)list.Item(0));
			Assert.AreEqual("OTH", element.GetAttribute("nullFlavor"), "nullFlavor");
			Assert.IsFalse(element.HasAttribute("codeSystem"), "code system");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatNullWithCodeSystem()
		{
			string xml = new CsPropertyFormatter().Format(GetContext("option"), new CSImpl(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor
				.OTHER));
			Assert.IsTrue(this.result.IsValid());
			XmlDocument document = new DocumentFactory().CreateFromString(xml);
			XmlNodeList list = document.GetElementsByTagName("option");
			Assert.AreEqual(1, list.Count, "option");
			XmlElement result = ((XmlElement)list.Item(0));
			Assert.AreEqual("OTH", result.GetAttribute("nullFlavor"), "nullFlavor");
			Assert.IsFalse(result.HasAttribute("codeSystem"), "should not have codeSystem");
		}
	}
}
