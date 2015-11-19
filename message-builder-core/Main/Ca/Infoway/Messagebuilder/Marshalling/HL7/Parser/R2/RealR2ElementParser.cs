using System;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2
{
	/// <summary>
	/// REAL - BigDecimal (R2)
	/// Parses an REAL element into a BigDecimal.
	/// </summary>
	/// <remarks>
	/// REAL - BigDecimal (R2)
	/// Parses an REAL element into a BigDecimal. The element looks like this:
	/// 
	/// If a value is null, value is replaced by a null flavor. So the element would look
	/// like this:
	/// 
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-REAL
	/// </remarks>
	[DataTypeHandler(new string[] { "REAL", "SXCM<REAL>" })]
	internal class RealR2ElementParser : AbstractSingleElementParser<BigDecimal>
	{
		private readonly SxcmR2ElementParserHelper sxcmHelper = new SxcmR2ElementParserHelper();

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		protected override BigDecimal ParseNonNullNode(ParseContext context, XmlNode node, BareANY bareAny, Type expectedReturnType
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
					RecordInvalidNumberError(context, node, xmlToModelResult, unparsedReal);
				}
				this.sxcmHelper.HandleOperator((XmlElement)node, context, xmlToModelResult, (ANYMetaData)bareAny);
			}
			return result;
		}

		private void ValidateDecimal(string value, string type, XmlToModelResult result, XmlElement element)
		{
			// check that value is a valid decimal?? i.e. value isn't some weird combinations of characters that might lead to a valid BigDecial (such as a hex value)
			if (StringUtils.IsBlank(value))
			{
				RecordValueMustBeSpecifiedError(result, element);
			}
		}

		private void RecordValueMustBeSpecifiedError(XmlToModelResult result, XmlElement element)
		{
			result.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "Value must be specified", element));
		}

		private void RecordInvalidNumberError(ParseContext context, XmlNode node, XmlToModelResult xmlToModelResult, string unparsedReal
			)
		{
			xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "Value \"" + unparsedReal + "\" of type " + context
				.Type + " is not a valid number", (XmlElement)node));
		}

		protected override BareANY DoCreateDataTypeInstance(string typeName)
		{
			return new REALImpl();
		}
	}
}
