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
using System.Collections.Generic;
using Platform.SimpleXml;

namespace Ca.Infoway.Messagebuilder.Xml
{
	public class Concept
	{
		[XmlAttributeAttribute(Required = false)]
		private string code;

		[XmlAttributeAttribute(Required = false)]
		private string displayName;

		[XmlAttributeAttribute(Required = false)]
		private bool selectable;

		[XmlAttributeAttribute(Required = false)]
		private string status;

		[ElementAttribute(Required = false)]
		private Ca.Infoway.Messagebuilder.Xml.Documentation documentation = new Ca.Infoway.Messagebuilder.Xml.Documentation();

		[ElementListAttribute(Required = false, Inline = true, Entry = "parentConcept")]
		private IList<string> parentConcepts;

		public Concept()
		{
		}

		public virtual string Code
		{
			get
			{
				return code;
			}
			set
			{
				string code = value;
				this.code = code;
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

		public virtual bool Selectable
		{
			get
			{
				return selectable;
			}
			set
			{
				bool selectable = value;
				this.selectable = selectable;
			}
		}

		public virtual string Status
		{
			get
			{
				return status;
			}
			set
			{
				string status = value;
				this.status = status;
			}
		}

		public virtual Ca.Infoway.Messagebuilder.Xml.Documentation Documentation
		{
			get
			{
				return documentation;
			}
			set
			{
				Ca.Infoway.Messagebuilder.Xml.Documentation documentation = value;
				this.documentation = documentation;
			}
		}

		public virtual IList<string> ParentConcepts
		{
			get
			{
				return parentConcepts;
			}
			set
			{
				IList<string> parentConcepts = value;
				this.parentConcepts = parentConcepts;
			}
		}

		public virtual void AddParentConcept(string parentConcept)
		{
			if (this.parentConcepts == null)
			{
				this.parentConcepts = new List<string>();
			}
			this.parentConcepts.Add(parentConcept);
		}
	}
}
