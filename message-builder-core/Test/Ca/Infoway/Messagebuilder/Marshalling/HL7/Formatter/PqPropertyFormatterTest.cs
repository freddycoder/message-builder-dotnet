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
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Terminology.Configurator;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class PqPropertyFormatterTest : FormatterTestCase
	{
		[SetUp]
		public override void Setup()
		{
			DefaultCodeResolutionConfigurator.ConfigureCodeResolversWithTrivialDefault();
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatPhysicalQuantityNull()
		{
			string result = new PqPropertyFormatter().Format(CreateContext(), new PQImpl());
			// a null value for PQ elements results in a nullFlavor attribute (but not via calling getAttributeNameValuePairs, only through format() itself)
			Assert.AreEqual("<name nullFlavor=\"NI\"/>", result.Trim(), "map size");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatPhysicalQuantityEmpty()
		{
			IDictionary<string, string> resultMap = new PqPropertyFormatter().GetAttributeNameValuePairs(CreateContext(), new PhysicalQuantity
				(), null);
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
			PqPropertyFormatter formatter = new PqPropertyFormatter();
			PhysicalQuantity physicalQuantity = new PhysicalQuantity();
			physicalQuantity.Unit = CeRxDomainTestValues.ENZYME_UNIT_MICROMOLES_MINUTE_PER_LITRE;
			formatter.Format(CreateContext(), new PQImpl(physicalQuantity));
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
			IDictionary<string, string> result = new PqPropertyFormatter().GetAttributeNameValuePairs(CreateContext(), physicalQuantity
				, null);
			Assert.AreEqual(2, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual(quantity, result.SafeGet("value"), "value");
			Assert.IsTrue(result.ContainsKey("unit"), "unit key as expected");
			Assert.AreEqual(unit.CodeValue, result.SafeGet("unit"), "unit");
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
			new PqPropertyFormatter().Format(new FormatContextImpl(this.result, null, "name", "PQ.BASIC", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.MANDATORY, false, SpecificationVersion.R02_04_02, null, null, null), new PQImpl(physicalQuantity), 0);
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
			PqPropertyFormatter formatter = new PqPropertyFormatter();
			PQImpl pqImpl = new PQImpl();
			pqImpl.Value = new PhysicalQuantity();
			string @string = formatter.FormatNonNullDataType(CreateContext(), pqImpl, 0);
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
			IDictionary<string, string> result = new PqPropertyFormatter().GetAttributeNameValuePairs(CreateContext(), physicalQuantity
				, null);
			Assert.AreEqual(formattedQuantity, result.SafeGet("value"), "value " + quantity);
		}

		private FormatContextImpl CreateContext()
		{
			return new FormatContextImpl(this.result, null, "name", "PQ.BASIC", null, false, SpecificationVersion.R02_04_02, null, null
				, null);
		}
	}
}
