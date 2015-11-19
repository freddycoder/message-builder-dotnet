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
using Platform.SimpleXml;

namespace Ca.Infoway.Messagebuilder.Xml
{
	public class ContextBinding
	{
		[XmlAttributeAttribute]
		private string conceptDomain;

		[XmlAttributeAttribute]
		private string realm;

		[XmlAttributeAttribute]
		private string codingStrength;

		public ContextBinding()
		{
		}

		public ContextBinding(string conceptDomain, string realm, Ca.Infoway.Messagebuilder.Xml.CodingStrength codingStrength)
		{
			this.conceptDomain = conceptDomain;
			this.realm = realm;
			SetCodingStrength(codingStrength);
		}

		public ContextBinding(string conceptDomain, string realm, string codingStrength)
		{
			this.conceptDomain = conceptDomain;
			this.realm = realm;
			this.codingStrength = codingStrength;
		}

		public virtual string ConceptDomain
		{
			get
			{
				return this.conceptDomain;
			}
		}

		public virtual string Realm
		{
			get
			{
				return this.realm;
			}
			set
			{
				string realm = value;
				this.realm = realm;
			}
		}

		public virtual Ca.Infoway.Messagebuilder.Xml.CodingStrength CodingStrength
		{
			get
			{
				return Ca.Infoway.Messagebuilder.Xml.CodingStrength.ValueOf<Ca.Infoway.Messagebuilder.Xml.CodingStrength>(this.codingStrength
					);
			}
		}

		private void SetCodingStrength(Ca.Infoway.Messagebuilder.Xml.CodingStrength codingStrength)
		{
			this.codingStrength = codingStrength == null ? null : codingStrength.Name;
		}
	}
}
