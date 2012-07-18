using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Model;

namespace Ca.Infoway.Messagebuilder.DevTools
{
	[System.Serializable]
	public class SenderBean : MessagePartBean
	{
		private const long serialVersionUID = 20111117L;

		private TEL telecom = new TELImpl();

		private II deviceId = new IIImpl();

		private ST deviceName = new STImpl();

		private ST deviceDesc = new STImpl();

		private IVL<TS, Interval<PlatformDate>> deviceExistenceTime = new IVLImpl<TS, Interval<PlatformDate>>();

		private ST deviceManufacturerModelName = new STImpl();

		private ST deviceSoftwareName = new STImpl();

		private II deviceAgentAgentOrganizationId = new IIImpl();

		//@Hl7PartTypeMapping({"MCCI_MT002100CA.Sender","MCCI_MT002200CA.Sender","MCCI_MT002300CA.Sender","MCCI_MT102001CA.Sender"})
		/// <summary>
		/// SendingNetworkAddress
		/// IB:Sending Network Address
		/// The network address of the application which sent the
		/// message.
		/// soap:Header\wsa:From
		/// May be important for sender validation.
		/// </summary>
		/// <remarks>
		/// SendingNetworkAddress
		/// IB:Sending Network Address
		/// The network address of the application which sent the
		/// message.
		/// soap:Header\wsa:From
		/// May be important for sender validation. Usually also
		/// the address to which responses are sent. This is optional
		/// because not all environments require network addresses. It
		/// is mandatory when communicating using SOAP.
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
		/// SendingApplicationIdentifier
		/// IA:Sending Application Identifier
		/// The unique identifier of the application or system to
		/// whom the message is being routed.
		/// soap:Header\wsa:From\@endpointID
		/// Because this is the key identifier of where the
		/// message is intended to go, this attribute is mandatory.
		/// IA:Sending Application Identifier
		/// The unique identifier of the application or system
		/// from which the message has originated.
		/// soap:Header\wsa:From\@endpointID
		/// Because this is the key identifier of where the
		/// message has originated, this attribute is mandatory in order
		/// to support efficient logging, auditing and debugging
		/// requirements.
		/// </summary>
		public virtual Identifier GetDeviceId()
		{
			//    @Hl7XmlMapping({"device/id"})
			return this.deviceId.Value;
		}

		public virtual void SetDeviceId(Identifier deviceId)
		{
			this.deviceId.Value = deviceId;
		}

		/// <summary>
		/// SendingApplicationName
		/// IE:Sending Application Name
		/// This is the name associated with the system or
		/// application sending the message.
		/// Provides useful information when debugging.
		/// </summary>
		public virtual string GetDeviceName()
		{
			//    @Hl7XmlMapping({"device/name"})
			return this.deviceName.Value;
		}

		public virtual void SetDeviceName(string deviceName)
		{
			this.deviceName.Value = deviceName;
		}

		/// <summary>
		/// SendingApplicationConfigurationInformation
		/// II:Sending Application Configuration Information
		/// Provides additional information about the
		/// configuration of the sending application.
		/// </summary>
		/// <remarks>
		/// SendingApplicationConfigurationInformation
		/// II:Sending Application Configuration Information
		/// Provides additional information about the
		/// configuration of the sending application. Useful when
		/// debugging.
		/// Provides additional information that may assist in
		/// debugging interactions.
		/// </remarks>
		public virtual string GetDeviceDesc()
		{
			//    @Hl7XmlMapping({"device/desc"})
			return this.deviceDesc.Value;
		}

		public virtual void SetDeviceDesc(string deviceDesc)
		{
			this.deviceDesc.Value = deviceDesc;
		}

		/// <summary>
		/// SendingApplicationVersionDate
		/// IH:Sending Application Version Date
		/// Indicates the last time the sending application was
		/// modified or reconfigured.
		/// Can help to isolate the source of a problem when
		/// debugging.
		/// </summary>
		public virtual Interval<PlatformDate> GetDeviceExistenceTime()
		{
			//    @Hl7XmlMapping({"device/existenceTime"})
			return this.deviceExistenceTime.Value;
		}

		public virtual void SetDeviceExistenceTime(Interval<PlatformDate> deviceExistenceTime)
		{
			this.deviceExistenceTime.Value = deviceExistenceTime;
		}

		/// <summary>
		/// SendingSoftwareVersionNumber
		/// IG:Sending Software Version Number
		/// Indicates the version number of the piece of software
		/// used to construct the message.
		/// May be used to filter messages based on the compliance
		/// testing of the sending software.
		/// </summary>
		public virtual string GetDeviceManufacturerModelName()
		{
			//    @Hl7XmlMapping({"device/manufacturerModelName"})
			return this.deviceManufacturerModelName.Value;
		}

		public virtual void SetDeviceManufacturerModelName(string deviceManufacturerModelName)
		{
			this.deviceManufacturerModelName.Value = deviceManufacturerModelName;
		}

		/// <summary>
		/// SendingApplicationSoftwareName
		/// IF:Sending Application Software Name
		/// Indicates the name of the software used to construct
		/// the message.
		/// May be used to filter messages based on sending
		/// application compliance testing.
		/// </summary>
		public virtual string GetDeviceSoftwareName()
		{
			//    @Hl7XmlMapping({"device/softwareName"})
			return this.deviceSoftwareName.Value;
		}

		public virtual void SetDeviceSoftwareName(string deviceSoftwareName)
		{
			this.deviceSoftwareName.Value = deviceSoftwareName;
		}

		/// <summary>
		/// SendingOrganizationIdentifier
		/// IK:Sending Organization Identifier
		/// Sending organization unique identifier.
		/// Identifier is the only non-structure attribute in this
		/// class and is therefore mandatory.
		/// </summary>
		/// <remarks>
		/// SendingOrganizationIdentifier
		/// IK:Sending Organization Identifier
		/// Sending organization unique identifier.
		/// Identifier is the only non-structure attribute in this
		/// class and is therefore mandatory. The agent association from
		/// the sending device (application) to the agent role is
		/// optional.
		/// IK:Sending Organization Identifier
		/// Sending organization unique identifier.
		/// The identifier is the only non-structural attribute in
		/// this class and is therefore mandatory. The association from
		/// sending device to agent is optional.
		/// </remarks>
		public virtual Identifier GetDeviceAgentAgentOrganizationId()
		{
			//    @Hl7XmlMapping({"device/agent/agentOrganization/id"})
			return this.deviceAgentAgentOrganizationId.Value;
		}

		public virtual void SetDeviceAgentAgentOrganizationId(Identifier deviceAgentAgentOrganizationId)
		{
			this.deviceAgentAgentOrganizationId.Value = deviceAgentAgentOrganizationId;
		}
	}
}
