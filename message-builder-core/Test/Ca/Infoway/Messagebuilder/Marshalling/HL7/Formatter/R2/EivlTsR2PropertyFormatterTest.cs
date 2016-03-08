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
 * Author:        $LastChangedBy: gng $
 * Last modified: $LastChangedDate: 2015-11-19 18:20:12 -0500 (Fri, 30 Jan 2015) $
 * Revision:      $LastChangedRevision: 9755 $
 */


using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2
{
	[TestFixture]
	public class EivlTsR2PropertyFormatterTest : FormatterTestCase
	{
		[TearDown]
		public virtual void Teardown()
		{
			this.result.ClearErrors();
		}

		private Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl CreateContext(string type)
		{
			return new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(this.result, null, "eventRelatedPeriod", 
				type, null, null, false, SpecificationVersion.R02_04_03, null, null, null, false);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestImpliedNullValue()
		{
			string result = new EivlTsR2PropertyFormatter().Format(CreateContext("EIVL<TS>"), new TELImpl());
			Assert.IsTrue(this.result.IsValid());
			AssertXml("xml output", "<eventRelatedPeriod nullFlavor=\"NI\"/>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestNullValue()
		{
			string result = new EivlTsR2PropertyFormatter().Format(CreateContext("EIVL<TS>"), new TELImpl(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor
				.NOT_APPLICABLE));
			Assert.IsTrue(this.result.IsValid());
			AssertXml("xml output", "<eventRelatedPeriod nullFlavor=\"NA\"/>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestEivlTsFull()
		{
			PhysicalQuantity low = new PhysicalQuantity(new BigDecimal("120"), Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive
				.CENTIMETRE);
			PhysicalQuantity high = new PhysicalQuantity(new BigDecimal("170"), Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive
				.CENTIMETRE);
			Interval<PhysicalQuantity> ivl = IntervalFactory.CreateLowHigh(low, high);
			TimingEvent timingEvent = Ca.Infoway.Messagebuilder.Domainvalue.Basic.TimingEvent.ACM;
			EventRelatedPeriodicIntervalTime @event = new EventRelatedPeriodicIntervalTime(ivl, timingEvent);
			string result = new EivlTsR2PropertyFormatter().Format(CreateContext("EIVL<TS>"), new EIVLImpl<EventRelatedPeriodicIntervalTime
				>(@event));
			Assert.IsTrue(this.result.IsValid());
			AssertXml("xml output", "<eventRelatedPeriod><event code=\"ACM\" codeSystem=\"2.16.840.1.113883.5.139\" codeSystemName=\"TimingEvent\" displayName=\"Acm\"/><offset><low unit=\"cm\" value=\"120\"/><high unit=\"cm\" value=\"170\"/></offset></eventRelatedPeriod>"
				, result, true);
		}
	}
}
