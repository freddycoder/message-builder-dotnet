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
using System.Collections.Generic;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Constraints;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2
{
	[DataTypeHandler("IVL<TS>")]
	internal class IvlTsR2ElementParser : ElementParser
	{
		private readonly IvlTsConstraintsHandler constraintsHandler = new IvlTsConstraintsHandler();

		private class ActualIvlTsParserClass : IvlR2ElementParser<PlatformDate>
		{
			protected override object ExtractValue(BareANY any)
			{
				object value = any == null ? null : any.BareValue;
				return value == null ? null : ((MbDate)value).Value;
			}
		}

		private static IvlR2ElementParser<PlatformDate> actualIvlTsParser = new IvlTsR2ElementParser.ActualIvlTsParserClass();

		public IvlTsR2ElementParser()
		{
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		public virtual BareANY Parse(ParseContext context, IList<XmlNode> nodes, XmlToModelResult xmlToModelResult)
		{
			BareANY parsedValue = actualIvlTsParser.Parse(context, nodes, xmlToModelResult);
			// need to wrap result in a DateInterval
			object bareValue = parsedValue.BareValue;
            Interval<PlatformDate> interval = GenericClassUtil.CastBareValueAsIntervalDate(bareValue);
			if (interval != null)
			{
				DateInterval newValue = new DateInterval(interval);
				XmlNode node = (nodes == null || nodes.Count == 0 ? null : nodes[0]);
				// should always have a node
				HandleConstraints(context, xmlToModelResult, (XmlElement)node, newValue);
                //Have to create a new value since .NET won't allow re-assign of BareValue
                return createNewParsedValue((IVLImpl<QTY<PlatformDate>, Interval<PlatformDate>>)parsedValue, newValue);
			}
			return parsedValue;
		}

        private IVLImpl<QTY<DateInterval>, DateInterval> createNewParsedValue(IVLImpl<QTY<PlatformDate>, Interval<PlatformDate>> oldParsedValue, DateInterval newValue) {
            IVLImpl<QTY<DateInterval>, DateInterval> newParsedValue = new IVLImpl<QTY<DateInterval>, DateInterval>();
            newParsedValue.BareValue = newValue;
            newParsedValue.NullFlavor = oldParsedValue.NullFlavor;
            newParsedValue.Language = oldParsedValue.Language;
            newParsedValue.DisplayName = oldParsedValue.DisplayName;
            newParsedValue.Translations.AddAll(oldParsedValue.Translations);
            newParsedValue.OriginalText = oldParsedValue.OriginalText;
            newParsedValue.IsCdata = oldParsedValue.IsCdata;
            newParsedValue.Unsorted = oldParsedValue.Unsorted;
            newParsedValue.Operator = oldParsedValue.Operator;
            return newParsedValue;
        }

		private void HandleConstraints(ParseContext context, Hl7Errors errors, XmlElement element, DateInterval dateInterval)
		{
			ErrorLogger logger = new _ErrorLogger_79(errors, element);
			this.constraintsHandler.HandleConstraints(context.GetConstraints(), dateInterval, logger);
		}

		private sealed class _ErrorLogger_79 : ErrorLogger
		{
			public _ErrorLogger_79(Hl7Errors errors, XmlElement element)
			{
				this.errors = errors;
				this.element = element;
			}

			public void LogError(Hl7ErrorCode errorCode, ErrorLevel errorLevel, string errorMessage)
			{
				errors.AddHl7Error(new Hl7Error(errorCode, errorLevel, errorMessage, element));
			}

			private readonly Hl7Errors errors;

			private readonly XmlElement element;
		}
	}
}
