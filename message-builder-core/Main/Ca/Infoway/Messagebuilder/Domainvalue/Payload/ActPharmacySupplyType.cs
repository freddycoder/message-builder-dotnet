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
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Domainvalue.Util;
using Ca.Infoway.Messagebuilder.Lang;

namespace Ca.Infoway.Messagebuilder.Domainvalue.Payload
{
	/// <summary>The Enum ActPharmacySupplyType.</summary>
	/// <remarks>The Enum ActPharmacySupplyType. Identifies types of dispensing events</remarks>
	[System.Serializable]
	public class ActPharmacySupplyType : EnumPattern, Ca.Infoway.Messagebuilder.Domainvalue.ActPharmacySupplyType, Describable
	{
		static ActPharmacySupplyType()
		{
		}

		private const long serialVersionUID = -4833727160525452059L;

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActPharmacySupplyType DAILY_FILL = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActPharmacySupplyType
			("DAILY_FILL", "DF");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActPharmacySupplyType EMERGENCY_SUPPLY = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActPharmacySupplyType
			("EMERGENCY_SUPPLY", "EM");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActPharmacySupplyType SCRIPT_OWING = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActPharmacySupplyType
			("SCRIPT_OWING", "SO");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActPharmacySupplyType FIRST_FILL = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActPharmacySupplyType
			("FIRST_FILL", "FF");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActPharmacySupplyType FIRST_FILL_COMPLETE = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActPharmacySupplyType
			("FIRST_FILL_COMPLETE", "FFC");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActPharmacySupplyType FIRST_FILL_COMPLETE_PARTIAL_STRENGTH
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActPharmacySupplyType("FIRST_FILL_COMPLETE_PARTIAL_STRENGTH", "FFCS"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActPharmacySupplyType FIRST_FILL_PART_FILL = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActPharmacySupplyType
			("FIRST_FILL_PART_FILL", "FFP");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActPharmacySupplyType FIRST_FILL_PART_FILL_PARTIAL_STRENGTH
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActPharmacySupplyType("FIRST_FILL_PART_FILL_PARTIAL_STRENGTH", "FFPS"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActPharmacySupplyType FEE_FOR_SERVICE = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActPharmacySupplyType
			("FEE_FOR_SERVICE", "FFS");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActPharmacySupplyType FIRST_FILL_PARTIAL_STRENGTH = 
			new Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActPharmacySupplyType("FIRST_FILL_PARTIAL_STRENGTH", "TFS");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActPharmacySupplyType TRIAL_FILL = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActPharmacySupplyType
			("TRIAL_FILL", "TF");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActPharmacySupplyType FLOOR_STOCK = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActPharmacySupplyType
			("FLOOR_STOCK", "FS");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActPharmacySupplyType MANUFACTURER_SAMPLE = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActPharmacySupplyType
			("MANUFACTURER_SAMPLE", "MS");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActPharmacySupplyType REFILL = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActPharmacySupplyType
			("REFILL", "RF");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActPharmacySupplyType REFILL_COMPLETE = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActPharmacySupplyType
			("REFILL_COMPLETE", "RFC");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActPharmacySupplyType REFILL_COMPLETE_PARTIAL_STRENGTH
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActPharmacySupplyType("REFILL_COMPLETE_PARTIAL_STRENGTH", "RFCS");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActPharmacySupplyType REFILL_FIRST_FILL_THIS_FACILITY
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActPharmacySupplyType("REFILL_FIRST_FILL_THIS_FACILITY", "RFF");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActPharmacySupplyType REFILL_PARTIAL_STRENGTH_FIRST_FILL_THIS_FACILITY
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActPharmacySupplyType("REFILL_PARTIAL_STRENGTH_FIRST_FILL_THIS_FACILITY"
			, "RFFS");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActPharmacySupplyType REFILL_PART_FILL = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActPharmacySupplyType
			("REFILL_PART_FILL", "RFP");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActPharmacySupplyType REFILL_PART_FILL_PARTIAL_STRENGTH
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActPharmacySupplyType("REFILL_PART_FILL_PARTIAL_STRENGTH", "RFPS");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActPharmacySupplyType REFILL_PARTIAL_STRENGTH = new 
			Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActPharmacySupplyType("REFILL_PARTIAL_STRENGTH", "RFS");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActPharmacySupplyType TRIAL_BALANCE = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActPharmacySupplyType
			("TRIAL_BALANCE", "TB");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActPharmacySupplyType TRIAL_BALANCE_PARTIAL_STRENGTH
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActPharmacySupplyType("TRIAL_BALANCE_PARTIAL_STRENGTH", "TBS");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActPharmacySupplyType UNIT_DOSE_EQUIVALENT = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActPharmacySupplyType
			("UNIT_DOSE_EQUIVALENT", "UDE");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActPharmacySupplyType UNIT_DOSE = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActPharmacySupplyType
			("UNIT_DOSE", "UD");

		private readonly string codeValue;

		private ActPharmacySupplyType(string name, string codeValue) : base(name)
		{
			this.codeValue = codeValue;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual string CodeValue
		{
			get
			{
				return this.codeValue;
			}
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual string CodeSystem
		{
			get
			{
				return Ca.Infoway.Messagebuilder.Codesystem.CodeSystem.VOCABULARY_ACT_CODE.Root;
			}
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual string CodeSystemName
		{
			get
			{
				return null;
			}
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual string Description
		{
			get
			{
				return DescribableUtil.GetDefaultDescription(this);
			}
		}
	}
}
