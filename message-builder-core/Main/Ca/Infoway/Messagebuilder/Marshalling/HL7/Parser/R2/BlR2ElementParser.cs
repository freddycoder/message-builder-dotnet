using System;
using System.Collections.Generic;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2
{
	/// <summary>Parses an BL element into a Boolean.</summary>
	/// <remarks>
	/// Parses an BL element into a Boolean. The element looks like this:
	/// 
	/// If a BL is null, value is replaced by a null flavor. So the element would look
	/// like this:
	/// 
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-BL
	/// </remarks>
	[DataTypeHandler(new string[] { "BL", "BN" })]
	public class BlR2ElementParser : AbstractSingleElementParser<Boolean?>
	{
		private static IList<string> VALID_BOOLEAN_STRINGS = new List<string>();

		static BlR2ElementParser()
		{
			VALID_BOOLEAN_STRINGS.Add("true");
			VALID_BOOLEAN_STRINGS.Add("false");
		}

		protected override BareANY DoCreateDataTypeInstance(string typeName)
		{
			return new BLImpl();
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		protected override Boolean? ParseNonNullNode(ParseContext context, XmlNode node, BareANY result, Type expectedReturnType, 
			XmlToModelResult xmlToModelResult)
		{
			XmlElement element = (XmlElement)node;
			return ParseBooleanValue(xmlToModelResult, GetAttributeValue(element, "value"), element, null);
		}

		protected override bool HasValidNullFlavorAttribute(ParseContext context, XmlNode node, XmlToModelResult result)
		{
			bool isBN = StringUtils.Equals(context.Type, StandardDataType.BN.Type);
			bool hasValidNF = base.HasValidNullFlavorAttribute(context, node, result);
			if (isBN && hasValidNF)
			{
				result.AddHl7Error(new Hl7Error(Hl7ErrorCode.MANDATORY_FIELD_NOT_PROVIDED, "BN field may not have a nullFlavor", (XmlElement
					)node));
			}
			return hasValidNF;
		}

		// public as a result of needing to call this method from ValidatingVistor
		public virtual Boolean? ParseBooleanValue(XmlToModelResult result, string unparsedBoolean, XmlElement element, XmlAttribute
			 attr)
		{
			Boolean? booleanResult = null;
			if (StringUtils.IsBlank(unparsedBoolean))
			{
				result.AddHl7Error(Hl7Error.CreateMandatoryBooleanValueError(element, attr));
			}
			else
			{
				if (VALID_BOOLEAN_STRINGS.Contains(unparsedBoolean))
				{
					booleanResult = Ca.Infoway.Messagebuilder.BooleanUtils.ValueOf(unparsedBoolean);
				}
				else
				{
					if (VALID_BOOLEAN_STRINGS.Contains(unparsedBoolean.ToLower()))
					{
						result.AddHl7Error(Hl7Error.CreateIncorrectCapitalizationBooleanValueError(unparsedBoolean, element, attr));
						booleanResult = Ca.Infoway.Messagebuilder.BooleanUtils.ValueOf(unparsedBoolean);
					}
					else
					{
						result.AddHl7Error(Hl7Error.CreateInvalidBooleanValueError(element, attr));
					}
				}
			}
			return booleanResult;
		}
	}
}
