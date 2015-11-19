using System;
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2
{
	/// <summary>
	/// INT (R2)
	/// Represents a INT object as an element:
	/// &lt;element-name value="1234"&gt;&lt;/element-name&gt;
	/// If an object is null, value is replaced by a nullFlavor.
	/// </summary>
	/// <remarks>
	/// INT (R2)
	/// Represents a INT object as an element:
	/// &lt;element-name value="1234"&gt;&lt;/element-name&gt;
	/// If an object is null, value is replaced by a nullFlavor. So the element would look
	/// like this:
	/// &lt;element-name nullFlavor="something" /&gt;
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-INT
	/// </remarks>
	[DataTypeHandler(new string[] { "INT", "SXCM<INT>" })]
	internal class IntR2PropertyFormatter : AbstractValueNullFlavorPropertyFormatter<Int32?>
	{
		private readonly SxcmR2PropertyFormatterHelper sxcmHelper = new SxcmR2PropertyFormatterHelper();

		protected override string GetValue(Int32? integer, FormatContext context, BareANY bareAny)
		{
			return integer.ToString();
		}

		protected override void AddOtherAttributesIfNecessary(Int32? integer, IDictionary<string, string> attributes, FormatContext
			 context, BareANY bareAny)
		{
			this.sxcmHelper.HandleOperator(attributes, context, (ANYMetaData)bareAny);
			// this is a hack to allow for a single known instance where the base model has extended a data type (INT, in this case) to have an extra property 
			if (bareAny is ANYMetaData && ((ANYMetaData)bareAny).Unsorted)
			{
				attributes["unsorted"] = "true";
			}
		}
	}
}
