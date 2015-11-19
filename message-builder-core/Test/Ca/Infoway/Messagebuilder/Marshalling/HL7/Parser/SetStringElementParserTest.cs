using System.Collections.Generic;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Xml;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[TestFixture]
	public class SetStringElementParserTest : ParserTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParse()
		{
			XmlNode node = CreateNode("<top>" + "<something>Fred</something>" + "<something>Wilma</something>" + "<something>Betty</something>"
				 + "</top>");
			BareANY result = new SetElementParser(ParserRegistry.GetInstance()).Parse(ParseContextImpl.Create("SET<ST>", null, SpecificationVersion
				.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY, Cardinality.Create("1-5"), null, false), 
				AsList(node.ChildNodes), null);
			ICollection<string> set = ((SET<ST, string>)result).RawSet();
			Assert.IsNotNull(set, "null");
			Assert.AreEqual(3, set.Count, "size");
			Assert.IsTrue(set.Contains("Fred"), "Fred");
			Assert.IsTrue(set.Contains("Wilma"), "Wilma");
			Assert.IsTrue(set.Contains("Betty"), "Betty");
		}
	}
}
