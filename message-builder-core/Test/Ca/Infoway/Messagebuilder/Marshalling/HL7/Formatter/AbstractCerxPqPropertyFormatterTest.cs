using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class AbstractCerxPqPropertyFormatterTest
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatPhysicalQuantityNull()
		{
			IDictionary<string, string> result = new PqPropertyFormatter().GetAttributeNameValuePairs(new FormatContextImpl("name", null
				, null), null);
			// a null value for PQ elements results in a nullFlavor attribute
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("nullFlavor"), "key as expected");
			Assert.AreEqual(AbstractPropertyFormatter.NULL_FLAVOR_NO_INFORMATION, result.SafeGet("nullFlavor"), "value as expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatPhysicalQuantityEmpty()
		{
			IDictionary<string, string> result = new PqPropertyFormatter().GetAttributeNameValuePairs(new FormatContextImpl("name", null
				, null), new PhysicalQuantity());
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
			PqPropertyFormatter formatter = new PqPropertyFormatter();
			PhysicalQuantity physicalQuantity = new PhysicalQuantity();
			physicalQuantity.Unit = Ca.Infoway.Messagebuilder.Datatype.Lang.UnitsOfMeasureCaseSensitive.MILLIGRAM;
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
			Ca.Infoway.Messagebuilder.Domainvalue.UnitsOfMeasureCaseSensitive unit = Ca.Infoway.Messagebuilder.Datatype.Lang.UnitsOfMeasureCaseSensitive
				.MILLILITRE;
			PhysicalQuantity physicalQuantity = new PhysicalQuantity();
			physicalQuantity.Quantity = new BigDecimal(quantity);
			physicalQuantity.Unit = unit;
			IDictionary<string, string> result = new PqPropertyFormatter().GetAttributeNameValuePairs(new FormatContextImpl("name", null
				, null), physicalQuantity);
			Assert.AreEqual(2, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual(quantity, result.SafeGet("value"), "value");
			Assert.IsTrue(result.ContainsKey("unit"), "unit key as expected");
			Assert.AreEqual(unit.CodeValue, result.SafeGet("unit"), "unit");
		}
	}
}
