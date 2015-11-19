using Ca.Infoway.Messagebuilder.Datatype.Lang;

namespace Ca.Infoway.Messagebuilder.DevTools
{
	public class ReceiverValueHolder
	{
		private TelecommunicationAddress telecom;

		private Identifier deviceId;

		private string deviceName;

		private Identifier deviceAgentAgentOrganizationId;

		public virtual TelecommunicationAddress GetTelecom()
		{
			return telecom;
		}

		public virtual void SetTelecom(TelecommunicationAddress telecom)
		{
			this.telecom = telecom;
		}

		public virtual Identifier GetDeviceId()
		{
			return deviceId;
		}

		public virtual void SetDeviceId(Identifier deviceId)
		{
			this.deviceId = deviceId;
		}

		public virtual string GetDeviceName()
		{
			return deviceName;
		}

		public virtual void SetDeviceName(string deviceName)
		{
			this.deviceName = deviceName;
		}

		public virtual Identifier GetDeviceAgentAgentOrganizationId()
		{
			return deviceAgentAgentOrganizationId;
		}

		public virtual void SetDeviceAgentAgentOrganizationId(Identifier deviceAgentAgentOrganizationId)
		{
			this.deviceAgentAgentOrganizationId = deviceAgentAgentOrganizationId;
		}
	}
}
