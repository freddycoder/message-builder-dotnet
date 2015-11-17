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
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2
{
	[TestFixture]
	public class CrR2ElementParserTest : CeRxDomainValueTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNullNode()
		{
			XmlNode node = CreateNode("<something nullFlavor=\"NI\" />");
			CR cr = (CR)new CrR2ElementParser().Parse(CreateContext(), node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.IsNull(cr.Value, "value");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION, cr.NullFlavor, "null flavor");
		}

		private ParseContext CreateContext()
		{
			return ParseContextImpl.Create("CR", typeof(Ratio<object, object>), SpecificationVersion.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.POPULATED, null, null, false);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseEmptyNode()
		{
			XmlNode node = CreateNode("<something/>");
			CodeRole codeRole = (CodeRole)new CrR2ElementParser().Parse(CreateContext(), node, this.xmlResult).BareValue;
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
			Assert.AreEqual("CR types must have a value element (or a nullFlavor attribute)", this.xmlResult.GetHl7Errors()[0].GetMessage
				());
			Assert.IsNull(codeRole, "code role");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidValue()
		{
			XmlNode node = CreateNode("<something inverted=\"true\"><name code=\"testCode\" codeSystem=\"11.22.33\" /><value code=\"oneMoreCode\" codeSystem=\"55.66.77\" /></something>"
				);
			CodeRole codeRole = (CodeRole)new CrR2ElementParser().Parse(CreateContext(), node, this.xmlResult).BareValue;
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.IsNotNull(codeRole, "code role");
			Assert.IsTrue(codeRole.Inverted);
			Assert.AreEqual("testCode", codeRole.Name.GetCodeValue());
			Assert.AreEqual("11.22.33", codeRole.Name.GetCodeSystem());
			Assert.AreEqual("oneMoreCode", codeRole.Value.GetCodeValue());
			Assert.AreEqual("55.66.77", codeRole.Value.GetCodeSystem());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidTooManyValues()
		{
			XmlNode node = CreateNode("<something inverted=\"true\"><name code=\"testCode\" codeSystem=\"11.22.33\" /><name code=\"xtestCode\" codeSystem=\"x11.22.33\" /><value code=\"oneMoreCode\" codeSystem=\"55.66.77\" /><value code=\"xoneMoreCode\" codeSystem=\"x55.66.77\" /></something>"
				);
			CodeRole codeRole = (CodeRole)new CrR2ElementParser().Parse(CreateContext(), node, this.xmlResult).BareValue;
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(2, this.xmlResult.GetHl7Errors().Count);
			Assert.IsNotNull(codeRole, "code role");
			Assert.IsTrue(codeRole.Inverted);
			Assert.AreEqual("testCode", codeRole.Name.GetCodeValue());
			Assert.AreEqual("11.22.33", codeRole.Name.GetCodeSystem());
			Assert.AreEqual("oneMoreCode", codeRole.Value.GetCodeValue());
			Assert.AreEqual("55.66.77", codeRole.Value.GetCodeSystem());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalidValueAttribute()
		{
			XmlNode node = CreateNode("<something><numerator value=\"monkey\" /><denominator value=\"2345.67\" /></something>");
			new CrR2ElementParser().Parse(CreateContext(), node, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
		}
	}
}
