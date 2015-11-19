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
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2
{
	/// <summary>
	/// PQ - Physical Quantity (R2)
	/// Parses a PQ element into a PhysicalQuantity.
	/// </summary>
	/// <remarks>
	/// PQ - Physical Quantity (R2)
	/// Parses a PQ element into a PhysicalQuantity. The element looks like this:
	/// 
	/// If a value is null, value is replaced by a null flavor. So the element would look
	/// like this:
	/// 
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-PQ
	/// </remarks>
	[DataTypeHandler(new string[] { "PQ", "SXCM<PQ>" })]
	internal class PqR2ElementParser : AbstractSingleElementParser<PhysicalQuantity>
	{
		private readonly SxcmR2ElementParserHelper sxcmHelper = new SxcmR2ElementParserHelper();

		private readonly PqrR2ElementParser pqrParser = new PqrR2ElementParser();

		private readonly PqValidationUtils pqValidationUtils = new PqValidationUtils();

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		protected override PhysicalQuantity ParseNonNullNode(ParseContext context, XmlNode node, BareANY bareAny, Type expectedReturnType
			, XmlToModelResult xmlToModelResult)
		{
			XmlElement element = (XmlElement)node;
			BigDecimal value = this.pqValidationUtils.ValidateValueR2(element.GetAttribute("value"), context.GetVersion(), context.Type
				, false, element, null, xmlToModelResult);
			string unitAsString = element.GetAttribute("unit");
			Ca.Infoway.Messagebuilder.Domainvalue.UnitsOfMeasureCaseSensitive unit = null;
			if (StringUtils.IsNotBlank(unitAsString))
			{
				unit = this.pqValidationUtils.ValidateUnits(context.Type, unitAsString, element, null, xmlToModelResult, true);
			}
			// TM - MBR-285: units default to "1" if not specified; however, this part of the schemas will be ignored
			PhysicalQuantity physicalQuantity = (value != null || unit != null) ? new PhysicalQuantity(value, unit) : null;
			if (physicalQuantity != null)
			{
				HandleTranslations(element, physicalQuantity, context, xmlToModelResult);
			}
			this.sxcmHelper.HandleOperator((XmlElement)node, context, xmlToModelResult, (ANYMetaData)bareAny);
			// this is not the usual way of doing things; this is to make validation easier
			((BareANYImpl)bareAny).BareValue = physicalQuantity;
			return physicalQuantity;
		}

		private void HandleTranslations(XmlElement element, PhysicalQuantity pq, ParseContext context, XmlToModelResult result)
		{
			// we have no knowledge of what domain the translations may belong to (I imagine code system could allow for a reverse lookup at some point)
			ParseContext newContext = ParseContextImpl.Create("PQR", typeof(ANY<object>), context);
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
						pq.Translation.Add(parsedTranslation);
					}
				}
			}
		}

		private CodedTypeR2<Code> ParseTranslation(XmlElement translationElement, ParseContext newContext, XmlToModelResult result
			)
		{
			BareANY anyResult = this.pqrParser.Parse(newContext, translationElement, result);
			return anyResult == null ? null : (CodedTypeR2<Code>)anyResult.BareValue;
		}

		protected override BareANY DoCreateDataTypeInstance(string typeName)
		{
			return new PQImpl();
		}
	}
}
