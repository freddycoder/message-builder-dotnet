using System.Collections.Generic;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[TestFixture]
	public class ListEnElementParserTest : ParserTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParse()
		{
			XmlNode node = CreateNode("<top><name><family>Flinstone</family><given>Fred</given></name>" + "<name><family>Flinstone</family><given>Wilma</given></name></top>"
				);
			BareANY result = new ListElementParser().Parse(ParserContextImpl.Create("LIST<PN>", null, SpecificationVersion.V02R02, null
				, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY), AsList(node.ChildNodes), this.xmlResult);
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
	}
}
