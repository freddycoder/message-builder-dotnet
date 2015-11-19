using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	/// <summary>Used to open up the visibility of the protected getAttributeNameValuePairs method in the parent class.</summary>
	/// <remarks>
	/// Used to open up the visibility of the protected getAttributeNameValuePairs method in the parent class.
	/// In C#, test classes cannot call protected methods unless they extend the class under test.
	/// </remarks>
	public interface TestableAbstractValueNullFlavorPropertyFormatter<V>
	{
		IDictionary<string, string> GetAttributeNameValuePairsForTest(FormatContext context, V t, BareANY bareAny);
	}
}
