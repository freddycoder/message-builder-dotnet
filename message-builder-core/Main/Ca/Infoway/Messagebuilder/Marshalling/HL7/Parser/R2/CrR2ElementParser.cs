using System;
using System.Collections.Generic;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2
{
	/// <summary>CR (R2)</summary>
	[DataTypeHandler("CR")]
	internal class CrR2ElementParser : AbstractSingleElementParser<CodeRole>
	{
		private CvR2ElementParser cvParser = new CvR2ElementParser();

		private CdR2ElementParser cdParser = new CdR2ElementParser();

		protected override BareANY DoCreateDataTypeInstance(string typeName)
		{
			return new CRImpl();
		}

		protected override CodeRole ParseNonNullNode(ParseContext context, XmlNode node, BareANY parseResult, Type expectedReturnType
			, XmlToModelResult xmlToModelResult)
		{
			CodeRole result = new CodeRole();
			XmlElement element = (XmlElement)node;
			HandleName(element, result, context, xmlToModelResult);
			HandleValue(element, result, context, xmlToModelResult);
			bool hasInvertedAttribute = HandleInverted(element, result);
			if (result.Name == null && result.Value == null && !hasInvertedAttribute)
			{
				result = null;
			}
			return result;
		}

		private bool HandleInverted(XmlElement element, CodeRole result)
		{
			bool hasInvertedAttribute = element.HasAttribute("inverted");
			if (hasInvertedAttribute)
			{
				bool inverted = Ca.Infoway.Messagebuilder.BooleanUtils.ValueOf(element.GetAttribute("inverted"));
				result.Inverted = inverted;
			}
			return hasInvertedAttribute;
		}

		private void HandleValue(XmlElement element, CodeRole result, ParseContext context, XmlToModelResult xmlToModelResult)
		{
			IList<XmlElement> values = GetNamedElements("value", element);
			if (values.Count >= 1)
			{
				if (values.Count > 1)
				{
					RecordError("Only one value element is allowed within a CR type.", context, element, xmlToModelResult);
				}
				XmlElement valueElement = values[0];
				// run through cd parser
				ParseContext newContext = ParseContextImpl.Create("ANY", typeof(Code), context);
				BareANY cdAny = this.cdParser.Parse(newContext, valueElement, xmlToModelResult);
				result.Value = cdAny == null ? null : (CodedTypeR2<Code>)cdAny.BareValue;
			}
			else
			{
				RecordError("CR types must have a value element (or a nullFlavor attribute)", context, element, xmlToModelResult);
			}
		}

		private void HandleName(XmlElement element, CodeRole result, ParseContext context, XmlToModelResult xmlToModelResult)
		{
			IList<XmlElement> names = GetNamedElements("name", element);
			if (names.Count >= 1)
			{
				if (names.Count > 1)
				{
					RecordError("Only one name element is allowed within a CR type.", context, element, xmlToModelResult);
				}
				XmlElement nameElement = names[0];
				// run through cv parser
				ParseContext newContext = ParseContextImpl.Create("ANY", typeof(Code), context);
				BareANY cvAny = this.cvParser.Parse(newContext, nameElement, xmlToModelResult);
				result.Name = cvAny == null ? null : (CodedTypeR2<Code>)cvAny.BareValue;
			}
		}

		protected virtual void RecordError(string message, ParseContext context, XmlNode node, XmlToModelResult xmlToModelResult)
		{
			xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, message, (XmlElement)node));
		}
	}
}
