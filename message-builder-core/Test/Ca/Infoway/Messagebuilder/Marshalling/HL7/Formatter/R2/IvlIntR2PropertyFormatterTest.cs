using System;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2
{
	[TestFixture]
	public class IvlIntR2PropertyFormatterTest : FormatterTestCase
	{
		private IvlIntR2PropertyFormatter formatter;

		/// <exception cref="System.Exception"></exception>
		[NUnit.Framework.SetUp]
		public virtual void SetUp()
		{
			this.formatter = new IvlIntR2PropertyFormatter();
		}

		protected override FormatContext GetContext(string name)
		{
			return new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(new ModelToXmlResult(), null, name, "IVL<INT>"
				, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.POPULATED, null, false);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestSimpleWithOperator()
		{
			Interval<Int32?> ivl = IntervalFactory.CreateSimple<Int32?>(5, SetOperator.EXCLUDE);
			string result = this.formatter.Format(GetContext("name"), new IVLImpl<QTY<Int32?>, Interval<Int32?>>(ivl));
			AssertXml("result", "<name operator=\"E\" value=\"5\"/>", result);
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
		public virtual void TestBasicWithInclusive()
		{
			Interval<Int32?> ivl = IntervalFactory.CreateLowHigh<Int32?>(1, 3);
			ivl.LowInclusive = true;
			ivl.HighInclusive = false;
			string result = this.formatter.Format(GetContext("name"), new IVLImpl<QTY<Int32?>, Interval<Int32?>>(ivl));
			AssertXml("result", "<name><low inclusive=\"true\" value=\"1\"/><high inclusive=\"false\" value=\"3\"/></name>", result);
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
