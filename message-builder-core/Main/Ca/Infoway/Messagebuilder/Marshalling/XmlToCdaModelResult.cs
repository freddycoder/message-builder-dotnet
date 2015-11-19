using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	public class XmlToCdaModelResult : TransformErrors
	{
		private XmlToModelResult delegate_;

		internal IList<TransformError> errors = new List<TransformError>();

		internal XmlToCdaModelResult(XmlToModelResult result)
		{
			this.delegate_ = result;
			foreach (Hl7Error error in result.GetHl7Errors())
			{
				errors.Add(new TransformError(error));
			}
		}

		public virtual object GetClinicalDocumentObject()
		{
			return this.delegate_.GetMessageObject();
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
