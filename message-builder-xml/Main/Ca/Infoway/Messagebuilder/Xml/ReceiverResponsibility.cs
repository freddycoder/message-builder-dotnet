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


using Platform.SimpleXml;

namespace Ca.Infoway.Messagebuilder.Xml
{
	[RootAttribute]
	public class ReceiverResponsibility
	{
		[XmlAttributeAttribute]
		private string invokeInteraction;

		[XmlAttributeAttribute]
		private bool includeTriggerEvent;

		[ElementAttribute(Required = false, Data = true)]
		private string reason;

		public virtual string InvokeInteraction
		{
			get
			{
				return invokeInteraction;
			}
			set
			{
				string invokeInteraction = value;
				this.invokeInteraction = invokeInteraction;
			}
		}

		public virtual bool IncludeTriggerEvent
		{
			get
			{
				return includeTriggerEvent;
			}
			set
			{
				bool includeTriggerEvent = value;
				this.includeTriggerEvent = includeTriggerEvent;
			}
		}

		public virtual string Reason
		{
			get
			{
				return reason;
			}
			set
			{
				string reason = value;
				this.reason = reason;
			}
		}
	}
}
