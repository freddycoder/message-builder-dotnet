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
using System.Collections.Generic;
using System.Text;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Util.Iterator;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	public abstract class BaseCollectionPropertyFormatter : AbstractNullFlavorPropertyFormatter<ICollection<BareANY>>
	{
		protected virtual FormatContext CreateSubContext(FormatContext context)
		{
			return new FormatContextImpl(context.GetModelToXmlResult(), context.GetPropertyPath(), context.GetElementName(), GetSubType
				(context), context.GetDomainType(), context.GetConformanceLevel(), context.IsSpecializationType(), context.GetVersion(), 
				context.GetDateTimeZone(), context.GetDateTimeTimeZone(), true, null);
		}

		protected override ICollection<BareANY> ExtractBareValue(BareANY hl7Value)
		{
			BareCollection collection = (BareCollection)hl7Value;
			return collection.GetBareCollectionValue();
		}

		protected virtual string FormatAllElements(FormatContext subContext, ICollection<BareANY> collection, int indentLevel)
		{
			StringBuilder builder = new StringBuilder();
			PropertyFormatter formatter = FormatterRegistry.GetInstance().Get(subContext.Type);
			if (collection.IsEmpty())
			{
				builder.Append(formatter.Format(subContext, null, indentLevel));
			}
			else
			{
				foreach (BareANY element in EmptyIterable<object>.NullSafeIterable<BareANY>(collection))
				{
					// FIXME - SPECIALIZATION_TYPE - compare "element" type with subcontext datatype - if different, need to re-build a subcontext
					builder.Append(formatter.Format(subContext, (BareANY)element, indentLevel));
				}
			}
			return builder.ToString();
		}

		/// <summary>
		/// We expect the type to look something like this:
		/// 
		/// SET&lt;II&gt;
		/// 
		/// and we want to return "II"
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		/// <exception cref="ModelToXmlTransformationException"></exception>
		private string GetSubType(FormatContext context)
		{
			string subType = Hl7DataTypeName.GetParameterizedType(context.Type);
			if (StringUtils.IsNotBlank(subType))
			{
				return subType;
			}
			else
			{
				throw new ModelToXmlTransformationException("Cannot find the sub type for " + context.Type);
			}
		}
	}
}
