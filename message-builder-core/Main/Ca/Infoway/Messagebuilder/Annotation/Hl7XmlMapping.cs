namespace Ca.Infoway.Messagebuilder.Annotation
{
	public class Hl7XmlMappingAttribute : System.Attribute
	{
		public string[] Value;

		public Hl7XmlMappingAttribute(string[] Value)
		{
			this.Value = Value;
		}

		public Hl7XmlMappingAttribute(string Value)
		{
			this.Value = new string[] { Value };
		}
	}
}
