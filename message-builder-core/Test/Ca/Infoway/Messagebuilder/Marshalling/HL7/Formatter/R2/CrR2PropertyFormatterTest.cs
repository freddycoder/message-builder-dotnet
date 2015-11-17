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
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2;
using Ca.Infoway.Messagebuilder.Resolver.Configurator;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2
{
	[TestFixture]
	public class CrR2PropertyFormatterTest : FormatterTestCase
	{
		[SetUp]
		public virtual void Setup()
		{
			DefaultCodeResolutionConfigurator.ConfigureCodeResolversWithTrivialDefault();
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestNullCase()
		{
			string result = new CrR2PropertyFormatter().Format(GetContext("name", "CR"), new CRImpl(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor
				.MASKED));
			Assert.IsTrue(this.result.IsValid());
			AssertXml("result", "<name nullFlavor=\"MSK\"/>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestEmpty()
		{
			string result = new CrR2PropertyFormatter().Format(GetContext("codeRole", "CR"), new CRImpl());
			Assert.IsTrue(this.result.IsValid());
			AssertXml("result", "<codeRole nullFlavor=\"NI\"/>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestValid()
		{
			CodedTypeR2<Code> name = new CodedTypeR2<Code>();
			name.Code = Ca.Infoway.Messagebuilder.Domainvalue.Payload.AdministrativeGender.MALE;
			CodedTypeR2<Code> value = new CodedTypeR2<Code>();
			value.Code = Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActStatus.COMPLETED;
			CodeRole codeRole = new CodeRole(name, value, true);
			string result = new CrR2PropertyFormatter().Format(GetContext("codeRole", "CR"), new CRImpl(codeRole));
			Assert.IsTrue(this.result.IsValid());
			AssertXml("result", "<codeRole inverted=\"true\"><name code=\"M\" codeSystem=\"2.16.840.1.113883.5.1\" displayName=\"Male\"/><value code=\"completed\" codeSystem=\"2.16.840.1.113883.5.14\" displayName=\"Completed\"/></codeRole>"
				, result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestInvalidMissingValue()
		{
			CodedTypeR2<Code> name = new CodedTypeR2<Code>();
			name.Code = Ca.Infoway.Messagebuilder.Domainvalue.Payload.AdministrativeGender.MALE;
			CodeRole codeRole = new CodeRole(name, null, true);
			string result = new CrR2PropertyFormatter().Format(GetContext("codeRole", "CR"), new CRImpl(codeRole));
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			AssertXml("result", "<codeRole inverted=\"true\"><name code=\"M\" codeSystem=\"2.16.840.1.113883.5.1\" displayName=\"Male\"/></codeRole>"
				, result);
		}
	}
}
