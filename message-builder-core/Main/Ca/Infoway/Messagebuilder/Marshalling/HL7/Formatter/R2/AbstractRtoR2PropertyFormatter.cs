using System.Text;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2
{
	public abstract class AbstractRtoR2PropertyFormatter<T, U> : AbstractNullFlavorPropertyFormatter<BareRatio>
	{
		protected override string FormatNonNullValue(FormatContext context, BareRatio value, int indentLevel)
		{
			StringBuilder buffer = new StringBuilder();
			buffer.Append(CreateElement(context, null, indentLevel, false, true));
			T bareNumerator = (T)value.BareNumerator;
			U bareDenominator = (U)value.BareDenominator;
			if (bareNumerator == null || bareDenominator == null)
			{
				context.GetModelToXmlResult().AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "Numerator and denominator must be non-null; both are mandatory for RTO types."
					, context.GetPropertyPath()));
			}
			buffer.Append(FormatNumerator(context, bareNumerator, indentLevel + 1));
			buffer.Append(FormatDenominator(context, bareDenominator, indentLevel + 1));
			buffer.Append(CreateElementClosure(context.GetElementName(), indentLevel, true));
			return buffer.ToString();
		}

		protected abstract string FormatNumerator(FormatContext context, T numerator, int indentLevel);

		protected abstract string FormatDenominator(FormatContext context, U denominator, int indentLevel);
	}
}
