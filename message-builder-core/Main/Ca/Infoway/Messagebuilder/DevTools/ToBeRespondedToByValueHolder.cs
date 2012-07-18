using Ca.Infoway.Messagebuilder.Datatype.Lang;

namespace Ca.Infoway.Messagebuilder.DevTools
{
	public class ToBeRespondedToByValueHolder
	{
		private Identifier deviceId;

		private TelecommunicationAddress telecom;

		public virtual Identifier GetDeviceId()
		{
			return deviceId;
		}

		public virtual void SetDeviceId(Identifier deviceId)
		{
			this.deviceId = deviceId;
		}

		public virtual TelecommunicationAddress GetTelecom()
		{
			return telecom;
		}

		public virtual void SetTelecom(TelecommunicationAddress telecom)
		{
			this.telecom = telecom;
		}
	}
}
