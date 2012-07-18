using System;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Terminology;
using Ca.Infoway.Messagebuilder.Util.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	/// <summary>
	/// MO - Money
	/// Represents an MO elements into a MO object.
	/// </summary>
	/// <remarks>
	/// MO - Money
	/// Represents an MO elements into a MO object. The element looks like this:
	/// 
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-MO
	/// </remarks>
	[DataTypeHandler("MO")]
	internal class MoElementParser : AbstractSingleElementParser<Money>
	{
		protected override BareANY DoCreateDataTypeInstance(string typeName)
		{
			return new MOImpl();
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		protected override Money ParseNonNullNode(ParseContext context, XmlNode node, BareANY result, Type expectedReturnType, XmlToModelResult
			 xmlToModelResult)
		{
			ValidateNoChildren(context, node);
			string value = GetMandatoryAttributeValue(node, "value", xmlToModelResult);
			BigDecimal amount = StringUtils.IsBlank(value) ? null : new BigDecimal(value);
			string currencyCode = GetMandatoryAttributeValue(node, "currency", xmlToModelResult);
			Currency currency = CodeResolverRegistry.Lookup<Currency>(currencyCode);
			if (currency == null)
			{
				xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "Could not decode currency value " + currencyCode
					 + " (" + XmlDescriber.DescribeSingleElement((XmlElement)node) + ")", (XmlElement)node));
			}
			return new Money(amount, currency);
		}
	}
}
