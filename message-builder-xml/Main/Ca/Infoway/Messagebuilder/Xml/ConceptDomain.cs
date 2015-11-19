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
	public class ConceptDomain
	{
		[XmlAttributeAttribute]
		private string name;

		[XmlAttributeAttribute(Required = false)]
		private string owningSCWG;

		[XmlAttributeAttribute(Required = false)]
		private string riskOfChange;

		[ElementAttribute(Required = false)]
		private Ca.Infoway.Messagebuilder.Xml.Documentation documentation = new Ca.Infoway.Messagebuilder.Xml.Documentation();

		[ElementListAttribute(Required = false, Inline = true, Entry = "specializes")]
		private IList<string> parentConceptDomains = new List<string>();

		public ConceptDomain()
		{
		}

		public ConceptDomain(string name)
		{
			this.name = name;
		}

		public ConceptDomain(string name, IList<string> parentConceptDomains) : this(name)
		{
			if (parentConceptDomains != null)
			{
				this.ParentConceptDomains.AddAll(parentConceptDomains);
			}
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

		public virtual IList<string> ParentConceptDomains
		{
			get
			{
				return this.parentConceptDomains;
			}
			set
			{
				IList<string> parentConceptDomains = value;
				this.parentConceptDomains = parentConceptDomains;
			}
		}

		public virtual void AddParent(string parentConceptDomain)
		{
			this.parentConceptDomains.Add(parentConceptDomain);
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

		public virtual string RiskOfChange
		{
			get
			{
				return riskOfChange;
			}
			set
			{
				string riskOfChange = value;
				this.riskOfChange = riskOfChange;
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
	}
}
