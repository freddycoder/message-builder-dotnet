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
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.Error;
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
	public class TsElementParser : AbstractSingleElementParser<PlatformDate>
	{
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

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		public override BareANY Parse(ParseContext context, XmlNode node, XmlToModelResult xmlToModelResult)
		{
			BareANY parseResult = base.Parse(context, node, xmlToModelResult);
			if (context.IsCda())
			{
				string operatorAsString = GetAttributeValue(node, "operator");
				SetOperator @operator = SetOperator.FindMatchingOperator(operatorAsString);
				((ANYMetaData)parseResult).Operator = @operator;
			}
			return parseResult;
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
				//                 - in a cowardly move, I have allowed for a system property to bypass this validation error
				if (Ca.Infoway.Messagebuilder.BooleanUtils.ValueOf(Runtime.GetProperty(TsDateFormats.ABSTRACT_TS_IGNORE_SPECIALIZATION_TYPE_ERROR_PROPERTY_NAME
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
					context = ParseContextImpl.Create(specializationType, context);
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
			return StandardDataType.TS_FULLDATE.Equals(type) || StandardDataType.TS_FULLDATETIME.Equals(type) || StandardDataType.TS_FULLDATEPARTTIME
				.Equals(type);
		}

		private bool IsAbstractFullDateWithTime(ParseContext context)
		{
			return StandardDataType.TS_FULLDATEWITHTIME.Equals(StandardDataType.GetByTypeName(context));
		}

		private PlatformDate ParseNonNullNode(ParseContext context, XmlElement element, XmlToModelResult xmlToModelResult)
		{
			// TM - for V02R01, "width" property is allowed (PQ.TIME) - not including this here, as MB does not officially support that release
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
					result = ParseDate(unparsedDate, GetAllDateFormats(StandardDataType.GetByTypeName(GetType(context)), context.GetVersion()
						), context);
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
			StandardDataType standardDataType = StandardDataType.GetByTypeName(context);
			if (context == null || context.GetVersion() == null || !SpecificationVersion.IsVersion(standardDataType, context.GetVersion
				(), Hl7BaseVersion.CERX))
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
			return GetAllDateFormats(type, context == null ? null : context.GetVersion());
		}

		private string[] GetAllDateFormats(StandardDataType type, VersionNumber version)
		{
			return TsDateFormats.GetAllDateFormats(type, version);
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

		private TimeZoneInfo GetTimeZone(ParseContext context)
		{
			TimeZoneInfo timeZone = null;
			if (NoTimeZonesProvided(context))
			{
				timeZone = System.TimeZoneInfo.Local;
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

		private TimeZoneInfo GetNonNullTimeZone(TimeZoneInfo timeZone)
		{
			return timeZone == null ? System.TimeZoneInfo.Local : timeZone;
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
