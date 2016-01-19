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
using Ca.Infoway.Messagebuilder.Xml.Cda.Vocabulary;
using Platform.SimpleXml;

namespace Ca.Infoway.Messagebuilder.Xml.Cda.Vocabulary
{
	[RootAttribute(Strict = false)]
	public class ValueSetDefinitionSystem
	{
		[XmlAttributeAttribute(Required = false)]
		private string valueSetOid;

		[XmlAttributeAttribute(Required = false)]
		private string valueSetName;

		[XmlAttributeAttribute(Required = false)]
		private string codeSystemOid;

		[XmlAttributeAttribute(Required = false)]
		private string codeSystemName;

		[ElementListAttribute(Required = false, Inline = true, Entry = "code")]
		private IList<Code> codes = new List<Code>();

		public virtual string ValueSetOid
		{
			get
			{
				return valueSetOid;
			}
			set
			{
				string valueSetOid = value;
				this.valueSetOid = valueSetOid;
			}
		}

		public virtual string ValueSetName
		{
			get
			{
				return valueSetName;
			}
			set
			{
				string valueSetName = value;
				this.valueSetName = valueSetName;
			}
		}

		public virtual string CodeSystemOid
		{
			get
			{
				return codeSystemOid;
			}
			set
			{
				string codeSystemOid = value;
				this.codeSystemOid = codeSystemOid;
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

		public virtual IList<Code> Codes
		{
			get
			{
				return codes;
			}
			set
			{
				IList<Code> codes = value;
				this.codes = codes;
			}
		}
	}
}
