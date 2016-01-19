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


using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Xml;
using Platform.SimpleXml;

namespace Ca.Infoway.Messagebuilder.Xml
{
	public class ValueSet
	{
		[XmlAttributeAttribute]
		private string name;

		[XmlAttributeAttribute(Required = false)]
		private string id;

		[XmlAttributeAttribute(Required = false)]
		private PlatformDate date;

		[XmlAttributeAttribute(Required = false)]
		private string owningSCWG;

		[XmlAttributeAttribute(Required = false)]
		private string codeSystem;

		[XmlAttributeAttribute(Required = false)]
		private bool complete = false;

		[ElementAttribute(Required = false)]
		private Ca.Infoway.Messagebuilder.Xml.Documentation documentation = new Ca.Infoway.Messagebuilder.Xml.Documentation();

		[ElementListAttribute(Required = false, Inline = true, Entry = "contextBinding")]
		private IList<ContextBinding> contextBindings = new List<ContextBinding>();

		[ElementListAttribute(Required = false, Inline = true, Entry = "drawsFrom")]
		private IList<string> sourceCodeSystems = new List<string>();

		[ElementListAttribute(Required = false, Inline = false, Name = "content", Entry = "code")]
		private List<Code> codes;

		[ElementListAttribute(Required = false, Inline = true, Entry = "filter")]
		private IList<ValueSetFilter> filters;

		public virtual bool Complete
		{
			get
			{
				// RM 17524: TM - changed to ArrayList to prevent simpleframework from outputting java class reference
				return complete;
			}
			set
			{
				bool complete = value;
				this.complete = complete;
			}
		}

		public ValueSet()
		{
		}

		public ValueSet(string name, string id)
		{
			this.Name = name;
			this.Id = id;
		}

		public virtual string Name
		{
			get
			{
				return this.name;
			}
			set
			{
				string name = value;
				this.name = name;
			}
		}

		public virtual string CodeSystem
		{
			get
			{
				return this.codeSystem;
			}
			set
			{
				string codeSystem = value;
				this.codeSystem = codeSystem;
			}
		}

		public virtual IList<ContextBinding> ContextBindings
		{
			get
			{
				return this.contextBindings;
			}
			set
			{
				IList<ContextBinding> contextBindings = value;
				this.contextBindings = contextBindings;
			}
		}

		public virtual string Id
		{
			get
			{
				return id;
			}
			set
			{
				string id = value;
				this.id = id;
			}
		}

		public virtual PlatformDate Date
		{
			get
			{
				return date;
			}
			set
			{
				PlatformDate date = value;
				this.date = date;
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

		public virtual string OwningSCWG
		{
			get
			{
				return owningSCWG;
			}
			set
			{
				string owningSCWG = value;
				this.owningSCWG = owningSCWG;
			}
		}

		public virtual List<Code> Codes
		{
			get
			{
				return codes;
			}
			set
			{
				List<Code> codes = value;
				this.codes = codes;
			}
		}

		public virtual void AddCode(Code code)
		{
			if (this.codes == null)
			{
				this.codes = new List<Code>();
			}
			this.codes.Add(code);
		}

		public virtual IList<string> SourceCodeSystems
		{
			get
			{
				return sourceCodeSystems;
			}
			set
			{
				IList<string> sourceCodeSystems = value;
				this.sourceCodeSystems = sourceCodeSystems;
			}
		}

		public virtual IList<ValueSetFilter> Filters
		{
			get
			{
				return filters;
			}
			set
			{
				IList<ValueSetFilter> filters = value;
				this.filters = filters;
			}
		}

		public virtual void AddFilter(ValueSetFilter filter)
		{
			if (this.filters == null)
			{
				this.filters = new List<ValueSetFilter>();
			}
			this.filters.Add(filter);
		}
	}
}
