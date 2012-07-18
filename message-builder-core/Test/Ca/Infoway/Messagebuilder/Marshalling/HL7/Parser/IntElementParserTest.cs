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
			INT parsedInt = (INT)new IntElementParser().Parse(CreateContext(), node, this.xmlResult);
			Assert.IsNull(parsedInt.Value, "null returned");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION, parsedInt.NullFlavor, "null flavor"
				);
		}

		private ParseContext CreateContext()
		{
			return ParserContextImpl.Create("Int", typeof(Int32?), SpecificationVersion.NEWFOUNDLAND, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.POPULATED);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseEmptyNode()
		{
			XmlNode node = CreateNode("<something/>");
			Assert.IsNull(new IntElementParser().Parse(null, node, this.xmlResult).BareValue, "null returned");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNoValueAttributeNode()
		{
			XmlNode node = CreateNode("<something notvalue=\"\" />");
			Assert.IsNull(new IntElementParser().Parse(null, node, this.xmlResult).BareValue, "null returned");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueAttributeValid()
		{
			XmlNode node = CreateNode("<something value=\"1345\" />");
			Assert.AreEqual(System.Convert.ToInt32("1345"), new IntElementParser().Parse(null, node, this.xmlResult).BareValue, "correct value returned"
				);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueAttributeValidZero()
		{
			XmlNode node = CreateNode("<something value=\"0\" />");
			Assert.AreEqual(System.Convert.ToInt32("0"), new IntElementParser().Parse(null, node, this.xmlResult).BareValue, "correct value returned"
				);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueAttributeValidNegative()
		{
			XmlNode node = CreateNode("<something value=\"-1\" />");
			Assert.AreEqual(System.Convert.ToInt32("-1"), new IntElementParser().Parse(null, node, this.xmlResult).BareValue, "correct value returned"
				);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueAttributeValidPlusExtraAttribute()
		{
			XmlNode node = CreateNode("<something extra=\"value\" value=\"1345\" />");
			Assert.AreEqual(System.Convert.ToInt32("1345"), new IntElementParser().Parse(null, node, this.xmlResult).BareValue, "correct value returned"
				);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseEmptyValue()
		{
			XmlNode node = CreateNode("<something value=\"\" />");
			Assert.AreEqual(null, new IntElementParser().Parse(null, node, this.xmlResult).BareValue, "correct value returned");
			Assert.IsFalse(this.xmlResult.IsValid(), "error");
			System.Console.Out.WriteLine(this.xmlResult.GetHl7Errors()[0].GetMessage());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseElementWithTextNodes()
		{
			XmlNode node = CreateNode("<something value=\"3\" >\n</something>");
			Assert.AreEqual(3, new IntElementParser().Parse(null, node, this.xmlResult).BareValue, "correct value returned");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseTooManyChildNodes()
		{
			XmlNode node = CreateNode("<something>" + "<monkey/>" + "</something>");
			try
			{
				new IntElementParser().Parse(new TrivialContext("INT"), node, this.xmlResult);
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
			new IntElementParser().Parse(null, node, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid(), "error");
			System.Console.Out.WriteLine(this.xmlResult.GetHl7Errors()[0].GetMessage());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueAttributeValidIntgerWithDecimal()
		{
			XmlNode node = CreateNode("<something value=\"1345.000\" />");
			Assert.AreEqual(System.Convert.ToInt32("1345"), new IntElementParser().Parse(null, node, this.xmlResult).BareValue, "correct value returned"
				);
			Assert.IsFalse(this.xmlResult.IsValid(), "error");
			System.Console.Out.WriteLine(this.xmlResult.GetHl7Errors()[0].GetMessage());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueAttributeValidIntgerWithOtherDecimal()
		{
			XmlNode node = CreateNode("<something value=\"1345.999\" />");
			Assert.AreEqual(System.Convert.ToInt32("1345"), new IntElementParser().Parse(null, node, this.xmlResult).BareValue, "correct value returned"
				);
			Assert.IsFalse(this.xmlResult.IsValid(), "error");
			System.Console.Out.WriteLine(this.xmlResult.GetHl7Errors()[0].GetMessage());
		}
	}
}
