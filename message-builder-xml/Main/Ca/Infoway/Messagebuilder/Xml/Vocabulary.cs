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
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Xml;
using Platform.SimpleXml;

namespace Ca.Infoway.Messagebuilder.Xml
{
	[RootAttribute]
	public class Vocabulary
	{
		[ElementListAttribute(Inline = true, Required = false, Entry = "valueSet")]
		private IList<ValueSet> valueSets = new List<ValueSet>();

		[ElementListAttribute(Inline = true, Required = false, Entry = "conceptDomain")]
		private IList<ConceptDomain> conceptDomains = new List<ConceptDomain>();

		public virtual IList<ValueSet> ValueSets
		{
			get
			{
				return this.valueSets;
			}
			set
			{
				IList<ValueSet> valueSets = value;
				this.valueSets = valueSets;
			}
		}

		public virtual IList<ConceptDomain> ConceptDomains
		{
			get
			{
				return this.conceptDomains;
			}
			set
			{
				IList<ConceptDomain> conceptDomains = value;
				this.conceptDomains = conceptDomains;
			}
		}
	}
}
