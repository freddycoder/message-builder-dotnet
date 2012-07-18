using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	/// <summary>
	/// MO - Money
	/// Represents an MO object as an element:
	/// &lt;amt value="10" currency="CAD"/&gt;
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-MO
	/// </summary>
	[DataTypeHandler("MO")]
	internal class MoPropertyFormatter : AbstractAttributePropertyFormatter<Money>
	{
		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.ModelToXmlTransformationException"></exception>
		internal override IDictionary<string, string> GetAttributeNameValuePairs(FormatContext context, Money money)
		{
			IDictionary<string, string> result = new Dictionary<string, string>();
			if (money != null)
			{
				BigDecimal value = money.Amount;
				if (value != null)
				{
					result["value"] = value.ToString();
				}
				Currency currency = money.Currency;
				if (currency != null)
				{
					result["currency"] = currency.CodeValue;
				}
			}
			return result;
		}
	}
}
