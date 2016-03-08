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
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2;
using Ca.Infoway.Messagebuilder.Resolver;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2
{
	[TestFixture]
	public class SxcmCdR2ElementParserTest : MarshallingTestCase
	{
		private SxcmCdR2ElementParser parser;

		/// <exception cref="System.Exception"></exception>
		[NUnit.Framework.SetUp]
		public override void SetUp()
		{
			base.SetUp();
			CodeResolverRegistry.RegisterResolver(typeof(MockCharacters), new EnumBasedCodeResolver(typeof(MockEnum)));
			this.parser = new SxcmCdR2ElementParser();
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNullNode()
		{
			XmlNode node = CreateNode("<something nullFlavor=\"NI\"/>");
			SXCM_R2<CodedTypeR2<MockCharacters>> cd = (SXCM_R2<CodedTypeR2<MockCharacters>>)this.parser.Parse(ParseContextImpl.Create
				("SXCM<CD>", typeof(MockCharacters), SpecificationVersion.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.OPTIONAL, null, null, false), node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.IsNull(cd.Value, "value");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION, cd.NullFlavor, "null flavor");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseOtherNullNode()
		{
			XmlNode node = CreateNode("<something nullFlavor=\"OTH\"/>");
			SXCM_R2<CodedTypeR2<MockCharacters>> cd = (SXCM_R2<CodedTypeR2<MockCharacters>>)this.parser.Parse(ParseContextImpl.Create
				("SXCM<CD>", typeof(MockCharacters), SpecificationVersion.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.OPTIONAL, null, null, false), node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.IsNull(cd.Value, "value");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.OTHER, cd.NullFlavor, "null flavor");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseCodeWithNullNode()
		{
			XmlNode node = CreateNode("<something code=\"BARNEY\" nullFlavor=\"OTH\"/>");
			SXCM_R2<CodedTypeR2<MockCharacters>> cd = (SXCM_R2<CodedTypeR2<MockCharacters>>)this.parser.Parse(ParseContextImpl.Create
				("SXCM<CD>", typeof(MockCharacters), SpecificationVersion.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.OPTIONAL, null, null, false), node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual("BARNEY", cd.Value.GetCodeValue(), "value");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.OTHER, cd.NullFlavor, "null flavor");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseCodeWithNullNodeAndCodeSystem()
		{
			XmlNode node = CreateNode("<something code=\"BARNEY\" codeSystem=\"1.2.3.4.5\" nullFlavor=\"OTH\"/>");
			SXCM_R2<CodedTypeR2<MockCharacters>> cd = (SXCM_R2<CodedTypeR2<MockCharacters>>)this.parser.Parse(ParseContextImpl.Create
				("SXCM<CD>", typeof(MockCharacters), SpecificationVersion.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.OPTIONAL, null, null, false), node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual("BARNEY", cd.Value.GetCodeValue(), "value");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.OTHER, cd.NullFlavor, "null flavor");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseEmptyNode()
		{
			XmlNode node = CreateNode("<something/>");
			SXCM_R2<CodedTypeR2<MockCharacters>> cd = (SXCM_R2<CodedTypeR2<MockCharacters>>)this.parser.Parse(ParseContextImpl.Create
				("SXCM<CD>", typeof(MockCharacters), SpecificationVersion.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.MANDATORY, null, null, false), node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual(SetOperator.INCLUDE, cd.Value.Operator);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNoCodeAttributeNode()
		{
			XmlNode node = CreateNode("<something notvalue=\"\" />");
			SXCM_R2<CodedTypeR2<MockCharacters>> cd = (SXCM_R2<CodedTypeR2<MockCharacters>>)this.parser.Parse(ParseContextImpl.Create
				("SXCM<CD>", typeof(MockCharacters), SpecificationVersion.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.OPTIONAL, null, null, false), node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual(SetOperator.INCLUDE, cd.Value.Operator);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalid()
		{
			XmlNode node = CreateNode("<something code=\"ER\" />");
			SXCM_R2<CodedTypeR2<MockCharacters>> cd = (SXCM_R2<CodedTypeR2<MockCharacters>>)this.parser.Parse(ParseContextImpl.Create
				("SXCM<CD>", typeof(MockCharacters), SpecificationVersion.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.OPTIONAL, null, null, false), node, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
			Assert.AreEqual(SetOperator.INCLUDE, cd.Value.Operator);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidWithEmptyNullFavorAttributeValue()
		{
			XmlNode node = CreateNode("<something code=\"BARNEY\" nullFlavor=\"\"/>");
			SXCM_R2<CodedTypeR2<MockCharacters>> cd = (SXCM_R2<CodedTypeR2<MockCharacters>>)this.parser.Parse(ParseContextImpl.Create
				("SXCM<CD>", typeof(MockCharacters), SpecificationVersion.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.OPTIONAL, null, null, false), node, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
			Assert.AreEqual("BARNEY", cd.Value.GetCodeValue(), "node with no code attribute returns null");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalidNullFavorAttributeValue()
		{
			XmlNode node = CreateNode("<something nullFlavor=\"NOT A VALID NULL FAVOR VALUE\"/>");
			this.parser.Parse(ParseContextImpl.Create("SXCM<CD>", typeof(MockCharacters), SpecificationVersion.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.OPTIONAL, null, null, false), node, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count, "warning message count");
		}

		// invalid NF
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidWithInvalidNullFavorAttributeValue()
		{
			XmlNode node = CreateNode("<something code=\"BARNEY\" nullFlavor=\"NOT A VALID NULL FAVOR VALUE\"/>");
			SXCM_R2<CodedTypeR2<MockCharacters>> cd = (SXCM_R2<CodedTypeR2<MockCharacters>>)this.parser.Parse(ParseContextImpl.Create
				("SXCM<CD>", typeof(MockCharacters), SpecificationVersion.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.OPTIONAL, null, null, false), node, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
			Assert.AreEqual("BARNEY", cd.Value.GetCodeValue(), "node with no code attribute returns null");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidFull()
		{
			XmlNode node = CreateNode("<something code=\"FRED\" codeSystem=\"1.2.3.4.5\" codeSystemName=\"aCsName\" codeSystemVersion=\"aCsVersion\" displayName=\"aDisplayName\" operator=\"P\">"
				 + "  <originalText>some original text</originalText>" + "  <qualifier inverted=\"true\"><name code=\"cm\" codeSystem=\"1.2.3.4\"/><value code=\"normal\" codeSystem=\"2.16.840.1.113883.5.14\"/></qualifier>"
				 + "  <qualifier inverted=\"true\"><name code=\"M\" codeSystem=\"2.16.840.1.113883.5.1\"/><value code=\"ACT\" codeSystem=\"2.16.840.1.113883.5.6\"/></qualifier>"
				 + "  <translation code=\"M\" codeSystem=\"2.16.840.1.113883.5.1\" />" + "  <translation code=\"F\" codeSystem=\"2.16.840.1.113883.5.1\" />"
				 + "</something>");
			SXCM_R2<CodedTypeR2<MockCharacters>> cd = (SXCM_R2<CodedTypeR2<MockCharacters>>)this.parser.Parse(ParseContextImpl.Create
				("SXCM<CD>", typeof(MockCharacters), SpecificationVersion.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.OPTIONAL, null, null, false), node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid(), "valid");
			Assert.AreEqual(MockEnum.FRED, cd.Value.Code, "enum found properly");
			Assert.AreEqual("aCsName", cd.Value.CodeSystemName);
			Assert.AreEqual("aCsVersion", cd.Value.CodeSystemVersion);
			Assert.AreEqual("aDisplayName", cd.Value.DisplayName);
			Assert.AreEqual("some original text", cd.Value.OriginalText.Content);
			Assert.AreEqual(2, cd.Value.Translation.Count);
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Payload.AdministrativeGender.MALE.CodeValue, cd.Value.Translation[0
				].Code.CodeValue);
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Payload.AdministrativeGender.MALE.CodeSystem, cd.Value.Translation[
				0].Code.CodeSystem);
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Payload.AdministrativeGender.FEMALE.CodeValue, cd.Value.Translation
				[1].Code.CodeValue);
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Payload.AdministrativeGender.FEMALE.CodeSystem, cd.Value.Translation
				[1].Code.CodeSystem);
			Assert.AreEqual(2, cd.Value.Qualifier.Count);
			Assert.IsTrue(cd.Value.Qualifier[0].Inverted);
			Assert.IsTrue(cd.Value.Qualifier[1].Inverted);
			Assert.AreEqual("cm", cd.Value.Qualifier[0].Name.GetCodeValue());
			Assert.AreEqual("M", cd.Value.Qualifier[1].Name.GetCodeValue());
			Assert.AreEqual("normal", cd.Value.Qualifier[0].Value.GetCodeValue());
			Assert.AreEqual("ACT", cd.Value.Qualifier[1].Value.GetCodeValue());
			Assert.AreEqual(SetOperator.PERIODIC_HULL, cd.Value.Operator);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseFull()
		{
			XmlNode node = CreateNode("<something code=\"BARNEY\" codeSystem=\"1.2.3.4.5\" codeSystemName=\"aCsName\" codeSystemVersion=\"aCsVersion\" displayName=\"aDisplayName\" value=\"1.2\" operator=\"P\">"
				 + "  some freeform text" + "  <originalText>some original text</originalText>" + "  <qualifier inverted=\"true\"><name code=\"cm\" codeSystem=\"1.2.3.4\"/><value code=\"normal\" codeSystem=\"2.16.840.1.113883.5.14\"/></qualifier>"
				 + "  <qualifier inverted=\"true\"><name code=\"M\" codeSystem=\"2.16.840.1.113883.5.1\"/><value code=\"ACT\" codeSystem=\"2.16.840.1.113883.5.6\"/></qualifier>"
				 + "  <translation code=\"M\" codeSystem=\"2.16.840.1.113883.5.1\" />" + "  <translation code=\"F\" codeSystem=\"2.16.840.1.113883.5.1\" />"
				 + "</something>");
			SXCM_R2<CodedTypeR2<MockCharacters>> cd = (SXCM_R2<CodedTypeR2<MockCharacters>>)this.parser.Parse(ParseContextImpl.Create
				("SXCM<CD>", typeof(MockCharacters), SpecificationVersion.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.OPTIONAL, null, null, false), node, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(2, this.xmlResult.GetHl7Errors().Count, "error message count");
			Assert.IsNotNull(cd.Value, "main enum found");
			Assert.AreEqual("BARNEY", cd.Value.GetCodeValue(), "main code");
			Assert.AreEqual("1.2.3.4.5", cd.Value.GetCodeSystem(), "main code");
			Assert.AreEqual("aCsName", cd.Value.CodeSystemName);
			Assert.AreEqual("aCsVersion", cd.Value.CodeSystemVersion);
			Assert.AreEqual("aDisplayName", cd.Value.DisplayName);
			Assert.IsNull(cd.Value.Value);
			Assert.IsNull(cd.Value.SimpleValue);
			Assert.AreEqual("some original text", cd.Value.OriginalText.Content);
			Assert.AreEqual(2, cd.Value.Translation.Count);
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Payload.AdministrativeGender.MALE.CodeValue, cd.Value.Translation[0
				].Code.CodeValue);
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Payload.AdministrativeGender.MALE.CodeSystem, cd.Value.Translation[
				0].Code.CodeSystem);
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Payload.AdministrativeGender.FEMALE.CodeValue, cd.Value.Translation
				[1].Code.CodeValue);
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Payload.AdministrativeGender.FEMALE.CodeSystem, cd.Value.Translation
				[1].Code.CodeSystem);
			Assert.AreEqual(2, cd.Value.Qualifier.Count);
			Assert.IsTrue(cd.Value.Qualifier[0].Inverted);
			Assert.IsTrue(cd.Value.Qualifier[1].Inverted);
			Assert.AreEqual("cm", cd.Value.Qualifier[0].Name.GetCodeValue());
			Assert.AreEqual("M", cd.Value.Qualifier[1].Name.GetCodeValue());
			Assert.AreEqual("normal", cd.Value.Qualifier[0].Value.GetCodeValue());
			Assert.AreEqual("ACT", cd.Value.Qualifier[1].Value.GetCodeValue());
			Assert.AreEqual(SetOperator.PERIODIC_HULL, cd.Value.Operator);
		}
	}
}
