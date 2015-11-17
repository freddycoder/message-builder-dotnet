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
using Ca.Infoway.Messagebuilder;
using Platform.SimpleXml;

namespace Ca.Infoway.Messagebuilder.Xml
{
	/// <summary>A class that models a specialization child of an abstract class.</summary>
	/// <remarks>A class that models a specialization child of an abstract class.</remarks>
	/// <author>Intelliware Development</author>
	[RootAttribute]
	public class SpecializationChild : IComparable<Ca.Infoway.Messagebuilder.Xml.SpecializationChild>
	{
		[XmlAttributeAttribute]
		private string name;

		[XmlAttributeAttribute(Required = false)]
		private string cmetBindingName;

		[XmlAttributeAttribute(Required = false)]
		private string cmetDerivationClassName;

		[XmlAttributeAttribute(Required = false)]
		private Boolean? isDefault;

		/// <summary>Standard constructor.</summary>
		/// <remarks>Standard constructor.</remarks>
		public SpecializationChild()
		{
		}

		/// <summary>Standard constructor.</summary>
		/// <remarks>Standard constructor.</remarks>
		/// <param name="name">the name of the specializing class</param>
		public SpecializationChild(string name)
		{
			this.name = name;
		}

		/// <summary>Standard constructor.</summary>
		/// <remarks>Standard constructor.</remarks>
		/// <param name="name">the name of the specializing class</param>
		/// <param name="cmetBindingName">the name used in MIF files to refer to an external message part</param>
		public SpecializationChild(string name, string cmetBindingName, string cmetDerivationClassName)
		{
			this.name = name;
			this.cmetBindingName = cmetBindingName;
			this.cmetDerivationClassName = cmetDerivationClassName;
		}

		public virtual string Name
		{
			get
			{
				return name;
			}
			set
			{
				string name = value;
				this.name = name;
			}
		}

		public virtual string CmetBindingName
		{
			get
			{
				return cmetBindingName;
			}
			set
			{
				string cmetBindingName = value;
				this.cmetBindingName = cmetBindingName;
			}
		}

		public virtual string CmetDerivationClassName
		{
			get
			{
				return cmetDerivationClassName;
			}
			set
			{
				string cmetDerivationClassName = value;
				this.cmetDerivationClassName = cmetDerivationClassName;
			}
		}

		public virtual bool IsDefault
		{
			get
			{
				return isDefault == null ? false : (bool)isDefault;
			}
			set
			{
				this.isDefault = value;
			}
		}

		public virtual int CompareTo(Ca.Infoway.Messagebuilder.Xml.SpecializationChild o)
		{
			return this.Name.CompareTo(o.Name);
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (obj is Ca.Infoway.Messagebuilder.Xml.SpecializationChild)
			{
				Ca.Infoway.Messagebuilder.Xml.SpecializationChild that = (Ca.Infoway.Messagebuilder.Xml.SpecializationChild)obj;
				return this.Name.Equals(that.Name);
			}
			else
			{
				return false;
			}
		}

		public override int GetHashCode()
		{
			return new HashCodeBuilder().Append(this.name).ToHashCode();
		}
	}
}
