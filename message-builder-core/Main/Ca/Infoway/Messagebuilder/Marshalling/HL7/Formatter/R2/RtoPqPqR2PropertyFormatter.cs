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
	[DataTypeHandler("RTO<PQ,PQ>")]
	public class RtoPqPqR2PropertyFormatter : AbstractRtoR2PropertyFormatter<PhysicalQuantity, PhysicalQuantity>
	{
		private PqR2PropertyFormatter pqFormatter = new PqR2PropertyFormatter();

		protected override string FormatNumerator(FormatContext context, PhysicalQuantity numerator, int indentLevel)
		{
			FormatContext newContext = new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl("PQ", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.OPTIONAL, Cardinality.Create("0-1"), "numerator", context);
			return this.pqFormatter.Format(newContext, new PQImpl(numerator), indentLevel);
		}

		protected override string FormatDenominator(FormatContext context, PhysicalQuantity denominator, int indentLevel)
		{
			if (denominator != null && BigDecimal.ZERO.Equals(denominator.Quantity))
			{
				context.GetModelToXmlResult().AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "Denominator cannot be zero for RTO types."
					, context.GetPropertyPath()));
			}
			FormatContext newContext = new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl("PQ", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.OPTIONAL, Cardinality.Create("0-1"), "denominator", context);
			return this.pqFormatter.Format(newContext, new PQImpl(denominator), indentLevel);
		}
	}
}
