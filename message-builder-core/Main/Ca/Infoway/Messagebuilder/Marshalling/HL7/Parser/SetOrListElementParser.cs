using System;
using System.Collections.Generic;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.J5goodies;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using ILOG.J2CsMapping.Collections.Generics;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	internal abstract class SetOrListElementParser : AbstractElementParser
	{
		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		public override BareANY Parse(ParseContext context, IList<XmlNode> nodes, XmlToModelResult xmlToModelResult)
		{
			string subType = GetSubType(context);
			ICollection<BareANY> list = GetCollectionType(context);
			foreach (XmlNode node in nodes)
			{
				ElementParser parser = ParserRegistry.GetInstance().Get(subType);
				if (parser != null)
				{
					BareANY result = parser.Parse(ParserContextImpl.Create(subType, GetSubTypeAsModelType(context), context.GetVersion(), context
						.GetDateTimeZone(), context.GetDateTimeTimeZone(), context.GetConformance()), ToList(node), xmlToModelResult);
					if (result != null)
					{
						list.Add(result);
					}
				}
				else
				{
					xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.INTERNAL_ERROR, "No parser type found for " + subType, (XmlElement
						)node));
					break;
				}
			}
			return WrapWithHl7DataType(context.Type, subType, list);
		}

		protected abstract BareANY WrapWithHl7DataType(string type, string subType, ICollection<BareANY> collection);

		protected abstract ICollection<BareANY> GetCollectionType(ParseContext context);

		private Type GetSubTypeAsModelType(ParseContext context)
		{
			Type returnType = GetReturnType(context);
			try
			{
				return Generics.GetParameterType(returnType);
			}
			catch (ArgumentException)
			{
				return returnType;
			}
		}

		private IList<XmlNode> ToList(XmlNode node)
		{
			return Arrays.AsList(node);
		}

		protected virtual string GetChildType()
		{
			return null;
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		private string GetSubType(ParseContext context)
		{
			string subType = Hl7DataTypeName.GetParameterizedType(context.Type);
			if (StringUtils.IsNotBlank(subType))
			{
				return subType;
			}
			else
			{
				throw new XmlToModelTransformationException("Cannot find the sub type for " + context.Type);
			}
		}
	}
}
