using Ca.Infoway.Messagebuilder.Annotation;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Model;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	[Hl7PartTypeMappingAttribute("ABCD_IN123456CA.SimpleInteraction")]
	public class SimpleInteraction : IInteraction
	{
		private BeanB bean;

		[Hl7XmlMappingAttribute("bean")]
		public virtual BeanB Bean
		{
			get
			{
				return this.bean;
			}
			set
			{
				BeanB bean = value;
				this.bean = bean;
			}
		}
	}
}
