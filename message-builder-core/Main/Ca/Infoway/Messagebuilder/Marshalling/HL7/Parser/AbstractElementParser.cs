using System;
using System.Collections.Generic;
using System.Xml;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Schema;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	public abstract class AbstractElementParser : ElementParser
	{
		protected static readonly string SPECIALIZATION_TYPE = "specializationType";

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		public abstract BareANY Parse(ParseContext context, IList<XmlNode> node, XmlToModelResult xmlToModelResult);

		protected virtual string GetAttributeValue(XmlNode node, string attributeName)
		{
			return node != null && node is XmlElement ? GetAttributeValue((XmlElement)node, attributeName) : null;
		}

		protected virtual string GetAttributeValue(XmlElement node, string attributeName)
		{
			return node != null && node.HasAttribute(attributeName) ? node.GetAttribute(attributeName) : null;
		}

		protected virtual string GetXsiType(XmlNode node)
		{
			return node != null && node is XmlElement ? GetXsiType((XmlElement)node) : null;
		}

		protected virtual string GetXsiType(XmlElement element)
		{
			return element.GetAttribute("type", XmlSchemas.SCHEMA_INSTANCE);
		}

		protected virtual Type GetReturnType(ParseContext context)
		{
			return context == null ? null : context.GetExpectedReturnType();
		}
	}
}
