using System;
using Ca.Infoway.Messagebuilder.Marshalling;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7
{
	[System.Serializable]
	public class XmlToModelTransformationException : MarshallingException
	{
		private const long serialVersionUID = 5389887615873887903L;

		public XmlToModelTransformationException(string message) : base(message)
		{
		}

		public XmlToModelTransformationException(Exception cause) : base(cause.ToString(), cause)
		{
		}

		public XmlToModelTransformationException(string message, Exception cause) : base(message, cause)
		{
		}
	}
}
