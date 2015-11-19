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
