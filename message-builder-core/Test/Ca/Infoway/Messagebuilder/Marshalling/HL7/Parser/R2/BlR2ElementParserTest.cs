using System;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2
{
	[TestFixture]
	public class BlR2ElementParserTest : CeRxDomainValueTestCase
	{
		private ParseContext contextBL;

		private ParseContext contextBN;

		private XmlToModelResult result;

		private BlR2ElementParser parser;

		/// <exception cref="System.Exception"></exception>
		[NUnit.Framework.SetUp]
		public override void SetUp()
		{
			base.SetUp();
			this.contextBL = ParseContextImpl.Create("BL", typeof(Boolean?), SpecificationVersion.V02R02, null, null, null, null, null
				, false);
			this.contextBN = ParseContextImpl.Create("BN", typeof(Boolean?), SpecificationVersion.R02_04_03, null, null, null, null, 
				null, false);
			this.result = new XmlToModelResult();
			this.parser = new BlR2ElementParser();
		}

		// BL tests
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseEmptyNodeBL()
		{
			XmlNode node = CreateNode("<something/>");
			Assert.IsNull(Process(node, true), "null returned");
			Assert.IsFalse(this.result.IsValid(), "result");
		}

		/// <exception cref="System.Exception"></exception>
		private Boolean? Process(XmlNode node, bool asBL)
		{
			return (Boolean?)this.parser.Parse(asBL ? this.contextBL : this.contextBN, node, this.result).BareValue;
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNullFlavorNodeBL()
		{
			XmlNode node = CreateNode("<something nullFlavor=\"NI\"/>");
			Assert.IsNull(Process(node, true), "null returned");
			Assert.IsTrue(this.result.IsValid(), "result");
			node = CreateNode("<something nullFlavor=\"NI\" value=\"true\"/>");
			Assert.IsNull(Process(node, true), "null returned even though true was specified");
			Assert.IsTrue(this.result.IsValid(), "result");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNoValueAttributeNodeBL()
		{
			XmlNode node = CreateNode("<something notvalue=\"\" />");
			Assert.IsNull(Process(node, true), "null returned");
			Assert.IsFalse(this.result.IsValid(), "result");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueAttributeTrueBL()
		{
			XmlNode node = CreateNode("<something value=\"true\" />");
			Assert.AreEqual(true, Process(node, true), "correct value returned");
			Assert.IsTrue(this.result.IsValid(), "result");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueAttributeFalseBL()
		{
			XmlNode node = CreateNode("<something value=\"false\" />");
			Assert.AreEqual(false, Process(node, true), "correct value returned");
			Assert.IsTrue(this.result.IsValid(), "result");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueWrongCaseBL()
		{
			XmlNode node = CreateNode("<something value=\"False\" />");
			Boolean? b = Process(node, true);
			Assert.IsFalse(this.result.IsValid(), "valid");
			Assert.AreEqual(false, b, "correct value returned");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueAttributeTruePlusExtraAttributeBL()
		{
			XmlNode node = CreateNode("<something extra=\"extra\" value=\"true\" />");
			Assert.AreEqual(true, Process(node, true), "correct value returned");
			Assert.IsTrue(this.result.IsValid(), "result");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalidValueAttributeBL()
		{
			XmlNode node = CreateNode("<something value=\"19990355\" />");
			Assert.IsNull(Process(node, true), "null returned");
			Assert.IsFalse(this.result.IsValid(), "error");
		}

		// BN tests
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseEmptyNodeBN()
		{
			XmlNode node = CreateNode("<something/>");
			Assert.IsNull(Process(node, false), "null returned");
			Assert.IsFalse(this.result.IsValid(), "result");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNullFlavorNodeBN()
		{
			XmlNode node = CreateNode("<something nullFlavor=\"NI\"/>");
			Assert.IsNull(Process(node, false), "null returned");
			Assert.IsFalse(this.result.IsValid(), "result");
			this.result.ClearErrors();
			node = CreateNode("<something nullFlavor=\"NI\" value=\"true\"/>");
			Assert.IsNull(Process(node, false), "null returned even though true was specified");
			Assert.IsFalse(this.result.IsValid(), "result");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNoValueAttributeNodeBN()
		{
			XmlNode node = CreateNode("<something notvalue=\"\" />");
			Assert.IsNull(Process(node, false), "null returned");
			Assert.IsFalse(this.result.IsValid(), "result");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueAttributeTrueBN()
		{
			XmlNode node = CreateNode("<something value=\"true\" />");
			Assert.AreEqual(true, Process(node, false), "correct value returned");
			Assert.IsTrue(this.result.IsValid(), "result");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueAttributeFalseBN()
		{
			XmlNode node = CreateNode("<something value=\"false\" />");
			Assert.AreEqual(false, Process(node, false), "correct value returned");
			Assert.IsTrue(this.result.IsValid(), "result");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueWrongCaseBN()
		{
			XmlNode node = CreateNode("<something value=\"False\" />");
			Boolean? b = Process(node, false);
			Assert.IsFalse(this.result.IsValid(), "valid");
			Assert.AreEqual(false, b, "correct value returned");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueAttributeTruePlusExtraAttributeBN()
		{
			XmlNode node = CreateNode("<something extra=\"extra\" value=\"true\" />");
			Assert.AreEqual(true, Process(node, false), "correct value returned");
			Assert.IsTrue(this.result.IsValid(), "result");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalidValueAttributeBN()
		{
			XmlNode node = CreateNode("<something value=\"19990355\" />");
			Assert.IsNull(Process(node, false), "null returned");
			Assert.IsFalse(this.result.IsValid(), "error");
		}
	}
}
