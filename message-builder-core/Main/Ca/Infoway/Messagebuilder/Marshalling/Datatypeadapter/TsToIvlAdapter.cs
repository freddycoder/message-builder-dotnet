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
			// TM - should this cover all IVL<TS.x> cases? what about IVL.HIGH/.LOW/.WIDTH?
			// (not a major concern, as this code is primarily meant to work with legacy NFLD transformation tests)
			if (typeof(TS).IsAssignableFrom(fromDataType) && (StandardDataType.IVL_FULL_DATE.Type.Equals(toDataTypeName) || StandardDataType
				.IVL_FULL_DATE_WITH_TIME.Type.Equals(toDataTypeName)))
			{
				return true;
			}
			return false;
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
			return new DataTypeAdapterHelper().CopyAndReturnAdapted(any, (BareANY)new IVLImpl<TS, Interval<PlatformDate>>(), any.BareValue
				 != null ? IntervalFactory.CreateLowHigh<PlatformDate>((PlatformDate)any.BareValue, (PlatformDate)any.BareValue) : null);
		}
	}
}
