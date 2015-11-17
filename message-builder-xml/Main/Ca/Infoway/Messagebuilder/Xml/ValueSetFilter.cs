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
using System;
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Xml;
using Platform.SimpleXml;

namespace Ca.Infoway.Messagebuilder.Xml
{
	public class ValueSetFilter
	{
		[XmlAttributeAttribute(Required = false)]
		private string codeSystemName;

		[XmlAttributeAttribute(Required = false)]
		private string propertyName;

		[XmlAttributeAttribute(Required = false)]
		private string propertyValue;

		[XmlAttributeAttribute(Required = false)]
		private Boolean? propertyIncluded;

		[XmlAttributeAttribute(Required = false)]
		private string nonComputableContent;

		[ElementListAttribute(Required = false, Inline = true, Entry = "includedCode")]
		private IList<ValueSetFilterCode> includedCodes;

		[ElementListAttribute(Required = false, Inline = true, Entry = "excludedCode")]
		private IList<ValueSetFilterCode> excludedCodes;

		[ElementListAttribute(Required = false, Inline = true, Entry = "otherValueSet")]
		private IList<ValueSetFilterReference> otherValueSets = new List<ValueSetFilterReference>();

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

		public virtual string PropertyName
		{
			get
			{
				return propertyName;
			}
			set
			{
				string propertyName = value;
				this.propertyName = propertyName;
			}
		}

		public virtual string PropertyValue
		{
			get
			{
				return propertyValue;
			}
			set
			{
				string propertyValue = value;
				this.propertyValue = propertyValue;
			}
		}

		public virtual Boolean? PropertyIncluded
		{
			get
			{
				return propertyIncluded;
			}
			set
			{
				Boolean? propertyIncluded = value;
				this.propertyIncluded = propertyIncluded;
			}
		}

		public virtual string NonComputableContent
		{
			get
			{
				return nonComputableContent;
			}
			set
			{
				string nonComputableContent = value;
				this.nonComputableContent = nonComputableContent;
			}
		}

		public virtual IList<ValueSetFilterCode> IncludedCodes
		{
			get
			{
				return includedCodes;
			}
			set
			{
				IList<ValueSetFilterCode> includedCodes = value;
				this.includedCodes = includedCodes;
			}
		}

		public virtual void AddIncludedCode(ValueSetFilterCode code)
		{
			if (this.includedCodes == null)
			{
				this.includedCodes = new List<ValueSetFilterCode>();
			}
			this.includedCodes.Add(code);
		}

		public virtual IList<ValueSetFilterCode> ExcludedCodes
		{
			get
			{
				return excludedCodes;
			}
			set
			{
				IList<ValueSetFilterCode> excludedCodes = value;
				this.excludedCodes = excludedCodes;
			}
		}

		public virtual void AddExcludedCode(ValueSetFilterCode code)
		{
			if (this.excludedCodes == null)
			{
				this.excludedCodes = new List<ValueSetFilterCode>();
			}
			this.excludedCodes.Add(code);
		}

		public virtual IList<ValueSetFilterReference> OtherValueSets
		{
			get
			{
				return otherValueSets;
			}
			set
			{
				IList<ValueSetFilterReference> otherValueSets = value;
				this.otherValueSets = otherValueSets;
			}
		}

		public virtual void AddOtherValueSet(ValueSetFilterReference reference)
		{
			if (this.otherValueSets == null)
			{
				this.otherValueSets = new List<ValueSetFilterReference>();
			}
			this.otherValueSets.Add(reference);
		}
	}
}
