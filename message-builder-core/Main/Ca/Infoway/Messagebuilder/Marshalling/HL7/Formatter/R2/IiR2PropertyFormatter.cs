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
 * Last modified: $LastChangedDate: 2011-05-04 15:47:15 -0400 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Constraints;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2
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
	internal class IiR2PropertyFormatter : AbstractAttributePropertyFormatter<Identifier>
	{
		private static readonly IiValidationUtils iiValidationUtils = new IiValidationUtils();

		private readonly IiConstraintsHandler constraintsHandler = new IiConstraintsHandler();

		protected override IDictionary<string, string> GetAttributeNameValuePairs(FormatContext context, Identifier ii, BareANY bareAny
			)
		{
			VersionNumber version = context.GetVersion();
			IDictionary<string, string> result = new Dictionary<string, string>();
			string typeFromContext = context.Type;
			ii = Validate(ii, typeFromContext, version, context);
			AddStandardAttributes(ii, result);
			return result;
		}

		private Identifier Validate(Identifier identifier, string type, VersionNumber version, FormatContext context)
		{
			// must have root or NF, not both (if has NF, will follow different path)
			// extension/assigningAuthorityName/displayable are optional
			// according to R2 schema, "root" is a "uid" and must be one of oid/uuid/ruid
			// 	 oid: "[0-2](\.(0|[1-9][0-9]*))*"
			//   uuid: "[0-9a-zA-Z]{8}-[0-9a-zA-Z]{4}-[0-9a-zA-Z]{4}-[0-9a-zA-Z]{4}-[0-9a-zA-Z]{12}"
			//   ruid: "[A-Za-z][A-Za-z0-9\-]*"
			HandleConstraints(identifier, context);
			ValidateRoot(identifier, type, context);
			return identifier;
		}

		private void HandleConstraints(Identifier identifier, FormatContext context)
		{
			ErrorLogger logger = new _ErrorLogger_93(context);
			this.constraintsHandler.HandleConstraints(context.GetConstraints(), identifier, logger, IsSingleCardinality(context.GetCardinality
				()));
		}

		private sealed class _ErrorLogger_93 : ErrorLogger
		{
			public _ErrorLogger_93(FormatContext context)
			{
				this.context = context;
			}

			public void LogError(Hl7ErrorCode errorCode, ErrorLevel errorLevel, string errorMessage)
			{
				Hl7Errors errors = context.GetModelToXmlResult();
				string propertyPath = context.GetPropertyPath();
				errors.AddHl7Error(new Hl7Error(errorCode, errorLevel, errorMessage, propertyPath));
			}

			private readonly FormatContext context;
		}

		private bool IsSingleCardinality(Cardinality cardinality)
		{
			return cardinality == null ? true : cardinality.Single;
		}

		private void ValidateRoot(Identifier ii, string type, FormatContext context)
		{
			string root = ii.Root;
			if (ValidateMandatoryAttribute("root", root, type, context))
			{
				// validate root is one of oid/uuid/ruid; this will likely be constrained to a specific type in some cases
				if (!(iiValidationUtils.IsOid(root, true) || iiValidationUtils.IsUuid(root) || iiValidationUtils.IsRuid(root)))
				{
					RecordError(iiValidationUtils.GetRootMustBeUuidRuidOidErrorMessage(root), context);
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
			if (StringUtils.IsNotBlank(ii.AssigningAuthorityName))
			{
				result["assigningAuthorityName"] = ii.AssigningAuthorityName;
			}
			if (StringUtils.IsNotBlank(ii.Displayable))
			{
				result["displayable"] = ii.Displayable;
			}
		}

		private void RecordError(string message, FormatContext context)
		{
			string propertyPath = context.GetPropertyPath();
			context.GetModelToXmlResult().AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, message, propertyPath));
		}

		private bool ValidateMandatoryAttribute(string attributeName, string attributeValue, string type, FormatContext context)
		{
			if (StringUtils.IsBlank(attributeValue))
			{
				RecordError("Attribute \"" + attributeName + "\" must be specified for " + type, context);
				return false;
			}
			return true;
		}
	}
}
