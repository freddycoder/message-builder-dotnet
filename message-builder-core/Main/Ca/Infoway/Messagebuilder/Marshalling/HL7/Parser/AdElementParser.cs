using System;
using System.Collections.Generic;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Platform;
using Ca.Infoway.Messagebuilder.Terminology;
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
		protected override BareANY DoCreateDataTypeInstance(string typeName)
		{
			return new ADImpl();
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		protected override PostalAddress ParseNonNullNode(ParseContext context, XmlNode node, BareANY parseResult, Type expectedReturnType
			, XmlToModelResult xmlToModelResult)
		{
			PostalAddress result = ParseNode(node);
			result.Uses = GetNameUses(GetAttributeValue(node, "use"));
			return result;
		}

		private ICollection<Ca.Infoway.Messagebuilder.Datatype.Lang.PostalAddressUse> GetNameUses(string nameUseAttribute)
		{
			ICollection<Ca.Infoway.Messagebuilder.Datatype.Lang.PostalAddressUse> uses = new HashSet<Ca.Infoway.Messagebuilder.Datatype.Lang.PostalAddressUse
				>();
			if (nameUseAttribute != null)
			{
				StringTokenizer tokenizer = new StringTokenizer(nameUseAttribute);
				while (tokenizer.HasMoreElements())
				{
					string token = tokenizer.NextToken();
					Ca.Infoway.Messagebuilder.Datatype.Lang.PostalAddressUse postalAddressUse = CodeResolverRegistry.Lookup<Ca.Infoway.Messagebuilder.Datatype.Lang.PostalAddressUse
						>(token);
					if (postalAddressUse != null)
					{
						uses.Add(postalAddressUse);
					}
				}
			}
			return uses;
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		private PostalAddress ParseNode(XmlNode node)
		{
			PostalAddress result = new PostalAddress();
			XmlNodeList childNodes = node.ChildNodes;
			for (int i = 0; i < childNodes.Count; i++)
			{
				XmlNode childNode = childNodes.Item(i);
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
						string value = GetTextValue(element);
						string codeAsString = GetAttributeValue(childNode, "code");
						result.AddPostalAddressPart(new PostalAddressPart(GetPostalAddressPartType(name), CodeUtil.ConvertToCode(codeAsString), value
							));
					}
				}
			}
			return result;
		}

		private bool IsNonBlankTextNode(XmlNode childNode)
		{
			return childNode.NodeType == System.Xml.XmlNodeType.Text && !StringUtils.IsBlank(childNode.Value);
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		private PostalAddressPartType GetPostalAddressPartType(string type)
		{
			return GetNamePartType<PostalAddressPartType>(type);
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		private string GetTextValue(XmlElement element)
		{
			XmlNode childNode = element.FirstChild;
			if (childNode == null)
			{
				return null;
			}
			else
			{
				if (childNode.NodeType != System.Xml.XmlNodeType.Text)
				{
					throw new XmlToModelTransformationException("Expected AD child node to have a text node");
				}
			}
			return childNode.Value;
		}
	}
}
