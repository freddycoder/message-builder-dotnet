using System;
using System.Xml;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Util.Xml;
using ILOG.J2CsMapping.Util;

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
	/// 
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-IVL
	/// </remarks>
	internal abstract class AbstractIvlElementParser<T> : AbstractSingleElementParser<Interval<T>>
	{
		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		protected override Interval<T> ParseNonNullNode(ParseContext context, XmlNode node, BareANY parseResult, Type expectedReturnType
			, XmlToModelResult xmlToModelResult)
		{
			Interval<T> result = null;
			try
			{
				XmlElement low = (XmlElement)GetNamedChildNode(node, "low");
				XmlElement high = (XmlElement)GetNamedChildNode(node, "high");
				XmlElement center = (XmlElement)GetNamedChildNode(node, "center");
				XmlElement width = (XmlElement)GetNamedChildNode(node, "width");
				object lowType = low == null ? null : CreateType(context, low, xmlToModelResult).BareValue;
				object highType = high == null ? null : CreateType(context, high, xmlToModelResult).BareValue;
				object centerType = center == null ? null : CreateType(context, center, xmlToModelResult).BareValue;
				object widthType = width == null ? null : CreateDiffType(context, width, xmlToModelResult);
				if (lowType != null && highType != null)
				{
					result = IntervalFactory.CreateLowHigh<T>((T)lowType, (T)highType);
				}
				else
				{
					if (lowType != null && widthType != null)
					{
						result = IntervalFactory.CreateLowWidth<T>((T)lowType, (Diff<T>)widthType);
					}
					else
					{
						if (highType != null && widthType != null)
						{
							result = IntervalFactory.CreateWidthHigh<T>((Diff<T>)widthType, (T)highType);
						}
						else
						{
							if (centerType != null && widthType != null)
							{
								result = IntervalFactory.CreateCentreWidth<T>((T)centerType, (Diff<T>)widthType);
							}
							else
							{
								if (lowType != null)
								{
									result = IntervalFactory.CreateLow<T>((T)lowType);
								}
								else
								{
									if (highType != null)
									{
										result = IntervalFactory.CreateHigh<T>((T)highType);
									}
									else
									{
										if (centerType != null)
										{
											result = IntervalFactory.CreateCentre<T>((T)centerType);
										}
										else
										{
											if (widthType != null)
											{
												result = IntervalFactory.CreateWidth<T>((Diff<T>)widthType);
											}
											else
											{
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
			catch (ParseException)
			{
				xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "Unable to parse the interval date for element \""
					 + node.Name + "\"", (XmlElement)node));
			}
			return result;
		}

		/// <exception cref="ILOG.J2CsMapping.Util.ParseException"></exception>
		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		internal virtual BareDiff CreateDiffType(ParseContext context, XmlElement width, XmlToModelResult xmlToModelResult)
		{
			return new Diff<T>((T)CreateType(context, width, xmlToModelResult).BareValue);
		}

		/// <exception cref="ILOG.J2CsMapping.Util.ParseException"></exception>
		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		protected abstract BareANY CreateType(ParseContext context, XmlElement high, XmlToModelResult xmlToModelResult);
	}
}
