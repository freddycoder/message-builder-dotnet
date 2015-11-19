using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Resolver.Configurator;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class AbstractCerxPqPropertyFormatterTest : FormatterTestCase
	{
		[SetUp]
		public virtual void Setup()
		{
			DefaultCodeResolutionConfigurator.ConfigureCodeResolversWithTrivialDefault();
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatPhysicalQuantityNull()
		{
			string formatResult = new PqPropertyFormatter().Format(CreateContext(), new PQImpl());
			// a null value for PQ elements results in a nullFlavor attribute
			Assert.AreEqual("<name nullFlavor=\"NI\"/>", formatResult.Trim(), "result");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatPhysicalQuantityEmpty()
		{
			IDictionary<string, string> result = new PqPropertyFormatter().GetAttributeNameValuePairs(CreateContext(), new PhysicalQuantity
				());
			// an empty value for PQ elements results in a nullFlavor attribute
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("nullFlavor"), "key as expected");
			Assert.AreEqual(AbstractPropertyFormatter.NULL_FLAVOR_NO_INFORMATION, result.SafeGet("nullFlavor"), "value as expected");
		}

		private Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl CreateContext()
		{
			return new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(this.result, null, "name", "PQ.BASIC", null
				, null, false, SpecificationVersion.V01R04_3, null, null, null, false);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatPhysicalQuantityValueOrUnitNull()
		{
			// no name-value pairs
			PqPropertyFormatter formatter = new PqPropertyFormatter();
			PhysicalQuantity physicalQuantity = new PhysicalQuantity();
			physicalQuantity.Unit = Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive.MILLIGRAM;
			formatter.Format(CreateContext(), new PQImpl(physicalQuantity));
			Assert.AreEqual("No value provided for physical quantity", this.result.GetHl7Errors()[0].GetMessage());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatPhysicalQuantityValid()
		{
			string quantity = "33.45";
			Ca.Infoway.Messagebuilder.Domainvalue.UnitsOfMeasureCaseSensitive unit = Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive
				.MILLILITRE;
			PhysicalQuantity physicalQuantity = new PhysicalQuantity();
			physicalQuantity.Quantity = new BigDecimal(quantity);
			physicalQuantity.Unit = unit;
			IDictionary<string, string> result = new PqPropertyFormatter().GetAttributeNameValuePairs(CreateContext(), physicalQuantity
				);
			Assert.AreEqual(2, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual(quantity, result.SafeGet("value"), "value");
			Assert.IsTrue(result.ContainsKey("unit"), "unit key as expected");
			Assert.AreEqual(unit.CodeValue, result.SafeGet("unit"), "unit");
		}
	}
}
