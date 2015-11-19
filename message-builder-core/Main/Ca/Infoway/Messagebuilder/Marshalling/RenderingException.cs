using System;
using Ca.Infoway.Messagebuilder;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	[System.Serializable]
	public class RenderingException : MarshallingException
	{
		private const long serialVersionUID = 1300553061611883012L;

		public RenderingException() : base()
		{
		}

		public RenderingException(string message, Exception cause) : base(message, cause)
		{
		}

		public RenderingException(string message) : base(message)
		{
		}

		public RenderingException(Exception cause) : base(cause)
		{
		}
	}
}
