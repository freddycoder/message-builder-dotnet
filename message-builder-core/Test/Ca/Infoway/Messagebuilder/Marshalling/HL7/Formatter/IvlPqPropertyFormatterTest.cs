using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class IvlPqPropertyFormatterTest : FormatterTestCase
	{
		private static readonly PhysicalQuantity PHYSICAL_QUANTITY_LOW = new PhysicalQuantity(new BigDecimal(1000), Ca.Infoway.Messagebuilder.Datatype.Lang.UnitsOfMeasureCaseSensitive
			.MILLILITRE);

		private static readonly PhysicalQuantity PHYSICAL_QUANTITY_HIGH = new PhysicalQuantity(new BigDecimal(2000), Ca.Infoway.Messagebuilder.Datatype.Lang.UnitsOfMeasureCaseSensitive
			.MILLILITRE);

		private IvlPqPropertyFormatter formatter;

		/// <exception cref="System.Exception"></exception>
		[NUnit.Framework.SetUp]
		public virtual void SetUp()
		{
			this.formatter = new IvlPqPropertyFormatter();
		}

		protected override FormatContext GetContext(string name)
		{
			return new FormatContextImpl(name, "IVL<PQ>", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.POPULATED);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestBasic()
		{
			Interval<PhysicalQuantity> interval = IntervalFactory.CreateLowHigh<PhysicalQuantity>(PHYSICAL_QUANTITY_LOW, PHYSICAL_QUANTITY_HIGH
				);
			string result = this.formatter.Format(GetContext("name"), new IVLImpl<QTY<PhysicalQuantity>, Interval<PhysicalQuantity>>(
				interval));
			AssertXml("result", "<name><low unit=\"ml\" value=\"1000\"/><high unit=\"ml\" value=\"2000\"/></name>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestIntervalLow()
		{
			Interval<PhysicalQuantity> low = IntervalFactory.CreateLow<PhysicalQuantity>(PHYSICAL_QUANTITY_LOW);
			string result = this.formatter.Format(GetContext("name"), new IVLImpl<QTY<PhysicalQuantity>, Interval<PhysicalQuantity>>(
				low));
			AssertXml("result", "<name><low unit=\"ml\" value=\"1000\"/></name>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestNullCase()
		{
			string result = this.formatter.Format(GetContext("name"), new IVLImpl<QTY<PhysicalQuantity>, Interval<PhysicalQuantity>>(
				));
			AssertXml("result", "<name nullFlavor=\"NI\"/>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestIntervalWidth()
		{
			Interval<PhysicalQuantity> interval = IntervalFactory.CreateWidth<PhysicalQuantity>(new Diff<PhysicalQuantity>(PHYSICAL_QUANTITY_LOW
				));
			string result = this.formatter.Format(GetContext("name"), new IVLImpl<QTY<PhysicalQuantity>, Interval<PhysicalQuantity>>(
				interval));
			AssertXml("result", "<name><width unit=\"ml\" value=\"1000\"/></name>", result);
		}
	}
}
