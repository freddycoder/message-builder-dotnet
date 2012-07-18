using Ca.Infoway.Messagebuilder.Transport;

namespace Ca.Infoway.Messagebuilder.Transport
{
	/// <summary>An exception for http problems encountered within the transport layers.</summary>
	/// <remarks>An exception for http problems encountered within the transport layers.</remarks>
	/// <author>
	/// Intelliware Development
	/// sharpen.ignore - transport - TBD!
	/// </author>
	[System.Serializable]
	public class HttpTransportLayerException : TransportLayerException
	{
		private const long serialVersionUID = 4806719016466005503L;

		/// <summary>Constructs an http transport layer exception based on the http status code.</summary>
		/// <remarks>Constructs an http transport layer exception based on the http status code.</remarks>
		/// <param name="statusCode">the statusCode of the http error</param>
		public HttpTransportLayerException(int statusCode) : base("Invalid HTTP status code received from server " + statusCode)
		{
		}
	}
}
