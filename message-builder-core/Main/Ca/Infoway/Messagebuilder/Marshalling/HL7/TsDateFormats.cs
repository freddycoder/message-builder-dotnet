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


using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using ILOG.J2CsMapping.Collections.Generics;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7
{
	public class TsDateFormats
	{
		public static readonly string ABSTRACT_TS_IGNORE_SPECIALIZATION_TYPE_ERROR_PROPERTY_NAME = "messagebuilder.abstract.ts.ignore.specializationtype.error";

		public static readonly IDictionary<StandardDataType, IList<string>> formats;

		public static readonly IDictionary<string, string> expandedFormats;

		public static readonly IDictionary<Hl7BaseVersion, IDictionary<StandardDataType, IList<string>>> versionFormatExceptions;

		public static readonly IList<string> datetimeFormatsRequiringWarning;

		static TsDateFormats()
		{
			IDictionary<StandardDataType, IList<string>> map = new Dictionary<StandardDataType, IList<string>>();
			map[StandardDataType.TS_FULLDATETIME] = Arrays.AsList("yyyyMMddHHmmss.SSS0ZZZZZ", "yyyyMMddHHmmss.SSSZZZZZ", "yyyyMMddHHmmssZZZZZ"
				);
			map[StandardDataType.TS_FULLDATEPARTTIME] = Arrays.AsList("yyyyMMddHHmmss.SSS0ZZZZZ", "yyyyMMddHHmmss.SSS0", "yyyyMMddHHmmss.SSSZZZZZ"
				, "yyyyMMddHHmmss.SSS", "yyyyMMddHHmmssZZZZZ", "yyyyMMddHHmmss", "yyyyMMddHHmmZZZZZ", "yyyyMMddHHmm", "yyyyMMddHHZZZZZ", 
				"yyyyMMddHH", "yyyyMMddZZZZZ", "yyyyMMdd");
			// not allowed if non-CeRx
			// not allowed if non-CeRx
			// not allowed if non-CeRx
			// not allowed if non-CeRx
			// not allowed if non-CeRx
			map[StandardDataType.TS_FULLDATE] = Arrays.AsList("yyyyMMdd");
			// this is an abstract type and these formats are only used after issuing a warning (there should be a specializationType); only defined in MR2009
			map[StandardDataType.TS_FULLDATEWITHTIME] = Arrays.AsList("yyyyMMddHHmmss.SSS0ZZZZZ", "yyyyMMddHHmmss.SSSZZZZZ", "yyyyMMddHHmmssZZZZZ"
				, "yyyyMMdd");
			map[StandardDataType.TS_DATE] = Arrays.AsList("yyyyMMdd", "yyyyMM", "yyyy");
			map[StandardDataType.TS_DATETIME] = Arrays.AsList("yyyyMMddHHmmss.SSS0ZZZZZ", "yyyyMMddHHmmss.SSS0", "yyyyMMddHHmmss.SSSZZZZZ"
				, "yyyyMMddHHmmss.SSS", "yyyyMMddHHmmssZZZZZ", "yyyyMMddHHmmss", "yyyyMMddHHmmZZZZZ", "yyyyMMddHHmm", "yyyyMMddHHZZZZZ", 
				"yyyyMMddHH", "yyyyMMddZZZZZ", "yyyyMMdd", "yyyyMMZZZZZ", "yyyyMM", "yyyyZZZZZ", "yyyy");
			// not allowed if non-CeRx
			// not allowed if non-CeRx
			// not allowed if non-CeRx
			// not allowed if non-CeRx
			// not allowed if non-CeRx
			map[StandardDataType.TS] = map.SafeGet(StandardDataType.TS_DATETIME);
			formats = Ca.Infoway.Messagebuilder.CollUtils.CreateUnmodifiableDictionary(map);
			datetimeFormatsRequiringWarning = Arrays.AsList("yyyyMMddHHmmss.SSS0", "yyyyMMddHHmmss.SSS", "yyyyMMddHHmmss", "yyyyMMddHHmm"
				, "yyyyMMddHH");
			IDictionary<string, string> _expandedFormats = new Dictionary<string, string>();
			_expandedFormats["yyyyMMddHHmmss.SSSZZZZZ"] = "yyyyMMddHHmmss.SSS0ZZZZZ";
			_expandedFormats["yyyyMMddHHmmss.SSS"] = "yyyyMMddHHmmss.SSS0";
			expandedFormats = Ca.Infoway.Messagebuilder.CollUtils.CreateUnmodifiableDictionary(_expandedFormats);
			// some older versions have slightly different rules for allowable time formats
			IDictionary<StandardDataType, IList<string>> exceptionMapMR2007 = new Dictionary<StandardDataType, IList<string>>();
			exceptionMapMR2007[StandardDataType.TS_FULLDATEWITHTIME] = CollUtils.EmptyList<string>();
			IDictionary<StandardDataType, IList<string>> exceptionMapCeRx = new Dictionary<StandardDataType, IList<string>>();
			exceptionMapCeRx[StandardDataType.TS_FULLDATEWITHTIME] = CollUtils.EmptyList<string>();
			exceptionMapCeRx[StandardDataType.TS_FULLDATETIME] = Arrays.AsList("yyyyMMddHHmmss");
			exceptionMapCeRx[StandardDataType.TS_DATETIME] = Arrays.AsList("yyyyMMddHHmmss.SSS0", "yyyyMMddHHmmss.SSS", "yyyyMMddHHmmss"
				, "yyyyMMddHHmm", "yyyyMMddHH", "yyyyMMdd", "yyyyMM", "yyyy");
			IDictionary<Hl7BaseVersion, IDictionary<StandardDataType, IList<string>>> versionMap = new Dictionary<Hl7BaseVersion, IDictionary
				<StandardDataType, IList<string>>>();
			versionMap[Hl7BaseVersion.MR2007] = Ca.Infoway.Messagebuilder.CollUtils.CreateUnmodifiableDictionary(exceptionMapMR2007);
			versionMap[Hl7BaseVersion.CERX] = Ca.Infoway.Messagebuilder.CollUtils.CreateUnmodifiableDictionary(exceptionMapCeRx);
			versionFormatExceptions = Ca.Infoway.Messagebuilder.CollUtils.CreateUnmodifiableDictionary(versionMap);
		}

		public static string[] GetAllDateFormats(StandardDataType standardDataType, VersionNumber version)
		{
			if (standardDataType == null || version == null)
			{
				return new string[0];
			}
			IDictionary<StandardDataType, IList<string>> exceptionMap = TsDateFormats.versionFormatExceptions.SafeGet(version.GetBaseVersion
				());
			IList<string> formats = (exceptionMap == null ? null : exceptionMap.SafeGet(standardDataType));
			if (formats == null)
			{
				formats = TsDateFormats.formats.SafeGet(standardDataType);
			}
			return CollUtils.IsEmpty(formats) ? new string[0] : formats.ToArray(new string[formats.Count]);
		}
	}
}
