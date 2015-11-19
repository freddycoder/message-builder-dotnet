using System.Xml;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Util.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	/// <summary>
	/// ON - OrganizationName
	/// Parses an ON element into a OrganizationName.
	/// </summary>
	/// <remarks>
	/// ON - OrganizationName
	/// Parses an ON element into a OrganizationName. The element looks like this:
	/// prefixIntelliware Development,Inc.
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-ON
	/// </remarks>
	[DataTypeHandler("ON")]
	internal class OnElementParser : AbstractEntityNameElementParser
	{
		protected override BareANY DoCreateDataTypeInstance(string typeName)
		{
			return new ONImpl();
		}

		protected override EntityName ParseNode(XmlNode node, XmlToModelResult xmlToModelResult)
		{
			OrganizationName result = new OrganizationName();
			XmlNodeList childNodes = node.ChildNodes;
			foreach (XmlNode childNode in new XmlNodeListIterable(childNodes))
			{
				if (childNode.NodeType == System.Xml.XmlNodeType.Text)
				{
					string value = childNode.Value;
					result.AddNamePart(new EntityNamePart(value));
				}
				else
				{
					if (childNode is XmlElement)
					{
						XmlElement element = (XmlElement)childNode;
						string name = NodeUtil.GetLocalOrTagName(element);
						string value = GetTextValue(element, xmlToModelResult);
						result.AddNamePart(new EntityNamePart(value, GetOrganizationNamePartType(name)));
					}
				}
			}
			return result;
		}

		private string GetTextValue(XmlElement element, Hl7Errors errors)
		{
			XmlNode childNode = element.FirstChild;
			if (childNode.NodeType != System.Xml.XmlNodeType.Text)
			{
				errors.AddHl7Error(new Hl7Error(Hl7ErrorCode.MANDATORY_FIELD_NOT_PROVIDED, "Expected ON child node to have a text node", 
					element));
			}
			return childNode.Value;
		}

		private NamePartType GetOrganizationNamePartType(string value)
		{
			return GetNamePartType<OrganizationNamePartType>(value);
		}
	}
}
