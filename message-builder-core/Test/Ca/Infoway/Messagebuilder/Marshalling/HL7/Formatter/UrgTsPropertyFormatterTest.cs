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
using Ca.Infoway.Messagebuilder.J5goodies;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Resolver.Configurator;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class UrgTsPropertyFormatterTest : FormatterTestCase
	{
		[SetUp]
		public virtual void Setup()
		{
			DefaultCodeResolutionConfigurator.ConfigureCodeResolversWithTrivialDefault();
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestBasic()
		{
			UncertainRange<PlatformDate> urg = UncertainRangeFactory.CreateLowHigh(DateUtil.GetDate(2010, 0, 20), DateUtil.GetDate(2011
				, 1, 21));
			string result = new UrgTsPropertyFormatter().Format(GetContext("name", "URG<TS.DATE>"), new URGImpl<TS, PlatformDate>(urg
				));
			Assert.IsTrue(this.result.IsValid());
			AssertXml("result", "<name><low value=\"20100120\"/><high value=\"20110221\"/></name>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestBasicWithInvalidInclusiveUsage()
		{
			UncertainRange<PlatformDate> urg = UncertainRangeFactory.CreateLowHigh(DateUtil.GetDate(2010, 0, 20), DateUtil.GetDate(2011
				, 1, 21));
			urg.HighInclusive = true;
			string result = new UrgTsPropertyFormatter().Format(GetContext("name", "URG<TS.DATE>"), new URGImpl<TS, PlatformDate>(urg
				));
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			// should not use inclusive fields with this datatype
			AssertXml("result", "<name><low value=\"20100120\"/><high value=\"20110221\"/></name>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestNullCase()
		{
			string result = new UrgTsPropertyFormatter().Format(GetContext("name", "URG<TS.DATE>"), new URGImpl<TS, PlatformDate>());
			Assert.IsTrue(this.result.IsValid());
			AssertXml("result", "<name nullFlavor=\"NI\"/>", result);
		}
	}
}
