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
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2;
using Ca.Infoway.Messagebuilder.Platform;
using Ca.Infoway.Messagebuilder.Util.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2
{
	/// <summary>Parses a TS element into a Date (R2).</summary>
	/// <remarks>
	/// Parses a TS element into a Date (R2). The element looks like this:
	/// 
	/// If a date is null, value is replaced by a null flavor. So the element would look
	/// like this:
	/// 
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-TS
	/// </remarks>
	[DataTypeHandler(new string[] { "TS", "SXCM<TS>" })]
	public class TsR2ElementParser : AbstractSingleElementParser<MbDate>
	{
		private readonly SxcmR2ElementParserHelper sxcmHelper = new SxcmR2ElementParserHelper();

		public TsR2ElementParser()
		{
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		protected override MbDate ParseNonNullNode(ParseContext context, XmlNode node, BareANY bareAny, Type expectedReturnType, 
			XmlToModelResult xmlToModelResult)
		{
			XmlElement element = (XmlElement)node;
			MbDate result = null;
			string unparsedDate = GetAttributeValue(node, "value");
			if (StringUtils.IsBlank(unparsedDate))
			{
				xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "Timestamp value must be non-blank.", element));
			}
			else
			{
				try
				{
					PlatformDate parsedDate = ParseDate(unparsedDate, GetAllDateFormats(context), context);
					result = (parsedDate == null ? null : new MbDate(parsedDate));
				}
				catch (ArgumentException)
				{
					string message = "The timestamp " + unparsedDate + " in element " + XmlDescriber.DescribeSingleElement(element) + " cannot be parsed.";
					xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, message, element));
				}
				this.sxcmHelper.HandleOperator(element, context, xmlToModelResult, (ANYMetaData)bareAny);
			}
			return result;
		}

		private string[] GetAllDateFormats(ParseContext context)
		{
			// use R020403 as it has no restrictions (and for R2, the acceptable date formats appear to be wide open)
			return TsDateFormats.GetAllDateFormats(StandardDataType.TS_DATETIME, SpecificationVersion.R02_04_03);
		}

		/// <summary>Adapted from org.apache.commons.lang.time.DateUtils, but leniency is turned off.</summary>
		/// <remarks>Adapted from org.apache.commons.lang.time.DateUtils, but leniency is turned off.</remarks>
		private PlatformDate ParseDate(string str, string[] parsePatterns, ParseContext context)
		{
			string dateString = StandardizeDate(str);
			bool dateModified = !StringUtils.Equals(str, dateString);
			for (int i = 0; i < parsePatterns.Length; i++)
			{
				string pattern = parsePatterns[i];
				if (DateFormatUtil.IsMatchingPattern(dateString, pattern))
				{
					PlatformDate date = DateFormatUtil.Parse(dateString, pattern, GetTimeZone(context));
					pattern = ExpandPatternIfNecessary(pattern, dateModified);
					// SPD: wrap the date in our own Date to remember the chosen parsePattern with the Date
					return new DateWithPattern(date, pattern);
				}
			}
			throw new ArgumentException("Unable to parse the date: " + str);
		}

		private string ExpandPatternIfNecessary(string pattern, bool dateModified)
		{
			// TM - do not expand the date pattern if it was not changed
			if (dateModified)
			{
				pattern = (TsDateFormats.expandedFormats.ContainsKey(pattern) ? TsDateFormats.expandedFormats.SafeGet(pattern) : pattern);
			}
			return pattern;
		}

		private TimeZoneInfo GetTimeZone(ParseContext context)
		{
			TimeZoneInfo timeZone = null;
			if (NoTimeZonesProvided(context))
			{
				timeZone = System.TimeZoneInfo.Local;
			}
			else
			{
				timeZone = GetNonNullTimeZone(context.GetDateTimeTimeZone());
			}
			return timeZone;
		}

		private bool NoTimeZonesProvided(ParseContext context)
		{
			return context == null || (context.GetDateTimeZone() == null && context.GetDateTimeTimeZone() == null);
		}

		private TimeZoneInfo GetNonNullTimeZone(TimeZoneInfo timeZone)
		{
			return timeZone == null ? System.TimeZoneInfo.Local : timeZone;
		}

		private string StandardizeDate(string inputDate)
		{
			string result = inputDate;
			int decimalPointIndex = inputDate.IndexOf('.');
			int timezoneDelimiterIndex = inputDate.IndexOf('-');
			if (timezoneDelimiterIndex < 0)
			{
				timezoneDelimiterIndex = inputDate.IndexOf('+');
			}
			if (decimalPointIndex >= 0 && timezoneDelimiterIndex >= 0 && timezoneDelimiterIndex > decimalPointIndex)
			{
				string upToDecimalPoint = Ca.Infoway.Messagebuilder.StringUtils.Substring(inputDate, 0, decimalPointIndex + 1);
				string partialSeconds = Ca.Infoway.Messagebuilder.StringUtils.Substring(inputDate, decimalPointIndex + 1, timezoneDelimiterIndex
					);
				string timezone = Ca.Infoway.Messagebuilder.StringUtils.Substring(inputDate, timezoneDelimiterIndex);
				if (StringUtils.IsNumeric(partialSeconds) && partialSeconds.Length > 3)
				{
					result = upToDecimalPoint + Ca.Infoway.Messagebuilder.StringUtils.Substring(partialSeconds, 0, 3) + timezone;
				}
			}
			return result;
		}

		protected override BareANY DoCreateDataTypeInstance(string typeName)
		{
			return new TS_R2Impl();
		}
	}
}
