namespace Ca.Infoway.Messagebuilder.Marshalling.HL7
{
	public class DataTypeHandler : System.Attribute
	{
		public string[] Value;

		public DataTypeHandler(string[] Value)
		{
			this.Value = Value;
		}

		public DataTypeHandler(string Value)
		{
			this.Value = new string[] { Value };
		}
	}
}
