using System;
using System.Collections.Generic;
using System.Xml;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Util.Xml;
using ILOG.J2CsMapping.Text;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	public abstract class AbstractRtoElementParser<N, D> : AbstractSingleElementParser<Ratio<N, D>>
	{
		protected override Ratio<N, D> ParseNonNullNode(ParseContext context, XmlNode node, BareANY parseResult, Type expectedReturnType
			, XmlToModelResult xmlToModelResult)
		{
			Ratio<N, D> result = new Ratio<N, D>();
			IList<Hl7DataTypeName> innerTypes = Hl7DataTypeName.Create(context.Type).GetInnerTypes();
			if (innerTypes.Count != 2)
			{
				// this should never happen unless a message set is incorrect; ok to abort with exception (parsing will continue after this datatype) 
				throw new XmlToModelTransformationException("RTO data type must have two inner types. Type " + context.Type + " has " + innerTypes
					.Count + ".");
			}
			bool numeratorFound = false;
			bool denominatorFound = false;
			XmlNodeList childNodes = node.ChildNodes;
			foreach (XmlNode childNode in new XmlNodeListIterable(childNodes))
			{
				if (childNode is XmlElement)
				{
					XmlElement element = (XmlElement)childNode;
					string name = NodeUtil.GetLocalOrTagName(element);
					if ("numerator".Equals(name))
					{
						numeratorFound = true;
						result.Numerator = GetNumeratorValue(element, innerTypes[0].ToString(), context, xmlToModelResult);
					}
					else
					{
						if ("denominator".Equals(name))
						{
							denominatorFound = true;
							result.Denominator = GetDenominatorValue(element, innerTypes[1].ToString(), context, xmlToModelResult);
						}
					}
				}
			}
			if (!numeratorFound)
			{
				RecordMissingElementError("Numerator", context, node, xmlToModelResult);
			}
			if (!denominatorFound)
			{
				RecordMissingElementError("Denominator", context, node, xmlToModelResult);
			}
			return result;
		}

		private void RecordMissingElementError(string element, ParseContext context, XmlNode node, XmlToModelResult xmlToModelResult
			)
		{
			xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, System.String.Format("{0} is mandatory for type {1} ({2})"
				, element, context.Type, XmlDescriber.DescribeSingleElement((XmlElement)node)), (XmlElement)node));
		}

		protected abstract N GetNumeratorValue(XmlElement element, string type, ParseContext context, XmlToModelResult xmlToModelResult
			);

		protected abstract D GetDenominatorValue(XmlElement element, string type, ParseContext context, XmlToModelResult xmlToModelResult
			);

		protected override BareANY DoCreateDataTypeInstance(string typeName)
		{
			return new RTOImpl<N, D>();
		}
	}
}
