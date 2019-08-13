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


using System;
using System.Collections.Generic;
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
using Ca.Infoway.Messagebuilder.Platform;
using Ca.Infoway.Messagebuilder.Resolver;
using Ca.Infoway.Messagebuilder.Util.Xml;
using ILOG.J2CsMapping.Util;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	/// <summary>
	/// AD - Address
	/// Parses a AD element into an Address.
	/// </summary>
	/// <remarks>
	/// AD - Address
	/// Parses a AD element into an Address. The element looks like this:
	/// 
	/// 1050
	/// W
	/// Wishard Blvd,
	/// RG 5th floor,
	/// Indianapolis, IN
	/// 46240
	/// 
	/// If an object is null, value is replaced by a nullFlavor. So the element would look
	/// like this:
	/// 
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-AD
	/// </remarks>
	[DataTypeHandler(new string[] { "AD", "AD.BASIC", "AD.FULL", "AD.SEARCH" })]
	internal class AdElementParser : AbstractSingleElementParser<PostalAddress>
	{
		private static readonly AdValidationUtils AD_VALIDATION_UTILS = new AdValidationUtils();

		protected override BareANY DoCreateDataTypeInstance(string typeName)
		{
			return new ADImpl();
		}

		protected override PostalAddress ParseNonNullNode(ParseContext context, XmlNode node, BareANY parseResult, Type expectedReturnType
			, XmlToModelResult xmlToModelResult)
		{
			PostalAddress result = ParseNode(node, xmlToModelResult);
			result.Uses = GetNameUses(GetAttributeValue(node, "use"), node, xmlToModelResult);
			// TODO - TM - missing useablePeriod (only for MR2009 AD.FULL)
			AD_VALIDATION_UTILS.ValidatePostalAddress(result, context.Type, context.GetVersion(), (XmlElement)node, null, xmlToModelResult
				);
			return result;
		}

		private ICollection<Ca.Infoway.Messagebuilder.Domainvalue.PostalAddressUse> GetNameUses(string nameUseAttribute, XmlNode 
			node, XmlToModelResult xmlToModelResult)
		{
			ICollection<Ca.Infoway.Messagebuilder.Domainvalue.PostalAddressUse> uses = CollUtils.SynchronizedSet(new LinkedSet<Ca.Infoway.Messagebuilder.Domainvalue.PostalAddressUse
                >());
			if (nameUseAttribute != null)
			{
				StringTokenizer tokenizer = new StringTokenizer(nameUseAttribute);
				while (tokenizer.HasMoreElements())
				{
					string token = tokenizer.NextToken();
					x_BasicPostalAddressUse postalAddressUse = CodeResolverRegistry.Lookup<x_BasicPostalAddressUse>(token);
					if (postalAddressUse == null)
					{
						// error if a use is not found
						RecordError("PostalAddressUse '" + token + "' is not valid", (XmlElement)node, xmlToModelResult);
					}
					else
					{
						uses.Add(postalAddressUse);
					}
				}
			}
			return uses;
		}

		private PostalAddress ParseNode(XmlNode node, XmlToModelResult xmlToModelResult)
		{
			PostalAddress result = new PostalAddress();
			XmlNodeList childNodes = node.ChildNodes;
			foreach (XmlNode childNode in new XmlNodeListIterable(childNodes))
			{
				if (IsNonBlankTextNode(childNode))
				{
					string value = childNode.Value;
					result.AddPostalAddressPart(new PostalAddressPart(value));
				}
				else
				{
					if (childNode is XmlElement)
					{
						XmlElement element = (XmlElement)childNode;
						string name = NodeUtil.GetLocalOrTagName(element);
						PostalAddressPartType postalAddressPartType = GetPostalAddressPartType(name);
						string value = GetTextValue(name, element, xmlToModelResult);
						string codeAsString = GetAttributeValue(childNode, "code");
						// only for state/country
						string codeSystem = GetAttributeValue(childNode, "codeSystem");
						// only for state/country
						Code code = CodeUtil.ConvertToCode(codeAsString, codeSystem);
						if (postalAddressPartType == null)
						{
							// error if part type not found
							RecordError("Address part type not valid: " + name, element, xmlToModelResult);
						}
						else
						{
							result.AddPostalAddressPart(new PostalAddressPart(postalAddressPartType, code, value));
						}
					}
				}
			}
			return result;
		}

		private bool IsNonBlankTextNode(XmlNode childNode)
		{
			return childNode.NodeType == System.Xml.XmlNodeType.Text && !StringUtils.IsBlank(childNode.Value);
		}

		private PostalAddressPartType GetPostalAddressPartType(string type)
		{
			// don't allow exception (seems like overkill)!
			try
			{
				return GetNamePartType<PostalAddressPartType>(type);
			}
			catch (XmlToModelTransformationException)
			{
				return null;
			}
		}

		private string GetTextValue(string name, XmlElement element, XmlToModelResult xmlToModelResult)
		{
			XmlNode childNode = element.FirstChild;
			string result = null;
			if (childNode != null)
			{
				if (childNode.NodeType != System.Xml.XmlNodeType.Text)
				{
					RecordError("Expected AD child node '" + name + "' to have a text node", element, xmlToModelResult);
				}
				else
				{
					result = childNode.Value;
				}
			}
			return result;
		}

		private void RecordError(string message, XmlElement element, XmlToModelResult xmlToModelResult)
		{
			xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, message + " (" + XmlDescriber.DescribeSingleElement
				(element) + ")", element));
		}
	}
}
