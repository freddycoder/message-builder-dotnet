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
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Xml;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class SetCdPropertyFormatterTest : FormatterTestCase
	{
		private SetPropertyFormatter formatter;

		/// <exception cref="System.Exception"></exception>
		[NUnit.Framework.SetUp]
		public virtual void SetUp()
		{
			this.formatter = new SetPropertyFormatter(FormatterRegistry.GetInstance());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNull()
		{
			string result = this.formatter.Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(this.result
				, null, "blah", "SET<CD>", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY, null, false, SpecificationVersion.R02_04_02
				, null, null, CodingStrength.CNE, false), new SETImpl<CD, Code>(typeof(CDImpl), Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor
				.NO_INFORMATION));
			Assert.IsFalse(this.result.IsValid());
			// blah is mandatory
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			AssertXml("null", "<blah nullFlavor=\"NI\"/>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNullNotMandatory()
		{
			string result = this.formatter.Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(this.result
				, null, "blah", "SET<CD>", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, false, SpecificationVersion.R02_04_02
				, null, null, CodingStrength.CNE, false), null);
			Assert.IsTrue(this.result.IsValid());
			AssertXml("null", string.Empty, result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNonNull()
		{
			string result = this.formatter.Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(this.result
				, null, "blah", "SET<CD>", "x_BasicUnitsOfMeasure", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY, Cardinality
				.Create("1-4"), false, SpecificationVersion.R02_04_02, null, null, CodingStrength.CNE, null, false), SETImpl<ANY<object>
				, object>.Create<CD, Code>(typeof(CDImpl), MakeSet(Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive
				.CENTIMETRE, Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive.KILOGRAM)));
			Assert.IsTrue(this.result.IsValid());
			AssertXml("non null", "<blah code=\"cm\" codeSystem=\"2.16.840.1.113883.5.141\"/><blah code=\"kg\" codeSystem=\"2.16.840.1.113883.5.141\"/>"
				, result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueEmptySet()
		{
			string result = this.formatter.Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(this.result
				, null, "blah", "SET<CD>", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.POPULATED, null, false, SpecificationVersion.R02_04_02
				, null, null, CodingStrength.CNE, false), SETImpl<ANY<object>, object>.Create<CD, Code>(typeof(CDImpl), new HashSet<Code
				>()));
			Assert.IsTrue(this.result.IsValid());
			AssertXml("non null", "<blah nullFlavor=\"NI\"/>", result);
		}
	}
}
