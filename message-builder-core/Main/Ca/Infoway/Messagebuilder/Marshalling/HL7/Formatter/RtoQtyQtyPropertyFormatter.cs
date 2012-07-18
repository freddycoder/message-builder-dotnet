using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	/// <summary>
	/// RTO - Ratio (quantity, quantity)
	/// Represents a Ratio of quantities as an element:
	/// 
	/// 
	/// 
	/// 
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-RTO
	/// </summary>
	[DataTypeHandler("RTO<QTY,QTY>")]
	public class RtoQtyQtyPropertyFormatter : AbstractRtoPropertyFormatter<BigDecimal, BigDecimal>
	{
		protected override IDictionary<string, string> GetDenominatorAttributeMap(BigDecimal value)
		{
			return GetAttributeMap(value);
		}

		protected override IDictionary<string, string> GetNumeratorAttributeMap(BigDecimal value)
		{
			return GetAttributeMap(value);
		}

		private IDictionary<string, string> GetAttributeMap(BigDecimal value)
		{
			IDictionary<string, string> result = new Dictionary<string, string>();
			result["value"] = value.ToString();
			result["xsi:type"] = "QTY";
			return result;
		}
	}
}
