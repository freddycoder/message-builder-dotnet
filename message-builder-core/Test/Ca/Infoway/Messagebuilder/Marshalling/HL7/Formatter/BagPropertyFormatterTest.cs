using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class BagPropertyFormatterTest : FormatterTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNull()
		{
			string result = new BagPropertyFormatter().Format(new FormatContextImpl("telecom", "BAG<TEL>", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.OPTIONAL), (BareANY)new LISTImpl<TEL, TelecommunicationAddress>(typeof(TELImpl)));
			AssertXml("null", string.Empty, result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNonNull()
		{
			string result = new BagPropertyFormatter().Format(new FormatContextImpl("telecom", "BAG<TEL>", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.OPTIONAL), (BareANY)LISTImpl<ANY<object>, object>.Create<TEL, TelecommunicationAddress>(typeof(TELImpl), CreateTelecommunicationAddressList
				()));
			AssertXml("non null", "<telecom value=\"+1-519-555-2345;ext=12345\"/>" + "<telecom value=\"+1-416-555-2345;ext=12345\"/>"
				, result);
		}

		private IList<TelecommunicationAddress> CreateTelecommunicationAddressList()
		{
			List<TelecommunicationAddress> result = new List<TelecommunicationAddress>();
			TelecommunicationAddress phone1 = CreateTelecommunicationAddress("+1-519-555-2345;ext=12345");
			TelecommunicationAddress phone2 = CreateTelecommunicationAddress("+1-416-555-2345;ext=12345");
			result.Add(phone1);
			result.Add(phone2);
			return result;
		}

		private static TelecommunicationAddress CreateTelecommunicationAddress(string formattedPhoneNumber)
		{
			TelecommunicationAddress telecom = new TelecommunicationAddress();
			telecom.Address = formattedPhoneNumber;
			return telecom;
		}
	}
}
