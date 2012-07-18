using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	/// <summary>
	/// CeRx specifies that the quantity is formatted as 99999999.99 with no leading or
	/// trailing zeros.
	/// </summary>
	/// <remarks>
	/// CeRx specifies that the quantity is formatted as 99999999.99 with no leading or
	/// trailing zeros.
	/// </remarks>
	public abstract class AbstractCerxPqPropertyFormatter : AbstractPqPropertyFormatter
	{
		private const int MAXIMUM_INTEGER_DIGITS = 11;

		private const int MAXIMUM_FRACTION_DIGITS = 2;

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.ModelToXmlTransformationException"></exception>
		protected override bool IsValidPhysicalQuantity(PhysicalQuantity physicalQuantity)
		{
			// now we have all values be valid; bad values are rounded by NumberFormat, and a warning message is sent back
			return true;
		}

		internal override bool IsInvalidValue(FormatContext context, PhysicalQuantity physicalQuantity)
		{
			if (physicalQuantity.Quantity == null)
			{
				return false;
			}
			else
			{
				return (physicalQuantity.Quantity.Scale() > MAXIMUM_FRACTION_DIGITS) || ((physicalQuantity.Quantity.Precision() - physicalQuantity
					.Quantity.Scale()) > MAXIMUM_INTEGER_DIGITS);
			}
		}

		protected override string CreateWarningText(FormatContext context, PhysicalQuantity physicalQuantity)
		{
			string warningText = string.Empty;
			int decimalDigits = physicalQuantity.Quantity.Scale();
			if (decimalDigits > MAXIMUM_FRACTION_DIGITS)
			{
				warningText += "PhysicalQuantity can contain a maximum of " + MAXIMUM_FRACTION_DIGITS + " decimal places. Value has " + decimalDigits
					 + " decimal places.";
			}
			int intDigits = physicalQuantity.Quantity.Precision() - decimalDigits;
			if (intDigits > MAXIMUM_INTEGER_DIGITS)
			{
				warningText += "PhysicalQuantity can contain a maximum of " + MAXIMUM_INTEGER_DIGITS + " integer places. Value has " + intDigits
					 + " integer places.";
			}
			return StringUtils.IsEmpty(warningText) ? base.CreateWarningText(context, physicalQuantity) : warningText;
		}

		protected override string FormatQuantity(BigDecimal quantity)
		{
			// NumberFormat quietly rounds. This is unfortunate for us. Check before we get to the format step.
			// UPDATE: we are allowing this behaviour to occur, and sending back a warning message rather than
			//         aborting via exception.
			// Redmine 1570 - don't change value even if incorrect; just call toString on it
			return quantity.ToPlainString();
		}
		// return new NumberFormatter().format(quantity, MAXIMUM_LENGTH, MAXIMUM_FRACTION_DIGITS, false); 
	}
}
