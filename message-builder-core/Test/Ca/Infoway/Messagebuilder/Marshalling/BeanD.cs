using Ca.Infoway.Messagebuilder.Annotation;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Model;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	[System.Serializable]
	[Hl7PartTypeMappingAttribute("ABCD_IN123456CA.BeanD")]
	public class BeanD : MessagePartBean
	{
		private CV someCode = new CVImpl();

		[Hl7XmlMappingAttribute("value")]
		public virtual IntoleranceValue SomeCode
		{
			get
			{
				return (IntoleranceValue)someCode.Value;
			}
			set
			{
				IntoleranceValue someCode = value;
				this.someCode.Value = someCode;
			}
		}
	}
}
