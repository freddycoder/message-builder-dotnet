using System;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	/// <summary>
	/// REAL - BigDecimal
	/// Parses an REAL element into a BigDecimal.
	/// </summary>
	/// <remarks>
	/// REAL - BigDecimal
	/// Parses an REAL element into a BigDecimal. The element looks like this:
	/// 
	/// If a value is null, value is replaced by a null flavor. So the element would look
	/// like this:
	/// 
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-REAL
	/// CHI further breaks down the datatype into REAL.CONF and REAL.COORD subtypes, but those are
	/// irrelevant on the parsing side. We don't check for non-negative or positive constraints.
	/// </remarks>
	[DataTypeHandler(new string[] { "REAL.CONF", "REAL.COORD" })]
	internal class RealElementParser : AbstractSingleElementParser<BigDecimal>
	{
		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		protected override BigDecimal ParseNonNullNode(ParseContext context, XmlNode node, BareANY parseResult, Type expectedReturnType
			, XmlToModelResult xmlToModelResult)
		{
			ValidateNoChildren(context, node);
			BigDecimal result = null;
			string unparsedReal = GetAttributeValue(node, "value");
			ValidateDecimal(unparsedReal, context.Type, xmlToModelResult, (XmlElement)node);
			if (unparsedReal != null)
			{
				try
				{
					result = new BigDecimal(unparsedReal);
				}
				catch (FormatException)
				{
					xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "Value \"" + unparsedReal + "\" of type " + context
						.Type + " is not a valid number", (XmlElement)node));
				}
			}
			return result;
		}

		private void ValidateDecimal(string value, string type, XmlToModelResult result, XmlElement element)
		{
			if (NumberUtil.IsNumber(value))
			{
				string integerPart = value.Contains(".") ? StringUtils.SubstringBefore(value, ".") : value;
				string decimalPart = value.Contains(".") ? StringUtils.SubstringAfter(value, ".") : string.Empty;
				RealFormat format = GetFormat(type);
				if (StandardDataType.REAL_CONF.Type.Equals(type) && (!"0".Equals(integerPart) && !string.Empty.Equals(integerPart)))
				{
					result.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "Value " + value + " of type " + type + " must be between 0 and 1."
						, element));
				}
				if (StringUtils.Length(value) > format.GetMaxValueLength())
				{
					result.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "Value " + value + " of type " + type + " exceeds maximum length of "
						 + format.GetMaxValueLength(), element));
				}
				if (StringUtils.Length(integerPart) > format.GetMaxIntegerPartLength())
				{
					result.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "Value " + value + " of type " + type + " should have no more than "
						 + format.GetMaxIntegerPartLength() + " digits before the decimal", element));
				}
				if (StringUtils.Length(decimalPart) > format.GetMaxDecimalPartLength())
				{
					result.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "Value " + value + " of type " + type + " should have no more than "
						 + format.GetMaxDecimalPartLength() + " digits after the decimal", element));
				}
			}
		}

		private RealFormat GetFormat(string type)
		{
			return StandardDataType.REAL_CONF.Type.Equals(type) ? (RealFormat)new RealConfFormat() : (RealFormat)new RealCoordFormat(
				);
		}

		protected override BareANY DoCreateDataTypeInstance(string typeName)
		{
			return new REALImpl();
		}
	}
}
