namespace Ca.Infoway.Messagebuilder.Xml
{
	/// <summary>An interface that represents types that have categories.</summary>
	/// <remarks>
	/// An interface that represents types that have categories.  Categories are
	/// used to segment the standard into segments such as "cr" (for Client Registry) or
	/// "lr" (Location Registry).
	/// </remarks>
	/// <author>Intelliware Development</author>
	public interface Categorizable
	{
		/// <summary>Get the category.</summary>
		/// <remarks>Get the category.</remarks>
		/// <returns>the category.</returns>
		string Category
		{
			get;
		}
	}
}
