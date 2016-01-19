/**
 * Copyright 2013 Canada Health Infoway, Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *        http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 * Author:        $LastChangedBy: gng $
 * Last modified: $LastChangedDate: 2015-11-19 18:20:12 -0500 (Fri, 30 Jan 2015) $
 * Revision:      $LastChangedRevision: 9755 $
 */


using System;
using System.Collections.Generic;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Constraints;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2;
using Ca.Infoway.Messagebuilder.Util.Xml;
using Ca.Infoway.Messagebuilder.Xml;
using ILOG.J2CsMapping.Collections.Generics;
using ILOG.J2CsMapping.Text;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2
{
	/// <summary>CodedType parser for R2</summary>
	public abstract class AbstractCodedTypeR2ElementParser : AbstractSingleElementParser<CodedTypeR2<Code>>
	{
		private static readonly string CODE_SYSTEM_NAME = "codeSystemName";

		protected static readonly string STANDARD_CODE_ATTRIBUTE_NAME = "code";

		protected static readonly string CODE_SYSTEM_ATTRIBUTE_NAME = "codeSystem";

		private static readonly string CODE_SYSTEM_VERSION = "codeSystemVersion";

		private static readonly string DISPLAY_NAME = "displayName";

		private static readonly string VALUE = "value";

		private static readonly string QTY = "qty";

		private CodeLookupUtils codeLookupUtils = new CodeLookupUtils();

		private SxcmR2ElementParserHelper operatorHelper = new SxcmR2ElementParserHelper();

		private IvlTsR2ElementParser validTimeParser = new IvlTsR2ElementParser();

		private EdElementParser edParser = new EdElementParser(new TelR2ElementParser(), true);

		private CodedTypesConstraintsHandler constraintsHandler = new CodedTypesConstraintsHandler();

		protected override CodedTypeR2<Code> ParseNonNullNode(ParseContext context, XmlNode node, BareANY result, Type expectedReturnType
			, XmlToModelResult xmlToModelResult)
		{
			throw new NotSupportedException("Nothing should be calling this method.");
		}

		protected abstract BareANY DoCreateR2DataTypeInstance(ParseContext context);

		public override BareANY Parse(ParseContext context, XmlNode node, XmlToModelResult result)
		{
			BareANY codedTypeAny = DoCreateR2DataTypeInstance(context);
			XmlElement element = (XmlElement)node;
			CodedTypeR2<Code> codedType = new CodedTypeR2<Code>();
			// attributes
			HandleNullFlavor(element, codedTypeAny, context, result);
			HandleCodeAndCodeSystem(element, codedType, context, result);
			HandleCodeSystemName(element, codedType, context, result);
			HandleCodeSystemVersion(element, codedType, context, result);
			HandleDisplayName(element, codedType, context, result);
			HandleValue(element, codedType, context, result);
			HandleQty(element, codedType, context, result);
			HandleOperator(element, codedTypeAny, codedType, context, result);
			// elements
			HandleSimpleValue(element, codedType, context, result);
			HandleOriginalText(element, codedType, context, result);
			HandleQualifier(element, codedType, context, result);
			HandleTranslation(element, codedType, context, result);
			HandleValidTime(element, codedType, context, result);
			HandleConstraints(codedType, context.GetConstraints(), element, result);
			// want to return null if no attributes or elements are present
			if (codedType.IsEmpty())
			{
				codedType = null;
			}
			((BareANYImpl)codedTypeAny).BareValue = CodedTypeR2Helper.ConvertCodedTypeR2(codedType, context.GetExpectedReturnType());
			return codedTypeAny;
		}

		private void HandleConstraints(CodedTypeR2<Code> codedType, ConstrainedDatatype constraints, XmlElement element, Hl7Errors
			 errors)
		{
			ErrorLogger logger = new _ErrorLogger_127(errors, element);
			this.constraintsHandler.HandleConstraints(constraints, codedType, logger);
		}

		private sealed class _ErrorLogger_127 : ErrorLogger
		{
			public _ErrorLogger_127(Hl7Errors errors, XmlElement element)
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

		private void HandleQualifier(XmlElement element, CodedTypeR2<Code> codedType, ParseContext context, XmlToModelResult result
			)
		{
			if (QualifierAllowed())
			{
				ParseContext newContext = ParseContextImpl.Create("CR", typeof(Code), context);
				XmlNodeList qualifiers = element.GetElementsByTagName("qualifier");
				for (int i = 0,  length = qualifiers.Count; i < length; i++)
				{
					XmlElement qualifierElement = (XmlElement)qualifiers.Item(i);
					// only want direct child node qualifiers
					if (qualifierElement.ParentNode.Equals(element))
					{
						BareANY anyCr = new CrR2ElementParser().Parse(newContext, qualifierElement, result);
						if (anyCr != null && anyCr.BareValue != null)
						{
							codedType.Qualifier.Add((CodeRole)anyCr.BareValue);
						}
					}
				}
			}
			else
			{
				ValidateUnallowedChildNode(context.Type, element, result, "qualifier");
			}
		}

		private void HandleNullFlavor(XmlElement element, BareANY dataType, ParseContext context, XmlToModelResult result)
		{
			if (HasValidNullFlavorAttribute(context, element, result))
			{
				NullFlavor nullFlavor = ParseNullNode(context, element, result);
				dataType.NullFlavor = nullFlavor;
			}
		}

		private void HandleCodeAndCodeSystem(XmlElement element, CodedTypeR2<Code> codedType, ParseContext context, XmlToModelResult
			 result)
		{
			string code = GetAttributeValue(element, STANDARD_CODE_ATTRIBUTE_NAME);
			string codeSystem = null;
			if (element.HasAttribute(CODE_SYSTEM_ATTRIBUTE_NAME))
			{
				if (CodeSystemAllowed())
				{
					codeSystem = StringUtils.TrimToNull(GetAttributeValue(element, CODE_SYSTEM_ATTRIBUTE_NAME));
				}
				else
				{
					LogValueNotAllowed(CODE_SYSTEM_ATTRIBUTE_NAME, element, context, result);
				}
			}
			//MBR-335: In some cases we have fixed values that are not part of the generated API and that have
			//values that do not conform to the expected return type. In this case, just fake up a value as
			//it will be discarded later in HL7SourceMapper. See PolicyActivity.GuarantorPerformerAssignedEntity
			//in ccda r1_1 message set for an example. i.e. GUAR is not a valid RoleClass
			bool relaxCodeCheck = context.IsFixedValue();
			Code actualCode = this.codeLookupUtils.GetCorrespondingCode(code, codeSystem, context.GetExpectedReturnType(), element, context
				.Type, result, true, relaxCodeCheck);
			codedType.Code = actualCode;
		}

		private void HandleCodeSystemName(XmlElement element, CodedTypeR2<Code> codedType, ParseContext context, XmlToModelResult
			 result)
		{
			if (element.HasAttribute(CODE_SYSTEM_NAME))
			{
				if (CodeSystemNameAllowed())
				{
					string codeSystemName = GetAttributeValue(element, CODE_SYSTEM_NAME);
					codedType.CodeSystemName = StringUtils.TrimToNull(codeSystemName);
				}
				else
				{
					LogValueNotAllowed(CODE_SYSTEM_NAME, element, context, result);
				}
			}
		}

		private void HandleCodeSystemVersion(XmlElement element, CodedTypeR2<Code> codedType, ParseContext context, XmlToModelResult
			 result)
		{
			if (element.HasAttribute(CODE_SYSTEM_VERSION))
			{
				if (CodeSystemVersionAllowed())
				{
					string codeSystemVersion = GetAttributeValue(element, CODE_SYSTEM_VERSION);
					codedType.CodeSystemVersion = StringUtils.TrimToNull(codeSystemVersion);
				}
				else
				{
					LogValueNotAllowed(CODE_SYSTEM_VERSION, element, context, result);
				}
			}
		}

		private void HandleDisplayName(XmlElement element, CodedTypeR2<Code> codedType, ParseContext context, XmlToModelResult result
			)
		{
			if (element.HasAttribute(DISPLAY_NAME))
			{
				if (DisplayNameAllowed())
				{
					string displayName = GetAttributeValue(element, DISPLAY_NAME);
					codedType.DisplayName = StringUtils.TrimToNull(displayName);
				}
				else
				{
					LogValueNotAllowed(DISPLAY_NAME, element, context, result);
				}
			}
		}

		private void HandleValue(XmlElement element, CodedTypeR2<Code> codedType, ParseContext context, XmlToModelResult result)
		{
			if (element.HasAttribute(VALUE))
			{
				if (ValueAllowed())
				{
					string valueString = StringUtils.TrimToNull(GetAttributeValue(element, VALUE));
					BigDecimal valueBigDecimal = null;
					try
					{
						valueBigDecimal = new BigDecimal(valueString);
					}
					catch (Exception)
					{
						RecordError("Value attribute is not a valid decimal number: " + valueString, element, context, result);
					}
					codedType.Value = valueBigDecimal;
				}
				else
				{
					LogValueNotAllowed(VALUE, element, context, result);
				}
			}
		}

		private void HandleQty(XmlElement element, CodedTypeR2<Code> codedType, ParseContext context, XmlToModelResult result)
		{
			if (element.HasAttribute(QTY))
			{
				if (QtyAllowed())
				{
					string qtyString = StringUtils.TrimToNull(GetAttributeValue(element, QTY));
					Int32? qtyInt = null;
					try
					{
						qtyInt = int.Parse(qtyString);
					}
					catch (Exception)
					{
						RecordError("Qty attribute is not a valid integer: " + qtyString, element, context, result);
					}
					codedType.Qty = qtyInt;
				}
				else
				{
					LogValueNotAllowed(QTY, element, context, result);
				}
			}
		}

		private void HandleOperator(XmlElement element, BareANY codedTypeAny, CodedTypeR2<Code> codedType, ParseContext context, 
			XmlToModelResult result)
		{
			// the operator is specified as defaulting to "I", but let's only allow process the attribute when not a nullFlavor (or if operator has been explicitly provided)
			if (element.HasAttribute("operator") || codedTypeAny.NullFlavor == null)
			{
				SetOperator @operator = this.operatorHelper.HandleOperator(element, context, result, new ANYImpl<object>());
				codedType.Operator = @operator;
			}
		}

		private void HandleSimpleValue(XmlElement element, CodedTypeR2<Code> codedType, ParseContext context, XmlToModelResult result
			)
		{
			string value = null;
			XmlNodeList childNodes = element.ChildNodes;
			XmlNode textNode = null;
			int numTextNodes = 0;
			foreach (XmlNode childNode in new XmlNodeListIterable(childNodes))
			{
				if (childNode.NodeType == System.Xml.XmlNodeType.Text)
				{
					if (StringUtils.IsNotBlank(childNode.Value))
					{
						if (textNode == null)
						{
							textNode = childNode;
						}
						numTextNodes++;
					}
				}
			}
			if (SimpleValueAllowed())
			{
				if (textNode != null)
				{
					value = textNode.Value.Trim();
				}
				if (numTextNodes > 1)
				{
					// too many text nodes
					RecordError("Expected " + context.Type + " to have at most one text node", element, context, result);
				}
			}
			else
			{
				if (numTextNodes > 0)
				{
					LogValueNotAllowed("text", element, context, result);
				}
			}
			codedType.SimpleValue = value;
		}

		private void HandleOriginalText(XmlElement element, CodedTypeR2<Code> codedType, ParseContext context, XmlToModelResult result
			)
		{
			if (OriginalTextAllowed())
			{
				IList<XmlElement> originalTextElements = GetNamedElements("originalText", element);
				if (originalTextElements.Count > 0)
				{
					if (originalTextElements.Count > 1)
					{
						RecordError("Only one original text element is allowed.", element, context, result);
					}
					ParseContext newContext = ParseContextImpl.Create("ED", context);
					BareANY parsedOriginalText = this.edParser.Parse(newContext, originalTextElements[0], result);
					if (parsedOriginalText != null)
					{
						codedType.OriginalText = (EncapsulatedData)parsedOriginalText.BareValue;
					}
				}
			}
			else
			{
				ValidateUnallowedChildNode(context.Type, element, result, "originalText");
			}
		}

		private void LogValueNotAllowed(string propertyName, XmlElement element, ParseContext context, XmlToModelResult result)
		{
			string message = System.String.Format("Relationships of type \"{0}\" are not allowed to have the \"{1}\" property.", context
				.Type, propertyName);
			RecordError(message, element, context, result);
		}

		private void RecordError(string message, XmlElement element, ParseContext context, XmlToModelResult result)
		{
			result.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, message, element));
		}

		private void HandleTranslation(XmlElement element, CodedTypeR2<Code> codedType, ParseContext context, XmlToModelResult result
			)
		{
			if (TranslationAllowed())
			{
				// we have no knowledge of what domain the translation may belong to (I imagine code system could allow for a reverse lookup at some point)
				ParseContext newContext = ParseContextImpl.Create("CD", typeof(Code), context);
				XmlNodeList translations = element.GetElementsByTagName("translation");
				for (int i = 0,  length = translations.Count; i < length; i++)
				{
					XmlElement translationElement = (XmlElement)translations.Item(i);
					// only want direct child node translations
					if (translationElement.ParentNode.Equals(element))
					{
						CodedTypeR2<Code> parsedTranslation = ParseTranslation(translationElement, newContext, result);
						if (parsedTranslation != null)
						{
							codedType.Translation.Add(parsedTranslation);
						}
					}
				}
			}
			else
			{
				ValidateUnallowedChildNode(context.Type, element, result, "translation");
			}
		}

		protected virtual CodedTypeR2<Code> ParseTranslation(XmlElement translationElement, ParseContext newContext, XmlToModelResult
			 result)
		{
			// leave this up to subclasses to define, if applicable
			return null;
		}

		private void HandleValidTime(XmlElement element, CodedTypeR2<Code> codedType, ParseContext context, XmlToModelResult result
			)
		{
			if (ValidTimeAllowed())
			{
				IList<XmlElement> validTimes = GetNamedElements("validTime", element);
				if (validTimes.Count > 0)
				{
					if (validTimes.Count > 1)
					{
						RecordError("Only one validTime is allowed", element, context, result);
					}
					XmlNode validTimeNode = validTimes[0];
					ParseContext newContext = ParseContextImpl.Create("IVL<TS>", typeof(HXIT<Code>), context);
					BareANY parsedValidTime = this.validTimeParser.Parse(newContext, Arrays.AsList(validTimeNode), result);
					if (parsedValidTime != null)
					{
						DateInterval dateInterval = (DateInterval)parsedValidTime.BareValue;
						codedType.ValidTime = dateInterval == null ? null : dateInterval.Interval;
					}
				}
			}
		}

		protected virtual bool CodeSystemAllowed()
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

		protected virtual bool DisplayNameAllowed()
		{
			return false;
		}

		protected virtual bool CodeSystemVersionAllowed()
		{
			return false;
		}

		protected virtual bool CodeSystemNameAllowed()
		{
			return false;
		}

		protected virtual bool SimpleValueAllowed()
		{
			return false;
		}

		protected virtual bool OriginalTextAllowed()
		{
			return false;
		}

		protected virtual bool TranslationAllowed()
		{
			return false;
		}

		protected virtual bool QualifierAllowed()
		{
			return false;
		}

		protected virtual bool ValidTimeAllowed()
		{
			return false;
		}
	}
}
