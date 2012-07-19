using System;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.J5goodies;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using ILOG.J2CsMapping.Text;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[TestFixture]
	public class TsFullDateTimeElementParserTest : MarshallingTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNullNode()
		{
			XmlNode node = CreateNode("<something nullFlavor=\"NI\" />");
			TS ts = (TS)new TsElementParser().Parse(CreateContext(), node, this.xmlResult);
			Assert.IsNull(ts.Value, "null returned");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION, ts.NullFlavor, "null flavor");
		}

		private ParseContext CreateContext()
		{
			return ParserContextImpl.Create("TS.FULLDATETIME", typeof(PlatformDate), SpecificationVersion.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.POPULATED);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseEmptyNode()
		{
			XmlNode node = CreateNode("<something/>");
			Assert.IsNull(new TsElementParser().Parse(CreateContext(), node, this.xmlResult).BareValue, "null returned");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNoValueAttributeNode()
		{
			XmlNode node = CreateNode("<something notvalue=\"\" />");
			Assert.IsNull(new TsElementParser().Parse(CreateContext(), node, this.xmlResult).BareValue, "null returned");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidValueAttribute()
		{
			PlatformDate calendar = DateUtil.GetDate(1999, 2, 3, 10, 11, 12, 0);
			XmlNode node = CreateNode("<something value=\"19990303101112\" />");
			AssertDateEquals("correct value returned", MarshallingTestCase.FULL_DATE_TIME, calendar, (PlatformDate)new TsElementParser
				().Parse(CreateContext(), node, this.xmlResult).BareValue);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueInWrongFormat()
		{
			XmlNode node = CreateNode("<something value=\"19990303\" />");
			Assert.IsNotNull(new TsElementParser().Parse(CreateContext(), node, this.xmlResult).BareValue, "correct value returned");
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count, "error");
			System.Console.Out.WriteLine(this.xmlResult.GetHl7Errors()[0].GetMessage());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidValueAttributePlusExtraAttribute()
		{
			PlatformDate calendar = DateUtil.GetDate(1999, 2, 3, 10, 11, 12, 0);
			XmlNode node = CreateNode("<something extra=\"extra\" value=\"19990303101112\" />");
			AssertDateEquals("correct value returned", MarshallingTestCase.FULL_DATE_TIME, calendar, (PlatformDate)new TsElementParser
				().Parse(CreateContext(), node, this.xmlResult).BareValue);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidValueAttributeWithTimeZoneMinus()
		{
			PlatformDate calendar = DateUtil.GetDate(2008, 2, 31, 15, 58, 57, 862);
			string value = "20080331155857.8620" + GetCurrentTimeZone(calendar);
			XmlNode node = CreateNode("<something extra=\"extra\" value=\"" + value + "\" />");
			AssertDateEquals("correct value returned", MarshallingTestCase.FULL_DATE_TIME, calendar, (PlatformDate)new TsElementParser
				().Parse(CreateContext(), node, this.xmlResult).BareValue);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidValueAttributeWithTimeZonePlus()
		{
			//Date expectedCalendar = DateUtil.getDate(2008, 2, 31, 10, 58, 57, 862);
            DateTime date = DateUtil.GetDate(2008, 2, 31, 10, 58, 57, 862);
            DateTime calWithTZ = TimeZoneInfo.ConvertTime(date, TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"));
            PlatformDate expectedCalendar = new PlatformDate(calWithTZ);
			XmlNode node = CreateNode("<something extra=\"extra\" value=\"20080331155857.8620+0100\" />");
			AssertDateEquals("correct value returned", MarshallingTestCase.FULL_DATE_TIME, expectedCalendar, (PlatformDate)new TsElementParser
				().Parse(CreateContext(), node, this.xmlResult).BareValue);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalidValueAttribute()
		{
			XmlNode node = CreateNode("<something value=\"19990355101112\" />");
			new TsElementParser().Parse(CreateContext(), node, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid(), "valid date");
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count, "one error");
			Hl7Error hl7Error = this.xmlResult.GetHl7Errors()[0];
			Assert.AreEqual("The timestamp 19990355101112 in element <something value=\"19990355101112\"/> cannot be parsed.", hl7Error
				.GetMessage(), "error message");
			Assert.AreEqual(Hl7ErrorCode.DATA_TYPE_ERROR, hl7Error.GetHl7ErrorCode(), "error message type");
		}

		private ParseContext CreateContextWithTimeZone(TimeZone timeZone)
		{
			return ParserContextImpl.Create("TS.FULLDATETIME", typeof(PlatformDate), SpecificationVersion.V02R02, null, timeZone, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.POPULATED, null, null);
		}

		private string GetCurrentTimeZone(PlatformDate calendar)
		{
            DateTimeOffset expectedDate1 = TimeZoneInfo.ConvertTime(calendar, TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"));
            String timeZoneString = expectedDate1.Offset.ToString().Split(":")[0];
            String currentTimeZone = timeZoneString;
            while (currentTimeZone.Length <= 4)
            {
                currentTimeZone += "0";
            }
            return currentTimeZone;
		}
	}
}
