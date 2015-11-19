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
 * Author:        $LastChangedBy: gng $
 * Last modified: $LastChangedDate: 2015-11-19 18:20:12 -0500 (Fri, 30 Jan 2015) $
 * Revision:      $LastChangedRevision: 9755 $
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

			public BareANY Adapt(Type toDataType, BareANY any)
			{
				return any;
			}

			public BareANY Adapt(string toDataTypeName, BareANY any)
			{
				return any;
			}

			public bool CanAdapt(Type fromDataType, string toDataTypeName)
			{
				return true;
			}

			public bool CanAdapt(string fromDataTypeName, Type toDataType)
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

		public virtual DataTypeAdapter GetAdapter(string fromDataTypeName, Type toDataType)
		{
			DataTypeAdapter matchingAdapter = NULL_DATA_TYPE_ADAPTER;
			foreach (DataTypeAdapter adapter in adapters)
			{
				if (adapter.CanAdapt(fromDataTypeName, toDataType))
				{
					matchingAdapter = adapter;
					break;
				}
			}
			return matchingAdapter;
		}
	}
}
