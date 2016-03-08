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
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.J5goodies;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2
{
	[TestFixture]
	public class AdR2ElementParserTest : MarshallingTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNullNode()
		{
			XmlNode node = CreateNode("<something nullFlavor=\"NI\" />");
			AD ad = (AD)(new AdR2ElementParser()).Parse(CreateContext("AD", SpecificationVersion.V02R02), node, this.xmlResult);
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
			AD ad = (AD)new AdR2ElementParser().Parse(CreateContext("AD", SpecificationVersion.V02R02), node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.IsNotNull(ad.Value, "empty node");
			Assert.IsTrue(ad.Value.Parts.IsEmpty(), "empty node value");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseTextNode()
		{
			XmlNode node = CreateNode("<something>text value</something>");
			AD ad = (AD)new AdR2ElementParser().Parse(CreateContext("AD", SpecificationVersion.V02R02), node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual(1, ad.Value.Parts.Count, "correct number of parts");
			AssertPostalAddressPartAsExpected("text node", ad.Value.Parts[0], null, "text value");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseTextNodeWithAttributes()
		{
			XmlNode node = CreateNode("<something representation=\"TXT\" mediaType=\"text/plain\">text value</something>");
			AD ad = (AD)new AdR2ElementParser().Parse(CreateContext("AD", SpecificationVersion.V02R02), node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual(1, ad.Value.Parts.Count, "correct number of parts");
			Assert.IsNull(ad.Value.IsNotOrdered);
			AssertPostalAddressPartAsExpected("text node with attributes", ad.Value.Parts[0], null, "text value");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseAll()
		{
			PlatformDate useable1 = DateUtil.GetDate(2008, 5, 25, 0, 0, 0, 0);
			PlatformDate useable2 = DateUtil.GetDate(2012, 8, 3, 0, 0, 0, 0);
			XmlNode node = CreateNode("<something isNotOrdered=\"true\"> " + "<city>city name</city>" + "freeform" + "<delimiter>,</delimiter>"
				 + "\n" + "<state>Ontario</state>" + "<useablePeriod operator=\"P\" value=\"20080625\" />" + "<useablePeriod value=\"20120903\" />"
				 + "</something>");
			AD ad = (AD)new AdR2ElementParser().Parse(CreateContext("AD", SpecificationVersion.V02R02), node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
			PostalAddress postalAddress = ad.Value;
			Assert.AreEqual(0, postalAddress.Uses.Count, "number of name uses");
			Assert.AreEqual(4, postalAddress.Parts.Count, "number of name parts");
			Assert.AreEqual(2, postalAddress.UseablePeriods.Count, "number of useablePeriods");
			Assert.IsTrue((bool)ad.Value.IsNotOrdered);
			//cast for .NET translation
			AssertPostalAddressPartAsExpected("city", postalAddress.Parts[0], PostalAddressPartType.CITY, "city name");
			AssertPostalAddressPartAsExpected("free", postalAddress.Parts[1], null, "freeform");
			AssertPostalAddressPartAsExpected("delimiter comma", postalAddress.Parts[2], PostalAddressPartType.DELIMITER, ",");
			AssertPostalAddressPartAsExpected("state", postalAddress.Parts[3], PostalAddressPartType.STATE, "Ontario");
			Assert.IsTrue(postalAddress.UseablePeriods.ContainsKey(useable1));
			Assert.AreEqual(SetOperator.PERIODIC_HULL, postalAddress.UseablePeriods.SafeGet(useable1));
			Assert.IsTrue(postalAddress.UseablePeriods.ContainsKey(useable2));
			Assert.AreEqual(SetOperator.INCLUDE, postalAddress.UseablePeriods.SafeGet(useable2));
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseUseablePeriodOutOfOrder()
		{
			PlatformDate useable1 = DateUtil.GetDate(2008, 5, 25, 0, 0, 0, 0);
			PlatformDate useable2 = DateUtil.GetDate(2012, 8, 3, 0, 0, 0, 0);
			XmlNode node = CreateNode("<something isNotOrdered=\"true\"> " + "<city>city name</city>" + "freeform" + "<useablePeriod operator=\"P\" value=\"20080625\" />"
				 + "<delimiter>,</delimiter>" + "\n" + "<state>Ontario</state>" + "<useablePeriod value=\"20120903\" />" + "</something>"
				);
			AD ad = (AD)new AdR2ElementParser().Parse(CreateContext("AD", SpecificationVersion.V02R02), node, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
			PostalAddress postalAddress = ad.Value;
			Assert.AreEqual(0, postalAddress.Uses.Count, "number of name uses");
			Assert.AreEqual(4, postalAddress.Parts.Count, "number of name parts");
			Assert.AreEqual(2, postalAddress.UseablePeriods.Count, "number of useablePeriods");
			Assert.IsTrue((bool)ad.Value.IsNotOrdered);
			//cast for .NET translation
			AssertPostalAddressPartAsExpected("city", postalAddress.Parts[0], PostalAddressPartType.CITY, "city name");
			AssertPostalAddressPartAsExpected("free", postalAddress.Parts[1], null, "freeform");
			AssertPostalAddressPartAsExpected("delimiter comma", postalAddress.Parts[2], PostalAddressPartType.DELIMITER, ",");
			AssertPostalAddressPartAsExpected("state", postalAddress.Parts[3], PostalAddressPartType.STATE, "Ontario");
			Assert.IsTrue(postalAddress.UseablePeriods.ContainsKey(useable1));
			Assert.AreEqual(SetOperator.PERIODIC_HULL, postalAddress.UseablePeriods.SafeGet(useable1));
			Assert.IsTrue(postalAddress.UseablePeriods.ContainsKey(useable2));
			Assert.AreEqual(SetOperator.INCLUDE, postalAddress.UseablePeriods.SafeGet(useable2));
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseFailure()
		{
			XmlNode node = CreateNode("<something><monkey>prefix 1</monkey>Organization name<delimiter>,</delimiter><suffix>Inc</suffix></something>"
				);
			new AdR2ElementParser().Parse(CreateContext("AD", SpecificationVersion.V02R02), node, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual("Address part type not valid: monkey (<monkey>)", this.xmlResult.GetHl7Errors()[0].GetMessage(), "message"
				);
		}

		private void AssertPostalAddressPartAsExpected(string message, PostalAddressPart postalAddressPart, PostalAddressPartType
			 expectedType, string expectedValue)
		{
			Assert.AreEqual(expectedType, postalAddressPart.Type, message + " type");
			Assert.AreEqual(expectedValue, postalAddressPart.Value, message + " value");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestUsesNoUse()
		{
			XmlNode node = CreateNode("<something/>");
			AD ad = (AD)new AdR2ElementParser().Parse(CreateContext("AD", SpecificationVersion.V02R02), node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual(0, ad.Value.Uses.Count, "zero uses");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestUsesOneUse()
		{
			XmlNode node = CreateNode("<something use=\"H\"/>");
			AD ad = (AD)new AdR2ElementParser().Parse(CreateContext("AD", SpecificationVersion.V02R02), node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual(1, ad.Value.Uses.Count, "one use");
			IEnumerator<Ca.Infoway.Messagebuilder.Domainvalue.PostalAddressUse> iterator = ad.Value.Uses.GetEnumerator();
			if (iterator.MoveNext())
			{
				//.NET
				Assert.IsTrue(iterator.Current.CodeValue.Equals(Ca.Infoway.Messagebuilder.Domainvalue.Basic.PostalAddressUse.HOME.CodeValue
					), "contains HOME use");
			}
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestUsesMultipleUses()
		{
			XmlNode node = CreateNode("<something use=\"H PHYS PST\"/>");
			AD ad = (AD)new AdR2ElementParser().Parse(CreateContext("AD", SpecificationVersion.V02R02), node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
			ICollection<string> uses = new HashSet<string>();
			PostalAddress postalAddress = ad.Value;
			foreach (Ca.Infoway.Messagebuilder.Domainvalue.PostalAddressUse postalAddressUse in postalAddress.Uses)
			{
				uses.Add(postalAddressUse.CodeValue);
			}
			Assert.AreEqual(3, postalAddress.Uses.Count, "three uses");
			Assert.IsTrue(uses.Contains(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_BasicPostalAddressUse.HOME.CodeValue), "contains HOME use"
				);
			Assert.IsTrue(uses.Contains(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_BasicPostalAddressUse.PHYSICAL.CodeValue), "contains PHYS use"
				);
			Assert.IsTrue(uses.Contains(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_BasicPostalAddressUse.POSTAL.CodeValue), "contains POSTAL use"
				);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestUsesUnknownUse()
		{
			XmlNode node = CreateNode("<something use=\"XXX\"/>");
			AD ad = (AD)new AdR2ElementParser().Parse(CreateContext("AD", SpecificationVersion.V02R02), node, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
			Assert.AreEqual(0, ad.Value.Uses.Count, "no uses");
		}
	}
}
