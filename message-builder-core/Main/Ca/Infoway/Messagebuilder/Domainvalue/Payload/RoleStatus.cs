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

namespace Ca.Infoway.Messagebuilder.Domainvalue.Payload
{
	/// <summary>
	/// Codes representing the defined possible states of an Role, as defined by the Role
	/// class state machine.
	/// </summary>
	/// <remarks>
	/// Codes representing the defined possible states of an Role, as defined by the Role
	/// class state machine.
	/// </remarks>
	/// <author>BC Holmes</author>
	[System.Serializable]
	public class RoleStatus : EnumPattern, Ca.Infoway.Messagebuilder.Domainvalue.RoleStatus, Describable
	{
		static RoleStatus()
		{
		}

		private const long serialVersionUID = 8923741098580990602L;

		/// <summary>The 'typical' state.</summary>
		/// <remarks>
		/// The 'typical' state. Excludes "nullified" which represents the termination state
		/// of a Role instance that was created in error.
		/// </remarks>
		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.RoleStatus NORMAL = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.RoleStatus
			("NORMAL");

		/// <summary>The state representing the fact that the Entity is currently active in the Role.</summary>
		/// <remarks>The state representing the fact that the Entity is currently active in the Role.</remarks>
		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.RoleStatus ACTIVE = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.RoleStatus
			("ACTIVE");

		/// <summary>The terminal state resulting from cancellation of the role prior to activation.</summary>
		/// <remarks>The terminal state resulting from cancellation of the role prior to activation.</remarks>
		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.RoleStatus CANCELLED = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.RoleStatus
			("CANCELLED");

		/// <summary>The state representing that fact that the role has not yet become active.</summary>
		/// <remarks>The state representing that fact that the role has not yet become active.</remarks>
		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.RoleStatus PENDING = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.RoleStatus
			("PENDING");

		/// <summary>The state that represents a suspension of the Entity playing the Role.</summary>
		/// <remarks>
		/// The state that represents a suspension of the Entity playing the Role.
		/// This state is arrived at from the "active" state.
		/// </remarks>
		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.RoleStatus SUSPENDED = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.RoleStatus
			("SUSPENDED");

		/// <summary>The state representing the successful termination of the Role.</summary>
		/// <remarks>The state representing the successful termination of the Role.</remarks>
		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.RoleStatus TERMINATED = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.RoleStatus
			("TERMINATED");

		/// <summary>
		/// The state representing the termination of a Role instance that was created
		/// in error.
		/// </summary>
		/// <remarks>
		/// The state representing the termination of a Role instance that was created
		/// in error.
		/// </remarks>
		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.RoleStatus NULLIFIED = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.RoleStatus
			("NULLIFIED");

		private RoleStatus(string name) : base(name)
		{
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual string CodeSystem
		{
			get
			{
				return Ca.Infoway.Messagebuilder.Codesystem.CodeSystem.VOCABULARY_ROLE_STATUS.Root;
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
				// another unusual case where the code value is in lower case
				return Name.ToLower();
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
