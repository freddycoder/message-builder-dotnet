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
	/// <summary>Descriptors of external resources that are imported into a MIF file</summary>
	/// <author>Intelliware Development</author>
	[RootAttribute]
	public class ImportedPackage
	{
		[XmlAttributeAttribute(Required = false)]
		private string root;

		[XmlAttributeAttribute(Required = false)]
		private string artifact;

		[XmlAttributeAttribute(Required = false)]
		private string version;

		[XmlAttributeAttribute(Required = false)]
		private string realm;

		/// <summary>The default constructor.</summary>
		/// <remarks>The default constructor.</remarks>
		public ImportedPackage()
		{
		}

		/// <summary>Get the root - e.g., "DEFN"</summary>
		/// <returns>the root</returns>
		/// <summary>Set the root</summary>
		/// <value>- the new root</value>
		public virtual string Root
		{
			get
			{
				return root;
			}
			set
			{
				string root = value;
				this.root = root;
			}
		}

		/// <summary>Get the artifact - e.g., "VO"</summary>
		/// <returns>the artifact</returns>
		/// <summary>Set the artifact</summary>
		/// <value>- the new artifact</value>
		public virtual string Artifact
		{
			get
			{
				return artifact;
			}
			set
			{
				string artifact = value;
				this.artifact = artifact;
			}
		}

		/// <summary>Get the version = e.g., "R04.04.xx"</summary>
		/// <returns>the version</returns>
		/// <summary>Set the version</summary>
		/// <value>- the new version</value>
		public virtual string Version
		{
			get
			{
				return version;
			}
			set
			{
				string version = value;
				this.version = version;
			}
		}

		/// <summary>Get the realm namespace - e.g., "CA"</summary>
		/// <returns>the realm namespace</returns>
		/// <summary>Set the realm namespace</summary>
		/// <value>- the new realm namespace</value>
		public virtual string Realm
		{
			get
			{
				return realm;
			}
			set
			{
				string realm = value;
				this.realm = realm;
			}
		}

		public virtual string ToTextRepresentation()
		{
			return this.root + "=" + this.realm + "=" + this.artifact + "=" + this.version;
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (!typeof(Ca.Infoway.Messagebuilder.Xml.ImportedPackage).IsAssignableFrom(obj.GetType()))
			{
				return false;
			}
			Ca.Infoway.Messagebuilder.Xml.ImportedPackage that = (Ca.Infoway.Messagebuilder.Xml.ImportedPackage)obj;
			return new EqualsBuilder().Append(this.root, that.root).Append(this.realm, that.realm).Append(this.artifact, that.artifact
				).Append(this.version, that.version).IsEquals();
		}

		public override int GetHashCode()
		{
			return new HashCodeBuilder().Append(this.root).Append(this.realm).Append(this.artifact).Append(this.version).ToHashCode();
		}
	}
}
