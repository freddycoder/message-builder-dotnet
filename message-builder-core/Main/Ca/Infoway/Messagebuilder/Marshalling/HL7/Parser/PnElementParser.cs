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
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Resolver;
using Ca.Infoway.Messagebuilder.Util.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	/// <summary>
	/// PN - Personal Name
	/// Parses a PN element into a PersonName.
	/// </summary>
	/// <remarks>
	/// PN - Personal Name
	/// Parses a PN element into a PersonName. The element looks like this:
	/// 
	/// Mr.
	/// John
	/// Jimmy
	/// Smith
	/// Sr.
	/// 
	/// If an object is null, value is replaced by a nullFlavor. So the element would look
	/// like this:
	/// 
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-PN
	/// </remarks>
	[DataTypeHandler(new string[] { "PN", "PN.BASIC", "PN.FULL", "PN.SEARCH", "PN.SIMPLE" })]
	internal class PnElementParser : AbstractEntityNameElementParser
	{
		private static readonly string NAME_PART_TYPE_QUALIFIER = "qualifier";

		private static readonly PnValidationUtils PN_VALIDATION_UTILS = new PnValidationUtils();

		protected override BareANY DoCreateDataTypeInstance(string typeName)
		{
			return new PNImpl();
		}

		protected override void ValidateName(EntityName result, ParseContext context, XmlElement element, Hl7Errors errors)
		{
			string personNameType = context.Type;
			// some jurisdictions make use of PN, even though it is not strictly defined (allowed?) in the datatype specifications
			if ("PN".Equals(personNameType))
			{
				string specializationType = GetSpecializationType(element);
				if (StringUtils.IsNotBlank(specializationType))
				{
					personNameType = specializationType;
				}
			}
			PN_VALIDATION_UTILS.ValidatePersonName((PersonName)result, personNameType, context.GetVersion().GetBaseVersion(), element
				, null, errors);
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		protected override EntityName ParseNode(XmlNode node, XmlToModelResult xmlToModelResult)
		{
			PersonName result = new PersonName();
			HandlePersonName(xmlToModelResult, result, node.ChildNodes);
			return result;
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		private void HandlePersonName(XmlToModelResult xmlToModelResult, PersonName result, XmlNodeList childNodes)
		{
			foreach (XmlNode childNode in new XmlNodeListIterable(childNodes))
			{
				if (childNode is XmlElement)
				{
					XmlElement element = (XmlElement)childNode;
					string name = NodeUtil.GetLocalOrTagName(element);
					string value = GetTextValue(element, xmlToModelResult);
					string qualifierString = GetAttributeValue(element, NAME_PART_TYPE_QUALIFIER);
					EntityNamePartQualifier qualifier = CodeResolverRegistry.Lookup<EntityNamePartQualifier>(qualifierString);
					if (StringUtils.IsNotBlank(value))
					{
						result.AddNamePart(new EntityNamePart(value, GetPersonalNamePartType(name), qualifier));
					}
				}
				else
				{
					//GN: Added in fix similar to what was done for AD.BASIC.  Issue with XML containing mixture of elements and untyped text nodes.
					if (IsNonBlankTextNode(childNode))
					{
						// validation will catch if this type does not allow for a free-form name
						result.AddNamePart(new EntityNamePart(childNode.Value.Trim(), null));
					}
				}
			}
		}

		private bool IsNonBlankTextNode(XmlNode childNode)
		{
			return childNode.Value != null && childNode.NodeType == System.Xml.XmlNodeType.Text && !StringUtils.IsBlank(childNode.Value
				);
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		private string GetTextValue(XmlElement element, XmlToModelResult xmlToModelResult)
		{
			string result = NodeUtil.GetTextValue(element, true);
			if (StringUtils.IsBlank(result))
			{
				xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "Expected PN child node \"" + element.Name + "\" to have a text node"
					, element));
			}
			return result;
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		private NamePartType GetPersonalNamePartType(string value)
		{
			return GetNamePartType<PersonNamePartType>(value);
		}
	}
}
