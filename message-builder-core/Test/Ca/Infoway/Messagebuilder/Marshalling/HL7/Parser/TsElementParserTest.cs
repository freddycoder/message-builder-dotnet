using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.J5goodies;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[TestFixture]
	public class TsElementParserTest : MarshallingTestCase
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
			return ParserContextImpl.Create("TS", typeof(PlatformDate), SpecificationVersion.NEWFOUNDLAND, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
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
			PlatformDate calendar = DateUtil.GetDate(1999, 2, 3, 9, 11, 10, 867);
			AssertValidValueAttribute(calendar, "19990303091110.867");
			AssertValidValueAttribute(DateUtil.GetDate(1999, 2, 3, 9, 11, 10, 0), "19990303091110");
			AssertValidValueAttribute(DateUtil.GetDate(1999, 2, 3, 9, 11, 0, 0), "199903030911");
			AssertValidValueAttribute(DateUtil.GetDate(1999, 2, 3, 18, 11, 0, 0), "199903031811");
			AssertValidValueAttribute(DateUtil.GetDate(1999, 2, 3, 9, 0, 0, 0), "1999030309");
			AssertValidValueAttribute(DateUtil.GetDate(1999, 2, 3, 0, 0, 0, 0), "19990303");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidValueAttributeWithTimeZoneMinus()
		{
			PlatformDate calendar = DateUtil.GetDate(2008, 2, 31, 15, 58, 57, 862);
			AssertValidValueAttribute(calendar, "20080331155857.8620-0400");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidValueAttributeWithTimeZonePlusHasCorrectDatePattern()
		{
			PlatformDate calendar = DateUtil.GetDate(2008, 2, 31, 10, 58, 57, 862);
			string value = "20080331155857.8620+0100";
			AssertValidValueAttribute(calendar, value);
			XmlNode node = CreateNode("<something value=\"" + value + "\" />");
			PlatformDate parsedDate = (PlatformDate)(new TsElementParser()).Parse(CreateContext(), node, this.xmlResult).BareValue;
			Assert.IsTrue(parsedDate is DateWithPattern, "is messagebuilder date");
			Assert.AreEqual("yyyyMMddHHmmss.SSS0ZZZZZ", ((DateWithPattern)parsedDate).DatePattern, "correct date pattern");
		}

		/// <exception cref="System.Exception"></exception>
		private void AssertValidValueAttribute(PlatformDate expectedResult, string value)
		{
			XmlNode node = CreateNode("<something value=\"" + value + "\" />");
			AssertDateEquals("correct value returned " + value, MarshallingTestCase.FULL_DATE_TIME, expectedResult, (PlatformDate)(new 
				TsElementParser()).Parse(CreateContext(), node, this.xmlResult).BareValue);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalidValueAttribute()
		{
			XmlNode node = CreateNode("<something value=\"19990355\" />");
			XmlToModelResult result = new XmlToModelResult();
			new TsElementParser().Parse(null, node, result);
			Assert.IsFalse(result.IsValid(), "valid date");
			Assert.AreEqual(1, result.GetHl7Errors().Count, "one error");
			Hl7Error hl7Error = result.GetHl7Errors()[0];
			Assert.AreEqual("The timestamp 19990355 in element <something value=\"19990355\"/> cannot be parsed.", hl7Error.GetMessage
				(), "error message");
			Assert.AreEqual(Hl7ErrorCode.DATA_TYPE_ERROR, hl7Error.GetHl7ErrorCode(), "error message type");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidDateForExceptionCase()
		{
			PlatformDate expectedResult = DateUtil.GetDate(2008, 5, 25, 14, 16, 10, 0);
			string value = "20080625141610-0400";
			XmlNode node = CreateNode("<something value=\"" + value + "\" />");
			ParseContext context = ParserContextImpl.Create("TS.FULLDATETIME", typeof(PlatformDate), SpecificationVersion.R02_04_02, 
				null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.POPULATED);
			AssertDateEquals("correct value returned " + value, MarshallingTestCase.FULL_DATE_TIME, expectedResult, (PlatformDate)(new 
				TsElementParser()).Parse(context, node, this.xmlResult).BareValue);
			Assert.AreEqual(0, this.xmlResult.GetHl7Errors().Count, "no error");
			context = ParserContextImpl.Create("TS.FULLDATETIME", typeof(PlatformDate), SpecificationVersion.V01R04_3, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.POPULATED);
			AssertDateEquals("correct value returned " + value, MarshallingTestCase.FULL_DATE_TIME, expectedResult, (PlatformDate)(new 
				TsElementParser()).Parse(context, node, this.xmlResult).BareValue);
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count, "one error");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNoFullDateTimeSpecificationTypeForAbstractFullDateWithTime()
		{
			PlatformDate expectedResult = DateUtil.GetDate(2008, 5, 25, 14, 16, 10, 0);
			string value = "20080625141610-0400";
			XmlNode node = CreateNode("<something value=\"" + value + "\" />");
			ParseContext context = ParserContextImpl.Create("TS.FULLDATEWITHTIME", typeof(PlatformDate), SpecificationVersion.R02_04_02
				, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.POPULATED);
			AssertDateEquals("correct value returned " + value, MarshallingTestCase.FULL_DATE_TIME, expectedResult, (PlatformDate)(new 
				TsElementParser()).Parse(context, node, this.xmlResult).BareValue);
			Assert.IsTrue(this.xmlResult.GetHl7Errors().IsEmpty(), "no errors after relaxing validation");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNoFullDateSpecificationTypeForAbstractFullDateWithTime()
		{
			PlatformDate expectedResult = DateUtil.GetDate(2008, 5, 25, 0, 0, 0, 0);
			string value = "20080625";
			XmlNode node = CreateNode("<something value=\"" + value + "\" />");
			ParseContext context = ParserContextImpl.Create("TS.FULLDATEWITHTIME", typeof(PlatformDate), SpecificationVersion.R02_04_02
				, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.POPULATED);
			AssertDateEquals("correct value returned " + value, MarshallingTestCase.FULL_DATE, expectedResult, (PlatformDate)(new TsElementParser
				()).Parse(context, node, this.xmlResult).BareValue);
			Assert.IsTrue(this.xmlResult.GetHl7Errors().IsEmpty(), "no errors after relaxing validation");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalidSpecificationTypeForAbstractFullDateWithTime()
		{
			PlatformDate expectedResult = DateUtil.GetDate(2008, 5, 25, 0, 0, 0, 0);
			string value = "20080625";
			XmlNode node = CreateNode("<something value=\"" + value + "\" specializationType=\"TS.DATETIME\" />");
			ParseContext context = ParserContextImpl.Create("TS.FULLDATEWITHTIME", typeof(PlatformDate), SpecificationVersion.R02_04_02
				, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.POPULATED);
			AssertDateEquals("correct value returned " + value, MarshallingTestCase.FULL_DATE, expectedResult, (PlatformDate)(new TsElementParser
				()).Parse(context, node, this.xmlResult).BareValue);
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count, "one error");
			Assert.IsTrue(this.xmlResult.GetHl7Errors()[0].GetMessage().StartsWith("Invalid specialization type TS.DATETIME"), "specialization type error"
				);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidFullDateSpecificationTypeForAbstractFullDateWithTime()
		{
			PlatformDate expectedResult = DateUtil.GetDate(2008, 5, 25, 0, 0, 0, 0);
			string value = "20080625";
			XmlNode node = CreateNode("<something value=\"" + value + "\" specializationType=\"TS.FULLDATE\" />");
			ParseContext context = ParserContextImpl.Create("TS.FULLDATEWITHTIME", typeof(PlatformDate), SpecificationVersion.R02_04_02
				, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.POPULATED);
			AssertDateEquals("correct value returned " + value, MarshallingTestCase.FULL_DATE, expectedResult, (PlatformDate)(new TsElementParser
				()).Parse(context, node, this.xmlResult).BareValue);
			Assert.IsTrue(this.xmlResult.GetHl7Errors().IsEmpty(), "no errors");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidFullDateTimeSpecificationTypeForAbstractFullDateWithTime()
		{
			PlatformDate expectedResult = DateUtil.GetDate(2008, 5, 25, 14, 16, 10, 0);
			string value = "20080625141610-0400";
			XmlNode node = CreateNode("<something value=\"" + value + "\" specializationType=\"TS.FULLDATETIME\" />");
			ParseContext context = ParserContextImpl.Create("TS.FULLDATEWITHTIME", typeof(PlatformDate), SpecificationVersion.R02_04_02
				, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.POPULATED);
			AssertDateEquals("correct value returned " + value, MarshallingTestCase.FULL_DATE_TIME, expectedResult, (PlatformDate)(new 
				TsElementParser()).Parse(context, node, this.xmlResult).BareValue);
			Assert.IsTrue(this.xmlResult.GetHl7Errors().IsEmpty(), "no errors");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidFullDateTimeButWithFullDateSpecificationTypeForAbstractFullDateWithTime()
		{
			PlatformDate expectedResult = DateUtil.GetDate(2008, 5, 25, 14, 16, 10, 0);
			string value = "20080625141610-0400";
			XmlNode node = CreateNode("<something value=\"" + value + "\" specializationType=\"TS.FULLDATE\" />");
			ParseContext context = ParserContextImpl.Create("TS.FULLDATEWITHTIME", typeof(PlatformDate), SpecificationVersion.R02_04_02
				, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.POPULATED);
			AssertDateEquals("correct value returned " + value, MarshallingTestCase.FULL_DATE_TIME, expectedResult, (PlatformDate)(new 
				TsElementParser()).Parse(context, node, this.xmlResult).BareValue);
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count, "one error");
			Assert.IsTrue(this.xmlResult.GetHl7Errors()[0].GetMessage().Equals("The timestamp element <something specializationType=\"TS.FULLDATE\" value=\"20080625141610-0400\"/> appears to be formatted as type TS.FULLDATETIME, but should be TS.FULLDATE."
				), "specialization type error");
		}
	}
}
