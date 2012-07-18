using Ca.Infoway.Messagebuilder.Annotation;
using Ca.Infoway.Messagebuilder.Model.Mock;

namespace Ca.Infoway.Messagebuilder.Model.Mock
{
	[System.Serializable]
	[Hl7PartTypeMappingAttribute(new string[] { "MFMI_MT700711CA.ControlActEvent" })]
	public class RegistrationControlActEventBean<RR> : ControlActEventBean
	{
		private const long serialVersionUID = 6512047519951312670L;

		private RegistrationRequestBean<RR> registrationBean;

		[Hl7XmlMappingAttribute("subject")]
		public virtual RegistrationRequestBean<RR> RegistrationBean
		{
			get
			{
				return registrationBean;
			}
			set
			{
				RegistrationRequestBean<RR> registrationBean = value;
				this.registrationBean = registrationBean;
			}
		}
	}
}
