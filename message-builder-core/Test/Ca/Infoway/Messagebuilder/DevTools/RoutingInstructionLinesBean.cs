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
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Model;

namespace Ca.Infoway.Messagebuilder.DevTools
{
	[System.Serializable]
	public class RoutingInstructionLinesBean : MessagePartBean
	{
		private const long serialVersionUID = 20111117L;

		private ST keyWordText = new STImpl();

		private ST value = new STImpl();

		//@Hl7PartTypeMapping({"MCCI_MT002100CA.AttentionLine","MCCI_MT002300CA.AttentionLine","MCCI_MT102001CA.AttentionLine"})
		/// <summary>
		/// RoutingType
		/// A:Routing Type
		/// A particular type of guidance for routing the
		/// message.
		/// Allows categorization of routing types or support for
		/// multiple route pieces.
		/// </summary>
		/// <remarks>
		/// RoutingType
		/// A:Routing Type
		/// A particular type of guidance for routing the
		/// message.
		/// Allows categorization of routing types or support for
		/// multiple route pieces. Mandatory to understand the routing
		/// information.
		/// </remarks>
		public virtual string GetKeyWordText()
		{
			//    @Hl7XmlMapping({"keyWordText"})
			return this.keyWordText.Value;
		}

		public virtual void SetKeyWordText(string keyWordText)
		{
			this.keyWordText.Value = keyWordText;
		}

		/// <summary>
		/// RoutingName
		/// B:Routing Name
		/// Indicates the specific value used to route the
		/// item.
		/// Allows internal routing within an application.
		/// </summary>
		public virtual string GetValue()
		{
			//    @Hl7XmlMapping({"value"})
			return this.value.Value;
		}

		public virtual void SetValue(string value)
		{
			this.value.Value = value;
		}
	}
}
