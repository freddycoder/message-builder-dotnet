namespace Ca.Infoway.Messagebuilder.Annotation
{
	public class Hl7PartTypeMappingAttribute : System.Attribute
	{
		public string[] Value;

		public Hl7PartTypeMappingAttribute(string[] Value)
		{
			this.Value = Value;
		}

		public Hl7PartTypeMappingAttribute(string Value)
		{
			this.Value = new string[] { Value };
		}
	}
}
