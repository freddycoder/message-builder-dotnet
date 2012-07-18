using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Annotation;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	[Hl7PartTypeMappingAttribute("ABCD_IN123456CA.BeanBPrime")]
	public class BeanBPrime
	{
		private IList<string> text = new List<string>();

		[Hl7XmlMappingAttribute("text")]
		public virtual IList<string> Text
		{
			get
			{
				return this.text;
			}
		}
	}
}
