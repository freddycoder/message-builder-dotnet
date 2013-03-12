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
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using ILOG.J2CsMapping.Text;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	/// <summary>
	/// TS.FULLDATEWITHTIME - Abstract TS - must be one of TS.FULLDATE or TS.FULLDATETIME
	/// Represents a TS.FULLDATETIME/TS.DATETIME object as an element:
	/// If an object is null, value is replaced by a nullFlavor.
	/// </summary>
	/// <remarks>
	/// TS.FULLDATEWITHTIME - Abstract TS - must be one of TS.FULLDATE or TS.FULLDATETIME
	/// Represents a TS.FULLDATETIME/TS.DATETIME object as an element:
	/// If an object is null, value is replaced by a nullFlavor. So the element would look
	/// like this:
	/// &lt;element-name nullFlavor="something" /&gt;
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-TS
	/// </remarks>
	[DataTypeHandler(new string[] { "TS.FULLDATEWITHTIME" })]
	public class TsFullDateWithTimePropertyFormatter : AbstractPropertyFormatter
	{
		private static readonly PropertyFormatter fullDateFormatter = new TsFullDatePropertyFormatter();

		private static readonly PropertyFormatter fullDateTimeFormatter = new TsFullDateTimePropertyFormatter();

		public override string Format(FormatContext context, BareANY hl7Value, int indentLevel)
		{
			StandardDataType specializationType = hl7Value.DataType;
			ValidateSpecializationType(specializationType, context);
			PropertyFormatter formatter = fullDateTimeFormatter;
			string formatterSpecializationType = StandardDataType.TS_FULLDATETIME.Type;
			if (StandardDataType.TS_FULLDATE == specializationType)
			{
				formatter = fullDateFormatter;
				formatterSpecializationType = StandardDataType.TS_FULLDATE.Type;
			}
			return formatter.Format(new FormatContextImpl(context.GetModelToXmlResult(), context.GetPropertyPath(), context.GetElementName
				(), formatterSpecializationType, context.GetConformanceLevel(), true, context.GetVersion(), context.GetDateTimeZone(), context
				.GetDateTimeTimeZone(), null), hl7Value, indentLevel);
		}

		private void ValidateSpecializationType(StandardDataType specializationType, FormatContext context)
		{
			if (specializationType == StandardDataType.TS)
			{
				context.GetModelToXmlResult().AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, System.String.Format("No specializationType provided. Value should be TS.FULLDATE or TS.FULLDATETIME. TS.FULLDATETIME will be assumed."
					, specializationType.Type), context.GetPropertyPath()));
			}
			else
			{
				if (specializationType != StandardDataType.TS_FULLDATE && specializationType != StandardDataType.TS_FULLDATETIME)
				{
					context.GetModelToXmlResult().AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, System.String.Format("Invalid specializationType: {0}. Value should be TS.FULLDATE or TS.FULLDATETIME. TS.FULLDATETIME will be assumed."
						, specializationType.Type), context.GetPropertyPath()));
				}
			}
		}
	}
}
