using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Resolver.Configurator;
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
			DefaultCodeResolutionConfigurator.ConfigureCodeResolversWithTrivialDefault();
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
			return ParseContextImpl.Create("MO", typeof(Money), SpecificationVersion.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.POPULATED, null, null, false);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseEmptyNode()
		{
			XmlNode node = CreateNode("<something/>");
			new MoElementParser().Parse(CreateContext(), node, result);
			Assert.IsFalse(result.IsValid(), "valid");
			Assert.AreEqual(2, this.result.GetHl7Errors().Count);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNoCurrencyAttributeNode()
		{
			XmlNode node = CreateNode("<something value=\"12.34\" notcurrency=\"CAD\" />");
			Money parseResult = (Money)new MoElementParser().Parse(CreateContext(), node, this.result).BareValue;
			Assert.IsFalse(result.IsValid(), "result");
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			AssertResultAsExpected(parseResult, new BigDecimal("12.34"), null);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidTwoAttributes()
		{
			XmlNode node = CreateNode("<something value=\"12.00\" currency=\"CAD\" />");
			Money result = (Money)new MoElementParser().Parse(CreateContext(), node, this.result).BareValue;
			Assert.IsTrue(this.result.IsValid(), "result");
			AssertResultAsExpected(result, new BigDecimal("12.00"), Ca.Infoway.Messagebuilder.Domainvalue.Basic.Currency.CANADIAN_DOLLAR
				);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidTwoAttributesMaxDigits()
		{
			XmlNode node = CreateNode("<something value=\"12345678901.12\" currency=\"CAD\" />");
			Money result = (Money)new MoElementParser().Parse(CreateContext(), node, this.result).BareValue;
			Assert.IsTrue(this.result.IsValid(), "result");
			AssertResultAsExpected(result, new BigDecimal("12345678901.12"), Ca.Infoway.Messagebuilder.Domainvalue.Basic.Currency.CANADIAN_DOLLAR
				);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidTwoAttributesDifferentOrder()
		{
			XmlNode node = CreateNode("<something currency=\"CAD\" value=\"12\" />");
			Money result = (Money)new MoElementParser().Parse(CreateContext(), node, this.result).BareValue;
			Assert.IsTrue(this.result.IsValid(), "result");
			AssertResultAsExpected(result, new BigDecimal("12"), Ca.Infoway.Messagebuilder.Domainvalue.Basic.Currency.CANADIAN_DOLLAR
				);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidTwoAttributesPlusExtra()
		{
			XmlNode node = CreateNode("<something value=\".4\" currency=\"CAD\" something=\"monkey\" />");
			Money result = (Money)new MoElementParser().Parse(CreateContext(), node, this.result).BareValue;
			Assert.IsTrue(this.result.IsValid(), "result");
			AssertResultAsExpected(result, new BigDecimal(".4"), Ca.Infoway.Messagebuilder.Domainvalue.Basic.Currency.CANADIAN_DOLLAR
				);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalidValue()
		{
			XmlNode node = CreateNode("<something value=\"12.00X\" currency=\"CAD\" />");
			Money parseResult = (Money)new MoElementParser().Parse(CreateContext(), node, this.result).BareValue;
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			AssertResultAsExpected(parseResult, null, Ca.Infoway.Messagebuilder.Domainvalue.Basic.Currency.CANADIAN_DOLLAR);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseMissingValue()
		{
			XmlNode node = CreateNode("<something value=\"\" currency=\"CAD\" />");
			Money parseResult = (Money)new MoElementParser().Parse(CreateContext(), node, this.result).BareValue;
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			AssertResultAsExpected(parseResult, null, Ca.Infoway.Messagebuilder.Domainvalue.Basic.Currency.CANADIAN_DOLLAR);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalidValueTooManyDigits()
		{
			XmlNode node = CreateNode("<something value=\"123456789012.123\" currency=\"CAD\" />");
			Money parseResult = (Money)new MoElementParser().Parse(CreateContext(), node, this.result).BareValue;
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(2, this.result.GetHl7Errors().Count);
			AssertResultAsExpected(parseResult, new BigDecimal("123456789012.123"), Ca.Infoway.Messagebuilder.Domainvalue.Basic.Currency
				.CANADIAN_DOLLAR);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalidValueNotAllDigitsBeforeDecimal()
		{
			XmlNode node = CreateNode("<something value=\"0x12\" currency=\"CAD\" />");
			Money parseResult = (Money)new MoElementParser().Parse(CreateContext(), node, this.result).BareValue;
			Assert.IsFalse(this.result.IsValid());
			// not all digits; not a number (the first error does not occur for .NET)
			AssertResultAsExpected(parseResult, null, Ca.Infoway.Messagebuilder.Domainvalue.Basic.Currency.CANADIAN_DOLLAR);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalidValueNotAllDigitsAfterDecimal()
		{
			XmlNode node = CreateNode("<something value=\"1122.1a\" currency=\"CAD\" />");
			Money parseResult = (Money)new MoElementParser().Parse(CreateContext(), node, this.result).BareValue;
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			// not all digits; not a number
			AssertResultAsExpected(parseResult, null, Ca.Infoway.Messagebuilder.Domainvalue.Basic.Currency.CANADIAN_DOLLAR);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalidCurrency()
		{
			XmlNode node = CreateNode("<something value=\"12.00\" currency=\"XXX\" />");
			Money parseResult = (Money)new MoElementParser().Parse(CreateContext(), node, this.result).BareValue;
			Assert.IsFalse(result.IsValid(), "result");
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			AssertResultAsExpected(parseResult, new BigDecimal("12.00"), null);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseUnallowedCurrency()
		{
			XmlNode node = CreateNode("<something value=\"123.0\" currency=\"USD\" />");
			Money parseResult = (Money)new MoElementParser().Parse(CreateContext(), node, this.result).BareValue;
			Assert.IsFalse(result.IsValid(), "result");
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			AssertResultAsExpected(parseResult, new BigDecimal("123.0"), Ca.Infoway.Messagebuilder.Domainvalue.Basic.Currency.US_DOLLAR
				);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseTooManyChildNodes()
		{
			XmlNode node = CreateNode("<something>" + "<monkey/>" + "</something>");
			try
			{
				new MoElementParser().Parse(CreateContext(), node, this.result);
				Assert.Fail("expected exception");
			}
			catch (XmlToModelTransformationException e)
			{
				// expected
				Assert.AreEqual("Expected MO node to have no children", e.Message, "proper exception returned");
			}
		}

		private void AssertResultAsExpected(Money result, BigDecimal value, Ca.Infoway.Messagebuilder.Domainvalue.Basic.Currency 
			currency)
		{
			Assert.IsNotNull(result, "populated result returned");
			if (result.Amount == null)
			{
				Assert.IsNull(result.Amount, "value");
			}
			else
			{
				Assert.AreEqual(value, result.Amount, "value");
			}
			if (result.Currency == null)
			{
				Assert.IsNull(result.Currency, "currency");
			}
			else
			{
				Assert.AreEqual(currency, result.Currency, "currency");
			}
		}
	}
}
