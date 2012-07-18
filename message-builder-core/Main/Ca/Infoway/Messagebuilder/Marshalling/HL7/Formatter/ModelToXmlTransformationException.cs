using System;
using Ca.Infoway.Messagebuilder.Marshalling;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[System.Serializable]
	public class ModelToXmlTransformationException : MarshallingException
	{
		private const long serialVersionUID = -7643354300516851891L;

		public ModelToXmlTransformationException(string message) : base(message)
		{
		}

		public ModelToXmlTransformationException(Exception cause) : base(cause.ToString(), cause)
		{
		}

		public ModelToXmlTransformationException(string message, Exception cause) : base(message, cause)
		{
		}
	}
}
