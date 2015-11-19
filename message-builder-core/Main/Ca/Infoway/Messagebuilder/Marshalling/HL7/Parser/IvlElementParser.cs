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
using Ca.Infoway.Messagebuilder.Resolver;
using Ca.Infoway.Messagebuilder.Util.Xml;
using Ca.Infoway.Messagebuilder.Xml;
using ILOG.J2CsMapping.Collections.Generics;
using ILOG.J2CsMapping.Text;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	/// <summary>
	/// IVL - Interval
	/// Parses an IVL element into a Interval.
	/// </summary>
	/// <remarks>
	/// IVL - Interval
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
	/// // TM - this format does not seem to be valid for MR2009, MR2007, or CeRx; it appears that MB does try to support it, however
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-IVL
	/// </remarks>
	internal abstract class IvlElementParser<T> : AbstractSingleElementParser<Interval<T>>
	{
		private IvlValidationUtils ivlValidationUtils;

		private readonly bool isUncertainRange;

		public IvlElementParser() : this(false)
		{
		}

		public IvlElementParser(bool isUncertainRange)
		{
			this.isUncertainRange = isUncertainRange;
			this.ivlValidationUtils = new IvlValidationUtils(this.isUncertainRange);
		}

		protected override Interval<T> ParseNonNullNode(ParseContext context, XmlNode node, BareANY parseResult, Type expectedReturnType
			, XmlToModelResult xmlToModelResult)
		{
			// go back and revert TS.FULLDATEWITHTIME validation check? (is there anything to revert?)
			context = HandleSpecializationType(context, node, xmlToModelResult);
			Interval<T> result = null;
			XmlElement low = (XmlElement)GetNamedChildNode(node, "low");
			XmlElement high = (XmlElement)GetNamedChildNode(node, "high");
			XmlElement center = (XmlElement)GetNamedChildNode(node, "center");
			XmlElement width = (XmlElement)GetNamedChildNode(node, "width");
			ValidateCorrectElementsProvided(low != null, high != null, center != null, width != null, (XmlElement)node, context, xmlToModelResult
				);
			BareANY lowAny = low == null ? null : CreateType(context, low, xmlToModelResult);
			object lowType = lowAny == null ? null : lowAny.BareValue;
			BareANY highAny = high == null ? null : CreateType(context, high, xmlToModelResult);
			object highType = highAny == null ? null : highAny.BareValue;
			BareANY centerAny = center == null ? null : CreateType(context, center, xmlToModelResult);
			object centerType = centerAny == null ? null : centerAny.BareValue;
			BareDiff widthType = width == null ? null : CreateDiffType(context, width, xmlToModelResult);
			DoOtherValidations(lowAny, highAny, centerAny, widthType, (XmlElement)node, context, xmlToModelResult);
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
														// try to parse a "simple" interval; this does not seem a valid approach for MR2009, MR2007, or CeRx (perhaps allowed within the XSDs?)
														object type = CreateType(context, (XmlElement)node, xmlToModelResult).BareValue;
														if (type == null)
														{
															xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.SYNTAX_ERROR, "\"Simple interval node: " + XmlDescriber.DescribePath
																(node) + " does not allow a null value\"", (XmlElement)node));
														}
														else
														{
															result = IntervalFactory.CreateSimple<T>((T)type);
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
			return result;
		}

		private ParseContext HandleSpecializationType(ParseContext context, XmlNode node, XmlToModelResult xmlToModelResult)
		{
			string type = context.Type;
			string specializationType = GetSpecializationType(node);
			IList<string> errors = new List<string>();
			string newType = this.ivlValidationUtils.ValidateSpecializationType(type, specializationType, errors);
			RecordAnyErrors(errors, (XmlElement)node, xmlToModelResult);
			if (!StringUtils.Equals(type, newType))
			{
				// replace the context with one using the specialization type
				context = ParseContextImpl.CreateWithConstraints(newType, context);
			}
			return context;
		}

		private void ValidateCorrectElementsProvided(bool lowProvided, bool highProvided, bool centerProvided, bool widthProvided
			, XmlElement element, ParseContext context, XmlToModelResult xmlToModelResult)
		{
			VersionNumber version = context.GetVersion();
			string type = context.Type;
			IList<string> errors = ivlValidationUtils.ValidateCorrectElementsProvided(type, version, lowProvided, highProvided, centerProvided
				, widthProvided);
			RecordAnyErrors(errors, element, xmlToModelResult);
		}

		private void DoOtherValidations(BareANY lowAny, BareANY highAny, BareANY centerAny, BareDiff widthType, XmlElement element
			, ParseContext context, XmlToModelResult xmlToModelResult)
		{
			string type = context.Type;
			NullFlavor lowNullFlavor = (lowAny == null ? null : lowAny.NullFlavor);
			NullFlavor centerNullFlavor = (centerAny == null ? null : centerAny.NullFlavor);
			NullFlavor highNullFlavor = (highAny == null ? null : highAny.NullFlavor);
			NullFlavor widthNullFlavor = (widthType == null ? null : widthType.NullFlavor);
			Ca.Infoway.Messagebuilder.Domainvalue.UnitsOfMeasureCaseSensitive widthTimeUnits = ((widthType != null && widthType is DateDiff
				) ? ((DateDiff)widthType).Unit : null);
			IList<string> errors = this.ivlValidationUtils.DoOtherValidations(type, lowNullFlavor, centerNullFlavor, highNullFlavor, 
				widthNullFlavor, widthTimeUnits);
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

		private BareANY CreateType(ParseContext context, XmlElement element, XmlToModelResult parseResult)
		{
			string type = GetParameterizedType(context);
			ElementParser parser = ParserRegistry.GetInstance().Get(type);
			if (parser != null)
			{
				return parser.Parse(ParseContextImpl.CreateWithConstraints(type, context), Arrays.AsList((XmlNode)element), parseResult);
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
				BareANY bareAny = CreateType(context, width, xmlToModelResult);
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
					StandardDataType diffType = StandardDataType.PQ_TIME;
					ElementParser parser = ParserRegistry.GetInstance().Get(diffType);
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
