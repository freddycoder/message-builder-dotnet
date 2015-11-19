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

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7
{
	public class MessageTypeKey
	{
		private readonly string version;

		private readonly string messageId;

		public MessageTypeKey(VersionNumber version, string messageId) : this(version.VersionLiteral, messageId)
		{
		}

		public MessageTypeKey(string version, string messageId)
		{
			this.version = version;
			this.messageId = messageId;
		}

		public virtual string GetVersion()
		{
			return this.version;
		}

		public virtual string GetMessageId()
		{
			return this.messageId;
		}

		public override int GetHashCode()
		{
			return new HashCodeBuilder().Append(this.version).Append(this.messageId).ToHashCode();
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			else
			{
				if (obj == this)
				{
					return true;
				}
				else
				{
					if (GetType() != obj.GetType())
					{
						return false;
					}
					else
					{
						Ca.Infoway.Messagebuilder.Marshalling.HL7.MessageTypeKey that = (Ca.Infoway.Messagebuilder.Marshalling.HL7.MessageTypeKey
							)obj;
						return new EqualsBuilder().Append(this.version, that.version).Append(this.messageId, that.messageId).IsEquals();
					}
				}
			}
		}

		public override string ToString()
		{
			return "[MessageType=" + this.messageId + ",version=" + this.version + "]";
		}
	}
}
