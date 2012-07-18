using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;

namespace Ca.Infoway.Messagebuilder.Xml.Validator
{
	public class MessageValidatorResult
	{
		private readonly IList<Hl7Error> hl7Errors = new List<Hl7Error>();

		public virtual IList<Hl7Error> GetHl7Errors()
		{
			return hl7Errors;
		}

		public virtual void AddHl7Error(Hl7Error hl7Error)
		{
			this.hl7Errors.Add(hl7Error);
		}
	}
}
