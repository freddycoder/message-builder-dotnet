using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[TestFixture]
	public class ListErrorElementParserTest : ParserTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParse()
		{
			XmlToModelResult result = new XmlToModelResult();
			XmlNode node = CreateNode("<top><name>Fred</name>" + "<name>Flinstone</name></top>");
			new ListElementParser().Parse(ParserContextImpl.Create("LIST<ABCDEFGHIJKLMNOPQRSTUVWXYZ>", null, SpecificationVersion.V02R02
				, null, null, null), AsList(node.ChildNodes), result);
			Assert.IsFalse(result.IsValid(), "valid");
			foreach (Hl7Error error in result.GetHl7Errors())
			{
				System.Console.Out.WriteLine(error);
			}
		}
	}
}
