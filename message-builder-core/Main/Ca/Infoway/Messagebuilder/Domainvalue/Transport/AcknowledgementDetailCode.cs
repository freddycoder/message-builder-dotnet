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


using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Domainvalue.Util;
using Ca.Infoway.Messagebuilder.Lang;

namespace Ca.Infoway.Messagebuilder.Domainvalue.Transport
{
	/// <summary>The Enum AcknowledgementDetailCode.</summary>
	/// <remarks>The Enum AcknowledgementDetailCode. A site specific code indicating the specific problem being reported by this Ack Detail.
	/// 	</remarks>
	[System.Serializable]
	public class AcknowledgementDetailCode : EnumPattern, Ca.Infoway.Messagebuilder.Domainvalue.AcknowledgementDetailCode, Describable
	{
		static AcknowledgementDetailCode()
		{
		}

		private const long serialVersionUID = 7919022582239626775L;

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementDetailCode INTERNAL_SYSTEM_ERROR = 
			new Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementDetailCode("INTERNAL_SYSTEM_ERROR", "INTERR");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementDetailCode MESSAGE_ROUTING_ERROR_DESTINATION_UNREACHABLE
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementDetailCode("MESSAGE_ROUTING_ERROR_DESTINATION_UNREACHABLE"
			, "RTEDEST");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementDetailCode MESSAGE_ROUTING_ERROR_UNKNOWN_DESTINATION
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementDetailCode("MESSAGE_ROUTING_ERROR_UNKNOWN_DESTINATION"
			, "RTUDEST");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementDetailCode MESSAGE_ROUTING_WARNING_DESTINATION_UNREACHABLE
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementDetailCode("MESSAGE_ROUTING_WARNING_DESTINATION_UNREACHABLE"
			, "RTWDEST");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementDetailCode NO_STORAGE_SPACE_FOR_MESSAGE
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementDetailCode("NO_STORAGE_SPACE_FOR_MESSAGE", "NOSTORE"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementDetailCode SYNTAX_ERROR = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementDetailCode
			("SYNTAX_ERROR", "SYN");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementDetailCode SYNTAX_ERROR_REQUIRED_ASSOCIATION_MISSING
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementDetailCode("SYNTAX_ERROR_REQUIRED_ASSOCIATION_MISSING"
			, "SYN100");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementDetailCode SYNTAX_ERROR_REQUIRED_ATTRIBUTE_MISSING
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementDetailCode("SYNTAX_ERROR_REQUIRED_ATTRIBUTE_MISSING"
			, "SYN101");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementDetailCode SYNTAX_ERROR_DATA_TYPE_ERROR
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementDetailCode("SYNTAX_ERROR_DATA_TYPE_ERROR", "SYN102"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementDetailCode SYNTAX_ERROR_VALUE_NOT_FOUND_IN_CODE_SYSTEM
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementDetailCode("SYNTAX_ERROR_VALUE_NOT_FOUND_IN_CODE_SYSTEM"
			, "SYN103");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementDetailCode SYNTAX_ERROR_INVALID_CODE_SYSTEM_IN_CNE
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementDetailCode("SYNTAX_ERROR_INVALID_CODE_SYSTEM_IN_CNE"
			, "SYN104");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementDetailCode SYNTAX_ERROR_REQUIRED_ELEMENT_MISSING
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementDetailCode("SYNTAX_ERROR_REQUIRED_ELEMENT_MISSING"
			, "SYN105");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementDetailCode SYNTAX_ERROR_TERMINOLOGY_ERROR
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementDetailCode("SYNTAX_ERROR_TERMINOLOGY_ERROR", "SYN106"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementDetailCode SYNTAX_ERROR_DEPRECATED_CODE
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementDetailCode("SYNTAX_ERROR_DEPRECATED_CODE", "SYN107"
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementDetailCode SYNTAX_ERROR_NUMBER_OF_REPETITIONS_EXCEEDS_LIMIT
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementDetailCode("SYNTAX_ERROR_NUMBER_OF_REPETITIONS_EXCEEDS_LIMIT"
			, "SYN108");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementDetailCode SYNTAX_ERROR_MANDATORY_ELEMENT_WITH_NULL_VALUE
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementDetailCode("SYNTAX_ERROR_MANDATORY_ELEMENT_WITH_NULL_VALUE"
			, "SYN109");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementDetailCode SYNTAX_ERROR_NUMBER_OF_ASSOCIATION_REPETITIONS_EXCEEDS_LIMIT
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementDetailCode("SYNTAX_ERROR_NUMBER_OF_ASSOCIATION_REPETITIONS_EXCEEDS_LIMIT"
			, "SYN110");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementDetailCode SYNTAX_ERROR_VALUE_DOES_NOT_MATCH_FIXED_VALUE
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementDetailCode("SYNTAX_ERROR_VALUE_DOES_NOT_MATCH_FIXED_VALUE"
			, "SYN111");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementDetailCode SYNTAX_ERROR_NUMBER_OF_ATTRIBUTE_REPETITIONS_EXCEEDS_LIMIT
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementDetailCode("SYNTAX_ERROR_NUMBER_OF_ATTRIBUTE_REPETITIONS_EXCEEDS_LIMIT"
			, "SYN112");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementDetailCode SYNTAX_ERROR_FORMAL_CONSTRAINT_VIOLATION
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementDetailCode("SYNTAX_ERROR_FORMAL_CONSTRAINT_VIOLATION"
			, "SYN113");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementDetailCode SYNTAX_ERROR_INSUFFICIENT_REPETITIONS
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementDetailCode("SYNTAX_ERROR_INSUFFICIENT_REPETITIONS"
			, "SYN114");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementDetailCode UNKNOWN_SENDER = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementDetailCode
			("UNKNOWN_SENDER", "NS260");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementDetailCode UNRECOGNIZED_ATTENTIONLINE
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementDetailCode("UNRECOGNIZED_ATTENTIONLINE", "NS261");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementDetailCode UNSUPPORTED_INTERACTION = 
			new Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementDetailCode("UNSUPPORTED_INTERACTION", "NS200");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementDetailCode UNSUPPORTED_PROCESSING_ID
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementDetailCode("UNSUPPORTED_PROCESSING_ID", "NS202");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementDetailCode UNSUPPORTED_VERSION_ID = 
			new Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementDetailCode("UNSUPPORTED_VERSION_ID", "NS203");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementDetailCode UNSUPPORTED_PROCESSING_MODE
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementDetailCode("UNSUPPORTED_PROCESSING_MODE", "NS250");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementDetailCode NOT_APPLICABLE = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementDetailCode
			("NOT_APPLICABLE", Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NOT_APPLICABLE);

		private readonly string codeValue;

		private readonly NullFlavor nullFlavor;

		private AcknowledgementDetailCode(string name, string codeValue) : base(name)
		{
			this.codeValue = codeValue;
			this.nullFlavor = null;
		}

		private AcknowledgementDetailCode(string name, NullFlavor nullFlavor) : base(name)
		{
			this.codeValue = null;
			this.nullFlavor = nullFlavor;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual string CodeSystem
		{
			get
			{
				return Ca.Infoway.Messagebuilder.Codesystem.CodeSystem.VOCABULARY_ACKNOWLEDGEMENT_DETAIL_CODE.Root;
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
		public virtual string CodeValue
		{
			get
			{
				return this.codeValue;
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

		/// <summary>Gets the null flavor.</summary>
		/// <remarks>Gets the null flavor.</remarks>
		/// <returns>the null flavor</returns>
		public virtual NullFlavor GetNullFlavor()
		{
			return this.nullFlavor;
		}

		/// <summary>Checks for null flavor.</summary>
		/// <remarks>Checks for null flavor.</remarks>
		/// <returns>true, if successful</returns>
		public virtual bool HasNullFlavor()
		{
			return this.nullFlavor != null;
		}
	}
}
