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
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2
{
	[TestFixture]
	public class MoR2PropertyFormatterTest : FormatterTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNull()
		{
			FormatContext context = GetContext("name");
			string result = new MoR2PropertyFormatter().Format(context, new MOImpl((Money)null));
			Assert.AreEqual("<name nullFlavor=\"NI\"/>", result.Trim(), "named null format");
			Assert.IsTrue(context.GetModelToXmlResult().IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNonNull()
		{
			MoR2PropertyFormatter formatter = new MoR2PropertyFormatter();
			Money money = new Money(new BigDecimal("12.00"), Ca.Infoway.Messagebuilder.Domainvalue.Basic.Currency.CANADIAN_DOLLAR);
			FormatContext context = GetContext("amount");
			string result = formatter.Format(context, new MOImpl(money));
			Assert.AreEqual("<amount currency=\"CAD\" value=\"12.00\"/>", result.Trim(), "something in text node");
			Assert.IsTrue(context.GetModelToXmlResult().IsValid());
			context.GetModelToXmlResult().ClearErrors();
			money = new Money(new BigDecimal("12"), Ca.Infoway.Messagebuilder.Domainvalue.Basic.Currency.CANADIAN_DOLLAR);
			result = formatter.Format(context, new MOImpl(money));
			Assert.AreEqual("<amount currency=\"CAD\" value=\"12\"/>", result.Trim(), "something in text node");
			Assert.IsTrue(context.GetModelToXmlResult().IsValid());
			context.GetModelToXmlResult().ClearErrors();
			money = new Money(new BigDecimal("12.0000"), Ca.Infoway.Messagebuilder.Domainvalue.Basic.Currency.EURO);
			result = formatter.Format(context, new MOImpl(money));
			Assert.AreEqual("<amount currency=\"EUR\" value=\"12.0000\"/>", result.Trim(), "something in text node");
			Assert.IsTrue(context.GetModelToXmlResult().IsValid());
			context.GetModelToXmlResult().ClearErrors();
			money = new Money(null, Ca.Infoway.Messagebuilder.Domainvalue.Basic.Currency.EURO);
			result = formatter.Format(context, new MOImpl(money));
			Assert.AreEqual("<amount currency=\"EUR\"/>", result.Trim(), "something in text node");
			Assert.IsTrue(context.GetModelToXmlResult().IsValid());
			context.GetModelToXmlResult().ClearErrors();
			money = new Money(new BigDecimal("12.0000"), null);
			result = formatter.Format(context, new MOImpl(money));
			Assert.IsTrue(context.GetModelToXmlResult().IsValid());
			context.GetModelToXmlResult().ClearErrors();
			money = new Money(new BigDecimal("123456789012.00"), Ca.Infoway.Messagebuilder.Domainvalue.Basic.Currency.CANADIAN_DOLLAR
				);
			result = formatter.Format(context, new MOImpl(money));
			Assert.AreEqual("<amount currency=\"CAD\" value=\"123456789012.00\"/>", result.Trim(), "something in text node");
			Assert.IsTrue(context.GetModelToXmlResult().IsValid());
			context.GetModelToXmlResult().ClearErrors();
			money = new Money(new BigDecimal("-89012.00"), Ca.Infoway.Messagebuilder.Domainvalue.Basic.Currency.CANADIAN_DOLLAR);
			result = formatter.Format(context, new MOImpl(money));
			Assert.AreEqual("<amount currency=\"CAD\" value=\"-89012.00\"/>", result.Trim(), "something in text node");
			Assert.IsFalse(context.GetModelToXmlResult().IsValid());
			Assert.AreEqual(1, context.GetModelToXmlResult().GetHl7Errors().Count);
		}

		// only digits allowed
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNonNullWithOperatorNotAllowed()
		{
			MoR2PropertyFormatter formatter = new MoR2PropertyFormatter();
			Money money = new Money(new BigDecimal("12.00"), Ca.Infoway.Messagebuilder.Domainvalue.Basic.Currency.CANADIAN_DOLLAR);
			FormatContext context = GetContext("amount");
			MOImpl dataType = new MOImpl(money);
			dataType.Operator = SetOperator.CONVEX_HULL;
			string result = formatter.Format(context, dataType);
			Assert.AreEqual("<amount currency=\"CAD\" value=\"12.00\"/>", result.Trim(), "something in text node");
			Assert.IsFalse(context.GetModelToXmlResult().IsValid());
			Assert.AreEqual(1, context.GetModelToXmlResult().GetHl7Errors().Count);
			Assert.IsTrue(context.GetModelToXmlResult().GetHl7Errors()[0].GetMessage().ToLower().Contains("operator"));
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatSxcmValueNonNullWithOperatorAllowed()
		{
			MoR2PropertyFormatter formatter = new MoR2PropertyFormatter();
			Money money = new Money(new BigDecimal("12.00"), Ca.Infoway.Messagebuilder.Domainvalue.Basic.Currency.CANADIAN_DOLLAR);
			FormatContext context = GetContext("amount", "SXCM<TS>");
			MOImpl dataType = new MOImpl(money);
			dataType.Operator = SetOperator.CONVEX_HULL;
			string result = formatter.Format(context, dataType);
			Assert.AreEqual("<amount currency=\"CAD\" operator=\"H\" value=\"12.00\"/>", result.Trim(), "something in text node");
			Assert.IsTrue(context.GetModelToXmlResult().IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatSxcmValueNonNullWithNoOperator()
		{
			MoR2PropertyFormatter formatter = new MoR2PropertyFormatter();
			Money money = new Money(new BigDecimal("12.00"), Ca.Infoway.Messagebuilder.Domainvalue.Basic.Currency.CANADIAN_DOLLAR);
			FormatContext context = GetContext("amount", "SXCM<TS>");
			MOImpl dataType = new MOImpl(money);
			string result = formatter.Format(context, dataType);
			Assert.AreEqual("<amount currency=\"CAD\" value=\"12.00\"/>", result.Trim(), "something in text node");
			Assert.IsTrue(context.GetModelToXmlResult().IsValid());
		}
	}
}
