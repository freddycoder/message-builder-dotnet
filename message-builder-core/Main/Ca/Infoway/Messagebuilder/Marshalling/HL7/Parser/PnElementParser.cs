using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
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

		protected override BareANY DoCreateDataTypeInstance(string typeName)
		{
			return new PNImpl();
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		protected override EntityName ParseNode(XmlNode node, XmlToModelResult xmlToModelResult)
		{
			PersonName result = new PersonName();
			XmlNodeList childNodes = node.ChildNodes;
			if (childNodes.Count == 1 && childNodes.Item(0) is XmlText)
			{
				// TODO - TM - this is most likely a PN.SIMPLE - need type passed in to be able to check
				HandleSimpleName(node, result);
			}
			else
			{
				HandlePersonName(xmlToModelResult, result, childNodes);
			}
			return result;
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		private void HandlePersonName(XmlToModelResult xmlToModelResult, PersonName result, XmlNodeList childNodes)
		{
			for (int i = 0; i < childNodes.Count; i++)
			{
				XmlNode childNode = childNodes.Item(i);
				if (childNode is XmlElement)
				{
					XmlElement element = (XmlElement)childNode;
					string name = NodeUtil.GetLocalOrTagName(element);
					string value = GetTextValue(element, xmlToModelResult);
					string qualifier = GetAttributeValue(element, NAME_PART_TYPE_QUALIFIER);
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
						string value = childNode.Value.Trim();
						result.AddNamePart(new EntityNamePart(value, null, null));
					}
				}
			}
		}

		private bool IsNonBlankTextNode(XmlNode childNode)
		{
			return childNode.Value != null && childNode.NodeType == System.Xml.XmlNodeType.Text && !StringUtils.IsBlank(childNode.Value
				);
		}

		private void HandleSimpleName(XmlNode node, PersonName result)
		{
			string value = NodeUtil.GetTextValue(node);
			if (StringUtils.IsNotBlank(value))
			{
				result.AddNamePart(new EntityNamePart(value, null));
			}
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
