using System;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[TestFixture]
	public class RtoPqPqElementParserTest : CeRxDomainValueTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNullNode()
		{
			XmlNode node = CreateNode("<something nullFlavor=\"NI\" />");
			RTO<PhysicalQuantity, PhysicalQuantity> rto = (RTO<PhysicalQuantity, PhysicalQuantity>)new RtoPqPqElementParser().Parse(CreateContext
				(), node, null);
			Assert.IsNull(rto.Value, "value");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION, rto.NullFlavor, "null flavor"
				);
		}

		private ParseContext CreateContext()
		{
			return ParserContextImpl.Create("RTO<PQ,PQ>", typeof(Ratio<object, object>), SpecificationVersion.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.POPULATED);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseEmptyNode()
		{
			XmlNode node = CreateNode("<something/>");
			Ratio<PhysicalQuantity, PhysicalQuantity> ratio = (Ratio<PhysicalQuantity, PhysicalQuantity>)new RtoPqPqElementParser().Parse
				(null, node, null).BareValue;
			Assert.IsNotNull(ratio, "ratio");
			Assert.IsNull(ratio.Numerator, "numerator");
			Assert.IsNull(ratio.Denominator, "denominator");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidAttributes()
		{
			resolver.AddDomainValue(Ca.Infoway.Messagebuilder.Datatype.Lang.UnitsOfMeasureCaseSensitive.MILLIGRAM, typeof(Ca.Infoway.Messagebuilder.Domainvalue.UnitsOfMeasureCaseSensitive
				));
			resolver.AddDomainValue(Ca.Infoway.Messagebuilder.Datatype.Lang.UnitsOfMeasureCaseSensitive.MILLILITRE, typeof(Ca.Infoway.Messagebuilder.Domainvalue.UnitsOfMeasureCaseSensitive
				));
			XmlNode node = CreateNode("<something><numerator value=\"1234.45\" unit=\"mg\"/><denominator value=\"2345.67\" unit=\"ml\" /></something>"
				);
			Ratio<PhysicalQuantity, PhysicalQuantity> ratio = (Ratio<PhysicalQuantity, PhysicalQuantity>)new RtoPqPqElementParser().Parse
				(null, node, null).BareValue;
			Assert.IsNotNull(ratio, "ratio");
			Assert.AreEqual(new BigDecimal("1234.45"), ratio.Numerator.Quantity, "numerator");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Datatype.Lang.UnitsOfMeasureCaseSensitive.MILLIGRAM, ratio.Numerator.Unit, "numerator unit"
				);
			Assert.AreEqual(new BigDecimal("2345.67"), ratio.Denominator.Quantity, "denominator");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Datatype.Lang.UnitsOfMeasureCaseSensitive.MILLILITRE.CodeValue, ratio.Denominator
				.Unit.CodeValue, "denominator unit");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalidValueAttribute()
		{
			XmlNode node = CreateNode("<something><numerator value=\"monkey\" /><denominator value=\"2345.67\" /></something>");
			try
			{
				new RtoPqPqElementParser().Parse(null, node, null);
				Assert.Fail("expected exception");
			}
			catch (FormatException)
			{
			}
		}
		// expected
	}
}
