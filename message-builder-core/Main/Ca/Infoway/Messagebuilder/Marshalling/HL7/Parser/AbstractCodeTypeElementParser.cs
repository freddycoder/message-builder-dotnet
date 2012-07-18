using System;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.J5goodies;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Util.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	public abstract class AbstractCodeTypeElementParser : AbstractSingleElementParser<Code>
	{
		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		public override BareANY Parse(ParseContext context, XmlNode node, XmlToModelResult xmlToModelResult)
		{
			BareANY cd = DoCreateDataTypeInstance(context.Type);
			PopulateNullFlavor(cd, context, node, xmlToModelResult);
			PopulateValue(cd, context, node, xmlToModelResult);
			PopulateOriginalText(cd, context, (XmlElement)node, GetReturnType(context), xmlToModelResult);
			return cd;
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		private void PopulateNullFlavor(BareANY dataType, ParseContext context, XmlNode node, XmlToModelResult xmlToModelResult)
		{
			if (HasValidNullFlavorAttribute(context, node, xmlToModelResult))
			{
				NullFlavor nullFlavor = ParseNullNode(context, node, xmlToModelResult);
				dataType.NullFlavor = nullFlavor;
			}
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		private void PopulateValue(BareANY dataType, ParseContext context, XmlNode node, XmlToModelResult xmlToModelResult)
		{
			Code value = ParseNonNullNode(context, node, dataType, GetReturnType(context), xmlToModelResult);
			((BareANYImpl)dataType).BareValue = value;
		}

		private void PopulateOriginalText(BareANY dataType, ParseContext context, XmlElement element, Type returnType, XmlToModelResult
			 xmlToModelResult)
		{
			if (HasOriginalText(element))
			{
				((CD)dataType).OriginalText = GetOriginalText(element);
			}
		}

		private string GetOriginalText(XmlElement element)
		{
			XmlNodeList children = element.ChildNodes;
			string result = null;
			int length = children == null ? 0 : children.Count;
			for (int i = 0; i < length; i++)
			{
				XmlNode node = children.Item(i);
				if (node.NodeType != System.Xml.XmlNodeType.Element)
				{
				}
				else
				{
					if ("originalText".Equals(NodeUtil.GetLocalOrTagName(node)))
					{
						result = NodeUtil.GetTextValue(node);
					}
				}
			}
			return result;
		}

		protected bool HasOriginalText(XmlElement element)
		{
			return StringUtils.IsNotBlank(GetOriginalText(element));
		}

		protected virtual Hl7Error CreateHl7Error(XmlNode node, Type type, string code)
		{
			string message = "The code, \"" + code + "\", in element <" + NodeUtil.GetLocalOrTagName(node) + "> is not a valid value for domain type \""
				 + ClassUtils.GetShortClassName(type) + "\"";
			return new Hl7Error(Hl7ErrorCode.VALUE_NOT_IN_CODE_SYSTEM, message, (XmlElement)node);
		}

		protected virtual Type GetReturnTypeAsCodeType(Type type)
		{
			if (type is Type)
			{
				return (Type)type;
			}
			else
			{
				if (Generics.IsCollectionParameterizedType(type))
				{
					// this case should only happen if the original property was inlined
					return (Type)Generics.GetParameterType(type);
				}
				else
				{
					throw new ArgumentException("Can't determine the domain type of " + type);
				}
			}
		}
	}
}
