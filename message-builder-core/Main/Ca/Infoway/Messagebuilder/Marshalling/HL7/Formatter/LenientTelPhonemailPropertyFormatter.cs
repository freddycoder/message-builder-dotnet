using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[DataTypeHandler(new string[] { "TEL.PHONEMAIL", "TEL" })]
	internal class LenientTelPhonemailPropertyFormatter : TelPhonemailPropertyFormatter
	{
		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.ModelToXmlTransformationException"></exception>
		protected override void ValidateTelecommunicationAddressUse(Ca.Infoway.Messagebuilder.Domainvalue.TelecommunicationAddressUse
			 telcomAddressUse)
		{
		}

		// no-op: be lenient
		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.ModelToXmlTransformationException"></exception>
		protected override void ValidateUrlScheme(TelecommunicationAddress telcomAddress)
		{
		}
		// no-op: be lenient
	}
}
