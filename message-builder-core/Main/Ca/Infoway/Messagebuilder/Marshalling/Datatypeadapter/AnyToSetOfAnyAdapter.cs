using System;
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Marshalling.Datatypeadapter;

namespace Ca.Infoway.Messagebuilder.Marshalling.Datatypeadapter
{
	public class AnyToSetOfAnyAdapter : DataTypeAdapter
	{
		public virtual bool CanAdapt(string fromDataTypeName, Type toDateType)
		{
			return !StandardDataType.IsSetOrList(fromDataTypeName) && typeof(SET<ANY<object>, object>).IsAssignableFrom(toDateType);
		}

		public virtual bool CanAdapt(Type fromDataType, string toDataTypeName)
		{
			return false;
		}

		public virtual BareANY Adapt(BareANY any)
		{
			SETImpl<ANY<object>, object> set = new SETImpl<ANY<object>, object>(any.GetType());
			((ICollection<object>)set.Value).Add(any);
			return (BareANY)set;
		}
	}
}
