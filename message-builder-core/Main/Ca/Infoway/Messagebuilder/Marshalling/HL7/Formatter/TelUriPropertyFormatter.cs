using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	/// <summary>
	/// Represents a TEL.URI String as an element:
	/// &lt;element-name value="mailto://me@me.com"&gt;&lt;/element-name&gt;
	/// If an object is null, value is replaced by a nullFlavor.
	/// </summary>
	/// <remarks>
	/// Represents a TEL.URI String as an element:
	/// &lt;element-name value="mailto://me@me.com"&gt;&lt;/element-name&gt;
	/// If an object is null, value is replaced by a nullFlavor. So the element would look
	/// like this:
	/// &lt;element-name nullFlavor="something" /&gt;
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-TEL
	/// The TEL.URI variant defined by CeRx is for computer system addreses only. The only valid
	/// URLSchemes are FILE, FTP, HTTP, HTTPS, MAILTO and NFS.
	/// </remarks>
	[DataTypeHandler("TEL.URI")]
	public class TelUriPropertyFormatter : AbstractValueNullFlavorPropertyFormatter<TelecommunicationAddress>
	{
		private static readonly TelValidationUtils TEL_VALIDATION_UTILS = new TelValidationUtils();

		protected sealed override string GetValue(TelecommunicationAddress uri, FormatContext context, BareANY bareAny)
		{
			string type = context.Type;
			StandardDataType specializationType = bareAny.DataType;
			VersionNumber version = context.GetVersion();
			Hl7Errors errors = context.GetModelToXmlResult();
			TEL_VALIDATION_UTILS.ValidateTelecommunicationAddress(uri, type, specializationType.Type, version, null, context.GetPropertyPath
				(), errors);
			return uri.ToString();
		}
	}
}
