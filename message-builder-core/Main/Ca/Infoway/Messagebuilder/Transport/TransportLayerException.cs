using System;

namespace Ca.Infoway.Messagebuilder.Transport
{
	/// <summary>An exception for general problems encountered within the transport layers.</summary>
	/// <remarks>An exception for general problems encountered within the transport layers.</remarks>
	/// <author>
	/// Intelliware Development
	/// sharpen.ignore - transport - TBD!
	/// </author>
	[System.Serializable]
	public class TransportLayerException : Exception
	{
		private const long serialVersionUID = -5941185034989629293L;

		/// <summary>Constructs a basic transport exception.</summary>
		/// <remarks>Constructs a basic transport exception.</remarks>
		public TransportLayerException()
		{
		}

		/// <summary>Constructs a transport exception with a message and a cause.</summary>
		/// <remarks>Constructs a transport exception with a message and a cause.</remarks>
		/// <param name="message">the exception error message</param>
		/// <param name="cause">the root exception</param>
		public TransportLayerException(string message, Exception cause) : base(message, cause)
		{
		}

		/// <summary>Constructs a transport exception with a message.</summary>
		/// <remarks>Constructs a transport exception with a message.</remarks>
		/// <param name="message">the exception error message</param>
		public TransportLayerException(string message) : base(message)
		{
		}

		/// <summary>Constructs a transport exception with a cause.</summary>
		/// <remarks>Constructs a transport exception with a cause.</remarks>
		/// <param name="cause">the root exception</param>
		public TransportLayerException(Exception cause) : base(cause.ToString(), cause)
		{
		}
	}
}
