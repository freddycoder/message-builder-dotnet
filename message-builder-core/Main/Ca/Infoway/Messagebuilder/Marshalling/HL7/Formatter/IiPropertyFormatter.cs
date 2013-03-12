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
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	/// <summary>
	/// II - Installer Identifier
	/// II has two attributes: root, extension
	/// CeRx standards claim that both attributes are required, although extension
	/// is sometimes unused.
	/// </summary>
	/// <remarks>
	/// II - Installer Identifier
	/// II has two attributes: root, extension
	/// CeRx standards claim that both attributes are required, although extension
	/// is sometimes unused.
	/// The HL7 standard also defines the assigningAuthorityName attribute, but that
	/// has been left out of the CeRx implementation.
	/// According to CeRx: Root has a limit of 100 characters, extension of 20
	/// characters. These limits are not currently enforced by this class.
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-II
	/// </remarks>
	[DataTypeHandler("II")]
	internal class IiPropertyFormatter : AbstractAttributePropertyFormatter<Identifier>
	{
		private static readonly IiValidationUtils iiValidationUtils = new IiValidationUtils();

		internal override IDictionary<string, string> GetAttributeNameValuePairs(FormatContext context, Identifier ii, BareANY bareAny
			)
		{
			VersionNumber version = context.GetVersion();
			IDictionary<string, string> result = new Dictionary<string, string>();
			string typeFromContext = context.Type;
			typeFromContext = HandleSpecializationType(bareAny, context, result);
			Validate(ii, typeFromContext, version, context);
			AddStandardAttributes(ii, result);
			AddExtraAttributes(typeFromContext, version, result);
			return result;
		}

		private string HandleSpecializationType(BareANY bareAny, FormatContext context, IDictionary<string, string> result)
		{
			string typeFromContext = context.Type;
			string typeFromField = bareAny.DataType == null ? null : bareAny.DataType.Type;
			if (iiValidationUtils.IsSpecializationTypeRequired(context.GetVersion(), typeFromContext))
			{
				bool validSpecializationType = IsSpecializationTypeProvided(typeFromContext, typeFromField);
				if (iiValidationUtils.IsII(typeFromContext))
				{
					validSpecializationType &= IiValidationUtils.concreteIiTypes.Contains(typeFromField);
				}
				else
				{
					if (iiValidationUtils.IsIiBusAndVer(typeFromContext))
					{
						validSpecializationType &= iiValidationUtils.IsIiBusOrIiVer(typeFromField);
					}
				}
				// only override type if new type is valid
				if (validSpecializationType)
				{
					typeFromContext = typeFromField;
					result[AbstractPropertyFormatter.SPECIALIZATION_TYPE] = typeFromContext;
				}
				else
				{
					if (iiValidationUtils.IsIiBusAndVer(typeFromContext))
					{
						result[AbstractPropertyFormatter.SPECIALIZATION_TYPE] = IiValidationUtils.II_BUS;
						typeFromContext = IiValidationUtils.II_BUS;
						RecordError(iiValidationUtils.GetInvalidSpecializationTypeForBusAndVerErrorMessage(typeFromField, typeFromContext), context
							);
					}
					else
					{
						RecordError(iiValidationUtils.GetInvalidOrMissingSpecializationTypeErrorMessage(typeFromField), context);
					}
				}
			}
			else
			{
				if (IsSpecializationTypeProvided(typeFromContext, typeFromField))
				{
					RecordError(iiValidationUtils.GetShouldNotProvideSpecializationTypeErrorMessage(typeFromContext), context);
				}
			}
			return typeFromContext;
		}

		private bool IsSpecializationTypeProvided(string typeFromContext, string typeFromField)
		{
			// we can only infer a specializationType was provided if the field type is no longer its default value (II, in this case) and is not identical to the context type
			return typeFromField != null && !iiValidationUtils.IsII(typeFromField) && !StringUtils.Equals(typeFromContext, typeFromField
				);
		}

		private void Validate(Identifier ii, string type, VersionNumber version, FormatContext context)
		{
			ValidateMandatoryAttribute("root", ii.Root, type, context);
			if (StandardDataType.II.Type.Equals(type))
			{
				ValidateRootAndExtensionAsOidOrUuid(ii.Root, ii.Extension, type, version, context);
				ValidateUnallowedAttribute("version", ii.Version, type, context);
			}
			else
			{
				if (StandardDataType.II_PUBLIC.Type.Equals(type))
				{
					ValidateRootAsOid(ii.Root, version, context);
					ValidateExtensionForOid(ii.Extension, type, context);
					ValidateUnallowedAttribute("version", ii.Version, type, context);
				}
				else
				{
					if (StandardDataType.II_BUS.Type.Equals(type))
					{
						ValidateRootAndExtensionAsOidOrUuid(ii.Root, ii.Extension, type, version, context);
						ValidateUnallowedAttribute("version", ii.Version, type, context);
					}
					else
					{
						if (StandardDataType.II_VER.Type.Equals(type))
						{
							ValidateRootAsUuid(ii.Root, version, context);
							ValidateUnallowedAttribute("extension", ii.Extension, type, context);
							ValidateUnallowedAttribute("version", ii.Version, type, context);
						}
						else
						{
							if (StandardDataType.II_BUSVER.Type.Equals(type))
							{
								ValidateRootAndExtensionAsOidOrUuid(ii.Root, ii.Extension, type, version, context);
								ValidateMandatoryAttribute("version", ii.Version, type, context);
							}
							else
							{
								if (StandardDataType.II_PUBLICVER.Type.Equals(type))
								{
									ValidateRootAsOid(ii.Root, version, context);
									ValidateExtensionForOid(ii.Extension, type, context);
									ValidateMandatoryAttribute("version", ii.Version, type, context);
								}
								else
								{
									if (StandardDataType.II_OID.Type.Equals(type))
									{
										ValidateRootAsOid(ii.Root, version, context);
										ValidateUnallowedAttribute("extension", ii.Extension, type, context);
										ValidateUnallowedAttribute("version", ii.Version, type, context);
									}
									else
									{
										if (StandardDataType.II_TOKEN.Type.Equals(type))
										{
											ValidateRootAsUuid(ii.Root, version, context);
											ValidateUnallowedAttribute("extension", ii.Extension, type, context);
											ValidateUnallowedAttribute("version", ii.Version, type, context);
										}
									}
								}
							}
						}
					}
				}
			}
		}

		private void ValidateMandatoryAttribute(string attributeName, string attributeValue, string type, FormatContext context)
		{
			if (StringUtils.IsBlank(attributeValue))
			{
				RecordError("Attribute \"" + attributeName + "\" must be specified for " + type, context);
			}
		}

		private void ValidateUnallowedAttribute(string attributeName, string attributeValue, string type, FormatContext context)
		{
			if (StringUtils.IsNotBlank(attributeValue))
			{
				RecordError("Attribute \"" + attributeName + "\" is not allowed for " + type, context);
			}
		}

		private void ValidateRootAsUuid(string root, VersionNumber version, FormatContext context)
		{
			if (StringUtils.IsNotBlank(root))
			{
				if (!iiValidationUtils.IsUuid(root))
				{
					RecordError(iiValidationUtils.GetRootMustBeUuidErrorMessage(root), context);
				}
				ValidateRootLength(root, version, context);
			}
		}

		private void ValidateRootLength(string root, VersionNumber version, FormatContext context)
		{
			if (iiValidationUtils.IsRootLengthInvalid(root, version))
			{
				RecordError(iiValidationUtils.GetInvalidRootLengthErrorMessage(root, version), context);
			}
		}

		private void ValidateRootAsOid(string root, VersionNumber version, FormatContext context)
		{
			if (StringUtils.IsNotBlank(root))
			{
				if (!iiValidationUtils.IsOid(root))
				{
					RecordError(iiValidationUtils.GetRootMustBeAnOidErrorMessage(root), context);
				}
				ValidateRootLength(root, version, context);
			}
		}

		private void ValidateExtensionForOid(string extension, string type, FormatContext context)
		{
			// extension is mandatory in this case
			ValidateMandatoryAttribute("extension", extension, type, context);
			ValidateExtensionLength(extension, context);
		}

		private void ValidateExtensionLength(string extension, FormatContext context)
		{
			if (iiValidationUtils.IsExtensionLengthInvalid(extension))
			{
				RecordError(iiValidationUtils.GetInvalidExtensionLengthErrorMessage(extension), context);
			}
		}

		private void ValidateRootAndExtensionAsOidOrUuid(string root, string extension, string type, VersionNumber version, FormatContext
			 context)
		{
			// if root has not been provided don't bother further validating root or extension
			if (StringUtils.IsNotBlank(root))
			{
				if (!iiValidationUtils.IsUuid(root))
				{
					ValidateRootAsOid(root, version, context);
					ValidateExtensionForOid(extension, type, context);
				}
				else
				{
					ValidateRootAsUuid(root, version, context);
					ValidateUnallowedAttribute("extension", extension, type, context);
				}
			}
		}

		private void AddStandardAttributes(Identifier ii, IDictionary<string, string> result)
		{
			result["root"] = ii.Root == null ? StringUtils.EMPTY : ii.Root;
			if (StringUtils.IsNotBlank(ii.Extension))
			{
				result["extension"] = ii.Extension;
			}
			if (StringUtils.IsNotBlank(ii.Version))
			{
				result["version"] = ii.Version;
			}
		}

		private void AddExtraAttributes(string type, VersionNumber version, IDictionary<string, string> result)
		{
			if (StandardDataType.II_PUBLIC.Type.Equals(type))
			{
				if (!iiValidationUtils.IsCerxOrMr2007(version))
				{
					result["use"] = "BUS";
				}
				result["displayable"] = "true";
			}
			else
			{
				if (StandardDataType.II_BUS.Type.Equals(type))
				{
					result["use"] = "BUS";
				}
				else
				{
					if (StandardDataType.II_VER.Type.Equals(type))
					{
						result["use"] = "VER";
					}
					else
					{
						if (StandardDataType.II_BUSVER.Type.Equals(type))
						{
							result["use"] = "BUS";
						}
						else
						{
							if (StandardDataType.II_PUBLICVER.Type.Equals(type))
							{
								result["displayable"] = "true";
							}
							else
							{
								if (StandardDataType.II_OID.Type.Equals(type))
								{
									if (!iiValidationUtils.IsCerxOrMr2007(version))
									{
										result["use"] = "BUS";
									}
								}
							}
						}
					}
				}
			}
		}

		private void RecordError(string message, FormatContext context)
		{
			string propertyPath = context.GetPropertyPath();
			context.GetModelToXmlResult().AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, message, propertyPath));
		}
	}
}
