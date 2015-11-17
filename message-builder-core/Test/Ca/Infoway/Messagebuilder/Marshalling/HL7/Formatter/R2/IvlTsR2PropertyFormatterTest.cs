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
 * Last modified: $LastChangedDate: 2011-05-04 15:47:15 -0400 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
using System;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.J5goodies;
using Ca.Infoway.Messagebuilder.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2
{
	[TestFixture]
	public class IvlTsR2PropertyFormatterTest : FormatterTestCase
	{
		[System.Serializable]
		public class CustomUnit : EnumPattern, Ca.Infoway.Messagebuilder.Domainvalue.UnitsOfMeasureCaseSensitive
		{
			static CustomUnit()
			{
			}

			private const long serialVersionUID = -8455773998578575019L;

			public static readonly IvlTsR2PropertyFormatterTest.CustomUnit SANDWICH = new IvlTsR2PropertyFormatterTest.CustomUnit("SANDWICH"
				);

			public static readonly IvlTsR2PropertyFormatterTest.CustomUnit COFFEE = new IvlTsR2PropertyFormatterTest.CustomUnit("COFFEE"
				);

			public static readonly IvlTsR2PropertyFormatterTest.CustomUnit NEWSPAPER = new IvlTsR2PropertyFormatterTest.CustomUnit("NEWSPAPER"
				);

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

			public virtual string CodeSystemName
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
			Interval<PlatformDate> interval = IntervalFactory.CreateWidth<PlatformDate>(new DateDiff(1, IvlTsR2PropertyFormatterTest.CustomUnit
				.SANDWICH));
			DateInterval dateInterval = new DateInterval(interval);
			IVL_TSImpl hl7DataType = new IVL_TSImpl(dateInterval);
			hl7DataType.DataType = StandardDataType.IVL_TS;
			string result = new IvlTsR2PropertyFormatter().Format(GetContext("name"), hl7DataType);
			AssertXml("result", "<name><width unit=\"SANDWICH\" value=\"1\"/></name>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestNullable()
		{
			Interval<PlatformDate> interval = IntervalFactory.CreateWidth<PlatformDate>(new DateDiff(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor
				.OTHER));
			DateInterval dateInterval = new DateInterval(interval);
			IVL_TSImpl hl7DataType = new IVL_TSImpl(dateInterval);
			hl7DataType.DataType = StandardDataType.IVL_TS;
			string result = new IvlTsR2PropertyFormatter().Format(GetContext("name"), hl7DataType);
			AssertXml("result", "<name><width nullFlavor=\"OTH\"/></name>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestIntervalNull()
		{
			DateInterval dateInterval = null;
			IVL_TSImpl hl7DataType = new IVL_TSImpl(dateInterval);
			hl7DataType.DataType = StandardDataType.IVL_TS;
			string result = new IvlTsR2PropertyFormatter().Format(GetContext("name"), hl7DataType);
			AssertXml("result", "<name nullFlavor=\"NI\"/>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestWrapperNull()
		{
			IVL_TSImpl hl7DataType = null;
			string result = new IvlTsR2PropertyFormatter().Format(GetContext("name"), hl7DataType);
			Assert.AreEqual(string.Empty, result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestBasicAbstract()
		{
			TimeZoneInfo timeZone = TimeZoneUtil.GetTimeZone("America/Toronto");
			Interval<PlatformDate> interval = IntervalFactory.CreateLowHigh<PlatformDate>(DateUtil.GetDate(2006, 11, 25, 11, 12, 13, 
				0, timeZone), DateUtil.GetDate(2007, 0, 2, 10, 11, 12, 0, timeZone));
			DateInterval dateInterval = new DateInterval(interval);
			IVL_TSImpl hl7DataType = new IVL_TSImpl(dateInterval);
			hl7DataType.DataType = StandardDataType.IVL_TS;
			string result = new IvlTsR2PropertyFormatter().Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(this.result, null, "name", "IVL<TS>", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.POPULATED, null, false, SpecificationVersion
				.V02R02, timeZone, timeZone, null, false), hl7DataType);
			Assert.IsTrue(this.result.IsValid());
			AssertXml("result", "<name><low value=\"20061225111213.0000-0500\"/><high value=\"20070102101112.0000-0500\"/></name>", result
				);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestBasicPartTime()
		{
			TimeZoneInfo timeZone = TimeZoneUtil.GetTimeZone("America/Toronto");
			PlatformDate lowDate = new DateWithPattern(DateUtil.GetDate(2006, 11, 25, 11, 12, 13, 0, timeZone), "yyyyMMddHHZZZZZ");
			PlatformDate highDate = new DateWithPattern(DateUtil.GetDate(2007, 0, 2, 10, 11, 12, 0, timeZone), "yyyyMMddHHZZZZZ");
			Interval<PlatformDate> interval = IntervalFactory.CreateLowHigh<PlatformDate>(lowDate, highDate);
			DateInterval dateInterval = new DateInterval(interval);
			IVL_TSImpl hl7DataType = new IVL_TSImpl(dateInterval);
			hl7DataType.DataType = StandardDataType.IVL_TS;
			string result = new IvlTsR2PropertyFormatter().Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(this.result, null, "name", "IVL<TS>", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.POPULATED, null, false, SpecificationVersion
				.V02R02, timeZone, timeZone, null, false), hl7DataType);
			Assert.IsTrue(this.result.IsValid());
			AssertXml("result", "<name><low value=\"2006122511-0500\"/><high value=\"2007010210-0500\"/></name>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestBasic()
		{
			TimeZoneInfo timeZone = TimeZoneUtil.GetTimeZone("America/Toronto");
			Interval<PlatformDate> interval = IntervalFactory.CreateLowHigh<PlatformDate>(DateUtil.GetDate(2006, 11, 25, 11, 12, 13, 
				0, timeZone), DateUtil.GetDate(2007, 0, 2, 10, 11, 12, 0, timeZone));
			DateInterval dateInterval = new DateInterval(interval);
			IVL_TSImpl hl7DataType = new IVL_TSImpl(dateInterval);
			hl7DataType.DataType = StandardDataType.IVL_TS;
			string result = new IvlTsR2PropertyFormatter().Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(this.result, null, "name", "IVL<TS>", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.POPULATED, null, false, SpecificationVersion
				.V02R02, timeZone, timeZone, null, false), hl7DataType);
			Assert.IsTrue(this.result.IsValid());
			AssertXml("result", "<name><low value=\"20061225111213.0000-0500\"/><high value=\"20070102101112.0000-0500\"/></name>", result
				);
		}

		protected override FormatContext GetContext(string name)
		{
			return new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(new ModelToXmlResult(), null, name, "IVL<TS>"
				, null, null, false);
		}
	}
}
