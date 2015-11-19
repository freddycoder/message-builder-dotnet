using System;

namespace Ca.Infoway.Messagebuilder.Terminology.Domainvalue
{
	/// <summary>The Interface Sortable.</summary>
	/// <remarks>The Interface Sortable. Used to help order objects.</remarks>
	/// <author>Intelliware Development</author>
	public interface Sortable
	{
		/// <summary>Gets the sort value.</summary>
		/// <remarks>Gets the sort value.</remarks>
		/// <returns>the sort value</returns>
		Int32? GetSortValue();
	}
}
