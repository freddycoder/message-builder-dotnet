using Ca.Infoway.Messagebuilder.Annotation;
using Ca.Infoway.Messagebuilder.Model.Mock;

namespace Ca.Infoway.Messagebuilder.Model.Mock
{
	[System.Serializable]
	public abstract class NoPayloadResponseMessageBean : NewBaseMessageBean
	{
		private const long serialVersionUID = 2456058924792026404L;

		private ControlActEventBean controlActEventBean;

		private AcknowledgementBean acknowledgement;

		public NoPayloadResponseMessageBean()
		{
			this.controlActEventBean = new ControlActEventBean();
		}

		[Hl7XmlMappingAttribute(new string[] { "controlActEvent", "controlActProcess" })]
		public virtual ControlActEventBean ControlActEvent
		{
			get
			{
				return this.controlActEventBean;
			}
		}

		public virtual AuthorBean Author
		{
			get
			{
				return ControlActEvent.Author;
			}
		}

		[Hl7XmlMappingAttribute("acknowledgement")]
		public virtual AcknowledgementBean Acknowledgement
		{
			get
			{
				return this.acknowledgement;
			}
			set
			{
				AcknowledgementBean acknowledgement = value;
				this.acknowledgement = acknowledgement;
			}
		}

		public virtual void ClearControlActEvent()
		{
			this.controlActEventBean = null;
		}
	}
}
