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
using Ca.Infoway.Messagebuilder.J5goodies;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2
{
	[TestFixture]
	public class TnR2PropertyFormatterTest : FormatterTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNull()
		{
			string result = new EnR2PropertyFormatter().Format(GetContext("name", "TN"), new TNImpl());
			Assert.IsTrue(this.result.IsValid());
			Assert.AreEqual("<name nullFlavor=\"NI\"/>", result.Trim(), "named null format");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNonNull()
		{
			EnR2PropertyFormatter formatter = new EnR2PropertyFormatter();
			string result = formatter.Format(GetContext("name", "TN"), new TNImpl(new TrivialName("something")));
			Assert.IsTrue(this.result.IsValid());
			AssertXml("something in text node", "<name>something</name>", result, true);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNonNullInvalidPart()
		{
			EnR2PropertyFormatter formatter = new EnR2PropertyFormatter();
			TrivialName trivialName = new TrivialName();
			trivialName.AddNamePart(new EntityNamePart("something", PersonNamePartType.FAMILY));
			string result = formatter.Format(GetContext("name", "TN"), new TNImpl(trivialName));
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			AssertXml("something in text node", "<name><family>something</family></name>", result, true);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNonNullInvalidQualifer()
		{
			EnR2PropertyFormatter formatter = new EnR2PropertyFormatter();
			TrivialName trivialName = new TrivialName();
			trivialName.AddNamePart(new EntityNamePart("something", null, Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNamePartQualifier
				.INITIAL));
			string result = formatter.Format(GetContext("name", "TN"), new TNImpl(trivialName));
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			AssertXml("something in text node", "<name>something</name>", result, true);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNonNullWithValidTime()
		{
			PlatformDate lowDate = new DateWithPattern(DateUtil.GetDate(2006, 11, 25), "yyyyMMdd");
			PlatformDate highDate = new DateWithPattern(DateUtil.GetDate(2014, 3, 12), "yyyyMMdd");
			Interval<PlatformDate> validTime = IntervalFactory.CreateLowHigh(lowDate, highDate);
			EnR2PropertyFormatter formatter = new EnR2PropertyFormatter();
			TrivialName trivialName = new TrivialName("something");
			trivialName.ValidTime = validTime;
			string result = formatter.Format(GetContext("name", "TN"), new TNImpl(trivialName));
			Assert.IsTrue(this.result.IsValid());
			AssertXml("something in text node", "<name>something<validTime><low value=\"20061225\"/><high value=\"20140412\"/></validTime></name>"
				, result, true);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueReservedXmlChars()
		{
			EnR2PropertyFormatter formatter = new EnR2PropertyFormatter();
			TrivialName trivialName = new TrivialName("<cats think they're > humans & dogs 99% of the time/>");
			string result = formatter.Format(GetContext("name", "TN"), new TNImpl(trivialName));
			Assert.IsTrue(this.result.IsValid());
			AssertXml("something in text node", "<name>&lt;cats think they&apos;re &gt; humans &amp; dogs 99% of the time/&gt;</name>"
				, result, true);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatInvalidNameUses()
		{
			EnR2PropertyFormatter formatter = new EnR2PropertyFormatter();
			EntityName name = new TrivialName("something");
			name.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.ALPHABETIC);
			name.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.IDEOGRAPHIC);
			string result = formatter.Format(GetContext("name", "TN"), new ENImpl<EntityName>(name));
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			AssertXml("something in text node", "<name use=\"ABC IDE\">something</name>", result, true);
		}
	}
}
