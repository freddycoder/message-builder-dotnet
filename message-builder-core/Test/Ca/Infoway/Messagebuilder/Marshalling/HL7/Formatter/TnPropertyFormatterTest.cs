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
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class TnPropertyFormatterTest : FormatterTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNull()
		{
			string result = new TnPropertyFormatter().Format(GetContext("name"), new TNImpl());
			Assert.AreEqual("<name nullFlavor=\"NI\"/>", result.Trim(), "named null format");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNonNull()
		{
			TnPropertyFormatter formatter = new TnPropertyFormatter();
			string result = formatter.Format(GetContext("name"), new TNImpl(new TrivialName("something")));
			Assert.AreEqual("<name>something</name>", result.Trim(), "something in text node");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueReservedXmlChars()
		{
			TnPropertyFormatter formatter = new TnPropertyFormatter();
			TrivialName trivialName = new TrivialName("<cats think they're > humans & dogs 99% of the time/>");
			string result = formatter.Format(GetContext("name"), new TNImpl(trivialName));
			Assert.AreEqual("<name>&lt;cats think they&apos;re &gt; humans &amp; dogs 99% of the time/&gt;</name>".Trim(), result.Trim
				(), "something in text node");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatNameUses()
		{
			TnPropertyFormatter formatter = new TnPropertyFormatter();
			EntityName name = new TrivialName("something");
			name.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.ALPHABETIC);
			name.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.IDEOGRAPHIC);
			// since the uses as a set, order is not guaranteed
			string result = formatter.Format(GetContext("name"), new ENImpl<EntityName>(name));
			Assert.IsTrue(result.StartsWith("<name use=\""), "open tag");
			Assert.IsTrue(result.Contains("ABC IDE") || result.Contains("IDE ABC"), "ABC");
			Assert.IsTrue(result.Trim().EndsWith("\">something</name>"), "close tag");
		}
	}
}
