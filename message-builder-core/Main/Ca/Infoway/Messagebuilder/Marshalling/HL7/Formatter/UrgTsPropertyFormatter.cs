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


using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[DataTypeHandler("URG<TS>")]
	internal class UrgTsPropertyFormatter : AbstractNullFlavorPropertyFormatter<UncertainRange<PlatformDate>>
	{
		internal IvlTsPropertyFormatter formatter = new IvlTsPropertyFormatter();

		protected override string FormatNonNullValue(FormatContext context, UncertainRange<PlatformDate> value, int indentLevel)
		{
			// convert URG to an IVL and use IVL formatter
			Interval<PlatformDate> convertedInterval = IntervalFactory.CreateFromUncertainRange(value);
			IVLImpl<TS, Interval<PlatformDate>> convertedHl7Interval = new IVLImpl<TS, Interval<PlatformDate>>(convertedInterval);
			FormatContext ivlContext = new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(context.Type.Replace
				("URG", "IVL"), context.IsSpecializationType(), context);
			string xml = this.formatter.Format(ivlContext, convertedHl7Interval, indentLevel);
			xml = ChangeAnyIvlRemnants(xml);
			// inclusive attributes not allowed for URG<TS>
			if (value.LowInclusive != null || value.HighInclusive != null)
			{
				context.GetModelToXmlResult().AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "High/Low inclusive fields should not be set; these attributes are not allowed for "
					 + context.Type + " types", context.GetPropertyPath()));
			}
			return xml;
		}

		private string ChangeAnyIvlRemnants(string xml)
		{
			xml = xml.Replace(" specializationType=\"IVL_", " specializationType=\"URG_");
			return xml.Replace(" xsi:type=\"IVL_", " xsi:type=\"URG_");
		}
	}
}
