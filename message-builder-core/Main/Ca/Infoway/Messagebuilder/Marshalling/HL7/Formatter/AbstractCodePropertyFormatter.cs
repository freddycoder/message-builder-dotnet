using System.Collections.Generic;
using System.Text;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	/// <summary>
	/// CS - Coded Simple
	/// Formats a enum into a CS element.
	/// </summary>
	/// <remarks>
	/// CS - Coded Simple
	/// Formats a enum into a CS element. The element looks like this:
	/// &lt;element-name code="RECENT"/&gt;
	/// According to CeRx: code has a limit of 20 characters. This limit is not
	/// currently enforced by this class.
	/// HL7 implies that variations on this type may use a different name than "code" for
	/// the attribute. The use in the controlActProcess is given as an example.
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-CS
	/// </remarks>
	internal abstract class AbstractCodePropertyFormatter : AbstractAttributePropertyFormatter<Code>
	{
		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.ModelToXmlTransformationException"></exception>
		public override string Format(FormatContext context, BareANY hl7Value, int indentLevel)
		{
			ValidateContext(context);
			CD cd = (CD)hl7Value;
			StringBuilder result = new StringBuilder();
			if (cd != null)
			{
				IDictionary<string, string> attributes = new Dictionary<string, string>();
				string warning = string.Empty;
				if (cd.HasNullFlavor())
				{
					if (context.GetConformanceLevel() == Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY)
					{
						warning = CreateWarning(context, indentLevel);
					}
					else
					{
						attributes.PutAll(CreateNullFlavorAttributes(hl7Value.NullFlavor));
					}
				}
				else
				{
					if (!HasValue(cd, context))
					{
						if (context.GetConformanceLevel() == null || IsMandatoryOrPopulated(context))
						{
							if (context.GetConformanceLevel() == Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY)
							{
								warning = CreateWarning(context, indentLevel);
							}
							else
							{
								attributes.PutAll(AbstractPropertyFormatter.NULL_FLAVOR_ATTRIBUTES);
							}
						}
					}
					else
					{
						attributes.PutAll(GetAttributeNameValuePairs(context, cd.Value));
					}
				}
				result.Append(warning);
				bool hasChildContent = HasChildContent(cd, context);
				if (hasChildContent || (!attributes.IsEmpty() || context.GetConformanceLevel() == Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
					.MANDATORY))
				{
					result.Append(CreateElement(context, attributes, indentLevel, !hasChildContent, !hasChildContent));
					if (hasChildContent)
					{
						CreateChildContent(cd, result);
						result.Append("</").Append(context.GetElementName()).Append(">");
						result.Append(SystemUtils.LINE_SEPARATOR);
					}
				}
			}
			return result.ToString();
		}

		protected virtual bool HasChildContent(CD cd, FormatContext context)
		{
			return HasOriginalText(cd);
		}

		protected virtual void CreateChildContent(CD cd, StringBuilder result)
		{
			if (HasOriginalText(cd))
			{
				result.Append(CreateElement("originalText", null, 0, false, false));
				result.Append(XmlStringEscape.Escape(cd.OriginalText));
				result.Append("</").Append("originalText").Append(">");
			}
		}

		protected virtual bool HasValue(CD cd, FormatContext context)
		{
			return cd != null && (cd.Value != null || HasChildContent(cd, context));
		}

		private bool HasOriginalText(CD cd)
		{
			return !StringUtils.IsEmpty(cd.OriginalText);
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.ModelToXmlTransformationException"></exception>
		internal override IDictionary<string, string> GetAttributeNameValuePairs(FormatContext context, Code code)
		{
			IDictionary<string, string> result = new Dictionary<string, string>();
			if (code != null)
			{
				string value = code.CodeValue;
				if (StringUtils.IsNotBlank(value))
				{
					result["code"] = value;
				}
			}
			return result;
		}
	}
}
