using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using ILOG.J2CsMapping.Text;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class PqPropertyFormatterTest
	{
		private class TestablePqPropertyFormatter : AbstractCerxPqPropertyFormatter
		{
			internal TestablePqPropertyFormatter(PqPropertyFormatterTest _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly PqPropertyFormatterTest _enclosing;
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatPhysicalQuantityNull()
		{
			IDictionary<string, string> result = new PqPropertyFormatterTest.TestablePqPropertyFormatter(this).GetAttributeNameValuePairs
				(new FormatContextImpl("name", null, null), null);
			// a null value for PQ elements results in a nullFlavor attribute
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("nullFlavor"), "key as expected");
			Assert.AreEqual(AbstractPropertyFormatter.NULL_FLAVOR_NO_INFORMATION, result.SafeGet("nullFlavor"), "value as expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatPhysicalQuantityEmpty()
		{
			IDictionary<string, string> result = new PqPropertyFormatterTest.TestablePqPropertyFormatter(this).GetAttributeNameValuePairs
				(new FormatContextImpl("name", null, null), new PhysicalQuantity());
			// an empty value for PQ elements results in a nullFlavor attribute
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("nullFlavor"), "key as expected");
			Assert.AreEqual(AbstractPropertyFormatter.NULL_FLAVOR_NO_INFORMATION, result.SafeGet("nullFlavor"), "value as expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatPhysicalQuantityValueOrUnitNull()
		{
			// no name-value pairs
			PqPropertyFormatterTest.TestablePqPropertyFormatter formatter = new PqPropertyFormatterTest.TestablePqPropertyFormatter(this
				);
			PhysicalQuantity physicalQuantity = new PhysicalQuantity();
			physicalQuantity.Unit = CeRxDomainTestValues.ENZYME_UNIT_MICROMOLES_MINUTE_PER_LITRE;
			try
			{
				formatter.GetAttributeNameValuePairs(new FormatContextImpl("name", null, null), physicalQuantity);
				Assert.Fail("expected exception");
			}
			catch (ModelToXmlTransformationException e)
			{
				Assert.AreEqual("PhysicalQuantity must define quantity", e.Message, "exception message null quantity");
			}
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
			IDictionary<string, string> result = new PqPropertyFormatterTest.TestablePqPropertyFormatter(this).GetAttributeNameValuePairs
				(new FormatContextImpl("name", null, null), physicalQuantity);
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
			PhysicalQuantity physicalQuantity = new PhysicalQuantity();
			BigDecimal bigDecimal = new BigDecimal(quantity);
			physicalQuantity.Quantity = bigDecimal;
			physicalQuantity.Unit = CeRxDomainTestValues.FLUID_OUNCE;
			try
			{
				string expectedErrorMessage = System.String.Format("<!-- WARNING: {0}{1} -->", decimalError ? "PhysicalQuantity can contain a maximum of 2 decimal places. Value has "
					 + bigDecimal.Scale() + " decimal places." : string.Empty, integerError ? "PhysicalQuantity can contain a maximum of 11 integer places. Value has "
					 + (bigDecimal.Precision() - bigDecimal.Scale()) + " integer places." : string.Empty);
				string result = new PqPropertyFormatterTest.TestablePqPropertyFormatter(this).Format(new FormatContextImpl("name", "PQ", 
					Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY), new PQImpl(physicalQuantity), 0);
				Assert.AreEqual(expectedErrorMessage, StringUtils.SubstringBefore(result, SystemUtils.LINE_SEPARATOR));
			}
			catch (ModelToXmlTransformationException e)
			{
				Assert.Fail("should not throw exception: " + e.Message);
			}
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.ModelToXmlTransformationException"></exception>
		[Test]
		public virtual void TestFormatNonNullWithEmptyPq()
		{
			PqPropertyFormatterTest.TestablePqPropertyFormatter formatter = new PqPropertyFormatterTest.TestablePqPropertyFormatter(this
				);
			PQImpl pqImpl = new PQImpl();
			pqImpl.Value = new PhysicalQuantity();
			string @string = formatter.FormatNonNullDataType(new FormatContextImpl("name", null, null), pqImpl, 0);
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
			IDictionary<string, string> result = new PqPropertyFormatterTest.TestablePqPropertyFormatter(this).GetAttributeNameValuePairs
				(new FormatContextImpl("name", null, null), physicalQuantity);
			Assert.AreEqual(formattedQuantity, result.SafeGet("value"), "value " + quantity);
		}
	}
}
