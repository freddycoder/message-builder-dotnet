using System;

namespace Ca.Infoway.Messagebuilder
{
	[System.Serializable]
	public class MarshallingException : Exception
	{
		private const long serialVersionUID = -4687947353744762872L;

		public MarshallingException()
		{
		}

		public MarshallingException(string message, Exception cause) : base(message, cause)
		{
		}

		public MarshallingException(string message) : base(message)
		{
		}

		public MarshallingException(Exception cause) : base(cause.ToString(), cause)
		{
		}
	}
}
