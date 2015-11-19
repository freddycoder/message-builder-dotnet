using System.Collections.Generic;
using System.Text;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Lang;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Constraints;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2;
using Ca.Infoway.Messagebuilder.Xml;
using Ca.Infoway.Messagebuilder.Xml.Util;
using ILOG.J2CsMapping.Text;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2
{
	internal abstract class AbstractCodedTypeR2PropertyFormatter : AbstractAttributePropertyFormatter<CodedTypeR2<Code>>
	{
		private readonly IvlTsR2PropertyFormatter ivlFormatter = new IvlTsR2PropertyFormatter();

		private readonly EdPropertyFormatter edFormatter = new EdPropertyFormatter(new TelR2PropertyFormatter(), true);

		private CodedTypesConstraintsHandler constraintsHandler = new CodedTypesConstraintsHandler();

		public override string Format(FormatContext context, BareANY hl7Value, int indentLevel)
		{
			string result = base.Format(context, hl7Value, indentLevel);
			// also calls formatNonNullDataType, but only if no NullFlavor present
			// if the supplied value had a null flavor we still need to handle other properties (if present)
			if (hl7Value != null && hl7Value.HasNullFlavor())
			{
				result = FormatNonNullDataType(context, hl7Value, indentLevel);
			}
			return result;
		}

		protected override CodedTypeR2<Code> ExtractBareValue(BareANY hl7Value)
		{
			return hl7Value == null ? null : CodedTypeR2Helper.ConvertCodedTypeR2(hl7Value.BareValue);
		}

		protected override string FormatNonNullDataType(FormatContext context, BareANY hl7Value, int indentLevel)
		{
			CodedTypeR2<Code> codedType = ExtractBareValue(hl7Value);
			HandleConstraints(codedType, context.GetConstraints(), context.GetPropertyPath(), context.GetModelToXmlResult());
			StringBuilder result = new StringBuilder();
			IDictionary<string, string> attributes = GetAttributeNameValuePairs(context, codedType, hl7Value);
			ValidateChildContent(codedType, context);
			bool hasChildContent = HasChildContent(codedType, context);
			bool hasSimpleValue = (SimpleValueAllowed() && HasSimpleValue(codedType));
			if (hasChildContent || hasSimpleValue || !attributes.IsEmpty())
			{
				result.Append(CreateElement(context, attributes, indentLevel, !(hasChildContent || hasSimpleValue), !hasSimpleValue || hasChildContent
					));
				if (hasChildContent || hasSimpleValue)
				{
					CreateChildContent(codedType, context, indentLevel + 1, result);
					result.Append(CreateElementClosure(context, indentLevel, true));
				}
			}
			return result.ToString();
		}

		private void HandleConstraints(CodedTypeR2<Code> codedType, ConstrainedDatatype constraints, string propertyPath, Hl7Errors
			 errors)
		{
			ErrorLogger logger = new _ErrorLogger_109(errors, propertyPath);
			this.constraintsHandler.HandleConstraints(constraints, codedType, logger);
		}

		private sealed class _ErrorLogger_109 : ErrorLogger
		{
			public _ErrorLogger_109(Hl7Errors errors, string propertyPath)
			{
				this.errors = errors;
				this.propertyPath = propertyPath;
			}

			public void LogError(Hl7ErrorCode errorCode, ErrorLevel errorLevel, string errorMessage)
			{
				errors.AddHl7Error(new Hl7Error(errorCode, errorLevel, errorMessage, propertyPath));
			}

			private readonly Hl7Errors errors;

			private readonly string propertyPath;
		}

		private void ValidateChildContent(CodedTypeR2<Code> codedType, FormatContext context)
		{
			if (HasTranslation(codedType) && !TranslationAllowed())
			{
				LogValueNotAllowed("translation", context);
			}
			if (HasQualifier(codedType) && !QualifierAllowed())
			{
				LogValueNotAllowed("qualifier", context);
			}
			if (HasOriginalText(codedType) && !OriginalTextAllowed())
			{
				LogValueNotAllowed("originalText", context);
			}
			if (HasSimpleValue(codedType) && !SimpleValueAllowed())
			{
				LogValueNotAllowed("text", context);
			}
		}

		private bool HasChildContent(CodedTypeR2<Code> codedType, FormatContext context)
		{
			bool hasChildContent = (OriginalTextAllowed() && HasOriginalText(codedType));
			hasChildContent |= (QualifierAllowed() && HasQualifier(codedType));
			hasChildContent |= (TranslationAllowed() && HasTranslation(codedType));
			hasChildContent |= (ValidTimeAllowed() && HasValidTime(codedType));
			return hasChildContent;
		}

		private void CreateChildContent(CodedTypeR2<Code> codedType, FormatContext context, int indentLevel, StringBuilder result
			)
		{
			HandleOriginalText(codedType, indentLevel, result, context);
			HandleQualifier(codedType, indentLevel, result, context);
			HandleTranslation(codedType, indentLevel, result, context);
			HandleValidTime(codedType, indentLevel, result, context);
			HandleSimpleValue(codedType, result, context);
		}

		private void HandleQualifier(CodedTypeR2<Code> codedType, int indentLevel, StringBuilder result, FormatContext context)
		{
			if (HasQualifier(codedType))
			{
				if (QualifierAllowed())
				{
					FormatContext newContext = new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl("CR", "qualifier", context
						);
					IList<CodeRole> qualifier = codedType.Qualifier;
					foreach (CodeRole codeRole in qualifier)
					{
						string formattedQualifier = new CrR2PropertyFormatter().Format(newContext, new CRImpl(codeRole), indentLevel);
						result.Append(formattedQualifier);
					}
				}
			}
		}

		private void HandleTranslation(CodedTypeR2<Code> codedType, int indentLevel, StringBuilder result, FormatContext context)
		{
			// translation (LIST<CD>)
			if (HasTranslation(codedType))
			{
				if (TranslationAllowed())
				{
					FormatContext newContext = new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl("CD", "translation", 
						context);
					foreach (CodedTypeR2<Code> translation in codedType.Translation)
					{
						CD_R2<Code> cdAny = new CD_R2Impl<Code>(translation);
						cdAny.NullFlavor = translation.NullFlavorForTranslationOnly;
						string transationString = CreateTranslation(translation, cdAny, indentLevel, newContext);
						result.Append(transationString);
					}
				}
			}
		}

		protected virtual string CreateTranslation(CodedTypeR2<Code> translation, CD_R2<Code> cdAny, int indentLevel, FormatContext
			 newContext)
		{
			// subclasses must implement as required 
			return string.Empty;
		}

		private void HandleValidTime(CodedTypeR2<Code> codedType, int indentLevel, StringBuilder result, FormatContext context)
		{
			if (HasValidTime(codedType))
			{
				if (ValidTimeAllowed())
				{
					FormatContext newContext = new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl("IVL<TS>", "validTime"
						, context);
					Interval<PlatformDate> validTime = codedType.ValidTime;
					IVL_TS ivlTs = new IVL_TSImpl(validTime == null ? null : new DateInterval(validTime));
					string formattedValidTime = this.ivlFormatter.Format(newContext, ivlTs, indentLevel);
					result.Append(formattedValidTime);
				}
			}
		}

		private void HandleSimpleValue(CodedTypeR2<Code> codedType, StringBuilder result, FormatContext context)
		{
			// simpleValue (String)
			if (HasSimpleValue(codedType))
			{
				if (SimpleValueAllowed())
				{
					result.Append(XmlStringEscape.Escape(codedType.SimpleValue));
				}
			}
		}

		private void HandleOriginalText(CodedTypeR2<Code> codedType, int indentLevel, StringBuilder result, FormatContext context
			)
		{
			if (HasOriginalText(codedType))
			{
				if (OriginalTextAllowed())
				{
					EncapsulatedData originalText = codedType.OriginalText;
					EDImpl<EncapsulatedData> edAny = new EDImpl<EncapsulatedData>(originalText);
					FormatContext newContext = new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl("ED", "originalText"
						, context);
					string formattedOriginalText = this.edFormatter.Format(newContext, edAny, indentLevel);
					if (StringUtils.IsNotBlank(formattedOriginalText))
					{
						result.Append(formattedOriginalText);
					}
				}
			}
		}

		protected override IDictionary<string, string> GetAttributeNameValuePairs(FormatContext context, CodedTypeR2<Code> codedType
			, BareANY bareAny)
		{
			IDictionary<string, string> result = new Dictionary<string, string>();
			HandleNullFlavor(codedType, result, bareAny, context);
			HandleCodeValue(codedType, result, context);
			HandleCodeSystem(codedType, result, context);
			HandleCodeSystemName(codedType, result, context);
			HandleCodeSystemVersion(codedType, result, context);
			HandleDisplayName(codedType, result, context);
			HandleOperator(codedType, result, context);
			HandleValue(codedType, result, context);
			HandleQty(codedType, result, context);
			return result;
		}

		private void HandleQty(CodedTypeR2<Code> codedType, IDictionary<string, string> result, FormatContext context)
		{
			if (HasQty(codedType))
			{
				if (QtyAllowed())
				{
					result["qty"] = codedType.Qty.ToString();
				}
				else
				{
					LogValueNotAllowed("qty", context);
				}
			}
		}

		private void HandleValue(CodedTypeR2<Code> codedType, IDictionary<string, string> result, FormatContext context)
		{
			if (HasValue(codedType))
			{
				if (ValueAllowed())
				{
					result["value"] = codedType.Value.ToString();
				}
				else
				{
					LogValueNotAllowed("value", context);
				}
			}
		}

		private void HandleOperator(CodedTypeR2<Code> codedType, IDictionary<string, string> result, FormatContext context)
		{
			if (HasOperator(codedType))
			{
				if (OperatorAllowed())
				{
					result["operator"] = codedType.Operator.CodeValue;
				}
				else
				{
					LogValueNotAllowed("operator", context);
				}
			}
		}

		protected virtual void HandleDisplayName(CodedTypeR2<Code> codedType, IDictionary<string, string> result, FormatContext context
			)
		{
			if (HasDisplayName(codedType))
			{
				if (DisplayNameAllowed())
				{
					result["displayName"] = codedType.DisplayName;
				}
				else
				{
					LogValueNotAllowed("displayName", context);
				}
			}
		}

		private void HandleCodeSystemVersion(CodedTypeR2<Code> codedType, IDictionary<string, string> result, FormatContext context
			)
		{
			if (HasCodeSystemVersion(codedType))
			{
				if (CodeSystemVersionAllowed())
				{
					result["codeSystemVersion"] = codedType.CodeSystemVersion;
				}
				else
				{
					LogValueNotAllowed("codeSystemVersion", context);
				}
			}
		}

		protected virtual void HandleCodeSystemName(CodedTypeR2<Code> codedType, IDictionary<string, string> result, FormatContext
			 context)
		{
			if (HasCodeSystemName(codedType))
			{
				if (CodeSystemNameAllowed())
				{
					result["codeSystemName"] = codedType.CodeSystemName;
				}
				else
				{
					LogValueNotAllowed("codeSystemName", context);
				}
			}
		}

		protected virtual void HandleCodeSystem(CodedTypeR2<Code> codedType, IDictionary<string, string> result, FormatContext context
			)
		{
			// FIXME - TM - CDA - validate as uid (?)
			if (HasCodeSystem(codedType))
			{
				if (CodeSystemAllowed())
				{
					result["codeSystem"] = codedType.GetCodeSystem();
				}
				else
				{
					LogValueNotAllowed("codeSystem", context);
				}
			}
		}

		private void HandleCodeValue(CodedTypeR2<Code> codedType, IDictionary<string, string> result, FormatContext context)
		{
			if (HasCodeValue(codedType))
			{
				if (CodeValueAllowed())
				{
					result["code"] = codedType.GetCodeValue();
				}
				else
				{
					LogValueNotAllowed("code", context);
				}
			}
		}

		private void HandleNullFlavor(CodedTypeR2<Code> codedType, IDictionary<string, string> result, BareANY bareAny, FormatContext
			 context)
		{
			if (bareAny != null && bareAny.HasNullFlavor())
			{
				result.PutAll(CreateNullFlavorAttributes(bareAny.NullFlavor));
			}
			else
			{
				if (codedType == null)
				{
					Ca.Infoway.Messagebuilder.Xml.ConformanceLevel conformanceLevel = context.GetConformanceLevel();
					Cardinality cardinality = context.GetCardinality();
					if (conformanceLevel == null || ConformanceLevelUtil.IsPopulated(conformanceLevel, cardinality))
					{
						result.PutAll(AbstractPropertyFormatter.NULL_FLAVOR_ATTRIBUTES);
					}
				}
			}
		}

		private void LogValueNotAllowed(string propertyName, FormatContext context)
		{
			string message = System.String.Format("Relationships of type \"{0}\" are not allowed to have the \"{1}\" property.", context
				.Type, propertyName);
			RecordError(message, context);
		}

		private void RecordError(string message, FormatContext context)
		{
			context.GetModelToXmlResult().AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, message, context.GetPropertyPath()));
		}

		private bool HasOriginalText(CodedTypeR2<Code> codedType)
		{
			return codedType != null && codedType.OriginalText != null;
		}

		private bool HasQualifier(CodedTypeR2<Code> codedType)
		{
			return codedType != null && !codedType.Qualifier.IsEmpty();
		}

		private bool HasTranslation(CodedTypeR2<Code> codedType)
		{
			return codedType != null && !codedType.Translation.IsEmpty();
		}

		private bool HasValidTime(CodedTypeR2<Code> codedType)
		{
			return codedType != null && codedType.ValidTime != null;
		}

		private bool HasSimpleValue(CodedTypeR2<Code> codedType)
		{
			return codedType != null && StringUtils.IsNotBlank(codedType.SimpleValue);
		}

		private bool HasCodeValue(CodedTypeR2<Code> codedType)
		{
			return codedType != null && StringUtils.IsNotBlank(codedType.GetCodeValue());
		}

		private bool HasCodeSystem(CodedTypeR2<Code> codedType)
		{
			return codedType != null && StringUtils.IsNotBlank(codedType.GetCodeSystem());
		}

		private bool HasCodeSystemName(CodedTypeR2<Code> codedType)
		{
			return codedType != null && StringUtils.IsNotBlank(codedType.CodeSystemName);
		}

		private bool HasCodeSystemVersion(CodedTypeR2<Code> codedType)
		{
			return codedType != null && StringUtils.IsNotBlank(codedType.CodeSystemVersion);
		}

		private bool HasDisplayName(CodedTypeR2<Code> codedType)
		{
			return codedType != null && StringUtils.IsNotBlank(codedType.DisplayName);
		}

		private bool HasOperator(CodedTypeR2<Code> codedType)
		{
			return codedType != null && codedType.Operator != null && StringUtils.IsNotBlank(codedType.Operator.CodeValue);
		}

		private bool HasValue(CodedTypeR2<Code> codedType)
		{
			return codedType != null && codedType.Value != null;
		}

		private bool HasQty(CodedTypeR2<Code> codedType)
		{
			return codedType != null && codedType.Qty != null;
		}

		// subclasses can override these methods to specify what properties they do and don't allow
		protected virtual bool OriginalTextAllowed()
		{
			return false;
		}

		protected virtual bool QualifierAllowed()
		{
			return false;
		}

		protected virtual bool TranslationAllowed()
		{
			return false;
		}

		protected virtual bool ValidTimeAllowed()
		{
			return false;
		}

		protected virtual bool SimpleValueAllowed()
		{
			return false;
		}

		protected virtual bool CodeValueAllowed()
		{
			return false;
		}

		protected virtual bool CodeSystemAllowed()
		{
			return false;
		}

		protected virtual bool CodeSystemNameAllowed()
		{
			return false;
		}

		protected virtual bool CodeSystemVersionAllowed()
		{
			return false;
		}

		protected virtual bool DisplayNameAllowed()
		{
			return false;
		}

		protected virtual bool OperatorAllowed()
		{
			return false;
		}

		protected virtual bool ValueAllowed()
		{
			return false;
		}

		protected virtual bool QtyAllowed()
		{
			return false;
		}
	}
}
