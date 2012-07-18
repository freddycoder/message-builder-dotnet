using System.Xml;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
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

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		protected override EntityName ParseNode(XmlNode node, XmlToModelResult xmlToModelResult)
		{
			OrganizationName result = new OrganizationName();
			XmlNodeList childNodes = node.ChildNodes;
			for (int i = 0; i < childNodes.Count; i++)
			{
				XmlNode childNode = childNodes.Item(i);
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
						string value = GetTextValue(element);
						result.AddNamePart(new EntityNamePart(value, GetOrganizationNamePartType(name)));
					}
				}
			}
			return result;
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		private string GetTextValue(XmlElement element)
		{
			XmlNode childNode = element.FirstChild;
			if (childNode.NodeType != System.Xml.XmlNodeType.Text)
			{
				throw new XmlToModelTransformationException("Expected ON child node to have a text node");
			}
			return childNode.Value;
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		private NamePartType GetOrganizationNamePartType(string value)
		{
			return GetNamePartType<OrganizationNamePartType>(value);
		}
	}
}
