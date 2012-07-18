using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class IvlTsFullDateTimePropertyFormatterTest : FormatterTestCase
	{
		[System.Serializable]
		public class CustomUnit : EnumPattern, Ca.Infoway.Messagebuilder.Domainvalue.UnitsOfMeasureCaseSensitive
		{
			static CustomUnit()
			{
			}

			private const long serialVersionUID = -8455773998578575019L;

			public static readonly IvlTsFullDateTimePropertyFormatterTest.CustomUnit SANDWICH = new IvlTsFullDateTimePropertyFormatterTest.CustomUnit
				("SANDWICH");

			public static readonly IvlTsFullDateTimePropertyFormatterTest.CustomUnit COFFEE = new IvlTsFullDateTimePropertyFormatterTest.CustomUnit
				("COFFEE");

			public static readonly IvlTsFullDateTimePropertyFormatterTest.CustomUnit NEWSPAPER = new IvlTsFullDateTimePropertyFormatterTest.CustomUnit
				("NEWSPAPER");

			private CustomUnit(string name) : base(name)
			{
			}

			public virtual string CodeSystem
			{
				get
				{
					return null;
				}
			}

			public virtual string CodeValue
			{
				get
				{
					return Name;
				}
			}
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestCustomUnit()
		{
			Interval<PlatformDate> interval = IntervalFactory.CreateWidth<PlatformDate>(new DateDiff(1, IvlTsFullDateTimePropertyFormatterTest.CustomUnit
				.SANDWICH));
			string result = new IvlTsPropertyFormatter().Format(GetContext("name"), new IVLImpl<QTY<PlatformDate>, Interval<PlatformDate
				>>(interval));
			AssertXml("result", "<name><width unit=\"SANDWICH\" value=\"1\"/></name>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestNullable()
		{
			Interval<PlatformDate> interval = IntervalFactory.CreateWidth<PlatformDate>(new DateDiff(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor
				.OTHER));
			string result = new IvlTsPropertyFormatter().Format(GetContext("name"), new IVLImpl<QTY<PlatformDate>, Interval<PlatformDate
				>>(interval));
			AssertXml("result", "<name><width nullFlavor=\"OTH\"/></name>", result);
		}

		protected override FormatContext GetContext(string name)
		{
			return new FormatContextImpl(name, "IVL<TS.FULLDATETIME>", null);
		}
	}
}
