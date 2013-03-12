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
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Util.Xml;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[TestFixture]
	public class NullFlavorHelperTest
	{
		public static readonly object[] POPULATED = new object[] { Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.POPULATED, true
			 };

		public static readonly object[] MANDATORY = new object[] { Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY, false
			 };

		public static readonly object[] REQUIRED = new object[] { Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.REQUIRED, false };

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestConformanceHandlingForNullFlavorIsErrorFree()
		{
			AssertConformance(POPULATED);
			AssertConformance(MANDATORY);
			AssertConformance(REQUIRED);
		}

		/// <exception cref="org.xml.sax.SAXException"></exception>
		private void AssertConformance(object[] arguments)
		{
			XmlNode node = CreateNode("<effectiveTime><low nullFlavor=\"NI\"/></effectiveTime>");
			XmlToModelResult xmlResult = new XmlToModelResult();
			new NullFlavorHelper((Ca.Infoway.Messagebuilder.Xml.ConformanceLevel)arguments[0], node, xmlResult, false).ParseNullNode(
				);
			Assert.AreEqual(arguments[1], xmlResult.GetHl7Errors().IsEmpty());
		}

		/// <exception cref="org.xml.sax.SAXException"></exception>
		[Test]
		public virtual void ShouldHandleXsiNilAttributeForAssociation()
		{
			XmlNode node = CreateNode("<patient nullFlavor=\"NI\" xsi:nil=\"true\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"/>"
				);
			XmlToModelResult xmlResult = new XmlToModelResult();
			new NullFlavorHelper(Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.POPULATED, node, xmlResult, true).ParseNullNode();
			Assert.IsTrue(xmlResult.GetHl7Errors().IsEmpty());
		}

		/// <exception cref="org.xml.sax.SAXException"></exception>
		[Test]
		public virtual void ShouldCatchXsiNilAttributeErrorForAssociation()
		{
			XmlNode node = CreateNode("<patient nullFlavor=\"NI\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"/>");
			XmlToModelResult xmlResult = new XmlToModelResult();
			new NullFlavorHelper(Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.POPULATED, node, xmlResult, true).ParseNullNode();
			Assert.IsFalse(xmlResult.GetHl7Errors().IsEmpty());
			Assert.AreEqual(1, xmlResult.GetHl7Errors().Count);
			Assert.IsTrue(xmlResult.GetHl7Errors()[0].GetMessage().Contains("does not specify xsi:nil=\"true\""));
		}

		/// <exception cref="org.xml.sax.SAXException"></exception>
		private XmlNode CreateNode(string xml)
		{
			return new DocumentFactory().CreateFromString(xml).DocumentElement;
		}
	}
}
