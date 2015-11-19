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
using Ca.Infoway.Messagebuilder.Platform;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[DataTypeHandler(new string[] { "SET" })]
	internal class SetElementParser : SetOrListElementParser
	{
		public SetElementParser(ParserRegistry parserRegistry) : base(parserRegistry, false)
		{
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
			if ("SET<CV>".Equals(typeName))
			{
				return new SETImpl<CV, Code>(typeof(CVImpl));
			}
			else
			{
				if ("SET<II>".Equals(typeName))
				{
					return new SETImpl<II, Identifier>(typeof(IIImpl));
				}
				else
				{
					if ("SET<PIVL>".Equals(typeName))
					{
						return new SETImpl<PIVL, PeriodicIntervalTime>(typeof(PIVLImpl));
					}
					else
					{
						if ("SET<PN>".Equals(typeName))
						{
							return new SETImpl<PN, PersonName>(typeof(PNImpl));
						}
						else
						{
							if ("SET<RTO<PQ,PQ>>".Equals(typeName))
							{
								return new SETImpl<RTO<PhysicalQuantity, PhysicalQuantity>, Ratio<PhysicalQuantity, PhysicalQuantity>>(typeof(RTOImpl<object
									, object>));
							}
							else
							{
								if ("SET<ST>".Equals(typeName))
								{
									return new SETImpl<ST, string>(typeof(STImpl));
								}
								else
								{
									if ("SET<TEL>".Equals(typeName))
									{
										return new SETImpl<TEL, TelecommunicationAddress>(typeof(TELImpl));
									}
									else
									{
										if ("SET<TS>".Equals(typeName))
										{
											return new SETImpl<TS, PlatformDate>(typeof(TSImpl));
										}
										else
										{
											if ("SET<CD>".Equals(typeName))
											{
												return new SETImpl<CD, Code>(typeof(CDImpl));
											}
											else
											{
												if ("SET<AD>".Equals(typeName))
												{
													return new SETImpl<AD, PostalAddress>(typeof(ADImpl));
												}
												else
												{
													if ("SET<TN>".Equals(typeName))
													{
														return new SETImpl<TN, TrivialName>(typeof(TNImpl));
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
						}
					}
				}
			}
		}

		protected override void ResultAlreadyExistsInCollection(BareANY result, XmlElement node, XmlToModelResult xmlToModelResult
			)
		{
			xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "Duplicate value not allowed for SET", (XmlElement
				)node));
		}

		protected override ICollection<BareANY> GetCollectionType(ParseContext context)
		{
			return new LinkedSet<BareANY>();
		}
	}
}
