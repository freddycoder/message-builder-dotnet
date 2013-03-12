/**
 * Copyright 2013 Canada Health Infoway, Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *        http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 * Author:        $LastChangedBy: tmcgrady $
 * Last modified: $LastChangedDate: 2011-05-04 16:47:15 -0300 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
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
			return GetContext(name, "IVL<TS.FULLDATE>", SpecificationVersion.R02_04_03);
		}

		protected override FormatContext GetContext(string name, string type, VersionNumber version)
		{
			return new FormatContextImpl(this.result, null, name, type, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.POPULATED, false
				, version, null, null, null);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestBasic()
		{
			Interval<PlatformDate> interval = IntervalFactory.CreateLowHigh<PlatformDate>(ParseDate("2006-12-25"), ParseDate("2007-01-02"
				));
			string result = this.formatter.Format(GetContext("name"), new IVLImpl<QTY<PlatformDate>, Interval<PlatformDate>>(interval
				));
			Assert.IsTrue(this.result.IsValid());
			AssertXml("result", "<name><low value=\"20061225\"/><high value=\"20070102\"/></name>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestInvalidIntervalLow()
		{
			Interval<PlatformDate> interval = IntervalFactory.CreateLow<PlatformDate>(ParseDate("2006-12-25"));
			string result = this.formatter.Format(GetContext("name"), new IVLImpl<QTY<PlatformDate>, Interval<PlatformDate>>(interval
				));
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			AssertXml("result", "<name><low value=\"20061225\"/></name>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestInvalidIntervalLow2()
		{
			Interval<PlatformDate> interval = IntervalFactory.CreateLow<PlatformDate>(ParseDate("2006-12-25"));
			string result = this.formatter.Format(GetContext("name", "IVL.HIGH<TS.FULLDATE>", SpecificationVersion.R02_04_02), new IVLImpl
				<QTY<PlatformDate>, Interval<PlatformDate>>(interval));
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(2, this.result.GetHl7Errors().Count);
			// low invalid; must supply high
			AssertXml("result", "<name><low value=\"20061225\"/></name>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestInvalidIntervalHigh()
		{
			Interval<PlatformDate> interval = IntervalFactory.CreateHigh<PlatformDate>(ParseDate("2006-12-25"));
			string result = this.formatter.Format(GetContext("name", "IVL.WIDTH<TS.FULLDATE>", SpecificationVersion.R02_04_02), new IVLImpl
				<QTY<PlatformDate>, Interval<PlatformDate>>(interval));
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(2, this.result.GetHl7Errors().Count);
			// high invalid; must supply width
			AssertXml("result", "<name><high value=\"20061225\"/></name>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestIntervalWidthWithDecimals()
		{
			Interval<PlatformDate> interval = IntervalFactory.CreateWidth<PlatformDate>(new DateDiff(new PhysicalQuantity(new BigDecimal
				("1.5"), Ca.Infoway.Messagebuilder.Domainvalue.Basic.DefaultTimeUnit.MONTH)));
			string result = this.formatter.Format(GetContext("name"), new IVLImpl<QTY<PlatformDate>, Interval<PlatformDate>>(interval
				));
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			// must have 2 of width/low/high
			AssertXml("result", "<name><width unit=\"mo\" value=\"1.5\"/></name>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestIntervalSimple()
		{
			Interval<PlatformDate> interval = IntervalFactory.CreateSimple<PlatformDate>(ParseDate("2006-12-25"));
			string result = this.formatter.Format(GetContext("name"), new IVLImpl<QTY<PlatformDate>, Interval<PlatformDate>>(interval
				));
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			// must have 2 of width/low/high
			AssertXml("result", "<name value=\"20061225\"/>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestNullCase()
		{
			string result = this.formatter.Format(GetContext("name"), new IVLImpl<QTY<PlatformDate>, Interval<PlatformDate>>());
			Assert.IsTrue(this.result.IsValid());
			AssertXml("result", "<name nullFlavor=\"NI\"/>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestNullCaseMasked()
		{
			IVLImpl<QTY<PlatformDate>, Interval<PlatformDate>> dataType = new IVLImpl<QTY<PlatformDate>, Interval<PlatformDate>>();
			dataType.NullFlavor = Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.MASKED;
			string result = this.formatter.Format(GetContext("name"), dataType);
			Assert.IsTrue(this.result.IsValid());
			AssertXml("result", "<name nullFlavor=\"MSK\"/>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestInvalidIntervalWidth()
		{
			Diff<PlatformDate> diff = new Diff<PlatformDate>(new PlatformDate(15 * DateUtils.MILLIS_PER_DAY));
			Interval<PlatformDate> interval = IntervalFactory.CreateWidth<PlatformDate>(diff);
			string result = this.formatter.Format(GetContext("name"), new IVLImpl<QTY<PlatformDate>, Interval<PlatformDate>>(interval
				));
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			AssertXml("result", "<name><width unit=\"d\" value=\"15\"/></name>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestIntervalWidth()
		{
			Diff<PlatformDate> diff = new Diff<PlatformDate>(new PlatformDate(15 * DateUtils.MILLIS_PER_DAY));
			Interval<PlatformDate> interval = IntervalFactory.CreateWidth<PlatformDate>(diff);
			string result = this.formatter.Format(GetContext("name", "IVL.WIDTH<TS.FULLDATE>", SpecificationVersion.R02_04_03), new IVLImpl
				<QTY<PlatformDate>, Interval<PlatformDate>>(interval));
			Assert.IsTrue(this.result.IsValid());
			AssertXml("result", "<name><width unit=\"d\" value=\"15\"/></name>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestIntervalLow()
		{
			Interval<PlatformDate> interval = IntervalFactory.CreateLow<PlatformDate>(ParseDate("2006-12-25"));
			string result = this.formatter.Format(GetContext("name", "IVL.LOW<TS.FULLDATE>", SpecificationVersion.R02_04_03), new IVLImpl
				<QTY<PlatformDate>, Interval<PlatformDate>>(interval));
			Assert.IsTrue(this.result.IsValid());
			AssertXml("result", "<name><low value=\"20061225\"/></name>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestIntervalHigh()
		{
			Interval<PlatformDate> interval = IntervalFactory.CreateHigh<PlatformDate>(ParseDate("2006-12-25"));
			string result = this.formatter.Format(GetContext("name", "IVL.HIGH<TS.FULLDATE>", SpecificationVersion.R02_04_03), new IVLImpl
				<QTY<PlatformDate>, Interval<PlatformDate>>(interval));
			Assert.IsTrue(this.result.IsValid());
			AssertXml("result", "<name><high value=\"20061225\"/></name>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestIntervalLowWidth()
		{
			Diff<PlatformDate> diff = new Diff<PlatformDate>(new PlatformDate(15 * DateUtils.MILLIS_PER_DAY));
			Interval<PlatformDate> interval = IntervalFactory.CreateLowWidth<PlatformDate>(ParseDate("2007-02-20T15:34:22"), diff);
			string result = this.formatter.Format(GetContext("name"), new IVLImpl<QTY<PlatformDate>, Interval<PlatformDate>>(interval
				));
			Assert.IsTrue(this.result.IsValid());
			AssertXml("result", "<name><low value=\"20070220\"/><width unit=\"d\" value=\"15\"/></name>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestIntervalLowHighWithNullFlavor()
		{
			Interval<PlatformDate> interval = IntervalFactory.CreateLowHigh<PlatformDate>(ParseDate("2007-02-20T15:34:22"), null, null
				, Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.MASKED);
			string result = this.formatter.Format(GetContext("name"), new IVLImpl<QTY<PlatformDate>, Interval<PlatformDate>>(interval
				));
			Assert.IsTrue(this.result.IsValid());
			AssertXml("result", "<name><low value=\"20070220\"/><high nullFlavor=\"MSK\"/></name>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestIntervalLowHighWithInvalidNullFlavor()
		{
			Interval<PlatformDate> interval = IntervalFactory.CreateLowHigh<PlatformDate>(ParseDate("2007-02-20T15:34:22"), null, null
				, Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.POSITIVE_INFINITY);
			string result = this.formatter.Format(GetContext("name"), new IVLImpl<QTY<PlatformDate>, Interval<PlatformDate>>(interval
				));
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			AssertXml("result", "<name><low value=\"20070220\"/><high nullFlavor=\"PINF\"/></name>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestIntervalLowHighWithInvalidNullFlavor2()
		{
			Interval<PlatformDate> interval = IntervalFactory.CreateLowHigh<PlatformDate>(ParseDate("2007-02-20T15:34:22"), null, null
				, Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NEGATIVE_INFINITY);
			string result = this.formatter.Format(GetContext("name"), new IVLImpl<QTY<PlatformDate>, Interval<PlatformDate>>(interval
				));
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			AssertXml("result", "<name><low value=\"20070220\"/><high nullFlavor=\"NINF\"/></name>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestIntervalLowWidthInvalidUnits()
		{
			PhysicalQuantity quantity = new PhysicalQuantity(new BigDecimal(15), Ca.Infoway.Messagebuilder.Domainvalue.Basic.DefaultTimeUnit
				.MINUTE);
			Diff<PlatformDate> diff = new DateDiff(quantity);
			Interval<PlatformDate> interval = IntervalFactory.CreateLowWidth<PlatformDate>(ParseDate("2007-02-20T15:34:22"), diff);
			string result = this.formatter.Format(GetContext("name"), new IVLImpl<QTY<PlatformDate>, Interval<PlatformDate>>(interval
				));
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			AssertXml("result", "<name><low value=\"20070220\"/><width unit=\"min\" value=\"15\"/></name>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestIntervalLowMissingOther()
		{
			Interval<PlatformDate> interval = IntervalFactory.CreateLow<PlatformDate>(ParseDate("2007-02-20T15:34:22"));
			string result = this.formatter.Format(GetContext("name"), new IVLImpl<QTY<PlatformDate>, Interval<PlatformDate>>(interval
				));
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			AssertXml("result", "<name><low value=\"20070220\"/></name>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestIntervalLowMissingOther2()
		{
			Interval<PlatformDate> interval = IntervalFactory.CreateLow<PlatformDate>(ParseDate("2007-02-20T15:34:22"));
			string result = this.formatter.Format(GetContext("name"), new IVLImpl<QTY<PlatformDate>, Interval<PlatformDate>>(interval
				));
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			// must have 2 of width/low/high
			AssertXml("result", "<name><low value=\"20070220\"/></name>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestBasicAbstract()
		{
			Interval<PlatformDate> interval = IntervalFactory.CreateLowHigh<PlatformDate>(ParseDate("2006-12-25"), ParseDate("2007-01-02"
				));
			IVLImpl<QTY<PlatformDate>, Interval<PlatformDate>> hl7DataType = new IVLImpl<QTY<PlatformDate>, Interval<PlatformDate>>(interval
				);
			hl7DataType.DataType = StandardDataType.IVL_FULL_DATE;
			string result = this.formatter.Format(new FormatContextImpl(this.result, null, "name", "IVL<TS.FULLDATEWITHTIME>", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.POPULATED, false, SpecificationVersion.R02_04_03, null, null, null), hl7DataType);
			Assert.IsTrue(this.result.IsValid());
			AssertXml("result", "<name specializationType=\"IVL_TS.FULLDATE\" xsi:type=\"IVL_TS\"><low specializationType=\"TS.FULLDATE\" value=\"20061225\" xsi:type=\"TS\"/><high specializationType=\"TS.FULLDATE\" value=\"20070102\" xsi:type=\"TS\"/></name>"
				, result);
		}
	}
}
