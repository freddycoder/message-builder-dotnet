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
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Util.Xml;
using ILOG.J2CsMapping.Text;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2
{
	public abstract class AbstractRtoR2ElementParser<N, D> : AbstractSingleElementParser<Ratio<N, D>>
	{
		protected override Ratio<N, D> ParseNonNullNode(ParseContext context, XmlNode node, BareANY parseResult, Type expectedReturnType
			, XmlToModelResult xmlToModelResult)
		{
			Ratio<N, D> result = new Ratio<N, D>();
			IList<Hl7DataTypeName> innerTypes = Hl7DataTypeName.Create(context.Type).GetInnerTypes();
			if (innerTypes.Count != 2)
			{
				// this should never happen unless a message set is incorrect; ok to abort with exception (parsing will continue after this datatype) 
				throw new XmlToModelTransformationException("RTO data type must have two inner types. Type " + context.Type + " has " + innerTypes
					.Count + ".");
			}
			bool numeratorFound = false;
			bool denominatorFound = false;
			XmlNodeList childNodes = node.ChildNodes;
			foreach (XmlNode childNode in new XmlNodeListIterable(childNodes))
			{
				if (childNode is XmlElement)
				{
					XmlElement element = (XmlElement)childNode;
					string name = NodeUtil.GetLocalOrTagName(element);
					if ("numerator".Equals(name))
					{
						numeratorFound = true;
						result.Numerator = GetNumeratorValue(element, innerTypes[0].ToString(), context, xmlToModelResult);
						if (denominatorFound)
						{
							RecordError("Denominator must come after numerator", context, element, xmlToModelResult);
						}
					}
					else
					{
						if ("denominator".Equals(name))
						{
							denominatorFound = true;
							result.Denominator = GetDenominatorValue(element, innerTypes[1].ToString(), context, xmlToModelResult);
						}
					}
				}
			}
			CheckNumerator(result, numeratorFound, node, context, xmlToModelResult);
			CheckDenominator(result, denominatorFound, node, context, xmlToModelResult);
			return result;
		}

		private void CheckDenominator(Ratio<N, D> result, bool denominatorFound, XmlNode node, ParseContext context, XmlToModelResult
			 xmlToModelResult)
		{
			if (denominatorFound)
			{
				if (result.Denominator is PhysicalQuantity)
				{
					PhysicalQuantity pqDenominator = (PhysicalQuantity)(object)result.Denominator;
					//cast to Object for .NET translation
					if (BigDecimal.ZERO.Equals(pqDenominator.Quantity))
					{
						RecordError("Denominator value can not be zero.", context, node, xmlToModelResult);
					}
					else
					{
						if (pqDenominator.Quantity == null)
						{
							// schema states that the pq values default to "1", without reference to which property; assuming this to mean quantity
							pqDenominator.Quantity = BigDecimal.ONE;
						}
					}
				}
			}
			else
			{
				RecordMissingElementError("Denominator", context, node, xmlToModelResult);
			}
		}

		private void CheckNumerator(Ratio<N, D> result, bool numeratorFound, XmlNode node, ParseContext context, XmlToModelResult
			 xmlToModelResult)
		{
			if (numeratorFound)
			{
				if (result.Numerator is PhysicalQuantity)
				{
					PhysicalQuantity pqNumerator = (PhysicalQuantity)result.BareNumerator;
					if (pqNumerator.Quantity == null)
					{
						// schema states that the pq values default to "1", without reference to which property; assuming this to mean quantity
						pqNumerator.Quantity = BigDecimal.ONE;
					}
				}
			}
			else
			{
				RecordMissingElementError("Numerator", context, node, xmlToModelResult);
			}
		}

		private void RecordMissingElementError(string elementName, ParseContext context, XmlNode node, XmlToModelResult xmlToModelResult
			)
		{
			string message = System.String.Format("{0} is mandatory for type {1} ({2})", elementName, context.Type, XmlDescriber.DescribeSingleElement
				((XmlElement)node));
			RecordError(message, context, node, xmlToModelResult);
		}

		protected virtual void RecordError(string message, ParseContext context, XmlNode node, XmlToModelResult xmlToModelResult)
		{
			xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, message, (XmlElement)node));
		}

		protected abstract N GetNumeratorValue(XmlElement element, string type, ParseContext context, XmlToModelResult xmlToModelResult
			);

		protected abstract D GetDenominatorValue(XmlElement element, string type, ParseContext context, XmlToModelResult xmlToModelResult
			);

		protected override BareANY DoCreateDataTypeInstance(string typeName)
		{
			return new RTOImpl<N, D>();
		}
	}
}
