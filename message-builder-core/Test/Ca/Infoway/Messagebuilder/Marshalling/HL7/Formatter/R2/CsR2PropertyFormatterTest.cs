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
	public class CsR2PropertyFormatterTest : FormatterTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestNullFlavor()
		{
			string result = new CsR2PropertyFormatter().Format(GetContext("name", "CS"), new CS_R2Impl<Code>(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor
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
			string result = new CsR2PropertyFormatter().Format(GetContext("name", "CS"), new CS_R2Impl<Code>(codedType));
			Assert.IsTrue(this.result.IsValid());
			Assert.AreEqual("<name code=\"cm\"/>", StringUtils.Trim(result), "result");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestCodeSystemNameNotRendered()
		{
			CodedTypeR2<Code> codedType = new CodedTypeR2<Code>();
			codedType.Code = CeRxDomainTestValues.CENTIMETRE;
			codedType.CodeSystemName = "aCodeSystemName";
			codedType.DisplayName = "aDisplayName";
			string result = new CsR2PropertyFormatter().Format(GetContext("name", "CS"), new CS_R2Impl<Code>(codedType));
			Assert.IsTrue(this.result.IsValid());
			Assert.AreEqual("<name code=\"cm\"/>", StringUtils.Trim(result), "result");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestOriginalTextAndNullFlavor()
		{
			CodedTypeR2<Code> codedType = new CodedTypeR2<Code>();
			EncapsulatedData originalText = new EncapsulatedData();
			originalText.Content = "original text not allowed for CS";
			codedType.OriginalText = originalText;
			CS_R2<Code> cs = new CS_R2Impl<Code>(codedType);
			cs.NullFlavor = Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION;
			string result = new CsR2PropertyFormatter().Format(GetContext("name", "CS"), cs);
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
			// Doesn't appear in the output, but shouldn't log an error either
			codedType.CodeSystemVersion = "aCodeSystemVersion";
			codedType.DisplayName = "aDisplayName";
			// Doesn't appear in the output, but shouldn't log an error either
			codedType.SimpleValue = "simpleValue";
			codedType.Operator = SetOperator.CONVEX_HULL;
			codedType.Value = BigDecimal.ONE;
			codedType.Translation.Add(new CodedTypeR2<Code>());
			codedType.Qualifier.Add(new CodeRole());
			EncapsulatedData originalText = new EncapsulatedData();
			originalText.Content = "original text not allowed for CS";
			codedType.OriginalText = originalText;
			CS_R2<Code> cs = new CS_R2Impl<Code>(codedType);
			string result = new CsR2PropertyFormatter().Format(GetContext("name", "CS"), cs);
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(7, this.result.GetHl7Errors().Count);
			Assert.AreEqual("<name code=\"cm\"/>", StringUtils.Trim(result), "result");
		}
	}
}
