using System;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.Datatypeadapter;

namespace Ca.Infoway.Messagebuilder.Marshalling.Datatypeadapter
{
	public class TsToIvlAdapter : DataTypeAdapter
	{
		public virtual bool CanAdapt(Type fromDataType, string toDataTypeName)
		{
			if (typeof(TS).IsAssignableFrom(fromDataType) && (StandardDataType.IVL_FULL_DATE.Type.Equals(toDataTypeName) || StandardDataType
				.IVL_FULL_DATE_WITH_TIME.Type.Equals(toDataTypeName)))
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
			return new DataTypeAdapterHelper().CopyAndReturnAdapted(any, (BareANY)new IVLImpl<TS, Interval<PlatformDate>>(), any.BareValue
				 != null ? IntervalFactory.CreateLow<PlatformDate>((PlatformDate)any.BareValue) : null);
		}
	}
}
