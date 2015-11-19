using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Platform;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	/// <summary>
	/// REAL.CONF - BigDecimal [0,1]
	/// Represents a REAL.CONF object as an element:
	/// &lt;element-name value="0.1234"&gt;&lt;/element-name&gt;
	/// If an object is null, value is replaced by a nullFlavor.
	/// </summary>
	/// <remarks>
	/// REAL.CONF - BigDecimal [0,1]
	/// Represents a REAL.CONF object as an element:
	/// &lt;element-name value="0.1234"&gt;&lt;/element-name&gt;
	/// If an object is null, value is replaced by a nullFlavor. So the element would look
	/// like this:
	/// &lt;element-name nullFlavor="something" /&gt;
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-REAL
	/// The REAL.CONF variant defined by CHI can only contain positive values between 0 to 1 (inclusive). CHI also
	/// defines maximum length 1 character to the left of the decimal point and 4 characters to the right.
	/// </remarks>
	[DataTypeHandler(new string[] { "REAL.CONF" })]
	public class RealConfPropertyFormatter : AbstractValueNullFlavorPropertyFormatter<BigDecimal>
	{
		private NumberFormatter numberFormatter = new NumberFormatter();

		private RealFormat realFormat = new RealConfFormat();

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
			if (bigDecimal.CompareTo(BigDecimal.ZERO) < 0 || bigDecimal.CompareTo(BigDecimal.ONE) > 0)
			{
				RecordValueMustBeBetweenZeroAndOneError(context.GetPropertyPath(), modelToXmlResult);
			}
			if (bigDecimal.Scale() > realFormat.GetMaxDecimalPartLength())
			{
				RecordTooManyDigitsToRightOfDecimalError(context.GetPropertyPath(), modelToXmlResult);
			}
		}

		private void RecordValueMustBeBetweenZeroAndOneError(string propertyPath, ModelToXmlResult modelToXmlResult)
		{
			modelToXmlResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "Value for REAL.CONF must be between 0 and 1 (inclusive). Value may have been modified to fit format requirements."
				, propertyPath));
		}

		private void RecordTooManyDigitsToRightOfDecimalError(string propertyPath, ModelToXmlResult modelToXmlResult)
		{
			modelToXmlResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "Value for REAL.CONF must have no more than " + realFormat
				.GetMaxDecimalPartLength() + " digits to the right of the decimal. Value has been modified to fit format requirements.", 
				propertyPath));
		}
	}
}
