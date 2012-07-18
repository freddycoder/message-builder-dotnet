using System;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using ILOG.J2CsMapping.Collections.Generics;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	/// <summary>
	/// ANY, ANY.LAB, ANY.CA.IZ, ANY.PATH
	/// Each value sent over the wire must correspond to one of the
	/// following non-abstract data type flavor specifications defined below:
	/// ANY:       all types allowed
	/// ANY.LAB:   CD.LAB, ST, PQ.LAB, IVL, INT.NONNEG, INT.POS, TS.FULLDATETIME, URG
	/// ANY.CA.IZ: ST, PN.BASIC, INT.POS, BL
	/// ANY.PATH:  ST, PQ, ED.DOCORREF or CD.LAB
	/// </summary>
	[DataTypeHandler(new string[] { "ANY", "ANY.LAB", "ANY.CA.IZ", "ANY.PATH" })]
	public class AnyElementParser : AbstractSingleElementParser<object>
	{
		protected override BareANY DoCreateDataTypeInstance(string typeName)
		{
			return new ANYImpl<object>();
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		protected override object ParseNonNullNode(ParseContext context, XmlNode node, BareANY hl7Result, Type returnType, XmlToModelResult
			 xmlToModelResult)
		{
			object result = null;
			string parentType = context == null ? null : context.Type;
			string specializationType = ObtainSpecializationType(parentType, node, xmlToModelResult);
			if (StringUtils.IsNotBlank(specializationType))
			{
				ElementParser elementParser = ParserRegistry.GetInstance().Get(specializationType);
				if (elementParser == null || !AnyHelper.IsValidTypeForAny(parentType, specializationType))
				{
					xmlToModelResult.AddHl7Error(Hl7Error.CreateInvalidTypeError(specializationType, parentType, (XmlElement)node));
				}
				else
				{
					BareANY parsedValue = elementParser.Parse(ParserContextImpl.Create(specializationType, GetReturnType(context), context.GetVersion
						(), context.GetDateTimeZone(), context.GetDateTimeTimeZone(), context.GetConformance()), Arrays.AsList(node), xmlToModelResult
						);
					result = parsedValue.BareValue;
					// Yes, this is a side effect of calling this method. If we don't do this then the actual type of the ANY.LAB (i.e. PQ.LAB) is lost.
					hl7Result.DataType = parsedValue.DataType;
				}
			}
			else
			{
				xmlToModelResult.AddHl7Error(Hl7Error.CreateMissingMandatoryAttributeError(AbstractElementParser.SPECIALIZATION_TYPE, (XmlElement
					)node));
			}
			return result;
		}

		/// <summary>The specialization type attribute is used to check against valid ANY types.</summary>
		/// <remarks>
		/// The specialization type attribute is used to check against valid ANY types. This has a bit of "magic"
		/// involved, as the CHI specializationType notation (eg. URG_PQ) just happens to match up to our
		/// StandardDataType enum names.
		/// </remarks>
		/// <param name="parentType"></param>
		/// <param name="node"></param>
		/// <param name="xmlToModelResult"></param>
		/// <returns>the converted specializationType</returns>
		private string ObtainSpecializationType(string parentType, XmlNode node, XmlToModelResult xmlToModelResult)
		{
			string rawSpecializationType = GetAttributeValue(node, AbstractElementParser.SPECIALIZATION_TYPE);
			if (StringUtils.IsBlank(rawSpecializationType))
			{
				// some cases don't need "specializationType". Treat xsi:type as specializationType (internally)
				// e.g. URG_PQ, ST
				rawSpecializationType = GetXsiType(node);
			}
			string result = rawSpecializationType;
			if (StringUtils.IsNotBlank(rawSpecializationType) && !AnyHelper.IsValidTypeForAny(parentType, rawSpecializationType))
			{
				string unqualify = Hl7DataTypeName.Unqualify(rawSpecializationType);
				string validType = GetValidType(unqualify, parentType);
				if (validType != null)
				{
					result = validType;
				}
			}
			return result;
		}

		private string GetValidType(string hl7Type, string parentType)
		{
			string result = null;
			StandardDataType dataType = EnumPattern.ValueOf<StandardDataType>(hl7Type);
			if (dataType != null)
			{
				if (AnyHelper.IsValidTypeForAny(parentType, dataType.Type))
				{
					result = dataType.Type;
				}
			}
			return result;
		}
	}
}
