using Ca.Infoway.Messagebuilder.Transport;

namespace Ca.Infoway.Messagebuilder.Transport
{
	/// <summary>A null implementation of a transport layer which doesn't send or receive a message.</summary>
	/// <remarks>A null implementation of a transport layer which doesn't send or receive a message.</remarks>
	/// <author>
	/// Intelliware Development
	/// sharpen.ignore - transport - TBD!
	/// </author>
	public class SystemOutTransportLayer : TransportLayer
	{
		/// <summary>Doesn't send a message.</summary>
		/// <remarks>Doesn't send a message. Provides an empty string for the response.</remarks>
		/// <param name="credentialsProvider">a way to obtain credentials</param>
		/// <param name="requestMessage">the message to be sent across the transport layer</param>
		/// <returns>the response message as a string</returns>
		public virtual string SendRequestAndGetResponse(CredentialsProvider credentialsProvider, RequestMessage requestMessage)
		{
			return string.Empty;
		}
	}
}
