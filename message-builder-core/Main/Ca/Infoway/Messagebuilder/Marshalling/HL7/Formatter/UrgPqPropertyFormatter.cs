using System.Collections.Generic;
using System.Text;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[DataTypeHandler(new string[] { "URG<PQ>", "URG<PQ.BASIC>", "URG<PQ.TIME>", "URG<PQ.WIDTH>" })]
	internal class UrgPqPropertyFormatter : AbstractNullFlavorPropertyFormatter<UncertainRange<PhysicalQuantity>>
	{
		private static readonly string UNIT = "unit";

		private static readonly string WIDTH = "width";

		private static readonly string CENTRE = "center";

		private static readonly string HIGH = "high";

		private static readonly string LOW = "low";

		private static readonly string VALUE = "value";

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.ModelToXmlTransformationException"></exception>
		internal override string FormatNonNullValue(FormatContext context, UncertainRange<PhysicalQuantity> value, int indentLevel
			)
		{
			StringBuilder buffer = new StringBuilder();
			buffer.Append(CreateElement(context, null, indentLevel, false, true));
			AppendIntervalBounds(value, buffer);
			buffer.Append(CreateElementClosure(context, 0, true));
			return buffer.ToString();
		}

		private void AppendIntervalBounds(UncertainRange<PhysicalQuantity> value, StringBuilder buffer)
		{
			switch (value.Representation)
			{
				case Representation.LOW_HIGH:
				{
					buffer.Append(CreateElement(LOW, ToStringMap(value.Low), 1, true, true));
					buffer.Append(CreateElement(HIGH, ToStringMap(value.High), 1, true, true));
					break;
				}

				case Representation.CENTRE:
				{
					buffer.Append(CreateElement(CENTRE, ToStringMap(value.Centre), 1, true, true));
					break;
				}

				case Representation.HIGH:
				{
					buffer.Append(CreateElement(HIGH, ToStringMap(value.High), 1, true, true));
					break;
				}

				case Representation.LOW:
				{
					buffer.Append(CreateElement(LOW, ToStringMap(value.Low), 1, true, true));
					break;
				}

				case Representation.WIDTH:
				{
					buffer.Append(CreateElement(WIDTH, ToStringMap(value.Width), 1, true, true));
					break;
				}

				case Representation.LOW_WIDTH:
				{
					buffer.Append(CreateElement(LOW, ToStringMap(value.Low), 1, true, true));
					buffer.Append(CreateElement(WIDTH, ToStringMap(value.Width), 1, true, true));
					break;
				}

				case Representation.WIDTH_HIGH:
				{
					buffer.Append(CreateElement(WIDTH, ToStringMap(value.Width), 1, true, true));
					buffer.Append(CreateElement(HIGH, ToStringMap(value.Centre), 1, true, true));
					break;
				}

				case Representation.CENTRE_WIDTH:
				{
					buffer.Append(CreateElement(CENTRE, ToStringMap(value.Centre), 1, true, true));
					buffer.Append(CreateElement(WIDTH, ToStringMap(value.Width), 1, true, true));
					break;
				}

				default:
				{
					break;
				}
			}
		}

		private IDictionary<string, string> ToStringMap(Diff<PhysicalQuantity> diff)
		{
			return ToStringMap(diff.Value);
		}

		private IDictionary<string, string> ToStringMap(object quantity)
		{
			return ToStringMap((PhysicalQuantity)quantity);
		}

		private IDictionary<string, string> ToStringMap(PhysicalQuantity quantity)
		{
			IDictionary<string, string> map = new Dictionary<string, string>();
			map[VALUE] = quantity.Quantity.ToString();
			map[UNIT] = quantity.Unit.CodeValue;
			return map;
		}
	}
}
