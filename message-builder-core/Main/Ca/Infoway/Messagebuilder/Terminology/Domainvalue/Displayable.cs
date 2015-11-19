namespace Ca.Infoway.Messagebuilder.Terminology.Domainvalue
{
	/// <summary>The Interface Displayable.</summary>
	/// <remarks>The Interface Displayable. Allows classes to provide display text for their contents.</remarks>
	/// <author>Intelliware Development</author>
	public interface Displayable
	{
		/// <summary>Gets the display text.</summary>
		/// <remarks>Gets the display text.</remarks>
		/// <param name="language">the language</param>
		/// <returns>the display text</returns>
		string GetDisplayText(string language);
	}
}
