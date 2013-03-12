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
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class ScPropertyFormatterTest : FormatterTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNull()
		{
			string result = new ScPropertyFormatter().Format(GetContext("name"), null);
			Assert.IsTrue(StringUtils.IsBlank(result), "named null format");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNullCode()
		{
			ScPropertyFormatter formatter = new ScPropertyFormatter();
			CodedString<Code> codedString = new CodedString<Code>("something", null);
			string result = formatter.Format(GetContext("name"), new SCImpl<Code>(codedString));
			Assert.AreEqual(AddLineSeparator("<name>something</name>"), result, "something in text node");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueCode()
		{
			ScPropertyFormatter formatter = new ScPropertyFormatter();
			CodedString<Code> codedString = new CodedString<Code>("something", Ca.Infoway.Messagebuilder.Domainvalue.Basic.State.ALBERTA
				);
			string result = formatter.Format(GetContext("name"), new SCImpl<Code>(codedString));
			Assert.AreEqual(AddLineSeparator("<name code=\"AB\">something</name>"), result, "something in text node");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueReservedXmlChars()
		{
			ScPropertyFormatter formatter = new ScPropertyFormatter();
			CodedString<Code> codedString = new CodedString<Code>("<cats think they're > humans & dogs 99% of the time/>", null);
			string result = formatter.Format(GetContext("name"), new SCImpl<Code>(codedString));
			Assert.AreEqual("<name>&lt;cats think they&apos;re &gt; humans &amp; dogs 99% of the time/&gt;</name>".Trim(), result.Trim
				(), "something in text node");
		}
	}
}
