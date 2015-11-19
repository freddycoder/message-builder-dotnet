using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.J5goodies;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[TestFixture]
	public class UrgTsElementParserTest : CeRxDomainValueTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParse()
		{
			XmlNode node = CreateNode("<effectiveTime xsi:type=\"URG_TS\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">" +
				 "<center xsi:type=\"TS\" specializationType=\"TS.DATE\" value=\"200404\"/>" + "<width xsi:type=\"PQ\" specializationType=\"PQ.TIME\" value=\"4\" unit=\"mo\"/>"
				 + "</effectiveTime>");
			UncertainRange<PlatformDate> range = (UncertainRange<PlatformDate>)new UrgTsElementParser().Parse(CreateContext(), node, 
				this.xmlResult).BareValue;
			Assert.IsNotNull(range, "null");
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual(DateUtil.GetDate(2004, 1, 1), range.Low, "low");
			Assert.AreEqual(DateUtil.GetDate(2004, 3, 1), range.Centre, "centre");
			Assert.AreEqual(DateUtil.GetDate(2004, 5, 1), range.High, "high");
			Assert.AreEqual(new BigDecimal("4"), ((DateDiff)range.Width).ValueAsPhysicalQuantity.Quantity, "width");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Basic.DefaultTimeUnit.MONTH.CodeValue, ((DateDiff)range.Width).ValueAsPhysicalQuantity
				.Unit.CodeValue, "width units");
			Assert.AreEqual(Representation.CENTRE_WIDTH, range.Representation, "representation");
			Assert.IsNull(range.LowInclusive);
			Assert.IsNull(range.HighInclusive);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseWithLowHighInclusiveAttributes()
		{
			XmlNode node = CreateNode("<effectiveTime>" + "<low inclusive=\"true\" value=\"20040101\"/>" + "<high inclusive=\"true\" value=\"20040501\"/>"
				 + "</effectiveTime>");
			UncertainRange<PlatformDate> range = (UncertainRange<PlatformDate>)new UrgTsElementParser().Parse(CreateContext(), node, 
				this.xmlResult).BareValue;
			PlatformDate lowDate = DateUtil.GetDate(2004, 0, 1);
			PlatformDate highDate = DateUtil.GetDate(2004, 4, 1);
			// inclusive usage is not allowed in this case as per pan-Canadian specs
			Assert.IsNotNull(range, "null");
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(2, this.xmlResult.GetHl7Errors().Count);
			Assert.AreEqual(lowDate, range.Low, "low");
			Assert.AreEqual(new PlatformDate(lowDate.Time + (highDate.Time - lowDate.Time) / 2), range.Centre, "centre");
			Assert.AreEqual(highDate, range.High, "high");
			Assert.AreEqual(highDate.Time - lowDate.Time, range.Width.Value.Time, "width");
			Assert.AreEqual(Representation.LOW_HIGH, range.Representation, "representation");
			Assert.IsTrue(range.LowInclusive.Value);
			Assert.IsTrue(range.HighInclusive.Value);
		}

		private ParseContext CreateContext()
		{
			return ParseContextImpl.Create("URG<TS.DATE>", null, SpecificationVersion.R02_04_02, null, null, null, null, null, null, 
				null, false);
		}
	}
}
