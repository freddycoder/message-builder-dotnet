using System.Text;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	/// <summary>
	/// IVL - Interval
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
	/// IVL - Interval
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
	public abstract class AbstractIvlPropertyFormatter<T> : AbstractNullFlavorPropertyFormatter<Interval<T>>
	{
		protected static readonly string UNIT = "unit";

		protected static readonly string WIDTH = "width";

		protected static readonly string CENTRE = "center";

		protected static readonly string HIGH = "high";

		protected static readonly string LOW = "low";

		protected static readonly string VALUE = "value";

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.ModelToXmlTransformationException"></exception>
		internal override string FormatNonNullValue(FormatContext context, Interval<T> value, int indentLevel)
		{
			StringBuilder buffer = new StringBuilder();
			if (value.Representation == Representation.SIMPLE)
			{
				buffer.Append(CreateElement(context, context.GetElementName(), new QTYImpl<T>(value.Value), indentLevel));
			}
			else
			{
				buffer.Append(CreateElement(context, null, indentLevel, false, true));
				AppendIntervalBounds(context, value, buffer, indentLevel + 1);
				buffer.Append(CreateElementClosure(context, indentLevel, true));
			}
			return buffer.ToString();
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.ModelToXmlTransformationException"></exception>
		private void AppendIntervalBounds(FormatContext context, Interval<T> value, StringBuilder buffer, int indentLevel)
		{
			string low = CreateElement(context, AbstractIvlPropertyFormatter<T>.LOW, new QTYImpl<T>(value.Low), indentLevel);
			string high = CreateElement(context, AbstractIvlPropertyFormatter<T>.HIGH, new QTYImpl<T>(value.High), indentLevel);
			string centre = CreateElement(context, AbstractIvlPropertyFormatter<T>.CENTRE, new QTYImpl<T>(value.Centre), indentLevel);
			string width = CreateWidthElement(context, AbstractIvlPropertyFormatter<T>.WIDTH, value.Width, indentLevel);
			switch (value.Representation)
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

				default:
				{
					break;
				}
			}
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.ModelToXmlTransformationException"></exception>
		protected abstract string CreateWidthElement(FormatContext context, string name, BareDiff diff, int indentLevel);

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.ModelToXmlTransformationException"></exception>
		protected abstract string CreateElement(FormatContext context, string name, QTY<T> value, int indentLevel);
	}
}
