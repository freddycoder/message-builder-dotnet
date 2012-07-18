using System;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Terminology;
using ILOG.J2CsMapping.Collections.Generics;
using ILOG.J2CsMapping.Text;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[DataTypeHandler("IVL")]
	internal abstract class IvlElementParser<T> : AbstractIvlElementParser<T>
	{
		protected override BareANY DoCreateDataTypeInstance(string typeName)
		{
			return GenericDataTypeFactory.Create(typeName);
		}

		/// <exception cref="ILOG.J2CsMapping.Util.ParseException"></exception>
		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		protected override BareANY CreateType(ParseContext context, XmlElement element, XmlToModelResult parseResult)
		{
			string type = GetParameterizedType(context);
			ElementParser parser = ParserRegistry.GetInstance().Get(type);
			if (parser != null)
			{
				return parser.Parse(ParserContextImpl.Create(type, null, context.GetVersion(), context.GetDateTimeZone(), context.GetDateTimeTimeZone
					(), Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY), Arrays.AsList((XmlNode)element), parseResult);
			}
			else
			{
				parseResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, System.String.Format("Cannot find a parser for type {0}"
					, type), element));
				return null;
			}
		}

		private string GetParameterizedType(ParseContext context)
		{
			return Hl7DataTypeName.GetParameterizedType(context.Type);
		}

		/// <exception cref="ILOG.J2CsMapping.Util.ParseException"></exception>
		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		internal override BareDiff CreateDiffType(ParseContext context, XmlElement width, XmlToModelResult xmlToModelResult)
		{
			if (IsTimestampType(context))
			{
				return CreateDateDiff(context, width, xmlToModelResult);
			}
			else
			{
				return base.CreateDiffType(context, width, xmlToModelResult);
			}
		}

		private Diff<PlatformDate> CreateDateDiff(ParseContext context, XmlElement width, XmlToModelResult xmlToModelResult)
		{
			Diff<PlatformDate> result = null;
			if (GetAttributeValue(width, NullFlavorHelper.NULL_FLAVOR_ATTRIBUTE_NAME) != null)
			{
				result = ParseNullWidthNode(width);
			}
			else
			{
				StandardDataType type = StandardDataType.GetByTypeName(context);
				try
				{
					StandardDataType diffType = GetWidthType(type);
					ElementParser parser = ParserRegistry.GetInstance().Get(diffType);
					if (parser != null)
					{
						ParseContext subContext = ParserContextImpl.Create(diffType.Type, typeof(PhysicalQuantity), context.GetVersion(), context
							.GetDateTimeZone(), context.GetDateTimeTimeZone(), Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.POPULATED);
						PhysicalQuantity quantity = (PhysicalQuantity)parser.Parse(subContext, Arrays.AsList((XmlNode)width), xmlToModelResult).BareValue;
						if (quantity != null && quantity.Quantity != null && quantity.Unit != null)
						{
							result = new DateDiff(quantity);
						}
					}
					else
					{
						xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "Cannot find a parser for " + diffType.Type, width
							));
					}
				}
				catch (XmlToModelTransformationException e)
				{
					xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, e.Message, width));
				}
			}
			return result;
		}

		private StandardDataType GetWidthType(StandardDataType type)
		{
			try
			{
				return StandardDataType.GetWidthType(type);
			}
			catch (ArgumentException)
			{
				return StandardDataType.PQ_TIME;
			}
		}

		private Diff<PlatformDate> ParseNullWidthNode(XmlElement width)
		{
			string nullFlavor = width.GetAttribute(NullFlavorHelper.NULL_FLAVOR_ATTRIBUTE_NAME);
			return new DateDiff(CodeResolverRegistry.Lookup<NullFlavor>(nullFlavor));
		}

		private bool IsTimestampType(ParseContext context)
		{
			string type = GetParameterizedType(context);
			return "TS".Equals(Hl7DataTypeName.Unqualify(type));
		}
	}
}
