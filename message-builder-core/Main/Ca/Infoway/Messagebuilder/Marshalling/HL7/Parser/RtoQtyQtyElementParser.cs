using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	/// <summary>
	/// RTO - Ratio (quantity, quantity)
	/// Parses into a Ratio of quantities.
	/// </summary>
	/// <remarks>
	/// RTO - Ratio (quantity, quantity)
	/// Parses into a Ratio of quantities. The element looks like this:
	/// 
	/// 
	/// 
	/// 
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-RTO
	/// </remarks>
	[DataTypeHandler("RTO<QTY,QTY>")]
	internal class RtoQtyQtyElementParser : AbstractRtoElementParser<BigDecimal, BigDecimal>
	{
		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		protected override BigDecimal GetNumeratorValue(XmlElement element)
		{
			return GetValue(element);
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		protected override BigDecimal GetDenominatorValue(XmlElement element)
		{
			return GetValue(element);
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		private BigDecimal GetValue(XmlElement element)
		{
			return new BigDecimal(GetAttributeValue(element, "value"));
		}
	}
}
