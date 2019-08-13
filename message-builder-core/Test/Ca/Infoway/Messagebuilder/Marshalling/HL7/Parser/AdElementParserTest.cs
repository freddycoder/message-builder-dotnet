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


using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[TestFixture]
	public class AdElementParserTest : MarshallingTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNullNode()
		{
			XmlNode node = CreateNode("<something nullFlavor=\"NI\" />");
			AD ad = (AD)(new AdElementParser()).Parse(CreateContext("AD.BASIC", SpecificationVersion.V02R02), node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual(null, ad.Value, "null returned");
		}

		private ParseContext CreateContext(string type, VersionNumber version)
		{
			return ParseContextImpl.Create(type, typeof(PostalAddress), version, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.POPULATED, null, null, false);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseEmptyNode()
		{
			XmlNode node = CreateNode("<something/>");
			AD ad = (AD)new AdElementParser().Parse(CreateContext("AD.BASIC", SpecificationVersion.V02R02), node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.IsNotNull(ad.Value, "empty node");
			Assert.IsTrue(ad.Value.Parts.IsEmpty(), "empty node value");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseTextNode()
		{
			XmlNode node = CreateNode("<something>text value</something>");
			AD ad = (AD)new AdElementParser().Parse(CreateContext("AD.BASIC", SpecificationVersion.V02R02), node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual(1, ad.Value.Parts.Count, "correct number of parts");
			AssertPostalAddressPartAsExpected("text node", ad.Value.Parts[0], null, "text value", null);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseTextNodeWithAttributes()
		{
			XmlNode node = CreateNode("<something representation=\"TXT\" mediaType=\"text/plain\">text value</something>");
			AD ad = (AD)new AdElementParser().Parse(CreateContext("AD.BASIC", SpecificationVersion.V02R02), node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual(1, ad.Value.Parts.Count, "correct number of parts");
			AssertPostalAddressPartAsExpected("text node with attributes", ad.Value.Parts[0], null, "text value", null);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseAll()
		{
			XmlNode node = CreateNode("<something> <city>city name</city>freeform<delimiter>,</delimiter>\n<state code=\"ON\">Ontario</state></something>"
				);
			AD ad = (AD)new AdElementParser().Parse(CreateContext("AD.BASIC", SpecificationVersion.V02R02), node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
			PostalAddress postalAddress = ad.Value;
			Assert.AreEqual(0, postalAddress.Uses.Count, "number of name uses");
			Assert.AreEqual(4, postalAddress.Parts.Count, "number of name parts");
			AssertPostalAddressPartAsExpected("city", postalAddress.Parts[0], PostalAddressPartType.CITY, "city name", null);
			AssertPostalAddressPartAsExpected("free", postalAddress.Parts[1], null, "freeform", null);
			AssertPostalAddressPartAsExpected("delimiter comma", postalAddress.Parts[2], PostalAddressPartType.DELIMITER, ",", null);
			AssertPostalAddressPartAsExpected("state", postalAddress.Parts[3], PostalAddressPartType.STATE, "Ontario", "ON");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseFailure()
		{
			XmlNode node = CreateNode("<something><monkey>prefix 1</monkey>Organization name<delimiter>,</delimiter><suffix>Inc</suffix></something>"
				);
			new AdElementParser().Parse(CreateContext("AD.BASIC", SpecificationVersion.V02R02), node, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual("Address part type not valid: monkey (<monkey>)", this.xmlResult.GetHl7Errors()[0].GetMessage(), "message"
				);
		}

		private void AssertPostalAddressPartAsExpected(string message, PostalAddressPart postalAddressPart, PostalAddressPartType
			 expectedType, string expectedValue, string expectedCode)
		{
			Assert.AreEqual(expectedType, postalAddressPart.Type, message + " type");
			Assert.AreEqual(expectedValue, postalAddressPart.Value, message + " value");
			Assert.AreEqual(expectedCode, postalAddressPart.Code == null ? null : postalAddressPart.Code.CodeValue, message + " code"
				);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestUsesNoUse()
		{
			XmlNode node = CreateNode("<something/>");
			AD ad = (AD)new AdElementParser().Parse(CreateContext("AD.BASIC", SpecificationVersion.V02R02), node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual(0, ad.Value.Uses.Count, "zero uses");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestUsesOneUse()
		{
			XmlNode node = CreateNode("<something use=\"H\"/>");
			AD ad = (AD)new AdElementParser().Parse(CreateContext("AD.BASIC", SpecificationVersion.V02R02), node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual(1, ad.Value.Uses.Count, "one use");
			Assert.IsTrue(ad.Value.Uses.Contains(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_BasicPostalAddressUse.HOME), "contains HOME use"
				);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestUsesMultipleUses()
		{
			XmlNode node = CreateNode("<something use=\"H PHYS PST\"/>");
			AD ad = (AD)new AdElementParser().Parse(CreateContext("AD.BASIC", SpecificationVersion.V02R02), node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
			PostalAddress postalAddress = ad.Value;
			Assert.AreEqual(3, postalAddress.Uses.Count, "one use");
            int index = 0;
            PostalAddressUse[] expectedUses = { Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_BasicPostalAddressUse.HOME,
                Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_BasicPostalAddressUse.PHYSICAL,
                Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_BasicPostalAddressUse.POSTAL };
            foreach (PostalAddressUse actualUse in postalAddress.Uses)
            {
                PostalAddressUse expectedUse = expectedUses[index];
                Assert.AreEqual(expectedUse, actualUse, "contains " + expectedUse.CodeValue + " use");
                index++;
            }
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestUsesUnknownUse()
		{
			XmlNode node = CreateNode("<something use=\"XXX\"/>");
			AD ad = (AD)new AdElementParser().Parse(CreateContext("AD.BASIC", SpecificationVersion.V02R02), node, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
			Assert.AreEqual(0, ad.Value.Uses.Count, "no uses");
		}
	}
}
