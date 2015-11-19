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
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Xml;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class SetCePropertyFormatterTest : FormatterTestCase
	{
		private FormatterRegistry formatterRegistry = FormatterRegistry.GetInstance();

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNull()
		{
			string result = new SetPropertyFormatter(this.formatterRegistry).Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(this.result, null, "blah", "SET<CE>", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY, null, false, SpecificationVersion
				.R02_04_02, null, null, CodingStrength.CNE, false), new SETImpl<CE, Code>(typeof(CEImpl), Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor
				.NO_INFORMATION));
			Assert.IsFalse(this.result.IsValid());
			// blah is mandatory
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			AssertXml("null", "<blah nullFlavor=\"NI\"/>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNonNull()
		{
			string result = new SetPropertyFormatter(this.formatterRegistry).Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(this.result, null, "blah", "SET<CE>", "x_BasicUnitsOfMeasure", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY
				, Cardinality.Create("1-4"), false, SpecificationVersion.R02_04_02, null, null, CodingStrength.CNE, null, false), SETImpl
				<ANY<object>, object>.Create<CE, Code>(typeof(CEImpl), MakeSet(Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive
				.CENTIMETRE, Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive.KILOGRAM)));
			Assert.IsTrue(this.result.IsValid());
			AssertXml("non null", "<blah code=\"cm\" codeSystem=\"2.16.840.1.113883.5.141\"/><blah code=\"kg\" codeSystem=\"2.16.840.1.113883.5.141\"/>"
				, result);
		}
	}
}
