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

namespace Ca.Infoway.Messagebuilder.Xml.Cda.Vocabulary
{
	[RootAttribute(Strict = false)]
	public class Code
	{
		[XmlAttributeAttribute(Required = false)]
		private string value;

		[XmlAttributeAttribute(Required = false)]
		private string displayName;

		[XmlAttributeAttribute(Required = false)]
		private string codeSystemName;

		[XmlAttributeAttribute(Required = false)]
		private string codeSystem;

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

		public virtual string DisplayName
		{
			get
			{
				return displayName;
			}
			set
			{
				string displayName = value;
				this.displayName = displayName;
			}
		}

		public virtual string CodeSystemName
		{
			get
			{
				return codeSystemName;
			}
			set
			{
				string codeSystemName = value;
				this.codeSystemName = codeSystemName;
			}
		}

		public virtual string CodeSystem
		{
			get
			{
				return codeSystem;
			}
			set
			{
				string codeSystem = value;
				this.codeSystem = codeSystem;
			}
		}
	}
}
