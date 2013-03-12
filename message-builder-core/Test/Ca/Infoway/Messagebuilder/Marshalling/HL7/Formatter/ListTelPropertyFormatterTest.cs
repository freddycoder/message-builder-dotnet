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
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class ListTelPropertyFormatterTest : FormatterTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNull()
		{
			string result = new ListPropertyFormatter().Format(new FormatContextImpl(new ModelToXmlResult(), null, "telecom", "LIST<TEL>"
				, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL), (BareANY)new LISTImpl<TEL, TelecommunicationAddress>(typeof(
				TELImpl)));
			AssertXml("null", string.Empty, result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNonNull()
		{
			string result = new ListPropertyFormatter().Format(new FormatContextImpl(new ModelToXmlResult(), null, "telecom", "LIST<TEL>"
				, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, false, SpecificationVersion.R02_04_03, null, null, null), (BareANY
				)LISTImpl<ANY<object>, object>.Create<TEL, TelecommunicationAddress>(typeof(TELImpl), CreateTelecommunicationAddressList
				()));
			AssertXml("non null", "<telecom value=\"+1-519-555-2345;ext=12345\"/>" + "<telecom value=\"+1-416-555-2345;ext=12345\"/>"
				, result);
		}

		private IList<TelecommunicationAddress> CreateTelecommunicationAddressList()
		{
			List<TelecommunicationAddress> result = new List<TelecommunicationAddress>();
			TelecommunicationAddress phone1 = CreateTelecommunicationAddress("+1-519-555-2345;ext=12345");
			TelecommunicationAddress phone2 = CreateTelecommunicationAddress("+1-416-555-2345;ext=12345");
			result.Add(phone1);
			result.Add(phone2);
			return result;
		}

		private static TelecommunicationAddress CreateTelecommunicationAddress(string formattedPhoneNumber)
		{
			TelecommunicationAddress telecom = new TelecommunicationAddress();
			telecom.Address = formattedPhoneNumber;
			return telecom;
		}
	}
}
