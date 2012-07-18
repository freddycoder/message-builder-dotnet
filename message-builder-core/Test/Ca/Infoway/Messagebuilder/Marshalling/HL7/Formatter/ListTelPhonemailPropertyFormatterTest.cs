using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class ListTelPhonemailPropertyFormatterTest : FormatterTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNull()
		{
			string result = new ListPropertyFormatter().Format(new FormatContextImpl("blah", "LIST<TEL.PHONEMAIL>", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.OPTIONAL), (BareANY)new LISTImpl<TEL, TelecommunicationAddress>(typeof(TELImpl)));
			AssertXml("null", string.Empty, result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNonNull()
		{
			string result = new ListPropertyFormatter().Format(new FormatContextImpl("blah", "LIST<TEL.PHONEMAIL>", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.OPTIONAL), (BareANY)LISTImpl<ANY<object>, object>.Create<TEL, TelecommunicationAddress>(typeof(TELImpl), new List<TelecommunicationAddress
				>(MakeTelecommunicationAddressSet("Fred"))));
			AssertXml("non null", "<blah value=\"mailto://Fred\"/>", result);
		}
	}
}
