using Ca.Infoway.Messagebuilder.Annotation;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Model;

namespace Ca.Infoway.Messagebuilder.Model.Pr
{
	[System.Serializable]
	[Hl7PartTypeMappingAttribute(new string[] { "NLPN_MT100200CA.PasswordChange" })]
	public class PasswordChangeBean : MessagePartBean
	{
		private const long serialVersionUID = 3617565414992486010L;

		private ST text = new STImpl();

		[Hl7XmlMappingAttribute("text")]
		public virtual string Text
		{
			get
			{
				return this.text.Value;
			}
			set
			{
				string text = value;
				this.text.Value = text;
			}
		}
	}
}
