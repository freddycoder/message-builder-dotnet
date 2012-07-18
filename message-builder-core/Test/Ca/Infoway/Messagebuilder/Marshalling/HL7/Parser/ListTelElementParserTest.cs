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
	public class ListTelElementParserTest : ParserTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParse()
		{
			XmlNode node = CreateNode("<top><telecom value=\"tel:+1-519-555-2345;ext=12345\"/>" + "<telecom value=\"tel:+1-416-555-2345;ext=12345\"/></top>"
				);
			BareANY result = new ListElementParser().Parse(ParserContextImpl.Create("LIST<TEL>", null, SpecificationVersion.V02R02, null
				, null, null), AsList(node.ChildNodes), null);
			IList<TelecommunicationAddress> list = ((LIST<TEL, TelecommunicationAddress>)result).RawList();
			Assert.IsNotNull(list, "null");
			Assert.AreEqual(2, list.Count, "size");
			TelecommunicationAddress phone1 = list[0];
			TelecommunicationAddress phone2 = list[1];
			Assert.AreEqual("+1-519-555-2345;ext=12345", phone1.Address);
			Assert.AreEqual("+1-416-555-2345;ext=12345", phone2.Address);
		}
	}
}
