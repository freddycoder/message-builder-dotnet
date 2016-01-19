/**
 * Copyright 2013 Canada Health Infoway, Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *        http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 * Author:        $LastChangedBy: gng $
 * Last modified: $LastChangedDate: 2015-11-19 18:20:12 -0500 (Fri, 30 Jan 2015) $
 * Revision:      $LastChangedRevision: 9755 $
 */


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
