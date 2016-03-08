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


using Ca.Infoway.Messagebuilder.Xml;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Xml
{
	[TestFixture]
	public class CodedTypeEvaluatorTest
	{
		[Test]
		public virtual void TestCodedTypes()
		{
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("ANY"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("ANY.LAB"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("ANY.CA.IZ"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("ANY.PATH"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("ANY.X1"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("ANY.X2"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("AD"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("AD.BASIC"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("AD.FULL"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("AD.SEARCH"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("BL"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("BN"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("ON"));
			Assert.IsTrue(CodedTypeEvaluator.IsCodedType("SC"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("EN"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("TN"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("QTY"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("GTS"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("GTS.BOUNDEDPIVL"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("II"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("II.TOKEN"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("II.BUS"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("II.PUBLIC"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("II.OID"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("II.VER"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("II.PUBLICVER"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("II.BUS_AND_VER"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("II.BUSVER"));
			Assert.IsTrue(CodedTypeEvaluator.IsCodedType("CV"));
			Assert.IsTrue(CodedTypeEvaluator.IsCodedType("CO"));
			Assert.IsTrue(CodedTypeEvaluator.IsCodedType("CD"));
			Assert.IsTrue(CodedTypeEvaluator.IsCodedType("CD.LAB"));
			Assert.IsTrue(CodedTypeEvaluator.IsCodedType("CE"));
			Assert.IsTrue(CodedTypeEvaluator.IsCodedType("CS"));
			Assert.IsTrue(CodedTypeEvaluator.IsCodedType("PQR"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("CR"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("HXIT"));
			Assert.IsTrue(CodedTypeEvaluator.IsCodedType("HXIT<CE>"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("ST"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("ST.LANG"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("ED"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("ED.DOC"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("ED.DOC_OR_REF"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("ED.REF"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("ED.DOC_REF"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("ED.SIGNATURE"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("PN"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("PN.BASIC"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("PN.SIMPLE"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("PN.FULL"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("PN.SEARCH"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("IVL"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("IVL<DATE>"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("IVL<DATETIME>"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("IVL<FULL_DATE>"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("IVL<FULL_DATE_WITH_TIME>"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("IVL<FULL_DATE_TIME>"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("IVL<FULL_DATE_PART_TIME>"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("IVL<TS>"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("IVL<HIGH_TS_FULLDATE>"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("IVL<WIDTH_TS_FULLDATE>"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("IVL<LOW_TS_DATE>"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("IVL<LOW_TS_FULLDATE>"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("IVL<LOW_TS_FULLDATETIME>"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("IVL<PQ>"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("IVL<PQ_BASIC>"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("IVL<PQ_DRUG>"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("IVL<PQ_TIME>"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("IVL<PQ_LAB>"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("IVL<PQ_HEIGHTWEIGHT>"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("IVL<PQ_DISTANCE>"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("IVL<INT>"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("IVL<REAL>"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("IVL<MO>"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("EIVL"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("EIVL<TS>"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("IVL.WIDTH"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("IVL.LOW"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("IVL.HIGH"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("MO"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("MO.CAD"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("PIVL"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("PIVL<TS>"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("PIVL<TS.DATETIME>"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("PIVL<TS.FULLDATETIME>"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("INT"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("INT.NONNEG"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("INT.POS"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("PQ"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("PQ.BASIC"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("PQ.DRUG"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("PQ.TIME"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("PQ.LAB"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("PQ.HEIGHTWEIGHT"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("PQ.DISTANCE"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("REAL"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("REAL.COORD"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("REAL.CONF"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("RTO"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("RTO<PQ,PQ>"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("RTO<MO,PQ>"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("RTO<PQ.DRUG,PQ.TIME>"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("RTO<PQ.DRUG,PQ.DRUG>"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("RTO<MO.CAD,PQ.BASIC>"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("TS"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("TS.DATE"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("TS.DATETIME"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("TS.FULLDATEWITHTIME"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("TS.FULLDATE"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("TS.FULLDATETIME"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("TS.FULLDATEPARTTIME"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("TEL"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("TEL.ALL"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("TEL.PHONEMAIL"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("TEL.PHONE"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("TEL.EMAIL"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("TEL.URI"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("URG"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("URG<TS.DATE>"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("URG<PQ>"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("URG<PQ.BASIC>"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("URG<PQ.DRUG>"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("URG<PQ.TIME>"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("URG<PQ.LAB>"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("URG<PQ.HEIGHTWEIGHT>"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("URG<PQ.DISTANCE>"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("URL"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("SXPR"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("SXCM"));
			Assert.IsTrue(CodedTypeEvaluator.IsCodedType("SXCM<CD>"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("SXCM<INT>"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("SXCM<MO>"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("SXCM<PQ>"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("SXCM<REAL>"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("SXCM<TS>"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("BXIT"));
			Assert.IsTrue(CodedTypeEvaluator.IsCodedType("BXIT<CD>"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("SET"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("LIST"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("COLLECTION"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("BAG"));
			Assert.IsTrue(CodedTypeEvaluator.IsCodedType("SET<CD>"));
			Assert.IsTrue(CodedTypeEvaluator.IsCodedType("LIST<CO>"));
			Assert.IsTrue(CodedTypeEvaluator.IsCodedType("COLLECTION<HXIT<CE>>"));
			Assert.IsTrue(CodedTypeEvaluator.IsCodedType("BAG<BXIT<CD>"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("SET<TS.FULLDATETIME>"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("LIST<URG<PQ>>>"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("COLLECTION<SXCM<TS>>"));
			Assert.IsFalse(CodedTypeEvaluator.IsCodedType("BAG<CR>"));
		}
	}
}
