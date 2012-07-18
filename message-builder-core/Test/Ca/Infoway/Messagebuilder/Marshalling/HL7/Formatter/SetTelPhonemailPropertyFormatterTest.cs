using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class SetTelPhonemailPropertyFormatterTest : FormatterTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNull()
		{
			string result = new SetPropertyFormatter().Format(new FormatContextImpl("blah", "SET<TEL.PHONEMAIL>", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.MANDATORY), new SETImpl<TEL, TelecommunicationAddress>(typeof(TELImpl), Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor
				.NO_INFORMATION));
			AssertXml("null", "<blah nullFlavor=\"NI\"/>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNonNull()
		{
			string result = new SetPropertyFormatter().Format(new FormatContextImpl("blah", "SET<TEL.PHONEMAIL>", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.MANDATORY), SETImpl<ANY<object>, object>.Create<TEL, TelecommunicationAddress>(typeof(TELImpl), MakeTelecommunicationAddressSet
				("Fred")));
			AssertXml("non null", "<blah value=\"mailto://Fred\"/>", result);
		}
	}
}
