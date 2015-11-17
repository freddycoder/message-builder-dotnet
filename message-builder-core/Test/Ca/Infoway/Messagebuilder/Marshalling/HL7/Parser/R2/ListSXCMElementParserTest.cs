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
 * Last modified: $LastChangedDate: 2011-05-04 15:47:15 -0400 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
using System.Collections.Generic;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2;
using Ca.Infoway.Messagebuilder.Xml;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2
{
	[TestFixture]
	public class ListSXCMElementParserTest : ParserTestCase
	{
		private ParserR2Registry parserR2Registry = ParserR2Registry.GetInstance();

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParse()
		{
			XmlNode node = CreateNode("<top xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns=\"urn:hl7-org:v3\" " + "xmlns:cda=\"urn:hl7-org:v3\" xmlns:sdtc=\"urn:hl7-org:sdtc\">"
				 + "<effectiveTime xsi:type=\"IVL_TS\"><low value=\"20120512\"/><high value=\"20120512\"/></effectiveTime>" + "<effectiveTime xsi:type=\"PIVL_TS\" institutionSpecified=\"true\" operator=\"A\"><period value=\"1\" unit=\"h\"/></effectiveTime>"
				 + "</top>");
			ParseContext parseContext = ParseContextImpl.Create("LIST<SXCM<TS>>", null, SpecificationVersion.CCDA_R1_1, null, null, null
				, Cardinality.Create("0-4"), null, true);
			BareANY result = new ListR2ElementParser(this.parserR2Registry).Parse(parseContext, AsList(node.ChildNodes), this.xmlResult
				);
			Assert.IsTrue(this.xmlResult.IsValid());
			IList<MbDate> list = ((LIST<SXCM_R2<MbDate>, MbDate>)result).RawList();
			Assert.IsNotNull(list, "null");
			Assert.AreEqual(2, list.Count, "size");
			DateInterval firstValue = (DateInterval)list[0];
			AssertDateEquals("low", "yyyyMMdd", ParseDate("2012-05-12"), firstValue.Interval.Low);
			AssertDateEquals("high", "yyyyMMdd", ParseDate("2012-05-12"), firstValue.Interval.High);
			PeriodicIntervalTimeR2 secondValue = (PeriodicIntervalTimeR2)list[1];
			Assert.AreEqual(true, secondValue.InstitutionSpecified);
			Assert.AreEqual(new BigDecimal("1"), secondValue.Period.Quantity);
			Assert.AreEqual("h", secondValue.Period.Unit.CodeValue);
		}

		/// <exception cref="ILOG.J2CsMapping.Util.ParseException"></exception>
		private PlatformDate ParseDate(string date)
		{
			return DateUtils.ParseDate(date, new string[] { "yyyy-MM-dd", "yyyy-MM-dd'T'HH:mm:ss" });
		}
	}
}
