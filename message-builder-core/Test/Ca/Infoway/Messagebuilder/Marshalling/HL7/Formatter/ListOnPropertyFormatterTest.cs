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
	public class ListOnPropertyFormatterTest : FormatterTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNull()
		{
			string result = new ListPropertyFormatter().Format(new FormatContextImpl(new ModelToXmlResult(), null, "name", "LIST<ON>"
				, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL), new LISTImpl<ON, OrganizationName>(typeof(ONImpl)));
			AssertXml("null", string.Empty, result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNullMandatory()
		{
			string result = new ListPropertyFormatter().Format(new FormatContextImpl(new ModelToXmlResult(), null, "blah", "LIST<ON>"
				, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY), (BareANY)new LISTImpl<ON, OrganizationName>(typeof(ONImpl), 
				Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION));
			AssertXml("null", "<blah nullFlavor=\"NI\"/>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNonNull()
		{
			string result = new ListPropertyFormatter().Format(new FormatContextImpl(new ModelToXmlResult(), null, "name", "LIST<ON>"
				, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY), LISTImpl<ANY<object>, object>.Create<ON, OrganizationName>(
				typeof(ONImpl), CreateOrganizationNameList()));
			Assert.AreEqual("<name>Organization 1</name>" + SystemUtils.LINE_SEPARATOR + "<name>Organization 2</name>" + SystemUtils.
				LINE_SEPARATOR, result, "non null");
		}

		private IList<OrganizationName> CreateOrganizationNameList()
		{
			List<OrganizationName> result = new List<OrganizationName>();
			result.Add(CreateOrganizationName("Organization 1"));
			result.Add(CreateOrganizationName("Organization 2"));
			return result;
		}

		private OrganizationName CreateOrganizationName(string name)
		{
			OrganizationName organizationName = new OrganizationName();
			IList<EntityNamePart> parts = organizationName.Parts;
			parts.Add(new EntityNamePart(name));
			return organizationName;
		}
	}
}
