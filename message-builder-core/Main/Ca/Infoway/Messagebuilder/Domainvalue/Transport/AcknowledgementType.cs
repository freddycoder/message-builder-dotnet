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
using Ca.Infoway.Messagebuilder.Domainvalue.Util;
using Ca.Infoway.Messagebuilder.Lang;

namespace Ca.Infoway.Messagebuilder.Domainvalue.Transport
{
	/// <summary>The Enum AcknowledgementType.</summary>
	/// <remarks>The Enum AcknowledgementType. This attribute contains an acknowledgement code as described in the HL7 message processing rules.
	/// 	</remarks>
	[System.Serializable]
	public class AcknowledgementType : EnumPattern, Ca.Infoway.Messagebuilder.Domainvalue.AcknowledgementType, Describable
	{
		static AcknowledgementType()
		{
		}

		private const long serialVersionUID = -1689382159743562443L;

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementType ACCEPT_ACKNOWLEDGEMENT_COMMIT_ACCEPT
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementType("ACCEPT_ACKNOWLEDGEMENT_COMMIT_ACCEPT", "CA", 
			true);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementType ACCEPT_ACKNOWLEDGEMENT_COMMIT_ERROR
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementType("ACCEPT_ACKNOWLEDGEMENT_COMMIT_ERROR", "CE", 
			false);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementType ACCEPT_ACKNOWLEDGEMENT_COMMIT_REJECT
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementType("ACCEPT_ACKNOWLEDGEMENT_COMMIT_REJECT", "CR", 
			false);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementType APPLICATION_ACKNOWLEDGEMENT_ACCEPT
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementType("APPLICATION_ACKNOWLEDGEMENT_ACCEPT", "AA", true
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementType APPLICATION_ACKNOWLEDGEMENT_ERROR
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementType("APPLICATION_ACKNOWLEDGEMENT_ERROR", "AE", false
			);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementType APPLICATION_ACKNOWLEDGEMENT_REJECT
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementType("APPLICATION_ACKNOWLEDGEMENT_REJECT", "AR", false
			);

		private readonly string codeValue;

		private readonly bool accepted;

		private AcknowledgementType(string name, string codeValue, bool accepted) : base(name)
		{
			this.codeValue = codeValue;
			this.accepted = accepted;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual string CodeSystem
		{
			get
			{
				return Ca.Infoway.Messagebuilder.Codesystem.CodeSystem.VOCABULARY_ACKNOWLEDGEMENT_TYPE.Root;
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

		/// <summary>Checks if is accepted.</summary>
		/// <remarks>Checks if is accepted.</remarks>
		/// <returns>true, if is accepted</returns>
		public virtual bool IsAccepted()
		{
			return this.accepted;
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
