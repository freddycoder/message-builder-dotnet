using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	public class TestableTelUriPropertyFormatter : TelUriPropertyFormatter, TestableAbstractValueNullFlavorPropertyFormatter<
		TelecommunicationAddress>
	{
		public virtual IDictionary<string, string> GetAttributeNameValuePairsForTest(FormatContext context, TelecommunicationAddress
			 t, BareANY bareAny)
		{
			return base.GetAttributeNameValuePairs(context, t, bareAny);
		}
	}
}
