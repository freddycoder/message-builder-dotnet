using System;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2
{
	/// <summary>ANY (R2)</summary>
	[DataTypeHandler("ANY")]
	public class AnyR2PropertyFormatter : AbstractNullFlavorPropertyFormatter<object>
	{
		protected override string FormatNonNullDataType(FormatContext context, BareANY hl7Value, int indentLevel)
		{
			string actualType = hl7Value.DataType.Type;
			StandardDataType actualTypeAsEnum = StandardDataType.GetByTypeName(actualType);
			string result = null;
			if (actualTypeAsEnum == null)
			{
				RecordError("Could not determine type for ANY relationship." + (actualType == null ? "'" : actualType + "' not found in StandardDataType enum."
					), context);
			}
			else
			{
				if (StandardDataType.ANY.Equals(actualTypeAsEnum.RootDataType))
				{
					// actual type has been determined to be ANY; this (most likely) means a concrete type has not been specified  
					RecordError("A concrete data type must be specified for a relationship of type ANY.", context);
				}
				else
				{
					PropertyFormatter formatter = FormatterR2Registry.GetInstance().Get(actualType);
					if (formatter == null)
					{
						string errorText = "Cannot support properties of type " + actualType + " for relationship of type ANY. Please specify a type applicable for ANY in the appropriate message bean.";
						RecordError(errorText, context);
					}
					else
					{
						// adjust context and pass processing off to the formatter applicable for the specified type
						result = formatter.Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(actualType, true, context
							), hl7Value, indentLevel);
					}
				}
			}
			return result;
		}

		protected override string FormatNonNullValue(FormatContext formatContext, object t, int indentLevel)
		{
			throw new NotSupportedException("Use formatNonNullDataType() instead.");
		}

		private void RecordError(string message, FormatContext context)
		{
			string propertyPath = context.GetPropertyPath();
			context.GetModelToXmlResult().AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, message, propertyPath));
		}
	}
}
