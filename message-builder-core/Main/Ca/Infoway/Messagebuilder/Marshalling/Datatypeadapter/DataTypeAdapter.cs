using System;
using Ca.Infoway.Messagebuilder.Datatype;

namespace Ca.Infoway.Messagebuilder.Marshalling.Datatypeadapter
{
	public interface DataTypeAdapter
	{
		bool CanAdapt(Type fromDataType, string toDataTypeName);

		bool CanAdapt(string fromDataTypeName, Type toDateType);

		BareANY Adapt(BareANY any);
	}
}
