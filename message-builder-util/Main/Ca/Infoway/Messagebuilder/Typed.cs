namespace Ca.Infoway.Messagebuilder
{
	/// <summary>An interface that defines HL7 concepts that have types.</summary>
	/// <author>Intelliware Development</author>
	public interface Typed
	{
		/// <summary>Return the HL7 type -- either an HL7 data type or a complex message type.</summary>
		/// <remarks>Return the HL7 type -- either an HL7 data type or a complex message type.</remarks>
		/// <returns>- the HL7 type</returns>
		string Type
		{
			get;
		}
	}
}
