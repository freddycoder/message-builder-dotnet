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
using System.Reflection;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Marshalling.Datatypeadapter;
using Ca.Infoway.Messagebuilder.Platform;
using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling.Datatypeadapter
{
	public class CollectionToSetOfTnAdapter : DataTypeAdapter
	{
		public virtual bool CanAdapt(Type fromDataType, string toDataTypeName)
		{
            if (IsCOLLECTIONType(fromDataType) && StandardDataType.SET.Equals(StandardDataType.GetByTypeName
				(toDataTypeName)) && ContainerOfTn(toDataTypeName))
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

		private bool ContainerOfTn(string fromDataTypeName)
		{
			bool containerOfTn = false;
			IList<Hl7TypeName> parameters = Hl7TypeName.Parse(fromDataTypeName).Parameters;
			if (parameters != null && !parameters.IsEmpty())
			{
				foreach (Hl7TypeName parameter in parameters)
				{
					if (StandardDataType.TN.RootType.Equals(parameter.RootName))
					{
						containerOfTn = true;
					}
				}
			}
			return containerOfTn;
		}

		public virtual bool CanAdapt(string fromDataTypeName, Type toDataType)
		{
			return false;
		}

		public virtual BareANY Adapt(Type toDataType, BareANY any)
		{
			return any;
		}

		public virtual BareANY Adapt(string toDataTypeName, BareANY any)
		{
            MethodInfo rawCollectionMethod = any.GetType().GetMethod("RawCollection");
            ICollection<object> collection = (ICollection<object>)rawCollectionMethod.Invoke(any, new object[] { });
            SETImpl<TNImpl, TrivialName> adaptedSet = new SETImpl<TNImpl, TrivialName>(typeof(TNImpl));
			if (any.HasNullFlavor())
			{
				NullFlavor nullFlavor = any.NullFlavor;
				adaptedSet.NullFlavor = nullFlavor;
			}
			else
			{
				adaptedSet.RawSet().AddAll(ToSetOfTrivialName(collection));
			}
			return adaptedSet;
		}

		private ICollection<TrivialName> ToSetOfTrivialName(ICollection<object> collection)
		{
            ICollection<TrivialName> set = new LinkedSet<TrivialName>();
			foreach (object element in collection)
			{
				set.Add(new TrivialName(element.ToString()));
			}
			return set;
		}
	}
}
