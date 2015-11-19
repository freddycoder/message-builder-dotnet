using System;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	/// <summary>
	/// BL - Boolean
	/// Formats a Boolean into a BL element.
	/// </summary>
	/// <remarks>
	/// BL - Boolean
	/// Formats a Boolean into a BL element. The element looks like this:
	/// &lt;element-name value="true"/&gt;		&lt;!-- or value="false" --&gt;
	/// If a Boolean is null, value is replaced by a nullFlavor. So the element would look
	/// like this:
	/// &lt;element-name nullFlavor="something" /&gt;
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-BL
	/// </remarks>
	[DataTypeHandler("BL")]
	internal class BlPropertyFormatter : AbstractValueNullFlavorPropertyFormatter<Boolean?>
	{
		protected override string GetValue(Boolean? booleanValue, FormatContext context, BareANY bareAny)
		{
			return booleanValue.Value ? "true" : "false";
		}
	}
}
