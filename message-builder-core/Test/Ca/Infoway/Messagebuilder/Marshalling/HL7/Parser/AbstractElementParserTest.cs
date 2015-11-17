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
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[TestFixture]
	public class AbstractElementParserTest
	{
		[Test]
		public virtual void ShouldConvertSpecializationType()
		{
			AbstractElementParser parser = new _AbstractElementParser_39();
			Assert.AreEqual("ST", parser.ConvertSpecializationType("ST"));
			Assert.AreEqual("ST", parser.ConvertSpecializationType("ST.CA"));
			Assert.AreEqual("ST.LANG", parser.ConvertSpecializationType("ST.LANG"));
			Assert.AreEqual("LIST<ST>", parser.ConvertSpecializationType("LIST_ST.CA"));
			Assert.AreEqual("CV", parser.ConvertSpecializationType("CV"));
			Assert.AreEqual("CV", parser.ConvertSpecializationType("CV.CA"));
			Assert.AreEqual("RTO<PQ,PQ>", parser.ConvertSpecializationType("RTO_PQ_PQ"));
			Assert.AreEqual("RTO<PQ,PQ>", parser.ConvertSpecializationType("RTO_PQ.CA_PQ.CA"));
			Assert.AreEqual("SET<RTO<PQ,PQ>>", parser.ConvertSpecializationType("SET_RTO_PQ_PQ"));
			Assert.AreEqual("LIST<RTO<PQ,PQ>>", parser.ConvertSpecializationType("LIST_RTO_PQ_PQ"));
			Assert.AreEqual("RTO<MO,PQ>", parser.ConvertSpecializationType("RTO_MO_PQ"));
			Assert.AreEqual("II.PUBLIC", parser.ConvertSpecializationType("II.PUBLIC"));
			Assert.AreEqual("CV", parser.ConvertSpecializationType("cv.ca"));
			Assert.AreEqual("RTO<PQ,PQ>", parser.ConvertSpecializationType("rto_pq_pq"));
		}

		private sealed class _AbstractElementParser_39 : AbstractElementParser
		{
			public _AbstractElementParser_39()
			{
			}

			/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
			public override BareANY Parse(ParseContext context, IList<XmlNode> node, XmlToModelResult xmlToModelResult)
			{
				return null;
			}
		}
	}
}
