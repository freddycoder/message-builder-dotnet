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
using Ca.Infoway.Messagebuilder.Resolver.Configurator;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class PivlTsPropertyFormatterTest : FormatterTestCase
	{
		[SetUp]
		public virtual void Setup()
		{
			DefaultCodeResolutionConfigurator.ConfigureCodeResolversWithTrivialDefault();
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestBasicCase()
		{
			PhysicalQuantity quantity = new PhysicalQuantity(new BigDecimal(1), Ca.Infoway.Messagebuilder.Domainvalue.Basic.DefaultTimeUnit
				.DAY);
			PeriodicIntervalTime frequency = PeriodicIntervalTime.CreateFrequency(3, quantity);
			string result = new PivlTsPropertyFormatter().Format(GetContext("periodicInterval", "PIVL<TS.DATETIME>"), new PIVLImpl(frequency
				));
			Assert.IsTrue(this.result.IsValid());
			AssertXml("result", "<periodicInterval><frequency><numerator value=\"3\"/><denominator unit=\"d\" value=\"1\"/></frequency></periodicInterval>"
				, result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestBasicCaseForSk()
		{
			PhysicalQuantity lowQuantity = new PhysicalQuantity(new BigDecimal(1), Ca.Infoway.Messagebuilder.Domainvalue.Basic.DefaultTimeUnit
				.DAY);
			PhysicalQuantity highQuantity = new PhysicalQuantity(new BigDecimal(4), Ca.Infoway.Messagebuilder.Domainvalue.Basic.DefaultTimeUnit
				.DAY);
			PeriodicIntervalTimeSk frequencySk = PeriodicIntervalTimeSk.CreateFrequencySk(3, lowQuantity, highQuantity);
			string result = new PivlTsPropertyFormatter().Format(GetContextSk("periodicInterval", "PIVL<TS.DATETIME>"), new PIVLImpl(
				frequencySk));
			Assert.IsTrue(this.result.IsValid());
			AssertXml("result", "<periodicInterval><frequency><numerator value=\"3\"/><denominator><low unit=\"d\" value=\"1\"/><high unit=\"d\" value=\"4\"/></denominator></frequency></periodicInterval>"
				, result);
		}

		protected virtual FormatContext GetContextSk(string name, string type)
		{
			return new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(this.result, null, name, type, null, null
				, false, SpecificationVersion.V01R04_2_SK, null, null, null, false);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestNoObject()
		{
			string result = new PivlTsPropertyFormatter().Format(GetContext("periodicInterval", "PIVL<TS.DATETIME>"), new PIVLImpl((PeriodicIntervalTime
				)null));
			Assert.IsTrue(this.result.IsValid());
			AssertXml("result", "<periodicInterval nullFlavor=\"NI\"/>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestMissingValues()
		{
			PeriodicIntervalTime frequency = PeriodicIntervalTime.CreateFrequency(null, null);
			string result = new PivlTsPropertyFormatter().Format(GetContext("periodicInterval", "PIVL<TS.DATETIME>"), new PIVLImpl(frequency
				));
			AssertXml("result", "<periodicInterval></periodicInterval>", result);
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestMissingValuesSk()
		{
			PeriodicIntervalTimeSk frequencySk = PeriodicIntervalTimeSk.CreateFrequencySk(null, null, null);
			string result = new PivlTsPropertyFormatter().Format(GetContextSk("periodicInterval", "PIVL<TS.DATETIME>"), new PIVLImpl(
				frequencySk));
			AssertXml("result", "<periodicInterval></periodicInterval>", result);
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestMissingQuantitiesSk()
		{
			PeriodicIntervalTimeSk frequencySk = PeriodicIntervalTimeSk.CreateFrequencySk(2, null, null);
			string result = new PivlTsPropertyFormatter().Format(GetContextSk("periodicInterval", "PIVL<TS.DATETIME>"), new PIVLImpl(
				frequencySk));
			AssertXml("result", "<periodicInterval></periodicInterval>", result);
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
		}
	}
}
