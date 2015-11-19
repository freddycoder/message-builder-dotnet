using System;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[DataTypeHandler("URG<PQ>")]
	internal class UrgPqPropertyFormatter : AbstractNullFlavorPropertyFormatter<UncertainRange<PhysicalQuantity>>
	{
		internal IvlPqPropertyFormatter formatter = new IvlPqPropertyFormatter();

		protected override string FormatNonNullDataType(FormatContext context, BareANY dataType, int indentLevel)
		{
			UncertainRange<PhysicalQuantity> value = (UncertainRange<PhysicalQuantity>)dataType.BareValue;
			// convert URG to an IVL and use IVL formatter (loses any inclusive info; we'll pull that out later)
			Interval<PhysicalQuantity> convertedInterval = IntervalFactory.CreateFromUncertainRange(value);
			IVLImpl<PQ, Interval<PhysicalQuantity>> convertedHl7Interval = new IVLImpl<PQ, Interval<PhysicalQuantity>>(convertedInterval
				);
			FormatContext ivlContext = new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(context.Type.Replace
				("URG", "IVL"), context.IsSpecializationType(), context);
			string xml = this.formatter.Format(ivlContext, convertedHl7Interval, indentLevel);
			xml = ChangeAnyIvlRemnants(xml);
			xml = AddOriginalText(xml, dataType, indentLevel);
			// add in inclusive attributes if necessary
			if (value.LowInclusive != null)
			{
				xml = AddInclusiveAttribute(xml, "low", value.LowInclusive);
			}
			if (value.HighInclusive != null)
			{
				xml = AddInclusiveAttribute(xml, "high", value.HighInclusive);
			}
			return xml;
		}

		private string AddOriginalText(string xml, BareANY dataType, int indentLevel)
		{
			// TM - RM20416: R2 URG<PQ> now has an explicit OT element (as opposed to being within the inner PQ.LAB)
			string originalText = ((ANYMetaData)dataType).OriginalText;
			if (StringUtils.IsNotBlank(originalText))
			{
				string otElement = CreateElement("originalText", null, indentLevel + 1, false, false);
				otElement += XmlStringEscape.Escape(originalText);
				otElement += CreateElementClosure("originalText", 0, false);
				int indexOf = xml.IndexOf(">");
				xml = Ca.Infoway.Messagebuilder.StringUtils.Substring(xml, 0, indexOf + 2) + otElement + Ca.Infoway.Messagebuilder.StringUtils.Substring
					(xml, indexOf + 2);
			}
			return xml;
		}

		protected override string FormatNonNullValue(FormatContext context, UncertainRange<PhysicalQuantity> value, int indentLevel
			)
		{
			// unused
			throw new NotSupportedException();
		}

		private string AddInclusiveAttribute(string xml, string elementName, Boolean? inclusive)
		{
			string searchString = "<" + elementName + " ";
			int elementIndex = xml.IndexOf(searchString);
			if (elementIndex >= 0)
			{
				string first = Ca.Infoway.Messagebuilder.StringUtils.Substring(xml, 0, elementIndex + searchString.Length);
				string last = Ca.Infoway.Messagebuilder.StringUtils.Substring(xml, elementIndex + searchString.Length);
				xml = first + "inclusive=\"" + inclusive.ToString().ToLower() + "\" " + last;
			}
			return xml;
		}

		private string ChangeAnyIvlRemnants(string xml)
		{
			xml = xml.Replace(" specializationType=\"IVL_", " specializationType=\"URG_");
			return xml.Replace(" xsi:type=\"IVL_", " xsi:type=\"URG_");
		}
	}
}
