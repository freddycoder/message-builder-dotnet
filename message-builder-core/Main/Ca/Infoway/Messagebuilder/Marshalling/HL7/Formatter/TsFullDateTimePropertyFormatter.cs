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
using System;
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Platform;
using ILOG.J2CsMapping.Text;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	/// <summary>
	/// TS.FULLDATETIME - Timestamp (fully-specified date and time only) and TS.DATETIME (partial date/time) and TS.FULLDATEPARTTIME
	/// Represents a TS.FULLDATETIME/TS.FULLDATEPARTTIME/TS.DATETIME object as an element:
	/// &lt;element-name value="yyyyMMddHHmmss"&gt;&lt;/element-name&gt;
	/// If an object is null, value is replaced by a nullFlavor.
	/// </summary>
	/// <remarks>
	/// TS.FULLDATETIME - Timestamp (fully-specified date and time only) and TS.DATETIME (partial date/time) and TS.FULLDATEPARTTIME
	/// Represents a TS.FULLDATETIME/TS.FULLDATEPARTTIME/TS.DATETIME object as an element:
	/// &lt;element-name value="yyyyMMddHHmmss"&gt;&lt;/element-name&gt;
	/// If an object is null, value is replaced by a nullFlavor. So the element would look
	/// like this:
	/// &lt;element-name nullFlavor="something" /&gt;
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-TS
	/// </remarks>
	[DataTypeHandler(new string[] { "TS", "TS.FULLDATETIME", "TS.FULLDATEPARTTIME", "TS.DATETIME" })]
	public class TsFullDateTimePropertyFormatter : AbstractValueNullFlavorPropertyFormatter<PlatformDate>
	{
		public static readonly string DATE_FORMAT_OVERRIDE_BASE_PROPERTY_NAME = "messagebuilder.date.format.override.";

		public static readonly string DATE_FORMAT_YYYYMMDDHHMMSS = "yyyyMMddHHmmss";

		public static readonly string DATE_FORMAT_YYYYMMDDHHMMSS_SSSZZZZZ = "yyyyMMddHHmmss.SSS0ZZZZZ";

		protected override string GetValue(PlatformDate date, FormatContext context, BareANY bareAny)
		{
			// write out the date using the applicable "full" pattern; clients can override this using a system property or a DateWithPattern date
			VersionNumber version = GetVersion(context);
			StandardDataType standardDataType = StandardDataType.GetByTypeName(context);
			string datePattern = DetermineDateFormat(standardDataType, date, version);
			ValidateDatePattern(datePattern, context);
			TimeZoneInfo timeZone = context != null && context.GetDateTimeTimeZone() != null ? context.GetDateTimeTimeZone() : System.TimeZoneInfo.Local;
			return DateFormatUtil.Format(date, datePattern, timeZone);
		}

		private void ValidateDatePattern(string datePattern, FormatContext context)
		{
			StandardDataType standardDataType = StandardDataType.GetByTypeName(context);
			VersionNumber version = (context == null ? null : context.GetVersion());
			string[] allowedDateFormats = TsDateFormats.GetAllDateFormats(standardDataType, version);
			if (ArrayContains(allowedDateFormats, datePattern))
			{
				// check if this pattern is missing a timezone
				if (!IsCerx(standardDataType, version) && TsDateFormats.datetimeFormatsRequiringWarning.Contains(datePattern))
				{
					context.GetModelToXmlResult().AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, System.String.Format("Date format {0} supplied for value of type {1} should also have a timezone (ZZZZZ)"
						, datePattern, context == null ? "TS" : context.Type), context.GetPropertyPath()));
				}
			}
			else
			{
				context.GetModelToXmlResult().AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, System.String.Format("Invalid date format {0} supplied for value of type {1}"
					, datePattern, context == null ? "TS" : context.Type), context.GetPropertyPath()));
			}
		}

		private bool ArrayContains(string[] allowedDateFormats, string datePattern)
		{
			for (int i = 0; i < allowedDateFormats.Length; i++)
			{
				if (allowedDateFormats[i].Equals(datePattern))
				{
					return true;
				}
			}
			return false;
		}

		private bool IsCerx(StandardDataType standardDataType, VersionNumber version)
		{
			return SpecificationVersion.IsVersion(standardDataType, version, Hl7BaseVersion.CERX);
		}

		// package level for testing purposes
		internal virtual string DetermineDateFormat(StandardDataType standardDataType, PlatformDate date, VersionNumber version)
		{
			// date format precedence:
			//    provided Date is a dateWithPattern
			//    format has been overridden for this version
			//    default format for version/specializationType
			string datePattern = GetPatternFromDateWithPattern(date);
			if (datePattern == null)
			{
				datePattern = GetOverrideDatePattern(version);
				if (datePattern == null)
				{
					datePattern = GetDefaultDatePattern(standardDataType, version);
				}
			}
			return datePattern;
		}

		private string GetOverrideDatePattern(VersionNumber version)
		{
			if (version == null)
			{
				return null;
			}
			return Runtime.GetProperty(DATE_FORMAT_OVERRIDE_BASE_PROPERTY_NAME + version.VersionLiteral);
		}

		private string GetPatternFromDateWithPattern(PlatformDate date)
		{
			if (date is DateWithPattern)
			{
				return ((DateWithPattern)date).DatePattern;
			}
			return null;
		}

		private string GetDefaultDatePattern(StandardDataType standardDataType, VersionNumber version)
		{
			if (SpecificationVersion.IsVersion(standardDataType, version, Hl7BaseVersion.CERX))
			{
				return DATE_FORMAT_YYYYMMDDHHMMSS;
			}
			return DATE_FORMAT_YYYYMMDDHHMMSS_SSSZZZZZ;
		}

		private VersionNumber GetVersion(FormatContext context)
		{
			return context == null ? null : context.GetVersion();
		}

		protected override void AddOtherAttributesIfNecessary(PlatformDate v, IDictionary<string, string> attributes, FormatContext
			 context, BareANY bareAny)
		{
			base.AddOtherAttributesIfNecessary(v, attributes, context, bareAny);
			if (context.IsCda())
			{
				SetOperator @operator = ((ANYMetaData)bareAny).Operator;
				if (@operator != null)
				{
					attributes["operator"] = @operator.CodeValue;
				}
			}
		}
	}
}
