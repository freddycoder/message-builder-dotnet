using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	/// <summary>
	/// CV - Coded Value
	/// Formats a enum into a CV element.
	/// </summary>
	/// <remarks>
	/// CV - Coded Value
	/// Formats a enum into a CV element. The element looks like this:
	/// &lt;element-name code="RECENT" /&gt;
	/// According to CeRx: code has a limit of 20 characters. This limit is not
	/// currently enforced by this class.
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-CV
	/// CeRx states that attribute codeSystem is mandatory if code is specified. However,
	/// none of the sample messages do this and the HL7 definition of the message domains
	/// do not specify what the codeSystem is for different domains.
	/// There's also an originalText attribute that must be included if code is specified.
	/// Again, the HL7 domain definitions are of little help with that.
	/// Finally: there are two types of attributes that that use this datatype.
	/// CNE (coded no extensibility): code attribute is mandatory.
	/// CWE (coded with extensibility): code attribute is required (that is, must be supported
	/// but not mandatory. originalText may be specified if code is not entered.
	/// Currently this class does nothing with codeSystem or originalText. Therefore it is
	/// identical to the CS class.
	/// </remarks>
	[DataTypeHandler("CV")]
	internal class CvPropertyFormatter : AbstractCodePropertyFormatter
	{
		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.ModelToXmlTransformationException"></exception>
		internal override IDictionary<string, string> GetAttributeNameValuePairs(FormatContext context, Code code)
		{
			IDictionary<string, string> result = base.GetAttributeNameValuePairs(context, code);
			if (code != null)
			{
				if (StringUtils.IsNotBlank(code.CodeSystem))
				{
					result["codeSystem"] = code.CodeSystem;
				}
			}
			return result;
		}
	}
}
