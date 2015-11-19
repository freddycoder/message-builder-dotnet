using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2
{
	/// <summary>
	/// REAL - BigDecimal (R2)
	/// Represents a REAL object as an element:
	/// &lt;element-name value="0.1234"&gt;&lt;/element-name&gt;
	/// If an object is null, value is replaced by a nullFlavor.
	/// </summary>
	/// <remarks>
	/// REAL - BigDecimal (R2)
	/// Represents a REAL object as an element:
	/// &lt;element-name value="0.1234"&gt;&lt;/element-name&gt;
	/// If an object is null, value is replaced by a nullFlavor. So the element would look
	/// like this:
	/// &lt;element-name nullFlavor="something" /&gt;
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-REAL
	/// </remarks>
	[DataTypeHandler(new string[] { "REAL", "SXCM<REAL>" })]
	public class RealR2PropertyFormatter : AbstractValueNullFlavorPropertyFormatter<BigDecimal>
	{
		private readonly SxcmR2PropertyFormatterHelper sxcmHelper = new SxcmR2PropertyFormatterHelper();

		protected override string GetValue(BigDecimal bigDecimal, FormatContext context, BareANY bareAny)
		{
			return bigDecimal.ToString();
		}

		protected override void AddOtherAttributesIfNecessary(BigDecimal v, IDictionary<string, string> attributes, FormatContext
			 context, BareANY bareAny)
		{
			this.sxcmHelper.HandleOperator(attributes, context, (ANYMetaData)bareAny);
		}
	}
}
