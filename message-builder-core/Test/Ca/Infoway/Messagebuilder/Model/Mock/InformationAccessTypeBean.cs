using Ca.Infoway.Messagebuilder.Annotation;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Model;

namespace Ca.Infoway.Messagebuilder.Model.Mock
{
	[System.Serializable]
	[Hl7PartTypeMappingAttribute(new string[] { "COCT_MT470000CA.Subject3", "RCMR_MT010001CA.Subject2" })]
	public class InformationAccessTypeBean : MessagePartBean
	{
		private const long serialVersionUID = -1127816597472476758L;

		private CD code = new CDImpl();

		[Hl7XmlMappingAttribute(new string[] { "actDefinition/code", "recordType/code" })]
		public virtual ActInformationAccessTypeCode GetCode()
		{
			return (ActInformationAccessTypeCode)this.code.Value;
		}

		public virtual void SetCode(ActInformationAccessTypeCode code)
		{
			this.code.Value = code;
		}
	}
}
