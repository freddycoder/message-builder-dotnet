using System;
using System.Xml;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using ILOG.J2CsMapping.Util;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	internal abstract class UrgElementParser<T, V> : AbstractSingleElementParser<UncertainRange<V>> where T : QTY<V>
	{
		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		protected override UncertainRange<V> ParseNonNullNode(ParseContext context, XmlNode node, BareANY result, Type expectedReturnType
			, XmlToModelResult xmlToModelResult)
		{
			try
			{
				XmlElement low = (XmlElement)GetNamedChildNode(node, "low");
				XmlElement high = (XmlElement)GetNamedChildNode(node, "high");
				XmlElement center = (XmlElement)GetNamedChildNode(node, "center");
				XmlElement width = (XmlElement)GetNamedChildNode(node, "width");
				if (low != null && high != null)
				{
					try
					{
						return UncertainRange<object>.CreateLowHigh(CreateType(low), CreateType(high));
					}
					catch (ArgumentException e)
					{
						xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.SYNTAX_ERROR, e.Message, (XmlElement)node));
						return null;
					}
				}
				else
				{
					if (low != null && width != null)
					{
						return UncertainRangeFactory.CreateLowWidth<V>(CreateType(low), CreateDiffType(width));
					}
					else
					{
						if (high != null && width != null)
						{
							return UncertainRangeFactory.CreateWidthHigh<V>(CreateDiffType(width), CreateType(high));
						}
						else
						{
							if (center != null && width != null)
							{
								return UncertainRangeFactory.CreateCentreWidth<V>(CreateType(center), CreateDiffType(width));
							}
							else
							{
								if (low != null)
								{
									return UncertainRangeFactory.CreateLow<V>(CreateType(low));
								}
								else
								{
									if (high != null)
									{
										return UncertainRangeFactory.CreateHigh<V>(CreateType(high));
									}
									else
									{
										if (center != null)
										{
											return UncertainRangeFactory.CreateCentre<V>(CreateType(center));
										}
										else
										{
											if (width != null)
											{
												return UncertainRangeFactory.CreateWidth<V>(CreateDiffType(width));
											}
											else
											{
												return null;
											}
										}
									}
								}
							}
						}
					}
				}
			}
			catch (ParseException e)
			{
				throw new XmlToModelTransformationException(e.ToString());
			}
		}

		/// <exception cref="ILOG.J2CsMapping.Util.ParseException"></exception>
		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		protected virtual Diff<V> CreateDiffType(XmlElement width)
		{
			return new Diff<V>((V)CreateType(width));
		}

		/// <exception cref="ILOG.J2CsMapping.Util.ParseException"></exception>
		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		protected abstract V CreateType(XmlElement high);

		protected override BareANY DoCreateDataTypeInstance(string typeName)
		{
			return new URGImpl<T, V>();
		}
	}
}
