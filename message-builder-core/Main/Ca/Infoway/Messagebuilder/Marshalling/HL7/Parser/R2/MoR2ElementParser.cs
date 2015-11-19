using System;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2;
using Ca.Infoway.Messagebuilder.Resolver;
using Ca.Infoway.Messagebuilder.Util.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2
{
	/// <summary>
	/// MO - Money (R2)
	/// Represents an MO elements into a MO object.
	/// </summary>
	/// <remarks>
	/// MO - Money (R2)
	/// Represents an MO elements into a MO object. The element looks like this:
	/// 
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-MO
	/// </remarks>
	[DataTypeHandler(new string[] { "MO", "SXCM<MO>" })]
	internal class MoR2ElementParser : AbstractSingleElementParser<Money>
	{
		private readonly SxcmR2ElementParserHelper sxcmHelper = new SxcmR2ElementParserHelper();

		protected override BareANY DoCreateDataTypeInstance(string typeName)
		{
			return new MOImpl();
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		protected override Money ParseNonNullNode(ParseContext context, XmlNode node, BareANY bareAny, Type expectedReturnType, XmlToModelResult
			 xmlToModelResult)
		{
			ValidateNoChildren(context, node);
			string value = GetAttributeValue(node, "value");
			BigDecimal amount = ValidateValue(value, context.Type, xmlToModelResult, (XmlElement)node);
			string currencyCode = GetAttributeValue(node, "currency");
			Ca.Infoway.Messagebuilder.Domainvalue.Basic.Currency currency = ValidateCurrency(currencyCode, node, xmlToModelResult);
			this.sxcmHelper.HandleOperator((XmlElement)node, context, xmlToModelResult, (ANYMetaData)bareAny);
			return amount == null && currency == null ? null : new Money(amount, currency);
		}

		private BigDecimal ValidateValue(string value, string type, XmlToModelResult xmlToModelResult, XmlElement element)
		{
			if (StringUtils.IsBlank(value))
			{
				if (element.HasAttribute("value"))
				{
					RecordInvalidNumberError(value, type, element, xmlToModelResult);
				}
				return null;
			}
			if (NumberUtil.IsNumber(value))
			{
				string integerPart = value.Contains(".") ? StringUtils.SubstringBefore(value, ".") : value;
				string decimalPart = value.Contains(".") ? StringUtils.SubstringAfter(value, ".") : string.Empty;
				if (!StringUtils.IsNumeric(integerPart) || !StringUtils.IsNumeric(decimalPart))
				{
					RecordMustContainDigitsOnlyError(value, xmlToModelResult, element);
				}
			}
			BigDecimal result = null;
			try
			{
				result = new BigDecimal(value);
			}
			catch (FormatException)
			{
				RecordInvalidNumberError(value, type, element, xmlToModelResult);
			}
			return result;
		}

		private Ca.Infoway.Messagebuilder.Domainvalue.Basic.Currency ValidateCurrency(string currencyCode, XmlNode node, XmlToModelResult
			 xmlToModelResult)
		{
			if (StringUtils.IsBlank(currencyCode))
			{
				return null;
			}
			// TM - the MB enum for currency is very limited
			Ca.Infoway.Messagebuilder.Domainvalue.Basic.Currency currency = CodeResolverRegistry.Lookup<Ca.Infoway.Messagebuilder.Domainvalue.Basic.Currency
				>(currencyCode);
			if (currency == null)
			{
				RecordUnknownCurrencyError(currencyCode, node, xmlToModelResult);
			}
			return currency;
		}

		private void RecordUnknownCurrencyError(string currencyCode, XmlNode node, XmlToModelResult xmlToModelResult)
		{
			xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "Could not decode currency value " + currencyCode
				 + " (" + XmlDescriber.DescribeSingleElement((XmlElement)node) + ")", (XmlElement)node));
		}

		private void RecordInvalidNumberError(string value, string type, XmlElement element, XmlToModelResult xmlToModelResult)
		{
			xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "Value \"" + value + "\" of type " + type + " is not a valid number ("
				 + XmlDescriber.DescribeSingleElement(element) + ")", element));
		}

		private void RecordMustContainDigitsOnlyError(string value, XmlToModelResult xmlToModelResult, XmlElement element)
		{
			xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "Value \"" + value + "\" can only contain digits. ("
				 + XmlDescriber.DescribeSingleElement(element) + ")", element));
		}
	}
}
