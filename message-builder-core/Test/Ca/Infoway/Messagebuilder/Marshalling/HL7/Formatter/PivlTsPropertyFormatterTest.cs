using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Resolver.Configurator;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class PivlTsPropertyFormatterTest : FormatterTestCase
	{
		[SetUp]
		public virtual void Setup()
		{
			DefaultCodeResolutionConfigurator.ConfigureCodeResolversWithTrivialDefault();
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestBasicCase()
		{
			PhysicalQuantity quantity = new PhysicalQuantity(new BigDecimal(1), Ca.Infoway.Messagebuilder.Domainvalue.Basic.DefaultTimeUnit
				.DAY);
			PeriodicIntervalTime frequency = PeriodicIntervalTime.CreateFrequency(3, quantity);
			string result = new PivlTsPropertyFormatter().Format(GetContext("periodicInterval", "PIVL<TS.DATETIME>"), new PIVLImpl(frequency
				));
			Assert.IsTrue(this.result.IsValid());
			AssertXml("result", "<periodicInterval><frequency><numerator value=\"3\"/><denominator unit=\"d\" value=\"1\"/></frequency></periodicInterval>"
				, result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestBasicCaseForSk()
		{
			PhysicalQuantity lowQuantity = new PhysicalQuantity(new BigDecimal(1), Ca.Infoway.Messagebuilder.Domainvalue.Basic.DefaultTimeUnit
				.DAY);
			PhysicalQuantity highQuantity = new PhysicalQuantity(new BigDecimal(4), Ca.Infoway.Messagebuilder.Domainvalue.Basic.DefaultTimeUnit
				.DAY);
			PeriodicIntervalTimeSk frequencySk = PeriodicIntervalTimeSk.CreateFrequencySk(3, lowQuantity, highQuantity);
			string result = new PivlTsPropertyFormatter().Format(GetContextSk("periodicInterval", "PIVL<TS.DATETIME>"), new PIVLImpl(
				frequencySk));
			Assert.IsTrue(this.result.IsValid());
			AssertXml("result", "<periodicInterval><frequency><numerator value=\"3\"/><denominator><low unit=\"d\" value=\"1\"/><high unit=\"d\" value=\"4\"/></denominator></frequency></periodicInterval>"
				, result);
		}

		protected virtual FormatContext GetContextSk(string name, string type)
		{
			return new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(this.result, null, name, type, null, null
				, false, SpecificationVersion.V01R04_2_SK, null, null, null, false);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestNoObject()
		{
			string result = new PivlTsPropertyFormatter().Format(GetContext("periodicInterval", "PIVL<TS.DATETIME>"), new PIVLImpl((PeriodicIntervalTime
				)null));
			Assert.IsTrue(this.result.IsValid());
			AssertXml("result", "<periodicInterval nullFlavor=\"NI\"/>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestMissingValues()
		{
			PeriodicIntervalTime frequency = PeriodicIntervalTime.CreateFrequency(null, null);
			string result = new PivlTsPropertyFormatter().Format(GetContext("periodicInterval", "PIVL<TS.DATETIME>"), new PIVLImpl(frequency
				));
			AssertXml("result", "<periodicInterval></periodicInterval>", result);
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestMissingValuesSk()
		{
			PeriodicIntervalTimeSk frequencySk = PeriodicIntervalTimeSk.CreateFrequencySk(null, null, null);
			string result = new PivlTsPropertyFormatter().Format(GetContextSk("periodicInterval", "PIVL<TS.DATETIME>"), new PIVLImpl(
				frequencySk));
			AssertXml("result", "<periodicInterval></periodicInterval>", result);
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestMissingQuantitiesSk()
		{
			PeriodicIntervalTimeSk frequencySk = PeriodicIntervalTimeSk.CreateFrequencySk(2, null, null);
			string result = new PivlTsPropertyFormatter().Format(GetContextSk("periodicInterval", "PIVL<TS.DATETIME>"), new PIVLImpl(
				frequencySk));
			AssertXml("result", "<periodicInterval></periodicInterval>", result);
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
		}
	}
}
