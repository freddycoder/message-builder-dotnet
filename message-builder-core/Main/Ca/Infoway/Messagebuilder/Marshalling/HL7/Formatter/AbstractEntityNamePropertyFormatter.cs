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
using System.Text;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	/// <summary>This is shared by all subclasses of EntityName.</summary>
	/// <remarks>This is shared by all subclasses of EntityName.</remarks>
	public abstract class AbstractEntityNamePropertyFormatter<V> : AbstractNullFlavorPropertyFormatter<V> where V : EntityName
	{
		protected override string FormatNonNullValue(FormatContext context, V value, int indentLevel)
		{
			ValidateName(value, context);
			StringBuilder buffer = new StringBuilder();
			if (value != null)
			{
				buffer.Append(CreateElement(context, GetUseAttributeMap(value), indentLevel, false, false));
				foreach (EntityNamePart namePart in value.Parts)
				{
					AppendNamePart(buffer, namePart);
				}
				buffer.Append(CreateElementClosure(context, 0, true));
			}
			return buffer.ToString();
		}

		protected virtual void ValidateName(V value, FormatContext context)
		{
		}

		// leave this up to subclasses to decide if they want to do any validations
		private void AppendNamePart(StringBuilder buffer, EntityNamePart namePart)
		{
			string openTag = string.Empty;
			string closeTag = string.Empty;
			if (namePart.Type != null)
			{
				openTag = "<" + namePart.Type.Value + AddQualifier(namePart) + ">";
				closeTag = "</" + namePart.Type.Value + ">";
			}
			buffer.Append(openTag);
			buffer.Append(XmlStringEscape.Escape(namePart.Value));
			buffer.Append(closeTag);
		}

		private string AddQualifier(EntityNamePart namePart)
		{
			EntityNamePartQualifier qualifier = namePart.Qualifier;
			return qualifier == null || StringUtils.IsBlank(qualifier.CodeValue) ? string.Empty : " qualifier=\"" + qualifier.CodeValue
				 + "\"";
		}

		protected virtual IDictionary<string, string> GetUseAttributeMap(V value)
		{
			string uses = string.Empty;
			foreach (Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse entityNameUse in value.Uses)
			{
				uses += uses.Length == 0 ? string.Empty : " ";
				uses += entityNameUse.CodeValue;
			}
			IDictionary<string, string> result = new Dictionary<string, string>();
			if (uses.Length > 0)
			{
				result["use"] = uses;
			}
			return result;
		}
	}
}
