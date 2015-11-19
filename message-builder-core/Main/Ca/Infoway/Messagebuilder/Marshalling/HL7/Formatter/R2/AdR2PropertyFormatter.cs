using System;
using System.Collections.Generic;
using System.Text;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2;
using Ca.Infoway.Messagebuilder.Util.Text;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2
{
	/// <summary>
	/// AD - Address (R2)
	/// Represents an Address object as an element:
	/// &lt;addr use='WP'&gt;
	/// &lt;houseNumber&gt;1050&lt;/houseNumber&gt;
	/// &lt;direction&gt;W&lt;/direction&gt;
	/// &lt;streetName&gt;Wishard Blvd&lt;/streetName&gt;,
	/// &lt;additionalLocator&gt;RG 5th floor&lt;/additionalLocator&gt;,
	/// &lt;city&gt;Indianapolis&lt;/city&gt;, &lt;state&gt;IN&lt;/state&gt;
	/// &lt;postalCode&gt;46240&lt;/postalCode&gt;
	/// &lt;/addr&gt;
	/// If an object is null, value is replaced by a nullFlavor.
	/// </summary>
	/// <remarks>
	/// AD - Address (R2)
	/// Represents an Address object as an element:
	/// &lt;addr use='WP'&gt;
	/// &lt;houseNumber&gt;1050&lt;/houseNumber&gt;
	/// &lt;direction&gt;W&lt;/direction&gt;
	/// &lt;streetName&gt;Wishard Blvd&lt;/streetName&gt;,
	/// &lt;additionalLocator&gt;RG 5th floor&lt;/additionalLocator&gt;,
	/// &lt;city&gt;Indianapolis&lt;/city&gt;, &lt;state&gt;IN&lt;/state&gt;
	/// &lt;postalCode&gt;46240&lt;/postalCode&gt;
	/// &lt;/addr&gt;
	/// If an object is null, value is replaced by a nullFlavor. So the element would look
	/// like this:
	/// &lt;element-name nullFlavor="something" /&gt;
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-AD
	/// </remarks>
	[DataTypeHandler("AD")]
	internal class AdR2PropertyFormatter : AbstractNullFlavorPropertyFormatter<PostalAddress>
	{
		private readonly TsR2PropertyFormatter tsFormatter = new TsR2PropertyFormatter();

		protected override string FormatNonNullValue(FormatContext context, PostalAddress postalAddress, int indentLevel)
		{
			IDictionary<string, string> attributeMap = new Dictionary<string, string>();
			string useAttribute = GetUseAttribute(context.Type, postalAddress, context.GetVersion().GetBaseVersion());
			if (StringUtils.IsNotBlank(useAttribute))
			{
				attributeMap["use"] = useAttribute;
			}
			Boolean? isNotOrdered = postalAddress.IsNotOrdered;
			if (isNotOrdered != null)
			{
				attributeMap["isNotOrdered"] = isNotOrdered.ToString().ToLower();
			}
			//lowercase for .NET
			StringBuilder buffer = new StringBuilder();
			buffer.Append(CreateElement(context, attributeMap, indentLevel, false, true));
			foreach (PostalAddressPart postalAddressPart in postalAddress.Parts)
			{
				AppendPostalAddressPart(buffer, postalAddressPart, indentLevel + 1);
			}
			IDictionary<PlatformDate, SetOperator> useablePeriods = postalAddress.UseablePeriods;
			foreach (PlatformDate date in useablePeriods.Keys)
			{
				SetOperator @operator = useablePeriods.SafeGet(date);
				AppendUseablePeriod(buffer, date, @operator, indentLevel + 1, context);
			}
			buffer.Append(CreateElementClosure(context, indentLevel, true));
			return buffer.ToString();
		}

		private void AppendUseablePeriod(StringBuilder buffer, PlatformDate date, SetOperator @operator, int indentLevel, FormatContext
			 outerContext)
		{
			FormatContext context = new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl("SXCM<TS>", "useablePeriod"
				, outerContext);
			MbDate mbDate = (date == null ? null : new MbDate(date));
			TS_R2 tsAny = new TS_R2Impl(mbDate, @operator);
			buffer.Append(this.tsFormatter.Format(context, tsAny, indentLevel));
		}

		private void AppendPostalAddressPart(StringBuilder buffer, PostalAddressPart postalAddressPart, int indentLevel)
		{
			bool hasPartType = postalAddressPart.Type != null;
			bool hasValue = postalAddressPart.Value != null && postalAddressPart.Value.Length > 0;
			string tagName = (hasPartType ? postalAddressPart.Type.Value : string.Empty);
			if (hasPartType)
			{
				if (!hasValue)
				{
					buffer.Append(CreateElement(tagName, null, indentLevel, true, true));
				}
				else
				{
					buffer.Append(CreateElement(tagName, GetCodeAttributes(postalAddressPart.Code), indentLevel, false, false));
				}
			}
			if (hasValue)
			{
				if (!hasPartType)
				{
					Indenter.IndentBuffer(buffer, indentLevel);
				}
				string xmlEscapedValue = XmlStringEscape.Escape(postalAddressPart.Value);
				if (xmlEscapedValue != null)
				{
					buffer.Append(xmlEscapedValue);
				}
			}
			if (hasPartType && hasValue)
			{
				buffer.Append(CreateElementClosure(tagName, 0, true));
			}
			else
			{
				buffer.Append(SystemUtils.LINE_SEPARATOR);
			}
		}

		private IDictionary<string, string> GetCodeAttributes(Code code)
		{
			// TM: schema indicates that each address part type has a "partType" attribute with the enum code for the part type; no examples ever do this; leaving out for now
			return null;
		}

		private string GetUseAttribute(string dataType, PostalAddress value, Hl7BaseVersion baseVersion)
		{
			string uses = string.Empty;
			foreach (Ca.Infoway.Messagebuilder.Domainvalue.PostalAddressUse postalAddressUse in value.Uses)
			{
				// for R2, all PostalAddressUses are allowed according to the schema
				uses += uses.Length == 0 ? string.Empty : " ";
				uses += postalAddressUse.CodeValue;
			}
			return uses;
		}
	}
}
