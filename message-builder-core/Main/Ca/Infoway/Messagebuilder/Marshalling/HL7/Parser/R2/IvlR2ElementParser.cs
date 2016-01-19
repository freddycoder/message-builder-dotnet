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
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2;
using Ca.Infoway.Messagebuilder.Resolver;
using Ca.Infoway.Messagebuilder.Util.Xml;
using Ca.Infoway.Messagebuilder.Xml;
using ILOG.J2CsMapping.Collections.Generics;
using ILOG.J2CsMapping.Text;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2
{
	/// <summary>
	/// IVL - Interval (R2)
	/// Parses an IVL element into a Interval.
	/// </summary>
	/// <remarks>
	/// IVL - Interval (R2)
	/// Parses an IVL element into a Interval. The element looks like this:
	/// 
	/// 
	/// 
	/// 
	/// or:
	/// 
	/// 
	/// 
	/// or (confusingly):
	/// // "simple" interval
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-IVL
	/// </remarks>
	internal abstract class IvlR2ElementParser<T> : AbstractSingleElementParser<Interval<T>>
	{
		private IvlValidationUtils ivlValidationUtils;

		private readonly bool isUncertainRange;

		public IvlR2ElementParser() : this(false)
		{
		}

		public IvlR2ElementParser(bool isUncertainRange)
		{
			this.isUncertainRange = isUncertainRange;
			this.ivlValidationUtils = new IvlValidationUtils(this.isUncertainRange);
		}

		protected override Interval<T> ParseNonNullNode(ParseContext context, XmlNode node, BareANY parseResult, Type expectedReturnType
			, XmlToModelResult xmlToModelResult)
		{
			Interval<T> result = null;
			XmlElement low = (XmlElement)GetNamedChildNode(node, "low");
			XmlElement high = (XmlElement)GetNamedChildNode(node, "high");
			XmlElement center = (XmlElement)GetNamedChildNode(node, "center");
			XmlElement width = (XmlElement)GetNamedChildNode(node, "width");
			ValidateCorrectElementsProvided(low != null, high != null, center != null, width != null, (XmlElement)node, context, xmlToModelResult
				);
			BareANY lowAny = low == null ? null : CreateType(context, low, xmlToModelResult, false);
			object lowType = ExtractValue(lowAny);
			Boolean? lowInclusive = ExtractInclusive(context, low, xmlToModelResult);
			BareANY highAny = high == null ? null : CreateType(context, high, xmlToModelResult, false);
			object highType = ExtractValue(highAny);
			Boolean? highInclusive = ExtractInclusive(context, high, xmlToModelResult);
			BareANY centerAny = center == null ? null : CreateType(context, center, xmlToModelResult, false);
			object centerType = ExtractValue(centerAny);
			BareDiff widthType = width == null ? null : CreateDiffType(context, width, xmlToModelResult);
			if (lowAny != null && highAny != null)
			{
				result = IntervalFactory.CreateLowHigh<T>((T)lowType, (T)highType, lowAny.NullFlavor, highAny.NullFlavor);
			}
			else
			{
				if (lowAny != null && widthType != null)
				{
					result = IntervalFactory.CreateLowWidth<T>((T)lowType, (Diff<T>)widthType, lowAny.NullFlavor);
				}
				else
				{
					if (highAny != null && widthType != null)
					{
						result = IntervalFactory.CreateWidthHigh<T>((Diff<T>)widthType, (T)highType, highAny.NullFlavor);
					}
					else
					{
						if (centerAny != null && widthType != null)
						{
							result = IntervalFactory.CreateCentreWidth<T>((T)centerType, (Diff<T>)widthType, centerAny.NullFlavor);
						}
						else
						{
							if (centerAny != null && lowAny != null)
							{
								result = IntervalFactory.CreateLowCentre<T>((T)lowType, (T)centerType, lowAny.NullFlavor, centerAny.NullFlavor);
							}
							else
							{
								if (centerAny != null && highAny != null)
								{
									result = IntervalFactory.CreateCentreHigh<T>((T)centerType, (T)highType, centerAny.NullFlavor, highAny.NullFlavor);
								}
								else
								{
									if (lowAny != null)
									{
										result = IntervalFactory.CreateLow<T>((T)lowType, lowAny.NullFlavor);
									}
									else
									{
										if (highAny != null)
										{
											result = IntervalFactory.CreateHigh<T>((T)highType, highAny.NullFlavor);
										}
										else
										{
											if (centerAny != null)
											{
												result = IntervalFactory.CreateCentre<T>((T)centerType, centerAny.NullFlavor);
											}
											else
											{
												if (widthType != null)
												{
													result = IntervalFactory.CreateWidth<T>((Diff<T>)widthType);
												}
												else
												{
													if (low == null && high == null && center == null && width == null)
													{
														// only treat this as a "simple" interval if no other interval elements were provided (even if they were in error)
														// try to parse a "simple" interval
														BareANY simpleAny = CreateType(context, (XmlElement)node, xmlToModelResult, true);
														object type = ExtractValue(simpleAny);
														if (type == null)
														{
															xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.SYNTAX_ERROR, "\"Simple interval node: " + XmlDescriber.DescribePath
																(node) + " does not allow a null value\"", (XmlElement)node));
														}
														else
														{
															result = IntervalFactory.CreateSimple<T>((T)type, ((ANYMetaData)simpleAny).Operator);
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
			if (result != null)
			{
				result.LowInclusive = lowInclusive;
				result.HighInclusive = highInclusive;
			}
			return result;
		}

		// subclasses may want to override this functionality
		protected virtual object ExtractValue(BareANY any)
		{
			return any == null ? null : any.BareValue;
		}

		private Boolean? ExtractInclusive(ParseContext context, XmlElement element, XmlToModelResult xmlToModelResult)
		{
			Boolean? inclusive = null;
			if (element != null)
			{
				string inclusiveString = GetAttributeValue(element, "inclusive");
				inclusive = inclusiveString == null ? true : Ca.Infoway.Messagebuilder.BooleanUtils.ValueOf(inclusiveString);
			}
			return inclusive;
		}

		private void ValidateCorrectElementsProvided(bool lowProvided, bool highProvided, bool centerProvided, bool widthProvided
			, XmlElement element, ParseContext context, XmlToModelResult xmlToModelResult)
		{
			IList<string> errors = ivlValidationUtils.ValidateCorrectElementsProvidedForR2(lowProvided, highProvided, centerProvided, 
				widthProvided);
			RecordAnyErrors(errors, element, xmlToModelResult);
		}

		private void RecordAnyErrors(IList<string> errors, XmlElement element, XmlToModelResult xmlToModelResult)
		{
			foreach (string error in errors)
			{
				RecordError(error, element, xmlToModelResult);
			}
		}

		private void RecordError(string message, XmlElement element, XmlToModelResult xmlToModelResult)
		{
			xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, message + " (" + XmlDescriber.DescribeSingleElement
				(element) + ")", element));
		}

		protected override BareANY DoCreateDataTypeInstance(string typeName)
		{
			return new IVLImpl<QTY<T>, Interval<T>>();
		}

		private BareANY CreateType(ParseContext context, XmlElement element, XmlToModelResult parseResult, bool isSxcm)
		{
			string type = GetParameterizedType(context);
			if (isSxcm)
			{
				type = "SXCM<" + type + ">";
			}
			ElementParser parser = ParserR2Registry.GetInstance().Get(type);
			if (parser != null)
			{
				ParseContext newContext = ParseContextImpl.CreateWithConstraints(type, context);
				BareANY parsedValue = parser.Parse(newContext, Arrays.AsList((XmlNode)element), parseResult);
				return parsedValue;
			}
			else
			{
				parseResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, System.String.Format("Cannot find a parser for type {0}"
					, type), element));
				return null;
			}
		}

		private string GetParameterizedType(ParseContext context)
		{
			return Hl7DataTypeName.GetParameterizedType(context.Type);
		}

		internal virtual BareDiff CreateDiffType(ParseContext context, XmlElement width, XmlToModelResult xmlToModelResult)
		{
			if (IsTimestampType(context))
			{
				return CreateDateDiff(context, width, xmlToModelResult);
			}
			else
			{
				BareANY bareAny = CreateType(context, width, xmlToModelResult, false);
				if (bareAny.HasNullFlavor())
				{
					return new Diff<T>(bareAny.NullFlavor);
				}
				else
				{
					return new Diff<T>((T)bareAny.BareValue);
				}
			}
		}

		private Diff<PlatformDate> CreateDateDiff(ParseContext context, XmlElement width, XmlToModelResult xmlToModelResult)
		{
			Diff<PlatformDate> result = null;
			if (GetAttributeValue(width, NullFlavorHelper.NULL_FLAVOR_ATTRIBUTE_NAME) != null)
			{
				result = ParseNullWidthNode(width);
			}
			else
			{
				try
				{
					StandardDataType diffType = StandardDataType.PQ;
					ElementParser parser = ParserR2Registry.GetInstance().Get(diffType);
					if (parser != null)
					{
						ParseContext subContext = ParseContextImpl.Create(diffType.Type, typeof(PhysicalQuantity), Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
							.POPULATED, Cardinality.Create("1"), context);
						PhysicalQuantity quantity = (PhysicalQuantity)parser.Parse(subContext, Arrays.AsList((XmlNode)width), xmlToModelResult).BareValue;
						// though in some PQ cases units can be null, this situation does not seem to make sense for PQ.TIME
						if (quantity != null && quantity.Quantity != null && quantity.Unit != null)
						{
							result = new DateDiff(quantity);
						}
					}
					else
					{
						xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "Cannot find a parser for " + diffType.Type, width
							));
					}
				}
				catch (XmlToModelTransformationException e)
				{
					xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, e.Message, width));
				}
			}
			return result;
		}

		private Diff<PlatformDate> ParseNullWidthNode(XmlElement width)
		{
			string nullFlavor = width.GetAttribute(NullFlavorHelper.NULL_FLAVOR_ATTRIBUTE_NAME);
			return new DateDiff(CodeResolverRegistry.Lookup<NullFlavor>(nullFlavor));
		}

		private bool IsTimestampType(ParseContext context)
		{
			string type = GetParameterizedType(context);
			return "TS".Equals(Hl7DataTypeName.Unqualify(type));
		}
	}
}
