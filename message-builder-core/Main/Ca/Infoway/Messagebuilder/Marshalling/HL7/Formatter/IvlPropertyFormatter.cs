using System;
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Datatype.Nullflavor;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	internal abstract class IvlPropertyFormatter<T> : AbstractIvlPropertyFormatter<T>
	{
		private static readonly string UNITS_OF_MEASURE_DAY = "d";

		protected virtual string GetDateDiffUnits(BareDiff diff)
		{
			if (diff is DateDiff)
			{
				Ca.Infoway.Messagebuilder.Domainvalue.UnitsOfMeasureCaseSensitive unit = ((DateDiff)diff).Unit;
				return unit != null ? unit.CodeValue : string.Empty;
			}
			else
			{
				return IvlPropertyFormatter<T>.UNITS_OF_MEASURE_DAY;
			}
		}

		protected virtual string FormatDateDiff(BareDiff diff)
		{
			if (diff is DateDiff)
			{
				PhysicalQuantity quantity = ((DateDiff)diff).ValueAsPhysicalQuantity;
				return quantity == null ? string.Empty : ObjectUtils.ToString(quantity.Quantity);
			}
			else
			{
				long l = ((PlatformDate)diff.BareValue).Time / DateUtils.MILLIS_PER_DAY;
				return l.ToString();
			}
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.ModelToXmlTransformationException"></exception>
		protected virtual string CreateTimestampWidthElement(FormatContext context, string name, BareDiff diff, int indentLevel)
		{
			if (diff != null)
			{
				IDictionary<string, string> attributes;
				if (diff is NullFlavorSupport && ((NullFlavorSupport)diff).HasNullFlavor())
				{
					NullFlavorSupport nullable = diff;
					attributes = ToStringMap(AbstractPropertyFormatter.NULL_FLAVOR_ATTRIBUTE_NAME, nullable.NullFlavor.CodeValue);
				}
				else
				{
					attributes = ToStringMap(AbstractIvlPropertyFormatter<T>.VALUE, FormatDateDiff(diff), AbstractIvlPropertyFormatter<T>.UNIT
						, GetDateDiffUnits(diff));
				}
				return CreateElement(name, attributes, indentLevel, true, true);
			}
			return null;
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.ModelToXmlTransformationException"></exception>
		protected override string CreateWidthElement(FormatContext context, string name, BareDiff diff, int indentLevel)
		{
			if (IsTimestamp(context))
			{
				return CreateTimestampWidthElement(context, name, diff, indentLevel);
			}
			else
			{
				string type = Hl7DataTypeName.GetParameterizedType(context.Type);
				PropertyFormatter formatter = FormatterRegistry.GetInstance().Get(type);
				if (formatter != null)
				{
					bool isSpecializationType = context.IsSpecializationType() && context.IsPassOnSpecializationType();
					return formatter.Format(new FormatContextImpl(name, type, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY, isSpecializationType
						, context.GetVersion(), context.GetDateTimeZone(), context.GetDateTimeTimeZone()), WrapWithHl7DataType(type, diff), indentLevel
						);
				}
				else
				{
					throw new ModelToXmlTransformationException("No formatter found for " + type);
				}
			}
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.ModelToXmlTransformationException"></exception>
		private BareANY WrapWithHl7DataType(string hl7DataType, BareDiff diff)
		{
			try
			{
				BareANY hl7Value = (BareANY)System.Activator.CreateInstance(DataTypeImplementationFactory.GetImplementation(hl7DataType));
				if (diff != null)
				{
					if (diff.BareValue != null)
					{
						((BareANYImpl)hl7Value).BareValue = diff.BareValue;
					}
					else
					{
						hl7Value.NullFlavor = diff.NullFlavor;
					}
				}
				return hl7Value;
			}
			catch (Exception e)
			{
				throw new ModelToXmlTransformationException("Unable to instantiate HL7 data type: " + hl7DataType, e);
			}
		}

		private bool IsTimestamp(FormatContext context)
		{
			return "TS".Equals(Hl7DataTypeName.Unqualify(Hl7DataTypeName.GetParameterizedType(context.Type)));
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.ModelToXmlTransformationException"></exception>
		protected override string CreateElement(FormatContext context, string name, QTY<T> value, int indentLevel)
		{
			string type = Hl7DataTypeName.GetParameterizedType(context.Type);
			PropertyFormatter formatter = FormatterRegistry.GetInstance().Get(type);
			if (formatter != null)
			{
				bool isSpecializationType = context.IsSpecializationType() && context.IsPassOnSpecializationType();
				return formatter.Format(new FormatContextImpl(name, type, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY, isSpecializationType
					, context.GetVersion(), context.GetDateTimeZone(), context.GetDateTimeTimeZone()), value, indentLevel);
			}
			else
			{
				throw new ModelToXmlTransformationException("No formatter found for " + type);
			}
		}
	}
}
