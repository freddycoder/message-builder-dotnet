using System;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	/// <summary>Provide a C#-compatible utility to create the necessary data types.</summary>
	/// <remarks>Provide a C#-compatible utility to create the necessary data types.</remarks>
	/// <author>Intelliware Development</author>
	internal class GenericDataTypeFactory
	{
		public static BareANY Create(string dataType)
		{
			Hl7DataTypeName type = Hl7DataTypeName.Create(dataType);
			string typeName = StringUtils.DeleteWhitespace(type.GetUnqualifiedVersion().ToString());
			if ("ANY".Equals(typeName))
			{
				return new ANYImpl<object>();
			}
			else
			{
				if ("AD".Equals(typeName))
				{
					return new ADImpl();
				}
				else
				{
					if ("BL".Equals(typeName))
					{
						return new BLImpl();
					}
					else
					{
						if ("ON".Equals(typeName))
						{
							return new ONImpl();
						}
						else
						{
							if ("SC".Equals(typeName))
							{
								return new SCImpl<Code>();
							}
							else
							{
								if ("TN".Equals(typeName))
								{
									return new TNImpl();
								}
								else
								{
									if ("GTS".Equals(typeName))
									{
										return new GTSImpl();
									}
									else
									{
										if ("II".Equals(typeName))
										{
											return new IIImpl();
										}
										else
										{
											if ("IVL<PQ>".Equals(typeName))
											{
												return new IVLImpl<PQ, Interval<PhysicalQuantity>>();
											}
											else
											{
												if ("IVL<TS>".Equals(typeName))
												{
													return new IVLImpl<TS, Interval<PlatformDate>>();
												}
												else
												{
													if ("IVL<INT>".Equals(typeName))
													{
														return new IVLImpl<INT, Interval<Int32?>>();
													}
													else
													{
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
																		return new SETImpl<PIVL, PeriodicIntervalTime>(typeof(PIVLImpl));
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
																																return new LISTImpl<AD, PostalAddress>(typeof(ADImpl));
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
