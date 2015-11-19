using System.Collections.Generic;
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
	public class ListTelPhonemailPropertyFormatterTest : FormatterTestCase
	{
		private FormatterRegistry formatterRegistry = FormatterRegistry.GetInstance();

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNull()
		{
			string result = new ListPropertyFormatter(this.formatterRegistry).Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(new ModelToXmlResult(), null, "blah", "LIST<TEL.PHONEMAIL>", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null
				, false, SpecificationVersion.R02_04_03, null, null, null, false), (BareANY)new LISTImpl<TEL, TelecommunicationAddress>(
				typeof(TELImpl)));
			AssertXml("null", string.Empty, result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNonNull()
		{
			ModelToXmlResult results = new ModelToXmlResult();
			string result = new ListPropertyFormatter(this.formatterRegistry).Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(results, null, "blah", "LIST<TEL.PHONEMAIL>", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, Cardinality.Create
				("0-4"), false, SpecificationVersion.R02_04_03, null, null, null, false), (BareANY)LISTImpl<ANY<object>, object>.Create<
				TEL, TelecommunicationAddress>(typeof(TELImpl), new List<TelecommunicationAddress>(MakeTelecommunicationAddressList("Fred"
				))));
			AssertXml("non null", "<blah specializationType=\"TEL.PHONE\" value=\"mailto:Fred\" xsi:type=\"TEL\"/>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNonNullMultiple()
		{
			string result = new ListPropertyFormatter(this.formatterRegistry).Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(new ModelToXmlResult(), null, "blah", "LIST<TEL.PHONEMAIL>", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, Cardinality
				.Create("0-4"), false, SpecificationVersion.R02_04_03, null, null, null, false), (BareANY)LISTImpl<ANY<object>, object>.
				Create<TEL, TelecommunicationAddress>(typeof(TELImpl), new List<TelecommunicationAddress>(MakeTelecommunicationAddressList
				("Fred", "Jack"))));
			AssertXml("non null", "<blah specializationType=\"TEL.PHONE\" value=\"mailto:Fred\" xsi:type=\"TEL\"/>" + "<blah specializationType=\"TEL.PHONE\" value=\"mailto:Jack\" xsi:type=\"TEL\"/>"
				, result);
		}
	}
}
