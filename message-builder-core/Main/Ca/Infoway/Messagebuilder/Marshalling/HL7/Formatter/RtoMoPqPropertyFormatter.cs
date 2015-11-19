using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	/// <summary>
	/// RTO&lt;PQ, PQ&gt; - Ratio (physical quantity, physical quantity)
	/// Represents a Ratio of physical quantities as an element:
	/// &lt;unitQuanity&gt;
	/// &lt;numerator value="1.0" xsi:type="PQ"/&gt;
	/// &lt;denominator value="64.0" xsi:type="/&gt;
	/// &lt;/unitQuanity&gt;
	/// </summary>
	[DataTypeHandler("RTO<MO,PQ>")]
	public class RtoMoPqPropertyFormatter : AbstractRtoPropertyFormatter<Money, PhysicalQuantity>
	{
		private PqPropertyFormatter pqFormatter = new PqPropertyFormatter();

		private MoPropertyFormatter moFormatter = new MoPropertyFormatter();

		//http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-RTO
		protected override string FormatNumerator(FormatContext context, Money numerator, int indentLevel)
		{
			string numeratorType = Hl7DataTypeName.Create(context.Type).GetInnerTypes()[0].ToString();
			FormatContext newContext = new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(numeratorType, context
				.IsSpecializationType(), Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY, Cardinality.Create("1"), "numerator", 
				context);
			return this.moFormatter.Format(newContext, new MOImpl(numerator), indentLevel);
		}

		protected override string FormatDenominator(FormatContext context, PhysicalQuantity denominator, int indentLevel)
		{
			string denominatorType = Hl7DataTypeName.Create(context.Type).GetInnerTypes()[1].ToString();
			FormatContext newContext = new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(denominatorType, context
				.IsSpecializationType(), Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY, Cardinality.Create("1"), "denominator"
				, context);
			return this.pqFormatter.Format(newContext, new PQImpl(denominator), indentLevel);
		}
	}
}
