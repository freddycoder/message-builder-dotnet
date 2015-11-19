using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2;
using Ca.Infoway.Messagebuilder.Resolver.Configurator;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2
{
	[TestFixture]
	public class RtoPqPqR2PropertyFormatterTest : FormatterTestCase
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
			string result = new RtoPqPqR2PropertyFormatter().Format(GetContext("name", "RTO<PQ,PQ>"), new RTOImpl<PhysicalQuantity, PhysicalQuantity
				>(ratio));
			Assert.IsTrue(this.result.IsValid());
			AssertXml("result", "<name><numerator unit=\"mg\" value=\"1.00\"/><denominator unit=\"mL\" value=\"10.00\"/></name>", result
				);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestNullCase()
		{
			string result = new RtoPqPqR2PropertyFormatter().Format(GetContext("name", "RTO<PQ,PQ>"), new RTOImpl<PhysicalQuantity, PhysicalQuantity
				>());
			Assert.IsTrue(this.result.IsValid());
			AssertXml("result", "<name nullFlavor=\"NI\"/>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestEmptyCase()
		{
			string result = new RtoPqPqR2PropertyFormatter().Format(GetContext("name", "RTO<PQ,PQ>"), new RTOImpl<PhysicalQuantity, PhysicalQuantity
				>(new Ratio<PhysicalQuantity, PhysicalQuantity>()));
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			Assert.IsTrue(this.result.GetHl7Errors()[0].GetMessage().Contains("Numerator and denominator must be non-null; both are mandatory for RTO types."
				));
			Assert.IsNotNull(result);
			AssertXml("result", "<name></name>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestInvalidDenominatorZero()
		{
			Ratio<PhysicalQuantity, PhysicalQuantity> ratio = new Ratio<PhysicalQuantity, PhysicalQuantity>();
			ratio.Numerator = new PhysicalQuantity(new BigDecimal(0), null);
			ratio.Denominator = new PhysicalQuantity(new BigDecimal(0), null);
			string result = new RtoPqPqR2PropertyFormatter().Format(GetContext("name", "RTO<PQ,PQ>"), new RTOImpl<PhysicalQuantity, PhysicalQuantity
				>(ratio));
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			Assert.IsTrue(this.result.GetHl7Errors()[0].GetMessage().Contains("Denominator cannot be zero for RTO types."));
			Assert.IsNotNull(result);
			AssertXml("result", "<name><numerator value=\"0\"/><denominator value=\"0\"/></name>", result);
		}
	}
}
