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
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2
{
	[TestFixture]
	public class StR2PropertyFormatterTest : FormatterTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNull()
		{
			FormatContext context = GetContext("name");
			string result = new StR2PropertyFormatter().Format(context, null);
			Assert.IsTrue(StringUtils.IsBlank(result), "named null format");
			AssertNoErrors(context);
		}

		private void AssertNoErrors(FormatContext context)
		{
			Assert.IsTrue(context.GetModelToXmlResult().IsValid(), "no errors");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNonNull()
		{
			AbstractPropertyFormatter formatter = new StR2PropertyFormatter();
			FormatContext context = GetContext("name");
			string result = formatter.Format(context, new STImpl("something"));
			Assert.AreEqual(AddLineSeparator("<name>something</name>"), result, "something in text node");
			AssertNoErrors(context);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatCdataValueNull()
		{
			AbstractPropertyFormatter formatter = new StR2PropertyFormatter();
			FormatContext context = GetContext("name");
			STImpl dataType = new STImpl((string)null);
			dataType.IsCdata = true;
			string result = formatter.Format(context, dataType);
			Assert.AreEqual(AddLineSeparator("<name nullFlavor=\"NI\"/>"), result, "something in text node");
			AssertNoErrors(context);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatCdataValueEmpty()
		{
			AbstractPropertyFormatter formatter = new StR2PropertyFormatter();
			FormatContext context = GetContext("name");
			STImpl dataType = new STImpl(string.Empty);
			dataType.IsCdata = true;
			string result = formatter.Format(context, dataType);
			Assert.AreEqual(AddLineSeparator("<name><![CDATA[]]></name>"), result, "something in text node");
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatCdataValueNonNull()
		{
			AbstractPropertyFormatter formatter = new StR2PropertyFormatter();
			FormatContext context = GetContext("name");
			STImpl dataType = new STImpl("something");
			dataType.IsCdata = true;
			string result = formatter.Format(context, dataType);
			Assert.AreEqual(AddLineSeparator("<name><![CDATA[something]]></name>"), result, "something in text node");
			AssertNoErrors(context);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatCdataValueNonNullWithSpecialCharacters()
		{
			AbstractPropertyFormatter formatter = new StR2PropertyFormatter();
			FormatContext context = GetContext("name");
			STImpl dataType = new STImpl("<cats think they're > humans & dogs 99% of the time/>");
			dataType.IsCdata = true;
			string result = formatter.Format(context, dataType);
			Assert.AreEqual(AddLineSeparator("<name><![CDATA[<cats think they're > humans & dogs 99% of the time/>]]></name>"), result
				, "something in text node");
			AssertNoErrors(context);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNonNullWithLanguageAllowed()
		{
			AbstractPropertyFormatter formatter = new StR2PropertyFormatter();
			Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl context = new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(new ModelToXmlResult(), null, "name", "ST", null, null, false);
			string result = formatter.Format(context, new STImpl("something", "fr-CA"));
			Assert.AreEqual(AddLineSeparator("<name language=\"fr-CA\">something</name>"), RemoveErrorComments(result), "something in text node"
				);
			AssertNoErrors(context);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNonNullWithLanguageFr()
		{
			AbstractPropertyFormatter formatter = new StR2PropertyFormatter();
			FormatContext context = new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(new ModelToXmlResult(), 
				null, "name", "ST", null, null, false);
			string result = formatter.Format(context, new STImpl("something", "fr-CA"));
			Assert.AreEqual(AddLineSeparator("<name language=\"fr-CA\">something</name>"), result, "something in text node");
			AssertNoErrors(context);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNonNullWithLanguageEn()
		{
			AbstractPropertyFormatter formatter = new StR2PropertyFormatter();
			Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl context = new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(new ModelToXmlResult(), null, "name", "ST", null, null, false);
			string result = formatter.Format(context, new STImpl("something", "en-CA"));
			Assert.AreEqual(AddLineSeparator("<name language=\"en-CA\">something</name>"), result, "something in text node");
			AssertNoErrors(context);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNonNullWithNonEnglishNonFrenchLanguage()
		{
			AbstractPropertyFormatter formatter = new StR2PropertyFormatter();
			Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl context = new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(new ModelToXmlResult(), null, "name", "ST", null, null, false);
			string result = formatter.Format(context, new STImpl("something", "it-CA"));
			Assert.AreEqual(AddLineSeparator("<name language=\"it-CA\">something</name>"), RemoveErrorComments(result), "something in text node"
				);
			AssertNoErrors(context);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNonNullWithBlankLanguage()
		{
			AbstractPropertyFormatter formatter = new StR2PropertyFormatter();
			Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl context = new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(new ModelToXmlResult(), null, "name", "ST", null, null, false);
			STImpl dataType = new STImpl("something");
			dataType.Language = string.Empty;
			string result = formatter.Format(context, dataType);
			Assert.AreEqual(AddLineSeparator("<name>something</name>"), RemoveErrorComments(result), "something in text node");
			Assert.AreEqual(1, context.GetModelToXmlResult().GetHl7Errors().Count, "error from blank language");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueReservedXmlChars()
		{
			AbstractPropertyFormatter formatter = new StR2PropertyFormatter();
			FormatContext context = GetContext("name");
			string result = formatter.Format(context, new STImpl("<cats think they're > humans & dogs 99% of the time/>"));
			Assert.AreEqual("<name>&lt;cats think they&apos;re &gt; humans &amp; dogs 99% of the time/&gt;</name>".Trim(), result.Trim
				(), "something in text node");
			AssertNoErrors(context);
		}
	}
}
