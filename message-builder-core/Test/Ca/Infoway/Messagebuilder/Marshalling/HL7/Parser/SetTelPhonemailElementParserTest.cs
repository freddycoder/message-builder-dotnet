using System.Collections.Generic;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[TestFixture]
	public class SetTelPhonemailElementParserTest : ParserTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParse()
		{
			XmlNode node = CreateNode("<top>" + "<something value=\"mailto://Fred\"/>" + "<something value=\"mailto://Wilma\"/>" + "</top>"
				);
			BareANY result = new SetElementParser().Parse(ParserContextImpl.Create("SET<TEL.PHONEMAIL>", null, SpecificationVersion.V02R02
				, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY), AsList(node.ChildNodes), null);
			ICollection<TelecommunicationAddress> set = ((SET<TEL, TelecommunicationAddress>)result).RawSet();
			Assert.IsNotNull(set, "null");
			Assert.AreEqual(2, set.Count, "size");
			ICollection<string> expectedStrings = new HashSet<string>();
			expectedStrings.Add("Fred");
			expectedStrings.Add("Wilma");
			foreach (TelecommunicationAddress address in set)
			{
				Assert.AreEqual(CeRxDomainTestValues.MAILTO.CodeValue, address.UrlScheme.CodeValue, "urlscheme");
				Assert.IsTrue(expectedStrings.Contains(address.Address), "expected set contains address");
				expectedStrings.Remove(address.Address);
			}
		}
	}
}
