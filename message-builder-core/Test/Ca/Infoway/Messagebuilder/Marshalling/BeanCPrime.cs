using Ca.Infoway.Messagebuilder.Annotation;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	[Hl7PartTypeMappingAttribute("ABCD_IN123456CA.BeanC")]
	public class BeanCPrime
	{
		private Ca.Infoway.Messagebuilder.Marshalling.BeanB beanB;

		[Hl7XmlMappingAttribute("component2/textHolder")]
		public virtual Ca.Infoway.Messagebuilder.Marshalling.BeanB BeanB
		{
			get
			{
				return this.beanB;
			}
			set
			{
				Ca.Infoway.Messagebuilder.Marshalling.BeanB beanB = value;
				this.beanB = beanB;
			}
		}
	}
}
