using System.Collections.Generic;
using System.Text;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2;
using Ca.Infoway.Messagebuilder.Util.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2
{
	/// <summary>
	/// Represents a TEL String as an element:
	/// &lt;element-name use="H WP" value="mailto://me@me.com"&gt;&lt;/element-name&gt;
	/// If an object is null, value is replaced by a nullFlavor.
	/// </summary>
	/// <remarks>
	/// Represents a TEL String as an element:
	/// &lt;element-name use="H WP" value="mailto://me@me.com"&gt;&lt;/element-name&gt;
	/// If an object is null, value is replaced by a nullFlavor. So the element would look
	/// like this:
	/// &lt;element-name nullFlavor="something" /&gt;
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-TEL
	/// </remarks>
	[DataTypeHandler("TEL")]
	public class TelR2PropertyFormatter : AbstractNullFlavorPropertyFormatter<TelecommunicationAddress>
	{
		private class TsR2PropertyFormatterVisible : TsR2PropertyFormatter
		{
			//	private static final TelValidationUtils TEL_VALIDATION_UTILS = new TelValidationUtils();
			//For .NET conversion to open up visibility of protected method
			public virtual IDictionary<string, string> GetAttributeNameValuePairsVisible(FormatContext context, MbDate t, BareANY bareAny
				)
			{
				return GetAttributeNameValuePairs(context, t, bareAny);
			}
		}

		protected override string FormatNonNullValue(FormatContext context, TelecommunicationAddress value, int indentLevel)
		{
			// any validation that can be done for R2??
			// scheme/address cannot be null
			bool hasUseablePeriods = !value.UseablePeriods.IsEmpty();
			StringBuilder buffer = new StringBuilder();
			buffer.Append(CreateElement(context, GetAttributesMap(value, context.GetVersion()), indentLevel, !hasUseablePeriods, true
				));
			if (hasUseablePeriods)
			{
				AppendUseablePeriods(value, buffer, indentLevel + 1, context);
				buffer.Append(CreateElementClosure(context, indentLevel, true));
			}
			return buffer.ToString();
		}

		private IDictionary<string, string> GetAttributesMap(TelecommunicationAddress address, VersionNumber version)
		{
			IDictionary<string, string> attributes = new Dictionary<string, string>();
			// address value
			attributes["value"] = address.ToString();
			// address uses
			if (!address.AddressUses.IsEmpty())
			{
				StringBuilder useValue = new StringBuilder();
				bool isFirst = true;
				foreach (Ca.Infoway.Messagebuilder.Domainvalue.TelecommunicationAddressUse addressUse in address.AddressUses)
				{
					if (!isFirst)
					{
						useValue.Append(XmlRenderingUtils.SPACE);
					}
					useValue.Append(addressUse.CodeValue);
					isFirst = false;
				}
				attributes["use"] = useValue.ToString();
			}
			return attributes;
		}

		private void AppendUseablePeriods(TelecommunicationAddress value, StringBuilder buffer, int indentLevel, FormatContext context
			)
		{
			Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl tsFormatContext = new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				("SXCM<TS>", context);
			IDictionary<PlatformDate, SetOperator> useablePeriods = value.UseablePeriods;
			foreach (PlatformDate period in useablePeriods.Keys)
			{
				MbDate mbDate = new MbDate(period);
				TS_R2 ts = new TS_R2Impl(mbDate, useablePeriods.SafeGet(period));
				IDictionary<string, string> attributes = new TelR2PropertyFormatter.TsR2PropertyFormatterVisible().GetAttributeNameValuePairsVisible
					(tsFormatContext, mbDate, ts);
				buffer.Append(CreateElement("useablePeriod", attributes, indentLevel, true, true));
			}
		}
	}
}
