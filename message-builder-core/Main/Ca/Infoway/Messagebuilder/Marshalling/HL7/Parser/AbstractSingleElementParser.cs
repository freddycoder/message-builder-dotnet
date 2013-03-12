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
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Util.Xml;
using log4net;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	public abstract class AbstractSingleElementParser<V> : AbstractElementParser
	{
		private readonly ILog log;

		protected static readonly string EMPTY_STRING = string.Empty;

		protected abstract BareANY DoCreateDataTypeInstance(string typeName);

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		public override BareANY Parse(ParseContext context, IList<XmlNode> nodes, XmlToModelResult xmlToModelResult)
		{
			if (nodes == null || nodes.Count == 0)
			{
				return null;
			}
			else
			{
				if (nodes.Count == 1)
				{
					return Parse(context, nodes[0], xmlToModelResult);
				}
				else
				{
					throw new XmlToModelTransformationException("Expected a single element and found " + nodes.Count);
				}
			}
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		public virtual BareANY Parse(ParseContext context, XmlNode node, XmlToModelResult xmlToModelResult)
		{
			BareANY result = CreateDataTypeInstance(context != null ? GetType(context) : null);
			if (HasValidNullFlavorAttribute(context, node, xmlToModelResult))
			{
				NullFlavor nullFlavor = ParseNullNode(context, node, xmlToModelResult);
				result.NullFlavor = nullFlavor;
			}
			else
			{
				V value = ParseNonNullNode(context, node, result, GetReturnType(context), xmlToModelResult);
				((BareANYImpl)result).BareValue = value;
			}
			return result;
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		protected abstract V ParseNonNullNode(ParseContext context, XmlNode node, BareANY result, Type returnType, XmlToModelResult
			 xmlToModelResult);

		private BareANY CreateDataTypeInstance(string typeName)
		{
			BareANY dataTypeInstance = DoCreateDataTypeInstance(typeName);
			SetDataType(typeName, dataTypeInstance);
			return dataTypeInstance;
		}

		protected virtual void SetDataType(string dataTypeName, BareANY dataTypeInstance)
		{
			if (dataTypeName != null)
			{
				StandardDataType dataType = StandardDataType.GetByTypeName(dataTypeName);
				if (dataType != null)
				{
					dataTypeInstance.DataType = dataType;
				}
				else
				{
					this.log.Error("missing data type! " + dataTypeName);
				}
			}
		}

		protected virtual bool HasValidNullFlavorAttribute(ParseContext context, XmlNode node, XmlToModelResult xmlToModelResult)
		{
			return new NullFlavorHelper(context != null ? context.GetConformance() : null, node, xmlToModelResult, false).HasValidNullFlavorAttribute
				();
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		protected virtual NullFlavor ParseNullNode(ParseContext context, XmlNode node, XmlToModelResult xmlToModelResult)
		{
			return new NullFlavorHelper(context != null ? context.GetConformance() : null, node, xmlToModelResult, false).ParseNullNode
				();
		}

		protected virtual XmlNode GetNamedChildNode(XmlNode node, string childNodeName)
		{
			XmlNode result = null;
			XmlNodeList childNodes = node.ChildNodes;
			for (int i = 0; i < childNodes.Count && result == null; i++)
			{
				XmlNode childNode = childNodes.Item(i);
				if (childNodeName.Equals(NodeUtil.GetLocalOrTagName(childNode)))
				{
					result = childNode;
				}
			}
			return result;
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		protected virtual string GetMandatoryAttributeValue(XmlNode node, string attributeName, XmlToModelResult parsingResult)
		{
			string result = GetAttributeValue(node, attributeName);
			if (StringUtils.IsBlank(result))
			{
				parsingResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "Attribute " + attributeName + " is mandatory for node "
					 + XmlDescriber.DescribePath(node) + " (" + XmlDescriber.DescribeSingleElement((XmlElement)node) + ")", (XmlElement)node
					));
			}
			return result;
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		protected virtual S GetNamePartType<S>(string value) where S : NamePartType
		{
			System.Type type = typeof(S);
			foreach (S partType in EnumPattern.Values<S>(type))
			{
				if (partType.Value.Equals(value))
				{
					return partType;
				}
			}
			throw new XmlToModelTransformationException("Unexpected part of type: " + value);
		}

		protected virtual void ValidateUnallowedAttributes(string type, XmlElement node, XmlToModelResult result, string attribute
			)
		{
			if (StringUtils.IsNotBlank(GetAttributeValue(node, attribute)))
			{
				result.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, type + " should not include the '" + attribute + "' property. ("
					 + XmlDescriber.DescribeSingleElement(node) + ")", node));
			}
		}

		protected virtual void ValidateUnallowedChildNode(string type, XmlElement node, XmlToModelResult result, string childNodeName
			)
		{
			XmlNode child = GetNamedChildNode(node, childNodeName);
			if (child != null)
			{
				result.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, type + " should not include the '" + childNodeName + "' property. ("
					 + XmlDescriber.DescribeSingleElement(node) + ")", node));
			}
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		protected virtual void ValidateNoChildren(ParseContext context, XmlNode node)
		{
			XmlNodeList childNodes = node.ChildNodes;
			for (int i = 0; i < childNodes.Count; ++i)
			{
				XmlNode item = childNodes.Item(i);
				if (IsNonTrivialChildNode(item))
				{
					throw new XmlToModelTransformationException("Expected " + GetType(context) + " node to have no children");
				}
			}
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		protected virtual void ValidateMaxChildCount(ParseContext context, XmlNode node, int maxChildren)
		{
			XmlNodeList childNodes = node.ChildNodes;
			int numNontrivialChildNodes = 0;
			for (int i = 0; i < childNodes.Count; ++i)
			{
				XmlNode item = childNodes.Item(i);
				if (IsNonTrivialChildNode(item))
				{
					numNontrivialChildNodes++;
				}
			}
			if (numNontrivialChildNodes > maxChildren)
			{
				throw new XmlToModelTransformationException("Expected " + GetType(context) + " node to have no more than " + maxChildren 
					+ " child nodes");
			}
		}

		private bool IsNonTrivialChildNode(XmlNode child)
		{
			return (child is XmlText && StringUtils.IsNotBlank(((XmlText)child).Data)) || (child is XmlElement);
		}

		private string GetType(ParseContext context)
		{
			return context == null ? string.Empty : context.Type;
		}

		public AbstractSingleElementParser()
		{
			log = log4net.LogManager.GetLogger(GetType());
		}
	}
}
