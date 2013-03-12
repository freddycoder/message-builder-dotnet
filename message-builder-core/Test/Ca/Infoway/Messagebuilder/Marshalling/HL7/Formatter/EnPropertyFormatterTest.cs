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
		public virtual void TestFormatValueTrivialName()
		{
			EnPropertyFormatter formatter = new EnPropertyFormatter();
			TnPropertyFormatter tnFormatter = new TnPropertyFormatter();
			EntityName name = new TrivialName("something");
			Assert.AreEqual(tnFormatter.Format(GetContext("x"), new TNImpl((TrivialName)name)), formatter.Format(GetContext("x"), new 
				ENImpl<EntityName>(name)), "TrivialName uses TN formatter");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueOrganizationName()
		{
			EnPropertyFormatter formatter = new EnPropertyFormatter();
			OnPropertyFormatter onFormatter = new OnPropertyFormatter();
			OrganizationName name = new OrganizationName();
			name.AddNamePart(new EntityNamePart("prefix", OrganizationNamePartType.PREFIX));
			name.AddNamePart(new EntityNamePart("Organization"));
			Assert.AreEqual(onFormatter.Format(GetContext("x"), new ONImpl(name)), formatter.Format(GetContext("x"), new ENImpl<EntityName
				>(name)), "OrganizationName uses ON formatter");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValuePersonName()
		{
			EnPropertyFormatter formatter = new EnPropertyFormatter();
			PnPropertyFormatter pnFormatter = new PnPropertyFormatter();
			PersonName name = new PersonName();
			name.AddNamePart(new EntityNamePart("prefix", PersonNamePartType.PREFIX));
			name.AddNamePart(new EntityNamePart("given", PersonNamePartType.GIVEN));
			Assert.AreEqual(pnFormatter.Format(GetContext("x"), new PNImpl(name)), formatter.Format(GetContext("x"), new ENImpl<EntityName
				>(name)), "PersonName uses PN formatter");
		}
	}
}
