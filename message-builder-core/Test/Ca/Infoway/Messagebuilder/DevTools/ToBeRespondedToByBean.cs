using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Model;

namespace Ca.Infoway.Messagebuilder.DevTools
{
	[System.Serializable]
	public class ToBeRespondedToByBean : MessagePartBean
	{
		private const long serialVersionUID = 20111117L;

		private TEL telecom = new TELImpl();

		private II deviceId = new IIImpl();

		//@Hl7PartTypeMapping({"MCCI_MT002100CA.RespondTo","MCCI_MT002200CA.RespondTo","MCCI_MT002300CA.RespondTo","MCCI_MT102001CA.RespondTo"})
		/// <summary>
		/// RespondToNetworkAddress
		/// KB:Respond to Network Address
		/// Indicates the address to send acknowledgments of this
		/// message to.
		/// soap:Header\wsa:ReplyTo
		/// Needed when the address to respond to is different
		/// than that of the sender.
		/// </summary>
		/// <remarks>
		/// RespondToNetworkAddress
		/// KB:Respond to Network Address
		/// Indicates the address to send acknowledgments of this
		/// message to.
		/// soap:Header\wsa:ReplyTo
		/// Needed when the address to respond to is different
		/// than that of the sender. This is optional because not all
		/// environments require network addresses. It is required when
		/// communicating using SOAP.
		/// </remarks>
		public virtual TelecommunicationAddress GetTelecom()
		{
			//    @Hl7XmlMapping({"telecom"})
			return this.telecom.Value;
		}

		public virtual void SetTelecom(TelecommunicationAddress telecom)
		{
			this.telecom.Value = telecom;
		}

		/// <summary>
		/// RespondToApplicationIdentifier
		/// KA:Respond to Application Identifier
		/// The unique identifier of the applications to which
		/// responses should be sent.
		/// </summary>
		/// <remarks>
		/// RespondToApplicationIdentifier
		/// KA:Respond to Application Identifier
		/// The unique identifier of the applications to which
		/// responses should be sent. Only populated when different from
		/// the sending application id.
		/// soap:Header\wsa:ReplyTo\@endpointID
		/// Allows unique identification and routing to the
		/// application to be responded to. This attribute is mandatory
		/// be cause it is the principal identifier of the application
		/// to respond to.
		/// </remarks>
		public virtual Identifier GetDeviceId()
		{
			//    @Hl7XmlMapping({"device/id"})
			return this.deviceId.Value;
		}

		public virtual void SetDeviceId(Identifier deviceId)
		{
			this.deviceId.Value = deviceId;
		}
	}
}
