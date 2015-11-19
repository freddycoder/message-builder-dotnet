using System;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.Datatypeadapter;

namespace Ca.Infoway.Messagebuilder.Marshalling.Datatypeadapter
{
	public class IvlToTsAdapter : DataTypeAdapter
	{
		public virtual bool CanAdapt(string fromDataTypeName, Type toDataType)
		{
			if ((StandardDataType.IVL_FULL_DATE.Type.Equals(fromDataTypeName) || StandardDataType.IVL_FULL_DATE_WITH_TIME.Type.Equals
				(fromDataTypeName)) && typeof(TS).IsAssignableFrom(toDataType))
			{
				return true;
			}
			return false;
		}

		public virtual bool CanAdapt(Type fromDataType, string toDataTypeName)
		{
			return false;
		}

		public virtual BareANY Adapt(Type toDataType, BareANY any)
		{
			IVL<TS, Interval<PlatformDate>> ivl = (IVL<TS, Interval<PlatformDate>>)any;
			return (BareANY)new DataTypeAdapterHelper().CopyAndReturnAdapted(any, (BareANY)new TSImpl(), ((Interval<PlatformDate>)ivl
				.Value).Low);
		}

		public virtual BareANY Adapt(string toDataTypeName, BareANY any)
		{
			return any;
		}
	}
}
