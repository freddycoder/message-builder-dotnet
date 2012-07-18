using Ca.Infoway.Messagebuilder.Annotation;
using Ca.Infoway.Messagebuilder.Model.Mock;

namespace Ca.Infoway.Messagebuilder.Model.Mock
{
	[System.Serializable]
	public abstract class NewQueryMessageBean<CAE> : NewBaseMessageBean
	{
		private const long serialVersionUID = 3941752675494132716L;

		private CAE controlActEventBean;

		[Hl7XmlMappingAttribute(new string[] { "controlActEvent", "controlActProcess" })]
		public CAE ControlActEventBean
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
