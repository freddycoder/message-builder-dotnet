using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2;
using Ca.Infoway.Messagebuilder.Platform;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2
{
	[TestFixture]
	public class IiR2ElementParserTest : CeRxDomainValueTestCase
	{
		private XmlToModelResult result;

		private static readonly IiValidationUtils II_VALIDATION_UTILS = new IiValidationUtils();

		/// <exception cref="System.Exception"></exception>
		[NUnit.Framework.SetUp]
		public override void SetUp()
		{
			base.SetUp();
			this.result = new XmlToModelResult();
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNullNode()
		{
			XmlNode node = CreateNode("<something nullFlavor=\"NI\" />");
			II ii = (II)new IiR2ElementParser().Parse(CreateContext("II.BUS"), node, this.result);
			Assert.IsNotNull(ii, "null result");
			Assert.IsTrue(ii.HasNullFlavor(), "has null flavor");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION, ii.NullFlavor, "NI null flavor"
				);
			Assert.IsTrue(this.result.IsValid());
		}

		private ParseContext CreateContext(string type)
		{
			return CreateContext(type, SpecificationVersion.V02R02);
		}

		private ParseContext CreateContext(string type, SpecificationVersion version)
		{
			return ParseContextImpl.Create(type, null, version, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, 
				null, null, false);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseEmptyNode()
		{
			// error should be: root is mandatory 
			XmlNode node = CreateNode("<something/>");
			new IiR2ElementParser().Parse(CreateContext("II"), node, this.result);
			Assert.IsFalse(result.IsValid(), "result");
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNoValueAttributeNode()
		{
			// error should be: root is mandatory 
			XmlNode node = CreateNode("<something notvalue=\"\" />");
			new IiR2ElementParser().Parse(CreateContext("II"), node, this.result);
			Assert.IsFalse(result.IsValid(), "result");
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidOneAttribute()
		{
			UUID uuid = UUID.RandomUUID();
			XmlNode node = CreateNode("<something root=\"" + uuid.ToString() + "\" />");
			II ii = (II)new IiR2ElementParser().Parse(CreateContext("II"), node, this.result);
			AssertResultAsExpected(ii.Value, uuid.ToString(), null, null, null);
			Assert.IsTrue(this.result.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidIi()
		{
			XmlNode node = CreateNode("<something root=\"1.222.333\" extension=\"extensionValue\" assigningAuthorityName=\"aaName\" displayable=\"d_true\" />"
				);
			II ii = (II)new IiR2ElementParser().Parse(CreateContext("II"), node, this.result);
			AssertResultAsExpected(ii.Value, "1.222.333", "extensionValue", "aaName", "d_true");
			Assert.IsTrue(this.result.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidIiAsUuid()
		{
			UUID uuid = UUID.RandomUUID();
			XmlNode node = CreateNode("<something root=\"" + uuid.ToString() + "\" />");
			II ii = (II)new IiR2ElementParser().Parse(CreateContext("II"), node, this.result);
			AssertResultAsExpected(ii.Value, uuid.ToString(), null, null, null);
			Assert.IsTrue(this.result.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalidIiBadUuid()
		{
			UUID uuid = UUID.RandomUUID();
			XmlNode node = CreateNode("<something root=\"" + uuid.ToString() + "_garbage\" />");
			II ii = (II)new IiR2ElementParser().Parse(CreateContext("II"), node, this.result);
			AssertResultAsExpected(ii.Value, uuid.ToString() + "_garbage", null);
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			Assert.AreEqual(Hl7ErrorCode.DATA_TYPE_ERROR, this.result.GetHl7Errors()[0].GetHl7ErrorCode());
			Assert.IsTrue(this.result.GetHl7Errors()[0].GetMessage().Contains("must conform to be either a UUID, RUID, or OID."));
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidIiOid()
		{
			XmlNode node = CreateNode("<something root=\"111.222.333\" />");
			II ii = (II)new IiR2ElementParser().Parse(CreateContext("II"), node, this.result);
			AssertResultAsExpected(ii.Value, "111.222.333", null);
			Assert.AreEqual(typeof(Identifier), ii.Value.GetType(), "type");
			Assert.IsTrue(this.result.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalidIiOid()
		{
			XmlNode node = CreateNode("<something root=\"345.333.444\" />");
			II ii = (II)new IiR2ElementParser().Parse(CreateContext("II"), node, this.result);
			AssertResultAsExpected(ii.Value, "345.333.444", null);
			Assert.AreEqual(typeof(Identifier), ii.Value.GetType(), "type");
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			Assert.AreEqual(Hl7ErrorCode.DATA_TYPE_ERROR, this.result.GetHl7Errors()[0].GetHl7ErrorCode());
			Assert.IsTrue(this.result.GetHl7Errors()[0].GetMessage().Contains("must conform to be either a UUID, RUID, or OID."));
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidMultipleAttributesDifferentOrder()
		{
			XmlNode node = CreateNode("<something displayable=\"d_false\" extension=\"extensionValue\"  root=\"1.2.2.1\" />");
			II ii = (II)new IiR2ElementParser().Parse(CreateContext("II"), node, this.result);
			AssertResultAsExpected(ii.Value, "1.2.2.1", "extensionValue", null, "d_false");
			Assert.IsTrue(this.result.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidMultipleAttributesPlusExtra()
		{
			XmlNode node = CreateNode("<something extra=\"extraValue\" root=\"2.1.2.1\" extension=\"extensionValue\" displayable=\"true\" />"
				);
			II ii = (II)new IiR2ElementParser().Parse(CreateContext("II.PUBLIC"), node, this.result);
			AssertResultAsExpected(ii.Value, "2.1.2.1", "extensionValue", null, "true");
			Assert.IsTrue(this.result.IsValid());
		}

		private void AssertResultAsExpected(Identifier result, string rootValue, string extensionValue)
		{
			AssertResultAsExpected(result, rootValue, extensionValue, null, null);
		}

		private void AssertResultAsExpected(Identifier result, string rootValue, string extensionValue, string assigningAuthorityName
			, string displayable)
		{
			Assert.IsNotNull(result, "populated result returned");
			Assert.AreEqual(rootValue, result.Root, "root");
			Assert.AreEqual(extensionValue, result.Extension, "extension");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestIsOid()
		{
			AssertOid("1.2.3");
			AssertNotOid("1.2.3.");
			AssertNotOid("1.2.3..4");
			AssertOid("0.2.3");
			AssertOid("01.2.3");
			AssertOid("1.2.3");
			AssertOid("2.2.3");
			AssertNotOid("3.2.3.4");
			AssertNotOid("4.2.3.4");
			AssertNotOid("5.2.3.4");
			AssertNotOid("6.2.3.4");
			AssertNotOid("7.2.3.4");
			AssertNotOid("8.2.3.4");
			AssertNotOid("9.2.3.4");
			AssertNotOid("91.2.3.4");
			AssertOid("1.22.33.456");
			AssertOid("1.22.3.456.333.23231.123");
			AssertOid("1.22.3.456.333.23231.0");
		}

		private void AssertOid(string oid)
		{
			Assert.IsTrue(II_VALIDATION_UTILS.IsOid(oid, true), oid);
		}

		private void AssertNotOid(string oid)
		{
			Assert.IsFalse(II_VALIDATION_UTILS.IsOid(oid, true), oid);
		}
	}
}
