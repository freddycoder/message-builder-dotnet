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
using System;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[TestFixture]
	public class IntElementParserTest : MarshallingTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNullNode()
		{
			XmlNode node = CreateNode("<something nullFlavor=\"NI\"/>");
			INT parsedInt = (INT)new IntElementParser().Parse(CreateContext("INT.POS"), node, this.xmlResult);
			Assert.IsNull(parsedInt.Value, "null returned");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION, parsedInt.NullFlavor, "null flavor"
				);
			Assert.IsTrue(this.xmlResult.IsValid(), "no errors");
		}

		private ParseContext CreateContext(string hl7Type)
		{
			return ParseContextImpl.Create(hl7Type, typeof(Int32?), SpecificationVersion.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.POPULATED, null, null, false);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseEmptyNode()
		{
			XmlNode node = CreateNode("<something/>");
			Assert.IsNull(new IntElementParser().Parse(CreateContext("INT.POS"), node, this.xmlResult).BareValue, "null returned");
			Assert.IsFalse(this.xmlResult.IsValid(), "error");
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count, "1 error expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNoValueAttributeNode()
		{
			XmlNode node = CreateNode("<something notvalue=\"\" />");
			Assert.IsNull(new IntElementParser().Parse(CreateContext("INT.POS"), node, this.xmlResult).BareValue, "null returned");
			Assert.IsFalse(this.xmlResult.IsValid(), "error");
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count, "1 error expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueAttributeValid()
		{
			XmlNode node = CreateNode("<something value=\"1345\" />");
			Assert.AreEqual(System.Convert.ToInt32("1345"), new IntElementParser().Parse(CreateContext("INT.POS"), node, this.xmlResult
				).BareValue, "correct value returned");
			Assert.IsTrue(this.xmlResult.IsValid(), "no errors");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueAttributeValidZero()
		{
			XmlNode node = CreateNode("<something value=\"0\" />");
			Assert.AreEqual(System.Convert.ToInt32("0"), new IntElementParser().Parse(CreateContext("INT.NONNEG"), node, this.xmlResult
				).BareValue, "correct value returned");
			Assert.IsTrue(this.xmlResult.IsValid(), "no errors");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueAttributeInvalidNegative()
		{
			XmlNode node = CreateNode("<something value=\"-1\" />");
			Assert.AreEqual(System.Convert.ToInt32("-1"), new IntElementParser().Parse(CreateContext("INT.POS"), node, this.xmlResult
				).BareValue, "correct value returned");
			Assert.IsFalse(this.xmlResult.IsValid(), "error");
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count, "1 error expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueAttributeInvalidNegative2()
		{
			XmlNode node = CreateNode("<something value=\"-1\" />");
			Assert.AreEqual(System.Convert.ToInt32("-1"), new IntElementParser().Parse(CreateContext("INT.NONNEG"), node, this.xmlResult
				).BareValue, "correct value returned");
			Assert.IsFalse(this.xmlResult.IsValid(), "error");
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count, "1 error expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueAttributeValidNegative()
		{
			XmlNode node = CreateNode("<something value=\"-1\" />");
			Assert.AreEqual(System.Convert.ToInt32("-1"), new IntElementParser().Parse(CreateContext("INT"), node, this.xmlResult).BareValue
				, "correct value returned");
			Assert.IsTrue(this.xmlResult.IsValid(), "no errors");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueAttributeValidPlusExtraAttribute()
		{
			XmlNode node = CreateNode("<something extra=\"value\" value=\"1345\" />");
			Assert.AreEqual(System.Convert.ToInt32("1345"), new IntElementParser().Parse(CreateContext("INT.POS"), node, this.xmlResult
				).BareValue, "correct value returned");
			Assert.IsTrue(this.xmlResult.IsValid(), "no errors");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseEmptyValue()
		{
			XmlNode node = CreateNode("<something value=\"\" />");
			Assert.AreEqual(null, new IntElementParser().Parse(CreateContext("INT.POS"), node, this.xmlResult).BareValue, "correct value returned"
				);
			Assert.IsFalse(this.xmlResult.IsValid(), "error");
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count, "1 error expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseElementWithTextNodes()
		{
			XmlNode node = CreateNode("<something value=\"3\" >\n</something>");
			Assert.AreEqual(3, new IntElementParser().Parse(CreateContext("INT.POS"), node, this.xmlResult).BareValue, "correct value returned"
				);
			Assert.IsTrue(this.xmlResult.IsValid(), "no errors");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseTooManyChildNodes()
		{
			XmlNode node = CreateNode("<something>" + "<monkey/>" + "</something>");
			try
			{
				new IntElementParser().Parse(new TrivialContext("INT.POS"), node, this.xmlResult);
				Assert.Fail("expected exception");
			}
			catch (XmlToModelTransformationException e)
			{
				// expected
				Assert.AreEqual("Expected INT.POS node to have no children", e.Message, "proper exception returned");
			}
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalidValueAttribute()
		{
			XmlNode node = CreateNode("<something value=\"monkey\" />");
			new IntElementParser().Parse(CreateContext("INT.POS"), node, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid(), "error");
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count, "1 error expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueWithZeroForIntPosAttribute()
		{
			XmlNode node = CreateNode("<something value=\"0\" />");
			new IntElementParser().Parse(CreateContext("INT.POS"), node, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid(), "error");
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count, "1 error expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueWithZeroForIntNonNegAttribute()
		{
			XmlNode node = CreateNode("<something value=\"0\" />");
			new IntElementParser().Parse(CreateContext("INT.NONNEG"), node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid(), "no errors");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueAttributeValidIntgerWithDecimal()
		{
			XmlNode node = CreateNode("<something value=\"1345.000\" />");
			Assert.AreEqual(System.Convert.ToInt32("1345"), new IntElementParser().Parse(CreateContext("INT.POS"), node, this.xmlResult
				).BareValue, "correct value returned");
			Assert.IsFalse(this.xmlResult.IsValid(), "error");
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count, "1 error expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueAttributeValidIntgerWithOtherDecimal()
		{
			XmlNode node = CreateNode("<something value=\"1345.999\" />");
			Assert.AreEqual(System.Convert.ToInt32("1345"), new IntElementParser().Parse(CreateContext("INT.POS"), node, this.xmlResult
				).BareValue, "correct value returned");
			Assert.IsFalse(this.xmlResult.IsValid(), "error");
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count, "1 error expected");
		}
	}
}
