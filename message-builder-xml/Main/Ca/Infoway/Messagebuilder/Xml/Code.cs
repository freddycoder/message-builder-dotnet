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


using Ca.Infoway.Messagebuilder;
using Platform.SimpleXml;

namespace Ca.Infoway.Messagebuilder.Xml
{
	public class Code
	{
		[XmlAttributeAttribute]
		private string codeSystem;

		[XmlAttributeAttribute(Name = "code")]
		private string codeValue;

		[XmlAttributeAttribute(Required = false)]
		private string status;

		[XmlAttributeAttribute(Required = false)]
		private string printName;

		public Code()
		{
		}

		public Code(string codeSystem, string code) : this(codeSystem, code, null, null)
		{
		}

		public Code(string codeSystem, string code, string printName, string status)
		{
			this.codeSystem = codeSystem;
			this.codeValue = code;
			this.printName = printName;
			this.status = status;
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

		public virtual string CodeValue
		{
			get
			{
				return codeValue;
			}
			set
			{
				string code = value;
				this.codeValue = code;
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

		public virtual string PrintName
		{
			get
			{
				return printName;
			}
			set
			{
				string printName = value;
				this.printName = printName;
			}
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (!typeof(Ca.Infoway.Messagebuilder.Xml.Code).IsAssignableFrom(obj.GetType()))
			{
				return false;
			}
			Ca.Infoway.Messagebuilder.Xml.Code that = (Ca.Infoway.Messagebuilder.Xml.Code)obj;
			return new EqualsBuilder().Append(this.codeSystem, that.codeSystem).Append(this.codeValue, that.codeValue).IsEquals();
		}

		public override int GetHashCode()
		{
			return new HashCodeBuilder().Append(this.codeSystem).Append(this.codeValue).ToHashCode();
		}
	}
}
