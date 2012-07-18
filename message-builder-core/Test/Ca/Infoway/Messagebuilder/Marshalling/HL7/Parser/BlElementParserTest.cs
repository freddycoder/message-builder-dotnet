using System;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[TestFixture]
	public class BlElementParserTest : CeRxDomainValueTestCase
	{
		private ParseContext context;

		private XmlToModelResult result;

		private BlElementParser parser;

		/// <exception cref="System.Exception"></exception>
		[NUnit.Framework.SetUp]
		public override void SetUp()
		{
			base.SetUp();
			this.context = ParserContextImpl.Create("BL", typeof(Boolean?), SpecificationVersion.V02R02, null, null, null);
			this.result = new XmlToModelResult();
			this.parser = new BlElementParser();
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseEmptyNode()
		{
			XmlNode node = CreateNode("<something/>");
			Assert.IsNull(Process(node), "null returned");
			Assert.IsFalse(this.result.IsValid(), "result");
		}

		/// <exception cref="System.Exception"></exception>
		private Boolean? Process(XmlNode node)
		{
			return (Boolean?)this.parser.Parse(this.context, node, this.result).BareValue;
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNullFlavorNode()
		{
			XmlNode node = CreateNode("<something nullFlavor=\"NI\"/>");
			Assert.IsNull(Process(node), "null returned");
			node = CreateNode("<something nullFlavor=\"NI\" value=\"true\"/>");
			Assert.IsNull(Process(node), "null returned even though true was specified");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNoValueAttributeNode()
		{
			XmlNode node = CreateNode("<something notvalue=\"\" />");
			Assert.IsNull(Process(node), "null returned");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueAttributeTrue()
		{
			XmlNode node = CreateNode("<something value=\"true\" />");
			Assert.AreEqual(true, Process(node), "correct value returned");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueAttributeFalse()
		{
			XmlNode node = CreateNode("<something value=\"false\" />");
			Assert.AreEqual(false, Process(node), "correct value returned");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueWrongCase()
		{
			XmlNode node = CreateNode("<something value=\"False\" />");
			Boolean? b = Process(node);
			Assert.AreEqual(false, b, "correct value returned");
			Assert.IsFalse(this.result.IsValid(), "valid");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueAttributeTruePlusExtraAttribute()
		{
			XmlNode node = CreateNode("<something extra=\"extra\" value=\"true\" />");
			Assert.AreEqual(true, Process(node), "correct value returned");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalidValueAttribute()
		{
			XmlNode node = CreateNode("<something value=\"19990355\" />");
			Process(node);
			Assert.IsFalse(this.result.IsValid(), "error");
		}
	}
}
