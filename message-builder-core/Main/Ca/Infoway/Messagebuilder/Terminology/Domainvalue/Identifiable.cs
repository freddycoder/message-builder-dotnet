using System;

namespace Ca.Infoway.Messagebuilder.Terminology.Domainvalue
{
	/// <summary>The Interface Identifiable.</summary>
	/// <remarks>The Interface Identifiable. Marks classes that provide numeric ids.</remarks>
	/// <author>Intelliware Development</author>
	public interface Identifiable
	{
		/// <summary>Gets the id.</summary>
		/// <remarks>Gets the id.</remarks>
		/// <returns>the id</returns>
		Int64? GetId();
	}
}
