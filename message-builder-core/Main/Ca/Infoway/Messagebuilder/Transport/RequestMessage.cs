using System.Xml;

namespace Ca.Infoway.Messagebuilder.Transport
{
	/// <summary>A message that can be sent across a transport layer.</summary>
	/// <remarks>A message that can be sent across a transport layer.</remarks>
	/// <author>
	/// Intelliware Development
	/// sharpen.ignore - transport - TBD!
	/// </author>
	public interface RequestMessage
	{
		/// <summary>Obtains the message as a string, converting the underlying structure if necessary (i.e.</summary>
		/// <remarks>Obtains the message as a string, converting the underlying structure if necessary (i.e. DOM -&gt; string).</remarks>
		/// <returns>the underlying message rendered as a string</returns>
		/// <exception cref="TransportLayerException">if a string representation of the message could not be constructed</exception>
		/// <exception cref="Ca.Infoway.Messagebuilder.Transport.TransportLayerException"></exception>
		string GetMessageAsString();

		/// <summary>Obtains the message's interaction id.</summary>
		/// <remarks>Obtains the message's interaction id.</remarks>
		/// <returns>the message's interaction id</returns>
		/// <exception cref="TransportLayerException">if the message's interaction id could not be determined</exception>
		/// <exception cref="Ca.Infoway.Messagebuilder.Transport.TransportLayerException"></exception>
		string GetInteractionId();

		/// <summary>Obtains the message as a DOM, converting the underlying structure if necessary (i.e.</summary>
		/// <remarks>Obtains the message as a DOM, converting the underlying structure if necessary (i.e. string -&gt; DOM).</remarks>
		/// <returns>the underlying message in a DOM structure</returns>
		/// <exception cref="TransportLayerException">if there were problems creating the DOM</exception>
		/// <exception cref="Ca.Infoway.Messagebuilder.Transport.TransportLayerException"></exception>
		XmlDocument GetMessageAsDocument();
	}
}
