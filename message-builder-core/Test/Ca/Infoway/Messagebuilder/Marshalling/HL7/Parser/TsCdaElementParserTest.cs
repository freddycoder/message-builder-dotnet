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
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.J5goodies;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Xml;
using ILOG.J2CsMapping.Collections.Generics;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[TestFixture]
	public class TsCdaElementParserTest : MarshallingTestCase
	{
		private TsCdaElementParser parser = new TsCdaElementParser();

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestTsCda()
		{
			PlatformDate expectedDate = DateUtil.GetDate(2012, 4, 3);
			XmlNode node = CreateNode("<date value=\"20120503\"/>");
			ParseContext context = ParseContextImpl.Create("TSCDAR1", null, SpecificationVersion.R02_04_03, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.MANDATORY, Cardinality.Create("1"), null, true);
			BareANY parseResult = this.parser.Parse(context, Arrays.AsList(node), this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.IsTrue(parseResult is TSCDAR1);
			Assert.IsTrue(parseResult.BareValue is MbDate);
			Assert.AreEqual(expectedDate, ((MbDate)parseResult.BareValue).Value);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestSxcmTs()
		{
			PlatformDate expectedDate = DateUtil.GetDate(2012, 4, 3);
			XmlNode node = CreateNode("<date operator=\"E\" value=\"20120503\"/>");
			ParseContext context = ParseContextImpl.Create("SXCMTSCDAR1", null, SpecificationVersion.R02_04_03, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.MANDATORY, Cardinality.Create("1"), null, true);
			BareANY parseResult = this.parser.Parse(context, Arrays.AsList(node), this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.IsTrue(parseResult is SXCMTSCDAR1);
			Assert.IsTrue(parseResult.BareValue is MbDate);
			Assert.AreEqual(expectedDate, ((MbDate)parseResult.BareValue).Value);
		}
	}
}
