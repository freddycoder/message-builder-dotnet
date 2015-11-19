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
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	/// <summary>
	/// TN - TrivialName
	/// Represents an TN object as an element:
	/// &lt;element-name&gt;This is a trivial name&lt;/element-name&gt;
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-TN
	/// </summary>
	[DataTypeHandler("TN")]
	public class TnPropertyFormatter : AbstractEntityNamePropertyFormatter<TrivialName>
	{
		protected override string FormatNonNullValue(FormatContext context, TrivialName value, int indentLevel)
		{
			StringBuilder buffer = new StringBuilder();
			if (value != null)
			{
				buffer.Append(CreateElement(context, GetUseAttributeMap(value), indentLevel, false, false));
				buffer.Append(XmlStringEscape.Escape(value.Name));
				buffer.Append(CreateElementClosure(context, 0, true));
			}
			return buffer.ToString();
		}
	}
}
