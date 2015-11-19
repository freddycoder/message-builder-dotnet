using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Resolver.Configurator;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class UrgPqPropertyFormatterTest : FormatterTestCase
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
			UncertainRange<PhysicalQuantity> urg = UncertainRangeFactory.CreateLowHigh(CreateQuantity("55", CeRxDomainTestValues.MILLIMETER
				), CreateQuantity("60", CeRxDomainTestValues.MILLIMETER));
			urg.HighInclusive = true;
			urg.LowInclusive = false;
			string result = new UrgPqPropertyFormatter().Format(GetContext("name", "URG<PQ.BASIC>"), new URGImpl<PQ, PhysicalQuantity
				>(urg));
			AssertXml("result", "<name><low inclusive=\"false\" unit=\"mm\" value=\"55\"/><high inclusive=\"true\" unit=\"mm\" value=\"60\"/></name>"
				, result);
			Assert.IsTrue(this.result.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestBasicForBC()
		{
			UncertainRange<PhysicalQuantity> urg = new UncertainRange<PhysicalQuantity>(new PhysicalQuantity(new BigDecimal(1), null)
				, new PhysicalQuantity(new BigDecimal(124), Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive.GRAMS_PER_LITRE
				), null, null, Representation.LOW_HIGH, Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION, null
				, null, true, false);
			URGImpl<PQ, PhysicalQuantity> dataType = new URGImpl<PQ, PhysicalQuantity>(urg);
			dataType.OriginalText = "<124";
			string result = new UrgPqPropertyFormatter().Format(GetContext("name", "URG<PQ.LAB>", SpecificationVersion.V02R04_BC), dataType
				);
			AssertXml("result", "<name><originalText>&lt;124</originalText><low inclusive=\"true\" nullFlavor=\"NI\" value=\"1\"/><high inclusive=\"false\" unit=\"g/L\" value=\"124\"/></name>"
				, result);
			Assert.IsTrue(this.result.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestNullCase()
		{
			string result = new UrgPqPropertyFormatter().Format(GetContext("name", "URG<PQ.BASIC>"), new URGImpl<PQ, PhysicalQuantity
				>());
			Assert.IsTrue(this.result.IsValid());
			AssertXml("result", "<name nullFlavor=\"NI\"/>", result);
		}

		private PhysicalQuantity CreateQuantity(string quantity, Ca.Infoway.Messagebuilder.Domainvalue.UnitsOfMeasureCaseSensitive
			 unit)
		{
			return new PhysicalQuantity(new BigDecimal(quantity), unit);
		}
	}
}
