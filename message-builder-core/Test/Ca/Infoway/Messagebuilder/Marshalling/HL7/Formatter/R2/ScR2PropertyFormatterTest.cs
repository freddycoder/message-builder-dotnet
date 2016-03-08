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


using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2
{
	[TestFixture]
	public class ScR2PropertyFormatterTest : FormatterTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestNullFlavor()
		{
			string result = new ScR2PropertyFormatter().Format(GetContext("name", "SC"), new SC_R2Impl<Code>(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor
				.NO_INFORMATION));
			Assert.IsTrue(this.result.IsValid());
			Assert.AreEqual("<name nullFlavor=\"NI\"/>", StringUtils.Trim(result), "result");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestValidFull()
		{
			CodedTypeR2<Code> codedType = new CodedTypeR2<Code>();
			codedType.Code = CeRxDomainTestValues.CENTIMETRE;
			codedType.CodeSystemName = "aCodeSystemName";
			codedType.CodeSystemVersion = "aCodeSystemVersion";
			codedType.DisplayName = "aDisplayName";
			codedType.SimpleValue = "simple text value";
			string result = new ScR2PropertyFormatter().Format(GetContext("name", "SC"), new SC_R2Impl<Code>(codedType));
			Assert.IsTrue(this.result.IsValid());
			Assert.AreEqual("<name code=\"cm\" codeSystem=\"1.2.3.4\" codeSystemName=\"aCodeSystemName\" codeSystemVersion=\"aCodeSystemVersion\" displayName=\"aDisplayName\">simple text value</name>"
				, StringUtils.Trim(result), "result");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestOriginalTextAndNullFlavor()
		{
			CodedTypeR2<Code> codedType = new CodedTypeR2<Code>();
			EncapsulatedData originalText = new EncapsulatedData();
			originalText.Content = "original text not allowed for SC";
			codedType.OriginalText = originalText;
			SC_R2<Code> sc = new SC_R2Impl<Code>(codedType);
			sc.NullFlavor = Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION;
			string result = new ScR2PropertyFormatter().Format(GetContext("name", "SC"), sc);
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			Assert.IsTrue(this.result.GetHl7Errors()[0].GetMessage().Contains("originalText"));
			Assert.AreEqual("<name nullFlavor=\"NI\"/>", StringUtils.Trim(result), "result");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestEverythingSpecified()
		{
			CodedTypeR2<Code> codedType = new CodedTypeR2<Code>();
			codedType.Code = CeRxDomainTestValues.CENTIMETRE;
			codedType.CodeSystemName = "aCodeSystemName";
			codedType.CodeSystemVersion = "aCodeSystemVersion";
			codedType.DisplayName = "aDisplayName";
			codedType.SimpleValue = "simple text value";
			codedType.Operator = SetOperator.CONVEX_HULL;
			codedType.Value = BigDecimal.ONE;
			codedType.Translation.Add(new CodedTypeR2<Code>());
			codedType.Qualifier.Add(new CodeRole());
			EncapsulatedData originalText = new EncapsulatedData();
			originalText.Content = "original text not allowed for SC";
			codedType.OriginalText = originalText;
			SC_R2<Code> sc = new SC_R2Impl<Code>(codedType);
			string result = new ScR2PropertyFormatter().Format(GetContext("name", "SC"), sc);
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(5, this.result.GetHl7Errors().Count);
			Assert.AreEqual("<name code=\"cm\" codeSystem=\"1.2.3.4\" codeSystemName=\"aCodeSystemName\" codeSystemVersion=\"aCodeSystemVersion\" displayName=\"aDisplayName\">simple text value</name>"
				, StringUtils.Trim(result), "result");
		}
	}
}
