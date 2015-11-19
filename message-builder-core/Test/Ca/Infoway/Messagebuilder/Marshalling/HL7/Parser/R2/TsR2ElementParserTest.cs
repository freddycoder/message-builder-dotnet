using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.J5goodies;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2;
using Ca.Infoway.Messagebuilder.Platform;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2
{
	/// <author>Intelliware</author>
	[TestFixture]
	public class TsR2ElementParserTest : MarshallingTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNullNode()
		{
			XmlNode node = CreateNode("<something nullFlavor=\"NI\" />");
			TS_R2 ts = (TS_R2)new TsR2ElementParser().Parse(CreateContext(), node, this.xmlResult);
			Assert.IsNull(ts.Value, "null returned");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION, ts.NullFlavor, "null flavor");
			Assert.IsTrue(this.xmlResult.GetHl7Errors().IsEmpty());
		}

		private ParseContext CreateContext()
		{
			return ParseContextImpl.Create("TS", typeof(PlatformDate), SpecificationVersion.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.POPULATED, null, null, false);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseEmptyNode()
		{
			XmlNode node = CreateNode("<something/>");
			Assert.IsNull(new TsR2ElementParser().Parse(CreateContext(), node, this.xmlResult).BareValue, "null returned");
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNoValueAttributeNode()
		{
			XmlNode node = CreateNode("<something notvalue=\"\" />");
			Assert.IsNull(new TsR2ElementParser().Parse(CreateContext(), node, this.xmlResult).BareValue, "null returned");
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseEmptyValueAttributeNode()
		{
			XmlNode node = CreateNode("<something value=\"\" />");
			Assert.IsNull(new TsR2ElementParser().Parse(CreateContext(), node, this.xmlResult).BareValue, "null returned");
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
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
			string expectedValue = "20080331155857.8620" + GetCurrentTimeZone(calendar);
			AssertValidValueAttribute(calendar, expectedValue);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidValueAttributeWithTimeZonePlusHasCorrectDatePattern()
		{
			PlatformDate calendar = DateUtil.GetDate(2008, 2, 31, 10, 58, 57, 862, TimeZoneUtil.GetTimeZone("America/New_York"));
			string value = "20080331155857.8620+0100";
			AssertValidValueAttribute(calendar, value);
			XmlNode node = CreateNode("<something value=\"" + value + "\" />");
			PlatformDate parsedDate = ((MbDate)(new TsR2ElementParser()).Parse(CreateContext(), node, this.xmlResult).BareValue).Value;
			Assert.IsTrue(parsedDate is DateWithPattern, "is messagebuilder date");
			Assert.AreEqual("yyyyMMddHHmmss.SSS0ZZZZZ", ((DateWithPattern)parsedDate).DatePattern, "correct date pattern");
		}

		/// <exception cref="System.Exception"></exception>
		private void AssertValidValueAttribute(PlatformDate expectedResult, string value)
		{
			XmlNode node = CreateNode("<something value=\"" + value + "\" />");
			object bareValue = new TsR2ElementParser().Parse(CreateContext(), node, this.xmlResult).BareValue;
			AssertDateEquals("correct value returned " + value, MarshallingTestCase.FULL_DATE_TIME, expectedResult, ((MbDate)bareValue
				).Value);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalidValueAttribute()
		{
			XmlNode node = CreateNode("<something value=\"19990355\" />");
			XmlToModelResult result = new XmlToModelResult();
			new TsR2ElementParser().Parse(null, node, result);
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
			string value = "20080625141610" + GetCurrentTimeZone(expectedResult);
			XmlNode node = CreateNode("<something value=\"" + value + "\" />");
			ParseContext context = ParseContextImpl.Create("TS", typeof(PlatformDate), SpecificationVersion.R02_04_02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.POPULATED, null, null, false);
			MbDate mbDate2 = (MbDate)new TsR2ElementParser().Parse(context, node, this.xmlResult).BareValue;
			AssertDateEquals("correct value returned " + value, MarshallingTestCase.FULL_DATE_TIME, expectedResult, mbDate2.Value);
			Assert.AreEqual(0, this.xmlResult.GetHl7Errors().Count, "no error");
			context = ParseContextImpl.Create("TS", typeof(PlatformDate), SpecificationVersion.V01R04_3, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.POPULATED, null, null, false);
			MbDate mbDate = (MbDate)new TsR2ElementParser().Parse(context, node, this.xmlResult).BareValue;
			AssertDateEquals("correct value returned " + value, MarshallingTestCase.FULL_DATE_TIME, expectedResult, mbDate.Value);
			Assert.AreEqual(0, this.xmlResult.GetHl7Errors().Count, "no error");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseDateTimeWithMissingTimezoneForNonCeRx()
		{
			PlatformDate expectedResult = DateUtil.GetDate(2008, 5, 25, 14, 16, 00, 0);
			string value = "200806251416";
			XmlNode node = CreateNode("<something value=\"" + value + "\" />");
			ParseContext context = ParseContextImpl.Create("TS", typeof(PlatformDate), SpecificationVersion.R02_04_02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.POPULATED, null, null, false);
			MbDate mbDate = (MbDate)new TsR2ElementParser().Parse(context, node, this.xmlResult).BareValue;
			AssertDateEquals("correct value returned " + value, MarshallingTestCase.FULL_DATE_TIME, expectedResult, mbDate.Value);
			Assert.IsTrue(this.xmlResult.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseDateTimeWithMissingTimezoneForCeRx()
		{
			PlatformDate expectedResult = DateUtil.GetDate(2008, 5, 25, 14, 16, 00, 0);
			string value = "200806251416";
			XmlNode node = CreateNode("<something value=\"" + value + "\" />");
			ParseContext context = ParseContextImpl.Create("TS", typeof(PlatformDate), SpecificationVersion.V01R04_3, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.POPULATED, null, null, false);
			MbDate mbDate = (MbDate)new TsR2ElementParser().Parse(context, node, this.xmlResult).BareValue;
			AssertDateEquals("correct value returned " + value, MarshallingTestCase.FULL_DATE_TIME, expectedResult, mbDate.Value);
			Assert.AreEqual(0, this.xmlResult.GetHl7Errors().Count, "no timezone missing error");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseFullDatePartTimeWithMissingTimezoneForNonCeRx()
		{
			PlatformDate expectedResult = DateUtil.GetDate(2008, 5, 25, 14, 16, 00, 0);
			string value = "200806251416";
			XmlNode node = CreateNode("<something value=\"" + value + "\" />");
			ParseContext context = ParseContextImpl.Create("TS", typeof(PlatformDate), SpecificationVersion.R02_04_02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.POPULATED, null, null, false);
			MbDate mbDate = (MbDate)new TsR2ElementParser().Parse(context, node, this.xmlResult).BareValue;
			AssertDateEquals("correct value returned " + value, MarshallingTestCase.FULL_DATE_TIME, expectedResult, mbDate.Value);
			Assert.IsTrue(this.xmlResult.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseFullDatePartTimeWithMissingTimezoneForCeRx()
		{
			PlatformDate expectedResult = DateUtil.GetDate(2008, 5, 25, 14, 16, 00, 0);
			string value = "200806251416";
			XmlNode node = CreateNode("<something value=\"" + value + "\" />");
			ParseContext context = ParseContextImpl.Create("TS", typeof(PlatformDate), SpecificationVersion.V01R04_3, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.POPULATED, null, null, false);
			MbDate mbDate = (MbDate)new TsR2ElementParser().Parse(context, node, this.xmlResult).BareValue;
			AssertDateEquals("correct value returned " + value, MarshallingTestCase.FULL_DATE_TIME, expectedResult, mbDate.Value);
			Assert.AreEqual(0, this.xmlResult.GetHl7Errors().Count, "no timezone missing error");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseFullDateTime()
		{
			PlatformDate expectedResult = DateUtil.GetDate(2008, 5, 25, 14, 16, 10, 0);
			string value = "20080625141610" + GetCurrentTimeZone(expectedResult);
			XmlNode node = CreateNode("<something value=\"" + value + "\" />");
			ParseContext context = ParseContextImpl.Create("TS", typeof(PlatformDate), SpecificationVersion.R02_04_02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.POPULATED, null, null, false);
			MbDate mbDate = (MbDate)new TsR2ElementParser().Parse(context, node, this.xmlResult).BareValue;
			AssertDateEquals("correct value returned " + value, MarshallingTestCase.FULL_DATE_TIME, expectedResult, mbDate.Value);
			Assert.IsTrue(this.xmlResult.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseDate()
		{
			PlatformDate expectedResult = DateUtil.GetDate(2008, 5, 25, 0, 0, 0, 0);
			string value = "20080625";
			XmlNode node = CreateNode("<something value=\"" + value + "\" />");
			ParseContext context = ParseContextImpl.Create("TS", typeof(PlatformDate), SpecificationVersion.R02_04_02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.POPULATED, null, null, false);
			MbDate mbDate = (MbDate)new TsR2ElementParser().Parse(context, node, this.xmlResult).BareValue;
			AssertDateEquals("correct value returned " + value, MarshallingTestCase.FULL_DATE, expectedResult, mbDate.Value);
			Assert.IsTrue(this.xmlResult.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueAttributeValidWithOperatorNotAllowed()
		{
			ParseContext context = ParseContextImpl.Create("TS", typeof(PlatformDate), SpecificationVersion.R02_04_02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.POPULATED, null, null, false);
			PlatformDate expectedResult = DateUtil.GetDate(2008, 5, 25, 0, 0, 0, 0);
			string value = "20080625";
			XmlNode node = CreateNode("<something operator=\"P\" value=\"" + value + "\" />");
			BareANY tsAny = new TsR2ElementParser().Parse(context, node, this.xmlResult);
			MbDate mbDate = (MbDate)tsAny.BareValue;
			AssertDateEquals("correct value returned " + value, MarshallingTestCase.FULL_DATE, expectedResult, mbDate.Value);
			Assert.IsNull(((ANYMetaData)tsAny).Operator, "no operator");
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count, "1 error expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueAttributeValidWithOperatorAllowed()
		{
			ParseContext context = ParseContextImpl.Create("SXCM<TS>", typeof(PlatformDate), SpecificationVersion.R02_04_02, null, null
				, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.POPULATED, null, null, false);
			PlatformDate expectedResult = DateUtil.GetDate(2008, 5, 25, 0, 0, 0, 0);
			string value = "20080625";
			XmlNode node = CreateNode("<something operator=\"P\" value=\"" + value + "\" />");
			BareANY tsAny = new TsR2ElementParser().Parse(context, node, this.xmlResult);
			MbDate mbDate = (MbDate)tsAny.BareValue;
			AssertDateEquals("correct value returned " + value, MarshallingTestCase.FULL_DATE, expectedResult, mbDate.Value);
			Assert.IsTrue(this.xmlResult.IsValid(), "no errors");
			Assert.AreEqual(SetOperator.PERIODIC_HULL, ((ANYMetaData)tsAny).Operator, "operator");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueAttributeValidWithDefaultOperator()
		{
			ParseContext context = ParseContextImpl.Create("SXCM<TS>", typeof(PlatformDate), SpecificationVersion.R02_04_02, null, null
				, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.POPULATED, null, null, false);
			PlatformDate expectedResult = DateUtil.GetDate(2008, 5, 25, 0, 0, 0, 0);
			string value = "20080625";
			XmlNode node = CreateNode("<something value=\"" + value + "\" />");
			BareANY tsAny = new TsR2ElementParser().Parse(context, node, this.xmlResult);
			MbDate mbDate = (MbDate)tsAny.BareValue;
			AssertDateEquals("correct value returned " + value, MarshallingTestCase.FULL_DATE, expectedResult, mbDate.Value);
			Assert.IsTrue(this.xmlResult.IsValid(), "no errors");
			Assert.AreEqual(SetOperator.INCLUDE, ((ANYMetaData)tsAny).Operator, "operator");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidFullDateTime()
		{
			PlatformDate expectedResult = DateUtil.GetDate(2008, 5, 25, 14, 16, 10, 0);
			string value = "20080625141610" + GetCurrentTimeZone(expectedResult);
			XmlNode node = CreateNode("<something value=\"" + value + "\" />");
			ParseContext context = ParseContextImpl.Create("TS", typeof(PlatformDate), SpecificationVersion.R02_04_02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.POPULATED, null, null, false);
			MbDate mbDate = (MbDate)new TsR2ElementParser().Parse(context, node, this.xmlResult).BareValue;
			AssertDateEquals("correct value returned " + value, MarshallingTestCase.FULL_DATE_TIME, expectedResult, mbDate.Value);
			Assert.IsTrue(this.xmlResult.GetHl7Errors().IsEmpty(), "no errors");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldBeConvertedDueToTimeZone()
		{
			PlatformDate expectedResult = DateUtil.GetDate(2008, 5, 24, 23, 0, 0, 0, TimeZoneUtil.GetTimeZone("America/New_York"));
			string value = "20080625";
			XmlNode node = CreateNode("<something value=\"" + value + "\" />");
			ParseContext context = ParseContextImpl.Create("TS", typeof(PlatformDate), SpecificationVersion.R02_04_02, TimeZoneUtil.GetTimeZone
				("GMT-3"), TimeZoneUtil.GetTimeZone("GMT-3"), Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.POPULATED, null, null, null
				, null, false);
			MbDate mbDate = (MbDate)new TsR2ElementParser().Parse(context, node, this.xmlResult).BareValue;
			AssertDateEquals("should have been converted due to time zone", MarshallingTestCase.FULL_DATE_TIME, expectedResult, mbDate
				.Value);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void DateShouldBeAffectedByDateTimeZone()
		{
			PlatformDate expectedResult = DateUtil.GetDate(2008, 5, 24, 23, 0, 0, 0, TimeZoneUtil.GetTimeZone("America/New_York"));
			string value = "20080625";
			XmlNode node = CreateNode("<something value=\"" + value + "\" />");
			ParseContext context = ParseContextImpl.Create("TS", typeof(PlatformDate), SpecificationVersion.R02_04_02, TimeZoneUtil.GetTimeZone
				("GMT-3"), TimeZoneUtil.GetTimeZone("GMT-3"), Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.POPULATED, null, null, null
				, null, false);
			MbDate mbDate = (MbDate)new TsR2ElementParser().Parse(context, node, this.xmlResult).BareValue;
			AssertDateEquals("should not be different even though different time zone", MarshallingTestCase.FULL_DATE, expectedResult
				, mbDate.Value);
		}

		private string GetCurrentTimeZone(PlatformDate calendar)
		{
			return DateFormatUtil.Format(calendar, "Z");
		}
	}
}
