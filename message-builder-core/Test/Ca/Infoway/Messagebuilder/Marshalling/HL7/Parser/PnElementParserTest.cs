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
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[TestFixture]
	public class PnElementParserTest : MarshallingTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNullNode()
		{
			XmlNode node = CreateNode("<something nullFlavor=\"NI\" />");
			PN pn = (PN)new PnElementParser().Parse(CreateContext("PN.FULL", SpecificationVersion.R02_04_02), node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.IsNull(pn.Value, "PersonName");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION, pn.NullFlavor, "null flavor");
		}

		private ParseContext CreateContext(string type, VersionNumber version)
		{
			return ParseContextImpl.Create(type, typeof(PersonName), version, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.POPULATED, null, null, false);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseEmptyNode()
		{
			XmlNode node = CreateNode("<something/>");
			PersonName personName = (PersonName)new PnElementParser().Parse(CreateContext("PN.BASIC", SpecificationVersion.R02_04_02)
				, node, this.xmlResult).BareValue;
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
			// use is mandatory
			Assert.IsNotNull(personName, "PersonName");
			Assert.AreEqual(0, personName.Parts.Count, "number of name parts");
			Assert.AreEqual(0, personName.Uses.Count, "number of name uses");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseSimpleNameNode()
		{
			XmlNode node = CreateNode("<something use=\"L\">John Doe</something>");
			PersonName personName = (PersonName)new PnElementParser().Parse(CreateContext("PN.SIMPLE", SpecificationVersion.R02_04_02
				), node, this.xmlResult).BareValue;
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.IsNotNull(personName, "PersonName");
			Assert.AreEqual(1, personName.Parts.Count, "number of name parts");
			Assert.AreEqual("John Doe", personName.Parts[0].Value, "name");
			Assert.IsNull(personName.Parts[0].Type);
			ICollection<Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse> uses = personName.Uses;
			Assert.AreEqual(1, uses.Count, "number of name uses");
			Assert.AreEqual("L", new List<Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse>(uses)[0].CodeValue, "name use");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParsePrefixes()
		{
			XmlNode node = CreateNode("<something use=\"L\">" + "  <prefix>Mr.</prefix>" + "</something>");
			PersonName personName = (PersonName)new PnElementParser().Parse(CreateContext("PN.FULL", SpecificationVersion.R02_04_02), 
				node, this.xmlResult).BareValue;
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual(1, personName.Parts.Count, "number of name parts");
			AssertNamePartAsExpected("prefix Mr", personName.Parts[0], PersonNamePartType.PREFIX, "Mr.", null);
			node = CreateNode("<something use=\"L\">" + "  <prefix>Mr.</prefix>" + "  <prefix>Mrs.</prefix>" + "</something>");
			personName = (PersonName)new PnElementParser().Parse(CreateContext("PN.FULL", SpecificationVersion.R02_04_02), node, this
				.xmlResult).BareValue;
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual(2, personName.Parts.Count, "number of name partsd second time");
			AssertNamePartAsExpected("prefix Mr", personName.Parts[0], PersonNamePartType.PREFIX, "Mr.", null);
			AssertNamePartAsExpected("prefix Mrs", personName.Parts[1], PersonNamePartType.PREFIX, "Mrs.", null);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseAll()
		{
			XmlNode node = CreateNode("<something use=\"L\">" + "  <prefix>Mr.</prefix>" + "  <given qualifier=\"IN\">John</given>" +
				 "  <given>Jimmy</given>" + "  <family qualifier=\"IN\">Jones</family>" + "  <suffix>ESQ</suffix>" + "</something>");
			PersonName personName = (PersonName)new PnElementParser().Parse(CreateContext("PN.FULL", SpecificationVersion.R02_04_02), 
				node, this.xmlResult).BareValue;
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual(1, personName.Uses.Count, "number of name uses");
			Assert.AreEqual(5, personName.Parts.Count, "number of name parts");
			AssertNamePartAsExpected("prefix Mr", personName.Parts[0], PersonNamePartType.PREFIX, "Mr.", null);
			AssertNamePartAsExpected("given John", personName.Parts[1], PersonNamePartType.GIVEN, "John", "IN");
			AssertNamePartAsExpected("given Jimmy", personName.Parts[2], PersonNamePartType.GIVEN, "Jimmy", null);
			AssertNamePartAsExpected("family Jones", personName.Parts[3], PersonNamePartType.FAMILY, "Jones", "IN");
			AssertNamePartAsExpected("suffix ESQ", personName.Parts[4], PersonNamePartType.SUFFIX, "ESQ", null);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseAllPlusUntypedValue()
		{
			XmlNode node = CreateNode("<name use=\"L\">Prime Minister of Canada" + "  <family>Landry</family>" + "  <prefix>MR.</prefix>"
				 + "  <suffix>III</suffix>" + "  <given>Chris</given>" + "  <given>William</given>" + "  <given qualifier=\"IN\">A.</given>"
				 + "</name>");
			PersonName personName = (PersonName)new PnElementParser().Parse(CreateContext("PN.FULL", SpecificationVersion.R02_04_02), 
				node, this.xmlResult).BareValue;
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
			// not allowed to have a simple name mixed in with parts
			Assert.AreEqual(1, personName.Uses.Count, "number of name uses");
			Assert.AreEqual(7, personName.Parts.Count, "number of name parts");
			AssertNamePartAsExpected("Untyped Prime Minister of Canada", personName.Parts[0], null, "Prime Minister of Canada", null);
			AssertNamePartAsExpected("family Landry", personName.Parts[1], PersonNamePartType.FAMILY, "Landry", null);
			AssertNamePartAsExpected("prefix MR.", personName.Parts[2], PersonNamePartType.PREFIX, "MR.", null);
			AssertNamePartAsExpected("suffix III", personName.Parts[3], PersonNamePartType.SUFFIX, "III", null);
			AssertNamePartAsExpected("given Chris", personName.Parts[4], PersonNamePartType.GIVEN, "Chris", null);
			AssertNamePartAsExpected("given William", personName.Parts[5], PersonNamePartType.GIVEN, "William", null);
			AssertNamePartAsExpected("given A.", personName.Parts[6], PersonNamePartType.GIVEN, "A.", "IN");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseFailure()
		{
			XmlNode node = CreateNode("<something><monkey>prefix 1</monkey>Organization name<delimiter>,</delimiter><suffix>Inc</suffix></something>"
				);
			try
			{
				new PnElementParser().Parse(CreateContext("PN.FULL", SpecificationVersion.R02_04_02), node, this.xmlResult);
				Assert.Fail("expected exception");
			}
			catch (XmlToModelTransformationException e)
			{
				Assert.AreEqual("Unexpected part of type: monkey", e.Message, "message");
			}
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseEmptyPrefix()
		{
			XmlNode node = CreateNode("<something use=\"L\">" + "  <prefix></prefix>" + "</something>");
			PersonName personName = (PersonName)new PnElementParser().Parse(CreateContext("PN.FULL", SpecificationVersion.R02_04_02), 
				node, this.xmlResult).BareValue;
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(2, this.xmlResult.GetHl7Errors().Count, "number of warnings");
			// empty part; must provide at least one part
			Assert.AreEqual(0, personName.Parts.Count, "number of name parts");
			Assert.AreEqual("Expected PN child node \"prefix\" to have a text node", xmlResult.GetHl7Errors()[0].GetMessage(), "warnings"
				);
			Assert.AreEqual("/something/prefix", xmlResult.GetHl7Errors()[0].GetPath(), "warnings");
		}

		private void AssertNamePartAsExpected(string message, EntityNamePart namePart, NamePartType expectedType, string expectedValue
			, string expectedQualifier)
		{
			Assert.AreEqual(expectedType, namePart.Type, message + " type");
			Assert.AreEqual(expectedValue, namePart.Value, message + " value");
			Assert.AreEqual(expectedQualifier, namePart.Qualifier == null ? null : namePart.Qualifier.CodeValue, message + " qualifier"
				);
		}
	}
}
