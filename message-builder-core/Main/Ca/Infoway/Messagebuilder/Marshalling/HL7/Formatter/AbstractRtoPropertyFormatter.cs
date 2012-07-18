using System.Collections.Generic;
using System.Text;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Util.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	public abstract class AbstractRtoPropertyFormatter<T, U> : AbstractNullFlavorPropertyFormatter<BareRatio>
	{
		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.ModelToXmlTransformationException"></exception>
		internal override string FormatNonNullValue(FormatContext context, BareRatio value, int indentLevel)
		{
			StringBuilder buffer = new StringBuilder();
			buffer.Append(CreateElement(context.GetElementName(), null, indentLevel, false, true));
			buffer.Append(CreateElement("numerator", GetNumeratorAttributeMap((T)value.BareNumerator), indentLevel + 1, true, true));
			buffer.Append(CreateElement("denominator", GetDenominatorAttributeMap((U)value.BareDenominator), indentLevel + 1, true, true
				));
			buffer.Append(XmlRenderingUtils.CreateEndElement(context.GetElementName(), indentLevel, true));
			return buffer.ToString();
		}

		protected abstract IDictionary<string, string> GetNumeratorAttributeMap(T value);

		protected abstract IDictionary<string, string> GetDenominatorAttributeMap(U value);
	}
}
