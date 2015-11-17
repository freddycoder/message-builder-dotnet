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
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2
{
	[TestFixture]
	public class EnR2PropertyFormatterTest : FormatterTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestEnR2PropertyFormatterWhenConformanceLevelIsNotSpecified()
		{
			string result = new EnR2PropertyFormatter().Format(GetContext("name", "EN"), new ENImpl<EntityName>());
			Assert.AreEqual("<name nullFlavor=\"NI\"/>", result.Trim());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestBasicForCeRxWithMultipleNameParts()
		{
			EnR2PropertyFormatter formatter = new EnR2PropertyFormatter();
			PersonName personName = new PersonName();
			personName.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.LEGAL);
			personName.AddNamePart(new EntityNamePart("Steve", PersonNamePartType.GIVEN));
			personName.AddNamePart(new EntityNamePart("Shaw", PersonNamePartType.FAMILY));
			string result = formatter.Format(GetContext("name", "EN", SpecificationVersion.V01R04_3), new PNImpl(personName));
			Assert.IsTrue(this.result.IsValid());
			AssertXml("something in text node", "<name use=\"L\"><given>Steve</given><family>Shaw</family></name>", result, true);
		}
	}
}
