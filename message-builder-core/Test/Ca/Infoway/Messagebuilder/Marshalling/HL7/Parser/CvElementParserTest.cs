using System;
using System.Collections.Generic;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Platform;
using Ca.Infoway.Messagebuilder.Terminology;
using Ca.Infoway.Messagebuilder.Xml;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[TestFixture]
	public class CvElementParserTest : MarshallingTestCase
	{
		private CvElementParser parser;

		/// <exception cref="System.Exception"></exception>
		[NUnit.Framework.SetUp]
		public override void SetUp()
		{
			base.SetUp();
			//CodeResolverRegistry.registerResolver(MockEnum.class, new EnumBasedCodeResolver(MockEnum.class));
			CodeResolverRegistry.RegisterResolver(typeof(MockCharacters), new EnumBasedCodeResolver(typeof(MockEnum)));
			this.parser = new CvElementParser();
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNullNode()
		{
			XmlNode node = CreateNode("<something nullFlavor=\"NI\"/>");
			CV cv = (CV)this.parser.Parse(ParserContextImpl.Create("CV", typeof(MockCharacters), SpecificationVersion.V02R02, null, null
				, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL), node, this.xmlResult);
			Assert.IsNull(cv.Value, "value");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION, cv.NullFlavor, "null flavor");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseOtherNullNode()
		{
			XmlNode node = CreateNode("<something nullFlavor=\"OTH\"/>");
			CV cv = (CV)this.parser.Parse(ParserContextImpl.Create("CV", typeof(MockCharacters), SpecificationVersion.V02R02, null, null
				, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL), node, this.xmlResult);
			Assert.IsNull(cv.Value, "value");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.OTHER, cv.NullFlavor, "null flavor");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseOtherNullNodeWithWrongCodeSystem()
		{
			XmlNode node = CreateNode("<something nullFlavor=\"OTH\" codeSystem=\"1.2.3.4.wrong.code.system\" />");
			CV cv = (CV)this.parser.Parse(ParserContextImpl.Create("CV", typeof(MockCharacters), SpecificationVersion.V02R02, null, null
				, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL), node, this.xmlResult);
			Assert.AreEqual("1.2.3.4.wrong.code.system", cv.Value.CodeSystem, "code system");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.OTHER, cv.NullFlavor, "null flavor");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseOtherNullNodeWithCodeSystem()
		{
			XmlNode node = CreateNode("<something nullFlavor=\"OTH\" codeSystem=\"1.2.3.4.5\" originalText=\"ahhh\"><originalText>ahhh</originalText></something>"
				);
			CV cv = (CV)this.parser.Parse(ParserContextImpl.Create("CV", typeof(MockCharacters), SpecificationVersion.V02R02, null, null
				, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL), node, this.xmlResult);
			Assert.AreEqual("1.2.3.4.5", cv.Value.CodeSystem, "code system");
			Assert.AreEqual("ahhh", cv.OriginalText, "original text");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.OTHER, cv.NullFlavor, "null flavor");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseEmptyNode()
		{
			XmlNode node = CreateNode("<something/>");
			CV cv = (CV)this.parser.Parse(ParserContextImpl.Create("CV", typeof(MockCharacters), SpecificationVersion.V02R02, null, null
				, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL), node, this.xmlResult);
			Assert.IsNull(cv.Value, "empty node returns null");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseCWEMustHaveOriginalTextOrCode()
		{
			XmlNode node = CreateNode("<something/>");
			CV cv = (CV)this.parser.Parse(CreateContext("CV", typeof(MockCharacters), SpecificationVersion.V02R02, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.OPTIONAL, CodingStrength.CWE), node, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid(), "valid");
			Assert.IsNull(cv.Value, "empty node returns null");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseCWEMustHaveNonEmptyOriginalTextOrCode()
		{
			XmlNode node = CreateNode("<something><originalText></originalText></something>");
			CV cv = (CV)this.parser.Parse(CreateContext("CV", typeof(MockCharacters), SpecificationVersion.V02R02, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.OPTIONAL, CodingStrength.CWE), node, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid(), "valid");
			Assert.IsNull(cv.Value, "empty node returns null");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseCNENullFlavorOtherMustHaveOriginalText()
		{
			XmlNode node = CreateNode("<something nullFlavor=\"OTH\"></something>");
			CV cv = (CV)this.parser.Parse(CreateContext("CV", typeof(MockCharacters), SpecificationVersion.V02R02, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.OPTIONAL, CodingStrength.CNE), node, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid(), "valid");
			Assert.IsNull(cv.Value, "empty node returns null");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseCNENonNullMustNotHaveOriginalText()
		{
			XmlNode node = CreateNode("<something code=\"codeAbc\" codesystem=\"1.2.3.4\"><originalText>some text</originalText></something>"
				);
			CV cv = (CV)this.parser.Parse(CreateContext("CV", typeof(MockCharacters), SpecificationVersion.V02R02, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.OPTIONAL, CodingStrength.CNE), node, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid(), "valid");
			Assert.IsNotNull(cv.OriginalText, "original text");
			// preserve what we can, even if an error is logged
			Assert.IsNull(cv.Value, "empty node returns null");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseCNEWithNullCanHaveOriginalText()
		{
			XmlNode node = CreateNode("<something nullFlavor=\"OTH\"><originalText>some text</originalText></something>");
			CV cv = (CV)this.parser.Parse(CreateContext("CV", typeof(MockCharacters), SpecificationVersion.V02R02, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.OPTIONAL, CodingStrength.CNE), node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid(), "valid");
			Assert.IsTrue(this.xmlResult.GetHl7Errors().IsEmpty());
			Assert.IsNotNull(cv.OriginalText, "original text");
			Assert.IsNull(cv.Value, "returns null value");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseEmptyNodeCNE()
		{
			XmlNode node = CreateNode("<something/>");
			CV cv = (CV)this.parser.Parse(CreateContext("CV", typeof(MockCharacters), SpecificationVersion.V02R02, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.MANDATORY, CodingStrength.CNE), node, this.xmlResult);
			Assert.IsNull(cv.Value, "empty node returns null");
			Assert.IsFalse(this.xmlResult.IsValid(), "valid");
		}

		private ParseContext CreateContext(string typeName, Type c, VersionNumber version, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
			 conformance, CodingStrength strength)
		{
			return ParserContextImpl.Create(typeName, c, version, null, null, conformance, strength, null);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNoCodeAttributeNode()
		{
			XmlNode node = CreateNode("<something notvalue=\"\" />");
			CV cv = (CV)this.parser.Parse(ParserContextImpl.Create("CV", typeof(MockCharacters), SpecificationVersion.V02R02, null, null
				, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL), node, this.xmlResult);
			Assert.IsNull(cv.Value, "node with no code attribute returns null");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalid()
		{
			XmlNode node = CreateNode("<something code=\"ER\" />");
			CV cv = (CV)this.parser.Parse(ParserContextImpl.Create("CV", typeof(MockCharacters), SpecificationVersion.V02R02, null, null
				, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL), node, this.xmlResult);
			Assert.IsNull(cv.Value, "node with no code attribute returns null");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidWithEmptyNullFavorAttributeValue()
		{
			XmlNode node = CreateNode("<something code=\"BARNEY\" nullFlavor=\"\"/>");
			CV cv = (CV)this.parser.Parse(ParserContextImpl.Create("CV", typeof(MockCharacters), SpecificationVersion.V02R02, null, null
				, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL), node, this.xmlResult);
			Assert.AreEqual("BARNEY", cv.Value.CodeValue, "node with no code attribute returns null");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalidNullFavorAttributeValue()
		{
			XmlNode node = CreateNode("<something nullFlavor=\"NOT A VALID NULL FAVOR VALUE\"/>");
			this.parser.Parse(ParserContextImpl.Create("CV", typeof(MockCharacters), SpecificationVersion.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.OPTIONAL), node, this.xmlResult);
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count, "warning message count");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidWithInvalidNullFavorAttributeValue()
		{
			XmlNode node = CreateNode("<something code=\"BARNEY\" nullFlavor=\"NOT A VALID NULL FAVOR VALUE\"/>");
			CV cv = (CV)this.parser.Parse(ParserContextImpl.Create("CV", typeof(MockCharacters), SpecificationVersion.V02R02, null, null
				, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL), node, this.xmlResult);
			Assert.AreEqual("BARNEY", cv.Value.CodeValue, "node with no code attribute returns null");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseContainsOriginalTextAndNullFlavor()
		{
			XmlNode node = CreateNode("<something nullFlavor=\"NI\"><originalText>My original text</originalText></something>");
			CV cs = (CV)this.parser.Parse(ParserContextImpl.Create("CV", typeof(MockCharacters), SpecificationVersion.V02R02, null, null
				, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL), node, this.xmlResult);
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION, cs.NullFlavor, "null flavor");
			Assert.AreEqual("My original text", cs.OriginalText, "original text");
			Assert.IsTrue(this.xmlResult.IsValid(), "valid");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidWithOriginalText()
		{
			XmlNode node = CreateNode("<something code=\"BARNEY\" ><originalText>Errr....</originalText></something>");
			CV cv = (CV)this.parser.Parse(ParserContextImpl.Create("CV", typeof(MockCharacters), SpecificationVersion.V02R02, null, null
				, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL), node, this.xmlResult);
			Assert.AreEqual("BARNEY", cv.Value.CodeValue, "node with no code attribute returns null");
			Assert.AreEqual("Errr....", cv.OriginalText, "original text");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidWithOriginalTextNoCodeSet()
		{
			XmlNode node = CreateNode("<something><originalText>Errr....</originalText></something>");
			// Adding to set used to fail on hashCode() call in OriginalTextWrapper
			CV cv = (CV)this.parser.Parse(ParserContextImpl.Create("CV", typeof(MockCharacters), SpecificationVersion.V02R02, null, null
				, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL), node, this.xmlResult);
			ICollection<Code> set = new LinkedSet<Code>();
			set.Add(cv.Value);
			Assert.AreEqual("Errr....", cv.OriginalText, "original text");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidWithEmptyOriginalText()
		{
			XmlNode node = CreateNode("<something><originalText /></something>");
			CV cv = (CV)this.parser.Parse(ParserContextImpl.Create("CV", typeof(MockCharacters), SpecificationVersion.V02R02, null, null
				, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL), node, this.xmlResult);
			Assert.IsNull(cv.OriginalText, "no original text");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseTooManyChildNodes()
		{
			XmlNode node = CreateNode("<something>" + "<monkey/>" + "</something>");
			CV cv = (CV)this.parser.Parse(ParserContextImpl.Create("CV", typeof(MockCharacters), SpecificationVersion.V02R02, null, null
				, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL), node, this.xmlResult);
			Assert.IsNull(cv.Value, "empty node with children returns null");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidEnumCode()
		{
			XmlNode node = CreateNode("<something code=\"FRED\" />");
			CV cv = (CV)this.parser.Parse(ParserContextImpl.Create("CV", typeof(MockCharacters), SpecificationVersion.V02R02, null, null
				, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL), node, this.xmlResult);
			Assert.AreEqual(MockEnum.FRED, cv.Value, "enum found properly");
			Assert.IsFalse(this.xmlResult.IsValid(), "valid");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalidEnumCode()
		{
			XmlNode node = CreateNode("<something code=\"ER\" codeSystem=\"1.2.3\"/>");
			XmlToModelResult result = new XmlToModelResult();
			CV cv = (CV)this.parser.Parse(ParserContextImpl.Create("CV", typeof(MockCharacters), SpecificationVersion.V02R02, null, null
				, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL), node, result);
			Assert.IsNull(cv.Value.CodeValue, "bogus enum not found");
			Assert.AreEqual(1, result.GetHl7Errors().Count, "error message count");
			Assert.AreEqual("The code, \"ER\", in element <something> is not a valid value for domain type \"MockCharacters\"", result
				.GetHl7Errors()[0].GetMessage(), "error message");
			Assert.AreEqual(Hl7ErrorCode.VALUE_NOT_IN_CODE_SYSTEM, result.GetHl7Errors()[0].GetHl7ErrorCode(), "error type");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidTranslation()
		{
			XmlNode node = CreateNode("<something code=\"BARNEY\" codeSystem=\"1.2.3.4.5\"><translation code=\"FRED\" codeSystem=\"1.2.3.4.5\" /></something>"
				);
			XmlToModelResult result = new XmlToModelResult();
			CD cd = (CD)this.parser.Parse(ParserContextImpl.Create("CD", typeof(MockCharacters), SpecificationVersion.V02R02, null, null
				, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL), node, result);
			Assert.IsNotNull(cd.Value, "main enum found");
			Assert.IsFalse(cd.Translations.IsEmpty(), "translation enum found");
			Assert.IsTrue(cd.Translations.Count == 1, "translation enum found");
			Assert.AreEqual(0, result.GetHl7Errors().Count, "error message count");
			Assert.AreEqual("BARNEY", cd.Value.CodeValue, "main code");
			Assert.AreEqual("FRED", cd.Translations[0].Value.CodeValue, "translation");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalidTranslation()
		{
			// triggers every error for translations
			XmlNode node = CreateNode("<something code=\"BARNEY\" codeSystem=\"1.2.3.4.5\">" + "<translation nullFlavor=\"OTH\" codeSystemName=\"aName\" codeSystemVersion=\"123\" displayName=\"aName\" >"
				 + "  <originalText>should not be here</originalText>" + "  <translation code=\"FRED\" codeSystem=\"1.2.3.4.5\" />" + "  <qualifier />"
				 + "</translation>" + "</something>");
			XmlToModelResult result = new XmlToModelResult();
			CD cd = (CD)this.parser.Parse(ParserContextImpl.Create("CD", typeof(MockCharacters), SpecificationVersion.V02R02, null, null
				, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL), node, result);
			Assert.IsNotNull(cd.Value, "main enum found");
			Assert.AreEqual("BARNEY", cd.Value.CodeValue, "main code");
			Assert.IsTrue(cd.Translations.IsEmpty(), "translation enum not found");
			Assert.AreEqual(9, result.GetHl7Errors().Count, "error message count");
			Assert.IsTrue(result.GetHl7Errors()[0].GetMessage().StartsWith("CD should not include the 'codeSystemName' property."), "error message"
				);
			Assert.IsTrue(result.GetHl7Errors()[1].GetMessage().StartsWith("CD should not include the 'codeSystemVersion' property.")
				, "error message");
			Assert.IsTrue(result.GetHl7Errors()[2].GetMessage().StartsWith("CD should not include the 'displayName' property."), "error message"
				);
			Assert.IsTrue(result.GetHl7Errors()[3].GetMessage().StartsWith("CD should not include the 'qualifier' property."), "error message"
				);
			Assert.IsTrue(result.GetHl7Errors()[4].GetMessage().StartsWith("CD should not include the 'nullFlavor' property."), "error message"
				);
			Assert.IsTrue(result.GetHl7Errors()[5].GetMessage().StartsWith("CD should not include the 'originalText' property."), "error message"
				);
			Assert.IsTrue(result.GetHl7Errors()[6].GetMessage().StartsWith("CD should not include the 'translation' property."), "error message"
				);
			Assert.IsTrue(result.GetHl7Errors()[7].GetMessage().StartsWith("Attribute code is mandatory for node /something/translation"
				), "error message");
			Assert.IsTrue(result.GetHl7Errors()[8].GetMessage().StartsWith("Attribute codeSystem is mandatory for node /something/translation"
				), "error message");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseMaximumValidTranslation()
		{
			XmlNode node = CreateNode("<something code=\"BARNEY\" codeSystem=\"1.2.3.4.5\">" + "<translation code=\"FRED\" codeSystem=\"1.2.3.4.5\" />"
				 + "<translation code=\"WILMA\" codeSystem=\"1.2.3.4.5\" />" + "<translation code=\"BETTY\" codeSystem=\"1.2.3.4.5\" />"
				 + "<translation code=\"BAM_BAM\" codeSystem=\"1.2.3.4.5\" />" + "<translation code=\"FRED\" codeSystem=\"1.2.3.4.5\" />"
				 + "<translation code=\"WILMA\" codeSystem=\"1.2.3.4.5\" />" + "<translation code=\"BETTY\" codeSystem=\"1.2.3.4.5\" />"
				 + "<translation code=\"BAM_BAM\" codeSystem=\"1.2.3.4.5\" />" + "<translation code=\"FRED\" codeSystem=\"1.2.3.4.5\" />"
				 + "<translation code=\"WILMA\" codeSystem=\"1.2.3.4.5\" /></something>");
			XmlToModelResult result = new XmlToModelResult();
			CD cd = (CD)this.parser.Parse(ParserContextImpl.Create("CD", typeof(MockCharacters), SpecificationVersion.V02R02, null, null
				, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL), node, result);
			Assert.IsNotNull(cd.Value, "main enum found");
			Assert.IsFalse(cd.Translations.IsEmpty(), "translation enums found");
			Assert.IsTrue(cd.Translations.Count == 10, "translation enums found");
			Assert.AreEqual(0, result.GetHl7Errors().Count, "error message count");
			Assert.AreEqual("BARNEY", cd.Value.CodeValue, "main code");
			Assert.AreEqual("FRED", cd.Translations[0].Value.CodeValue, "translation");
			Assert.AreEqual("WILMA", cd.Translations[9].Value.CodeValue, "translation");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseTooManyTranslations()
		{
			XmlNode node = CreateNode("<something code=\"BARNEY\" codeSystem=\"1.2.3.4.5\">" + "<translation code=\"FRED\" codeSystem=\"1.2.3.4.5\" />"
				 + "<translation code=\"WILMA\" codeSystem=\"1.2.3.4.5\" />" + "<translation code=\"BETTY\" codeSystem=\"1.2.3.4.5\" />"
				 + "<translation code=\"BAM_BAM\" codeSystem=\"1.2.3.4.5\" />" + "<translation code=\"FRED\" codeSystem=\"1.2.3.4.5\" />"
				 + "<translation code=\"WILMA\" codeSystem=\"1.2.3.4.5\" />" + "<translation code=\"BETTY\" codeSystem=\"1.2.3.4.5\" />"
				 + "<translation code=\"BAM_BAM\" codeSystem=\"1.2.3.4.5\" />" + "<translation code=\"FRED\" codeSystem=\"1.2.3.4.5\" />"
				 + "<translation code=\"WILMA\" codeSystem=\"1.2.3.4.5\" />" + "<translation code=\"BETTY\" codeSystem=\"1.2.3.4.5\" /></something>"
				);
			XmlToModelResult result = new XmlToModelResult();
			CD cd = (CD)this.parser.Parse(ParserContextImpl.Create("CD", typeof(MockCharacters), SpecificationVersion.V02R02, null, null
				, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL), node, result);
			Assert.IsNotNull(cd.Value, "main enum found");
			Assert.IsFalse(cd.Translations.IsEmpty(), "translation enums found");
			Assert.IsTrue(cd.Translations.Count == 11, "translation enums found");
			Assert.AreEqual(1, result.GetHl7Errors().Count, "error message count");
			Assert.AreEqual("BARNEY", cd.Value.CodeValue, "main code");
			Assert.AreEqual("FRED", cd.Translations[0].Value.CodeValue, "translation");
			Assert.AreEqual("BETTY", cd.Translations[10].Value.CodeValue, "translation");
			Assert.AreEqual("A maximum of 10 translations are allowed for any given code.", result.GetHl7Errors()[0].GetMessage(), "error message"
				);
			Assert.AreEqual(Hl7ErrorCode.DATA_TYPE_ERROR, result.GetHl7Errors()[0].GetHl7ErrorCode(), "error type");
		}
	}
}
