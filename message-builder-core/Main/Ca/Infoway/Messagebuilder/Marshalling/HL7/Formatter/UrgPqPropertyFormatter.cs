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
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[DataTypeHandler("URG<PQ>")]
	internal class UrgPqPropertyFormatter : AbstractNullFlavorPropertyFormatter<UncertainRange<PhysicalQuantity>>
	{
		internal IvlPqPropertyFormatter formatter = new IvlPqPropertyFormatter();

		internal override string FormatNonNullValue(FormatContext context, UncertainRange<PhysicalQuantity> value, int indentLevel
			)
		{
			// convert URG to an IVL and use IVL formatter (loses any inclusive info; we'll pull that out later)
			Interval<PhysicalQuantity> convertedInterval = IntervalFactory.CreateFromUncertainRange(value);
			IVLImpl<PQ, Interval<PhysicalQuantity>> convertedHl7Interval = new IVLImpl<PQ, Interval<PhysicalQuantity>>(convertedInterval
				);
			FormatContext ivlContext = new FormatContextImpl(context.Type.Replace("URG", "IVL"), context);
			string xml = this.formatter.Format(ivlContext, convertedHl7Interval, indentLevel);
			xml = ChangeAnyIvlRemnants(xml);
			// add in inclusive attributes if necessary
			if (value.LowInclusive != null)
			{
				xml = AddInclusiveAttribute(xml, "low", value.LowInclusive);
			}
			if (value.HighInclusive != null)
			{
				xml = AddInclusiveAttribute(xml, "high", value.HighInclusive);
			}
			return xml;
		}

		private string AddInclusiveAttribute(string xml, string elementName, Boolean? inclusive)
		{
			string searchString = "<" + elementName + " ";
			int elementIndex = xml.IndexOf(searchString);
			if (elementIndex >= 0)
			{
				string first = Ca.Infoway.Messagebuilder.StringUtils.Substring(xml, 0, elementIndex + searchString.Length);
				string last = Ca.Infoway.Messagebuilder.StringUtils.Substring(xml, elementIndex + searchString.Length);
				xml = first + "inclusive=\"" + inclusive.ToString().ToLower() + "\" " + last;
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
