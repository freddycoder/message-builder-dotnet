using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2
{
	public class SxcmR2PropertyFormatterHelper
	{
		public virtual void HandleOperator(IDictionary<string, string> attributes, FormatContext context, ANYMetaData wrapper)
		{
			string type = context == null ? null : context.Type;
			bool isSxcm = (type != null && type.StartsWith("SXCM<"));
			bool hasOperator = wrapper != null && wrapper.Operator != null;
			if (hasOperator)
			{
				if (isSxcm)
				{
					attributes["operator"] = wrapper.Operator.CodeValue;
				}
				else
				{
					context.GetModelToXmlResult().AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "Operator property not applicable for type: "
						 + type, context.GetPropertyPath()));
				}
			}
		}
	}
}
