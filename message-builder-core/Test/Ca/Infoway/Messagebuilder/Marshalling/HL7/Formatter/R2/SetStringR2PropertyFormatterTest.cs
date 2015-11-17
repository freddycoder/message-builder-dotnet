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
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2;
using Ca.Infoway.Messagebuilder.Xml;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2
{
	[TestFixture]
	public class SetStringR2PropertyFormatterTest : FormatterTestCase
	{
		private FormatterR2Registry formatterRegistry = FormatterR2Registry.GetInstance();

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNull()
		{
			string result = new SetR2PropertyFormatter(this.formatterRegistry).Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(new ModelToXmlResult(), null, "blah", "SET<ST>", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY, null, false)
				, new SETImpl<ST, string>(typeof(STImpl), Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION));
			AssertXml("null", "<blah nullFlavor=\"NI\"/>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNonNull()
		{
			string result = new SetR2PropertyFormatter(this.formatterRegistry).Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(new ModelToXmlResult(), null, "blah", "SET<ST>", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY, Cardinality.
				Create("1-4"), false), SETImpl<ANY<object>, object>.Create<ST, string>(typeof(STImpl), MakeSet("Fred", "Wilma")));
			AssertXml("non null", "<blah>Fred</blah><blah>Wilma</blah>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueTooMany()
		{
			string result = new SetR2PropertyFormatter(this.formatterRegistry).Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(this.result, null, "blah", "SET<ST>", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY, Cardinality.Create("1-2"
				), false), SETImpl<ANY<object>, object>.Create<ST, string>(typeof(STImpl), MakeSet("Fred", "Wilma", "Barney")));
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			Assert.AreEqual("Number of elements (3) is more than the specified maximum (2)", this.result.GetHl7Errors()[0].GetMessage
				());
			Assert.IsTrue(result.Contains("<blah>Fred</blah>"));
			Assert.IsTrue(result.Contains("<blah>Wilma</blah>"));
			Assert.IsTrue(result.Contains("<blah>Barney</blah>"));
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueTooFew()
		{
			string result = new SetR2PropertyFormatter(this.formatterRegistry).Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(this.result, null, "blah", "SET<ST>", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY, Cardinality.Create("4-6"
				), false), SETImpl<ANY<object>, object>.Create<ST, string>(typeof(STImpl), MakeSet("Fred", "Wilma", "Barney")));
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			Assert.AreEqual("Number of elements (3) is less than the specified minimum (4)", this.result.GetHl7Errors()[0].GetMessage
				());
			Assert.IsTrue(result.Contains("<blah>Fred</blah>"));
			Assert.IsTrue(result.Contains("<blah>Wilma</blah>"));
			Assert.IsTrue(result.Contains("<blah>Barney</blah>"));
		}
	}
}
