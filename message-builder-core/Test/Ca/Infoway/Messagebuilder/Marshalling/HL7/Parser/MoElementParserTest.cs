/**
 * Copyright 2013 Canada Health Infoway, Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *        http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 * Author:        $LastChangedBy: tmcgrady $
 * Last modified: $LastChangedDate: 2011-05-04 16:47:15 -0300 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
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
			return ParserContextImpl.Create("MO", typeof(Money), SpecificationVersion.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.POPULATED);
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
			AssertResultAsExpected(result, new BigDecimal("12.00"), Currency.CANADIAN_DOLLAR);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidTwoAttributesMaxDigits()
		{
			XmlNode node = CreateNode("<something value=\"12345678901.12\" currency=\"CAD\" />");
			Money result = (Money)new MoElementParser().Parse(CreateContext(), node, this.result).BareValue;
			Assert.IsTrue(this.result.IsValid(), "result");
			AssertResultAsExpected(result, new BigDecimal("12345678901.12"), Currency.CANADIAN_DOLLAR);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidTwoAttributesDifferentOrder()
		{
			XmlNode node = CreateNode("<something currency=\"CAD\" value=\"12\" />");
			Money result = (Money)new MoElementParser().Parse(CreateContext(), node, this.result).BareValue;
			Assert.IsTrue(this.result.IsValid(), "result");
			AssertResultAsExpected(result, new BigDecimal("12"), Currency.CANADIAN_DOLLAR);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidTwoAttributesPlusExtra()
		{
			XmlNode node = CreateNode("<something value=\".4\" currency=\"CAD\" something=\"monkey\" />");
			Money result = (Money)new MoElementParser().Parse(CreateContext(), node, this.result).BareValue;
			Assert.IsTrue(this.result.IsValid(), "result");
			AssertResultAsExpected(result, new BigDecimal(".4"), Currency.CANADIAN_DOLLAR);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalidValue()
		{
			XmlNode node = CreateNode("<something value=\"12.00X\" currency=\"CAD\" />");
			Money parseResult = (Money)new MoElementParser().Parse(CreateContext(), node, this.result).BareValue;
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			AssertResultAsExpected(parseResult, null, Currency.CANADIAN_DOLLAR);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseMissingValue()
		{
			XmlNode node = CreateNode("<something value=\"\" currency=\"CAD\" />");
			Money parseResult = (Money)new MoElementParser().Parse(CreateContext(), node, this.result).BareValue;
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			AssertResultAsExpected(parseResult, null, Currency.CANADIAN_DOLLAR);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalidValueTooManyDigits()
		{
			XmlNode node = CreateNode("<something value=\"123456789012.123\" currency=\"CAD\" />");
			Money parseResult = (Money)new MoElementParser().Parse(CreateContext(), node, this.result).BareValue;
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(2, this.result.GetHl7Errors().Count);
			AssertResultAsExpected(parseResult, new BigDecimal("123456789012.123"), Currency.CANADIAN_DOLLAR);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalidValueNotAllDigitsBeforeDecimal()
		{
			XmlNode node = CreateNode("<something value=\"0x12\" currency=\"CAD\" />");
			Money parseResult = (Money)new MoElementParser().Parse(CreateContext(), node, this.result).BareValue;
			Assert.IsFalse(this.result.IsValid());
			// not all digits; not a number (the first error does not occur for .NET)
			AssertResultAsExpected(parseResult, null, Currency.CANADIAN_DOLLAR);
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
			AssertResultAsExpected(parseResult, null, Currency.CANADIAN_DOLLAR);
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
			AssertResultAsExpected(parseResult, new BigDecimal("123.0"), Currency.US_DOLLAR);
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

		private void AssertResultAsExpected(Money result, BigDecimal value, Currency currency)
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
