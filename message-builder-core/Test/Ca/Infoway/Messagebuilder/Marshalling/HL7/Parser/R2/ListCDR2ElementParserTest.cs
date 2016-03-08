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


using System;
using System.Collections.Generic;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2;
using Ca.Infoway.Messagebuilder.Xml;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2
{
	[TestFixture]
	public class ListCDR2ElementParserTest : ParserTestCase
	{
		private ParserR2Registry parserR2Registry = ParserR2Registry.GetInstance();

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParse()
		{
			XmlNode node = CreateNode("<top>" + "<targetSiteCode code=\"416949008\" codeSystem=\"2.16.840.1.113883.6.96\" codeSystemName=\"SNOMED CT\" displayName=\"Abdomen and pelvis\"/>"
				 + "</top>");
			Type expectedReturnType = typeof(ObservationValue);
			ParseContext parseContext = ParseContextImpl.Create("LIST<CD>", expectedReturnType, SpecificationVersion.CCDA_R1_1, null, 
				null, null, Cardinality.Create("0-4"), null, true);
			BareANY result = new ListR2ElementParser(this.parserR2Registry).Parse(parseContext, AsList(node.ChildNodes), this.xmlResult
				);
			Assert.IsTrue(this.xmlResult.IsValid());
			IList<CodedTypeR2<ObservationValue>> list = ((LIST<CD_R2<ObservationValue>, CodedTypeR2<ObservationValue>>)result).RawList
				();
			Assert.IsNotNull(list, "null");
			Assert.AreEqual(1, list.Count, "size");
			CodedTypeR2<ObservationValue> firstValue = list[0];
			Assert.AreEqual("416949008", firstValue.GetCodeValue());
			Assert.AreEqual("2.16.840.1.113883.6.96", firstValue.GetCodeSystem());
			Assert.AreEqual("SNOMED CT", firstValue.CodeSystemName);
			Assert.AreEqual("Abdomen and pelvis", firstValue.DisplayName);
		}
	}
}
