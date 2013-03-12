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
	/// <author>administrator</author>
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

		//Date expectedCalendar = DateUtil.getDate(2008, 2, 31, 10, 58, 57, 862);
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
			SimpleDateFormat tzformat = new SimpleDateFormat("Z");
			string currentTimeZone = tzformat.Format(calendar);
			return currentTimeZone;
		}
	}
}
