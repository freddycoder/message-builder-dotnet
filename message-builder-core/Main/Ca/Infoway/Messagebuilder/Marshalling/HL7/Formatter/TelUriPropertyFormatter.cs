using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
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
		private static readonly IList<string> ALLOWABLE_URL_SCHEMES = new List<string>();

		static TelUriPropertyFormatter()
		{
			ALLOWABLE_URL_SCHEMES.Add("file");
			ALLOWABLE_URL_SCHEMES.Add("ftp");
			ALLOWABLE_URL_SCHEMES.Add("http");
			ALLOWABLE_URL_SCHEMES.Add("https");
			ALLOWABLE_URL_SCHEMES.Add("mailto");
			ALLOWABLE_URL_SCHEMES.Add("nfs");
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.ModelToXmlTransformationException"></exception>
		protected sealed override string GetValue(TelecommunicationAddress uri, FormatContext context)
		{
			ValidateUrlScheme(uri);
			return uri.ToString();
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.ModelToXmlTransformationException"></exception>
		protected virtual void ValidateUrlScheme(TelecommunicationAddress uri)
		{
			if (!ALLOWABLE_URL_SCHEMES.Contains(uri.UrlScheme.CodeValue))
			{
				throw new ModelToXmlTransformationException("URLScheme " + uri.UrlScheme.CodeValue + " is not supported for TEL.URI data"
					);
			}
		}
	}
}
