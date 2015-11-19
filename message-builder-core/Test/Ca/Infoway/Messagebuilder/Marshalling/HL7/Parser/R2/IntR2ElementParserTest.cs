using System;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2
{
	[TestFixture]
	public class IntR2ElementParserTest : MarshallingTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNullNode()
		{
			XmlNode node = CreateNode("<something nullFlavor=\"NI\"/>");
			INT parsedInt = (INT)new IntR2ElementParser().Parse(CreateContext("INT"), node, this.xmlResult);
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
			Assert.IsNull(new IntR2ElementParser().Parse(CreateContext("INT"), node, this.xmlResult).BareValue, "null returned");
			Assert.IsFalse(this.xmlResult.IsValid(), "error");
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count, "1 error expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNoValueAttributeNode()
		{
			XmlNode node = CreateNode("<something notvalue=\"\" />");
			Assert.IsNull(new IntR2ElementParser().Parse(CreateContext("INT"), node, this.xmlResult).BareValue, "null returned");
			Assert.IsFalse(this.xmlResult.IsValid(), "error");
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count, "1 error expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueAttributeValid()
		{
			XmlNode node = CreateNode("<something value=\"1345\" />");
			INTImpl anyInt = (INTImpl)new IntR2ElementParser().Parse(CreateContext("INT"), node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid(), "no errors");
			Assert.AreEqual(System.Convert.ToInt32("1345"), anyInt.BareValue, "correct value returned");
			Assert.IsFalse(anyInt.Unsorted, "unsorted default");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueWithUnsorted()
		{
			XmlNode node = CreateNode("<something unsorted=\"true\" value=\"1345\" />");
			INTImpl anyInt = (INTImpl)new IntR2ElementParser().Parse(CreateContext("INT"), node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid(), "no errors");
			Assert.AreEqual(System.Convert.ToInt32("1345"), anyInt.BareValue, "correct value returned");
			Assert.IsTrue(anyInt.Unsorted, "unsorted");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueAttributeValidWithOperatorNotAllowed()
		{
			XmlNode node = CreateNode("<something operator=\"P\" value=\"1345\" />");
			BareANY intAny = new IntR2ElementParser().Parse(CreateContext("INT"), node, this.xmlResult);
			Assert.AreEqual(System.Convert.ToInt32("1345"), intAny.BareValue, "correct value returned");
			Assert.IsNull(((ANYMetaData)intAny).Operator, "no operator");
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count, "1 error expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueAttributeValidWithOperatorAllowed()
		{
			XmlNode node = CreateNode("<something operator=\"P\" value=\"1345\" />");
			BareANY intAny = new IntR2ElementParser().Parse(CreateContext("SXCM<INT>"), node, this.xmlResult);
			Assert.AreEqual(System.Convert.ToInt32("1345"), intAny.BareValue, "correct value returned");
			Assert.IsTrue(this.xmlResult.IsValid(), "no errors");
			Assert.AreEqual(SetOperator.PERIODIC_HULL, ((ANYMetaData)intAny).Operator, "operator");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueAttributeValidWithDefaultOperator()
		{
			XmlNode node = CreateNode("<something value=\"1345\" />");
			BareANY intAny = new IntR2ElementParser().Parse(CreateContext("SXCM<INT>"), node, this.xmlResult);
			Assert.AreEqual(System.Convert.ToInt32("1345"), intAny.BareValue, "correct value returned");
			Assert.IsTrue(this.xmlResult.IsValid(), "no errors");
			Assert.AreEqual(SetOperator.INCLUDE, ((ANYMetaData)intAny).Operator, "operator");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueAttributeValidZero()
		{
			XmlNode node = CreateNode("<something value=\"0\" />");
			Assert.AreEqual(System.Convert.ToInt32("0"), new IntR2ElementParser().Parse(CreateContext("INT"), node, this.xmlResult).BareValue
				, "correct value returned");
			Assert.IsTrue(this.xmlResult.IsValid(), "no errors");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueAttributeValidNegative()
		{
			XmlNode node = CreateNode("<something value=\"-1\" />");
			Assert.AreEqual(System.Convert.ToInt32("-1"), new IntR2ElementParser().Parse(CreateContext("INT"), node, this.xmlResult).
				BareValue, "correct value returned");
			Assert.IsTrue(this.xmlResult.IsValid(), "no errors");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueAttributeInvalidNegative()
		{
			XmlNode node = CreateNode("<something value=\"-\" />");
			Assert.AreEqual(null, new IntR2ElementParser().Parse(CreateContext("INT"), node, this.xmlResult).BareValue, "correct value returned"
				);
			Assert.IsFalse(this.xmlResult.IsValid(), "error");
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count, "1 error expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueAttributeInvalidHexValue()
		{
			XmlNode node = CreateNode("<something value=\"0x1a\" />");
			Assert.AreEqual(System.Convert.ToInt32("26"), new IntR2ElementParser().Parse(CreateContext("INT"), node, this.xmlResult).
				BareValue, "correct value returned");
			Assert.IsFalse(this.xmlResult.IsValid(), "error");
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count, "1 error expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueAttributeValidPlusExtraAttribute()
		{
			XmlNode node = CreateNode("<something extra=\"value\" value=\"1345\" />");
			Assert.AreEqual(System.Convert.ToInt32("1345"), new IntR2ElementParser().Parse(CreateContext("INT"), node, this.xmlResult
				).BareValue, "correct value returned");
			Assert.IsTrue(this.xmlResult.IsValid(), "no errors");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseEmptyValue()
		{
			XmlNode node = CreateNode("<something value=\"\" />");
			Assert.AreEqual(null, new IntR2ElementParser().Parse(CreateContext("INT"), node, this.xmlResult).BareValue, "correct value returned"
				);
			Assert.IsFalse(this.xmlResult.IsValid(), "error");
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count, "1 error expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseElementWithTextNodes()
		{
			XmlNode node = CreateNode("<something value=\"3\" >\n</something>");
			Assert.AreEqual(3, new IntR2ElementParser().Parse(CreateContext("INT"), node, this.xmlResult).BareValue, "correct value returned"
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
				new IntR2ElementParser().Parse(new TrivialContext("INT"), node, this.xmlResult);
				Assert.Fail("expected exception");
			}
			catch (XmlToModelTransformationException e)
			{
				// expected
				Assert.AreEqual("Expected INT node to have no children", e.Message, "proper exception returned");
			}
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalidValueAttribute()
		{
			XmlNode node = CreateNode("<something value=\"monkey\" />");
			new IntR2ElementParser().Parse(CreateContext("INT"), node, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid(), "error");
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count, "1 error expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueWithZeroForIntAttribute()
		{
			XmlNode node = CreateNode("<something value=\"0\" />");
			new IntR2ElementParser().Parse(CreateContext("INT"), node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid(), "no errors");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueAttributeValidIntgerWithDecimal()
		{
			XmlNode node = CreateNode("<something value=\"1345.000\" />");
			Assert.AreEqual(System.Convert.ToInt32("1345"), new IntR2ElementParser().Parse(CreateContext("INT"), node, this.xmlResult
				).BareValue, "correct value returned");
			Assert.IsFalse(this.xmlResult.IsValid(), "error");
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count, "1 error expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueAttributeValidIntgerWithOtherDecimal()
		{
			XmlNode node = CreateNode("<something value=\"1345.999\" />");
			Assert.AreEqual(System.Convert.ToInt32("1345"), new IntR2ElementParser().Parse(CreateContext("INT"), node, this.xmlResult
				).BareValue, "correct value returned");
			Assert.IsFalse(this.xmlResult.IsValid(), "error");
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count, "1 error expected");
		}
	}
}
