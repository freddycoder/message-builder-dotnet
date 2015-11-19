using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Marshalling;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	internal interface AssociationBridge : BaseRelationshipBridge
	{
		/// <summary>
		/// If the underlying value is a collection, return each collection that
		/// contains one value for each element.
		/// </summary>
		/// <remarks>
		/// If the underlying value is a collection, return each collection that
		/// contains one value for each element.  If the underlying value is
		/// not a collection, return a collection with zero or one element, depending
		/// on whether or not the value is null.
		/// </remarks>
		/// <returns></returns>
		ICollection<PartBridge> GetAssociationValues();
	}
}
