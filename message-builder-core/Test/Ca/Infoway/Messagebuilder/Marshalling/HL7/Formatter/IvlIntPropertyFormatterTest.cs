using System;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class IvlIntPropertyFormatterTest : FormatterTestCase
	{
		private IvlIntPropertyFormatter formatter;

		/// <exception cref="System.Exception"></exception>
		[NUnit.Framework.SetUp]
		public virtual void SetUp()
		{
			this.formatter = new IvlIntPropertyFormatter();
		}

		protected override FormatContext GetContext(string name)
		{
			return new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(new ModelToXmlResult(), null, name, "IVL<INT>"
				, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.POPULATED, null, false);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestBasic()
		{
			Interval<Int32?> ivl = IntervalFactory.CreateLowHigh<Int32?>(1, 3);
			string result = this.formatter.Format(GetContext("name"), new IVLImpl<QTY<Int32?>, Interval<Int32?>>(ivl));
			AssertXml("result", "<name><low value=\"1\"/><high value=\"3\"/></name>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestIntervalLow()
		{
			Interval<Int32?> ivl = IntervalFactory.CreateLow<Int32?>(1);
			string result = this.formatter.Format(GetContext("name"), new IVLImpl<QTY<Int32?>, Interval<Int32?>>(ivl));
			AssertXml("result", "<name><low value=\"1\"/></name>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestNullCase()
		{
			string result = this.formatter.Format(GetContext("name"), new IVLImpl<QTY<Int32?>, Interval<Int32?>>());
			AssertXml("result", "<name nullFlavor=\"NI\"/>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestIntervalWidth()
		{
			Interval<Int32?> ivl = IntervalFactory.CreateWidth<Int32?>(new Diff<Int32?>(2));
			string result = this.formatter.Format(GetContext("name"), new IVLImpl<QTY<Int32?>, Interval<Int32?>>(ivl));
			AssertXml("result", "<name><width value=\"2\"/></name>", result);
		}
	}
}
