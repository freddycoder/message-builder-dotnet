using Ca.Infoway.Messagebuilder.Annotation;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Model;

namespace Ca.Infoway.Messagebuilder.Model.Mock
{
	[System.Serializable]
	[Hl7PartTypeMappingAttribute(new string[] { "MCCI_MT002100CA.Receiver", "MCCI_MT002300CA.Receiver", "MCCI_MT000100CA.Receiver"
		, "MCCI_MT102001CA.Receiver", "MCCI_MT000300CA.Receiver" })]
	public class Receiver : MessagePartBean
	{
		private const long serialVersionUID = -1571165043033330892L;

		[Hl7BusinessNameAttribute("receiverApplicationIdentifier")]
		private II deviceId = new IIImpl();

		[Hl7BusinessNameAttribute("receiverApplicationName")]
		private ST deviceName = new STImpl();

		[Hl7BusinessNameAttribute("receiverNetworkAddress")]
		private TEL telecommunicationAddress = new TELImpl();

		[Hl7BusinessNameAttribute("receiverOrganizationIdentifier")]
		private II receiverOrganizationIdentifier = new IIImpl();

		[Hl7XmlMappingAttribute("device/id")]
		public virtual Identifier DeviceId
		{
			get
			{
				return this.deviceId.Value;
			}
			set
			{
				Identifier deviceId = value;
				this.deviceId.Value = deviceId;
			}
		}

		[Hl7XmlMappingAttribute("device/name")]
		public virtual string DeviceName
		{
			get
			{
				return this.deviceName.Value;
			}
		}

		public virtual void SetDeviceName(string deviceName)
		{
			this.deviceName.Value = deviceName;
		}

		[Hl7XmlMappingAttribute("telecom")]
		public virtual Ca.Infoway.Messagebuilder.Datatype.Lang.TelecommunicationAddress TelecommunicationAddress
		{
			get
			{
				return this.telecommunicationAddress.Value;
			}
		}

		public virtual void SetTelecommunicationAddress(Ca.Infoway.Messagebuilder.Datatype.Lang.TelecommunicationAddress telecommunicationAddress
			)
		{
			this.telecommunicationAddress.Value = telecommunicationAddress;
		}

		/// <summary>
		/// JK:Receiver Organization Identifier
		/// Receiver organization.
		/// </summary>
		/// <remarks>
		/// JK:Receiver Organization Identifier
		/// Receiver organization.
		/// The identifier of the receiver organization. This is the
		/// only non-structural attribute in this class and is therefore
		/// mandatory. Receiver organization is optional (as the scoper
		/// association from the receiver application is optional).
		/// </remarks>
		[Hl7XmlMappingAttribute("device/agent/agentOrganization/id")]
		public virtual Identifier ReceiverOrganizationIdentifier
		{
			get
			{
				return this.receiverOrganizationIdentifier.Value;
			}
		}

		public virtual void SetReceiverOrganizationIdentifier(Identifier receiverOrganizationIdentifier)
		{
			this.receiverOrganizationIdentifier.Value = receiverOrganizationIdentifier;
		}
	}
}
