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
using System.Text;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.Datatype.Nullflavor;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2;
using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2
{
	/// <summary>
	/// IVL - Interval (R2)
	/// Represents an Interval object as an element:
	/// &lt;value&gt;
	/// &lt;low value='2'/&gt;
	/// &lt;high value='4'/&gt;
	/// &lt;/value&gt;
	/// or:
	/// &lt;value&gt;
	/// &lt;width unit="d" value="15"/&gt;
	/// &lt;/value&gt;
	/// If an object is null, value is replaced by a nullFlavor.
	/// </summary>
	/// <remarks>
	/// IVL - Interval (R2)
	/// Represents an Interval object as an element:
	/// &lt;value&gt;
	/// &lt;low value='2'/&gt;
	/// &lt;high value='4'/&gt;
	/// &lt;/value&gt;
	/// or:
	/// &lt;value&gt;
	/// &lt;width unit="d" value="15"/&gt;
	/// &lt;/value&gt;
	/// If an object is null, value is replaced by a nullFlavor. So the element would
	/// look like this:
	/// &lt;element-name nullFlavor="something" /&gt;
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-IVL
	/// </remarks>
	internal abstract class IvlR2PropertyFormatter<T> : AbstractNullFlavorPropertyFormatter<Interval<T>>
	{
		private IvlValidationUtils ivlValidationUtils = new IvlValidationUtils();

		private static readonly string UNITS_OF_MEASURE_DAY = "d";

		protected static readonly string UNIT = "unit";

		protected static readonly string WIDTH = "width";

		protected static readonly string CENTRE = "center";

		protected static readonly string HIGH = "high";

		protected static readonly string LOW = "low";

		protected static readonly string VALUE = "value";

		protected override string FormatNonNullValue(FormatContext context, Interval<T> value, int indentLevel)
		{
			// need to use the alternate format method that has the BareANY object as a parameter
			throw new NotSupportedException();
		}

		protected override string FormatNonNullDataType(FormatContext context, BareANY bareAny, int indentLevel)
		{
			Interval<T> value = ExtractBareValue(bareAny);
			context = ValidateInterval(value, bareAny, context);
			StringBuilder buffer = new StringBuilder();
			if (value.Representation == Representation.SIMPLE)
			{
				QTYImpl<T> qty = (QTYImpl<T>)CreateQTY(value.Value, null);
				qty.Operator = value.Operator;
				buffer.Append(CreateElement(context, context.GetElementName(), qty, null, true, indentLevel));
			}
			else
			{
				buffer.Append(CreateElement(context, null, indentLevel, false, true));
				AppendIntervalBounds(context, value, buffer, indentLevel + 1);
				buffer.Append(CreateElementClosure(context, indentLevel, true));
			}
			return buffer.ToString();
		}

		private FormatContext ValidateInterval(Interval<T> value, BareANY bareAny, FormatContext context)
		{
			bool lowProvided = RepresentationUtil.HasLow(value.Representation) && (value.Low != null || value.LowNullFlavor != null);
			bool highProvided = RepresentationUtil.HasHigh(value.Representation) && (value.High != null || value.HighNullFlavor != null
				);
			bool centerProvided = RepresentationUtil.HasCentre(value.Representation) && (value.Centre != null || value.CentreNullFlavor
				 != null);
			bool widthProvided = RepresentationUtil.HasWidth(value.Representation) && (value.Width != null && (value.Width.Value != null
				 || value.Width.NullFlavor != null));
			IList<string> errors = this.ivlValidationUtils.ValidateCorrectElementsProvidedForR2(lowProvided, highProvided, centerProvided
				, widthProvided);
			RecordAnyErrors(errors, context);
			return context;
		}

		private void RecordAnyErrors(IList<string> errors, FormatContext context)
		{
			foreach (string error in errors)
			{
				RecordError(error, context);
			}
		}

		private void AppendIntervalBounds(FormatContext context, Interval<T> value, StringBuilder buffer, int indentLevel)
		{
			Representation rep = value.Representation;
			string low = RepresentationUtil.HasLow(rep) ? CreateElement(context, IvlR2PropertyFormatter<T>.LOW, CreateQTY(value.Low, 
				value.LowNullFlavor), GetInclusiveValue(value, true), false, indentLevel) : null;
			string high = RepresentationUtil.HasHigh(rep) ? CreateElement(context, IvlR2PropertyFormatter<T>.HIGH, CreateQTY(value.High
				, value.HighNullFlavor), GetInclusiveValue(value, false), false, indentLevel) : null;
			string centre = RepresentationUtil.HasCentre(rep) ? CreateElement(context, IvlR2PropertyFormatter<T>.CENTRE, CreateQTY(value
				.Centre, value.CentreNullFlavor), null, false, indentLevel) : null;
			string width = RepresentationUtil.HasWidth(rep) ? CreateWidthElement(context, IvlR2PropertyFormatter<T>.WIDTH, value.Width
				, indentLevel) : null;
			switch (rep)
			{
				case Representation.LOW_HIGH:
				{
					buffer.Append(low);
					buffer.Append(high);
					break;
				}

				case Representation.CENTRE:
				{
					buffer.Append(centre);
					break;
				}

				case Representation.HIGH:
				{
					buffer.Append(high);
					break;
				}

				case Representation.LOW:
				{
					buffer.Append(low);
					break;
				}

				case Representation.WIDTH:
				{
					buffer.Append(width);
					break;
				}

				case Representation.LOW_WIDTH:
				{
					buffer.Append(low);
					buffer.Append(width);
					break;
				}

				case Representation.LOW_CENTER:
				{
					buffer.Append(low);
					buffer.Append(centre);
					break;
				}

				case Representation.WIDTH_HIGH:
				{
					buffer.Append(width);
					buffer.Append(high);
					break;
				}

				case Representation.CENTRE_WIDTH:
				{
					buffer.Append(centre);
					buffer.Append(width);
					break;
				}

				case Representation.CENTRE_HIGH:
				{
					buffer.Append(centre);
					buffer.Append(high);
					break;
				}

				default:
				{
					break;
				}
			}
		}

		private Boolean? GetInclusiveValue(Interval<T> value, bool isLow)
		{
			if (value == null)
			{
				return null;
			}
			return isLow ? value.LowInclusive : value.HighInclusive;
		}

		private QTY<T> CreateQTY(T value, NullFlavor nullFlavor)
		{
			return new QTYImpl<T>(null, value, nullFlavor, StandardDataType.QTY);
		}

		protected virtual string GetDateDiffUnits(BareDiff diff)
		{
			if (diff is DiffWithQuantityAndUnit)
			{
				Ca.Infoway.Messagebuilder.Domainvalue.UnitsOfMeasureCaseSensitive unit = ((DiffWithQuantityAndUnit)diff).Unit;
				return unit != null ? unit.CodeValue : string.Empty;
			}
			else
			{
				return IvlR2PropertyFormatter<T>.UNITS_OF_MEASURE_DAY;
			}
		}

		protected virtual string FormatDateDiff(BareDiff diff)
		{
			if (diff is DiffWithQuantityAndUnit)
			{
				PhysicalQuantity quantity = ((DiffWithQuantityAndUnit)diff).ValueAsPhysicalQuantity;
				return quantity == null ? string.Empty : ObjectUtils.ToString(quantity.Quantity);
			}
			else
			{
				PlatformDate date;
				if (diff.BareValue is PlatformDate)
				{
					date = (PlatformDate)diff.BareValue;
				}
				else
				{
					date = ((MbDate)diff.BareValue).Value;
				}
				long l = date.Time / DateUtils.MILLIS_PER_DAY;
				return l.ToString();
			}
		}

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
					attributes = ToStringMap(IvlR2PropertyFormatter<T>.VALUE, FormatDateDiff(diff), IvlR2PropertyFormatter<T>.UNIT, GetDateDiffUnits
						(diff));
				}
				return CreateElement(name, attributes, indentLevel, true, true);
			}
			return null;
		}

		protected virtual string CreateWidthElement(FormatContext context, string name, BareDiff diff, int indentLevel)
		{
			if (IsTimestamp(context))
			{
				return CreateTimestampWidthElement(context, name, diff, indentLevel);
			}
			else
			{
				string type = Hl7DataTypeName.GetParameterizedType(context.Type);
				PropertyFormatter formatter = FormatterR2Registry.GetInstance().Get(type);
				if (formatter != null)
				{
					bool isSpecializationType = false;
					return formatter.Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(type, isSpecializationType
						, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY, Cardinality.Create("1"), name, context), WrapWithHl7DataType
						(type, diff), indentLevel);
				}
				else
				{
					throw new ModelToXmlTransformationException("No formatter found for " + type);
				}
			}
		}

		private BareANY WrapWithHl7DataType(string hl7DataType, BareDiff diff)
		{
			try
			{
				BareANY hl7Value = (BareANY)DataTypeFactory.CreateDataType(hl7DataType, true);
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

		protected virtual string CreateElement(FormatContext context, string name, QTY<T> value, Boolean? inclusive, bool isSxcm, 
			int indentLevel)
		{
			string type = Hl7DataTypeName.GetParameterizedType(context.Type);
			if (isSxcm)
			{
				type = "SXCM<" + type + ">";
			}
			PropertyFormatter formatter = FormatterR2Registry.GetInstance().Get(type);
			if (formatter != null)
			{
				bool isSpecializationType = false;
				FormatContext newContext = new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(type, isSpecializationType
					, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.POPULATED, Cardinality.Create("1"), name, context);
				string result = formatter.Format(newContext, value, indentLevel);
				if (inclusive != null)
				{
					// TM - small hack to add in the inclusive attribute (low/high) (operator, simple only, is already formatted by using the SXCM type)
					result = result.ReplaceFirst(" value=", " inclusive=\"" + inclusive.ToString().ToLower() + "\" value=");
				}
				return result;
			}
			else
			{
				throw new ModelToXmlTransformationException("No formatter found for " + type);
			}
		}

		private void RecordError(string message, FormatContext context)
		{
			string propertyPath = context.GetPropertyPath();
			context.GetModelToXmlResult().AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, message, propertyPath));
		}
	}
}
