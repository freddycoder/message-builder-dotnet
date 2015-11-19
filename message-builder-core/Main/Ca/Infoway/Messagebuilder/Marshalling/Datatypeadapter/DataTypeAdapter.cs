using System;
using Ca.Infoway.Messagebuilder.Datatype;

namespace Ca.Infoway.Messagebuilder.Marshalling.Datatypeadapter
{
	public interface DataTypeAdapter
	{
		bool CanAdapt(Type fromDataType, string toDataTypeName);

		bool CanAdapt(string fromDataTypeName, Type toDataType);

		BareANY Adapt(Type toDataType, BareANY any);

		BareANY Adapt(string toDataTypeName, BareANY any);
	}
}
