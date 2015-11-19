using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Constraints;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2
{
	[DataTypeHandler("IVL<TS>")]
	public class IvlTsR2PropertyFormatter : PropertyFormatter
	{
		private readonly IvlTsConstraintsHandler constraintsHandler = new IvlTsConstraintsHandler();

		private class ActualFormatterClass : IvlR2PropertyFormatter<MbDate>
		{
		}

		private static IvlR2PropertyFormatter<MbDate> actualFormatter = new IvlTsR2PropertyFormatter.ActualFormatterClass();

		public virtual string Format(FormatContext formatContext, BareANY dataType)
		{
			return Format(formatContext, dataType, 0);
		}

		public virtual string Format(FormatContext context, BareANY value, int indentLevel)
		{
			if (value == null)
			{
				return string.Empty;
			}
			object bareValue = value.BareValue;
			Interval<PlatformDate> innerDateInterval = null;
			Interval<MbDate> innerMbDateInterval = null;
			if (bareValue != null && bareValue is DateInterval)
			{
				DateInterval dateInterval = (DateInterval)bareValue;
				HandleConstraints(context, context.GetModelToXmlResult(), context.GetPropertyPath(), dateInterval);
				innerDateInterval = dateInterval.Interval;
				innerMbDateInterval = IntervalFactory.CreateMbDateInterval(innerDateInterval);
			}
			BareANY newValue = new IVLImpl<TS, Interval<MbDate>>(typeof(Interval<object>), innerMbDateInterval, value.NullFlavor, value
				.DataType);
			return actualFormatter.Format(context, newValue, indentLevel);
		}

		private void HandleConstraints(FormatContext context, Hl7Errors errors, string propertyPath, DateInterval dateInterval)
		{
			ErrorLogger logger = new _ErrorLogger_74(errors, propertyPath);
			this.constraintsHandler.HandleConstraints(context.GetConstraints(), dateInterval, logger);
		}

		private sealed class _ErrorLogger_74 : ErrorLogger
		{
			public _ErrorLogger_74(Hl7Errors errors, string propertyPath)
			{
				this.errors = errors;
				this.propertyPath = propertyPath;
			}

			public void LogError(Hl7ErrorCode errorCode, ErrorLevel errorLevel, string errorMessage)
			{
				errors.AddHl7Error(new Hl7Error(errorCode, errorLevel, errorMessage, propertyPath));
			}

			private readonly Hl7Errors errors;

			private readonly string propertyPath;
		}
	}
}
