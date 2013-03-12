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
 * Author:        $LastChangedBy: tmcgrady $
 * Last modified: $LastChangedDate: 2011-05-04 16:47:15 -0300 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.J5goodies;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	/// <author>administrator</author>
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
			Assert.IsTrue(this.xmlResult.GetHl7Errors().IsEmpty());
		}

		private ParseContext CreateContext()
		{
			return ParserContextImpl.Create("TS", typeof(PlatformDate), SpecificationVersion.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.POPULATED);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseEmptyNode()
		{
			XmlNode node = CreateNode("<something/>");
			Assert.IsNull(new TsElementParser().Parse(CreateContext(), node, this.xmlResult).BareValue, "null returned");
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNoValueAttributeNode()
		{
			XmlNode node = CreateNode("<something notvalue=\"\" />");
			Assert.IsNull(new TsElementParser().Parse(CreateContext(), node, this.xmlResult).BareValue, "null returned");
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseEmptyValueAttributeNode()
		{
			XmlNode node = CreateNode("<something value=\"\" />");
			Assert.IsNull(new TsElementParser().Parse(CreateContext(), node, this.xmlResult).BareValue, "null returned");
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
		public virtual void TestParseDateTimeWithMissingTimezoneForNonCeRx()
		{
			PlatformDate expectedResult = DateUtil.GetDate(2008, 5, 25, 14, 16, 00, 0);
			string value = "200806251416";
			XmlNode node = CreateNode("<something value=\"" + value + "\" />");
			ParseContext context = ParserContextImpl.Create("TS.DATETIME", typeof(PlatformDate), SpecificationVersion.R02_04_02, null
				, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.POPULATED);
			AssertDateEquals("correct value returned " + value, MarshallingTestCase.FULL_DATE_TIME, expectedResult, (PlatformDate)(new 
				TsElementParser()).Parse(context, node, this.xmlResult).BareValue);
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count, "has timezone missing error");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseDateTimeWithMissingTimezoneForCeRx()
		{
			PlatformDate expectedResult = DateUtil.GetDate(2008, 5, 25, 14, 16, 00, 0);
			string value = "200806251416";
			XmlNode node = CreateNode("<something value=\"" + value + "\" />");
			ParseContext context = ParserContextImpl.Create("TS.DATETIME", typeof(PlatformDate), SpecificationVersion.V01R04_3, null, 
				null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.POPULATED);
			AssertDateEquals("correct value returned " + value, MarshallingTestCase.FULL_DATE_TIME, expectedResult, (PlatformDate)(new 
				TsElementParser()).Parse(context, node, this.xmlResult).BareValue);
			Assert.AreEqual(0, this.xmlResult.GetHl7Errors().Count, "no timezone missing error");
		}

		//        assertTrue("no errors after relaxing validation", this.xmlResult.getHl7Errors().isEmpty());
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
			//        assertTrue("no errors after relaxing validation", this.xmlResult.getHl7Errors().isEmpty());
			Assert.IsFalse(this.xmlResult.IsValid(), "no errors after relaxing validation");
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
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
		//Date expectedResult = DateUtil.getDate(2008, 5, 24, 23, 0, 0, 0);
		//Date expectedResult = DateUtil.getDate(2008, 5, 24);
	}
}
