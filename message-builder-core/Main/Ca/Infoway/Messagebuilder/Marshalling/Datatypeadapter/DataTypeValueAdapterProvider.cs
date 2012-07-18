using System;
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Marshalling.Datatypeadapter;

namespace Ca.Infoway.Messagebuilder.Marshalling.Datatypeadapter
{
	public class DataTypeValueAdapterProvider
	{
		private sealed class _DataTypeAdapter_31 : DataTypeAdapter
		{
			public _DataTypeAdapter_31()
			{
			}

			public BareANY Adapt(BareANY any)
			{
				return any;
			}

			public bool CanAdapt(Type fromDataType, string toDataTypeName)
			{
				return true;
			}

			public bool CanAdapt(string fromDataTypeName, Type toDateType)
			{
				return true;
			}
		}

		private static readonly DataTypeAdapter NULL_DATA_TYPE_ADAPTER = new _DataTypeAdapter_31();

		private readonly IList<DataTypeAdapter> adapters = new List<DataTypeAdapter>();

		public DataTypeValueAdapterProvider()
		{
			adapters.Add(new TsToIvlAdapter());
			adapters.Add(new IvlToTsAdapter());
			adapters.Add(new CollectionToSetOfTnAdapter());
			adapters.Add(new CollectionOfAnyToAnyAdapter());
			adapters.Add(new AnyToSetOfAnyAdapter());
			adapters.Add(new AnyToListOfAnyAdapter());
		}

		public virtual DataTypeAdapter GetAdapter(Type fromDataType, string toDataTypeName)
		{
			DataTypeAdapter matchingAdapter = NULL_DATA_TYPE_ADAPTER;
			if (fromDataType != null && toDataTypeName != null)
			{
				foreach (DataTypeAdapter adapter in adapters)
				{
					if (adapter.CanAdapt(fromDataType, toDataTypeName))
					{
						matchingAdapter = adapter;
						break;
					}
				}
			}
			return matchingAdapter;
		}

		public virtual DataTypeAdapter GetAdapter(string fromDataTypeName, Type toDateType)
		{
			DataTypeAdapter matchingAdapter = NULL_DATA_TYPE_ADAPTER;
			foreach (DataTypeAdapter adapter in adapters)
			{
				if (adapter.CanAdapt(fromDataTypeName, toDateType))
				{
					matchingAdapter = adapter;
					break;
				}
			}
			return matchingAdapter;
		}
	}
}
