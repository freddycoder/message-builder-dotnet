using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Resolver.Configurator;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class RtoMoPqPropertyFormatterTest : FormatterTestCase
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
			Ratio<Money, PhysicalQuantity> ratio = new Ratio<Money, PhysicalQuantity>();
			ratio.Numerator = new Money(new BigDecimal("1.00"), Ca.Infoway.Messagebuilder.Domainvalue.Basic.Currency.CANADIAN_DOLLAR);
			ratio.Denominator = new PhysicalQuantity(new BigDecimal("10.00"), Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive
				.MILLILITRE);
			string result = new RtoMoPqPropertyFormatter().Format(GetContext("name", "RTO<MO.CAD,PQ.BASIC>"), new RTOImpl<Money, PhysicalQuantity
				>(ratio));
			AssertXml("result", "<name><numerator currency=\"CAD\" value=\"1.00\"/><denominator unit=\"mL\" value=\"10.00\"/></name>"
				, result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestNullCase()
		{
			string result = new RtoMoPqPropertyFormatter().Format(GetContext("name", "RTO<MO.CAD,PQ.BASIC>"), new RTOImpl<PhysicalQuantity
				, PhysicalQuantity>());
			AssertXml("result", "<name nullFlavor=\"NI\"/>", result);
		}
	}
}
