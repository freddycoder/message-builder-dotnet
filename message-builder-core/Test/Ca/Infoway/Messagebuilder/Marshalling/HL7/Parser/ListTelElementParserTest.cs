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
using System.Collections.Generic;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[TestFixture]
	public class ListTelElementParserTest : ParserTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParse()
		{
			XmlNode node = CreateNode("<top><telecom specializationType=\"TEL.PHONE\" value=\"tel:+1-519-555-2345;ext=1\"/>" + "<telecom specializationType=\"TEL.PHONE\" value=\"tel:+1-416-555-2345;ext=2\"/></top>"
				);
			BareANY result = new ListElementParser().Parse(ParserContextImpl.Create("LIST<TEL.PHONEMAIL>", null, SpecificationVersion
				.V02R02, null, null, null), AsList(node.ChildNodes), this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
			IList<TelecommunicationAddress> list = ((LIST<TEL, TelecommunicationAddress>)result).RawList();
			Assert.IsNotNull(list, "null");
			Assert.AreEqual(2, list.Count, "size");
			TelecommunicationAddress phone1 = list[0];
			TelecommunicationAddress phone2 = list[1];
			Assert.AreEqual("+1-519-555-2345;ext=1", phone1.Address);
			Assert.AreEqual("+1-416-555-2345;ext=2", phone2.Address);
		}
	}
}
