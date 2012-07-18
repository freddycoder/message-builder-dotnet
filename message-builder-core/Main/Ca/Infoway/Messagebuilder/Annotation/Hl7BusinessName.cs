namespace Ca.Infoway.Messagebuilder.Annotation
{
	/// <summary>A temporary annotation until we are fully auto-generating classes.</summary>
	/// <remarks>A temporary annotation until we are fully auto-generating classes.</remarks>
	public class Hl7BusinessNameAttribute : System.Attribute
	{
		public string Value = string.Empty;

		public Hl7BusinessNameAttribute(string Value)
		{
			this.Value = Value;
		}
	}
}
