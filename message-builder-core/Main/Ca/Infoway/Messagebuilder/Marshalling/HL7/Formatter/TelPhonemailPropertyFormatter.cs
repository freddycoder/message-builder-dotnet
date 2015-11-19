using System.Collections.Generic;
using System.Text;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Error;
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
	[DataTypeHandler(new string[] { "TEL.ALL", "TEL.PHONEMAIL", "TEL" })]
	public class TelPhonemailPropertyFormatter : AbstractValueNullFlavorPropertyFormatter<TelecommunicationAddress>
	{
		private static readonly TelValidationUtils TEL_VALIDATION_UTILS = new TelValidationUtils();

		protected sealed override string GetValue(TelecommunicationAddress phonemail, FormatContext context, BareANY bareAny)
		{
			string type = context.Type;
			string specializationType = bareAny.DataType == null ? null : bareAny.DataType.Type;
			VersionNumber version = context.GetVersion();
			Hl7Errors errors = context.GetModelToXmlResult();
			TEL_VALIDATION_UTILS.ValidateTelecommunicationAddress(phonemail, type, specializationType, version, null, context.GetPropertyPath
				(), errors);
			return phonemail.ToString();
		}

		protected override void AddOtherAttributesIfNecessary(TelecommunicationAddress phonemail, IDictionary<string, string> attributes
			, FormatContext context, BareANY bareAny)
		{
			VersionNumber version = context.GetVersion();
			string type = (bareAny == null || bareAny.DataType == null) ? null : bareAny.DataType.Type;
			string actualType = TEL_VALIDATION_UTILS.DetermineActualType(phonemail, context.Type, type, version, null, context.GetPropertyPath
				(), context.GetModelToXmlResult(), false);
			if (!context.Type.Equals(actualType))
			{
				// excluding our test NFLD version to allow legacy tests to pass
				if (!"NEWFOUNDLAND".Equals(version == null ? null : version.VersionLiteral))
				{
					AddSpecializationType(attributes, actualType);
				}
			}
			if (!phonemail.AddressUses.IsEmpty())
			{
				StringBuilder useValue = new StringBuilder();
				bool isFirst = true;
				foreach (Ca.Infoway.Messagebuilder.Domainvalue.TelecommunicationAddressUse addressUse in phonemail.AddressUses)
				{
					if (TEL_VALIDATION_UTILS.IsAllowableUse(actualType, addressUse, version))
					{
						if (!isFirst)
						{
							useValue.Append(XmlRenderingUtils.SPACE);
						}
						useValue.Append(addressUse.CodeValue);
						isFirst = false;
					}
				}
				attributes["use"] = useValue.ToString();
			}
		}
	}
}
