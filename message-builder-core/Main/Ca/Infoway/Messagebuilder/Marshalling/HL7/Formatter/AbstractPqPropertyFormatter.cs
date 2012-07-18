using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	/// <summary>
	/// PQ - Physical Quantity
	/// Represents a PhysicalQuantity object as an element:
	/// &lt;element-name value="123.33" unit="validUnit"/&gt;
	/// If a value is null, value is replaced by a null flavor.
	/// </summary>
	/// <remarks>
	/// PQ - Physical Quantity
	/// Represents a PhysicalQuantity object as an element:
	/// &lt;element-name value="123.33" unit="validUnit"/&gt;
	/// If a value is null, value is replaced by a null flavor. So the element would look
	/// like this:
	/// &lt;element-name nullFlavor="something" /&gt;
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-PQ
	/// Concreate subclasses of this class will likely limit the valid values for unit.
	/// CeRx specifies that the quantity is formatted as 99999999.99 with no leading or
	/// trailing zeros.
	/// </remarks>
	public abstract class AbstractPqPropertyFormatter : AbstractAttributePropertyFormatter<PhysicalQuantity>
	{
		public static readonly string ATTRIBUTE_UNIT = "unit";

		public static readonly string ATTRIBUTE_VALUE = "value";

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.ModelToXmlTransformationException"></exception>
		internal override IDictionary<string, string> GetAttributeNameValuePairs(FormatContext context, PhysicalQuantity physicalQuantity
			)
		{
			IDictionary<string, string> result = new Dictionary<string, string>();
			if (physicalQuantity == null)
			{
				result[AbstractPropertyFormatter.NULL_FLAVOR_ATTRIBUTE_NAME] = AbstractPropertyFormatter.NULL_FLAVOR_NO_INFORMATION;
			}
			else
			{
				if (physicalQuantity.Quantity == null && physicalQuantity.Unit == null)
				{
					result[AbstractPropertyFormatter.NULL_FLAVOR_ATTRIBUTE_NAME] = AbstractPropertyFormatter.NULL_FLAVOR_NO_INFORMATION;
				}
				else
				{
					if (physicalQuantity.Quantity == null)
					{
						throw new ModelToXmlTransformationException("PhysicalQuantity must define quantity");
					}
					else
					{
						if (IsValidPhysicalQuantity(physicalQuantity))
						{
							result[ATTRIBUTE_VALUE] = FormatQuantity(physicalQuantity.Quantity);
							if (physicalQuantity.Unit != null)
							{
								// if unit is null, then this is an "each"
								result[ATTRIBUTE_UNIT] = physicalQuantity.Unit.CodeValue;
							}
						}
					}
				}
			}
			return result;
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.ModelToXmlTransformationException"></exception>
		protected virtual bool IsValidPhysicalQuantity(PhysicalQuantity physicalQuantity)
		{
			return true;
		}

		protected virtual string FormatQuantity(BigDecimal quantity)
		{
			return quantity.ToString();
		}
	}
}
