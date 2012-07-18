using Ca.Infoway.Messagebuilder;
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
	[DataTypeHandler(new string[] { "REAL.COORD" })]
	public class RealCoordPropertyFormatter : AbstractValueNullFlavorPropertyFormatter<BigDecimal>
	{
		private NumberFormatter formatter = new NumberFormatter();

		private RealFormat format = new RealCoordFormat();

		internal override bool IsInvalidValue(FormatContext context, BigDecimal bigDecimal)
		{
			string value = bigDecimal.SetScale(this.format.GetMaxDecimalPartLength(), System.MidpointRounding.AwayFromZero).ToString(
				);
			if (this.format.GetMaxValueLength() > StringUtils.Length(value))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		protected override string GetValue(BigDecimal bigDecimal, FormatContext context)
		{
			return this.formatter.Format(bigDecimal, this.format.GetMaxValueLength(), this.format.GetMaxDecimalPartLength(), true);
		}
	}
}
