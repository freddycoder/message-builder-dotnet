using Ca.Infoway.Messagebuilder.Transport;

namespace Ca.Infoway.Messagebuilder.Transport
{
	/// <summary>A transport mechanism for sending requests (as requestMessages) and receiving responses (as strings).</summary>
	/// <remarks>A transport mechanism for sending requests (as requestMessages) and receiving responses (as strings).</remarks>
	/// <author>
	/// Intelliware Development
	/// sharpen.ignore - transport - TBD!
	/// </author>
	public interface TransportLayer
	{
		/// <summary>Sends a RequestMessage using the provided credentials and returns a response message as a string.</summary>
		/// <remarks>Sends a RequestMessage using the provided credentials and returns a response message as a string.</remarks>
		/// <param name="credentialsProvider">a way to obtain credentials</param>
		/// <param name="requestMessage">the message to be sent across the transport layer</param>
		/// <returns>the response message as a string</returns>
		/// <exception cref="TransportLayerException">if any problems occurred during send or receive of the message</exception>
		/// <exception cref="Ca.Infoway.Messagebuilder.Transport.TransportLayerException"></exception>
		string SendRequestAndGetResponse(CredentialsProvider credentialsProvider, RequestMessage requestMessage);
	}
}
