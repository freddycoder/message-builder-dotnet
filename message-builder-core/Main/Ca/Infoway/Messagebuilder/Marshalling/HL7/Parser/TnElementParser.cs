using System.Xml;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	/// <summary>
	/// TN - TrivialName
	/// Parses a TN element into a TrivialName.
	/// </summary>
	/// <remarks>
	/// TN - TrivialName
	/// Parses a TN element into a TrivialName. The element looks like this:
	/// This is a trivial name
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-TN
	/// </remarks>
	[DataTypeHandler("TN")]
	internal class TnElementParser : AbstractEntityNameElementParser
	{
		protected override BareANY DoCreateDataTypeInstance(string typeName)
		{
			return new TNImpl();
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		protected override EntityName ParseNode(XmlNode node, XmlToModelResult xmlToModelResult)
		{
			string name = null;
			int childNodeCount = node.ChildNodes.Count;
			if (childNodeCount == 0)
			{
			}
			else
			{
				// name portion is null
				if (childNodeCount == 1)
				{
					XmlNode childNode = node.FirstChild;
					if (childNode.NodeType != System.Xml.XmlNodeType.Text)
					{
						throw new XmlToModelTransformationException("Expected TN node to have a text node");
					}
					name = childNode.Value;
				}
				else
				{
					throw new XmlToModelTransformationException("Expected TN node to have at most one child");
				}
			}
			return new TrivialName(name);
		}
	}
}
