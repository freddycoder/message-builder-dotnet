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
 * Last modified: $LastChangedDate: 2011-05-04 15:47:15 -0400 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
using System;
using System.Collections.Generic;
using System.Reflection;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Marshalling.Datatypeadapter;

namespace Ca.Infoway.Messagebuilder.Marshalling.Datatypeadapter
{
	public class CollectionOfAnyToAnyAdapter : DataTypeAdapter
	{
		public virtual bool CanAdapt(Type fromDataType, string toDataTypeName)
		{
			if (IsCOLLECTIONType(fromDataType) && !StandardDataType.IsSetOrList(toDataTypeName))
			{
				return true;
			}
			return false;
		}

        private bool IsCOLLECTIONType(Type type) {
            foreach (Type interfaceType in type.GetInterfaces()) {
                if (interfaceType.IsGenericType && interfaceType.GetGenericTypeDefinition() == typeof(COLLECTION<>)) {
                    return true;
                }
            }
            return false;
        }

		public virtual bool CanAdapt(string fromDataTypeName, Type toDateType)
		{
			return false;
		}

		public virtual BareANY Adapt(Type toDateType, BareANY any)
		{
			return any;
		}

		public virtual BareANY Adapt(string toDataTypeName, BareANY any)
		{
            BareANY element = null;
            if (any != null) {
                PropertyInfo property = any.GetType().GetProperty("Value");
                object collectionValue = property.GetValue(any, null);
                if (collectionValue != null) {
                    IEnumerable<BareANY> enumerable = (IEnumerable<BareANY>)collectionValue;
                    IEnumerator<BareANY> enumerator = enumerable.GetEnumerator();
                    if (enumerator.MoveNext()) {
                        element = enumerator.Current;
                    }
                }
            }
            if (element == null) {
                element = new ANYImpl<object>();
            }

			return (BareANY)element;
		}
	}
}
