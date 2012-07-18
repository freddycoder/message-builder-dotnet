using System.Collections.Generic;
using System.Text;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Util.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	/// <summary>
	/// Represents a TEL.PHONEMAIL String as an element:
	/// &lt;element-name use="H WP" value="mailto://me@me.com"&gt;&lt;/element-name&gt;
	/// If an object is null, value is replaced by a nullFlavor.
	/// </summary>
	/// <remarks>
	/// Represents a TEL.PHONEMAIL String as an element:
	/// &lt;element-name use="H WP" value="mailto://me@me.com"&gt;&lt;/element-name&gt;
	/// If an object is null, value is replaced by a nullFlavor. So the element would look
	/// like this:
	/// &lt;element-name nullFlavor="something" /&gt;
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-TEL
	/// The TEL.PHONEMAIL variant defined by CeRx is for personal contact addresses only.
	/// The only valid URLSchemes are FAX, MAILTO and TELEPHONE.
	/// </remarks>
	[DataTypeHandler(new string[] { "TEL.PHONEMAIL", "TEL" })]
	public class TelPhonemailPropertyFormatter : AbstractValueNullFlavorPropertyFormatter<TelecommunicationAddress>
	{
		private static readonly IList<string> ALLOWABLE_URL_SCHEMES;

		private static readonly IList<string> ALLOWABLE_TELECOMMUNICATION_USES;

		static TelPhonemailPropertyFormatter()
		{
			ALLOWABLE_URL_SCHEMES = new List<string>();
			ALLOWABLE_URL_SCHEMES.Add("fax");
			ALLOWABLE_URL_SCHEMES.Add("mailto");
			ALLOWABLE_URL_SCHEMES.Add("tel");
			ALLOWABLE_TELECOMMUNICATION_USES = new List<string>();
			ALLOWABLE_TELECOMMUNICATION_USES.Add("EC");
			ALLOWABLE_TELECOMMUNICATION_USES.Add("H");
			ALLOWABLE_TELECOMMUNICATION_USES.Add("MC");
			ALLOWABLE_TELECOMMUNICATION_USES.Add("PG");
			ALLOWABLE_TELECOMMUNICATION_USES.Add("TMP");
			ALLOWABLE_TELECOMMUNICATION_USES.Add("WP");
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.ModelToXmlTransformationException"></exception>
		protected sealed override string GetValue(TelecommunicationAddress phonemail, FormatContext context)
		{
			ValidateUrlScheme(phonemail);
			return phonemail.ToString();
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.ModelToXmlTransformationException"></exception>
		protected sealed override void AddOtherAttributesIfNecessary(TelecommunicationAddress phonemail, IDictionary<string, string
			> attributes)
		{
			if (!phonemail.AddressUses.IsEmpty())
			{
				StringBuilder useValue = new StringBuilder();
				bool isFirst = true;
				foreach (Ca.Infoway.Messagebuilder.Domainvalue.TelecommunicationAddressUse addressUse in phonemail.AddressUses)
				{
					ValidateTelecommunicationAddressUse(addressUse);
					if (!isFirst)
					{
						useValue.Append(XmlRenderingUtils.SPACE);
					}
					useValue.Append(addressUse.CodeValue);
					isFirst = false;
				}
				attributes["use"] = useValue.ToString();
			}
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.ModelToXmlTransformationException"></exception>
		protected virtual void ValidateUrlScheme(TelecommunicationAddress telcomAddress)
		{
			if (!ALLOWABLE_URL_SCHEMES.Contains(telcomAddress.UrlScheme.CodeValue))
			{
				throw new ModelToXmlTransformationException("URLScheme " + telcomAddress.UrlScheme.CodeValue + " is not supported for TEL.PHONEMAIL data"
					);
			}
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.ModelToXmlTransformationException"></exception>
		protected virtual void ValidateTelecommunicationAddressUse(Ca.Infoway.Messagebuilder.Domainvalue.TelecommunicationAddressUse
			 telcomAddressUse)
		{
			if (!ALLOWABLE_TELECOMMUNICATION_USES.Contains(telcomAddressUse.CodeValue))
			{
				throw new ModelToXmlTransformationException("Telecommunication address use " + telcomAddressUse.CodeValue + " is not supported for TEL.PHONEMAIL data"
					);
			}
		}
	}
}
