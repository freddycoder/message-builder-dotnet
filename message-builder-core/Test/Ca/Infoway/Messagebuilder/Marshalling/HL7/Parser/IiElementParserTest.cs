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
	public class IiElementParserTest : CeRxDomainValueTestCase
	{
		private XmlToModelResult result;

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
			II ii = (II)new IiElementParser().Parse(CreateContext("II.BUS"), node, this.result);
			Assert.IsNotNull(ii, "null result");
			Assert.IsTrue(ii.HasNullFlavor(), "has null flavor");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION, ii.NullFlavor, "NI null flavor"
				);
		}

		private ParseContext CreateContext(string type)
		{
			return CreateContext(type, SpecificationVersion.V02R02);
		}

		private ParseContext CreateContext(string type, SpecificationVersion version)
		{
			return ParserContextImpl.Create(type, null, version, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseEmptyNode()
		{
			XmlNode node = CreateNode("<something/>");
			new IiElementParser().Parse(CreateContext("II.BUS"), node, this.result);
			Assert.IsFalse(result.IsValid(), "result");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNoValueAttributeNode()
		{
			XmlNode node = CreateNode("<something notvalue=\"\" />");
			new IiElementParser().Parse(CreateContext("II.BUS"), node, this.result);
			Assert.IsFalse(result.IsValid(), "result");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidOneAttribute()
		{
			XmlNode node = CreateNode("<something root=\"rootValue\" />");
			II ii = (II)new IiElementParser().Parse(CreateContext("II.BUS"), node, this.result);
			AssertResultAsExpected(ii.Value, "rootValue", null);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidTwoAttributes()
		{
			XmlNode node = CreateNode("<something root=\"rootValue\" extension=\"extensionValue\" />");
			II ii = (II)new IiElementParser().Parse(CreateContext("II.BUS"), node, this.result);
			AssertResultAsExpected(ii.Value, "rootValue", "extensionValue");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidTwoAttributesAsId()
		{
			XmlNode node = CreateNode("<something root=\"rootValue\" extension=\"extensionValue\" />");
			II ii = (II)new IiElementParser().Parse(CreateContext("II.OID"), node, this.result);
			AssertResultAsExpected(ii.Value, "rootValue", "extensionValue");
			Assert.AreEqual(typeof(Identifier), ii.Value.GetType(), "type");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidTwoAttributesDifferentOrder()
		{
			XmlNode node = CreateNode("<something extension=\"extensionValue\"  root=\"rootValue\" />");
			II ii = (II)new IiElementParser().Parse(CreateContext("II.BUS"), node, this.result);
			AssertResultAsExpected(ii.Value, "rootValue", "extensionValue");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidTwoAttributesPlusExtra()
		{
			XmlNode node = CreateNode("<something extra=\"extraValue\" root=\"rootValue\" extension=\"extensionValue\" />");
			II ii = (II)new IiElementParser().Parse(CreateContext("II.BUS"), node, this.result);
			AssertResultAsExpected(ii.Value, "rootValue", "extensionValue");
		}

		/// <exception cref="System.Exception"></exception>
		[Ignore]
		[Test]
		public virtual void TestParseInvalidMissingSpecializationType()
		{
			// TM/BM - decided that validating for SpecializationType for the II case caused CHI and users more grief than benefit
			XmlNode node = CreateNode("<something root=\"rootValue\" extension=\"extensionValue\" />");
			II ii = (II)new IiElementParser().Parse(CreateContext("II"), node, this.result);
			AssertResultAsExpected(ii.Value, "rootValue", "extensionValue");
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(Hl7ErrorCode.MANDATORY_FIELD_NOT_PROVIDED, this.result.GetHl7Errors()[0].GetHl7ErrorCode());
			Assert.IsTrue(this.result.GetHl7Errors()[0].GetMessage().Contains("specializationType"));
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidMissingSpecializationTypeForCeRx()
		{
			XmlNode node = CreateNode("<something root=\"rootValue\" extension=\"extensionValue\" />");
			ParseContext context = CreateContext("II", SpecificationVersion.V01R04_3);
			II ii = (II)new IiElementParser().Parse(context, node, this.result);
			AssertResultAsExpected(ii.Value, "rootValue", "extensionValue");
			Assert.IsTrue(this.result.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidMissingSpecializationTypeForAB()
		{
			XmlNode node = CreateNode("<something root=\"rootValue\" extension=\"extensionValue\" />");
			ParseContext context = CreateContext("II", SpecificationVersion.V02R02_AB);
			II ii = (II)new IiElementParser().Parse(context, node, this.result);
			AssertResultAsExpected(ii.Value, "rootValue", "extensionValue");
			Assert.IsTrue(this.result.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidSpecializationType()
		{
			XmlNode node = CreateNode("<something root=\"1.2.3.4\" extension=\"extensionValue\" specializationType=\"II.BUS\" use=\"BUS\" />"
				);
			II ii = (II)new IiElementParser().Parse(CreateContext("II"), node, this.result);
			AssertResultAsExpected(ii.Value, "1.2.3.4", "extensionValue");
			Assert.IsTrue(this.result.IsValid());
		}

		private void AssertResultAsExpected(Identifier result, string rootValue, string extensionValue)
		{
			Assert.IsNotNull(result, "populated result returned");
			if (rootValue == null)
			{
				Assert.IsNull(result.Root, "null root");
			}
			else
			{
				Assert.AreEqual(rootValue, result.Root, "root");
			}
			if (extensionValue == null)
			{
				Assert.IsNull(result.Extension, "null extension");
			}
			else
			{
				Assert.AreEqual(extensionValue, result.Extension, "extension");
			}
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestIsOid()
		{
			AssertOid("1.2.3");
			AssertNotOid("1.2.3.");
			AssertNotOid("1.2.3..4");
			AssertNotOid(".2.3.4");
			AssertOid("1.22.33.456");
			AssertOid("1.22.3.456.333.23231.123");
			AssertOid("1.22.3.456.333.23231.0");
		}

		private void AssertOid(string oid)
		{
			Assert.IsTrue(new IiElementParser().IsOid(oid), oid);
		}

		private void AssertNotOid(string oid)
		{
			Assert.IsFalse(new IiElementParser().IsOid(oid), oid);
		}
	}
}
