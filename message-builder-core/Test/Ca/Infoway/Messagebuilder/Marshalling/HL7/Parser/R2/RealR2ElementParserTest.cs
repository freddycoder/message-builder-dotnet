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
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2
{
	[TestFixture]
	public class RealR2ElementParserTest : CeRxDomainValueTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNullNode()
		{
			XmlNode node = CreateNode("<something nullFlavor=\"NI\"/>");
			REAL real = (REAL)new RealR2ElementParser().Parse(CreateContext("REAL"), node, this.xmlResult);
			Assert.IsNull(real.Value, "null returned");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION, real.NullFlavor, "null flavor"
				);
			Assert.IsTrue(this.xmlResult.IsValid(), "no errors");
		}

		private ParseContext CreateContext(string type)
		{
			return ParseContextImpl.Create(type, typeof(BigDecimal), SpecificationVersion.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.POPULATED, null, null, false);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseEmptyNode()
		{
			XmlNode node = CreateNode("<something/>");
			REAL real = (REAL)new RealR2ElementParser().Parse(CreateContext("REAL"), node, this.xmlResult);
			Assert.IsNull(real.BareValue, "null returned");
			Assert.IsNull(real.NullFlavor, "no null flavor");
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count, "1 error");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNoValueAttributeNode()
		{
			XmlNode node = CreateNode("<something notvalue=\"\" />");
			REAL real = (REAL)new RealR2ElementParser().Parse(CreateContext("REAL"), node, this.xmlResult);
			Assert.IsNull(real.BareValue, "null returned");
			Assert.IsNull(real.NullFlavor, "no null flavor");
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count, "1 error");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueAttributeValidFraction()
		{
			XmlNode node = CreateNode("<something value=\"0.2345\" />");
			BareANY real = new RealR2ElementParser().Parse(CreateContext("REAL"), node, this.xmlResult);
			Assert.AreEqual(new BigDecimal("0.2345"), real.BareValue, "correct value returned");
			Assert.IsNull(real.NullFlavor, "no null flavor");
			Assert.IsTrue(this.xmlResult.IsValid(), "no errors");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueAttributeValidWithOperatorNotAllowed()
		{
			XmlNode node = CreateNode("<something operator=\"P\" value=\"1345.67\" />");
			BareANY intAny = new RealR2ElementParser().Parse(CreateContext("INT"), node, this.xmlResult);
			Assert.AreEqual(new BigDecimal("1345.67"), intAny.BareValue, "correct value returned");
			Assert.IsNull(((ANYMetaData)intAny).Operator, "no operator");
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count, "1 error expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueAttributeValidWithOperatorAllowed()
		{
			XmlNode node = CreateNode("<something operator=\"P\" value=\"1345.67\" />");
			BareANY intAny = new RealR2ElementParser().Parse(CreateContext("SXCM<INT>"), node, this.xmlResult);
			Assert.AreEqual(new BigDecimal("1345.67"), intAny.BareValue, "correct value returned");
			Assert.IsTrue(this.xmlResult.IsValid(), "no errors");
			Assert.AreEqual(SetOperator.PERIODIC_HULL, ((ANYMetaData)intAny).Operator, "operator");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueAttributeValidWithDefaultOperator()
		{
			XmlNode node = CreateNode("<something value=\"1345.67\" />");
			BareANY intAny = new RealR2ElementParser().Parse(CreateContext("SXCM<INT>"), node, this.xmlResult);
			Assert.AreEqual(new BigDecimal("1345.67"), intAny.BareValue, "correct value returned");
			Assert.IsTrue(this.xmlResult.IsValid(), "no errors");
			Assert.AreEqual(SetOperator.INCLUDE, ((ANYMetaData)intAny).Operator, "operator");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueAttributeValidOneWithZeroesAfterDecimal()
		{
			XmlNode node = CreateNode("<something value=\"1.0000\" />");
			BareANY real = new RealR2ElementParser().Parse(CreateContext("REAL"), node, this.xmlResult);
			Assert.AreEqual(new BigDecimal("1.0000"), real.BareValue, "correct value returned");
			Assert.IsTrue(this.xmlResult.IsValid(), "no errors");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueAttributeValidRealLoneDecimal()
		{
			XmlNode node = CreateNode("<something value=\"1.\" />");
			BareANY real = new RealR2ElementParser().Parse(CreateContext("REAL"), node, this.xmlResult);
			Assert.AreEqual(new BigDecimal("1"), real.BareValue, "correct value returned");
			Assert.IsTrue(this.xmlResult.IsValid(), "no errors");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueAttributeValidRealZero()
		{
			XmlNode node = CreateNode("<something value=\"0\" />");
			Assert.AreEqual(new BigDecimal(0), new RealR2ElementParser().Parse(CreateContext("REAL"), node, this.xmlResult).BareValue
				, "correct value returned");
			Assert.IsTrue(this.xmlResult.IsValid(), "no errors");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueAttributeValidRealLotsOfDigits()
		{
			XmlNode node = CreateNode("<something value=\"9999.9999\" />");
			BareANY real = new RealR2ElementParser().Parse(CreateContext("REAL"), node, this.xmlResult);
			Assert.AreEqual(new BigDecimal("9999.9999"), real.BareValue, "correct value returned");
			Assert.IsTrue(this.xmlResult.IsValid(), "no errors");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueAttributeValidRealNegative()
		{
			XmlNode node = CreateNode("<something value=\"-999.9999\" />");
			BigDecimal bigDecimal = new BigDecimal("-999.9999");
			Assert.AreEqual(bigDecimal, new RealR2ElementParser().Parse(CreateContext("REAL"), node, this.xmlResult).BareValue, "correct value returned"
				);
			Assert.IsTrue(this.xmlResult.IsValid(), "no errors");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueAttributeValidPlusExtraAttribute()
		{
			XmlNode node = CreateNode("<something extra=\"value\" value=\"1345\" />");
			Assert.AreEqual(new BigDecimal("1345"), new RealR2ElementParser().Parse(CreateContext("REAL"), node, this.xmlResult).BareValue
				, "correct value returned");
			Assert.IsTrue(this.xmlResult.IsValid(), "no errors");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseTooManyChildNodes()
		{
			XmlNode node = CreateNode("<something>" + "<monkey/>" + "</something>");
			try
			{
				new RealR2ElementParser().Parse(CreateContext("REAL"), node, this.xmlResult);
				Assert.Fail("expected exception");
			}
			catch (XmlToModelTransformationException e)
			{
				// expected
				Assert.AreEqual("Expected REAL node to have no children", e.Message, "proper exception returned");
			}
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalidValueAttribute()
		{
			XmlNode node = CreateNode("<something value=\"monkey\" />");
			new RealR2ElementParser().Parse(CreateContext("REAL"), node, this.xmlResult);
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count, "errors");
			Assert.AreEqual("Value \"monkey\" of type REAL is not a valid number", this.xmlResult.GetHl7Errors()[0].GetMessage(), "error message"
				);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidValueAttributeNothingBeforeDecimal()
		{
			XmlNode node = CreateNode("<something value=\".11\" />");
			Assert.AreEqual(new BigDecimal(".11"), new RealR2ElementParser().Parse(CreateContext("REAL"), node, this.xmlResult).BareValue
				, "correct value returned");
			Assert.AreEqual(0, this.xmlResult.GetHl7Errors().Count, "errors");
		}

		// try a test with a hex value (these pass NumberUtil.isNumber, but fail when used to create a BigDecimal)
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueAttributeInvalidAsHexValue()
		{
			XmlNode node = CreateNode("<something value=\"0x1a\" />");
			Assert.IsNull(new RealR2ElementParser().Parse(CreateContext("REAL"), node, this.xmlResult).BareValue);
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count, "1 error");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidValueAttributeNothingAfterDecimal()
		{
			XmlNode node = CreateNode("<something value=\"1.\" />");
			Assert.AreEqual(new BigDecimal("1."), new RealR2ElementParser().Parse(CreateContext("REAL"), node, this.xmlResult).BareValue
				, "correct value returned");
			Assert.AreEqual(0, this.xmlResult.GetHl7Errors().Count, "errors");
		}
	}
}
