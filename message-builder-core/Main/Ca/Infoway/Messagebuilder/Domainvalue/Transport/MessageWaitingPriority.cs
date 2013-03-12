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
using Ca.Infoway.Messagebuilder.Lang;

namespace Ca.Infoway.Messagebuilder.Domainvalue.Transport
{
	/// <summary>MessageWaitingPriority.</summary>
	/// <remarks>
	/// MessageWaitingPriority.
	/// Indicates that the receiver has messages for the sender
	/// From:
	/// http://www.hl7.org/v3ballot/html/infrastructure/vocabulary/MessageWaitingPriority.htm
	/// </remarks>
	/// <author>Intelliware Development</author>
	[System.Serializable]
	public class MessageWaitingPriority : EnumPattern, Ca.Infoway.Messagebuilder.Domainvalue.MessageWaitingPriority
	{
		static MessageWaitingPriority()
		{
		}

		private const long serialVersionUID = -9181499971666284366L;

		/// <summary>High priority messages are available.</summary>
		/// <remarks>High priority messages are available.</remarks>
		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.MessageWaitingPriority HIGH = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.MessageWaitingPriority
			("HIGH", "H");

		/// <summary>Low priority messages are available.</summary>
		/// <remarks>Low priority messages are available.</remarks>
		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.MessageWaitingPriority LOW = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.MessageWaitingPriority
			("LOW", "L");

		/// <summary>Medium priority messages are available.</summary>
		/// <remarks>Medium priority messages are available.</remarks>
		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.MessageWaitingPriority MEDIUM = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.MessageWaitingPriority
			("MEDIUM", "M");

		private readonly string code;

		private MessageWaitingPriority(string name, string code) : base(name)
		{
			this.code = code;
		}

		/// <summary>Returns the message waiting priority.</summary>
		/// <remarks>Returns the message waiting priority.</remarks>
		/// <returns>the message waiting priority</returns>
		public virtual string GetMessageWaitingPriority()
		{
			return this.code;
		}

		/// <summary>Returns the message waiting priority code system.</summary>
		/// <remarks>Returns the message waiting priority code system.</remarks>
		/// <returns>the message waiting priority code system</returns>
		public virtual string CodeSystem
		{
			get
			{
				return Ca.Infoway.Messagebuilder.Codesystem.CodeSystem.VOCABULARY_MESSAGE_WAITING_PRIORITY.Root;
			}
		}

		/// <summary>Returns the code value.</summary>
		/// <remarks>Returns the code value.</remarks>
		/// <returns>the code value</returns>
		public virtual string CodeValue
		{
			get
			{
				return this.code;
			}
		}
	}
}
