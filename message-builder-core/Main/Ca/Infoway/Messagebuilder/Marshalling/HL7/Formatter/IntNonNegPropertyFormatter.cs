using System;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	/// <summary>
	/// INT.NONNEG - Integer (Non-negative)
	/// Represents a INT.NONNEG object as an element:
	/// &lt;element-name value="1234"&gt;&lt;/element-name&gt;
	/// If an object is null, value is replaced by a nullFlavor.
	/// </summary>
	/// <remarks>
	/// INT.NONNEG - Integer (Non-negative)
	/// Represents a INT.NONNEG object as an element:
	/// &lt;element-name value="1234"&gt;&lt;/element-name&gt;
	/// If an object is null, value is replaced by a nullFlavor. So the element would look
	/// like this:
	/// &lt;element-name nullFlavor="something" /&gt;
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-INT
	/// The INT.NONNEG variant defined by CeRx cannot contain negative values. CeRx also defines
	/// a maximum length of 10, which is not enforced by this class.
	/// </remarks>
	[DataTypeHandler("INT.NONNEG")]
	internal class IntNonNegPropertyFormatter : AbstractValueNullFlavorPropertyFormatter<Int32?>
	{
		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.ModelToXmlTransformationException"></exception>
		protected override string GetValue(Int32? integer, FormatContext context)
		{
			return integer.ToString();
		}

		internal override bool IsInvalidValue(FormatContext context, Int32? integer)
		{
			return integer == null || integer.Value < 0;
		}

		protected override string CreateWarningText(FormatContext context, Int32? t)
		{
			return "Value " + t + " should be non-negative.";
		}
	}
}
