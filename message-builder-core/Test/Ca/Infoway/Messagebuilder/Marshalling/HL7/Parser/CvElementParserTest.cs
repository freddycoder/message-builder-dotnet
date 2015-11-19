using System;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Resolver;
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
			CodeResolverRegistry.RegisterResolver(typeof(MockCharacters), new EnumBasedCodeResolver(typeof(MockEnum)));
			this.parser = new CvElementParser();
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNullNode()
		{
			XmlNode node = CreateNode("<something nullFlavor=\"NI\"/>");
			CV cv = (CV)this.parser.Parse(ParseContextImpl.Create("CV", typeof(MockCharacters), SpecificationVersion.V02R02, null, null
				, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, null, false), node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.IsNull(cv.Value, "value");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION, cv.NullFlavor, "null flavor");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseOtherNullNode()
		{
			XmlNode node = CreateNode("<something nullFlavor=\"OTH\"/>");
			CV cv = (CV)this.parser.Parse(ParseContextImpl.Create("CV", typeof(MockCharacters), SpecificationVersion.V02R02, null, null
				, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, null, false), node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.IsNull(cv.Value, "value");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.OTHER, cv.NullFlavor, "null flavor");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseCodeWithNullNode()
		{
			XmlNode node = CreateNode("<something code=\"BARNEY\" codeSystem=\"1.2.3.4.5\" nullFlavor=\"OTH\"/>");
			CD cd = (CD)this.parser.Parse(ParseContextImpl.Create("CD", typeof(MockCharacters), SpecificationVersion.V02R02, null, null
				, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, null, false), node, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
			Assert.AreEqual("BARNEY", cd.Value.CodeValue, "value");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.OTHER, cd.NullFlavor, "null flavor");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseOtherNullNodeWithWrongCodeSystem()
		{
			XmlNode node = CreateNode("<something nullFlavor=\"OTH\" codeSystem=\"1.2.3.4.wrong.code.system\" />");
			CV cv = (CV)this.parser.Parse(ParseContextImpl.Create("CV", typeof(MockCharacters), SpecificationVersion.V02R02, null, null
				, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, null, false), node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual("1.2.3.4.wrong.code.system", cv.Value.CodeSystem, "code system");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.OTHER, cv.NullFlavor, "null flavor");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseOtherNullNodeWithCodeSystem()
		{
			XmlNode node = CreateNode("<something nullFlavor=\"OTH\" codeSystem=\"1.2.3.4.5\"><originalText>ahhh</originalText></something>"
				);
			CV cv = (CV)this.parser.Parse(ParseContextImpl.Create("CV", typeof(MockCharacters), SpecificationVersion.V02R02, null, null
				, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, null, false), node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual("1.2.3.4.5", cv.Value.CodeSystem, "code system");
			Assert.AreEqual("ahhh", cv.OriginalText, "original text");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.OTHER, cv.NullFlavor, "null flavor");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseEmptyNode()
		{
			XmlNode node = CreateNode("<something/>");
			CV cv = (CV)this.parser.Parse(ParseContextImpl.Create("CV", typeof(MockCharacters), SpecificationVersion.V02R02, null, null
				, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, null, false), node, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
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
		public virtual void TestParseCNEMustHaveNonEmptyCodeAndCodeSystem()
		{
			XmlNode node = CreateNode("<something code=\"\" codeSystem=\"\" />");
			CV cv = (CV)this.parser.Parse(CreateContext("CV", typeof(MockCharacters), SpecificationVersion.V02R02, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.OPTIONAL, CodingStrength.CNE), node, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid(), "valid");
			Assert.IsNull(cv.Value, "empty node returns null");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidCNENullFlavor()
		{
			XmlNode node = CreateNode("<something nullFlavor=\"NI\"></something>");
			CV cv = (CV)this.parser.Parse(CreateContext("CV", typeof(MockCharacters), SpecificationVersion.V02R02, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.OPTIONAL, CodingStrength.CNE), node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid(), "valid");
			Assert.IsNull(cv.Value, "empty node returns null");
			Assert.AreEqual("NI", cv.NullFlavor.CodeValue);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalidCNENullFlavorWithOriginalTextAndSomethingElse()
		{
			XmlNode node = CreateNode("<something nullFlavor=\"OTH\" codeSystem=\"this_isnt_allowed\"><originalText>some text</originalText></something>"
				);
			CD cd = (CD)this.parser.Parse(CreateContext("CD", typeof(MockCharacters), SpecificationVersion.V02R02, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.OPTIONAL, CodingStrength.CNE), node, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid(), "valid");
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
			Assert.AreEqual("this_isnt_allowed", cd.Value.CodeSystem);
			Assert.AreEqual("OTH", cd.NullFlavor.CodeValue);
			Assert.AreEqual("some text", cd.OriginalText);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidCNENullFlavorWithOriginalTextAtMaxLength()
		{
			XmlNode node = CreateNode("<something nullFlavor=\"OTH\"><originalText>123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890</originalText></something>"
				);
			CD cd = (CD)this.parser.Parse(CreateContext("CD", typeof(MockCharacters), SpecificationVersion.V02R02, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.OPTIONAL, CodingStrength.CNE), node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid(), "valid");
			Assert.IsNull(cd.Value, "empty node returns null");
			Assert.AreEqual("OTH", cd.NullFlavor.CodeValue);
			Assert.AreEqual("123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890"
				, cd.OriginalText);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidCNENullFlavorWithOriginalTextAtMaxLengthPlusOne()
		{
			XmlNode node = CreateNode("<something nullFlavor=\"OTH\"><originalText>1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901</originalText></something>"
				);
			CD cd = (CD)this.parser.Parse(CreateContext("CD", typeof(MockCharacters), SpecificationVersion.V02R02, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.OPTIONAL, CodingStrength.CNE), node, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid(), "valid");
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
			Assert.IsNull(cd.Value, "empty node returns null");
			Assert.AreEqual("OTH", cd.NullFlavor.CodeValue);
			Assert.AreEqual("1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901"
				, cd.OriginalText);
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
			Assert.IsFalse(this.xmlResult.IsValid(), "valid");
			Assert.IsNull(cv.Value, "empty node returns null");
		}

		private ParseContext CreateContext(string typeName, Type c, VersionNumber version, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
			 conformance, CodingStrength strength)
		{
			return ParseContextImpl.Create(typeName, c, version, null, null, conformance, null, strength, null, null, false);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNoCodeAttributeNode()
		{
			XmlNode node = CreateNode("<something notvalue=\"\" />");
			CV cv = (CV)this.parser.Parse(ParseContextImpl.Create("CV", typeof(MockCharacters), SpecificationVersion.V02R02, null, null
				, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, null, false), node, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
			Assert.IsNull(cv.Value, "node with no code attribute returns null");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalid()
		{
			XmlNode node = CreateNode("<something code=\"ER\" />");
			CV cv = (CV)this.parser.Parse(ParseContextImpl.Create("CV", typeof(MockCharacters), SpecificationVersion.V02R02, null, null
				, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, null, false), node, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(3, this.xmlResult.GetHl7Errors().Count);
			Assert.IsNull(cv.Value, "node with no code attribute returns null");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalidCWE()
		{
			XmlNode node = CreateNode("<something code=\"BARNEY\" />");
			CD cd = (CD)this.parser.Parse(ParseContextImpl.Create("CD", typeof(MockCharacters), SpecificationVersion.V02R02, null, null
				, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, CodingStrength.CWE, null, null, false), node, this.xmlResult
				);
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
			// code system is mandatory when providing code and is CWE
			Assert.AreEqual("BARNEY", cd.Value.CodeValue);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidWithEmptyNullFavorAttributeValue()
		{
			XmlNode node = CreateNode("<something code=\"BARNEY\" nullFlavor=\"\"/>");
			CV cv = (CV)this.parser.Parse(ParseContextImpl.Create("CV", typeof(MockCharacters), SpecificationVersion.V02R02, null, null
				, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, null, false), node, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(2, this.xmlResult.GetHl7Errors().Count);
			Assert.AreEqual("BARNEY", cv.Value.CodeValue, "node with no code attribute returns null");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalidNullFavorAttributeValue()
		{
			XmlNode node = CreateNode("<something nullFlavor=\"NOT A VALID NULL FAVOR VALUE\"/>");
			this.parser.Parse(ParseContextImpl.Create("CV", typeof(MockCharacters), SpecificationVersion.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.OPTIONAL, null, null, false), node, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(2, this.xmlResult.GetHl7Errors().Count, "warning message count");
		}

		// invalid NF; code/codeSystem are mandatory
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidWithInvalidNullFavorAttributeValue()
		{
			XmlNode node = CreateNode("<something code=\"BARNEY\" nullFlavor=\"NOT A VALID NULL FAVOR VALUE\"/>");
			CV cv = (CV)this.parser.Parse(ParseContextImpl.Create("CV", typeof(MockCharacters), SpecificationVersion.V02R02, null, null
				, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, null, false), node, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(2, this.xmlResult.GetHl7Errors().Count);
			Assert.AreEqual("BARNEY", cv.Value.CodeValue, "node with no code attribute returns null");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseContainsOriginalTextAndNullFlavor()
		{
			XmlNode node = CreateNode("<something nullFlavor=\"NI\"><originalText>My original text</originalText></something>");
			CV cs = (CV)this.parser.Parse(ParseContextImpl.Create("CV", typeof(MockCharacters), SpecificationVersion.V02R02, null, null
				, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, null, false), node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid(), "valid");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION, cs.NullFlavor, "null flavor");
			Assert.AreEqual("My original text", cs.OriginalText, "original text");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidWithOriginalText()
		{
			XmlNode node = CreateNode("<something code=\"BARNEY\" codeSystem=\"1.2.3.4.5\"><originalText>Errr....</originalText></something>"
				);
			CV cv = (CV)this.parser.Parse(ParseContextImpl.Create("CV", typeof(MockCharacters), SpecificationVersion.V02R02, null, null
				, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, null, false), node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual("BARNEY", cv.Value.CodeValue);
			Assert.AreEqual("1.2.3.4.5", cv.Value.CodeSystem);
			Assert.AreEqual("Errr....", cv.OriginalText, "original text");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidWithOriginalTextNoCodeSet()
		{
			XmlNode node = CreateNode("<something><originalText>Errr....</originalText></something>");
			// Adding to set used to fail on hashCode() call in OriginalTextWrapper
			CV cv = (CV)this.parser.Parse(ParseContextImpl.Create("CV", typeof(MockCharacters), SpecificationVersion.V02R02, null, null
				, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, CodingStrength.CWE, null, null, false), node, this.xmlResult
				);
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual("Errr....", cv.OriginalText, "original text");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidWithEmptyOriginalText()
		{
			XmlNode node = CreateNode("<something><originalText /></something>");
			CV cv = (CV)this.parser.Parse(ParseContextImpl.Create("CV", typeof(MockCharacters), SpecificationVersion.V02R02, null, null
				, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, CodingStrength.CWE, null, null, false), node, this.xmlResult
				);
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
			// need one of code or OT
			Assert.IsNull(cv.OriginalText, "no original text");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseTooManyChildNodes()
		{
			XmlNode node = CreateNode("<something>" + "<monkey/>" + "</something>");
			CV cv = (CV)this.parser.Parse(ParseContextImpl.Create("CV", typeof(MockCharacters), SpecificationVersion.V02R02, null, null
				, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, null, false), node, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
			// must provide code/codeSystem (monkey element effectively ignored; this is what it seems to have always been doing)
			Assert.IsNull(cv.Value, "empty node with children returns null");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidEnumCodeButNoCodeSystem()
		{
			XmlNode node = CreateNode("<something code=\"FRED\" />");
			CV cv = (CV)this.parser.Parse(ParseContextImpl.Create("CV", typeof(MockCharacters), SpecificationVersion.V02R02, null, null
				, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, null, false), node, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid(), "valid");
			Assert.AreEqual(MockEnum.FRED, cv.Value, "enum found properly");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidEnumCodeWithCodeSystem()
		{
			XmlNode node = CreateNode("<something code=\"FRED\" codeSystem=\"1.2.3.4.5\"/>");
			CV cv = (CV)this.parser.Parse(ParseContextImpl.Create("CV", typeof(MockCharacters), SpecificationVersion.V02R02, null, null
				, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, null, false), node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid(), "valid");
			Assert.AreEqual(MockEnum.FRED, cv.Value, "enum found properly");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidCodeWithMaxCodeValueCeRx()
		{
			XmlNode node = CreateNode("<something code=\"12345678901234567890\" codeSystem=\"1.2.3.4.5\"/>");
			CV cv = (CV)this.parser.Parse(ParseContextImpl.Create("CV", typeof(MockCharacters), SpecificationVersion.V01R04_3, null, 
				null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, null, false), node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid(), "valid");
			Assert.AreEqual(MockEnum.CERX_MAX, cv.Value, "enum found properly");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidCodeWithMaxPlus1CodeValueCeRx()
		{
			XmlNode node = CreateNode("<something code=\"123456789012345678901\" codeSystem=\"1.2.3.4.5\"/>");
			CV cv = (CV)this.parser.Parse(ParseContextImpl.Create("CV", typeof(MockCharacters), SpecificationVersion.V01R04_3, null, 
				null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, null, false), node, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid(), "valid");
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
			Assert.AreEqual(MockEnum.CERX_MAX_PLUS_1, cv.Value, "enum found properly");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidCodeWithMaxCodeValueMr2009()
		{
			XmlNode node = CreateNode("<something code=\"12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890\" codeSystem=\"1.2.3.4.5\"/>"
				);
			CV cv = (CV)this.parser.Parse(ParseContextImpl.Create("CV", typeof(MockCharacters), SpecificationVersion.R02_04_02, null, 
				null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, null, false), node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid(), "valid");
			Assert.AreEqual(MockEnum.MR2009_MAX, cv.Value, "enum found properly");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidCodeWithMaxPlus1CodeValueMr2009()
		{
			XmlNode node = CreateNode("<something code=\"123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901\" codeSystem=\"1.2.3.4.5\"/>"
				);
			CV cv = (CV)this.parser.Parse(ParseContextImpl.Create("CV", typeof(MockCharacters), SpecificationVersion.R02_04_02, null, 
				null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, null, false), node, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid(), "valid");
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
			Assert.AreEqual(MockEnum.MR2009_MAX_PLUS_1, cv.Value, "enum found properly");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidEnumCodeWithCodeSystemButUnallowedAttribute()
		{
			XmlNode node = CreateNode("<something code=\"FRED\" codeSystem=\"1.2.3.4.5\" displayName=\"unallowed\"/>");
			CV cv = (CV)this.parser.Parse(ParseContextImpl.Create("CV", typeof(MockCharacters), SpecificationVersion.V02R02, null, null
				, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, null, false), node, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid(), "valid");
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
			Assert.AreEqual(MockEnum.FRED, cv.Value, "enum found properly");
			Assert.AreEqual("unallowed", cv.DisplayName, "display name");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalidEnumCode()
		{
			XmlNode node = CreateNode("<something code=\"ER\" codeSystem=\"1.2.3\"/>");
			CV cv = (CV)this.parser.Parse(ParseContextImpl.Create("CV", typeof(MockCharacters), SpecificationVersion.V02R02, null, null
				, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, null, false), node, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count, "error message count");
			// invalid code
			Assert.IsNull(cv.Value.CodeValue, "bogus enum not found");
			Assert.AreEqual("The code, \"ER\", in element <something> is not a valid value for domain type \"MockCharacters\"", this.
				xmlResult.GetHl7Errors()[0].GetMessage(), "error message");
			Assert.AreEqual(Hl7ErrorCode.VALUE_NOT_IN_CODE_SYSTEM, this.xmlResult.GetHl7Errors()[0].GetHl7ErrorCode(), "error type");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidTranslation()
		{
			XmlNode node = CreateNode("<something code=\"BARNEY\" codeSystem=\"1.2.3.4.5\"><translation code=\"FRED\" codeSystem=\"1.2.3.4.5\" /></something>"
				);
			CD cd = (CD)this.parser.Parse(ParseContextImpl.Create("CD", typeof(MockCharacters), SpecificationVersion.V02R02, null, null
				, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, null, false), node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.IsNotNull(cd.Value, "main enum found");
			Assert.IsFalse(cd.Translations.IsEmpty(), "translation enum found");
			Assert.IsTrue(cd.Translations.Count == 1, "translation enum found");
			Assert.AreEqual(0, this.xmlResult.GetHl7Errors().Count, "error message count");
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
			CD cd = (CD)this.parser.Parse(ParseContextImpl.Create("CD", typeof(MockCharacters), SpecificationVersion.V02R02, null, null
				, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, null, false), node, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(8, this.xmlResult.GetHl7Errors().Count, "error message count");
			Assert.IsNotNull(cd.Value, "main enum found");
			Assert.AreEqual("BARNEY", cd.Value.CodeValue, "main code");
			Assert.AreEqual(1, cd.Translations.Count, "translation enum not found");
			Assert.IsTrue(this.xmlResult.GetHl7Errors()[0].GetMessage().StartsWith("CD should not include the 'codeSystemName' property."
				), "error message");
			Assert.IsTrue(this.xmlResult.GetHl7Errors()[1].GetMessage().StartsWith("CD should not include the 'codeSystemVersion' property."
				), "error message");
			Assert.IsTrue(this.xmlResult.GetHl7Errors()[2].GetMessage().StartsWith("CD should not include the 'qualifier' property.")
				, "error message");
			Assert.IsTrue(this.xmlResult.GetHl7Errors()[3].GetMessage().StartsWith("(translation level) Translation may not contain other translations."
				), "error message");
			Assert.IsTrue(this.xmlResult.GetHl7Errors()[4].GetMessage().StartsWith("(translation level) Translation may not contain a NullFlavor."
				), "error message");
			Assert.IsTrue(this.xmlResult.GetHl7Errors()[5].GetMessage().StartsWith("(translation level) Translation may not contain originalText."
				), "error message");
			Assert.IsTrue(this.xmlResult.GetHl7Errors()[6].GetMessage().StartsWith("(translation level) Translation may not contain displayName."
				), "error message");
			Assert.IsTrue(this.xmlResult.GetHl7Errors()[7].GetMessage().StartsWith("(translation level) Code and codeSystem properties must be provided."
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
			CD cd = (CD)this.parser.Parse(ParseContextImpl.Create("CD", typeof(MockCharacters), SpecificationVersion.V02R02, null, null
				, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, null, false), node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.IsNotNull(cd.Value, "main enum found");
			Assert.IsFalse(cd.Translations.IsEmpty(), "translation enums found");
			Assert.IsTrue(cd.Translations.Count == 10, "translation enums found");
			Assert.AreEqual(0, this.xmlResult.GetHl7Errors().Count, "error message count");
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
			CD cd = (CD)this.parser.Parse(ParseContextImpl.Create("CD", typeof(MockCharacters), SpecificationVersion.V02R02, null, null
				, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, null, false), node, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
			Assert.IsNotNull(cd.Value, "main enum found");
			Assert.IsFalse(cd.Translations.IsEmpty(), "translation enums found");
			Assert.IsTrue(cd.Translations.Count == 11, "translation enums found");
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count, "error message count");
			Assert.AreEqual("BARNEY", cd.Value.CodeValue, "main code");
			Assert.AreEqual("FRED", cd.Translations[0].Value.CodeValue, "translation");
			Assert.AreEqual("BETTY", cd.Translations[10].Value.CodeValue, "translation");
			Assert.IsTrue(this.xmlResult.GetHl7Errors()[0].GetMessage().StartsWith("A maximum of 10 translations are allowed."), "error message"
				);
			Assert.AreEqual(Hl7ErrorCode.DATA_TYPE_ERROR, this.xmlResult.GetHl7Errors()[0].GetHl7ErrorCode(), "error type");
		}
	}
}
