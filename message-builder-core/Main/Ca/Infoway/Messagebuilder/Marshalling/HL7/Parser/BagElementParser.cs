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
using System.Collections.Generic;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[DataTypeHandler(new string[] { "BAG" })]
	internal class BagElementParser : SetOrListElementParser
	{
		public BagElementParser(ParserRegistry parserRegistry) : base(parserRegistry, false)
		{
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		public override BareANY Parse(ParseContext context, IList<XmlNode> nodes, XmlToModelResult xmlToModelResult)
		{
			xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "Data type \"" + context.Type + "\" is not part of the pan-Canadian standard"
				, CollUtils.IsEmpty(nodes) ? null : (XmlElement)nodes[0]));
			return base.Parse(context, nodes, xmlToModelResult);
		}

		protected override BareANY WrapWithHl7DataType(string type, string subType, ICollection<BareANY> collection, ParseContext
			 context)
		{
			CollectionHelper result = CreateCollectionHelper(type);
			foreach (BareANY bareANY in collection)
			{
				result.Add(bareANY);
			}
			return (BareANY)result;
		}

		private CollectionHelper CreateCollectionHelper(string dataType)
		{
			Hl7DataTypeName type = Hl7DataTypeName.Create(dataType);
			string typeName = StringUtils.DeleteWhitespace(type.GetUnqualifiedVersion().ToString());
			if ("BAG<AD>".Equals(typeName))
			{
				return new LISTImpl<AD, PostalAddress>(typeof(ADImpl));
			}
			else
			{
				if ("BAG<GTS>".Equals(typeName))
				{
					return new LISTImpl<GTS, GeneralTimingSpecification>(typeof(GTSImpl));
				}
				else
				{
					if ("BAG<II>".Equals(typeName))
					{
						return new LISTImpl<II, Identifier>(typeof(IIImpl));
					}
					else
					{
						if ("BAG<PN>".Equals(typeName))
						{
							return new LISTImpl<PN, PersonName>(typeof(PNImpl));
						}
						else
						{
							if ("BAG<ST>".Equals(typeName))
							{
								return new LISTImpl<ST, string>(typeof(STImpl));
							}
							else
							{
								if ("BAG<TEL>".Equals(typeName))
								{
									return new LISTImpl<TEL, TelecommunicationAddress>(typeof(TELImpl));
								}
								else
								{
									throw new MarshallingException("Cannot create a data type construct for data type " + dataType);
								}
							}
						}
					}
				}
			}
		}

		protected override ICollection<BareANY> GetCollectionType(ParseContext context)
		{
			return new List<BareANY>();
		}
	}
}
