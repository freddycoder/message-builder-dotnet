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
