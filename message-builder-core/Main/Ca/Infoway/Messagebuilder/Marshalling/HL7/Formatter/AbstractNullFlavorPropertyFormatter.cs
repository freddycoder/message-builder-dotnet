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
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Platform;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	/// <summary>If an object is null, value is replaced by a nullFlavor.</summary>
	/// <remarks>
	/// If an object is null, value is replaced by a nullFlavor. So the element would look
	/// like this:
	/// &lt;element-name nullFlavor="something" /&gt;
	/// Otherwise this class hands the formatting off to the formatNonNull method.
	/// </remarks>
	public abstract class AbstractNullFlavorPropertyFormatter<V> : AbstractPropertyFormatter
	{
		protected AbstractNullFlavorPropertyFormatter()
		{
		}

		public override string Format(FormatContext context, BareANY hl7Value, int indentLevel)
		{
			string result = string.Empty;
			if (hl7Value != null)
			{
				V value = ExtractBareValue(hl7Value);
				if (hl7Value.HasNullFlavor())
				{
					result = CreateElement(context, CreateNullFlavorAttributes(hl7Value.NullFlavor), indentLevel, true, true);
					if (context.GetConformanceLevel() == Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY)
					{
						CreateMissingMandatoryWarning(context);
					}
				}
				else
				{
					if (value == null || IsEmptyCollection(value))
					{
						if (context.GetConformanceLevel() == null || IsMandatoryOrPopulated(context))
						{
							if (context.GetConformanceLevel() == Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY)
							{
								result = CreateElement(context, AbstractPropertyFormatter.EMPTY_ATTRIBUTE_MAP, indentLevel, true, true);
								CreateMissingMandatoryWarning(context);
							}
							else
							{
								result = CreateElement(context, AbstractPropertyFormatter.NULL_FLAVOR_ATTRIBUTES, indentLevel, true, true);
							}
						}
					}
					else
					{
						result = FormatNonNullDataType(context, hl7Value, indentLevel);
					}
				}
			}
			return result;
		}

		protected virtual V ExtractBareValue(BareANY hl7Value)
		{
			return (V)hl7Value.BareValue;
		}

		internal virtual string FormatNonNullDataType(FormatContext context, BareANY dataType, int indentLevel)
		{
			return FormatNonNullValue(context, ExtractBareValue(dataType), indentLevel);
		}

		internal abstract string FormatNonNullValue(FormatContext context, V t, int indentLevel);

		protected virtual bool IsEmptyCollection(V value)
		{
			if (ListElementUtil.IsCollection(value))
			{
				return ListElementUtil.IsEmpty(value);
			}
			return false;
		}

		protected virtual IDictionary<string, string> CreateNullFlavorAttributes(NullFlavor nullFlavor)
		{
			Dictionary<string, string> attributes = new Dictionary<string, string>();
			attributes[AbstractPropertyFormatter.NULL_FLAVOR_ATTRIBUTE_NAME] = nullFlavor.CodeValue;
			return attributes;
		}

		protected virtual void CreateMissingMandatoryWarning(FormatContext context)
		{
			context.GetModelToXmlResult().AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, context.GetElementName() + " is a mandatory field, but no value is specified"
				, context.GetPropertyPath()));
		}

		protected virtual bool IsMandatoryOrPopulated(FormatContext context)
		{
			Ca.Infoway.Messagebuilder.Xml.ConformanceLevel level = context.GetConformanceLevel();
			return level == Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY || level == Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.POPULATED;
		}

		protected virtual IDictionary<string, string> ToStringMap(params string[] @string)
		{
			IDictionary<string, string> result = new Dictionary<string, string>();
			int length = @string == null ? 0 : @string.Length;
			for (int i = 0; i < length - 1; i += 2)
			{
				if (@string[i] != null && @string[i + 1] != null)
				{
					result[@string[i]] = @string[i + 1];
				}
			}
			return result;
		}
	}
}
