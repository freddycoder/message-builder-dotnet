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
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2;
using Ca.Infoway.Messagebuilder.Resolver;
using Ca.Infoway.Messagebuilder.Util.Xml;
using ILOG.J2CsMapping.Text;
using ILOG.J2CsMapping.Util;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2
{
	/// <summary>
	/// AD - Address (R2)
	/// Parses a AD element into an Address.
	/// </summary>
	/// <remarks>
	/// AD - Address (R2)
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
	[DataTypeHandler("AD")]
	internal class AdR2ElementParser : AbstractSingleElementParser<PostalAddress>
	{
		private readonly TsR2ElementParser tsParser = new TsR2ElementParser();

		protected override BareANY DoCreateDataTypeInstance(string typeName)
		{
			return new ADImpl();
		}

		protected override PostalAddress ParseNonNullNode(ParseContext context, XmlNode node, BareANY parseResult, Type expectedReturnType
			, XmlToModelResult xmlToModelResult)
		{
			PostalAddress address = ParseAddressPartTypes(node, xmlToModelResult);
			IDictionary<PlatformDate, SetOperator> useablePeriods = ParseUseablePeriods((XmlElement)node, context, xmlToModelResult);
			ICollection<Ca.Infoway.Messagebuilder.Domainvalue.PostalAddressUse> uses = ParseAddressUses(GetAttributeValue(node, "use"
				), node, xmlToModelResult);
			Boolean? isNotOrdered = ParseIsNotOrdered((XmlElement)node);
			address.UseablePeriods.PutAll(useablePeriods);
			address.Uses = uses;
			address.IsNotOrdered = isNotOrdered;
			return address;
		}

		private IDictionary<PlatformDate, SetOperator> ParseUseablePeriods(XmlElement node, ParseContext context, XmlToModelResult
			 xmlToModelResult)
		{
			IDictionary<PlatformDate, SetOperator> useablePeriods = new Dictionary<PlatformDate, SetOperator>();
			XmlNodeList childNodes = node.ChildNodes;
			bool foundUseablePeriod = false;
			bool loggedUseablePeriodError = false;
			foreach (XmlNode childNode in new XmlNodeListIterable(childNodes))
			{
				string childElementName = NodeUtil.GetLocalOrTagName(childNode);
				bool isUseablePeriod = "useablePeriod".Equals(childElementName);
				if (foundUseablePeriod && !isUseablePeriod && !loggedUseablePeriodError)
				{
					loggedUseablePeriodError = true;
					RecordError("Useable periods must come after all address part types.", (XmlElement)node, xmlToModelResult);
				}
				if (childNode is XmlElement)
				{
					XmlElement childElement = (XmlElement)childNode;
					if (isUseablePeriod)
					{
						foundUseablePeriod = true;
						ParseContext newContext = ParseContextImpl.Create("SXCM<TS>", context);
						BareANY tsAny = this.tsParser.Parse(newContext, childElement, xmlToModelResult);
						if (tsAny != null && tsAny.BareValue != null)
						{
							SetOperator @operator = ((ANYMetaData)tsAny).Operator;
							MbDate ts = (MbDate)tsAny.BareValue;
							useablePeriods[ts.Value] = @operator;
						}
					}
				}
			}
			return useablePeriods;
		}

		private Boolean? ParseIsNotOrdered(XmlElement element)
		{
			Boolean? isNotOrdered = null;
			if (element.HasAttribute("isNotOrdered"))
			{
				isNotOrdered = Ca.Infoway.Messagebuilder.BooleanUtils.ValueOf(element.GetAttribute("isNotOrdered"));
			}
			return isNotOrdered;
		}

		private ICollection<Ca.Infoway.Messagebuilder.Domainvalue.PostalAddressUse> ParseAddressUses(string nameUseAttribute, XmlNode
			 node, XmlToModelResult xmlToModelResult)
		{
			ICollection<Ca.Infoway.Messagebuilder.Domainvalue.PostalAddressUse> uses = new HashSet<Ca.Infoway.Messagebuilder.Domainvalue.PostalAddressUse
				>();
			if (nameUseAttribute != null)
			{
				StringTokenizer tokenizer = new StringTokenizer(nameUseAttribute);
				while (tokenizer.HasMoreElements())
				{
					string token = tokenizer.NextToken();
					Ca.Infoway.Messagebuilder.Domainvalue.PostalAddressUse postalAddressUse = CodeResolverRegistry.Lookup<Ca.Infoway.Messagebuilder.Domainvalue.PostalAddressUse
						>(token);
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

		private PostalAddress ParseAddressPartTypes(XmlNode node, XmlToModelResult xmlToModelResult)
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
						if (!"useablePeriod".Equals(name))
						{
							PostalAddressPartType postalAddressPartType = GetPostalAddressPartType(name, element, xmlToModelResult);
							string value = GetTextValue(name, element, xmlToModelResult);
							if (postalAddressPartType != null)
							{
								result.AddPostalAddressPart(new PostalAddressPart(postalAddressPartType, value));
							}
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

		private PostalAddressPartType GetPostalAddressPartType(string type, XmlElement element, XmlToModelResult xmlToModelResult
			)
		{
			PostalAddressPartType postalAddressPartType = null;
			try
			{
				postalAddressPartType = GetNamePartType<PostalAddressPartType>(type);
				if (postalAddressPartType != null && element.HasAttribute("partType"))
				{
					string partTypeCode = element.GetAttribute("partType");
					string correctPartTypeCode = postalAddressPartType.CodeValue;
					if (!StringUtils.Equals(correctPartTypeCode, partTypeCode))
					{
						string message = System.String.Format("Address partType attribute for element {0} must have a fixed value of {1}", type, 
							correctPartTypeCode);
						RecordError(message, element, xmlToModelResult);
					}
				}
			}
			catch (XmlToModelTransformationException)
			{
			}
			// don't re-throw exception (seems like overkill)!
			if (postalAddressPartType == null)
			{
				// error if part type not found
				RecordError("Address part type not valid: " + type, element, xmlToModelResult);
			}
			return postalAddressPartType;
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
