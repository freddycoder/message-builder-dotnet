using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Platform;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	/// <summary>
	/// REAL.COORD - BigDecimal
	/// Represents a REAL.COORD object as an element:
	/// &lt;element-name value="4321.1234"&gt;&lt;/element-name&gt;
	/// If an object is null, value is replaced by a nullFlavor.
	/// </summary>
	/// <remarks>
	/// REAL.COORD - BigDecimal
	/// Represents a REAL.COORD object as an element:
	/// &lt;element-name value="4321.1234"&gt;&lt;/element-name&gt;
	/// If an object is null, value is replaced by a nullFlavor. So the element would look
	/// like this:
	/// &lt;element-name nullFlavor="something" /&gt;
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-REAL
	/// The REAL.COORD variant defined by CHI can only values with maximum length 4 characters to the left of the decimal point and 4 characters to the right.
	/// </remarks>
	[DataTypeHandler(new string[] { "REAL.COORD" })]
	public class RealCoordPropertyFormatter : AbstractValueNullFlavorPropertyFormatter<BigDecimal>
	{
		private NumberFormatter numberFormatter = new NumberFormatter();

		private RealFormat realFormat = new RealCoordFormat();

		protected override string GetValue(BigDecimal bigDecimal, FormatContext context, BareANY bareAny)
		{
			Validate(context, bigDecimal);
			return this.numberFormatter.Format(bigDecimal, this.realFormat.GetMaxValueLength(), this.realFormat.GetMaxIntegerPartLength
				(), DetermineScale(bigDecimal), true);
		}

		private int DetermineScale(BigDecimal bigDecimal)
		{
			bool useBigDecimalScale = (bigDecimal.Scale() >= 0 && bigDecimal.Scale() < this.realFormat.GetMaxDecimalPartLength());
			return useBigDecimalScale ? bigDecimal.Scale() : this.realFormat.GetMaxDecimalPartLength();
		}

		private void Validate(FormatContext context, BigDecimal bigDecimal)
		{
			ModelToXmlResult modelToXmlResult = context.GetModelToXmlResult();
			string value = bigDecimal.ToString();
			string integerPart = value.Contains(".") ? StringUtils.SubstringBefore(value, ".") : value;
			string decimalPart = value.Contains(".") ? StringUtils.SubstringAfter(value, ".") : string.Empty;
			if (integerPart.Length > realFormat.GetMaxIntegerPartLength())
			{
				RecordTooManyCharactersToLeftOfDecimalError(context.GetPropertyPath(), modelToXmlResult);
			}
			if (decimalPart.Length > realFormat.GetMaxDecimalPartLength())
			{
				RecordTooManyDigitsToRightOfDecimalError(context.GetPropertyPath(), modelToXmlResult);
			}
		}

		private void RecordTooManyCharactersToLeftOfDecimalError(string propertyPath, ModelToXmlResult modelToXmlResult)
		{
			modelToXmlResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "Value for REAL.COORD must have no more than " + 
				realFormat.GetMaxIntegerPartLength() + " characters to the left of the decimal. Value has been modified to fit format requirements."
				, propertyPath));
		}

		private void RecordTooManyDigitsToRightOfDecimalError(string propertyPath, ModelToXmlResult modelToXmlResult)
		{
			modelToXmlResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "Value for REAL.COORD must have no more than " + 
				realFormat.GetMaxDecimalPartLength() + " digits to the right of the decimal. Value has been modified to fit format requirements."
				, propertyPath));
		}
	}
}
