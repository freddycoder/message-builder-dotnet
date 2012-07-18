using Ca.Infoway.Messagebuilder.Annotation;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	[Hl7PartTypeMappingAttribute("ABCD_IN123456CA.BeanB")]
	public class BeanB
	{
		private string text;

		[Hl7XmlMappingAttribute("text")]
		public virtual string Text
		{
			get
			{
				return this.text;
			}
			set
			{
				string text = value;
				this.text = text;
			}
		}
	}
}
