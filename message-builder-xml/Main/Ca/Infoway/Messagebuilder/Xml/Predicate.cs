namespace Ca.Infoway.Messagebuilder.Xml
{
	/// <summary>A generic interface for determining whether or not a condition applies.</summary>
	/// <remarks>
	/// A generic interface for determining whether or not a condition applies.
	/// This interface is typically used while iterating over a number of items in a
	/// collection, to choose one particular option.
	/// </remarks>
	/// <author>Intelliware Development</author>
	/// <TBD></TBD>
	public interface Predicate<T>
	{
		/// <summary>Apply the predicate criteria.</summary>
		/// <remarks>Apply the predicate criteria.</remarks>
		/// <param name="t">- the item to analyze</param>
		/// <returns>true if the predicate matches; false otherwise</returns>
		bool Apply(T t);
	}
}
