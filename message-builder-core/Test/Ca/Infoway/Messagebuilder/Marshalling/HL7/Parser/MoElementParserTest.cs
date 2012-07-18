using System;
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
	public class MoElementParserTest : MarshallingTestCase
	{
		private XmlToModelResult result;

		/// <exception cref="System.Exception"></exception>
		[NUnit.Framework.SetUp]
		public override void SetUp()
		{
			this.result = new XmlToModelResult();
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNullNode()
		{
			XmlNode node = CreateNode("<something nullFlavor=\"NI\" />");
			MO mo = (MO)new MoElementParser().Parse(CreateContext(), node, null);
			Assert.IsNull(mo.Value, "null result");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION, mo.NullFlavor, "null flavor");
		}

		private ParseContext CreateContext()
		{
			return ParserContextImpl.Create("MO", typeof(Money), SpecificationVersion.NEWFOUNDLAND, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.POPULATED);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseEmptyNode()
		{
			XmlNode node = CreateNode("<something/>");
			new MoElementParser().Parse(null, node, result);
			Assert.IsFalse(result.IsValid(), "valid");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNoCurrencyAttributeNode()
		{
			XmlNode node = CreateNode("<something value=\"12.34\" notcurrency=\"CAD\" />");
			new MoElementParser().Parse(null, node, this.result);
			Assert.IsFalse(result.IsValid(), "result");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidTwoAttributes()
		{
			XmlNode node = CreateNode("<something value=\"12.00\" currency=\"CAD\" />");
			Money result = (Money)new MoElementParser().Parse(null, node, this.result).BareValue;
			AssertResultAsExpected(result, new BigDecimal("12.00"), Currency.CANADIAN_DOLLAR);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidTwoAttributesDifferentOrder()
		{
			XmlNode node = CreateNode("<something currency=\"CAD\" value=\"12.00\" />");
			Money result = (Money)new MoElementParser().Parse(null, node, this.result).BareValue;
			AssertResultAsExpected(result, new BigDecimal("12.00"), Currency.CANADIAN_DOLLAR);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidTwoAttributesPlusExtra()
		{
			XmlNode node = CreateNode("<something value=\"12.00\" currency=\"CAD\" something=\"monkey\" />");
			Money result = (Money)new MoElementParser().Parse(null, node, this.result).BareValue;
			AssertResultAsExpected(result, new BigDecimal("12.00"), Currency.CANADIAN_DOLLAR);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalidValue()
		{
			XmlNode node = CreateNode("<something value=\"12.00X\" currency=\"CAD\" />");
			try
			{
				new MoElementParser().Parse(null, node, this.result);
				Assert.Fail("expected exception");
			}
			catch (FormatException)
			{
			}
		}

		// expected
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalidCurrency()
		{
			XmlNode node = CreateNode("<something value=\"12.00\" currency=\"XXX\" />");
			new MoElementParser().Parse(null, node, this.result);
			Assert.IsFalse(result.IsValid(), "result");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseTooManyChildNodes()
		{
			XmlNode node = CreateNode("<something>" + "<monkey/>" + "</something>");
			try
			{
				new MoElementParser().Parse(new TrivialContext("MO"), node, this.result);
				Assert.Fail("expected exception");
			}
			catch (XmlToModelTransformationException e)
			{
				// expected
				Assert.AreEqual("Expected MO node to have no children", e.Message, "proper exception returned");
			}
		}

		private void AssertResultAsExpected(Money result, BigDecimal value, Currency currency)
		{
			Assert.IsNotNull(result, "populated result returned");
			Assert.AreEqual(value, result.Amount, "value");
			Assert.AreEqual(currency, result.Currency, "currency");
		}
	}
}
