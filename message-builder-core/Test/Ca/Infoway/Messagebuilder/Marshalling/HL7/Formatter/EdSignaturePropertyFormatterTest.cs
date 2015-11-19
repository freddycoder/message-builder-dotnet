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
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class EdSignaturePropertyFormatterTest : FormatterTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNullWithConformanceOptional()
		{
			string expectedResult = string.Empty;
			FormatContext context = new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(new ModelToXmlResult(), 
				null, "name", null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, false);
			string result = new EdSignaturePropertyFormatter().Format(context, null);
			Assert.AreEqual(expectedResult, result, "named null format");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNull()
		{
			// expected:
			// <name nullFlavor=\"NI\"/>
			string expectedResult = "<name nullFlavor=\"NI\"/>" + SystemUtils.LINE_SEPARATOR;
			string result = new EdSignaturePropertyFormatter().Format(GetContext("name"), new EDImpl<string>());
			Assert.AreEqual(expectedResult, result, "named null format");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNonNull()
		{
			// expected:
			// <name mediaType="text/xml">
			//   <signature xmlns="http://www.w3.org/2000/09/xmldsig#">signatureText</signature>
			// </name>
			string expectedResult = "<name mediaType=\"text/xml\">" + SystemUtils.LINE_SEPARATOR + "  <signature xmlns=\"http://www.w3.org/2000/09/xmldsig#\">signatureText</signature>"
				 + SystemUtils.LINE_SEPARATOR + "</name>" + SystemUtils.LINE_SEPARATOR;
			string result = new EdSignaturePropertyFormatter().Format(GetContext("name"), new EDImpl<string>("signatureText"));
			Assert.AreEqual(expectedResult, result, "something in text node");
		}
	}
}
