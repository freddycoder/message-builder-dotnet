using System;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	/// <summary>
	/// INT.POS - Integer (Positive)
	/// Represents a INT.POS object as an element:
	/// &lt;element-name value="1234"&gt;&lt;/element-name&gt;
	/// If an object is null, value is replaced by a nullFlavor.
	/// </summary>
	/// <remarks>
	/// INT.POS - Integer (Positive)
	/// Represents a INT.POS object as an element:
	/// &lt;element-name value="1234"&gt;&lt;/element-name&gt;
	/// If an object is null, value is replaced by a nullFlavor. So the element would look
	/// like this:
	/// &lt;element-name nullFlavor="something" /&gt;
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-INT
	/// The INT.POS variant defined by CeRx can only contain positive values. CeRx also defines
	/// a maximum length of 10, which is not enforced by this class.
	/// </remarks>
	[DataTypeHandler("INT.POS")]
	internal class IntPosPropertyFormatter : AbstractValueNullFlavorPropertyFormatter<Int32?>
	{
		protected override string GetValue(Int32? integer, FormatContext context, BareANY bareAny)
		{
			Validate(integer, context, bareAny);
			return integer.ToString();
		}

		private void Validate(Int32? integer, FormatContext context, BareANY bareAny)
		{
			if (integer.Value <= 0)
			{
				RecordMustBeGreaterThanZeroError(integer, context.GetPropertyPath(), context.GetModelToXmlResult());
			}
		}

		private void RecordMustBeGreaterThanZeroError(Int32? integer, string propertyPath, ModelToXmlResult modelToXmlResult)
		{
			modelToXmlResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "The attribute \"value\" must be greater than zero for INT.POS."
				, propertyPath));
		}
	}
}
