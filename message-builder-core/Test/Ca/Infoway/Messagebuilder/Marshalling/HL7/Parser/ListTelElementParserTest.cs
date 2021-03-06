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


using System.Collections.Generic;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Xml;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[TestFixture]
	public class ListTelElementParserTest : ParserTestCase
	{
		private ParserRegistry parserRegistry = ParserRegistry.GetInstance();

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParse()
		{
			XmlNode node = CreateNode("<top><telecom specializationType=\"TEL.PHONE\" value=\"tel:+1-519-555-2345;ext=1\"/>" + "<telecom specializationType=\"TEL.PHONE\" value=\"tel:+1-416-555-2345;ext=2\"/></top>"
				);
			BareANY result = new ListElementParser(this.parserRegistry).Parse(ParseContextImpl.Create("LIST<TEL.PHONEMAIL>", null, SpecificationVersion
				.V02R02, null, null, null, Cardinality.Create("0-4"), null, false), AsList(node.ChildNodes), this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
			IList<TelecommunicationAddress> list = ((LIST<TEL, TelecommunicationAddress>)result).RawList();
			Assert.IsNotNull(list, "null");
			Assert.AreEqual(2, list.Count, "size");
			TelecommunicationAddress phone1 = list[0];
			TelecommunicationAddress phone2 = list[1];
			Assert.AreEqual("+1-519-555-2345;ext=1", phone1.Address);
			Assert.AreEqual("+1-416-555-2345;ext=2", phone2.Address);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseWithMinimumViolation()
		{
			XmlNode node = CreateNode("<top><telecom specializationType=\"TEL.PHONE\" value=\"tel:+1-519-555-2345;ext=1\"/>" + "<telecom specializationType=\"TEL.PHONE\" value=\"tel:+1-416-555-2345;ext=2\"/></top>"
				);
			BareANY result = new ListElementParser(this.parserRegistry).Parse(ParseContextImpl.Create("LIST<TEL.PHONEMAIL>", null, SpecificationVersion
				.V02R02, null, null, null, Cardinality.Create("3-5"), null, false), AsList(node.ChildNodes), this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
			Assert.AreEqual("Number of elements (2) is less than the specified minimum (3)", this.xmlResult.GetHl7Errors()[0].GetMessage
				());
			IList<TelecommunicationAddress> list = ((LIST<TEL, TelecommunicationAddress>)result).RawList();
			Assert.IsNotNull(list, "null");
			Assert.AreEqual(2, list.Count, "size");
			TelecommunicationAddress phone1 = list[0];
			TelecommunicationAddress phone2 = list[1];
			Assert.AreEqual("+1-519-555-2345;ext=1", phone1.Address);
			Assert.AreEqual("+1-416-555-2345;ext=2", phone2.Address);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseWithMaximumViolation()
		{
			XmlNode node = CreateNode("<top><telecom specializationType=\"TEL.PHONE\" value=\"tel:+1-519-555-2345;ext=1\"/>" + "<telecom specializationType=\"TEL.PHONE\" value=\"tel:+1-519-555-2345;ext=2\"/>"
				 + "<telecom specializationType=\"TEL.PHONE\" value=\"tel:+1-519-555-2345;ext=3\"/>" + "<telecom specializationType=\"TEL.PHONE\" value=\"tel:+1-416-555-2345;ext=4\"/></top>"
				);
			BareANY result = new ListElementParser(this.parserRegistry).Parse(ParseContextImpl.Create("LIST<TEL.PHONEMAIL>", null, SpecificationVersion
				.V02R02, null, null, null, Cardinality.Create("1-2"), null, false), AsList(node.ChildNodes), this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
			Assert.AreEqual("Number of elements (4) is more than the specified maximum (2)", this.xmlResult.GetHl7Errors()[0].GetMessage
				());
			IList<TelecommunicationAddress> list = ((LIST<TEL, TelecommunicationAddress>)result).RawList();
			Assert.IsNotNull(list, "null");
			Assert.AreEqual(4, list.Count, "size");
			TelecommunicationAddress phone1 = list[0];
			TelecommunicationAddress phone2 = list[1];
			TelecommunicationAddress phone3 = list[2];
			TelecommunicationAddress phone4 = list[3];
			Assert.AreEqual("+1-519-555-2345;ext=1", phone1.Address);
			Assert.AreEqual("+1-519-555-2345;ext=2", phone2.Address);
			Assert.AreEqual("+1-519-555-2345;ext=3", phone3.Address);
			Assert.AreEqual("+1-416-555-2345;ext=4", phone4.Address);
		}
	}
}
