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
 * Last modified: $LastChangedDate: 2011-05-04 16:47:15 -0300 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
using System;
using System.Collections.Generic;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.J5goodies;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using ILOG.J2CsMapping.Collections.Generics;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	internal abstract class SetOrListElementParser : AbstractElementParser
	{
		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		public override BareANY Parse(ParseContext context, IList<XmlNode> nodes, XmlToModelResult xmlToModelResult)
		{
			string subType = GetSubType(context);
			ICollection<BareANY> list = GetCollectionType(context);
			foreach (XmlNode node in nodes)
			{
				ElementParser parser = ParserRegistry.GetInstance().Get(subType);
				if (parser != null)
				{
					BareANY result = parser.Parse(ParserContextImpl.Create(subType, GetSubTypeAsModelType(context), context.GetVersion(), context
						.GetDateTimeZone(), context.GetDateTimeTimeZone(), context.GetConformance()), ToList(node), xmlToModelResult);
					if (result != null)
					{
						list.Add(result);
					}
				}
				else
				{
					xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.INTERNAL_ERROR, "No parser type found for " + subType, (XmlElement
						)node));
					break;
				}
			}
			return WrapWithHl7DataType(context.Type, subType, list);
		}

		protected abstract BareANY WrapWithHl7DataType(string type, string subType, ICollection<BareANY> collection);

		protected abstract ICollection<BareANY> GetCollectionType(ParseContext context);

		private Type GetSubTypeAsModelType(ParseContext context)
		{
			Type returnType = GetReturnType(context);
			try
			{
				return Generics.GetParameterType(returnType);
			}
			catch (ArgumentException)
			{
				return returnType;
			}
		}

		private IList<XmlNode> ToList(XmlNode node)
		{
			return Arrays.AsList(node);
		}

		protected virtual string GetChildType()
		{
			return null;
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		private string GetSubType(ParseContext context)
		{
			string subType = Hl7DataTypeName.GetParameterizedType(context.Type);
			if (StringUtils.IsNotBlank(subType))
			{
				return subType;
			}
			else
			{
				throw new XmlToModelTransformationException("Cannot find the sub type for " + context.Type);
			}
		}
	}
}
