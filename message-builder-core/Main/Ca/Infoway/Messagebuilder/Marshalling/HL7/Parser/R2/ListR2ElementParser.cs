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
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2;
using Ca.Infoway.Messagebuilder.Platform;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2
{
	[DataTypeHandler(new string[] { "LIST", "BAG" })]
	internal class ListR2ElementParser : SetOrListElementParser
	{
		public ListR2ElementParser(ParserR2Registry parserRegistry) : base(parserRegistry, true)
		{
		}

		protected override BareANY WrapWithHl7DataType(string type, string subType, ICollection<BareANY> collection, ParseContext
			 context)
		{
			CollectionHelper result = CreateCollectionHelper(type, context.GetExpectedReturnType());
			bool adaptValue = AdaptValue(type);
			foreach (BareANY bareANY in collection)
			{
				if (adaptValue)
				{
					BareANY adaptedValue = GenericClassUtil.AdaptValue(bareANY);
					result.Add(adaptedValue);
				}
				else
				{
					result.Add(bareANY);
				}
			}
			return (BareANY)result;
		}

		private bool AdaptValue(string dataType)
		{
			Hl7DataTypeName type = Hl7DataTypeName.Create(dataType);
			string typeName = StringUtils.DeleteWhitespace(type.GetUnqualifiedVersion().ToString());
			return "LIST<SXCM<TS>>".Equals(typeName);
		}

		private CollectionHelper CreateCollectionHelper(string dataType, Type expectedReturnType)
		{
			Hl7DataTypeName type = Hl7DataTypeName.Create(dataType);
			string typeName = StringUtils.DeleteWhitespace(type.GetUnqualifiedVersion().ToString());
			CollectionHelper result = typeName.StartsWith("LIST") ? HandleListTypes(typeName, expectedReturnType) : HandleBagTypes(typeName
				);
			if (result == null)
			{
				throw new MarshallingException("Cannot create a data type construct for data type " + dataType);
			}
			return result;
		}

		private CollectionHelper HandleBagTypes(string typeName)
		{
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
							}
						}
					}
				}
			}
			return null;
		}

		private CollectionHelper HandleListTypes(string typeName, Type expectedReturnType)
		{
			if ("LIST<AD>".Equals(typeName))
			{
				return new LISTImpl<AD, PostalAddress>(typeof(ADImpl));
			}
			else
			{
				if ("LIST<GTS>".Equals(typeName))
				{
					return new LISTImpl<GTS, GeneralTimingSpecification>(typeof(GTSImpl));
				}
				else
				{
					if ("LIST<II>".Equals(typeName))
					{
						return new LISTImpl<II, Identifier>(typeof(IIImpl));
					}
					else
					{
						if ("LIST<PN>".Equals(typeName))
						{
							return new LISTImpl<PN, PersonName>(typeof(PNImpl));
						}
						else
						{
							if ("LIST<TEL>".Equals(typeName))
							{
								return new LISTImpl<TEL, TelecommunicationAddress>(typeof(TELImpl));
							}
							else
							{
								if ("LIST<ON>".Equals(typeName))
								{
									return new LISTImpl<ON, OrganizationName>(typeof(ONImpl));
								}
								else
								{
									if ("LIST<CD>".Equals(typeName))
									{
										return CodedTypeR2Helper.CreateCDList(expectedReturnType);
									}
									else
									{
										if ("LIST<CS>".Equals(typeName))
										{
											return CodedTypeR2Helper.CreateCSList(expectedReturnType);
										}
										else
										{
											if ("LIST<CE>".Equals(typeName))
											{
												return CodedTypeR2Helper.CreateCEList(expectedReturnType);
											}
											else
											{
												if ("LIST<SXCM<TS>>".Equals(typeName))
												{
													return GenericClassUtil.CreateSXCMR2List();
												}
												else
												{
													if ("LIST<ANY>".Equals(typeName))
													{
														return new LISTImpl<ANY<object>, object>(typeof(ANYImpl<object>));
													}
													else
													{
														if ("LIST<INT>".Equals(typeName))
														{
															return new LISTImpl<INT, Int32?>(typeof(INTImpl));
														}
														else
														{
															if ("LIST<PQ>".Equals(typeName))
															{
																return new LISTImpl<PQ, PhysicalQuantity>(typeof(PQImpl));
															}
															else
															{
																if ("LIST<ST>".Equals(typeName))
																{
																	return new LISTImpl<ST, string>(typeof(STImpl));
																}
																else
																{
																	if ("LIST<SXCMTSCDAR1>".Equals(typeName))
																	{
																		return new LISTImpl<SXCMTSCDAR1, MbDate>(typeof(SXCMTSCDAR1Impl));
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
					}
				}
			}
			return null;
		}

		protected override ICollection<BareANY> GetCollectionType(ParseContext context)
		{
			return new List<BareANY>();
		}
	}
}
