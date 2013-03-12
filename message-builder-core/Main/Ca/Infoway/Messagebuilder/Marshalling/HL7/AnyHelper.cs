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
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using ILOG.J2CsMapping.Collections.Generics;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7
{
	/// <summary>
	/// ANY, ANY.LAB, ANY.CA.IZ, ANY.PATH
	/// Each value sent over the wire must correspond to one of the
	/// following non-abstract data type flavor specifications defined below:
	/// ANY:       all types allowed
	/// ANY.LAB:   CD.LAB, ST, PQ.LAB, IVL, INT.NONNEG, INT.POS, TS.FULLDATETIME, URG
	/// ANY.CA.IZ: ST, PN.BASIC, INT.POS, BL
	/// ANY.PATH:  ST, PQ, ED.DOCORREF or CD.LAB
	/// </summary>
	/// <author>Intelliware Development</author>
	public class AnyHelper
	{
		private static IList<string> ANY_LAB_LIST = Arrays.AsList(new string[] { StandardDataType.CD_LAB.Type, StandardDataType.ST
			.Type, StandardDataType.PQ_LAB.Type, StandardDataType.IVL_PQ_BASIC.Type, StandardDataType.IVL_PQ_DISTANCE.Type, StandardDataType
			.IVL_PQ_DRUG.Type, StandardDataType.IVL_PQ_HEIGHTWEIGHT.Type, StandardDataType.IVL_PQ_LAB.Type, StandardDataType.IVL_PQ_TIME
			.Type, StandardDataType.INT_NONNEG.Type, StandardDataType.INT_POS.Type, StandardDataType.TS_FULLDATETIME.Type, StandardDataType
			.URG_PQ_BASIC.Type, StandardDataType.URG_PQ_DISTANCE.Type, StandardDataType.URG_PQ_DRUG.Type, StandardDataType.URG_PQ_HEIGHTWEIGHT
			.Type, StandardDataType.URG_PQ_LAB.Type, StandardDataType.URG_PQ_TIME.Type });

		private static IList<string> ANY_PATH_LIST = Arrays.AsList(new string[] { StandardDataType.ST.Type, StandardDataType.PQ_BASIC
			.Type, StandardDataType.PQ_DISTANCE.Type, StandardDataType.PQ_DRUG.Type, StandardDataType.PQ_HEIGHTWEIGHT.Type, StandardDataType
			.PQ_LAB.Type, StandardDataType.PQ_TIME.Type, StandardDataType.ED_DOC_OR_REF.Type, StandardDataType.CD_LAB.Type });

		private static IList<string> ANY_CA_IZ_LIST = Arrays.AsList(new string[] { StandardDataType.ST.Type, StandardDataType.PN_BASIC
			.Type, StandardDataType.INT_POS.Type, StandardDataType.BL.Type });

		private static IDictionary<string, IList<string>> validTypesForAnyType = new Dictionary<string, IList<string>>();

		static AnyHelper()
		{
			validTypesForAnyType["ANY.LAB"] = ANY_LAB_LIST;
			validTypesForAnyType["ANY.CA.IZ"] = ANY_CA_IZ_LIST;
			validTypesForAnyType["ANY.PATH"] = ANY_PATH_LIST;
		}

		public static bool IsValidTypeForAny(string type, string specializationType)
		{
			if ("ANY".Equals(type))
			{
				return true;
			}
			else
			{
				if (AnyHelper.validTypesForAnyType.ContainsKey(type))
				{
					return AnyHelper.validTypesForAnyType.SafeGet(type).Contains(specializationType);
				}
			}
			return false;
		}
	}
}
