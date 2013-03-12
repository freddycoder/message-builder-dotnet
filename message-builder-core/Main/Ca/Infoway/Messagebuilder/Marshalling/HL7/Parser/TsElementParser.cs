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
 * Last modified: $LastChangedDate: 2011-05-04 16:47:15 -0300 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
using System;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Platform;
using Ca.Infoway.Messagebuilder.Util.Xml;
using ILOG.J2CsMapping.Text;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	/// <summary>Parses a TS element into a Date.</summary>
	/// <remarks>
	/// Parses a TS element into a Date. The element looks like this:
	/// 
	/// If a date is null, value is replaced by a null flavor. So the element would look
	/// like this:
	/// 
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-TS
	/// </remarks>
	[DataTypeHandler("TS")]
	internal class TsElementParser : AbstractSingleElementParser<PlatformDate>
	{
		public static readonly string ABSTRACT_TS_IGNORE_SPECIALIZATION_TYPE_ERROR_PROPERTY_NAME = "messagebuilder.abstract.ts.ignore.specializationtype.error";

		public TsElementParser()
		{
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		protected override PlatformDate ParseNonNullNode(ParseContext context, XmlNode node, BareANY result, Type expectedReturnType
			, XmlToModelResult xmlToModelResult)
		{
			if (IsAbstractFullDateWithTime(context))
			{
				context = HandleSpecializationType(context, node, xmlToModelResult);
			}
			return ParseNonNullNode(context, (XmlElement)node, xmlToModelResult);
		}

		private ParseContext HandleSpecializationType(ParseContext context, XmlNode node, XmlToModelResult xmlToModelResult)
		{
			string specializationType = GetSpecializationType(node);
			if (specializationType == null)
			{
				// TM - RedMine issue 492 - there is some concern over MBT forcing a specialization type for abstract TS type TS_FULLDATEWITHTIME
				//    - I'm relaxing this validation for the time being (the formatter currently ignores specialization type completely)
				//    - (update: perhaps the real issue is that this was an IVL<TS.FULLDATEWITHTIME> and MB has a bug where inner types can't have specializationType set??)
				// TM - 16/10/2012 - should be able to set specialization type now (need to specify IVL_FULL_DATE_TIME as the specialization type for IVL<TS.FULLDATEWITHTIME>, for example)
				//                 - in a cowardly move, I have allowed for a system property to bypass this error
				if (ILOG.J2CsMapping.Util.BooleanUtil.ValueOf(Runtime.GetProperty(ABSTRACT_TS_IGNORE_SPECIALIZATION_TYPE_ERROR_PROPERTY_NAME
					)))
				{
				}
				else
				{
					// do nothing - fall back to parsing through all allowable date formats for TS.FULLDATEWITHTIME
					xmlToModelResult.AddHl7Error(Hl7Error.CreateMissingMandatoryAttributeError(AbstractElementParser.SPECIALIZATION_TYPE, (XmlElement
						)node));
				}
			}
			else
			{
				if (IsValidSpecializationType(specializationType))
				{
					context = ParserContextImpl.Create(specializationType, context.GetExpectedReturnType(), context.GetVersion(), context.GetDateTimeZone
						(), context.GetDateTimeTimeZone(), context.GetConformance(), null, null);
				}
				else
				{
					// log error - fall back to parsing through all allowable date formats for TS.FULLDATEWITHTIME
					xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "Invalid specialization type " + specializationType
						 + " (" + XmlDescriber.DescribeSingleElement((XmlElement)node) + ")", (XmlElement)node));
				}
			}
			return context;
		}

		private bool IsValidSpecializationType(string specializationType)
		{
			StandardDataType type = StandardDataType.GetByTypeName(specializationType);
			return StandardDataType.TS_FULLDATE.Equals(type) || StandardDataType.TS_FULLDATETIME.Equals(type);
		}

		private bool IsAbstractFullDateWithTime(ParseContext context)
		{
			return StandardDataType.TS_FULLDATEWITHTIME.Equals(StandardDataType.GetByTypeName(context));
		}

		// FIXME - TM - for V02R01, "width" property is allowed (PQ.TIME) - need to add support?
		private PlatformDate ParseNonNullNode(ParseContext context, XmlElement element, XmlToModelResult xmlToModelResult)
		{
			PlatformDate result = null;
			string unparsedDate = GetAttributeValue(element, "value");
			if (StringUtils.IsBlank(unparsedDate))
			{
				xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "Timestamp value must be non-blank.", element));
			}
			else
			{
				try
				{
					result = ParseDate(unparsedDate, GetAllDateFormats(context), context);
					CheckForMissingTimezone(context, xmlToModelResult, result, unparsedDate, element);
				}
				catch (ArgumentException)
				{
					result = TryEveryFormat(context, unparsedDate, element, xmlToModelResult);
					if (result == null)
					{
						string message = "The timestamp " + unparsedDate + " in element " + XmlDescriber.DescribeSingleElement(element) + " cannot be parsed.";
						xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, message, element));
					}
				}
			}
			return result;
		}

		private void CheckForMissingTimezone(ParseContext context, XmlToModelResult xmlToModelResult, PlatformDate result, string
			 unparsedDate, XmlElement element)
		{
			// issue a warning if a datetime (partial or otherwise) was passed in without a timezone (non-CeRx only)
			if (context == null || context.GetVersion() == null || !SpecificationVersion.IsVersion(context.GetVersion(), Hl7BaseVersion
				.CERX))
			{
				if (result is DateWithPattern && TsDateFormats.datetimeFormatsRequiringWarning.Contains(((DateWithPattern)result).DatePattern
					))
				{
					xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "Timezone should be specified for datetime " + unparsedDate
						 + ". Value processed without timezone.", element));
				}
			}
		}

		private PlatformDate TryEveryFormat(ParseContext context, string unparsedDate, XmlElement element, XmlToModelResult xmlToModelResult
			)
		{
			PlatformDate result = null;
			foreach (StandardDataType type in TsDateFormats.formats.Keys)
			{
				try
				{
					result = ParseDate(unparsedDate, GetDateFormatsForOtherType(type, context), context);
					if (result != null)
					{
						string message = "The timestamp element {0} appears to be formatted as type {1}, but should be {2}.";
						xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, System.String.Format(message, XmlDescriber.DescribeSingleElement
							(element), type.Type, context.Type), element));
						break;
					}
				}
				catch (ArgumentException)
				{
				}
			}
			return result;
		}

		private string[] GetDateFormatsForOtherType(StandardDataType type, ParseContext context)
		{
			ParseContext newContext;
			if (context == null)
			{
				newContext = ParserContextImpl.Create(type == null ? null : type.Type, null, null, null, null, null, null, null);
			}
			else
			{
				newContext = ParserContextImpl.Create(type == null ? null : type.Type, context.GetExpectedReturnType(), context.GetVersion
					(), context.GetDateTimeZone(), context.GetDateTimeTimeZone(), context.GetConformance());
			}
			return GetAllDateFormats(newContext);
		}

		private string[] GetAllDateFormats(ParseContext context)
		{
			StandardDataType standardDataType = StandardDataType.GetByTypeName(context);
			VersionNumber version = (context == null ? null : context.GetVersion());
			return TsDateFormats.GetAllDateFormats(standardDataType, version);
		}

		/// <summary>Adapted from org.apache.commons.lang.time.DateUtils, but leniency is turned off.</summary>
		/// <remarks>Adapted from org.apache.commons.lang.time.DateUtils, but leniency is turned off.</remarks>
		private PlatformDate ParseDate(string str, string[] parsePatterns, ParseContext context)
		{
			string dateString = StandardizeDate(str);
			for (int i = 0; i < parsePatterns.Length; i++)
			{
				string pattern = parsePatterns[i];
				if (DateFormatUtil.IsMatchingPattern(dateString, pattern))
				{
					PlatformDate date = DateFormatUtil.Parse(dateString, pattern, GetTimeZone(context));
					pattern = ExpandPatternIfNecessary(pattern);
					// SPD: wrap the date in our own Date to remember the chosen parsePattern with the Date
					return new DateWithPattern(date, pattern);
				}
			}
			throw new ArgumentException("Unable to parse the date: " + str);
		}

		private string ExpandPatternIfNecessary(string pattern)
		{
			return TsDateFormats.expandedFormats.ContainsKey(pattern) ? TsDateFormats.expandedFormats.SafeGet(pattern) : pattern;
		}

		private TimeZone GetTimeZone(ParseContext context)
		{
			TimeZone timeZone = null;
			if (NoTimeZonesProvided(context))
			{
				timeZone = System.TimeZone.CurrentTimeZone;
			}
			else
			{
				if (IsDate(context))
				{
					timeZone = GetNonNullTimeZone(context.GetDateTimeZone());
				}
				else
				{
					timeZone = GetNonNullTimeZone(context.GetDateTimeTimeZone());
				}
			}
			return timeZone;
		}

		private bool NoTimeZonesProvided(ParseContext context)
		{
			return context == null || (context.GetDateTimeZone() == null && context.GetDateTimeTimeZone() == null);
		}

		private TimeZone GetNonNullTimeZone(TimeZone timeZone)
		{
			return timeZone == null ? System.TimeZone.CurrentTimeZone : timeZone;
		}

		//	private boolean isDateTime(ParseContext context) {
		//		return StandardDataType.TS_DATETIME.equals(StandardDataType.getByTypeName(context)) ||
		//				StandardDataType.TS_FULLDATETIME.equals(StandardDataType.getByTypeName(context)) ||
		//				StandardDataType.TS_FULLDATEWITHTIME.equals(StandardDataType.getByTypeName(context));
		//	}
		private bool IsDate(ParseContext context)
		{
			return StandardDataType.TS_DATE.Equals(StandardDataType.GetByTypeName(context)) || StandardDataType.TS_FULLDATE.Equals(StandardDataType
				.GetByTypeName(context));
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
			return new TSImpl();
		}
	}
}
