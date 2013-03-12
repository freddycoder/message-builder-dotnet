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
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class MoPropertyFormatterTest : FormatterTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNull()
		{
			FormatContext context = GetContext("name");
			string result = new MoPropertyFormatter().Format(context, new MOImpl((Money)null));
			Assert.AreEqual("<name nullFlavor=\"NI\"/>", result.Trim(), "named null format");
			Assert.IsTrue(context.GetModelToXmlResult().IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNonNull()
		{
			MoPropertyFormatter formatter = new MoPropertyFormatter();
			Money money = new Money(new BigDecimal("12.00"), Currency.CANADIAN_DOLLAR);
			FormatContext context = GetContext("amount");
			string result = formatter.Format(context, new MOImpl(money));
			Assert.AreEqual("<amount currency=\"CAD\" value=\"12.00\"/>", result.Trim(), "something in text node");
			Assert.IsTrue(context.GetModelToXmlResult().IsValid());
			context.GetModelToXmlResult().ClearErrors();
			money = new Money(new BigDecimal("12"), Currency.CANADIAN_DOLLAR);
			result = formatter.Format(context, new MOImpl(money));
			Assert.AreEqual("<amount currency=\"CAD\" value=\"12\"/>", result.Trim(), "something in text node");
			Assert.IsTrue(context.GetModelToXmlResult().IsValid());
			context.GetModelToXmlResult().ClearErrors();
			money = new Money(new BigDecimal("12.0000"), Currency.EURO);
			result = formatter.Format(context, new MOImpl(money));
			Assert.AreEqual("<amount currency=\"EUR\" value=\"12.0000\"/>", result.Trim(), "something in text node");
			Assert.IsFalse(context.GetModelToXmlResult().IsValid());
			Assert.AreEqual(2, context.GetModelToXmlResult().GetHl7Errors().Count);
			// bad currency; too many digits right of decimal
			context.GetModelToXmlResult().ClearErrors();
			money = new Money(null, Currency.EURO);
			result = formatter.Format(context, new MOImpl(money));
			Assert.AreEqual("<amount currency=\"EUR\"/>", result.Trim(), "something in text node");
			Assert.IsFalse(context.GetModelToXmlResult().IsValid());
			Assert.AreEqual(2, context.GetModelToXmlResult().GetHl7Errors().Count);
			// bad currency; missing value
			context.GetModelToXmlResult().ClearErrors();
			money = new Money(new BigDecimal("12.0000"), null);
			result = formatter.Format(context, new MOImpl(money));
			Assert.AreEqual("<amount value=\"12.0000\"/>", result.Trim(), "something in text node");
			// missing currency; too many digits right of decimal
			Assert.IsFalse(context.GetModelToXmlResult().IsValid());
			Assert.AreEqual(2, context.GetModelToXmlResult().GetHl7Errors().Count);
			context.GetModelToXmlResult().ClearErrors();
			money = new Money(new BigDecimal("123456789012.00"), Currency.CANADIAN_DOLLAR);
			result = formatter.Format(context, new MOImpl(money));
			Assert.AreEqual("<amount currency=\"CAD\" value=\"123456789012.00\"/>", result.Trim(), "something in text node");
			Assert.IsFalse(context.GetModelToXmlResult().IsValid());
			Assert.AreEqual(1, context.GetModelToXmlResult().GetHl7Errors().Count);
			// too many digit left of decimal
			context.GetModelToXmlResult().ClearErrors();
			money = new Money(new BigDecimal("-89012.00"), Currency.CANADIAN_DOLLAR);
			result = formatter.Format(context, new MOImpl(money));
			Assert.AreEqual("<amount currency=\"CAD\" value=\"-89012.00\"/>", result.Trim(), "something in text node");
			Assert.IsFalse(context.GetModelToXmlResult().IsValid());
			Assert.AreEqual(1, context.GetModelToXmlResult().GetHl7Errors().Count);
		}
		// only digits allowed
	}
}
