using System;
using System.Collections.Generic;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Platform;
using Ca.Infoway.Messagebuilder.Util.Xml;
using ILOG.J2CsMapping.Collections.Generics;
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
		private readonly IDictionary<StandardDataType, IList<string>> formats;

		private readonly IDictionary<string, string> expandedFormats;

		private readonly IDictionary<VersionNumber, IDictionary<StandardDataType, IList<string>>> versionFormatExceptions;

		public TsElementParser()
		{
			IDictionary<StandardDataType, IList<string>> map = new Dictionary<StandardDataType, IList<string>>();
			map[StandardDataType.TS_FULLDATETIME] = Arrays.AsList("yyyyMMddHHmmss.SSSZZZZZ", "yyyyMMddHHmmssZZZZZ");
			// this is an abstract type and these formats are only used after issuing a warning (there should be a specializationType)
			map[StandardDataType.TS_FULLDATEWITHTIME] = Arrays.AsList("yyyyMMddHHmmss.SSSZZZZZ", "yyyyMMddHHmmssZZZZZ", "yyyyMMdd");
			map[StandardDataType.TS_FULLDATE] = Arrays.AsList("yyyyMMdd");
			map[StandardDataType.TS_DATE] = Arrays.AsList("yyyyMMdd", "yyyyMM", "yyyy");
			map[StandardDataType.TS_DATETIME] = Arrays.AsList("yyyyMMddHHmmss.SSSZZZZZ", "yyyyMMddHHmmss.SSS", "yyyyMMddHHmmssZZZZZ", 
				"yyyyMMddHHmmss", "yyyyMMddHHmmZZZZZ", "yyyyMMddHHmm", "yyyyMMddHHZZZZZ", "yyyyMMddHH", "yyyyMMddZZZZZ", "yyyyMMdd", "yyyyMMZZZZZ"
				, "yyyyMM", "yyyyZZZZZ", "yyyy");
			map[StandardDataType.TS] = map.SafeGet(StandardDataType.TS_DATETIME);
			this.formats = Ca.Infoway.Messagebuilder.CollUtils.CreateUnmodifiableDictionary(map);
			this.expandedFormats = new Dictionary<string, string>();
			this.expandedFormats["yyyyMMddHHmmss.SSSZZZZZ"] = "yyyyMMddHHmmss.SSS0ZZZZZ";
			this.expandedFormats["yyyyMMddHHmmss.SSS"] = "yyyyMMddHHmmss.SSS0";
			// some older versions have slightly different rules for allowable time formats
			IDictionary<StandardDataType, IList<string>> exceptionMapV02R01 = new Dictionary<StandardDataType, IList<string>>();
			exceptionMapV02R01[StandardDataType.TS_FULLDATEWITHTIME] = CollUtils.EmptyList<string>();
			IDictionary<StandardDataType, IList<string>> exceptionMapV01R04_3 = new Dictionary<StandardDataType, IList<string>>();
			exceptionMapV01R04_3[StandardDataType.TS_FULLDATEWITHTIME] = CollUtils.EmptyList<string>();
			exceptionMapV01R04_3[StandardDataType.TS_FULLDATETIME] = Arrays.AsList("yyyyMMddHHmmss");
			exceptionMapV01R04_3[StandardDataType.TS_DATETIME] = Arrays.AsList("yyyyMMddHHmmss", "yyyyMMddHHmm", "yyyyMMddHH", "yyyyMMdd"
				, "yyyyMM", "yyyy");
			IDictionary<VersionNumber, IDictionary<StandardDataType, IList<string>>> versionMap = new Dictionary<VersionNumber, IDictionary
				<StandardDataType, IList<string>>>();
			versionMap[SpecificationVersion.V02R01] = Ca.Infoway.Messagebuilder.CollUtils.CreateUnmodifiableDictionary(exceptionMapV02R01
				);
			versionMap[SpecificationVersion.V01R04_3] = Ca.Infoway.Messagebuilder.CollUtils.CreateUnmodifiableDictionary(exceptionMapV01R04_3
				);
			this.versionFormatExceptions = Ca.Infoway.Messagebuilder.CollUtils.CreateUnmodifiableDictionary(versionMap);
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
			string specializationType = GetAttributeValue(node, AbstractElementParser.SPECIALIZATION_TYPE);
			if (specializationType == null)
			{
			}
			else
			{
				// TM - RedMine issue 492 - there is some concern over MBT forcing a specialization type for abstract TS types
				//    - I'm relaxing this validation for the time being (the formatter currently ignores specialization type completely)
				// do nothing - fall back to parsing through all allowable date formats for TS.FULLDATEWITHTIME
				// xmlToModelResult.addHl7Error(Hl7Error.createMissingMandatoryAttributeError(SPECIALIZATION_TYPE, (Element) node));
				if (IsValidType(specializationType))
				{
					context = ParserContextImpl.Create(specializationType, context.GetExpectedReturnType(), context.GetVersion(), context.GetDateTimeZone
						(), context.GetDateTimeTimeZone(), context.GetConformance(), null, null);
				}
				else
				{
					xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "Invalid specialization type " + specializationType
						 + " (" + XmlDescriber.DescribeSingleElement((XmlElement)node) + ")", (XmlElement)node));
				}
			}
			return context;
		}

		private bool IsValidType(string specializationType)
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

		private PlatformDate TryEveryFormat(ParseContext context, string unparsedDate, XmlElement element, XmlToModelResult xmlToModelResult
			)
		{
			PlatformDate result = null;
			foreach (StandardDataType type in this.formats.Keys)
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
			IDictionary<StandardDataType, IList<string>> exceptionMap = this.versionFormatExceptions.SafeGet(context == null ? null : 
				context.GetVersion());
			if (exceptionMap == null)
			{
				exceptionMap = this.versionFormatExceptions.SafeGet(context == null ? null : context.GetVersion() == null ? null : context
					.GetVersion().GetBaseVersion());
			}
			IList<string> formats = (exceptionMap == null ? null : exceptionMap.SafeGet(standardDataType));
			if (formats == null)
			{
				formats = this.formats.SafeGet(standardDataType);
			}
			return CollUtils.IsEmpty(formats) ? new string[0] : formats.ToArray(new string[formats.Count]);
		}

		/// <summary>Adapted from org.apache.commons.lang.time.DateUtils, but leniency is turned off.</summary>
		/// <remarks>Adapted from org.apache.commons.lang.time.DateUtils, but leniency is turned off.</remarks>
		/// <param name="context">TODO</param>
		private PlatformDate ParseDate(string str, string[] parsePatterns, ParseContext context)
		{
			string dateString = StandardizeDate(str);
			for (int i = 0; i < parsePatterns.Length; i++)
			{
				string pattern = parsePatterns[i];
				if (DateFormatUtil.IsMatchingPattern(dateString, pattern))
				{
					PlatformDate date = DateFormatUtil.Parse(dateString, pattern, GetTimeZone(context));
					// SPD: wrap the date in our own Date to remember the chosen parsePattern with the Date
					pattern = ExpandPatternIfNecessary(pattern);
					return new DateWithPattern(date, pattern);
				}
			}
			throw new ArgumentException("Unable to parse the date: " + str);
		}

		private string ExpandPatternIfNecessary(string pattern)
		{
			return this.expandedFormats.ContainsKey(pattern) ? this.expandedFormats.SafeGet(pattern) : pattern;
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
					if (IsDateTime(context))
					{
						timeZone = GetNonNullTimeZone(context.GetDateTimeTimeZone());
					}
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

		private bool IsDateTime(ParseContext context)
		{
			return StandardDataType.TS_DATETIME.Equals(StandardDataType.GetByTypeName(context)) || StandardDataType.TS_FULLDATETIME.Equals
				(StandardDataType.GetByTypeName(context)) || StandardDataType.TS_FULLDATEWITHTIME.Equals(StandardDataType.GetByTypeName(
				context));
		}

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
