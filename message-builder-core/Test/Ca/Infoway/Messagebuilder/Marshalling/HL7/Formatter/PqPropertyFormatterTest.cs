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
 * Author:        $LastChangedBy: gng $
 * Last modified: $LastChangedDate: 2015-11-19 18:20:12 -0500 (Fri, 30 Jan 2015) $
 * Revision:      $LastChangedRevision: 9755 $
 */


using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Resolver.Configurator;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class PqPropertyFormatterTest : FormatterTestCase
	{
		private class TestablePqPropertyFormatter : PqPropertyFormatter, TestableAbstractValueNullFlavorPropertyFormatter<PhysicalQuantity
			>
		{
			public virtual IDictionary<string, string> GetAttributeNameValuePairsForTest(FormatContext context, PhysicalQuantity t, BareANY
				 bareAny)
			{
				return base.GetAttributeNameValuePairs(context, t, bareAny);
			}

			public virtual string FormatNonNullDataTypeForTest(FormatContext context, BareANY bareAny, int indentLevel)
			{
				return base.FormatNonNullDataType(context, bareAny, indentLevel);
			}
		}

		[SetUp]
		public virtual void Setup()
		{
			DefaultCodeResolutionConfigurator.ConfigureCodeResolversWithTrivialDefault();
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatPhysicalQuantityNull()
		{
			string result = new PqPropertyFormatterTest.TestablePqPropertyFormatter().Format(CreateContext("PQ.BASIC"), new PQImpl());
			// a null value for PQ elements results in a nullFlavor attribute (but not via calling getAttributeNameValuePairs, only through format() itself)
			Assert.AreEqual("<name nullFlavor=\"NI\"/>", result.Trim(), "map size");
			Assert.IsTrue(this.result.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatPhysicalQuantityNullMissingOriginalText()
		{
			PQImpl dataType = new PQImpl(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NOT_APPLICABLE);
			string result = new PqPropertyFormatterTest.TestablePqPropertyFormatter().Format(CreateContext("PQ.LAB"), dataType);
			Assert.AreEqual("<name nullFlavor=\"NA\"/>", result.Trim(), "map size");
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatPhysicalQuantityNotNullWithNullFlavorMissingOriginalText()
		{
			PhysicalQuantity pq = new PhysicalQuantity(null, Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive.
				CENTIMETRE);
			PQImpl dataType = new PQImpl(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NOT_APPLICABLE);
			dataType.Value = pq;
			string result = new PqPropertyFormatterTest.TestablePqPropertyFormatter().Format(CreateContext("PQ.LAB"), dataType);
			Assert.AreEqual("<name nullFlavor=\"NA\"/>", result.Trim(), "map size");
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(2, this.result.GetHl7Errors().Count);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatPhysicalQuantityEmpty()
		{
			IDictionary<string, string> resultMap = new PqPropertyFormatterTest.TestablePqPropertyFormatter().GetAttributeNameValuePairs
				(CreateContext("PQ.BASIC"), new PhysicalQuantity());
			// an empty value for PQ elements results in a nullFlavor attribute
			Assert.AreEqual(1, resultMap.Count, "map size");
			Assert.IsTrue(resultMap.ContainsKey("nullFlavor"), "key as expected");
			Assert.AreEqual(AbstractPropertyFormatter.NULL_FLAVOR_NO_INFORMATION, resultMap.SafeGet("nullFlavor"), "value as expected"
				);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatPhysicalQuantityValueOrUnitNull()
		{
			// no name-value pairs
			PqPropertyFormatter formatter = new PqPropertyFormatterTest.TestablePqPropertyFormatter();
			PhysicalQuantity physicalQuantity = new PhysicalQuantity();
			physicalQuantity.Unit = CeRxDomainTestValues.ENZYME_UNIT_MICROMOLES_MINUTE_PER_LITRE;
			formatter.Format(CreateContext("PQ.BASIC"), new PQImpl(physicalQuantity));
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			Assert.AreEqual("No value provided for physical quantity", this.result.GetHl7Errors()[0].GetMessage(), "exception message null quantity"
				);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatPhysicalQuantityValid()
		{
			string quantity = "33.45";
			Ca.Infoway.Messagebuilder.Domainvalue.UnitsOfMeasureCaseSensitive unit = CeRxDomainTestValues.ENZYME_UNIT_MICROMOLES_MINUTE_PER_LITRE;
			PhysicalQuantity physicalQuantity = new PhysicalQuantity();
			physicalQuantity.Quantity = new BigDecimal(quantity);
			physicalQuantity.Unit = unit;
			IDictionary<string, string> result = new PqPropertyFormatterTest.TestablePqPropertyFormatter().GetAttributeNameValuePairs
				(CreateContext("PQ.BASIC"), physicalQuantity);
			Assert.AreEqual(2, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual(quantity, result.SafeGet("value"), "value");
			Assert.IsTrue(result.ContainsKey("unit"), "unit key as expected");
			Assert.AreEqual(unit.CodeValue, result.SafeGet("unit"), "unit");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatPhysicalQuantityValidWithOriginalText()
		{
			string quantity = "33.45";
			Ca.Infoway.Messagebuilder.Domainvalue.UnitsOfMeasureCaseSensitive unit = CeRxDomainTestValues.ENZYME_UNIT_MICROMOLES_MINUTE_PER_LITRE;
			PhysicalQuantity physicalQuantity = new PhysicalQuantity();
			physicalQuantity.Quantity = new BigDecimal(quantity);
			physicalQuantity.Unit = unit;
			PQ rawPq = new PQImpl();
			rawPq.OriginalText = "some original text";
			rawPq.Value = physicalQuantity;
			string result = new PqPropertyFormatterTest.TestablePqPropertyFormatter().Format(CreateContext("PQ.BASIC"), rawPq, 0);
			string expectedResult = "<name unit=\"U/L\" value=\"33.45\">" + SystemUtils.LINE_SEPARATOR + "  <originalText>some original text</originalText>"
				 + SystemUtils.LINE_SEPARATOR + "</name>" + SystemUtils.LINE_SEPARATOR;
			Assert.AreEqual(expectedResult, result, "output");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatPhysicalQuantityFormattingErrors()
		{
			AssertExceptionAsExpected("33.455", true, false);
			AssertExceptionAsExpected("-33.455", true, false);
			AssertExceptionAsExpected("123456789.455", true, false);
			AssertExceptionAsExpected("-123456789.455", true, false);
			AssertExceptionAsExpected("123456789012", false, true);
			AssertExceptionAsExpected("-123456789012", false, true);
			AssertExceptionAsExpected("1234567890123.12345", true, true);
			AssertExceptionAsExpected("-1234567890123.12345", true, true);
		}

		private void AssertExceptionAsExpected(string quantity, bool decimalError, bool integerError)
		{
			this.result.ClearErrors();
			PhysicalQuantity physicalQuantity = new PhysicalQuantity();
			BigDecimal bigDecimal = new BigDecimal(quantity);
			physicalQuantity.Quantity = bigDecimal;
			physicalQuantity.Unit = CeRxDomainTestValues.FLUID_OUNCE;
			string expectedErrorDecimal = "PhysicalQuantity for MR2009/PQ.BASIC can contain a maximum of 2 decimal places";
			string expectedErrorInteger = "PhysicalQuantity for MR2009/PQ.BASIC can contain a maximum of 11 integer places";
			new PqPropertyFormatterTest.TestablePqPropertyFormatter().Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(this.result, null, "name", "PQ.BASIC", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY, null, false, SpecificationVersion
				.R02_04_02, null, null, null, false), new PQImpl(physicalQuantity), 0);
			if (decimalError)
			{
				Assert.AreEqual(expectedErrorDecimal, this.result.GetHl7Errors()[0].GetMessage());
			}
			if (integerError)
			{
				Assert.AreEqual(expectedErrorInteger, this.result.GetHl7Errors()[decimalError && integerError ? 1 : 0].GetMessage());
			}
		}

		[Test]
		public virtual void TestFormatNonNullWithEmptyPq()
		{
			PqPropertyFormatterTest.TestablePqPropertyFormatter formatter = new PqPropertyFormatterTest.TestablePqPropertyFormatter();
			PQImpl pqImpl = new PQImpl();
			pqImpl.Value = new PhysicalQuantity();
			string @string = formatter.FormatNonNullDataTypeForTest(CreateContext("PQ.BASIC"), pqImpl, 0);
			string lineBreak = Runtime.GetProperty("line.separator");
			Assert.AreEqual("<name nullFlavor=\"NI\"/>" + lineBreak, @string);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatPhysicalQuantityFormatting()
		{
			AssertFormattingAsExpected("33.4", "33.4");
			AssertFormattingAsExpected("33.40", "33.40");
			AssertFormattingAsExpected("33.41", "33.41");
			AssertFormattingAsExpected("033.40", "33.40");
			AssertFormattingAsExpected("0.40", "0.40");
			AssertFormattingAsExpected("12345678.99", "12345678.99");
			AssertFormattingAsExpected("12345678901.99", "12345678901.99");
			AssertFormattingAsExpected("-33.4", "-33.4");
			AssertFormattingAsExpected("-33.40", "-33.40");
			AssertFormattingAsExpected("-33.41", "-33.41");
			AssertFormattingAsExpected("-033.40", "-33.40");
			AssertFormattingAsExpected("-0.40", "-0.40");
			AssertFormattingAsExpected("-12345678.99", "-12345678.99");
			// now check values that will be truncated/rounded (UPDATE: not anymore due to Redmine 1570)
			AssertFormattingAsExpected("-33.416", "-33.416");
			AssertFormattingAsExpected("-33.41223", "-33.41223");
			AssertFormattingAsExpected("123456789012.99", "123456789012.99");
		}

		/// <exception cref="System.Exception"></exception>
		private void AssertFormattingAsExpected(string quantity, string formattedQuantity)
		{
			PhysicalQuantity physicalQuantity = new PhysicalQuantity();
			physicalQuantity.Quantity = new BigDecimal(quantity);
			physicalQuantity.Unit = CeRxDomainTestValues.CENTIMETRE;
			IDictionary<string, string> result = new PqPropertyFormatterTest.TestablePqPropertyFormatter().GetAttributeNameValuePairs
				(CreateContext("PQ.BASIC"), physicalQuantity);
			Assert.AreEqual(formattedQuantity, result.SafeGet("value"), "value " + quantity);
		}

		private Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl CreateContext(string type)
		{
			return new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(this.result, null, "name", type, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.POPULATED, null, false, SpecificationVersion.R02_04_02, null, null, null, false);
		}
	}
}
