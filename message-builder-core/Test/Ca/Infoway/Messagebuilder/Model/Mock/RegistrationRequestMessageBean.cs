using Ca.Infoway.Messagebuilder.Annotation;
using Ca.Infoway.Messagebuilder.Model.Mock;

namespace Ca.Infoway.Messagebuilder.Model.Mock
{
	[System.Serializable]
	public abstract class RegistrationRequestMessageBean<CAE> : NewBaseMessageBean
	{
		private const long serialVersionUID = -4171299182341789015L;

		private CAE controlActEventBean;

		[Hl7XmlMappingAttribute(new string[] { "controlActEvent", "controlActProcess" })]
		public virtual CAE ControlActEventBean
		{
			get
			{
				return this.controlActEventBean;
			}
			set
			{
				CAE controlActEventBean = value;
				this.controlActEventBean = controlActEventBean;
			}
		}
	}
}
