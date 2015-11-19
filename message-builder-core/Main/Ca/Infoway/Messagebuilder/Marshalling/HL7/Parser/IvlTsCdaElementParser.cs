using System.Collections.Generic;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Constraints;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Platform;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[DataTypeHandler("IVLTSCDAR1")]
	internal class IvlTsCdaElementParser : ElementParser
	{
		private IvlTsElementParser r1Parser = new IvlTsElementParser();

		private readonly IvlTsConstraintsHandler constraintsHandler = new IvlTsConstraintsHandler();

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		public virtual BareANY Parse(ParseContext context, IList<XmlNode> nodes, XmlToModelResult xmlToModelResult)
		{
			ParseContext newContext = ConvertContext(context);
			BareANY parseResult = this.r1Parser.Parse(newContext, nodes, xmlToModelResult);
			BareANY convertedDataType = ConvertDataType(parseResult);
			HandleConstraints(context, xmlToModelResult, nodes, convertedDataType);
			return convertedDataType;
		}

		private void HandleConstraints(ParseContext context, Hl7Errors errors, IList<XmlNode> nodes, BareANY convertedDataType)
		{
			XmlElement element = (nodes.Count > 0 ? (XmlElement)nodes[0] : null);
			ErrorLogger logger = new _ErrorLogger_61(errors, element);
			DateInterval dateInterval = (DateInterval)convertedDataType.BareValue;
			this.constraintsHandler.HandleConstraints(context.GetConstraints(), dateInterval, logger);
		}

		private sealed class _ErrorLogger_61 : ErrorLogger
		{
			public _ErrorLogger_61(Hl7Errors errors, XmlElement element)
			{
				this.errors = errors;
				this.element = element;
			}

			public void LogError(Hl7ErrorCode errorCode, ErrorLevel errorLevel, string errorMessage)
			{
				errors.AddHl7Error(new Hl7Error(errorCode, errorLevel, errorMessage, element));
			}

			private readonly Hl7Errors errors;

			private readonly XmlElement element;
		}

		private BareANY ConvertDataType(BareANY dataType)
		{
			object bareValue = dataType.BareValue;
			Interval<PlatformDate> ivlTsR1 = GenericClassUtil.CastBareValueAsIntervalDate(bareValue);
			DateInterval ivlTsR2 = (ivlTsR1 == null ? null : ConvertIvlTs(ivlTsR1));
			IVLTSCDAR1 result = new IVLTSCDAR1Impl();
			result.DataType = dataType.DataType;
			result.BareValue = ivlTsR2;
			result.NullFlavor = dataType.NullFlavor;
			return result;
		}

		private DateInterval ConvertIvlTs(Interval<PlatformDate> ivlTsR1)
		{
			return ivlTsR1 == null ? null : new DateInterval(ivlTsR1);
		}

		private ParseContext ConvertContext(ParseContext parseContext)
		{
			return ParseContextImpl.Create("IVL<TS>", parseContext);
		}
	}
}
