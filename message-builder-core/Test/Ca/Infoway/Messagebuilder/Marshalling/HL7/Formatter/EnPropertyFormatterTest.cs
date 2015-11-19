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
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class EnPropertyFormatterTest : FormatterTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestEnPropertyFormatterWhenConformanceLevelIsNotSpecified()
		{
			string result = new EnPropertyFormatter().Format(GetContext("name"), new ENImpl<EntityName>());
			Assert.AreEqual("<name nullFlavor=\"NI\"/>", result.Trim());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestEnPropertyFormatterWhenConformanceLevelIsSetToNullFlavor()
		{
			string result = new EnPropertyFormatter().Format(GetContext("name"), new ENImpl<EntityName>(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor
				.ASKED_BUT_UNKNOWN));
			Assert.AreEqual("<name nullFlavor=\"ASKU\"/>", result.Trim());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueTrivialName()
		{
			EnPropertyFormatter formatter = new EnPropertyFormatter();
			EntityName name = new TrivialName("something");
			Assert.AreEqual("<x xsi:type=\"TN\">something</x>", formatter.Format(GetContext("x"), new ENImpl<EntityName>(name)).Trim(
				), "TrivialName uses TN formatter");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueOrganizationName()
		{
			EnPropertyFormatter formatter = new EnPropertyFormatter();
			OrganizationName name = new OrganizationName();
			name.AddNamePart(new EntityNamePart("prefix", OrganizationNamePartType.PREFIX));
			name.AddNamePart(new EntityNamePart("Organization"));
			Assert.AreEqual("<x xsi:type=\"ON\"><prefix>prefix</prefix>Organization</x>", formatter.Format(GetContext("x"), new ENImpl
				<EntityName>(name)).Trim(), "OrganizationName uses ON formatter");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValuePersonName()
		{
			EnPropertyFormatter formatter = new EnPropertyFormatter();
			PersonName name = new PersonName();
			name.AddNamePart(new EntityNamePart("prefix", PersonNamePartType.PREFIX));
			name.AddNamePart(new EntityNamePart("given", PersonNamePartType.GIVEN));
			Assert.AreEqual("<x xsi:type=\"PN\"><prefix>prefix</prefix><given>given</given></x>", formatter.Format(GetContext("x"), new 
				ENImpl<EntityName>(name)).Trim(), "PersonName uses PN formatter");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNoSpecializationType()
		{
			EnPropertyFormatter formatter = new EnPropertyFormatter();
			EntityName name = new EntityName();
			name.AddNamePart(new EntityNamePart("prefix", PersonNamePartType.PREFIX));
			name.AddNamePart(new EntityNamePart("given", PersonNamePartType.GIVEN));
			Assert.AreEqual("<x><prefix>prefix</prefix><given>given</given></x>", formatter.Format(GetContext("x"), new ENImpl<EntityName
				>(name)).Trim(), "result");
			System.Console.Out.WriteLine(string.Empty);
		}
	}
}
