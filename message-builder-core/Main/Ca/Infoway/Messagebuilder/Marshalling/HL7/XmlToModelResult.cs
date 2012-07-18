using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7
{
	/// <summary>
	/// An object that represents the result of transforming an object from HL7 XML format
	/// to an object representation.
	/// </summary>
	/// <remarks>
	/// An object that represents the result of transforming an object from HL7 XML format
	/// to an object representation.  The result tends to contain two key items:
	/// 
	/// An object representation of the HL7 message that contains all of the populated
	/// data.
	/// A set of errors that were encountered during parsing of the message.
	/// 
	/// </remarks>
	/// <author>Intelliware Development</author>
	public class XmlToModelResult
	{
		private object messageObject;

		private readonly IList<Hl7Error> hl7Errors = new List<Hl7Error>();

		/// <summary>The object representation of the HL7 message.</summary>
		/// <remarks>The object representation of the HL7 message.</remarks>
		/// <returns>- the populated classes that contain the message data.</returns>
		public virtual object GetMessageObject()
		{
			return messageObject;
		}

		public virtual void SetMessageObject(object messageObject)
		{
			this.messageObject = messageObject;
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
