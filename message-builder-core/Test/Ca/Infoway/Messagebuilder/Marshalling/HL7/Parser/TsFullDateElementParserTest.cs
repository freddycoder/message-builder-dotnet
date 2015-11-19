using System;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.J5goodies;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[TestFixture]
	public class TsFullDateElementParserTest : MarshallingTestCase
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
			return ParseContextImpl.Create("TS.FULLDATE", typeof(PlatformDate), SpecificationVersion.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.POPULATED, null, null, false);
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
			PlatformDate calendar = DateUtil.GetDate(1999, 2, 3, 0, 0, 0, 0);
			XmlNode node = CreateNode("<something value=\"19990303\" />");
			AssertDateEquals("correct value returned", MarshallingTestCase.FULL_DATE, calendar, (PlatformDate)new TsElementParser().Parse
				(CreateContext(), node, this.xmlResult).BareValue);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidValueAttributePlusExtraAttribute()
		{
			PlatformDate calendar = DateUtil.GetDate(1999, 2, 3, 0, 0, 0, 0);
			XmlNode node = CreateNode("<something extra=\"extra\" value=\"19990303\" />");
			AssertDateEquals("correct value returned", MarshallingTestCase.FULL_DATE, calendar, (PlatformDate)new TsElementParser().Parse
				(CreateContext(), node, this.xmlResult).BareValue);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalidValueAttribute()
		{
			XmlNode node = CreateNode("<something value=\"19990355\" />");
			XmlToModelResult result = new XmlToModelResult();
			new TsElementParser().Parse(new TrivialContext("TS.FULLDATE"), node, result);
			Assert.IsFalse(result.IsValid(), "valid date");
			Assert.AreEqual(1, result.GetHl7Errors().Count, "one error");
			Hl7Error hl7Error = result.GetHl7Errors()[0];
			Assert.AreEqual("The timestamp 19990355 in element <something value=\"19990355\"/> cannot be parsed.", hl7Error.GetMessage
				(), "error message");
			Assert.AreEqual(Hl7ErrorCode.DATA_TYPE_ERROR, hl7Error.GetHl7ErrorCode(), "error message type");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void DateInterpretedAsSaskShouldBeGreaterThanSameTimeInterpretedAsOntario()
		{
			XmlNode node = CreateNode("<something value=\"19990303000000\" />");
			PlatformDate saskDate = ((PlatformDate)new TsElementParser().Parse(CreateContextWithTimeZone(TimeZoneUtil.GetTimeZone("Canada/Saskatchewan"
				)), node, this.xmlResult).BareValue);
			PlatformDate ontarioDate = ((PlatformDate)new TsElementParser().Parse(CreateContextWithTimeZone(TimeZoneUtil.GetTimeZone(
				"Canada/Ontario")), node, this.xmlResult).BareValue);
			Assert.IsTrue(saskDate.CompareTo(ontarioDate) > 0);
		}

		private ParseContext CreateContextWithTimeZone(TimeZoneInfo timeZone)
		{
			return ParseContextImpl.Create("TS.FULLDATE", typeof(PlatformDate), SpecificationVersion.V02R02, timeZone, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.POPULATED, null, null, null, null, false);
		}
	}
}
