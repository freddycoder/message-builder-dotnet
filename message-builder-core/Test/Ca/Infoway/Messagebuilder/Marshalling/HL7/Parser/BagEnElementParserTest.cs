using System.Collections.Generic;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Xml;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[TestFixture]
	public class BagEnElementParserTest : ParserTestCase
	{
		private ParserRegistry parserRegistry = ParserRegistry.GetInstance();

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldParseSimpleBag()
		{
			XmlNode node = CreateNode("<top><name><family>Flinstone</family><given>Fred</given></name>" + "<name><family>Flinstone</family><given>Wilma</given></name></top>"
				);
			BareANY result = new BagElementParser(this.parserRegistry).Parse(ParseContextImpl.Create("BAG<PN>", null, SpecificationVersion
				.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY, Cardinality.Create("1-5"), null, false), 
				AsList(node.ChildNodes), this.xmlResult);
			IList<PersonName> list = ((LIST<PN, PersonName>)result).RawList();
			Assert.IsNotNull(list, "null");
			Assert.AreEqual(2, list.Count, "size");
			EntityName fred = list[0];
			EntityName wilma = list[1];
			Assert.AreEqual("Flinstone", fred.Parts[0].Value);
			Assert.AreEqual("Fred", fred.Parts[1].Value);
			Assert.AreEqual("Flinstone", wilma.Parts[0].Value);
			Assert.AreEqual("Wilma", wilma.Parts[1].Value);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldParseEmptyBag()
		{
			XmlNode node = CreateNode("<top></top>");
			BareANY result = new BagElementParser(this.parserRegistry).Parse(ParseContextImpl.Create("BAG<PN>", null, SpecificationVersion
				.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY, Cardinality.Create("1-5"), null, false), 
				AsList(node.ChildNodes), this.xmlResult);
			IList<PersonName> list = ((LIST<PN, PersonName>)result).RawList();
			Assert.IsNotNull(list, "null");
			Assert.AreEqual(0, list.Count, "size");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldParseNullFlavor()
		{
			XmlNode node = CreateNode("<top><name nullFlavor=\"NI\"/></top>");
			BareANY result = new BagElementParser(this.parserRegistry).Parse(ParseContextImpl.Create("BAG<PN>", null, SpecificationVersion
				.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY, Cardinality.Create("1-5"), null, false), 
				AsList(node.ChildNodes), this.xmlResult);
			LIST<PN, PersonName> hl7List = (LIST<PN, PersonName>)result;
			IList<PersonName> list = hl7List.RawList();
			Assert.IsNotNull(list, "null");
			Assert.AreEqual(1, list.Count, "size");
			IList<PN> pnList = (IList<PN>)hl7List.Value;
			PN firstName = pnList[0];
			Assert.IsTrue(firstName.Null, "null");
		}
	}
}
