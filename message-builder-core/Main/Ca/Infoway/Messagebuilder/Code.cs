namespace Ca.Infoway.Messagebuilder
{
	/// <summary>The Interface Code.</summary>
	/// <remarks>The Interface Code. Implemented by all classes that supply a code mnemonic and a related code system.</remarks>
	public interface Code
	{
		/// <summary>Gets the code value.</summary>
		/// <remarks>Gets the code value.</remarks>
		/// <returns>the code value</returns>
		string CodeValue
		{
			get;
		}

		/// <summary>Gets the code system.</summary>
		/// <remarks>Gets the code system.</remarks>
		/// <returns>the code system</returns>
		string CodeSystem
		{
			get;
		}
	}
}
