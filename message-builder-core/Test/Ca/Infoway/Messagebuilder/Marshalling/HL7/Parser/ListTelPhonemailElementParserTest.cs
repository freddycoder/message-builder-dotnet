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
	public class ListTelPhonemailElementParserTest : ParserTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParse()
		{
			XmlNode node = CreateNode("<top>" + "<something specializationType=\"TEL.EMAIL\" value=\"mailto://Fred\"/>" + "<something specializationType=\"TEL.EMAIL\" value=\"mailto://Wilma\"/>"
				 + "</top>");
			BareANY result = new ListElementParser(ParserRegistry.GetInstance()).Parse(ParseContextImpl.Create("LIST<TEL.PHONEMAIL>", 
				null, SpecificationVersion.V02R02, null, null, null, Cardinality.Create("1-5"), null, false), AsList(node.ChildNodes), null
				);
			IList<TelecommunicationAddress> list = ((LIST<TEL, TelecommunicationAddress>)result).RawList();
			Assert.IsNotNull(list, "null");
			Assert.AreEqual(2, list.Count, "size");
			ICollection<string> expectedStrings = new HashSet<string>();
			expectedStrings.Add("Fred");
			expectedStrings.Add("Wilma");
			foreach (TelecommunicationAddress address in list)
			{
				Assert.AreEqual(CeRxDomainTestValues.MAILTO.CodeValue, address.UrlScheme.CodeValue, "urlscheme");
				Assert.IsTrue(expectedStrings.Contains(address.Address), "expected set contains address");
				expectedStrings.Remove(address.Address);
			}
		}
	}
}
