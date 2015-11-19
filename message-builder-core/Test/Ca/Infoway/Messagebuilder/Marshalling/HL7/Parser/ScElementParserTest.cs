using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Resolver;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[TestFixture]
	public class ScElementParserTest : CeRxDomainValueTestCase
	{
		private static string EMPTY_STRING = string.Empty;

		/// <exception cref="System.Exception"></exception>
		[NUnit.Framework.SetUp]
		public override void SetUp()
		{
			base.SetUp();
			CodeResolverRegistry.RegisterResolver(typeof(MockCharacters), new EnumBasedCodeResolver(typeof(MockEnum)));
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNullNode()
		{
			XmlNode node = CreateNode("<something nullFlavor=\"NI\" />");
			SC<Code> sc = (SC<Code>)new ScElementParser().Parse(CreateContext(), node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.IsNull(sc.Value, "null returned");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION, sc.NullFlavor, "null flavor");
		}

		private ParseContext CreateContext()
		{
			return ParseContextImpl.Create("SC", typeof(CodedString<Code>), SpecificationVersion.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.POPULATED, null, null, false);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseEmptyNode()
		{
			XmlNode node = CreateNode("<something/>");
			CodedString<Code> result = (CodedString<Code>)new ScElementParser().Parse(null, node, this.xmlResult).BareValue;
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
			Assert.AreEqual("SC datatypes must have a string value (<something/>)", this.xmlResult.GetHl7Errors()[0].GetMessage(), "proper error reported"
				);
			Assert.AreEqual(EMPTY_STRING, result.Value, "empty string returned");
			Assert.AreEqual(null, result.Code, "null code");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseTextNode()
		{
			XmlNode node = CreateNode("<something>text value</something>");
			CodedString<Code> result = (CodedString<Code>)new ScElementParser().Parse(null, node, this.xmlResult).BareValue;
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual("text value", result.Value, "proper text returned");
			Assert.AreEqual(null, result.Code, "null code");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseTextNodeWithAttributes()
		{
			XmlNode node = CreateNode("<something representation=\"TXT\" mediaType=\"text/plain\">text value</something>");
			CodedString<Code> result = (CodedString<Code>)new ScElementParser().Parse(null, node, this.xmlResult).BareValue;
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual("text value", result.Value, "proper text returned");
			Assert.AreEqual(null, result.Code, "null code");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseTextNodeWithCodeAttributesSomeErrors()
		{
			XmlNode node = CreateNode("<something representation=\"TXT\" mediaType=\"text/plain\" code=\"AB\">text value</something>"
				);
			CodedString<Code> result = (CodedString<Code>)new ScElementParser().Parse(ParseContextImpl.Create("SC", new CodedString<State
				>(null, null).GetType(), SpecificationVersion.V02R02, null, null, null, null, null, false), node, this.xmlResult).BareValue;
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
			Assert.AreEqual("For SC datatypes, if code or code system is provided then the other value must also be provided (<something code=\"AB\" mediaType=\"text/plain\" representation=\"TXT\">)"
				, this.xmlResult.GetHl7Errors()[0].GetMessage(), "proper error reported");
			Assert.AreEqual("text value", result.Value, "proper text returned");
			Assert.AreEqual(null, result.Code, "null code");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseTextNodeWithCodeAttributes()
		{
			ParseContext context = ParseContextImpl.Create("SC", typeof(MockCharacters), SpecificationVersion.V02R02, null, null, null
				, null, null, false);
			XmlNode node = CreateNode("<something code=\"FRED\" codeSystem=\"1.2.3.4.5\" displayName=\"some text\" codeSystemName=\"cs name\" codeSystemVersion=\"cs version\">text value</something>"
				);
			CodedString<Code> result = (CodedString<Code>)new ScElementParser().Parse(context, node, this.xmlResult).BareValue;
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual(MockEnum.FRED, result.Code);
			Assert.AreEqual("cs name", result.CodeSystemName);
			Assert.AreEqual("cs version", result.CodeSystemVersion);
			Assert.AreEqual("some text", result.DisplayName);
			Assert.AreEqual("text value", result.Value);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseTooManyChildNodes()
		{
			XmlNode node = CreateNode("<something>" + "<monkey/>" + "<shines/>" + "</something>");
			new ScElementParser().Parse(null, node, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(2, this.xmlResult.GetHl7Errors().Count);
			Assert.AreEqual("Expected SC node to have at most one child", this.xmlResult.GetHl7Errors()[0].GetMessage(), "proper error reported"
				);
			Assert.AreEqual("SC datatypes must have a string value (<something>)", this.xmlResult.GetHl7Errors()[1].GetMessage(), "proper error reported"
				);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNotATextNode()
		{
			XmlNode node = CreateNode("<something>" + "<monkey/>" + "</something>");
			new ScElementParser().Parse(null, node, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(2, this.xmlResult.GetHl7Errors().Count);
			Assert.AreEqual("Expected SC node to have a text node", this.xmlResult.GetHl7Errors()[0].GetMessage(), "proper error reported"
				);
			Assert.AreEqual("SC datatypes must have a string value (<something>)", this.xmlResult.GetHl7Errors()[1].GetMessage(), "proper error reported"
				);
		}
	}
}
