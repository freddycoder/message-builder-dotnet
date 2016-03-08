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


using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Xml;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class ListTelPhonemailPropertyFormatterTest : FormatterTestCase
	{
		private FormatterRegistry formatterRegistry = FormatterRegistry.GetInstance();

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNull()
		{
			string result = new ListPropertyFormatter(this.formatterRegistry).Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(new ModelToXmlResult(), null, "blah", "LIST<TEL.PHONEMAIL>", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null
				, false, SpecificationVersion.R02_04_03, null, null, null, false), (BareANY)new LISTImpl<TEL, TelecommunicationAddress>(
				typeof(TELImpl)));
			AssertXml("null", string.Empty, result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNonNull()
		{
			ModelToXmlResult results = new ModelToXmlResult();
			string result = new ListPropertyFormatter(this.formatterRegistry).Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(results, null, "blah", "LIST<TEL.PHONEMAIL>", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, Cardinality.Create
				("0-4"), false, SpecificationVersion.R02_04_03, null, null, null, false), (BareANY)LISTImpl<ANY<object>, object>.Create<
				TEL, TelecommunicationAddress>(typeof(TELImpl), new List<TelecommunicationAddress>(MakeTelecommunicationAddressList("Fred"
				))));
			AssertXml("non null", "<blah specializationType=\"TEL.PHONE\" value=\"mailto:Fred\" xsi:type=\"TEL\"/>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNonNullMultiple()
		{
			string result = new ListPropertyFormatter(this.formatterRegistry).Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(new ModelToXmlResult(), null, "blah", "LIST<TEL.PHONEMAIL>", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, Cardinality
				.Create("0-4"), false, SpecificationVersion.R02_04_03, null, null, null, false), (BareANY)LISTImpl<ANY<object>, object>.
				Create<TEL, TelecommunicationAddress>(typeof(TELImpl), new List<TelecommunicationAddress>(MakeTelecommunicationAddressList
				("Fred", "Jack"))));
			AssertXml("non null", "<blah specializationType=\"TEL.PHONE\" value=\"mailto:Fred\" xsi:type=\"TEL\"/>" + "<blah specializationType=\"TEL.PHONE\" value=\"mailto:Jack\" xsi:type=\"TEL\"/>"
				, result);
		}
	}
}
