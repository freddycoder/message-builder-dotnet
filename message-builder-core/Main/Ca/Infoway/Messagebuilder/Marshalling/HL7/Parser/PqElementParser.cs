using System;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Terminology;
using Ca.Infoway.Messagebuilder.Util.Xml;
using ILOG.J2CsMapping.Text;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	/// <summary>
	/// PQ - Physical Quantity
	/// Parses a PQ element into a PhysicalQuantity.
	/// </summary>
	/// <remarks>
	/// PQ - Physical Quantity
	/// Parses a PQ element into a PhysicalQuantity. The element looks like this:
	/// 
	/// If a value is null, value is replaced by a null flavor. So the element would look
	/// like this:
	/// 
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-PQ
	/// CeRx specifies that the quantity is formatted as 99999999.99 with no leading or
	/// trailing zeros. This class ignores that restriction.
	/// Note: this may have to be modified once the PQ.DRUG and PQ.HEIGHTWEIGHT subclasses are described.
	/// </remarks>
	[DataTypeHandler("PQ")]
	internal class PqElementParser : AbstractSingleElementParser<PhysicalQuantity>
	{
		private const int MAXIMUM_INTEGER_DIGITS = 11;

		private const int MAXIMUM_FRACTION_DIGITS = 2;

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		protected override PhysicalQuantity ParseNonNullNode(ParseContext context, XmlNode node, BareANY result, Type expectedReturnType
			, XmlToModelResult xmlToModelResult)
		{
			return ParseNonNullElement(context, (XmlElement)node, xmlToModelResult);
		}

		private PhysicalQuantity ParseNonNullElement(ParseContext context, XmlElement element, XmlToModelResult xmlToModelResult)
		{
			BigDecimal value = ParseValue(context, element.GetAttribute("value"), element, xmlToModelResult);
			Ca.Infoway.Messagebuilder.Domainvalue.UnitsOfMeasureCaseSensitive unit = ParseUnit(context, element.GetAttribute("unit"), 
				element, xmlToModelResult);
			return (value != null) ? new PhysicalQuantity(value, unit) : null;
		}

		private BigDecimal ParseValue(ParseContext context, string valueAsString, XmlElement element, XmlToModelResult xmlToModelResult
			)
		{
			BigDecimal result = null;
			if (StringUtils.IsBlank(valueAsString))
			{
				xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, System.String.Format("No value provided for physical quantity ({0})"
					, XmlDescriber.DescribeSingleElement(element)), element));
			}
			else
			{
				try
				{
					result = new BigDecimal(valueAsString);
					CheckResultIsValidValue(result, element, xmlToModelResult);
				}
				catch (FormatException)
				{
					xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, System.String.Format("value \"{0}\" is not a valid decimal value ({1})"
						, valueAsString, XmlDescriber.DescribeSingleElement(element)), element));
				}
			}
			return result;
		}

		protected virtual void CheckResultIsValidValue(BigDecimal value, XmlElement element, XmlToModelResult xmlToModelResult)
		{
			if (value.Scale() > MAXIMUM_FRACTION_DIGITS)
			{
				xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, System.String.Format("PhysicalQuantity ({0}) can contain a maximum of {1} decimal places"
					, XmlDescriber.DescribeSingleElement(element), MAXIMUM_FRACTION_DIGITS), element));
			}
			else
			{
				if ((value.Precision() - value.Scale()) > MAXIMUM_INTEGER_DIGITS)
				{
					xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, System.String.Format("PhysicalQuantity ({0}) can contain a maximum of {1} integer places"
						, XmlDescriber.DescribeSingleElement(element), MAXIMUM_INTEGER_DIGITS), element));
				}
			}
		}

		private Ca.Infoway.Messagebuilder.Domainvalue.UnitsOfMeasureCaseSensitive ParseUnit(ParseContext context, string unitAsString
			, XmlElement element, XmlToModelResult xmlToModelResult)
		{
			if (StringUtils.IsNotBlank(unitAsString))
			{
				Ca.Infoway.Messagebuilder.Domainvalue.UnitsOfMeasureCaseSensitive unit = (Ca.Infoway.Messagebuilder.Domainvalue.UnitsOfMeasureCaseSensitive
					)CodeResolverRegistry.Lookup(GetUnitTypeByHl7Type(context), unitAsString);
				if (unit == null)
				{
					xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, System.String.Format("Unit \"{0}\" is not valid ({1})"
						, unitAsString, XmlDescriber.DescribeSingleElement(element)), element));
				}
				return unit;
			}
			else
			{
				return null;
			}
		}

		private Type GetUnitTypeByHl7Type(ParseContext context)
		{
			StandardDataType type = StandardDataType.GetByTypeName(context.Type);
			if (type == null)
			{
				// TODO: BCH: should we consider this an error case?
				return typeof(Ca.Infoway.Messagebuilder.Domainvalue.UnitsOfMeasureCaseSensitive);
			}
			else
			{
				if (StandardDataType.PQ_DRUG.Equals(type))
				{
					return typeof(x_DrugUnitsOfMeasure);
				}
				else
				{
					if (StandardDataType.PQ_HEIGHTWEIGHT.Equals(type))
					{
						return typeof(x_HeightOrWeightObservationUnitsOfMeasure);
					}
					else
					{
						if (StandardDataType.PQ_TIME.Equals(type))
						{
							return typeof(x_TimeUnitsOfMeasure);
						}
						else
						{
							if (StandardDataType.PQ_BASIC.Equals(type))
							{
								return typeof(x_BasicUnitsOfMeasure);
							}
							else
							{
								return typeof(Ca.Infoway.Messagebuilder.Domainvalue.UnitsOfMeasureCaseSensitive);
							}
						}
					}
				}
			}
		}

		protected override BareANY DoCreateDataTypeInstance(string typeName)
		{
			return new PQImpl();
		}
	}
}
