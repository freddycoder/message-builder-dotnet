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
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2;
using Ca.Infoway.Messagebuilder.Resolver.Configurator;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2
{
	[TestFixture]
	public class PqR2PropertyFormatterTest : FormatterTestCase
	{
		private class TestablePqR2PropertyFormatter : PqR2PropertyFormatter, TestableAbstractValueNullFlavorPropertyFormatter<PhysicalQuantity
			>
		{
			public virtual IDictionary<string, string> GetAttributeNameValuePairsForTest(FormatContext context, PhysicalQuantity t, BareANY
				 bareAny)
			{
				return base.GetAttributeNameValuePairs(context, t, bareAny);
			}

			public virtual string FormatNonNullDataTypeForTest(FormatContext context, BareANY hl7Value, int indentLevel)
			{
				return base.FormatNonNullDataType(context, hl7Value, indentLevel);
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
			string result = new PqR2PropertyFormatterTest.TestablePqR2PropertyFormatter().Format(CreateContext("PQ"), new PQImpl());
			// a null value for PQ elements results in a nullFlavor attribute (but not via calling getAttributeNameValuePairs, only through format() itself)
			Assert.AreEqual("<name nullFlavor=\"NI\"/>", result.Trim(), "map size");
			Assert.IsTrue(this.result.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatPhysicalQuantitySpecificNull()
		{
			PQImpl dataType = new PQImpl(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NOT_APPLICABLE);
			string result = new PqR2PropertyFormatterTest.TestablePqR2PropertyFormatter().Format(CreateContext("PQ"), dataType);
			Assert.AreEqual("<name nullFlavor=\"NA\"/>", result.Trim(), "map size");
			Assert.IsTrue(this.result.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatPhysicalQuantityNotNullWithNullFlavor()
		{
			// in this case, NF "wins"
			PhysicalQuantity pq = new PhysicalQuantity(null, Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive.
				CENTIMETRE);
			PQImpl dataType = new PQImpl(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NOT_APPLICABLE);
			dataType.Value = pq;
			string result = new PqR2PropertyFormatterTest.TestablePqR2PropertyFormatter().Format(CreateContext("PQ"), dataType);
			Assert.AreEqual("<name nullFlavor=\"NA\"/>", result.Trim(), "map size");
			Assert.IsTrue(this.result.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatPhysicalQuantityEmpty()
		{
			IDictionary<string, string> resultMap = new PqR2PropertyFormatterTest.TestablePqR2PropertyFormatter().GetAttributeNameValuePairsForTest
				(CreateContext("PQ"), new PhysicalQuantity(), null);
			// an empty value for PQ elements results no attributes whatsoever
			Assert.AreEqual(0, resultMap.Count, "map size");
			Assert.IsTrue(this.result.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatPhysicalQuantityValueOrUnitNull()
		{
			// no name-value pairs
			PqR2PropertyFormatter formatter = new PqR2PropertyFormatterTest.TestablePqR2PropertyFormatter();
			PhysicalQuantity physicalQuantity = new PhysicalQuantity();
			physicalQuantity.Unit = CeRxDomainTestValues.ENZYME_UNIT_MICROMOLES_MINUTE_PER_LITRE;
			string result = formatter.Format(CreateContext("PQ"), new PQImpl(physicalQuantity));
			Assert.IsTrue(this.result.IsValid());
			Assert.AreEqual("<name unit=\"U/L\"/>", result.Trim(), "map size");
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
			IDictionary<string, string> result = new PqR2PropertyFormatterTest.TestablePqR2PropertyFormatter().GetAttributeNameValuePairsForTest
				(CreateContext("PQ"), physicalQuantity, null);
			Assert.AreEqual(2, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual(quantity, result.SafeGet("value"), "value");
			Assert.IsTrue(result.ContainsKey("unit"), "unit key as expected");
			Assert.AreEqual(unit.CodeValue, result.SafeGet("unit"), "unit");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatPhysicalQuantityValidWithTranslations()
		{
			CodedTypeR2<Code> translation1 = new CodedTypeR2<Code>();
			translation1.Code = Ca.Infoway.Messagebuilder.Domainvalue.Payload.AdministrativeGender.MALE;
			CodedTypeR2<Code> translation2 = new CodedTypeR2<Code>();
			translation2.Code = Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActStatus.ACTIVE;
			string quantity = "33.45";
			Ca.Infoway.Messagebuilder.Domainvalue.UnitsOfMeasureCaseSensitive unit = CeRxDomainTestValues.ENZYME_UNIT_MICROMOLES_MINUTE_PER_LITRE;
			PhysicalQuantity physicalQuantity = new PhysicalQuantity();
			physicalQuantity.Quantity = new BigDecimal(quantity);
			physicalQuantity.Unit = unit;
			physicalQuantity.Translation.Add(translation1);
			physicalQuantity.Translation.Add(translation2);
			IDictionary<string, string> result = new PqR2PropertyFormatterTest.TestablePqR2PropertyFormatter().GetAttributeNameValuePairsForTest
				(CreateContext("PQ"), physicalQuantity, null);
			Assert.AreEqual(2, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual(quantity, result.SafeGet("value"), "value");
			Assert.IsTrue(result.ContainsKey("unit"), "unit key as expected");
			Assert.AreEqual(unit.CodeValue, result.SafeGet("unit"), "unit");
			string xml = new PqR2PropertyFormatterTest.TestablePqR2PropertyFormatter().Format(CreateContext("PQ"), new PQImpl(physicalQuantity
				), 0);
			AssertXml("should see translations", "<name unit=\"U/L\" value=\"33.45\"><translation code=\"M\" codeSystem=\"2.16.840.1.113883.5.1\" displayName=\"Male\"/><translation code=\"active\" codeSystem=\"2.16.840.1.113883.5.14\" displayName=\"Active\"/></name>"
				, xml);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValidPhysicalQuantity()
		{
			string quantity = "33.45";
			Ca.Infoway.Messagebuilder.Domainvalue.UnitsOfMeasureCaseSensitive unit = CeRxDomainTestValues.ENZYME_UNIT_MICROMOLES_MINUTE_PER_LITRE;
			PhysicalQuantity physicalQuantity = new PhysicalQuantity();
			physicalQuantity.Quantity = new BigDecimal(quantity);
			physicalQuantity.Unit = unit;
			PQ rawPq = new PQImpl(physicalQuantity);
			string result = new PqR2PropertyFormatterTest.TestablePqR2PropertyFormatter().Format(CreateContext("PQ"), rawPq, 0);
			string expectedResult = "<name unit=\"U/L\" value=\"33.45\"/>";
			Assert.AreEqual(expectedResult, result.Trim(), "output");
		}

		[Test]
		public virtual void TestFormatNonNullWithEmptyPq()
		{
			// nullFlavor, value, and unit are all optional in the schema (unit will default to "1")
			PqR2PropertyFormatterTest.TestablePqR2PropertyFormatter formatter = new PqR2PropertyFormatterTest.TestablePqR2PropertyFormatter
				();
			PQImpl pqImpl = new PQImpl();
			pqImpl.Value = new PhysicalQuantity();
			string result = formatter.FormatNonNullDataTypeForTest(CreateContext("PQ"), pqImpl, 0);
			Assert.AreEqual("<name/>", result.Trim());
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
		[Test]
		public virtual void TestFormatValidPhysicalQuantityWithOperatorNotAllowed()
		{
			string quantity = "33.45";
			Ca.Infoway.Messagebuilder.Domainvalue.UnitsOfMeasureCaseSensitive unit = CeRxDomainTestValues.ENZYME_UNIT_MICROMOLES_MINUTE_PER_LITRE;
			PhysicalQuantity physicalQuantity = new PhysicalQuantity();
			physicalQuantity.Quantity = new BigDecimal(quantity);
			physicalQuantity.Unit = unit;
			PQ rawPq = new PQImpl(physicalQuantity);
			rawPq.Operator = SetOperator.PERIODIC_HULL;
			string result = new PqR2PropertyFormatterTest.TestablePqR2PropertyFormatter().Format(CreateContext("PQ"), rawPq, 0);
			string expectedResult = "<name unit=\"U/L\" value=\"33.45\"/>";
			Assert.AreEqual(expectedResult, result.Trim(), "output");
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatSxcmPhysicalQuantityWithOperator()
		{
			string quantity = "33.45";
			Ca.Infoway.Messagebuilder.Domainvalue.UnitsOfMeasureCaseSensitive unit = CeRxDomainTestValues.ENZYME_UNIT_MICROMOLES_MINUTE_PER_LITRE;
			PhysicalQuantity physicalQuantity = new PhysicalQuantity();
			physicalQuantity.Quantity = new BigDecimal(quantity);
			physicalQuantity.Unit = unit;
			PQ rawPq = new PQImpl(physicalQuantity);
			rawPq.Operator = SetOperator.PERIODIC_HULL;
			string result = new PqR2PropertyFormatterTest.TestablePqR2PropertyFormatter().Format(CreateContext("SXCM<PQ>"), rawPq, 0);
			string expectedResult = "<name operator=\"P\" unit=\"U/L\" value=\"33.45\"/>";
			Assert.AreEqual(expectedResult, result.Trim(), "output");
			Assert.IsTrue(this.result.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatSxcmPhysicalQuantityWithoutOperator()
		{
			string quantity = "33.45";
			Ca.Infoway.Messagebuilder.Domainvalue.UnitsOfMeasureCaseSensitive unit = CeRxDomainTestValues.ENZYME_UNIT_MICROMOLES_MINUTE_PER_LITRE;
			PhysicalQuantity physicalQuantity = new PhysicalQuantity();
			physicalQuantity.Quantity = new BigDecimal(quantity);
			physicalQuantity.Unit = unit;
			PQ rawPq = new PQImpl(physicalQuantity);
			string result = new PqR2PropertyFormatterTest.TestablePqR2PropertyFormatter().Format(CreateContext("SXCM<PQ>"), rawPq, 0);
			string expectedResult = "<name unit=\"U/L\" value=\"33.45\"/>";
			Assert.AreEqual(expectedResult, result.Trim(), "output");
			Assert.IsTrue(this.result.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestEdgeCasesForFormatPhysicalQuantityFormattingThatCauseTroubleForDotNet()
		{
			AssertFormattingAsExpected("0.0", "0.0");
			AssertFormattingAsExpected("-0.0", "0.0");
		}

		/// <exception cref="System.Exception"></exception>
		private void AssertFormattingAsExpected(string quantity, string formattedQuantity)
		{
			PhysicalQuantity physicalQuantity = new PhysicalQuantity();
			physicalQuantity.Quantity = new BigDecimal(quantity);
			physicalQuantity.Unit = CeRxDomainTestValues.CENTIMETRE;
			IDictionary<string, string> result = new PqR2PropertyFormatterTest.TestablePqR2PropertyFormatter().GetAttributeNameValuePairsForTest
				(CreateContext("PQ"), physicalQuantity, null);
			Assert.AreEqual(formattedQuantity, result.SafeGet("value"), "value " + quantity);
		}

		private Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl CreateContext(string type)
		{
			return new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(this.result, null, "name", type, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.POPULATED, null, false, SpecificationVersion.R02_04_02, null, null, null, false);
		}
	}
}
