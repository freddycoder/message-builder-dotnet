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
	public class SetTelPhonemailElementParserTest : ParserTestCase
	{
		private ParserRegistry parserRegistry = ParserRegistry.GetInstance();

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParse()
		{
			XmlNode node = CreateNode("<top>" + "<something specializationType=\"TEL.EMAIL\" value=\"mailto://Fred\"/>" + "<something specializationType=\"TEL.EMAIL\" value=\"mailto://Wilma\"/>"
				 + "</top>");
			BareANY result = new SetElementParser(this.parserRegistry).Parse(ParseContextImpl.Create("SET<TEL.PHONEMAIL>", null, SpecificationVersion
				.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY, Cardinality.Create("1-5"), null, false), 
				AsList(node.ChildNodes), null);
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

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseWithDuplicates()
		{
			XmlNode node = CreateNode("<top>" + "<telecom specializationType=\"TEL.EMAIL\"  value=\"mailto:doctorLocation@doctor.org\"/>"
				 + "<telecom specializationType=\"TEL.EMAIL\"  value=\"mailto:doctorLocation@doctor.org\"/>" + "</top>");
			BareANY result = new SetElementParser(this.parserRegistry).Parse(ParseContextImpl.Create("SET<TEL.PHONEMAIL>", null, SpecificationVersion
				.V01R04_3, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY, Cardinality.Create("1-5"), null, false)
				, AsList(node.ChildNodes), this.xmlResult);
			ICollection<TelecommunicationAddress> set = ((SET<TEL, TelecommunicationAddress>)result).RawSet();
			Assert.IsNotNull(set, "null");
			Assert.AreEqual(1, set.Count, "size");
			foreach (TelecommunicationAddress address in set)
			{
				Assert.AreEqual(CeRxDomainTestValues.MAILTO.CodeValue, address.UrlScheme.CodeValue, "urlscheme");
				Assert.AreEqual("doctorLocation@doctor.org", address.Address, "address");
			}
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
			Assert.AreEqual("Duplicate value not allowed for SET", this.xmlResult.GetHl7Errors()[0].GetMessage());
		}
	}
}
