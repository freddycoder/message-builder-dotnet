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
			.Type, StandardDataType.PQ_LAB.Type, StandardDataType.IVL_PQ.Type, StandardDataType.INT_NONNEG.Type, StandardDataType.INT_POS
			.Type, StandardDataType.TS_FULLDATETIME.Type, StandardDataType.URG_PQ.Type });

		private static IList<string> ANY_PATH_LIST = Arrays.AsList(new string[] { StandardDataType.ST.Type, StandardDataType.PQ.Type
			, StandardDataType.ED_DOC_OR_REF.Type, StandardDataType.CD_LAB.Type });

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
