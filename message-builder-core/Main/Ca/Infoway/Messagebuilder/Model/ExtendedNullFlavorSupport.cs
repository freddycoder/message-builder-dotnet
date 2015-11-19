using Ca.Infoway.Messagebuilder.Datatype.Nullflavor;
using Ca.Infoway.Messagebuilder.Domainvalue;

namespace Ca.Infoway.Messagebuilder.Model
{
	public interface ExtendedNullFlavorSupport : NullFlavorSupport
	{
		bool HasNullFlavor(string propertyName);

		NullFlavor GetNullFlavor(string propertyName);

		void SetNullFlavor(string propertyName, NullFlavor nullFlavor);

		bool HasNullFlavorInList(string propertyName, int indexInList);

		NullFlavor GetNullFlavorInList(string propertyName, int indexInList);

		bool SetNullFlavorInList(string propertyName, int indexInList, NullFlavor nullFlavor);

		bool HasNullFlavorInSet(string propertyName, object valueInSet);

		NullFlavor GetNullFlavorInSet(string propertyName, object valueInSet);

		bool SetNullFlavorInSet(string propertyName, object valueInSet, NullFlavor nullFlavor);
	}
}
