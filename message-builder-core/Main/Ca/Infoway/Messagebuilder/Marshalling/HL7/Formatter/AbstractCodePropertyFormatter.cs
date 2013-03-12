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
using System.Collections.Generic;
using System.Text;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Terminology;
using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	/// <summary>
	/// CS - Coded Simple
	/// Formats a enum into a CS element.
	/// </summary>
	/// <remarks>
	/// CS - Coded Simple
	/// Formats a enum into a CS element. The element looks like this:
	/// &lt;element-name code="RECENT"/&gt;
	/// According to CeRx: code has a limit of 20 characters. This limit is not
	/// currently enforced by this class.
	/// HL7 implies that variations on this type may use a different name than "code" for
	/// the attribute. The use in the controlActProcess is given as an example.
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-CS
	/// </remarks>
	internal abstract class AbstractCodePropertyFormatter : AbstractAttributePropertyFormatter<Code>
	{
		private static readonly CdValidationUtils CD_VALIDATION_UTILS = new CdValidationUtils();

		public override string Format(FormatContext context, BareANY hl7Value, int indentLevel)
		{
			CD cd = (CD)hl7Value;
			StringBuilder result = new StringBuilder();
			if (cd != null)
			{
				// don't bother validating if we don't have anything to validate
				if (cd.HasNullFlavor() || HasValue(cd, context))
				{
					Hl7Errors errors = context.GetModelToXmlResult();
					Hl7BaseVersion baseVersion = context.GetVersion().GetBaseVersion();
					string type = context.Type;
					bool isCne = context.GetCodingStrength() == CodingStrength.CNE;
					bool isCwe = context.GetCodingStrength() == CodingStrength.CWE;
					if (cd.Value != null && cd.Value.CodeValue != null)
					{
						ValidateCodeExists(cd.Value, context.GetDomainType(), context.GetVersion(), context.GetPropertyPath(), errors);
					}
					string codeAsString = (cd.Value != null ? cd.Value.CodeValue : null);
					CD_VALIDATION_UTILS.ValidateCodedType(cd, codeAsString, isCwe, isCne, false, type, baseVersion, null, context.GetPropertyPath
						(), errors);
				}
				IDictionary<string, string> attributes = new Dictionary<string, string>();
				if (cd.HasNullFlavor())
				{
					if (context.GetConformanceLevel() == Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY)
					{
						LogMandatoryError(context);
					}
					else
					{
						attributes.PutAll(CreateNullFlavorAttributes(hl7Value.NullFlavor));
					}
				}
				else
				{
					if (!HasValue(cd, context))
					{
						if (context.GetConformanceLevel() == null || IsMandatoryOrPopulated(context))
						{
							if (context.GetConformanceLevel() == Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY)
							{
								LogMandatoryError(context);
							}
							else
							{
								attributes.PutAll(AbstractPropertyFormatter.NULL_FLAVOR_ATTRIBUTES);
							}
						}
					}
				}
				// Codes can have other attributes in map even if has NullFlavor
				attributes.PutAll(GetAttributeNameValuePairs(context, cd.Value, hl7Value));
				bool hasChildContent = HasChildContent(cd, context);
				if (hasChildContent || (!attributes.IsEmpty() || context.GetConformanceLevel() == Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
					.MANDATORY))
				{
					result.Append(CreateElement(context, attributes, indentLevel, !hasChildContent, !hasChildContent));
					if (hasChildContent)
					{
						CreateChildContent(cd, result);
						result.Append("</").Append(context.GetElementName()).Append(">");
						result.Append(SystemUtils.LINE_SEPARATOR);
					}
				}
			}
			return result.ToString();
		}

		private void ValidateCodeExists(Code value, string domainType, VersionNumber version, string propertyPath, Hl7Errors errors
			)
		{
			Type returnType = (Type)DomainTypeHelper.GetReturnType(domainType, version);
			if (returnType == null)
			{
				errors.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "Could not locate a registered domain type to match \"" + domainType
					 + "\"", propertyPath));
			}
			else
			{
				if (GetCode(returnType, value.CodeValue, value.CodeSystem) == null)
				{
					errors.AddHl7Error(CreateCodeValueNotFoundError(value, returnType, propertyPath));
				}
			}
		}

		protected virtual Hl7Error CreateCodeValueNotFoundError(Code value, Type type, string propertyPath)
		{
			string message = "The code, \"" + value.CodeValue + "\" " + (value.CodeSystem == null ? string.Empty : (" (" + value.CodeSystem
				 + ") ")) + "is not a valid value for domain type \"" + ClassUtils.GetShortClassName(type) + "\"";
			return new Hl7Error(Hl7ErrorCode.VALUE_NOT_IN_CODE_SYSTEM, message, propertyPath);
		}

		private Code GetCode(Type returnType, string codeValue, string codeSystem)
		{
			CodeResolver resolver = CodeResolverRegistry.GetResolver(returnType);
			return codeSystem == null ? resolver.Lookup<Code>(returnType, codeValue) : resolver.Lookup<Code>(returnType, codeValue, codeSystem
				);
		}

		private void LogMandatoryError(FormatContext context)
		{
			string errorMessage = context.GetElementName() + " is a mandatory field, but no value is specified";
			context.GetModelToXmlResult().AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, errorMessage, context.GetPropertyPath
				()));
		}

		protected virtual bool HasChildContent(CD cd, FormatContext context)
		{
			return HasOriginalText(cd);
		}

		protected virtual void CreateChildContent(CD cd, StringBuilder result)
		{
			if (HasOriginalText(cd))
			{
				result.Append(CreateElement("originalText", null, 0, false, false));
				result.Append(XmlStringEscape.Escape(cd.OriginalText));
				result.Append("</").Append("originalText").Append(">");
			}
		}

		protected virtual bool HasValue(CD cd, FormatContext context)
		{
			return cd != null && (cd.Value != null || HasChildContent(cd, context));
		}

		private bool HasOriginalText(CD cd)
		{
			return !StringUtils.IsEmpty(cd.OriginalText);
		}

		internal override IDictionary<string, string> GetAttributeNameValuePairs(FormatContext context, Code code, BareANY bareAny
			)
		{
			IDictionary<string, string> result = new Dictionary<string, string>();
			if (code != null)
			{
				string value = code.CodeValue;
				if (StringUtils.IsNotBlank(value))
				{
					result["code"] = value;
				}
			}
			return result;
		}
	}
}
