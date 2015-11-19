using System;
using System.Text;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Platform;
using Ca.Infoway.Messagebuilder.Util.Text;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	public class EdContentRenderer
	{
		public virtual void RenderContent(EncapsulatedData encapsulatedData, StringBuilder buffer, int indentLevel, FormatContext
			 context, bool hasReferenceOrThumbnailOrDocument)
		{
			bool hasContent = (encapsulatedData.Content != null);
			if (hasReferenceOrThumbnailOrDocument && hasContent)
			{
				Indenter.IndentBuffer(buffer, indentLevel);
			}
			if (hasContent)
			{
				string textContent = encapsulatedData.Content;
				if (EdRepresentation.B64.Equals(encapsulatedData.Representation))
				{
					ValidateBase64Encoded("content", textContent, context);
				}
				buffer.Append(textContent);
			}
			if (hasReferenceOrThumbnailOrDocument && hasContent)
			{
				buffer.Append(SystemUtils.LINE_SEPARATOR);
			}
		}

		public virtual void ValidateBase64Encoded(string property, string stringToCheck, FormatContext context)
		{
			try
			{
				Base64.DecodeBase64String(stringToCheck);
			}
			catch (Exception)
			{
				RecordError("The ED property '" + property + "' does not appear to be Base64 encoded.", context);
			}
		}

		private void RecordError(string message, FormatContext context)
		{
			context.GetModelToXmlResult().AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, message, context.GetPropertyPath()));
		}
	}
}
