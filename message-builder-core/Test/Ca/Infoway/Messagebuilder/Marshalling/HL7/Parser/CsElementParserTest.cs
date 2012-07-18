using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Terminology;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[TestFixture]
	public class CsElementParserTest : MarshallingTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[NUnit.Framework.SetUp]
		public override void SetUp()
		{
			base.SetUp();
			CodeResolverRegistry.RegisterResolver(typeof(MockEnum), new EnumBasedCodeResolver(typeof(MockEnum)));
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNullNode()
		{
			XmlNode node = CreateNode("<something nullFlavor=\"NI\"/>");
			CS acknowledgementCondition = (CS)new CsElementParser().Parse(ParserContextImpl.Create("CS", typeof(MockCode), SpecificationVersion
				.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL), node, this.xmlResult);
			Assert.IsTrue(acknowledgementCondition.HasNullFlavor());
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION, acknowledgementCondition.NullFlavor
				);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseContainsCodeSystem()
		{
			XmlNode node = CreateNode("<something code=\"ER\" codeSystem=\"1.2.3.4\" />");
			CS cs = (CS)new CsElementParser().Parse(ParserContextImpl.Create("CS", typeof(MockCode), SpecificationVersion.V02R02, null
				, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL), node, this.xmlResult);
			Assert.IsNotNull(cs, "cs");
			Assert.IsNotNull(cs.Value, "code");
			Assert.IsFalse(this.xmlResult.IsValid(), "valid");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseContainsDisplayName()
		{
			XmlNode node = CreateNode("<something code=\"ER\" displayName=\"Error\" />");
			CS cs = (CS)new CsElementParser().Parse(ParserContextImpl.Create("CS", typeof(MockCode), SpecificationVersion.V02R02, null
				, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL), node, this.xmlResult);
			Assert.IsNotNull(cs, "cs");
			Assert.IsNotNull(cs.Value, "code");
			Assert.IsFalse(this.xmlResult.IsValid(), "valid");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseContainsCodeSystemName()
		{
			XmlNode node = CreateNode("<something code=\"ER\" codeSystemName=\"My code system\" />");
			CS cs = (CS)new CsElementParser().Parse(ParserContextImpl.Create("CS", typeof(MockCode), SpecificationVersion.V02R02, null
				, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL), node, this.xmlResult);
			Assert.IsNotNull(cs, "cs");
			Assert.IsNotNull(cs.Value, "code");
			Assert.IsFalse(this.xmlResult.IsValid(), "valid");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseContainsOriginalText()
		{
			XmlNode node = CreateNode("<something code=\"ER\"><originalText>My original text</originalText></something>");
			CS cs = (CS)new CsElementParser().Parse(ParserContextImpl.Create("CS", typeof(MockCode), SpecificationVersion.V02R02, null
				, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL), node, this.xmlResult);
			Assert.IsNotNull(cs, "cs");
			Assert.IsNotNull(cs.Value, "code");
			Assert.IsFalse(this.xmlResult.IsValid(), "valid");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseEmptyNode()
		{
			XmlNode node = CreateNode("<something/>");
			CS cs = (CS)new CsElementParser().Parse(ParserContextImpl.Create("CS", typeof(MockCode), SpecificationVersion.V02R02, null
				, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL), node, this.xmlResult);
			Assert.IsNull(cs.Value, "empty node returns null");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNoCodeAttributeNode()
		{
			XmlNode node = CreateNode("<something notvalue=\"\" />");
			CS cs = (CS)new CsElementParser().Parse(ParserContextImpl.Create("CS", typeof(MockCode), SpecificationVersion.V02R02, null
				, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL), node, this.xmlResult);
			Assert.IsNull(cs.Value, "node with no code attribute returns null");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValid()
		{
			XmlNode node = CreateNode("<something code=\"ER\" />");
			CS cs = (CS)new CsElementParser().Parse(ParserContextImpl.Create("CS", typeof(MockCode), SpecificationVersion.V02R02, null
				, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL), node, null);
			Assert.AreEqual("ER", cs.Value.CodeValue, "node with code attribute returns value");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidEnumCode()
		{
			XmlNode node = CreateNode("<something code=\"FRED\" />");
			XmlToModelResult result = new XmlToModelResult();
			CS cs = (CS)new CsElementParser().Parse(ParserContextImpl.Create("CS", typeof(MockEnum), SpecificationVersion.V02R02, null
				, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL), node, result);
			Assert.AreEqual(MockEnum.FRED, cs.Value, "enum found properly");
			Assert.AreEqual(0, result.GetHl7Errors().Count, "error message count");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalidEnumCode()
		{
			XmlNode node = CreateNode("<something code=\"ER\" />");
			CS cs = (CS)new CsElementParser().Parse(ParserContextImpl.Create("CS", typeof(MockEnum), SpecificationVersion.V02R02, null
				, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL), node, this.xmlResult);
			Assert.IsNull(cs.Value, "bogus enum not found");
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count, "error message count");
			Assert.AreEqual("The code, \"ER\", in element <something> is not a valid value for domain type \"MockEnum\"", this.xmlResult
				.GetHl7Errors()[0].GetMessage(), "error message");
			Assert.AreEqual(Hl7ErrorCode.VALUE_NOT_IN_CODE_SYSTEM, this.xmlResult.GetHl7Errors()[0].GetHl7ErrorCode(), "error type");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseTooManyChildNodes()
		{
			XmlNode node = CreateNode("<something>" + "<monkey/>" + "</something>");
			CS cs = (CS)new CsElementParser().Parse(ParserContextImpl.Create("CS", typeof(MockCode), SpecificationVersion.V02R02, null
				, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL), node, this.xmlResult);
			Assert.IsNull(cs.Value, "empty node with children returns null");
		}
	}
}
