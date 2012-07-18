using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class AnyPropertyFormatterTest : FormatterTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestBasic()
		{
			UncertainRange<PhysicalQuantity> urg = UncertainRange<object>.CreateLowHigh(CreateQuantity("55", Ca.Infoway.Messagebuilder.Datatype.Lang.UnitsOfMeasureCaseSensitive
				.MILLIMETER), CreateQuantity("60", Ca.Infoway.Messagebuilder.Datatype.Lang.UnitsOfMeasureCaseSensitive.MILLIMETER));
			URGImpl<PQ, PhysicalQuantity> urgImpl = new URGImpl<PQ, PhysicalQuantity>(urg);
			urgImpl.DataType = StandardDataType.URG_PQ;
			string result = new AnyPropertyFormatter().Format(new FormatContextImpl("name", "ANY.LAB", null), urgImpl, 0);
			AssertXml("result", "<name specializationType=\"URG_PQ\" xsi:type=\"URG_PQ\"><low unit=\"mm\" value=\"55\"/><high unit=\"mm\" value=\"60\"/></name>"
				, result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestNullCase()
		{
			URGImpl<PQ, PhysicalQuantity> urgImpl = new URGImpl<PQ, PhysicalQuantity>();
			urgImpl.DataType = StandardDataType.URG_PQ;
			string result = new AnyPropertyFormatter().Format(new FormatContextImpl("name", "ANY.LAB", null), urgImpl, 0);
			AssertXml("result", "<name nullFlavor=\"NI\"/>", result);
		}

		private PhysicalQuantity CreateQuantity(string quantity, Ca.Infoway.Messagebuilder.Domainvalue.UnitsOfMeasureCaseSensitive
			 unit)
		{
			return new PhysicalQuantity(new BigDecimal(quantity), unit);
		}
	}
}
