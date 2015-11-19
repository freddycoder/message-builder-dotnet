using System;
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	internal class TestableIntPosPropertyFormatter : IntPosPropertyFormatter, TestableAbstractValueNullFlavorPropertyFormatter
		<Int32?>
	{
		public virtual IDictionary<string, string> GetAttributeNameValuePairsForTest(FormatContext context, Int32? t, BareANY bareAny
			)
		{
			return base.GetAttributeNameValuePairs(context, t, bareAny);
		}
	}
}
