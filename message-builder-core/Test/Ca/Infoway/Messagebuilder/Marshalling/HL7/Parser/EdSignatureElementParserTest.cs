using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[TestFixture]
	public class EdSignatureElementParserTest : CeRxDomainValueTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNullNode()
		{
			XmlNode node = CreateNode("<something nullFlavor=\"NI\" />");
			ED<string> ed = (ED<string>)new EdSignatureElementParser().Parse(CreateEdContext(), node, null);
			Assert.IsNull(ed.Value, "signature is null");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION, ed.NullFlavor, "null flavor");
		}

		private ParseContext CreateEdContext()
		{
			return ParserContextImpl.Create("ED.SIGNATURE", typeof(string), SpecificationVersion.V02R02, null, null, null);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseEmptyNode()
		{
			TestInvalidNode(CreateNode("<something/>"));
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseTextNode()
		{
			TestInvalidNode(CreateNode("<something>signatureText</something>"));
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseWrongChildNode()
		{
			TestInvalidNode(CreateNode("<something>" + "  <notSignature></notSignature>" + "</something>"));
		}

		/// <exception cref="System.Exception"></exception>
		public virtual void TestInvalidNode(XmlNode invalidNode)
		{
			XmlToModelResult xmlResult = new XmlToModelResult();
			string parseResult = (string)new EdSignatureElementParser().Parse(CreateEdContext(), invalidNode, xmlResult).BareValue;
			Assert.IsNull(parseResult, "parse result");
			Assert.AreEqual(1, xmlResult.GetHl7Errors().Count, "HL7 error count");
			Hl7Error hl7Error = xmlResult.GetHl7Errors()[0];
			Assert.AreEqual("Expected ED.SIGNATURE node to have a child element named signature", hl7Error.GetMessage(), "error message"
				);
			Assert.AreEqual(Hl7ErrorCode.DATA_TYPE_ERROR, hl7Error.GetHl7ErrorCode(), "error message code");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidNode()
		{
			XmlNode node = CreateNode("<something>" + "  <signature>signatureText</signature>" + "</something>");
			Assert.AreEqual("signatureText", new EdSignatureElementParser().Parse(CreateEdContext(), node, null).BareValue, "signature"
				);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseEmptySignatureNode()
		{
			XmlNode node = CreateNode("<something>" + "  <signature></signature>" + "</something>");
			Assert.AreEqual(string.Empty, new EdSignatureElementParser().Parse(CreateEdContext(), node, null).BareValue, "signature");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseEmptySignatureNodeAgain()
		{
			XmlNode node = CreateNode("<something>" + "  <signature/>" + "</something>");
			Assert.AreEqual(string.Empty, new EdSignatureElementParser().Parse(CreateEdContext(), node, null).BareValue, "signature");
		}
	}
}
