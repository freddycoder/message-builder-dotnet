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
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Lang;
using ILOG.J2CsMapping.Collections.Generics;
using ILOG.J2CsMapping.Text;

namespace Ca.Infoway.Messagebuilder.Marshalling.Polymorphism
{
	public class PolymorphismHandler
	{
		private static IDictionary<StandardDataType, IList<StandardDataType>> allowedMappings = new Dictionary<StandardDataType, 
			IList<StandardDataType>>();

		private static IDictionary<StandardDataType, StandardDataType> cdaR1MappingsToNew = new Dictionary<StandardDataType, StandardDataType
			>();

		private static IDictionary<StandardDataType, StandardDataType> cdaR1MappingsToOld = new Dictionary<StandardDataType, StandardDataType
			>();

		static PolymorphismHandler()
		{
			//Only 1 static init block in .NET
			//Static imports here seem to confuse sharpen
			allowedMappings[StandardDataType.TS] = Arrays.AsList(StandardDataType.SXCM_TS, StandardDataType.PIVL_TS, StandardDataType
				.IVL_TS, StandardDataType.EIVL_TS);
			allowedMappings[StandardDataType.SXCM_TS] = Arrays.AsList(StandardDataType.PIVL_TS, StandardDataType.IVL_TS, StandardDataType
				.EIVL_TS);
			allowedMappings[StandardDataType.CD] = Arrays.AsList(StandardDataType.CE, StandardDataType.BXIT_CD, StandardDataType.SXCM_CD
				, StandardDataType.CV, StandardDataType.HXIT_CE, StandardDataType.CS, StandardDataType.CO);
			allowedMappings[StandardDataType.CE] = Arrays.AsList(StandardDataType.CV, StandardDataType.HXIT_CE, StandardDataType.CS, 
				StandardDataType.CO);
			allowedMappings[StandardDataType.CV] = Arrays.AsList(StandardDataType.CS, StandardDataType.CO);
			allowedMappings[StandardDataType.EN] = Arrays.AsList(StandardDataType.PN, StandardDataType.ON, StandardDataType.TN);
			cdaR1MappingsToNew[StandardDataType.TS] = StandardDataType.TSCDAR1;
			cdaR1MappingsToNew[StandardDataType.PIVL_TS] = StandardDataType.PIVLTSCDAR1;
			cdaR1MappingsToNew[StandardDataType.SXCM_TS] = StandardDataType.SXCMTSCDAR1;
			cdaR1MappingsToNew[StandardDataType.IVL_TS] = StandardDataType.IVLTSCDAR1;
			cdaR1MappingsToOld[StandardDataType.TSCDAR1] = StandardDataType.TS;
			cdaR1MappingsToOld[StandardDataType.PIVLTSCDAR1] = StandardDataType.PIVL_TS;
			cdaR1MappingsToOld[StandardDataType.SXCMTSCDAR1] = StandardDataType.SXCM_TS;
			cdaR1MappingsToOld[StandardDataType.IVLTSCDAR1] = StandardDataType.IVL_TS;
		}

		public virtual string DetermineActualDataTypeFromXsiType(string modelType, string newTypeFromXsiType, bool isCda, bool isR1
			, ErrorLogger errorLogger)
		{
			StandardDataType newTypeEnum = EnumPattern.ValueOf<StandardDataType>(newTypeFromXsiType);
			return DetermineActualDataType(modelType, newTypeEnum, isCda, isR1, errorLogger);
		}

		public virtual string DetermineActualDataType(string modelType, StandardDataType newTypeEnum, bool isCda, bool isR1, ErrorLogger
			 errorLogger)
		{
			StandardDataType modelTypeEnum = StandardDataType.GetByTypeName(modelType);
			if (!isCda || modelTypeEnum == null || newTypeEnum == null || StandardDataType.IsSetOrList(modelType) || NewTypeIsRootOfCurrent
				(modelTypeEnum, newTypeEnum))
			{
				return modelType;
			}
			return DetermineActualDataType(modelTypeEnum, newTypeEnum, isCda && isR1, errorLogger);
		}

		private string DetermineActualDataType(StandardDataType modelType, StandardDataType newType, bool isCdaR1, ErrorLogger errorLogger
			)
		{
			StandardDataType convertedModelType = modelType;
			if (cdaR1MappingsToOld.ContainsKey(modelType))
			{
				convertedModelType = cdaR1MappingsToOld.SafeGet(modelType);
			}
			string unspecializedModelType = convertedModelType.TypeName.UnspecializedName;
			string unspecializedNewType = newType.TypeName.UnspecializedName;
			// allow ANY handlers and collection handlers deal with type changes on their own
			if (StandardDataType.ANY.Type.Equals(unspecializedModelType) || StandardDataType.IsSetOrList(unspecializedModelType))
			{
				return modelType.Type;
			}
			if (IsValidTypeChange(unspecializedModelType, unspecializedNewType))
			{
				return MapCdaR1Type(newType, isCdaR1);
			}
			else
			{
				string message = System.String.Format("Not able to handle type change from {0} to {1}. Type has been left unchanged.", convertedModelType
					.Type, newType.Type);
				errorLogger.LogError(Hl7ErrorCode.UNSUPPORTED_TYPE_CHANGE, ErrorLevel.WARNING, message);
				return modelType.Type;
			}
		}

		public virtual string MapCdaR1Type(StandardDataType newType, bool isCdaR1)
		{
			if (isCdaR1 && cdaR1MappingsToNew.ContainsKey(newType))
			{
				return cdaR1MappingsToNew.SafeGet(newType).Type;
			}
			return newType.Type;
		}

		internal virtual bool IsValidTypeChange(string currentType, string newType)
		{
			// assumes types come in as IVL<TS> and *not* IVL_TS (which is what xsi:type would have for a value)
			StandardDataType inType = StandardDataType.GetByTypeName(currentType);
			StandardDataType outType = StandardDataType.GetByTypeName(newType);
			return IsValidTypeChange(inType, outType);
		}

		internal virtual bool IsValidTypeChange(StandardDataType currentType, StandardDataType newType)
		{
			// bug fix: if the new type ends up being the root type of the current (model) type, that is valid
			if (currentType != null && currentType.Equals(newType))
			{
				return true;
			}
			IList<StandardDataType> allowedTypes = allowedMappings.SafeGet(currentType);
			return allowedTypes != null && allowedTypes.Contains(newType);
		}

		private bool NewTypeIsRootOfCurrent(StandardDataType currentType, StandardDataType newType)
		{
			return currentType.RootDataType.Equals(newType);
		}
	}
}
