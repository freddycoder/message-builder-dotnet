using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;

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
	[DataTypeHandler("RTO<PQ,PQ>")]
	public class RtoPqPqPropertyFormatter : AbstractRtoPropertyFormatter<PhysicalQuantity, PhysicalQuantity>
	{
		//http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-RTO
		protected override IDictionary<string, string> GetDenominatorAttributeMap(PhysicalQuantity value)
		{
			return GetAttributeMap(value);
		}

		protected override IDictionary<string, string> GetNumeratorAttributeMap(PhysicalQuantity value)
		{
			return GetAttributeMap(value);
		}

		private IDictionary<string, string> GetAttributeMap(PhysicalQuantity value)
		{
			IDictionary<string, string> result = new Dictionary<string, string>();
			result["value"] = value.Quantity.ToString();
			result["unit"] = value.Unit.CodeValue;
			result["xsi:type"] = "PQ";
			return result;
		}
	}
}
