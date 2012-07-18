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
