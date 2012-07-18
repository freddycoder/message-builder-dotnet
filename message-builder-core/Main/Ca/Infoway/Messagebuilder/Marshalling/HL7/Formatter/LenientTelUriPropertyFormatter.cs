using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[DataTypeHandler("TEL.URI")]
	internal class LenientTelUriPropertyFormatter : TelUriPropertyFormatter
	{
		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.ModelToXmlTransformationException"></exception>
		protected override void ValidateUrlScheme(TelecommunicationAddress uri)
		{
		}
		// no-op: be lenient
	}
}
