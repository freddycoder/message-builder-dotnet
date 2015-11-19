using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using ILOG.J2CsMapping.Collections.Generics;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7
{
	/// <summary>
	/// ANY, ANY.LAB, ANY.CA.IZ, ANY.PATH; added for BC: ANY.X1, ANY.X2
	/// Each value sent over the wire must correspond to one of the
	/// following non-abstract data type flavor specifications defined below:
	/// ANY:       all types allowed
	/// ANY.LAB:   CD.LAB, ST, PQ.LAB, IVL, INT.NONNEG, INT.POS, TS.FULLDATETIME, URG
	/// ANY.CA.IZ: ST, PN.BASIC, INT.POS, BL
	/// ANY.PATH:  ST, PQ, ED.DOCORREF or CD.LAB
	/// ANY.X1:    ST, CV, PQ.LAB, IVL, URG
	/// ANY.X2:    ST, CV, ED.DOCORREF
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

		private static IList<string> ANY_X1_LIST = Arrays.AsList(new string[] { StandardDataType.CV.Type, StandardDataType.ST.Type
			, StandardDataType.PQ_LAB.Type, StandardDataType.IVL_PQ_BASIC.Type, StandardDataType.IVL_PQ_DISTANCE.Type, StandardDataType
			.IVL_PQ_DRUG.Type, StandardDataType.IVL_PQ_HEIGHTWEIGHT.Type, StandardDataType.IVL_PQ_LAB.Type, StandardDataType.IVL_PQ_TIME
			.Type, StandardDataType.URG_PQ_LAB.Type });

		private static IList<string> ANY_X2_LIST = Arrays.AsList(new string[] { StandardDataType.CV.Type, StandardDataType.ST.Type
			, StandardDataType.ED_DOC_OR_REF.Type });

		private static IDictionary<string, IList<string>> validTypesForAnyType = new Dictionary<string, IList<string>>();

		static AnyHelper()
		{
			validTypesForAnyType["ANY.LAB"] = ANY_LAB_LIST;
			validTypesForAnyType["ANY.CA.IZ"] = ANY_CA_IZ_LIST;
			validTypesForAnyType["ANY.PATH"] = ANY_PATH_LIST;
			validTypesForAnyType["ANY.x1"] = ANY_X1_LIST;
			validTypesForAnyType["ANY.x2"] = ANY_X2_LIST;
		}

		public static bool IsValidTypeForAny(string type, string specializationType)
		{
			// this method expects collection type info (LIST, SET, COLLECTION) to be already removed from speciaizationType
			if ("ANY".Equals(type))
			{
				// any valid type other than ANY (and its variants) are allowed
				StandardDataType specializationTypeAsEnum = StandardDataType.GetByTypeName(specializationType);
				return specializationType != null && !specializationType.StartsWith("ANY") && specializationTypeAsEnum != null;
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
