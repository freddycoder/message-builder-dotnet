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
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2;
using Ca.Infoway.Messagebuilder.Util.Text;
using ILOG.J2CsMapping.Text;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2
{
	/// <summary>
	/// EN (R2) - EntityName; also handles PN (PersonName), ON (OrganizationName), and TN (TrivialName)
	/// Represents an EN/PN/ON/TN object as an element:
	/// &lt;element-name&gt;This is a trivial name&lt;/element-name&gt;
	/// </summary>
	[DataTypeHandler(new string[] { "EN", "PN", "ON", "TN" })]
	internal class EnR2PropertyFormatter : AbstractNullFlavorPropertyFormatter<EntityName>
	{
		private readonly IvlTsR2PropertyFormatter validTimeFormatter = new IvlTsR2PropertyFormatter();

		protected override string FormatNonNullValue(FormatContext context, EntityName entityName, int indentLevel)
		{
			ValidateName(entityName, context);
			StringBuilder buffer = new StringBuilder();
			if (entityName != null)
			{
				buffer.Append(CreateElement(context, GetUseAttributeMap(entityName), indentLevel, false, true));
				IList<EntityNamePart> parts = entityName.Parts;
				for (int i = 0; i < parts.Count; i++)
				{
					AppendNamePart(buffer, parts[i], indentLevel + 1);
				}
				AppendValidTime(buffer, entityName, context, indentLevel + 1);
				buffer.Append(CreateElementClosure(context, indentLevel, true));
			}
			return buffer.ToString();
		}

		private void AppendNamePart(StringBuilder buffer, EntityNamePart namePart, int indentLevel)
		{
			string openTag = string.Empty;
			string closeTag = string.Empty;
			bool valueProvided = namePart.Value != null;
			if (namePart.Type != null)
			{
				openTag = "<" + namePart.Type.Value + AddQualifier(namePart) + AddNullFlavor(namePart) + (valueProvided ? string.Empty : 
					"/") + ">";
				closeTag = "</" + namePart.Type.Value + ">";
			}
			Indenter.IndentBuffer(buffer, indentLevel);
			buffer.Append(openTag);
			if (valueProvided)
			{
				buffer.Append(XmlStringEscape.Escape(namePart.Value));
				buffer.Append(closeTag);
			}
			buffer.Append(SystemUtils.LINE_SEPARATOR);
		}

		private void AppendValidTime(StringBuilder buffer, EntityName value, FormatContext context, int indentLevel)
		{
			Interval<PlatformDate> validTime = value.ValidTime;
			if (validTime != null)
			{
				FormatContext ivlTsContext = new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl("IVL<TS>", "validTime"
					, context);
				IVL_TSImpl ivlImpl = new IVL_TSImpl(new DateInterval(validTime));
				string formattedValidTime = this.validTimeFormatter.Format(ivlTsContext, ivlImpl, indentLevel);
				buffer.Append(formattedValidTime);
			}
		}

		private string AddQualifier(EntityNamePart namePart)
		{
			EntityNamePartQualifier qualifier = namePart.Qualifier;
			return qualifier == null || StringUtils.IsBlank(qualifier.CodeValue) ? string.Empty : " qualifier=\"" + qualifier.CodeValue
				 + "\"";
		}

		private string AddNullFlavor(EntityNamePart namePart)
		{
			NullFlavor nullFlavor = namePart.NullFlavor;
			return nullFlavor == null || StringUtils.IsBlank(nullFlavor.CodeValue) ? string.Empty : " nullFlavor=\"" + nullFlavor.CodeValue
				 + "\"";
		}

		protected virtual IDictionary<string, string> GetUseAttributeMap(EntityName value)
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

		private void ValidateName(EntityName entityName, FormatContext context)
		{
			// EN - no validations
			// PN - no validations
			// ON - part types can only be delimiter/prefix/suffix
			// TN - only one part type allowed, with no type or qualifier; no uses
			if (StringUtils.Equals("ON", context.Type))
			{
				foreach (EntityNamePart entityNamePart in entityName.Parts)
				{
					CheckPartTypeForOn(entityNamePart.Type, context);
				}
			}
			if (StringUtils.Equals("TN", context.Type))
			{
				CheckNameForTn(entityName, context);
			}
		}

		private void CheckNameForTn(EntityName entityName, FormatContext context)
		{
			int numParts = entityName.Parts.Count;
			if (numParts > 1)
			{
				// only 1 allowed
				RecordError(context, "TN values can only have one name part. Parts found: " + numParts);
			}
			if (numParts >= 1)
			{
				EntityNamePart tnPart = entityName.Parts[0];
				if (tnPart.Type != null)
				{
					// no part types allowed
					RecordError(context, "TN values can not have a name part type. Part type found: " + tnPart.Type.Value);
				}
				if (tnPart.Qualifier != null)
				{
					// no qualifier allowed
					RecordError(context, "TN values can not have any qualifiers. Qualifier found: " + tnPart.Qualifier.CodeValue);
				}
			}
			if (!entityName.Uses.IsEmpty())
			{
				// uses not allowed
				RecordError(context, "TN values can not have any uses specified. Uses found: " + entityName.Uses.ToString());
			}
		}

		private void CheckPartTypeForOn(NamePartType type, FormatContext context)
		{
			// valid types are null, delimiter, prefix, suffix
			if (type != null)
			{
				string typeValue = type.Value == null ? null : type.Value.ToUpper();
				//.NET conversion
				OrganizationNamePartType onType = EnumPattern.ValueOf<OrganizationNamePartType>(typeValue);
				if (onType == null)
				{
					RecordError(context, System.String.Format("Name parts of type {0} are not valid for ON data types. Only delimiter, prefix, suffix, and free-format text are allowed."
						, type.Value));
				}
			}
		}

		private void RecordError(FormatContext context, string errorMessage)
		{
			context.GetModelToXmlResult().AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, errorMessage, context.GetPropertyPath
				()));
		}
	}
}
