using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Resolver.Configurator;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class RtoPqPqPropertyFormatterTest : FormatterTestCase
	{
		[SetUp]
		public virtual void Setup()
		{
			DefaultCodeResolutionConfigurator.ConfigureCodeResolversWithTrivialDefault();
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestBasic()
		{
			Ratio<PhysicalQuantity, PhysicalQuantity> ratio = new Ratio<PhysicalQuantity, PhysicalQuantity>();
			ratio.Numerator = new PhysicalQuantity(new BigDecimal("1.00"), Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive
				.MILLIGRAM);
			ratio.Denominator = new PhysicalQuantity(new BigDecimal("10.00"), Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive
				.MILLILITRE);
			string result = new RtoPqPqPropertyFormatter().Format(GetContext("name", "RTO<PQ.DRUG,PQ.DRUG>"), new RTOImpl<PhysicalQuantity
				, PhysicalQuantity>(ratio));
			AssertXml("result", "<name><numerator unit=\"mg\" value=\"1.00\"/><denominator unit=\"mL\" value=\"10.00\"/></name>", result
				);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestNullCase()
		{
			string result = new RtoPqPqPropertyFormatter().Format(GetContext("name", "RTO<PQ.DRUG,PQ.TIME>"), new RTOImpl<PhysicalQuantity
				, PhysicalQuantity>());
			AssertXml("result", "<name nullFlavor=\"NI\"/>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestInvalidNullCase()
		{
			string result = new RtoPqPqPropertyFormatter().Format(GetContext("name", "RTO<PQ.DRUG,PQ.TIME>"), new RTOImpl<PhysicalQuantity
				, PhysicalQuantity>(new Ratio<PhysicalQuantity, PhysicalQuantity>()));
			Assert.IsNotNull(result);
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(3, this.result.GetHl7Errors().Count);
		}
		// mandatory fields missing x 2, rto has no value
	}
}
