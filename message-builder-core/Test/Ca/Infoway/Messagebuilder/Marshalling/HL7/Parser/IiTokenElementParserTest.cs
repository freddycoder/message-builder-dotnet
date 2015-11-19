using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[TestFixture]
	public class IiTokenElementParserTest : CeRxDomainValueTestCase
	{
		private static readonly string ROOT_UUID = "1ee83ff1-08ab-4fe7-b573-ea777e9bad51";

		private AbstractSingleElementParser<Identifier> parser;

		private XmlToModelResult xmlResult;

		private ParseContext context;

		/// <exception cref="System.Exception"></exception>
		[NUnit.Framework.SetUp]
		public override void SetUp()
		{
			base.SetUp();
			this.parser = new IiElementParser();
			this.xmlResult = new XmlToModelResult();
			this.context = ParseContextImpl.Create("II.TOKEN", typeof(Identifier), SpecificationVersion.V02R02, null, null, null, null
				, null, false);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNullNode()
		{
			XmlNode node = CreateNode("<something nullFlavor=\"NI\" />");
			BareANY ii = this.parser.Parse(this.context, node, this.xmlResult);
			Assert.IsNull(ii.BareValue, "null result");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION, ii.NullFlavor, "null flavor");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseEmptyNode()
		{
			XmlNode node = CreateNode("<something/>");
			this.parser.Parse(this.context, node, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid(), "result");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValid()
		{
			XmlNode node = CreateNode("<something root=\"" + ROOT_UUID + "\" />");
			Identifier result = (Identifier)this.parser.Parse(this.context, node, this.xmlResult).BareValue;
			Assert.AreEqual(new Identifier(ROOT_UUID), result, "result");
			Assert.IsTrue(this.xmlResult.IsValid(), "error");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseDetectExtraAttribute()
		{
			XmlNode node = CreateNode("<something root=\"" + ROOT_UUID + "\" extension=\"lsdfjlsdjkf\" />");
			Identifier result = (Identifier)this.parser.Parse(this.context, node, this.xmlResult).BareValue;
			Assert.AreEqual(new Identifier(ROOT_UUID, "lsdfjlsdjkf"), result, "result");
			Assert.IsFalse(this.xmlResult.IsValid(), "error");
		}
	}
}
