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
using Ca.Infoway.Messagebuilder;

namespace Ca.Infoway.Messagebuilder.Util.Xml
{
	public class ConformanceLevelUtil
	{
		public static readonly string ASSOCIATION_IS_IGNORED_AND_CAN_NOT_BE_USED = "Association is ignored and can not be used: ({0})";

		public static readonly string ASSOCIATION_IS_IGNORED_AND_WILL_NOT_BE_USED = "Association is ignored and will not be used: ({0})";

		public static readonly string ATTRIBUTE_IS_IGNORED_AND_CAN_NOT_BE_USED = "Attribute is ignored and can not be used: ({0})";

		public static readonly string ATTRIBUTE_IS_IGNORED_AND_WILL_NOT_BE_USED = "Attribute is ignored and will not be used: ({0})";

		public static readonly string ASSOCIATION_IS_NOT_ALLOWED = "Association is not allowed: ({0})";

		public static readonly string ATTRIBUTE_IS_NOT_ALLOWED = "Attribute is not allowed: ({0})";

		public static readonly string IGNORED_AS_NOT_ALLOWED = "ignored.as.not.allowed";

		public static bool IsIgnoredNotAllowed()
		{
			return ILOG.J2CsMapping.Util.BooleanUtil.ValueOf(Runtime.GetProperty(IGNORED_AS_NOT_ALLOWED));
		}
	}
}
