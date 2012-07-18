using System;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Util.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	/// <summary>
	/// INT - Integer
	/// Parses an INT element into a Integer.
	/// </summary>
	/// <remarks>
	/// INT - Integer
	/// Parses an INT element into a Integer. The element looks like this:
	/// 
	/// If a value is null, value is replaced by a null flavor. So the element would look
	/// like this:
	/// 
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-INT
	/// CeRx further breaks down the datatype into INT.NONNEG and INT.POS subtypes, but those are
	/// irrelevant on the parsing side. We don't check for non-negative or positive constraints.
	/// </remarks>
	[DataTypeHandler(new string[] { "INT.NONNEG", "INT.POS", "INT" })]
	internal class IntElementParser : AbstractSingleElementParser<Int32?>
	{
		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		protected override Int32? ParseNonNullNode(ParseContext context, XmlNode node, BareANY result, Type expectedReturnType, XmlToModelResult
			 xmlToModelResult)
		{
			ValidateNoChildren(context, node);
			return ParseNonNullNode((XmlElement)node, expectedReturnType, xmlToModelResult);
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		protected virtual Int32? ParseNonNullNode(XmlElement element, Type expectedReturnType, XmlToModelResult xmlToModelResult)
		{
			Int32? result = null;
			string unparsedInteger = GetAttributeValue(element, "value");
			if (StringUtils.IsNotBlank(unparsedInteger))
			{
				if (!NumberUtil.IsNumber(unparsedInteger))
				{
					xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "The attribute \"value\" does not contain a valid number ("
						 + XmlDescriber.DescribeSingleElement(element) + ")", element));
				}
				else
				{
					result = NumberUtil.ParseAsInteger(unparsedInteger);
					if (!NumberUtil.IsInteger(unparsedInteger))
					{
						xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "The attribute \"value\" is not a valid integer, it will be truncated to "
							 + result + " (" + XmlDescriber.DescribeSingleElement(element) + ")", element));
					}
				}
			}
			else
			{
				if (element.HasAttribute("value"))
				{
					xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "The attribute \"value\" is specified, but empty. ("
						 + XmlDescriber.DescribeSingleElement(element) + ")", element));
				}
			}
			return result;
		}

		protected override BareANY DoCreateDataTypeInstance(string typeName)
		{
			return new INTImpl();
		}
	}
}
