using System;
using Ca.Infoway.Messagebuilder.Xml;
using Platform.SimpleXml;

namespace Ca.Infoway.Messagebuilder.Xml
{
	[RootAttribute]
	public class MessageSetHistory
	{
		[XmlAttributeAttribute]
		private MessageSetHistory.HistoryType type;

		[XmlAttributeAttribute]
		private string value;

		[XmlAttributeAttribute]
		private Int32? order;

		public enum HistoryType
		{
			DELTA_SET,
			MESSAGE_SET
		}

		public MessageSetHistory()
		{
		}

		public MessageSetHistory(MessageSetHistory.HistoryType type, string value, Int32? order)
		{
			this.value = value;
			this.type = type;
			this.order = order;
		}

		public virtual string Value
		{
			get
			{
				return value;
			}
			set
			{
				this.value = value;
			}
		}

		public virtual MessageSetHistory.HistoryType Type
		{
			get
			{
				return type;
			}
			set
			{
				MessageSetHistory.HistoryType type = value;
				this.type = type;
			}
		}

		public virtual Int32? Order
		{
			get
			{
				return order;
			}
			set
			{
				Int32? order = value;
				this.order = order;
			}
		}
	}
}
