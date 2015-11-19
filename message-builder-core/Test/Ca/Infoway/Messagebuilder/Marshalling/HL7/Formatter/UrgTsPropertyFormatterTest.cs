using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.J5goodies;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Resolver.Configurator;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class UrgTsPropertyFormatterTest : FormatterTestCase
	{
		[SetUp]
		public virtual void Setup()
		{
			DefaultCodeResolutionConfigurator.ConfigureCodeResolversWithTrivialDefault();
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestBasic()
		{
			UncertainRange<PlatformDate> urg = UncertainRangeFactory.CreateLowHigh(DateUtil.GetDate(2010, 0, 20), DateUtil.GetDate(2011
				, 1, 21));
			string result = new UrgTsPropertyFormatter().Format(GetContext("name", "URG<TS.DATE>"), new URGImpl<TS, PlatformDate>(urg
				));
			Assert.IsTrue(this.result.IsValid());
			AssertXml("result", "<name><low value=\"20100120\"/><high value=\"20110221\"/></name>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestBasicWithInvalidInclusiveUsage()
		{
			UncertainRange<PlatformDate> urg = UncertainRangeFactory.CreateLowHigh(DateUtil.GetDate(2010, 0, 20), DateUtil.GetDate(2011
				, 1, 21));
			urg.HighInclusive = true;
			string result = new UrgTsPropertyFormatter().Format(GetContext("name", "URG<TS.DATE>"), new URGImpl<TS, PlatformDate>(urg
				));
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			// should not use inclusive fields with this datatype
			AssertXml("result", "<name><low value=\"20100120\"/><high value=\"20110221\"/></name>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestNullCase()
		{
			string result = new UrgTsPropertyFormatter().Format(GetContext("name", "URG<TS.DATE>"), new URGImpl<TS, PlatformDate>());
			Assert.IsTrue(this.result.IsValid());
			AssertXml("result", "<name nullFlavor=\"NI\"/>", result);
		}
	}
}
