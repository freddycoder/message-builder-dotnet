using Ca.Infoway.Messagebuilder.Annotation;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	[Hl7PartTypeMappingAttribute("MOCK_MT898989CA.SubType")]
	public class MockSubType2
	{
		private string name;

		[Hl7XmlMappingAttribute("component/subject3/name")]
		public virtual string GetName()
		{
			return name;
		}

		public virtual void SetName(string name)
		{
			this.name = name;
		}
	}
}
