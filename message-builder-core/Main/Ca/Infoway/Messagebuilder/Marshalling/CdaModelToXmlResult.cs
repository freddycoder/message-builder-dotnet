using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	public class CdaModelToXmlResult : TransformErrors
	{
		private ModelToXmlResult delegate_;

		internal IList<TransformError> errors = new List<TransformError>();

		public CdaModelToXmlResult(ModelToXmlResult result)
		{
			this.delegate_ = result;
			foreach (Hl7Error error in result.GetHl7Errors())
			{
				errors.Add(new TransformError(error));
			}
		}

		public virtual string GetXmlDocument()
		{
			return this.delegate_.GetXmlMessage();
		}

		public virtual string GetXmlDocumentWithoutFormatting()
		{
			return this.delegate_.GetXmlMessageWithoutFormatting();
		}

		public virtual bool IsValid()
		{
			return this.delegate_.IsValid();
		}

		public virtual bool HasErrors()
		{
			return this.delegate_.HasErrors();
		}

		public virtual bool HasWarnings()
		{
			return this.delegate_.HasWarnings();
		}

		public virtual IList<TransformError> GetErrors()
		{
			return this.errors;
		}
	}
}
