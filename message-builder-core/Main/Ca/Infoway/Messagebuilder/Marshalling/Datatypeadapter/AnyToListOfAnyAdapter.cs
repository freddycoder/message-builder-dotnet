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
	public class AnyToListOfAnyAdapter : DataTypeAdapter
	{
		public virtual bool CanAdapt(string fromDataTypeName, Type toDataType)
		{
			return !StandardDataType.IsSetOrList(fromDataTypeName) && IsLISTType(toDataType);
		}

		public virtual bool CanAdapt(Type fromDataType, string toDataTypeName)
		{
			return false;
		}

        private bool IsLISTType(Type type) {
            foreach (Type interfaceType in type.GetInterfaces()) {
                if (interfaceType.IsGenericType && interfaceType.GetGenericTypeDefinition() == typeof(LIST<,>)) {
                    return true;
                }
            }
            return false;
        }

		public virtual BareANY Adapt(Type toDataType, BareANY any)
		{
            ConstructorInfo constructor = toDataType.GetConstructor(new Type[] { typeof(Type) });
            object constructedObject = constructor.Invoke(new object[] { any.GetType() });
            PropertyInfo property = toDataType.GetProperty("Value");
            object collectionValue = property.GetValue(constructedObject, null);
            Type collectionType = collectionValue.GetType();
            collectionType.GetMethod("Add").Invoke(collectionValue, new object[] { any });
            return (BareANY)constructedObject;
		}

		public virtual BareANY Adapt(string toDataTypeName, BareANY any)
		{
			return any;
		}
	}
}
