/**
 * Copyright 2013 Canada Health Infoway, Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *        http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 * Author:        $LastChangedBy: tmcgrady $
 * Last modified: $LastChangedDate: 2011-05-04 16:47:15 -0300 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
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
