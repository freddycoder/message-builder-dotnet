using System;
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Marshalling.Datatypeadapter;

namespace Ca.Infoway.Messagebuilder.Marshalling.Datatypeadapter
{
	public class CollectionOfAnyToAnyAdapter : DataTypeAdapter
	{
		public virtual bool CanAdapt(Type fromDataType, string toDataTypeName)
		{
			if (typeof(COLLECTION<object>).IsAssignableFrom(fromDataType) && !StandardDataType.IsSetOrList(toDataTypeName))
			{
				return true;
			}
			return false;
		}

		public virtual bool CanAdapt(string fromDataTypeName, Type toDateType)
		{
			return false;
		}

		public virtual BareANY Adapt(BareANY any)
		{
			ICollection<object> collection = ((COLLECTION<object>)any).Value;
			BareANY element = null;
			if (collection != null && !collection.IsEmpty())
			{
				element = (BareANY)collection.GetEnumerator().Current;
			}
			else
			{
				element = new ANYImpl<object>();
			}
			return (BareANY)element;
		}
	}
}
