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
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.J5goodies;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2;
using Ca.Infoway.Messagebuilder.Resolver.Configurator;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2
{
	[TestFixture]
	public class PivlTsR2PropertyFormatterTest : FormatterTestCase
	{
		[SetUp]
		public virtual void Setup()
		{
			DefaultCodeResolutionConfigurator.ConfigureCodeResolversWithTrivialDefault();
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFullPivl()
		{
			PlatformDate lowDate = DateUtil.GetDate(1999, 0, 23);
			PlatformDate lowDateWithPattern = new DateWithPattern(lowDate, "yyyyMMdd");
			PlatformDate highDate = DateUtil.GetDate(2013, 4, 7);
			PlatformDate highDateWithPattern = new DateWithPattern(highDate, "yyyyMMdd");
			Interval<PlatformDate> phase = IntervalFactory.CreateLowHigh(lowDateWithPattern, highDateWithPattern);
			PhysicalQuantity period = new PhysicalQuantity(new BigDecimal(11), Ca.Infoway.Messagebuilder.Domainvalue.Basic.DefaultTimeUnit
				.DAY);
			PeriodicIntervalTimeR2 pivl = new PeriodicIntervalTimeR2(phase, period, CalendarCycle.DAY_OF_THE_MONTH, true, null, null);
			string result = new PivlTsR2PropertyFormatter().Format(GetContext("periodicInterval", "PIVL<TS>"), new PIVL_R2Impl(pivl));
			Assert.IsTrue(this.result.IsValid());
			AssertXml("result", "<periodicInterval alignment=\"D\" institutionSpecified=\"true\"><phase><low value=\"19990123\"/><high value=\"20130507\"/></phase><period unit=\"d\" value=\"11\"/></periodicInterval>"
				, result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestNoValue()
		{
			string result = new PivlTsR2PropertyFormatter().Format(GetContext("periodicInterval", "PIVL<TS>"), new PIVL_R2Impl((PeriodicIntervalTimeR2
				)null));
			Assert.IsTrue(this.result.IsValid());
			AssertXml("result", "<periodicInterval nullFlavor=\"NI\"/>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestNullFlavor()
		{
			string result = new PivlTsR2PropertyFormatter().Format(GetContext("periodicInterval", "PIVL<TS>"), new PIVL_R2Impl(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor
				.TEMPORARILY_UNAVAILABLE));
			Assert.IsTrue(this.result.IsValid());
			AssertXml("result", "<periodicInterval nullFlavor=\"NAV\"/>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestMissingValues()
		{
			PeriodicIntervalTimeR2 pivl = new PeriodicIntervalTimeR2((Interval<PlatformDate>)null, (PhysicalQuantity)null);
			string result = new PivlTsR2PropertyFormatter().Format(GetContext("periodicInterval", "PIVL<TS>"), new PIVL_R2Impl(pivl));
			// from a strict reading of the schema, this is a perfectly valid PIVL_TS
			AssertXml("result", "<periodicInterval></periodicInterval>", result);
			Assert.IsTrue(this.result.IsValid());
		}
	}
}
