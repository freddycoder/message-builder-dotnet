using System.Collections.Generic;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Xml;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[TestFixture]
	public class SetIiElementParserTest : ParserTestCase
	{
		private ParserRegistry parserRegistry = ParserRegistry.GetInstance();

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParse()
		{
			XmlNode node = CreateNode("<top>" + "<something root=\"rootValue\" extension=\"fred\" />" + "<something root=\"rootValue2\" extension=\"extensionValue\" />"
				 + "</top>");
			BareANY result = new SetElementParser(this.parserRegistry).Parse(ParseContextImpl.Create("SET<II>", null, SpecificationVersion
				.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY, Cardinality.Create("1-5"), null, false), 
				AsList(node.ChildNodes), new XmlToModelResult());
			ICollection<Identifier> rawSet = ((SET<II, Identifier>)result).RawSet();
			Assert.IsNotNull(rawSet, "null");
			Assert.AreEqual(2, rawSet.Count, "size");
			Assert.IsTrue(rawSet.Contains(new Identifier("rootValue", "fred")));
			Assert.IsTrue(rawSet.Contains(new Identifier("rootValue2", "extensionValue")));
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void RawValueCanBeAddedToParsedValue()
		{
			XmlNode node = CreateNode("<top>" + "<something root=\"1.1\" extension=\"fred\" use=\"BUS\"/>" + "<something root=\"2.2\" extension=\"extensionValue\" use=\"BUS\" />"
				 + "</top>");
			BareANY result = new SetElementParser(this.parserRegistry).Parse(ParseContextImpl.Create("SET<II.BUS>", null, SpecificationVersion
				.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY, Cardinality.Create("1-5"), null, false), 
				AsList(node.ChildNodes), null);
			ICollection<Identifier> rawSet = ((SET<II, Identifier>)result).RawSet();
			rawSet.Add(new Identifier("3.3", "newExtension"));
			Assert.AreEqual(3, rawSet.Count, "size");
			Assert.IsTrue(rawSet.Contains(new Identifier("3.3", "newExtension")));
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void DuplicatesShouldLogValidationError()
		{
			XmlNode node = CreateNode("<top>" + "<something root=\"1.1\" extension=\"fred\" use=\"BUS\"/>" + "<something root=\"2.2\" extension=\"extensionValue\" use=\"BUS\" />"
				 + "<something root=\"2.2\" extension=\"extensionValue\" use=\"BUS\" />" + "</top>");
			BareANY result = new SetElementParser(this.parserRegistry).Parse(ParseContextImpl.Create("SET<II.BUS>", null, SpecificationVersion
				.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY, Cardinality.Create("1-5"), null, false), 
				AsList(node.ChildNodes), this.xmlResult);
			ICollection<Identifier> rawSet = ((SET<II, Identifier>)result).RawSet();
			Assert.AreEqual(2, rawSet.Count, "size");
			Assert.IsTrue(rawSet.Contains(new Identifier("1.1", "fred")));
			Assert.IsTrue(rawSet.Contains(new Identifier("2.2", "extensionValue")));
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count, "errors");
			Assert.AreEqual("Duplicate value not allowed for SET", this.xmlResult.GetHl7Errors()[0].GetMessage(), "message");
		}
	}
}
