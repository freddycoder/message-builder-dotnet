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

namespace Ca.Infoway.Messagebuilder.Domainvalue.Controlact
{
	/// <summary>The Enum ActStatus.</summary>
	/// <remarks>The Enum ActStatus. Codes representing the defined states of an Act as defined by the Act class state machine.</remarks>
	[System.Serializable]
	public class ActStatus : EnumPattern, Ca.Infoway.Messagebuilder.Domainvalue.ActStatus, Describable
	{
		static ActStatus()
		{
		}

		private const long serialVersionUID = 7809865843109575750L;

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActStatus NORMAL = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActStatus
			("NORMAL");

		/// <summary>The Act has been terminated prior to the originally intended completion.</summary>
		/// <remarks>The Act has been terminated prior to the originally intended completion.</remarks>
		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActStatus ABORTED = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActStatus
			("ABORTED");

		/// <summary>The Act can be performed or is being performed.</summary>
		/// <remarks>The Act can be performed or is being performed.</remarks>
		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActStatus ACTIVE = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActStatus
			("ACTIVE");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActStatus CANCELLED = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActStatus
			("CANCELLED");

		/// <summary>
		/// An Act that has terminated normally after all of its constituents
		/// has been performed.
		/// </summary>
		/// <remarks>
		/// An Act that has terminated normally after all of its constituents
		/// has been performed.
		/// </remarks>
		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActStatus COMPLETED = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActStatus
			("COMPLETED");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActStatus HELD = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActStatus
			("HELD");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActStatus NEW = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActStatus
			("NEW");

		/// <summary>
		/// An Act that has been activated (actions could or have been performed against
		/// it), but has been temporarily disabled.
		/// </summary>
		/// <remarks>
		/// An Act that has been activated (actions could or have been performed against
		/// it), but has been temporarily disabled. No further action should be taken against
		/// it until it is released
		/// </remarks>
		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActStatus SUSPENDED = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActStatus
			("SUSPENDED");

		/// <summary>
		/// This Act instance was created in error and has been 'removed' and is treated
		/// as though it never existed.
		/// </summary>
		/// <remarks>
		/// This Act instance was created in error and has been 'removed' and is treated
		/// as though it never existed. A record is retained for audit purposes only.
		/// </remarks>
		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActStatus NULLIFIED = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActStatus
			("NULLIFIED");

		/// <summary>This Act instance has been replaced by a new instance.</summary>
		/// <remarks>This Act instance has been replaced by a new instance.</remarks>
		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActStatus OBSOLETE = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActStatus
			("OBSOLETE");

		private ActStatus(string name) : base(name)
		{
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual string CodeSystem
		{
			get
			{
				return Ca.Infoway.Messagebuilder.Codesystem.CodeSystem.VOCABULARY_ACT_STATUS.Root;
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
				// Act Status is special in using lower case for its code values
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
