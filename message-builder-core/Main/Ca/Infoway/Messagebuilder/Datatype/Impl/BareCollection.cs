using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Datatype;

namespace Ca.Infoway.Messagebuilder.Datatype.Impl
{
	public interface BareCollection
	{
		ICollection<BareANY> GetBareCollectionValue();
	}
}
