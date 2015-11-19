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
