using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7
{
	public class ModelToXmlResult
	{
		private string xmlMessage;

		private readonly IList<Hl7Error> hl7Errors = new List<Hl7Error>();

		public virtual string GetXmlMessage()
		{
			return this.xmlMessage;
		}

		public virtual void SetXmlMessage(string xmlMessage)
		{
			this.xmlMessage = xmlMessage;
		}

		public virtual bool IsValid()
		{
			return this.hl7Errors.Count == 0;
		}

		public virtual void AddHl7Error(Hl7Error hl7Error)
		{
			this.hl7Errors.Add(hl7Error);
		}

		internal virtual bool HasCodeError()
		{
			return GetFirstCodeError() != null;
		}

		internal virtual Hl7Error GetFirstCodeError()
		{
			Hl7Error result = null;
			foreach (Hl7Error error in this.hl7Errors)
			{
				if (error.GetHl7ErrorCode() == Hl7ErrorCode.VALUE_NOT_IN_CODE_SYSTEM)
				{
					result = error;
					break;
				}
			}
			return result;
		}

		public virtual IList<Hl7Error> GetHl7Errors()
		{
			return hl7Errors;
		}
	}
}
