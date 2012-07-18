namespace Ca.Infoway.Messagebuilder.Annotation
{
	/// <author>Intelliware Development</author>
	public class Hl7ChoiceAttribute : System.Attribute
	{
		public string[] Value;

		public Hl7ChoiceAttribute(string[] Value)
		{
			this.Value = Value;
		}

		public Hl7ChoiceAttribute(string Value)
		{
			this.Value = new string[] { Value };
		}
	}
}
