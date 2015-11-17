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
 * Author:        $LastChangedBy: tmcgrady $
 * Last modified: $LastChangedDate: 2011-05-04 15:47:15 -0400 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Constraints;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[DataTypeHandler("IVLTSCDAR1")]
	internal class IvlTsCdaPropertyFormatter : PropertyFormatter
	{
		private IvlTsPropertyFormatter r1Formatter = new IvlTsPropertyFormatter();

		private readonly IvlTsConstraintsHandler constraintsHandler = new IvlTsConstraintsHandler();

		public virtual string Format(FormatContext formatContext, BareANY dataType)
		{
			return Format(formatContext, dataType, 0);
		}

		public virtual string Format(FormatContext context, BareANY dataType, int indentLevel)
		{
			if (dataType == null)
			{
				return string.Empty;
			}
			HandleConstraints(context.GetConstraints(), context.GetModelToXmlResult(), context.GetPropertyPath(), (DateInterval)dataType
				.BareValue);
			FormatContext newContext = ConvertContext(context);
			BareANY newDataType = ConvertDataType(dataType);
			return this.r1Formatter.Format(newContext, newDataType, indentLevel);
		}

		private BareANY ConvertDataType(BareANY dataType)
		{
			object bareValue = dataType.BareValue;
			DateInterval ivlTsR2 = (bareValue is DateInterval ? (DateInterval)bareValue : null);
			Interval<PlatformDate> ivlTsR1 = (ivlTsR2 == null ? null : ConvertIvlTs(ivlTsR2));
			BareANY result = new IVLImpl<QTY<PlatformDate>, Interval<PlatformDate>>();
			result.DataType = dataType.DataType;
			result.BareValue = ivlTsR1;
			result.NullFlavor = dataType.NullFlavor;
			return result;
		}

		private void HandleConstraints(ConstrainedDatatype constraints, Hl7Errors errors, string propertyPath, DateInterval dateInterval
			)
		{
			ErrorLogger logger = new _ErrorLogger_73(errors, propertyPath);
			this.constraintsHandler.HandleConstraints(constraints, dateInterval, logger);
		}

		private sealed class _ErrorLogger_73 : ErrorLogger
		{
			public _ErrorLogger_73(Hl7Errors errors, string propertyPath)
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

		private Interval<PlatformDate> ConvertIvlTs(DateInterval ivlTsR2)
		{
			return ivlTsR2 == null ? null : ivlTsR2.Interval;
		}

		private FormatContext ConvertContext(FormatContext formatContext)
		{
			return new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl("IVL<TS>", formatContext);
		}
	}
}
