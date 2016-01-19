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
using Ca.Infoway.Messagebuilder.Xml;
using Platform.SimpleXml;

namespace Ca.Infoway.Messagebuilder.Xml
{
	/// <summary>The CMET binding metadata associated with a MIF file.</summary>
	/// <remarks>The CMET binding metadata associated with a MIF file. Derived from a coremif file with root=DEFN and artifact=IFC.
	/// 	</remarks>
	/// <author>Intelliware Development</author>
	[RootAttribute]
	public class CmetBinding : Documentable
	{
		[XmlAttributeAttribute(Required = false)]
		private string cmetName;

		[XmlAttributeAttribute(Required = false)]
		private string attributionLevel;

		[XmlAttributeAttribute(Required = false)]
		private string code;

		[XmlAttributeAttribute(Required = false)]
		private string codeSystemOid;

		[ElementAttribute(Required = false)]
		private Ca.Infoway.Messagebuilder.Xml.Documentation documentation;

		/// <summary>The default constructor.</summary>
		/// <remarks>The default constructor.</remarks>
		public CmetBinding()
		{
		}

		public virtual string CmetName
		{
			get
			{
				return cmetName;
			}
			set
			{
				string cmetName = value;
				this.cmetName = cmetName;
			}
		}

		public virtual string AttributionLevel
		{
			get
			{
				return attributionLevel;
			}
			set
			{
				string attributionLevel = value;
				this.attributionLevel = attributionLevel;
			}
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

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (!typeof(Ca.Infoway.Messagebuilder.Xml.CmetBinding).IsAssignableFrom(obj.GetType()))
			{
				return false;
			}
			Ca.Infoway.Messagebuilder.Xml.CmetBinding that = (Ca.Infoway.Messagebuilder.Xml.CmetBinding)obj;
			return new EqualsBuilder().Append(this.cmetName, that.cmetName).Append(this.attributionLevel, that.attributionLevel).Append
				(this.code, that.code).Append(this.codeSystemOid, that.codeSystemOid).Append(this.documentation, that.documentation).IsEquals
				();
		}

		public override int GetHashCode()
		{
			return new HashCodeBuilder().Append(this.cmetName).Append(this.attributionLevel).Append(this.code).Append(this.codeSystemOid
				).Append(this.documentation).ToHashCode();
		}
	}
}
