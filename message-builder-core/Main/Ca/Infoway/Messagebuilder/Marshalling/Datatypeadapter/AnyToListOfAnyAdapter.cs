using System;
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Marshalling.Datatypeadapter;

namespace Ca.Infoway.Messagebuilder.Marshalling.Datatypeadapter
{
	public class AnyToListOfAnyAdapter : DataTypeAdapter
	{
		public virtual bool CanAdapt(string fromDataTypeName, Type toDateType)
		{
			return !StandardDataType.IsSetOrList(fromDataTypeName) && typeof(LIST<ANY<object>, object>).IsAssignableFrom(toDateType);
		}

		public virtual bool CanAdapt(Type fromDataType, string toDataTypeName)
		{
			return false;
		}

		public virtual BareANY Adapt(BareANY any)
		{
			LISTImpl<ANY<object>, object> set = new LISTImpl<ANY<object>, object>(any.GetType());
			((IList<object>)set.Value).Add(any);
			return (BareANY)set;
		}
	}
}
