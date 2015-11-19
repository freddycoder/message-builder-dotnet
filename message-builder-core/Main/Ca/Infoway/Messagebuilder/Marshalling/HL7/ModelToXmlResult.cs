using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Error;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7
{
	public class ModelToXmlResult : Hl7Errors
	{
		private string xmlMessage;

		private readonly IList<Hl7Error> hl7Errors = new List<Hl7Error>();

		public virtual string GetXmlMessage()
		{
			return this.xmlMessage;
		}

		public virtual string GetXmlMessageWithoutFormatting()
		{
			return this.xmlMessage == null ? null : System.Text.RegularExpressions.Regex.Replace(this.xmlMessage, ">\\s+<", "><");
		}

		public virtual void SetXmlMessage(string xmlMessage)
		{
			this.xmlMessage = xmlMessage;
		}

		public virtual bool HasErrors()
		{
			return HasErrorLevel(ErrorLevel.ERROR);
		}

		public virtual bool HasWarnings()
		{
			return HasErrorLevel(ErrorLevel.WARNING);
		}

		public virtual bool IsValid()
		{
			return !(HasErrors() || HasWarnings());
		}

		private bool HasErrorLevel(ErrorLevel level)
		{
			foreach (Hl7Error hl7Error in this.hl7Errors)
			{
				if (hl7Error.GetHl7ErrorLevel() == level)
				{
					return true;
				}
			}
			return false;
		}

		public virtual void AddHl7Error(Hl7Error hl7Error)
		{
			this.hl7Errors.Add(hl7Error);
		}

		public virtual IList<Hl7Error> GetHl7Errors()
		{
			return this.hl7Errors;
		}

		public virtual void ClearErrors()
		{
			this.hl7Errors.Clear();
		}
	}
}
