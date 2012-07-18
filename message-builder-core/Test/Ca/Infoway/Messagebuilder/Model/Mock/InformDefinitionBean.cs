using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Annotation;
using Ca.Infoway.Messagebuilder.Model;
using Ca.Infoway.Messagebuilder.Model.Mock;

namespace Ca.Infoway.Messagebuilder.Model.Mock
{
	[System.Serializable]
	[Hl7PartTypeMappingAttribute(new string[] { "COCT_MT470000CA.InformDefinition" })]
	public class InformDefinitionBean : MessagePartBean
	{
		private const long serialVersionUID = -377645382168732286L;

		private IList<InformationAccessTypeBean> actDefinitions = new List<InformationAccessTypeBean>();

		private Recipient recipient;

		[Hl7XmlMappingAttribute("subject")]
		public virtual IList<InformationAccessTypeBean> GetActDefinitions()
		{
			return actDefinitions;
		}

		public virtual void SetActDefinitions(IList<InformationAccessTypeBean> actDefinitions)
		{
			this.actDefinitions = actDefinitions;
		}

		[Hl7XmlMappingAttribute("receiver/recipient")]
		public virtual Recipient GetRecipient()
		{
			return recipient;
		}

		public virtual void SetRecipient(Recipient recipient)
		{
			this.recipient = recipient;
		}
	}
}
