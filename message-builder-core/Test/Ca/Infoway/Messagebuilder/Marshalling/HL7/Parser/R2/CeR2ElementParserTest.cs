using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2;
using Ca.Infoway.Messagebuilder.Resolver;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2
{
	[TestFixture]
	public class CeR2ElementParserTest : MarshallingTestCase
	{
		private CeR2ElementParser parser;

		/// <exception cref="System.Exception"></exception>
		[NUnit.Framework.SetUp]
		public override void SetUp()
		{
			base.SetUp();
			CodeResolverRegistry.RegisterResolver(typeof(MockCharacters), new EnumBasedCodeResolver(typeof(MockEnum)));
			this.parser = new CeR2ElementParser();
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNullNode()
		{
			XmlNode node = CreateNode("<something nullFlavor=\"NI\"/>");
			CE_R2<MockCharacters> ce = (CE_R2<MockCharacters>)this.parser.Parse(ParseContextImpl.Create("CE", typeof(MockCharacters), 
				SpecificationVersion.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, null, false), node
				, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.IsNull(ce.Value, "value");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION, ce.NullFlavor, "null flavor");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseOtherNullNode()
		{
			XmlNode node = CreateNode("<something nullFlavor=\"OTH\"/>");
			CE_R2<MockCharacters> ce = (CE_R2<MockCharacters>)this.parser.Parse(ParseContextImpl.Create("CE", typeof(MockCharacters), 
				SpecificationVersion.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, null, false), node
				, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.IsNull(ce.Value, "value");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.OTHER, ce.NullFlavor, "null flavor");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseCodeWithNullNode()
		{
			XmlNode node = CreateNode("<something code=\"BARNEY\" nullFlavor=\"OTH\"/>");
			CE_R2<MockCharacters> ce = (CE_R2<MockCharacters>)this.parser.Parse(ParseContextImpl.Create("CE", typeof(MockCharacters), 
				SpecificationVersion.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, null, false), node
				, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual("BARNEY", ce.Value.GetCodeValue(), "value");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.OTHER, ce.NullFlavor, "null flavor");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseCodeWithNullNodeAndCodeSystem()
		{
			XmlNode node = CreateNode("<something code=\"BARNEY\" codeSystem=\"1.2.3.4.5\" nullFlavor=\"OTH\"/>");
			CE_R2<MockCharacters> ce = (CE_R2<MockCharacters>)this.parser.Parse(ParseContextImpl.Create("CE", typeof(MockCharacters), 
				SpecificationVersion.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, null, false), node
				, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual("BARNEY", ce.Value.GetCodeValue(), "value");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.OTHER, ce.NullFlavor, "null flavor");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseEmptyNode()
		{
			XmlNode node = CreateNode("<something/>");
			CE_R2<MockCharacters> ce = (CE_R2<MockCharacters>)this.parser.Parse(ParseContextImpl.Create("CE", typeof(MockCharacters), 
				SpecificationVersion.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY, null, null, false), node
				, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.IsNull(ce.Value, "empty node returns null");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNoCodeAttributeNode()
		{
			XmlNode node = CreateNode("<something notvalue=\"\" />");
			CE_R2<MockCharacters> ce = (CE_R2<MockCharacters>)this.parser.Parse(ParseContextImpl.Create("CE", typeof(MockCharacters), 
				SpecificationVersion.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, null, false), node
				, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.IsNull(ce.Value, "node with no code attribute returns null");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalid()
		{
			XmlNode node = CreateNode("<something code=\"ER\" />");
			CE_R2<MockCharacters> ce = (CE_R2<MockCharacters>)this.parser.Parse(ParseContextImpl.Create("CE", typeof(MockCharacters), 
				SpecificationVersion.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, null, false), node
				, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
			Assert.IsNull(ce.Value, "node with no code attribute returns null");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidWithEmptyNullFavorAttributeValue()
		{
			XmlNode node = CreateNode("<something code=\"BARNEY\" nullFlavor=\"\"/>");
			CE_R2<MockCharacters> ce = (CE_R2<MockCharacters>)this.parser.Parse(ParseContextImpl.Create("CE", typeof(MockCharacters), 
				SpecificationVersion.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, null, false), node
				, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
			Assert.AreEqual("BARNEY", ce.Value.GetCodeValue(), "node with no code attribute returns null");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalidNullFavorAttributeValue()
		{
			XmlNode node = CreateNode("<something nullFlavor=\"NOT A VALID NULL FAVOR VALUE\"/>");
			this.parser.Parse(ParseContextImpl.Create("CE", typeof(MockCharacters), SpecificationVersion.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
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
			CE_R2<MockCharacters> ce = (CE_R2<MockCharacters>)this.parser.Parse(ParseContextImpl.Create("CE", typeof(MockCharacters), 
				SpecificationVersion.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, null, false), node
				, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
			Assert.AreEqual("BARNEY", ce.Value.GetCodeValue(), "node with no code attribute returns null");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidFull()
		{
			XmlNode node = CreateNode("<something code=\"FRED\" codeSystem=\"1.2.3.4.5\" codeSystemName=\"aCsName\" codeSystemVersion=\"aCsVersion\" displayName=\"aDisplayName\">"
				 + "  <originalText>some original text</originalText>" + "  <translation code=\"M\" codeSystem=\"2.16.840.1.113883.5.1\" />"
				 + "  <translation code=\"F\" codeSystem=\"2.16.840.1.113883.5.1\" />" + "  <translation nullFlavor=\"OTH\" codeSystem=\"2.16.840.1.113883.5.1\" />"
				 + "</something>");
			CE_R2<MockCharacters> ce = (CE_R2<MockCharacters>)this.parser.Parse(ParseContextImpl.Create("CE", typeof(MockCharacters), 
				SpecificationVersion.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, null, false), node
				, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid(), "valid");
			Assert.AreEqual(MockEnum.FRED, ce.Value.Code, "enum found properly");
			Assert.AreEqual("aCsName", ce.Value.CodeSystemName);
			Assert.AreEqual("aCsVersion", ce.Value.CodeSystemVersion);
			Assert.AreEqual("aDisplayName", ce.Value.DisplayName);
			Assert.AreEqual("some original text", ce.Value.OriginalText.Content);
			Assert.AreEqual(3, ce.Value.Translation.Count);
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Payload.AdministrativeGender.MALE.CodeValue, ce.Value.Translation[0
				].Code.CodeValue);
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Payload.AdministrativeGender.MALE.CodeSystem, ce.Value.Translation[
				0].Code.CodeSystem);
			Assert.IsNull(ce.Value.Translation[0].NullFlavorForTranslationOnly);
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Payload.AdministrativeGender.FEMALE.CodeValue, ce.Value.Translation
				[1].Code.CodeValue);
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Payload.AdministrativeGender.FEMALE.CodeSystem, ce.Value.Translation
				[1].Code.CodeSystem);
			Assert.IsNull(ce.Value.Translation[1].NullFlavorForTranslationOnly);
			Assert.IsNull(ce.Value.Translation[2].Code.CodeValue);
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Payload.AdministrativeGender.FEMALE.CodeSystem, ce.Value.Translation
				[2].Code.CodeSystem);
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.OTHER, ce.Value.Translation[2].NullFlavorForTranslationOnly
				);
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
			CE_R2<MockCharacters> ce = (CE_R2<MockCharacters>)this.parser.Parse(ParseContextImpl.Create("CE", typeof(MockCharacters), 
				SpecificationVersion.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, null, false), node
				, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(4, this.xmlResult.GetHl7Errors().Count, "error message count");
			Assert.IsNotNull(ce.Value, "main enum found");
			Assert.AreEqual("BARNEY", ce.Value.GetCodeValue(), "main code");
			Assert.AreEqual("1.2.3.4.5", ce.Value.GetCodeSystem(), "main code");
			Assert.AreEqual("aCsName", ce.Value.CodeSystemName);
			Assert.AreEqual("aCsVersion", ce.Value.CodeSystemVersion);
			Assert.AreEqual("aDisplayName", ce.Value.DisplayName);
			Assert.IsNull(ce.Value.Operator);
			Assert.IsNull(ce.Value.Value);
			Assert.IsNull(ce.Value.SimpleValue);
			Assert.AreEqual("some original text", ce.Value.OriginalText.Content);
			Assert.AreEqual(2, ce.Value.Translation.Count);
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Payload.AdministrativeGender.MALE.CodeValue, ce.Value.Translation[0
				].Code.CodeValue);
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Payload.AdministrativeGender.MALE.CodeSystem, ce.Value.Translation[
				0].Code.CodeSystem);
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Payload.AdministrativeGender.FEMALE.CodeValue, ce.Value.Translation
				[1].Code.CodeValue);
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Payload.AdministrativeGender.FEMALE.CodeSystem, ce.Value.Translation
				[1].Code.CodeSystem);
			Assert.AreEqual(0, ce.Value.Qualifier.Count);
		}
	}
}
