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
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class ListEnPropertyFormatterTest : FormatterTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNull()
		{
			string result = new ListPropertyFormatter().Format(new FormatContextImpl(new ModelToXmlResult(), null, "name", "LIST<EN>"
				, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL), new LISTImpl<EN<EntityName>, EntityName>(typeof(ENImpl<EntityName
				>)));
			AssertXml("null", string.Empty, result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNonNull()
		{
			string result = new ListPropertyFormatter().Format(new FormatContextImpl(new ModelToXmlResult(), null, "name", "LIST<EN>"
				, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, false, SpecificationVersion.R02_04_02, null, null, null), (BareANY
				)LISTImpl<ANY<object>, object>.Create<EN<EntityName>, EntityName>(typeof(ENImpl<EntityName>), CreateEntityNameList()));
			Assert.AreEqual("<name><family>Flinstone</family><given>Fred</given></name>" + SystemUtils.LINE_SEPARATOR + "<name><family>Flinstone</family><given>Wilma</given></name>"
				 + SystemUtils.LINE_SEPARATOR, result, "non null");
		}

		private IList<EntityName> CreateEntityNameList()
		{
			List<EntityName> result = new List<EntityName>();
			EntityName fred = CreateEntityName("Flinstone", "Fred");
			EntityName wilma = CreateEntityName("Flinstone", "Wilma");
			result.Add(fred);
			result.Add(wilma);
			return result;
		}

		private EntityName CreateEntityName(string familiyName, string givenName)
		{
			EntityName personName = new PersonName();
			IList<EntityNamePart> parts = personName.Parts;
			parts.Add(new EntityNamePart(familiyName, PersonNamePartType.FAMILY));
			parts.Add(new EntityNamePart(givenName, PersonNamePartType.GIVEN));
			return personName;
		}
	}
}
