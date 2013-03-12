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
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Util.Xml;
using Ca.Infoway.Messagebuilder.Xml.Util;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	public abstract class AbstractPropertyFormatter : PropertyFormatter
	{
		private static readonly XmlWarningRenderer warningRenderer = new XmlWarningRenderer();

		internal static readonly IDictionary<string, string> EMPTY_ATTRIBUTE_MAP = new Dictionary<string, string>();

		internal static readonly string NULL_FLAVOR_ATTRIBUTE_NAME = "nullFlavor";

		internal static readonly string NULL_FLAVOR_NO_INFORMATION = Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.
			NO_INFORMATION.CodeValue;

		internal static readonly IDictionary<string, string> NULL_FLAVOR_ATTRIBUTES = new Dictionary<string, string>();

		static AbstractPropertyFormatter()
		{
			NULL_FLAVOR_ATTRIBUTES[NULL_FLAVOR_ATTRIBUTE_NAME] = NULL_FLAVOR_NO_INFORMATION;
		}

		protected virtual string CreateWarning(int indentLevel, string text)
		{
			return warningRenderer.CreateWarning(indentLevel, text);
		}

		public virtual string Format(FormatContext formatContext, BareANY dataType)
		{
			return Format(formatContext, dataType, 0);
		}

		public abstract string Format(FormatContext formatContext, BareANY dataType, int indentLevel);

		protected virtual string CreateElement(FormatContext context, IDictionary<string, string> attributes, int indentLevel, bool
			 close, bool lineBreak)
		{
			if (!IsNullFlavor(attributes))
			{
				if (attributes == null)
				{
					attributes = new Dictionary<string, string>();
				}
				IDictionary<string, string> extraAttributes = CreateSpecializationTypeAttibutesIfNecessary(context);
				// bug 13884 - csharp throws exception if put duplicate key in map; this was occurring when using putAll() instead of below code
				foreach (string key in extraAttributes.Keys)
				{
					attributes.Remove(key);
					attributes[key] = extraAttributes.SafeGet(key);
				}
			}
			return CreateElement(context.GetElementName(), attributes, indentLevel, close, lineBreak);
		}

		protected virtual string CreateElement(string name, IDictionary<string, string> attributes, int indentLevel, bool close, 
			bool lineBreak)
		{
			return XmlRenderingUtils.CreateStartElement(name, attributes, indentLevel, close, lineBreak);
		}

		protected virtual string CreateElementClosure(FormatContext context, int indentLevel, bool lineBreak)
		{
			return XmlRenderingUtils.CreateEndElement(context.GetElementName(), indentLevel, lineBreak);
		}

		protected virtual IDictionary<string, string> CreateSpecializationTypeAttibutesIfNecessary(FormatContext context)
		{
			IDictionary<string, string> attributes = new Dictionary<string, string>();
			if (context.IsSpecializationType())
			{
				string typeAsString = context.Type;
				AddSpecializationType(attributes, typeAsString);
			}
			return attributes;
		}

		protected virtual void AddSpecializationType(IDictionary<string, string> attributes, string typeAsString)
		{
			StandardDataType type = StandardDataType.GetByTypeName(typeAsString);
			attributes["xsi:type"] = Xmlify(type.TypeName.UnspecializedName);
			attributes["specializationType"] = Xmlify(type.Type);
		}

		protected virtual bool IsNullFlavor(IDictionary<string, string> attributes)
		{
			return attributes != null && attributes.ContainsKey(NULL_FLAVOR_ATTRIBUTE_NAME);
		}

		public virtual string Xmlify(string type)
		{
			string typeForXml = System.Text.RegularExpressions.Regex.Replace(type, "\\>", string.Empty);
			typeForXml = System.Text.RegularExpressions.Regex.Replace(typeForXml, "\\<", "_");
			return typeForXml;
		}
	}
}
