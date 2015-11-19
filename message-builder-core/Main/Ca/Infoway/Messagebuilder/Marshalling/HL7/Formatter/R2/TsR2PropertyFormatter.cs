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
using System;
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2;
using Ca.Infoway.Messagebuilder.Platform;
using ILOG.J2CsMapping.Text;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2
{
	/// <summary>
	/// TS (R2) - Timestamp
	/// Represents a TS object as an element:
	/// &lt;element-name value="yyyyMMddHHmmss"&gt;&lt;/element-name&gt;
	/// If an object is null, value is replaced by a nullFlavor.
	/// </summary>
	/// <remarks>
	/// TS (R2) - Timestamp
	/// Represents a TS object as an element:
	/// &lt;element-name value="yyyyMMddHHmmss"&gt;&lt;/element-name&gt;
	/// If an object is null, value is replaced by a nullFlavor. So the element would look
	/// like this:
	/// &lt;element-name nullFlavor="something" /&gt;
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-TS
	/// </remarks>
	[DataTypeHandler(new string[] { "TS", "SXCM<TS>" })]
	public class TsR2PropertyFormatter : AbstractValueNullFlavorPropertyFormatter<MbDate>
	{
		public static readonly string DATE_FORMAT_OVERRIDE_BASE_PROPERTY_NAME = "messagebuilder.date.format.override.";

		public static readonly string DATE_FORMAT_YYYYMMDDHHMMSS = "yyyyMMddHHmmss";

		public static readonly string DATE_FORMAT_YYYYMMDDHHMMSS_SSSZZZZZ = "yyyyMMddHHmmss.SSS0ZZZZZ";

		private readonly SxcmR2PropertyFormatterHelper sxcmHelper = new SxcmR2PropertyFormatterHelper();

		protected override string GetValue(MbDate mbDate, FormatContext context, BareANY bareAny)
		{
			PlatformDate date = (mbDate == null ? null : mbDate.Value);
			// write out the date using the "full" pattern; clients can override this using a system property or a DateWithPattern date
			VersionNumber version = GetVersion(context);
			string datePattern = DetermineDateFormat(date, version);
			ValidateDatePattern(datePattern, context);
			TimeZoneInfo timeZone = context != null && context.GetDateTimeTimeZone() != null ? context.GetDateTimeTimeZone() : System.TimeZoneInfo.Local;
			return DateFormatUtil.Format(date, datePattern, timeZone);
		}

		protected override void AddOtherAttributesIfNecessary(MbDate v, IDictionary<string, string> attributes, FormatContext context
			, BareANY bareAny)
		{
			this.sxcmHelper.HandleOperator(attributes, context, (ANYMetaData)bareAny);
		}

		private void ValidateDatePattern(string datePattern, FormatContext context)
		{
			string[] allowedDateFormats = TsDateFormats.GetAllDateFormats(StandardDataType.TS_DATETIME, context.GetVersion());
			if (!ArrayContains(allowedDateFormats, datePattern))
			{
				context.GetModelToXmlResult().AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, System.String.Format("Unknown date format {0} supplied for value of type {1}"
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

		// package level for testing purposes
		internal virtual string DetermineDateFormat(PlatformDate date, VersionNumber version)
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
					datePattern = DATE_FORMAT_YYYYMMDDHHMMSS_SSSZZZZZ;
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

		private VersionNumber GetVersion(FormatContext context)
		{
			return context == null ? null : context.GetVersion();
		}
	}
}
