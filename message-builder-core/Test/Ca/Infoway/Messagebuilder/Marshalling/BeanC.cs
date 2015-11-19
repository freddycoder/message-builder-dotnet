using Ca.Infoway.Messagebuilder.Annotation;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	[Hl7PartTypeMappingAttribute("ABCD_IN123456CA.BeanC")]
	public class BeanC
	{
		private Ca.Infoway.Messagebuilder.Marshalling.BeanB beanB;

		[Hl7XmlMappingAttribute("textHolder")]
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
