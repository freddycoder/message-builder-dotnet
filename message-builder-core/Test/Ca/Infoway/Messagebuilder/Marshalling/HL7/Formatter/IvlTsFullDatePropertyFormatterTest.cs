using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class IvlTsFullDatePropertyFormatterTest : FormatterTestCase
	{
		private IvlTsPropertyFormatter formatter;

		/// <exception cref="System.Exception"></exception>
		[NUnit.Framework.SetUp]
		public virtual void SetUp()
		{
			this.formatter = new IvlTsPropertyFormatter();
		}

		protected override FormatContext GetContext(string name)
		{
			return new FormatContextImpl(name, "IVL<TS.FULLDATE>", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.POPULATED);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestBasic()
		{
			Interval<PlatformDate> interval = IntervalFactory.CreateLowHigh<PlatformDate>(ParseDate("2006-12-25"), ParseDate("2007-01-02"
				));
			string result = this.formatter.Format(GetContext("name"), new IVLImpl<QTY<PlatformDate>, Interval<PlatformDate>>(interval
				));
			AssertXml("result", "<name><low value=\"20061225\"/><high value=\"20070102\"/></name>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestIntervalLow()
		{
			Interval<PlatformDate> interval = IntervalFactory.CreateLow<PlatformDate>(ParseDate("2006-12-25"));
			string result = this.formatter.Format(GetContext("name"), new IVLImpl<QTY<PlatformDate>, Interval<PlatformDate>>(interval
				));
			AssertXml("result", "<name><low value=\"20061225\"/></name>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestIntervalWidthWithDecimals()
		{
			Interval<PlatformDate> interval = IntervalFactory.CreateWidth<PlatformDate>(new DateDiff(new PhysicalQuantity(new BigDecimal
				("1.5"), DefaultTimeUnit.MONTH)));
			string result = this.formatter.Format(GetContext("name"), new IVLImpl<QTY<PlatformDate>, Interval<PlatformDate>>(interval
				));
			AssertXml("result", "<name><width unit=\"mo\" value=\"1.5\"/></name>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestIntervalSimple()
		{
			Interval<PlatformDate> interval = IntervalFactory.CreateSimple<PlatformDate>(ParseDate("2006-12-25"));
			string result = this.formatter.Format(GetContext("name"), new IVLImpl<QTY<PlatformDate>, Interval<PlatformDate>>(interval
				));
			AssertXml("result", "<name value=\"20061225\"/>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestNullCase()
		{
			string result = this.formatter.Format(GetContext("name"), new IVLImpl<QTY<PlatformDate>, Interval<PlatformDate>>());
			AssertXml("result", "<name nullFlavor=\"NI\"/>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestIntervalWidth()
		{
			Diff<PlatformDate> diff = new Diff<PlatformDate>(new PlatformDate(15 * DateUtils.MILLIS_PER_DAY));
			Interval<PlatformDate> interval = IntervalFactory.CreateWidth<PlatformDate>(diff);
			string result = this.formatter.Format(GetContext("name"), new IVLImpl<QTY<PlatformDate>, Interval<PlatformDate>>(interval
				));
			AssertXml("result", "<name><width unit=\"d\" value=\"15\"/></name>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestIntervalLowWidth()
		{
			Diff<PlatformDate> diff = new Diff<PlatformDate>(new PlatformDate(15 * DateUtils.MILLIS_PER_DAY));
			Interval<PlatformDate> interval = IntervalFactory.CreateLowWidth<PlatformDate>(ParseDate("2007-02-20T15:34:22"), diff);
			string result = this.formatter.Format(GetContext("name"), new IVLImpl<QTY<PlatformDate>, Interval<PlatformDate>>(interval
				));
			AssertXml("result", "<name><low value=\"20070220\"/><width unit=\"d\" value=\"15\"/></name>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestBasicAbstract()
		{
			Interval<PlatformDate> interval = IntervalFactory.CreateLowHigh<PlatformDate>(ParseDate("2006-12-25"), ParseDate("2007-01-02"
				));
			IVLImpl<QTY<PlatformDate>, Interval<PlatformDate>> hl7DataType = new IVLImpl<QTY<PlatformDate>, Interval<PlatformDate>>(interval
				);
			hl7DataType.DataType = StandardDataType.TS_FULLDATEWITHTIME;
			string result = this.formatter.Format(new FormatContextImpl("name", "IVL<TS.FULLDATE>", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.POPULATED, true, null, null, null), hl7DataType);
			AssertXml("result", "<name specializationType=\"IVL_TS.FULLDATE\" xsi:type=\"IVL_TS\"><low specializationType=\"TS.FULLDATE\" value=\"20061225\" xsi:type=\"TS\"/><high specializationType=\"TS.FULLDATE\" value=\"20070102\" xsi:type=\"TS\"/></name>"
				, result);
		}
	}
}
