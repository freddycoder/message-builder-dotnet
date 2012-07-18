using System;
using System.Collections.Generic;
using System.Text;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Util.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	/// <summary>
	/// PIVL - Periodic Interval of Time
	/// An interval of time that recurs periodically.
	/// </summary>
	/// <remarks>
	/// PIVL - Periodic Interval of Time
	/// An interval of time that recurs periodically. Periodic intervals have two
	/// properties, phase and period. The phase specifies the "interval prototype"
	/// that is repeated every period.
	/// &lt;effectiveTime xsi:type='PIVL_TS'&gt;
	/// &lt;phase&gt;
	/// &lt;low value='198709'/&gt;
	/// &lt;high value='198710'/&gt;
	/// &lt;/phase&gt;
	/// &lt;period value='1' unit='a'/&gt;
	/// &lt;/effectiveTime&gt;
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-PIVL
	/// </remarks>
	internal abstract class AbstractPivlPropertyFormatter : AbstractNullFlavorPropertyFormatter<PeriodicIntervalTime>
	{
		private static readonly string FREQUENCY = "frequency";

		private static readonly string UNIT = "unit";

		private static readonly string VALUE = "value";

		private static readonly string PERIOD = "period";

		private static readonly string PHASE = "phase";

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.ModelToXmlTransformationException"></exception>
		internal override string FormatNonNullValue(FormatContext context, PeriodicIntervalTime value, int indentLevel)
		{
			StringBuilder buffer = new StringBuilder();
			buffer.Append(CreateElement(context, GetAttributesMap(), indentLevel, false, true));
			AppendIntervalBounds(value, buffer, indentLevel + 1, context);
			buffer.Append(CreateElementClosure(context, indentLevel, true));
			return buffer.ToString();
		}

		protected virtual IDictionary<string, string> GetAttributesMap()
		{
			return null;
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.ModelToXmlTransformationException"></exception>
		private void AppendIntervalBounds(PeriodicIntervalTime value, StringBuilder buffer, int indentLevel, FormatContext context
			)
		{
			string period = CreateElement(PERIOD, value.Period, indentLevel);
			string phase = CreateElement(PHASE, value.Phase, indentLevel);
			switch (value.Representation)
			{
				case Representation.PERIOD:
				{
					buffer.Append(period);
					break;
				}

				case Representation.PHASE:
				{
					buffer.Append(phase);
					break;
				}

				case Representation.PERIOD_PHASE:
				{
					buffer.Append(period);
					buffer.Append(phase);
					break;
				}

				case Representation.FREQUENCY:
				{
					// Change for Saskatchewan
					bool isSask = SpecificationVersion.IsVersion(SpecificationVersion.V01R04_2_SK, context != null ? context.GetVersion() : null
						);
					if (isSask)
					{
						if (value is PeriodicIntervalTimeSk)
						{
							buffer.Append(CreateElementSk(FREQUENCY, value.Repetitions, ((PeriodicIntervalTimeSk)value).GetQuantitySk(), indentLevel, 
								context));
						}
					}
					else
					{
						buffer.Append(CreateElement(FREQUENCY, value.Repetitions, value.Quantity, indentLevel, context));
					}
					break;
				}

				default:
				{
					break;
				}
			}
		}

		// removed "break" to correct c# translation
		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.ModelToXmlTransformationException"></exception>
		private string CreateElementSk(string name, Int32? repetitions, Interval<PhysicalQuantity> quantity, int indentLevel, FormatContext
			 context)
		{
			if (repetitions != null && quantity != null)
			{
				StringBuilder buffer = new StringBuilder();
				buffer.Append(CreateElement(name, null, indentLevel, false, true));
				AppendSk(buffer, repetitions, quantity, indentLevel + 1, context);
				buffer.Append(XmlRenderingUtils.CreateEndElement(name, indentLevel, true));
				return buffer.ToString();
			}
			return null;
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.ModelToXmlTransformationException"></exception>
		private void AppendSk(StringBuilder buffer, Int32? repetitions, Interval<PhysicalQuantity> quantity, int indentLevel, FormatContext
			 context)
		{
			string type = "INT.NONNEG";
			string ivlPqType = "IVL<PQ>";
			PropertyFormatter intFormatter = FormatterRegistry.GetInstance().Get(type);
			PropertyFormatter ivlPqFormatter = FormatterRegistry.GetInstance().Get(ivlPqType);
			if (intFormatter != null && ivlPqFormatter != null)
			{
				buffer.Append(intFormatter.Format(new FormatContextImpl("numerator", type, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
					.MANDATORY, context.IsSpecializationType(), null, null, null), new INTImpl(repetitions), indentLevel));
				IVLImpl<PQ, Interval<PhysicalQuantity>> ivlImpl = new IVLImpl<PQ, Interval<PhysicalQuantity>>(quantity);
				buffer.Append(ivlPqFormatter.Format(new FormatContextImpl("denominator", ivlPqType, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
					.MANDATORY, context.IsSpecializationType(), null, null, null), ivlImpl, indentLevel));
			}
			else
			{
				throw new ModelToXmlTransformationException("No formatter found for " + (type == null ? type : ivlPqType));
			}
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.ModelToXmlTransformationException"></exception>
		private string CreateElement(string name, Int32? repetitions, PhysicalQuantity quantity, int indentLevel, FormatContext context
			)
		{
			if (repetitions != null && quantity != null)
			{
				StringBuilder buffer = new StringBuilder();
				buffer.Append(CreateElement(name, null, indentLevel, false, true));
				Append(buffer, repetitions, quantity, indentLevel + 1, context);
				buffer.Append(XmlRenderingUtils.CreateEndElement(name, indentLevel, true));
				return buffer.ToString();
			}
			return null;
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.ModelToXmlTransformationException"></exception>
		private void Append(StringBuilder buffer, Int32? repetitions, PhysicalQuantity quantity, int indentLevel, FormatContext context
			)
		{
			string type = "INT.NONNEG";
			PropertyFormatter formatter = FormatterRegistry.GetInstance().Get(type);
			if (formatter != null)
			{
				buffer.Append(formatter.Format(new FormatContextImpl("numerator", type, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY
					, context.IsSpecializationType(), null, null, null), new INTImpl(repetitions), indentLevel));
				IDictionary<string, string> attributes = ToStringMap(VALUE, Format(new DateDiff(quantity)), UNIT, GetUnits(new DateDiff(quantity
					)));
				buffer.Append(CreateElement(new FormatContextImpl("denominator", "PQ.TIME", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
					.MANDATORY, context.IsSpecializationType(), null, null, null), attributes, indentLevel, true, true));
			}
			else
			{
				throw new ModelToXmlTransformationException("No formatter found for " + type);
			}
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.ModelToXmlTransformationException"></exception>
		private string CreateElement(string name, DateDiff period, int indentLevel)
		{
			if (period != null)
			{
				IDictionary<string, string> attributes = ToStringMap(VALUE, Format(period), UNIT, GetUnits(period));
				return CreateElement(name, attributes, indentLevel, true, true);
			}
			return null;
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.ModelToXmlTransformationException"></exception>
		private string CreateElement(string name, Interval<PlatformDate> phase, int indentLevel)
		{
			if (phase != null)
			{
				return new IvlTsPropertyFormatter().Format(new FormatContextImpl(name, "IVL<TS.FULLDATE>", null), new IVLImpl<TS, Interval
					<PlatformDate>>(phase), indentLevel);
			}
			return null;
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.ModelToXmlTransformationException"></exception>
		protected abstract string Format(DateDiff diff);

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.ModelToXmlTransformationException"></exception>
		protected abstract string GetUnits(DateDiff diff);
	}
}
