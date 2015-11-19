using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2
{
	[TestFixture]
	public class EivlTsR2ElementParserTest : CeRxDomainValueTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNullNode()
		{
			XmlNode node = CreateNode("<something nullFlavor=\"NI\" />");
			EIVL<EventRelatedPeriodicIntervalTime> tel = (EIVL<EventRelatedPeriodicIntervalTime>)new EivlTsR2ElementParser().Parse(CreateContext
				("EIVL<TS>", SpecificationVersion.V02R02), node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.IsNull(tel.Value, "null returned");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION, tel.NullFlavor, "null flavor"
				);
		}

		private ParseContext CreateContext(string type, VersionNumber version)
		{
			return ParseContextImpl.Create(type, typeof(EventRelatedPeriodicIntervalTime), version, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.POPULATED, null, null, false);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseEmptyNode()
		{
			XmlNode node = CreateNode("<something/>");
			new EivlTsR2ElementParser().Parse(CreateContext("EIVL<TS>", SpecificationVersion.V02R02), node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNoValueAttributeNode()
		{
			XmlNode node = CreateNode("<something notvalue=\"\" />");
			new EivlTsR2ElementParser().Parse(CreateContext("EIVL<TS>", SpecificationVersion.V02R02), node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseAll()
		{
			XmlNode node = CreateNode("<eventRelatedPeriod>" + "<event code=\"ACM\" codeSystem=\"2.16.840.1.113883.5.139\" codeSystemName=\"TimingEvent\"/>"
				 + "<offset>" + "<low unit=\"cm\" value=\"120\"/>" + "<high unit=\"cm\" value=\"170\"/>" + "</offset>" + "</eventRelatedPeriod>"
				);
			EventRelatedPeriodicIntervalTime address = (EventRelatedPeriodicIntervalTime)new EivlTsR2ElementParser().Parse(CreateContext
				("EIVL<TS>", SpecificationVersion.R02_04_03), node, this.xmlResult).BareValue;
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual("ACM", address.Event.CodeValue);
			Assert.AreEqual(new BigDecimal("120"), address.Offset.Low.Quantity);
			Assert.AreEqual("cm", address.Offset.Low.Unit.CodeValue);
			Assert.AreEqual(new BigDecimal("170"), address.Offset.High.Quantity);
			Assert.AreEqual("cm", address.Offset.High.Unit.CodeValue);
		}
	}
}
