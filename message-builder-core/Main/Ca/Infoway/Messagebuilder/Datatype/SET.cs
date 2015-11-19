using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Datatype;

namespace Ca.Infoway.Messagebuilder.Datatype
{
	/// <summary>HL7 datatype SET.</summary>
	/// <remarks>
	/// HL7 datatype SET. Backed by a java Set.
	/// Used when multiple repetitions are allowed, order is irrelevant and duplicates are prohibited.
	/// </remarks>
	/// <author>Intelliware Development</author>
	/// <TBD></TBD>
	/// <TBD></TBD>
	public interface SET<T, V> : COLLECTION<T> where T : ANY<V>
	{
		/// <summary>Returns the underlying Java Set containing values in the underlying Java datatype.</summary>
		/// <remarks>Returns the underlying Java Set containing values in the underlying Java datatype.</remarks>
		/// <returns>the underlying Java Set containing values in the underlying Java datatype</returns>
		ICollection<V> RawSet();

		ICollection<U> RawSet<U>() where U : V;
	}
}
