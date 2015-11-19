using Ca.Infoway.Messagebuilder.Annotation;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	[Hl7PartTypeMappingAttribute("MOCK_MT123456CA.SubType")]
	public class MockSubType
	{
		private string name;

		[Hl7XmlMappingAttribute("component/subject3/name")]
		public virtual string Name
		{
			get
			{
				return name;
			}
			set
			{
				string name = value;
				this.name = name;
			}
		}
	}
}
