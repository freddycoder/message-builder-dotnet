using Ca.Infoway.Messagebuilder.Annotation;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Model;
using Ca.Infoway.Messagebuilder.Model.Mock;

namespace Ca.Infoway.Messagebuilder.Model.Mock
{
	[System.Serializable]
	[Hl7PartTypeMappingAttribute(new string[] { "COCT_MT470000CA.ConsentEvent" })]
	public class ConsentEventBean : MessagePartBean, Identifiable
	{
		private const long serialVersionUID = -647607118325387652L;

		private II id = new IIImpl();

		private CD reasonCode = new CDImpl();

		private IdentifiedPersonBean patient;

		private ST signatureText = new STImpl();

		private InformDefinitionBean informDefinition;

		[Hl7XmlMappingAttribute("id")]
		public virtual Identifier Id
		{
			get
			{
				return this.id.Value;
			}
		}

		public virtual void SetId(Identifier id)
		{
			this.id.Value = id;
		}

		[Hl7XmlMappingAttribute("subject1/patient")]
		public virtual IdentifiedPersonBean GetPatient()
		{
			return patient;
		}

		public virtual void SetPatient(IdentifiedPersonBean patient)
		{
			this.patient = patient;
		}

		[Hl7XmlMappingAttribute("reasonCode")]
		public virtual ActConsentInformationAccessReason GetReasonCode()
		{
			return (ActConsentInformationAccessReason)this.reasonCode.Value;
		}

		public virtual void SetReasonCode(ActConsentInformationAccessReason reasonCode)
		{
			this.reasonCode.Value = reasonCode;
		}

		[Hl7XmlMappingAttribute("author2/signatureText")]
		public virtual string GetSignatureText()
		{
			return this.signatureText.Value;
		}

		public virtual void SetSignatureText(string signatureText)
		{
			this.signatureText.Value = signatureText;
		}

		[Hl7XmlMappingAttribute("subject2/informDefinition")]
		public virtual InformDefinitionBean GetInformDefinition()
		{
			return informDefinition;
		}

		public virtual void SetInformDefinition(InformDefinitionBean informDefinition)
		{
			this.informDefinition = informDefinition;
		}
	}
}
