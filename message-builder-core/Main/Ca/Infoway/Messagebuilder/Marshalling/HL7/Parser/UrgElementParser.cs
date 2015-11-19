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
 * Author:        $LastChangedBy: tmcgrady $
 * Last modified: $LastChangedDate: 2011-05-04 15:47:15 -0400 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
using System;
using System.Xml;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Util.Xml;
using ILOG.J2CsMapping.Collections.Generics;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	internal abstract class UrgElementParser<T, V> : AbstractSingleElementParser<UncertainRange<V>> where T : QTY<V>
	{
		protected override UncertainRange<V> ParseNonNullNode(ParseContext context, XmlNode node, BareANY result, Type expectedReturnType
			, XmlToModelResult xmlToModelResult)
		{
			// URGs are almost identical in function to IVLs; use IVL parser
			BareANY bareAny = GetIvlParser().Parse(ConvertContext(context), Arrays.AsList(node), xmlToModelResult);
			Interval<V> parsedInterval = (Interval<V>)bareAny.BareValue;
			Boolean? lowInclusive = GetInclusiveValue("low", context, node, xmlToModelResult);
			Boolean? highInclusive = GetInclusiveValue("high", context, node, xmlToModelResult);
			UncertainRange<V> urg = ConvertIntervalToUncertainRange(parsedInterval, lowInclusive, highInclusive);
			return urg;
		}

		private Boolean? GetInclusiveValue(string elementName, ParseContext context, XmlNode node, XmlToModelResult xmlToModelResult
			)
		{
			Boolean? result = null;
			XmlNodeList childNodes = node.ChildNodes;
			foreach (XmlNode child in new XmlNodeListIterable(childNodes))
			{
				if (elementName.EqualsIgnoreCase(child.Name))
				{
					string inclusive = GetAttributeValue(child, "inclusive");
					if (inclusive != null)
					{
						result = System.Convert.ToBoolean(inclusive);
					}
					if (inclusive != null && !"true".EqualsIgnoreCase(inclusive) && !"false".EqualsIgnoreCase(inclusive))
					{
						xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "The 'inclusive' attribute for URG." + elementName
							 + " must be 'true' or 'false'", (XmlElement)node));
					}
					else
					{
						if (inclusive != null && !context.Type.StartsWith("URG<PQ."))
						{
							xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "The 'inclusive' attribute for URG." + elementName
								 + " is not allowed for types of " + context.Type, (XmlElement)node));
						}
					}
					break;
				}
			}
			return result;
		}

		private ParseContext ConvertContext(ParseContext context)
		{
			string newType = "IVL<" + Hl7DataTypeName.GetParameterizedType(context.Type) + ">";
			return ParseContextImpl.CreateWithConstraints(newType, context);
		}

		private UncertainRange<V> ConvertIntervalToUncertainRange(Interval<V> parsedInterval, Boolean? lowInclusive, Boolean? highInclusive
			)
		{
			UncertainRange<V> urg = null;
			if (parsedInterval != null)
			{
				urg = new UncertainRange<V>(parsedInterval, lowInclusive, highInclusive);
			}
			return urg;
		}

		protected abstract ElementParser GetIvlParser();

		protected override BareANY DoCreateDataTypeInstance(string typeName)
		{
			return new URGImpl<T, V>();
		}
	}
}
