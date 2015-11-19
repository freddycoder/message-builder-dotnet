using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class EdSignaturePropertyFormatterTest : FormatterTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNullWithConformanceOptional()
		{
			string expectedResult = string.Empty;
			FormatContext context = new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(new ModelToXmlResult(), 
				null, "name", null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, false);
			string result = new EdSignaturePropertyFormatter().Format(context, null);
			Assert.AreEqual(expectedResult, result, "named null format");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNull()
		{
			// expected:
			// <name nullFlavor=\"NI\"/>
			string expectedResult = "<name nullFlavor=\"NI\"/>" + SystemUtils.LINE_SEPARATOR;
			string result = new EdSignaturePropertyFormatter().Format(GetContext("name"), new EDImpl<string>());
			Assert.AreEqual(expectedResult, result, "named null format");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNonNull()
		{
			// expected:
			// <name mediaType="text/xml">
			//   <signature xmlns="http://www.w3.org/2000/09/xmldsig#">signatureText</signature>
			// </name>
			string expectedResult = "<name mediaType=\"text/xml\">" + SystemUtils.LINE_SEPARATOR + "  <signature xmlns=\"http://www.w3.org/2000/09/xmldsig#\">signatureText</signature>"
				 + SystemUtils.LINE_SEPARATOR + "</name>" + SystemUtils.LINE_SEPARATOR;
			string result = new EdSignaturePropertyFormatter().Format(GetContext("name"), new EDImpl<string>("signatureText"));
			Assert.AreEqual(expectedResult, result, "something in text node");
		}
	}
}
