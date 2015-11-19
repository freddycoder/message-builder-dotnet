using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Xml;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class SetTelPhonemailPropertyFormatterTest : FormatterTestCase
	{
		private FormatterRegistry formatterRegistry = FormatterRegistry.GetInstance();

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNull()
		{
			string result = new SetPropertyFormatter(this.formatterRegistry).Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(new ModelToXmlResult(), null, "blah", "SET<TEL.PHONEMAIL>", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY, null
				, false, SpecificationVersion.R02_04_03, null, null, null, false), new SETImpl<TEL, TelecommunicationAddress>(typeof(TELImpl
				), Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION));
			AssertXml("null", "<blah nullFlavor=\"NI\"/>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNonNull()
		{
			string result = new SetPropertyFormatter(this.formatterRegistry).Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(new ModelToXmlResult(), null, "blah", "SET<TEL.PHONEMAIL>", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY, Cardinality
				.Create("1-4"), false, SpecificationVersion.R02_04_03, null, null, null, false), SETImpl<ANY<object>, object>.Create<TEL
				, TelecommunicationAddress>(typeof(TELImpl), MakeTelecommunicationAddressSet("Fred")));
			AssertXml("non null", "<blah specializationType=\"TEL.PHONE\" value=\"mailto:Fred\" xsi:type=\"TEL\"/>", result);
		}
	}
}
