using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Annotation;
using Ca.Infoway.Messagebuilder.Marshalling;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	[Hl7PartTypeMappingAttribute("ABCD_IN123456CA.BeanAPrime")]
	public class BeanAPrime
	{
		private IList<BeanB> issues = new List<BeanB>();

		[Hl7XmlMappingAttribute("subjectOf/component/issue")]
		public virtual IList<BeanB> Issues
		{
			get
			{
				return this.issues;
			}
		}
	}
}
