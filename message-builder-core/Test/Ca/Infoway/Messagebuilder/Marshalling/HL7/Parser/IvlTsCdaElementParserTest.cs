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
 * Author:        $LastChangedBy: gng $
 * Last modified: $LastChangedDate: 2015-11-19 18:20:12 -0500 (Fri, 30 Jan 2015) $
 * Revision:      $LastChangedRevision: 9755 $
 */


using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.J5goodies;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Xml;
using ILOG.J2CsMapping.Collections.Generics;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[TestFixture]
	public class IvlTsCdaElementParserTest : MarshallingTestCase
	{
		private IvlTsCdaElementParser parser = new IvlTsCdaElementParser();

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestIvlTs()
		{
			XmlToModelResult result = new XmlToModelResult();
			XmlNode node = CreateNode("<ivl><low value=\"20120503\"/><high value=\"20120708\"/></ivl>");
			ParseContext context = ParseContextImpl.Create("IVLTSCDAR1", null, SpecificationVersion.R02_04_03, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.MANDATORY, Cardinality.Create("1"), null, true);
			BareANY parseResult = this.parser.Parse(context, Arrays.AsList(node), result);
			PlatformDate dateLow = DateUtil.GetDate(2012, 4, 3);
			DateWithPattern dateWithPatternLow = new DateWithPattern(dateLow, "yyyyMMdd");
			PlatformDate dateHigh = DateUtil.GetDate(2012, 6, 8);
			DateWithPattern dateWithPatternHigh = new DateWithPattern(dateHigh, "yyyyMMdd");
			Interval<PlatformDate> expectedIvl = IntervalFactory.CreateLowHigh((PlatformDate)dateWithPatternLow, (PlatformDate)dateWithPatternHigh
				);
			Assert.IsTrue(result.IsValid());
			Assert.IsTrue(parseResult is IVLTSCDAR1);
			DateInterval ivl = (DateInterval)parseResult.BareValue;
			Assert.AreEqual(expectedIvl, ivl.Interval);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestIvlTsConstraintsValid()
		{
			XmlToModelResult result = new XmlToModelResult();
			XmlNode node = CreateNode("<ivl><low value=\"20120503\"/><high value=\"20120708\"/></ivl>");
			ConstrainedDatatype constraints = new ConstrainedDatatype("ivl", "IVL<TS>");
			constraints.Relationships.Add(new Relationship("low", "TS", Cardinality.Create("1")));
			constraints.Relationships.Add(new Relationship("high", "TS", Cardinality.Create("1")));
			ParseContext context = ParseContextImpl.Create("IVLTSCDAR1", null, SpecificationVersion.R02_04_03, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.MANDATORY, Cardinality.Create("1"), constraints, true);
			BareANY parseResult = this.parser.Parse(context, Arrays.AsList(node), result);
			PlatformDate dateLow = DateUtil.GetDate(2012, 4, 3);
			DateWithPattern dateWithPatternLow = new DateWithPattern(dateLow, "yyyyMMdd");
			PlatformDate dateHigh = DateUtil.GetDate(2012, 6, 8);
			DateWithPattern dateWithPatternHigh = new DateWithPattern(dateHigh, "yyyyMMdd");
			Interval<PlatformDate> expectedIvl = IntervalFactory.CreateLowHigh((PlatformDate)dateWithPatternLow, (PlatformDate)dateWithPatternHigh
				);
			Assert.IsTrue(result.IsValid());
			Assert.IsTrue(parseResult is IVLTSCDAR1);
			DateInterval ivl = (DateInterval)parseResult.BareValue;
			Assert.AreEqual(expectedIvl, ivl.Interval);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestIvlTsConstraintsInvalid()
		{
			XmlToModelResult result = new XmlToModelResult();
			XmlNode node = CreateNode("<ivl><low value=\"20120503\"/><high value=\"20120708\"/></ivl>");
			ConstrainedDatatype constraints = new ConstrainedDatatype("ivl", "IVL<TS>");
			constraints.Relationships.Add(new Relationship("low", "TS", Cardinality.Create("0")));
			constraints.Relationships.Add(new Relationship("high", "TS", Cardinality.Create("0")));
			ParseContext context = ParseContextImpl.Create("IVLTSCDAR1", null, SpecificationVersion.R02_04_03, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.MANDATORY, Cardinality.Create("1"), constraints, true);
			BareANY parseResult = this.parser.Parse(context, Arrays.AsList(node), result);
			PlatformDate dateLow = DateUtil.GetDate(2012, 4, 3);
			DateWithPattern dateWithPatternLow = new DateWithPattern(dateLow, "yyyyMMdd");
			PlatformDate dateHigh = DateUtil.GetDate(2012, 6, 8);
			DateWithPattern dateWithPatternHigh = new DateWithPattern(dateHigh, "yyyyMMdd");
			Interval<PlatformDate> expectedIvl = IntervalFactory.CreateLowHigh((PlatformDate)dateWithPatternLow, (PlatformDate)dateWithPatternHigh
				);
			Assert.IsFalse(result.IsValid());
			Assert.AreEqual(2, result.GetHl7Errors().Count);
			Assert.IsTrue(parseResult is IVLTSCDAR1);
			DateInterval ivl = (DateInterval)parseResult.BareValue;
			Assert.AreEqual(expectedIvl, ivl.Interval);
		}
	}
}
