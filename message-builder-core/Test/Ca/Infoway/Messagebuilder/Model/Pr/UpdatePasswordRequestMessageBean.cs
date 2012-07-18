using Ca.Infoway.Messagebuilder.Annotation;
using Ca.Infoway.Messagebuilder.Model.Mock;
using Ca.Infoway.Messagebuilder.Model.Pr;

namespace Ca.Infoway.Messagebuilder.Model.Pr
{
	[System.Serializable]
	[Hl7PartTypeMappingAttribute("NLPN_IN100200CA")]
	public class UpdatePasswordRequestMessageBean : RegistrationRequestMessageBean<RegistrationControlActEventBean<PasswordChangeBean
		>>
	{
		private const long serialVersionUID = 3466536667079485448L;
	}
}
