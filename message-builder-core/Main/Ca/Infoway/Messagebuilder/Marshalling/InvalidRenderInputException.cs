using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	/// <summary>
	/// An exception indicating that the application tried to marshall a message
	/// part that did not follow the rules of marshalling.
	/// </summary>
	/// <remarks>
	/// An exception indicating that the application tried to marshall a message
	/// part that did not follow the rules of marshalling.
	/// </remarks>
	/// <author>Intelliware Development</author>
	[System.Serializable]
	public class InvalidRenderInputException : RenderingException
	{
		private readonly IList<Hl7Error> hl7Errors;

		private const long serialVersionUID = -1049387329590610715L;

		public InvalidRenderInputException(IList<Hl7Error> hl7Errors)
		{
			this.hl7Errors = hl7Errors;
		}

		public virtual IList<Hl7Error> GetHl7Errors()
		{
			return this.hl7Errors;
		}

		public override string Message
		{
			get
			{
				Hl7Error firstError = null;
				foreach (Hl7Error hl7Error in this.hl7Errors)
				{
					if (hl7Error.GetHl7ErrorLevel() == ErrorLevel.ERROR)
					{
						firstError = hl7Error;
						break;
					}
				}
				return firstError == null ? string.Empty : firstError.ToString();
			}
		}
	}
}
