using System.Collections.Generic;
using System.Text;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Util.Iterator;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	/// <summary>
	/// AD.BASIC - Address (Basic)
	/// Represents an Address object as an element:
	/// &lt;element-name use="PHYS"&gt;	&lt;!-- "PHYS" is visit, "PST" is postal, "TMP" is temporary, "H" is home, "WP" is workplace.
	/// </summary>
	/// <remarks>
	/// AD.BASIC - Address (Basic)
	/// Represents an Address object as an element:
	/// &lt;element-name use="PHYS"&gt;	&lt;!-- "PHYS" is visit, "PST" is postal, "TMP" is temporary, "H" is home, "WP" is workplace. --&gt;
	/// 1709 Bloor St W.&lt;delimiter/&gt;
	/// Suite 200&lt;delimiter/&gt;
	/// &lt;city&gt;Toronto&lt;/city&gt;
	/// &lt;state code="ON&gt;Ontario&lt;/state&gt;
	/// &lt;postalCode&gt;A1A 1A1&lt;/postalCode&gt;&lt;delimiter/&gt;
	/// &lt;country code="CA"&gt;Canada&lt;/country&gt;
	/// &lt;/element-name&gt;
	/// If an object is null, value is replaced by a nullFlavor. So the element would look
	/// like this:
	/// &lt;element-name nullFlavor="something" /&gt;
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-AD
	/// CeRx limits the length of each part to 60 characters. This limit is not enforced by
	/// this class.
	/// It is also quite apparent that the use of the delimiters in the address indicates a
	/// certain level of dementia.
	/// </remarks>
	[DataTypeHandler("AD.BASIC")]
	internal class AdBasicPropertyFormatter : AbstractAdPropertyFormatter
	{
		private static readonly IList<string> ALLOWABLE_ADDRESS_USES = new List<string>();

		static AdBasicPropertyFormatter()
		{
			ALLOWABLE_ADDRESS_USES.Add("H");
			ALLOWABLE_ADDRESS_USES.Add("PHYS");
			ALLOWABLE_ADDRESS_USES.Add("PST");
			ALLOWABLE_ADDRESS_USES.Add("TMP");
			ALLOWABLE_ADDRESS_USES.Add("WP");
		}

		internal sealed override string FormatNonNullValue(FormatContext context, PostalAddress postalAddress, int indentLevel)
		{
			PostalAddress basicAddress = new PostalAddress();
			StringBuilder builder = new StringBuilder();
			PostalAddressPartType lastPartType = null;
			foreach (PostalAddressPart part in EmptyIterable<object>.NullSafeIterable(postalAddress.Parts))
			{
				if (part.Type == PostalAddressPartType.CITY || part.Type == PostalAddressPartType.STATE || part.Type == PostalAddressPartType
					.COUNTRY || part.Type == PostalAddressPartType.POSTAL_CODE)
				{
					Flush(builder, basicAddress);
					basicAddress.AddPostalAddressPart(part);
				}
				else
				{
					if (part.Type == PostalAddressPartType.DELIMITER && StringUtils.IsBlank(part.Value))
					{
						Flush(builder, basicAddress);
						basicAddress.AddPostalAddressPart(part);
					}
					else
					{
						if (StringUtils.IsNotBlank(part.Value))
						{
							if (builder.Length > 0 && part.Type == PostalAddressPartType.STREET_ADDRESS_LINE && lastPartType == PostalAddressPartType
								.STREET_ADDRESS_LINE)
							{
								Flush(builder, basicAddress);
								basicAddress.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.DELIMITER, (string)null));
							}
							else
							{
								if (builder.Length > 0)
								{
									builder.Append(" ");
								}
							}
							builder.Append(part.Value);
						}
					}
				}
				lastPartType = part.Type;
			}
			Flush(builder, basicAddress);
			foreach (Ca.Infoway.Messagebuilder.Datatype.Lang.PostalAddressUse use in postalAddress.Uses)
			{
				if (IsAllowableUse(use))
				{
					basicAddress.AddUse(use);
				}
			}
			return base.FormatNonNullValue(context, basicAddress, indentLevel);
		}

		private bool IsAllowableUse(Ca.Infoway.Messagebuilder.Datatype.Lang.PostalAddressUse use)
		{
			return use != null && use.CodeValue != null && ALLOWABLE_ADDRESS_USES.Contains(use.CodeValue);
		}

		private void Flush(StringBuilder builder, PostalAddress basicAddress)
		{
			if (builder.Length > 0)
			{
				basicAddress.AddPostalAddressPart(new PostalAddressPart(builder.ToString()));
				builder.Length = 0;
			}
		}
	}
}
