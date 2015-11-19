using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Domainvalue;

namespace Ca.Infoway.Messagebuilder.Marshalling.Datatypeadapter
{
	internal class DataTypeAdapterHelper
	{
		internal virtual BareANY CopyAndReturnAdapted(BareANY any, BareANY adaptedAny, object newValue)
		{
			if (any.HasNullFlavor())
			{
				NullFlavor nullFlavor = any.NullFlavor;
				adaptedAny.NullFlavor = nullFlavor;
			}
			else
			{
				((BareANYImpl)adaptedAny).BareValue = newValue;
			}
			return adaptedAny;
		}
	}
}
