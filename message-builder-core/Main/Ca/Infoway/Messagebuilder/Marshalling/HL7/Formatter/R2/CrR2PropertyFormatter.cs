using System.Collections.Generic;
using System.Text;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2;
using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2
{
	/// <summary>
	/// RTO&lt;PQ, PQ&gt; - Ratio R2 (physical quantity, physical quantity)
	/// Represents a Ratio of physical quantities as an element:
	/// &lt;unitQuanity&gt;
	/// &lt;numerator value="1.0" xsi:type="PQ"/&gt;
	/// &lt;denominator value="64.0" xsi:type="/&gt;
	/// &lt;/unitQuanity&gt;
	/// </summary>
	[DataTypeHandler("CR")]
	public class CrR2PropertyFormatter : AbstractNullFlavorPropertyFormatter<CodeRole>
	{
		private CvR2PropertyFormatter cvFormatter = new CvR2PropertyFormatter();

		private CdR2PropertyFormatter cdFormatter = new CdR2PropertyFormatter();

		protected override string FormatNonNullValue(FormatContext context, CodeRole codeRole, int indentLevel)
		{
			bool hasContent = (codeRole.Name != null || codeRole.Value != null);
			// validation here (limited, from schema); must have value or a NF (and if we are here, we don't have a NF)
			if (codeRole.Value == null)
			{
				context.GetModelToXmlResult().AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "CR types must have the \"value\" property provided"
					, context.GetPropertyPath()));
			}
			StringBuilder buffer = new StringBuilder();
			buffer.Append(CreateElement(context, CreateAttributesMap(codeRole, context), indentLevel, !hasContent, true));
			if (hasContent)
			{
				if (codeRole.Name != null)
				{
					buffer.Append(FormatName(context, codeRole.Name, indentLevel + 1));
				}
				if (codeRole.Value != null)
				{
					buffer.Append(FormatValue(context, codeRole.Value, indentLevel + 1));
				}
				buffer.Append(CreateElementClosure(context.GetElementName(), indentLevel, true));
			}
			return buffer.ToString();
		}

		private IDictionary<string, string> CreateAttributesMap(CodeRole codeRole, FormatContext context)
		{
			IDictionary<string, string> attributes = null;
			if (codeRole.Inverted)
			{
				// value defaults to false; only output if true
				attributes = new Dictionary<string, string>();
				attributes["inverted"] = "true";
			}
			return attributes;
		}

		private string FormatName(FormatContext context, CodedTypeR2<Code> name, int indentLevel)
		{
			FormatContext newContext = new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl("CV", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.OPTIONAL, Cardinality.Create("0-1"), "name", context);
			return this.cvFormatter.Format(newContext, new CV_R2Impl<Code>(name), indentLevel);
		}

		private string FormatValue(FormatContext context, CodedTypeR2<Code> value, int indentLevel)
		{
			FormatContext newContext = new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl("CD", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.OPTIONAL, Cardinality.Create("0-1"), "value", context);
			return this.cdFormatter.Format(newContext, new CD_R2Impl<Code>(value), indentLevel);
		}
	}
}
