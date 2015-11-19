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
using System.Text;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2
{
	/// <summary>Event-related periodic interval of time</summary>
	[DataTypeHandler("EIVL<TS>")]
	public class EivlTsR2PropertyFormatter : AbstractNullFlavorPropertyFormatter<EventRelatedPeriodicIntervalTime>
	{
		private readonly CeR2PropertyFormatter ceR2PropertyFormatter = new CeR2PropertyFormatter();

		private readonly IvlPqR2PropertyFormatter ivlPqR2PropertyFormatter = new IvlPqR2PropertyFormatter();

		protected override string FormatNonNullValue(FormatContext context, EventRelatedPeriodicIntervalTime value, int indentLevel
			)
		{
			StringBuilder buffer = new StringBuilder();
			if (value != null && !value.IsEmpty())
			{
				buffer.Append(CreateElement(context, null, indentLevel, false, true));
				buffer.Append(HandleEvent(value, context, indentLevel + 1));
				buffer.Append(HandleOffset(value, context, indentLevel + 1));
				buffer.Append(CreateElementClosure(context, indentLevel, true));
			}
			return buffer.ToString();
		}

		private string HandleOffset(EventRelatedPeriodicIntervalTime value, FormatContext context, int indentLevel)
		{
			string result = string.Empty;
			if (value.Offset != null)
			{
				FormatContext newContext = new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl("IVL<PQ>", "offset", 
					context);
				IVL<QTY<PhysicalQuantity>, Interval<PhysicalQuantity>> ivlAny = new IVLImpl<QTY<PhysicalQuantity>, Interval<PhysicalQuantity
					>>();
				ivlAny.Value = value.Offset;
				result = this.ivlPqR2PropertyFormatter.Format(newContext, ivlAny, indentLevel);
			}
			return result;
		}

		private string HandleEvent(EventRelatedPeriodicIntervalTime value, FormatContext context, int indentLevel)
		{
			string result = string.Empty;
			if (value.Event != null)
			{
				FormatContext newContext = new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl("CE", "event", context
					);
				CodedTypeR2<Code> codedType = new CodedTypeR2<Code>();
				//Fixup for .NET
				codedType.Code = value.Event;
				codedType.CodeSystemName = "TimingEvent";
				CE_R2<Code> ceAny = new CE_R2Impl<Code>(codedType);
				result = this.ceR2PropertyFormatter.Format(newContext, ceAny, indentLevel);
			}
			return result;
		}
	}
}
