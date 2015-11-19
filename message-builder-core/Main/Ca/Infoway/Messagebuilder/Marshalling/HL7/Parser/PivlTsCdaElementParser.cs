using System.Collections.Generic;
using System.Xml;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[DataTypeHandler("PIVLTSCDAR1")]
	internal class PivlTsCdaElementParser : ElementParser
	{
		private PivlTsElementParser r1Parser = new PivlTsElementParser();

		private PivlTsDateTimeElementParser r1ParserFrequency = new PivlTsDateTimeElementParser();

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		public virtual BareANY Parse(ParseContext context, IList<XmlNode> nodes, XmlToModelResult xmlToModelResult)
		{
			ParseContext newContext = ConvertContext(context);
			BareANY parseResult = this.r1Parser.Parse(newContext, nodes, xmlToModelResult);
			if (parseResult.BareValue == null && !parseResult.HasNullFlavor())
			{
				parseResult = this.r1ParserFrequency.Parse(newContext, nodes, xmlToModelResult);
			}
			return ConvertDataType(parseResult);
		}

		private BareANY ConvertDataType(BareANY dataType)
		{
			object bareValue = dataType.BareValue;
			PeriodicIntervalTime pivlR1 = (bareValue is PeriodicIntervalTime ? (PeriodicIntervalTime)bareValue : null);
			PeriodicIntervalTimeR2 pivlR2 = (pivlR1 == null ? null : ConvertPivl(pivlR1));
			BareANY result = new PIVLTSCDAR1Impl(pivlR2);
			result.DataType = dataType.DataType;
			result.NullFlavor = dataType.NullFlavor;
			return result;
		}

		private PeriodicIntervalTimeR2 ConvertPivl(PeriodicIntervalTime pivlR1)
		{
			return PeriodicIntervalTimeR2.CreateFromPivlR1(pivlR1);
		}

		private ParseContext ConvertContext(ParseContext ParseContext)
		{
			return ParseContextImpl.Create("PIVL<TS>", ParseContext);
		}
	}
}
