using System;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using ILOG.J2CsMapping.Text;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	/// <summary>
	/// TS.FULLDATEWITHTIME - Abstract TS - must be one of TS.FULLDATE or TS.FULLDATETIME
	/// Represents a TS.FULLDATETIME/TS.DATETIME object as an element:
	/// If an object is null, value is replaced by a nullFlavor.
	/// </summary>
	/// <remarks>
	/// TS.FULLDATEWITHTIME - Abstract TS - must be one of TS.FULLDATE or TS.FULLDATETIME
	/// Represents a TS.FULLDATETIME/TS.DATETIME object as an element:
	/// If an object is null, value is replaced by a nullFlavor. So the element would look
	/// like this:
	/// &lt;element-name nullFlavor="something" /&gt;
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-TS
	/// </remarks>
	[DataTypeHandler(new string[] { "TS.FULLDATEWITHTIME" })]
	public class TsFullDateWithTimePropertyFormatter : AbstractPropertyFormatter
	{
		private static readonly PropertyFormatter fullDateFormatter = new TsFullDatePropertyFormatter();

		private static readonly PropertyFormatter fullDateTimeFormatter = new TsFullDateTimePropertyFormatter();

		public override string Format(FormatContext context, BareANY hl7Value, int indentLevel)
		{
			if (hl7Value == null)
			{
				return string.Empty;
			}
			StandardDataType specializationType = hl7Value.DataType;
			bool valueOmitted = hl7Value.HasNullFlavor() && hl7Value.BareValue == null;
			ValidateSpecializationType(specializationType, valueOmitted, context);
			PropertyFormatter formatter = fullDateTimeFormatter;
			string formatterSpecializationType = StandardDataType.TS_FULLDATETIME.Type;
			if (StandardDataType.TS_FULLDATE == specializationType)
			{
				formatter = fullDateFormatter;
				formatterSpecializationType = StandardDataType.TS_FULLDATE.Type;
			}
			return formatter.Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(formatterSpecializationType
				, true, context), hl7Value, indentLevel);
		}

		private void ValidateSpecializationType(StandardDataType specializationType, bool valueOmitted, FormatContext context)
		{
			if (specializationType == StandardDataType.TS || specializationType == null)
			{
				if (Ca.Infoway.Messagebuilder.BooleanUtils.ValueOf(Runtime.GetProperty(TsDateFormats.ABSTRACT_TS_IGNORE_SPECIALIZATION_TYPE_ERROR_PROPERTY_NAME
					)))
				{
				}
				else
				{
					// user has specified that this validation error should be suppressed
					if (valueOmitted)
					{
					}
					else
					{
						// RM16399 - there are some cases where it is valid to omit a specialization type (such as when not providing a TS value)
						// do nothing; other potential errors will be caught by the default concrete TS formatter 
						context.GetModelToXmlResult().AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, System.String.Format("No specializationType provided. Value should be one of TS.FULLDATE / TS.FULLDATETIME / TS.FULLDATEPARTTIME. TS.FULLDATETIME will be assumed."
							, specializationType.Type), context.GetPropertyPath()));
					}
				}
			}
			else
			{
				if (specializationType != StandardDataType.TS_FULLDATE && specializationType != StandardDataType.TS_FULLDATETIME && specializationType
					 != StandardDataType.TS_FULLDATEPARTTIME)
				{
					context.GetModelToXmlResult().AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, System.String.Format("Invalid specializationType: {0}. Value should be one of TS.FULLDATE / TS.FULLDATETIME / TS.FULLDATEPARTTIME. TS.FULLDATETIME will be assumed."
						, specializationType.Type), context.GetPropertyPath()));
				}
			}
		}
	}
}
