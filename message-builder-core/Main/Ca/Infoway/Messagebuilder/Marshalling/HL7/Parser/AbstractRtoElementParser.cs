using System;
using System.Xml;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Util.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	public abstract class AbstractRtoElementParser<N, D> : AbstractSingleElementParser<Ratio<N, D>>
	{
		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		protected override Ratio<N, D> ParseNonNullNode(ParseContext context, XmlNode node, BareANY parseResult, Type expectedReturnType
			, XmlToModelResult xmlToModelResult)
		{
			Ratio<N, D> result = new Ratio<N, D>();
			XmlNodeList childNodes = node.ChildNodes;
			for (int i = 0; i < childNodes.Count; i++)
			{
				XmlNode childNode = childNodes.Item(i);
				if (childNode is XmlElement)
				{
					XmlElement element = (XmlElement)childNode;
					string name = NodeUtil.GetLocalOrTagName(element);
					if ("numerator".Equals(name))
					{
						result.Numerator = GetNumeratorValue(element);
					}
					else
					{
						if ("denominator".Equals(name))
						{
							result.Denominator = GetDenominatorValue(element);
						}
					}
				}
			}
			return result;
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		protected abstract N GetNumeratorValue(XmlElement element);

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		protected abstract D GetDenominatorValue(XmlElement element);

		protected override BareANY DoCreateDataTypeInstance(string typeName)
		{
			return new RTOImpl<N, D>();
		}
	}
}
