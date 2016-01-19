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


using System;
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Xml;
using Platform.SimpleXml;

namespace Ca.Infoway.Messagebuilder.Xml
{
	/// <summary>A representation of an entire message set.</summary>
	/// <remarks>A representation of an entire message set.</remarks>
	/// <author>Intelliware Development</author>
	[RootAttribute]
	public class MessageSet : MessagePartResolver
	{
		[XmlAttributeAttribute(Required = false)]
		private string version;

		[XmlAttributeAttribute(Required = false)]
		private bool cda;

		[XmlAttributeAttribute(Required = false)]
		private bool generatedAsR2;

		[XmlAttributeAttribute(Required = false)]
		private string descriptiveName;

		[XmlAttributeAttribute(Required = false)]
		private string realmCode;

		[XmlAttributeAttribute(Required = false)]
		private string component;

		[XmlAttributeAttribute(Required = false)]
		private string schemaVersion = "2.0";

		[XmlAttributeAttribute(Required = false)]
		private string generatedBy;

		[ElementAttribute(Required = false)]
		private Ca.Infoway.Messagebuilder.Xml.Vocabulary vocabulary;

		[ElementAttribute(Required = false)]
		private Ca.Infoway.Messagebuilder.Xml.SchemaMetadata schemaMetadata;

		[ElementListAttribute(Name = "remixHistory", Required = false, Inline = true, Entry = "remixHistoryEntry")]
		private IList<MessageSetHistory> remixHistory = new List<MessageSetHistory>();

		[ElementMapAttribute(Name = "packageLocation", Key = "name", Required = false, Inline = true, Attribute = true, Entry = "packageEntry"
			)]
		private IDictionary<string, PackageLocation> packageLocations = new SortedList<string, PackageLocation>();

		[ElementMapAttribute(Name = "interaction", Key = "name", Required = false, Inline = true, Attribute = true)]
		private IDictionary<string, Interaction> interactions = new SortedList<string, Interaction>();

		[ElementMapAttribute(Name = "constrainedDatatype", Key = "name", Required = false, Inline = true, Attribute = true, Entry
			 = "constrainedDatatypeEntry")]
		private IDictionary<string, ConstrainedDatatype> constrainedDatatypes = new SortedList<string, ConstrainedDatatype>();

		[ElementListAttribute(Required = false, Inline = true, Entry = "schematronContext")]
		private IList<SchematronContext> schematronContexts = new List<SchematronContext>();

		/// <summary>Get the version code that this message set represents.</summary>
		/// <remarks>Get the version code that this message set represents.</remarks>
		/// <returns>- the version code.</returns>
		/// <summary>Set the version code.</summary>
		/// <remarks>Set the version code.</remarks>
		/// <value>- the new version code.</value>
		public virtual string Version
		{
			get
			{
				return this.version;
			}
			set
			{
				string version = value;
				this.version = version;
			}
		}

		public virtual bool Cda
		{
			get
			{
				return cda;
			}
			set
			{
				bool cda = value;
				this.cda = cda;
			}
		}

		/// <summary>Denotes if this message set was generated for R2 data types</summary>
		/// <returns>whether this message set was generated for R2 data types</returns>
		/// <summary>Sets whether this message set was generated for R2 data types</summary>
		/// <value>- whether this message set was generated for R2 data types</value>
		public virtual bool GeneratedAsR2
		{
			get
			{
				return generatedAsR2;
			}
			set
			{
				bool generatedAsR2 = value;
				this.generatedAsR2 = generatedAsR2;
			}
		}

		/// <summary>
		/// Get a map of all the interactions defined in the message set, keyed by
		/// interaction id.
		/// </summary>
		/// <remarks>
		/// Get a map of all the interactions defined in the message set, keyed by
		/// interaction id.
		/// </remarks>
		/// <returns>- the map of all interactions.</returns>
		/// <summary>Set the interactions.</summary>
		/// <remarks>Set the interactions.</remarks>
		/// <value>- the new value</value>
		public virtual IDictionary<string, Interaction> Interactions
		{
			get
			{
				return this.interactions;
			}
			set
			{
				IDictionary<string, Interaction> interactions = value;
				this.interactions = interactions;
			}
		}

		public virtual void AddInteraction(Interaction interaction)
		{
			if (interaction != null && interaction.Name != null)
			{
				this.interactions[interaction.Name] = interaction;
			}
		}

		/// <summary>Get a map of all package locations, keyed by package location id.</summary>
		/// <remarks>Get a map of all package locations, keyed by package location id.</remarks>
		/// <returns>- the map</returns>
		/// <summary>Set the package locations.</summary>
		/// <remarks>Set the package locations.</remarks>
		/// <value>- the new value.</value>
		public virtual IDictionary<string, PackageLocation> PackageLocations
		{
			get
			{
				return this.packageLocations;
			}
			set
			{
				IDictionary<string, PackageLocation> packageLocations = value;
				this.packageLocations = packageLocations;
			}
		}

		/// <summary>Get a single PackageLocation by name</summary>
		/// <param name="name">the name of the package location</param>
		/// <returns>the package location, or null if no such location is known</returns>
		public virtual PackageLocation GetPackageLocation(string name)
		{
			return this.packageLocations.SafeGet(name);
		}

		/// <summary>Add a new package location to the MessageSet</summary>
		/// <param name="packageLocation">the package location</param>
		public virtual void AddPackageLocation(PackageLocation packageLocation)
		{
			this.packageLocations[packageLocation.Name] = packageLocation;
		}

		/// <summary>Get a part by part type name.</summary>
		/// <remarks>Get a part by part type name.</remarks>
		/// <param name="type">- the message part type name</param>
		/// <returns>- the message part</returns>
		public virtual MessagePart GetMessagePart(string type)
		{
			MessagePart messagePart = null;
			if (type != null)
			{
				string packageLocationName = type.Contains(".") ? StringUtils.SubstringBefore(type, ".") : type;
				PackageLocation location = PackageLocations.SafeGet(packageLocationName);
				if (location == null)
				{
					messagePart = null;
				}
				else
				{
					if (type.Contains("."))
					{
						messagePart = location.MessageParts.SafeGet(type);
					}
					else
					{
						if (StringUtils.IsNotBlank(location.RootType))
						{
							messagePart = location.MessageParts.SafeGet(location.RootType);
						}
					}
				}
			}
			return messagePart;
		}

		/// <summary>Get a template parameter part by name, relative to a referring part.</summary>
		/// <remarks>Get a template parameter part by name, relative to a referring part. It is assumed that the parameter part will be in the same package location
		/// 	</remarks>
		/// <param name="basePart">the message part referring to the template parameter</param>
		/// <param name="templateParameterName">the unqualified name of the template parameter</param>
		/// <returns>the message part defining the template parameter</returns>
		public virtual MessagePart ResolveTemplateParameter(MessagePart basePart, string templateParameterName)
		{
			MessagePart messagePart = null;
			if (basePart != null)
			{
				string packageLocationName = StringUtils.SubstringBefore(basePart.Name, ".");
				PackageLocation location = PackageLocations.SafeGet(packageLocationName);
				if (location != null && StringUtils.IsNotBlank(templateParameterName))
				{
					messagePart = location.MessageParts.SafeGet(packageLocationName + "." + templateParameterName);
				}
			}
			return messagePart;
		}

		/// <summary>Add a message part.</summary>
		/// <remarks>Add a message part.</remarks>
		/// <param name="part">- the message part to add</param>
		public virtual void AddMessagePart(MessagePart part)
		{
			TypeName name = new TypeName(part.Name);
			string packageName = name.RootName.Name;
			PackageLocation location = this.packageLocations.SafeGet(packageName);
			if (location == null)
			{
				throw new ArgumentException("No package location exists: " + packageName);
			}
			else
			{
				location.MessageParts[part.Name] = part;
			}
		}

		/// <summary>Get a collection of all message parts defined by the message set.</summary>
		/// <remarks>Get a collection of all message parts defined by the message set.</remarks>
		/// <returns>the message parts</returns>
		public virtual ICollection<MessagePart> AllMessageParts
		{
			get
			{
				IList<MessagePart> result = new List<MessagePart>();
				foreach (PackageLocation packageLocation in this.packageLocations.Values)
				{
					result.AddAll(packageLocation.MessageParts.Values);
				}
				return result;
			}
		}

		/// <summary>Get a package location root type.</summary>
		/// <remarks>Get a package location root type.</remarks>
		/// <param name="packageLocation">- the package location key</param>
		/// <returns>the package location</returns>
		public virtual string GetPackageLocationRootType(string packageLocation)
		{
			if (this.packageLocations.ContainsKey(packageLocation))
			{
				return this.packageLocations.SafeGet(packageLocation).RootType;
			}
			else
			{
				return null;
			}
		}

		/// <summary>Add a constrained datatype.</summary>
		/// <remarks>Add a constrained datatype.</remarks>
		/// <param name="type">- the constrained type to add</param>
		public virtual void AddConstrainedDatatype(ConstrainedDatatype type)
		{
			this.constrainedDatatypes[type.Name] = type;
		}

		/// <summary>Check whether the message set contains a constrained datatype with the specified name</summary>
		/// <param name="typeName">the name to check</param>
		/// <returns>true is a constrained datatype with that name is defined; false otherwise</returns>
		public virtual bool HasConstrainedDatatype(string typeName)
		{
			return this.constrainedDatatypes.ContainsKey(typeName);
		}

		/// <summary>Get the list of all constrained datatypes</summary>
		/// <returns>the list of all constrained datatypes</returns>
		public virtual IList<ConstrainedDatatype> GetAllConstrainedDatatypes()
		{
			IList<ConstrainedDatatype> result = new List<ConstrainedDatatype>();
			result.AddAll(this.constrainedDatatypes.Values);
			return result;
		}

		/// <summary>Get a constrained datatype by name</summary>
		/// <param name="typeName">the name</param>
		/// <returns>the constrained datatype</returns>
		public virtual ConstrainedDatatype GetConstrainedDatatype(string typeName)
		{
			return this.constrainedDatatypes.SafeGet(typeName);
		}

		public virtual IDictionary<string, ConstrainedDatatype> ConstrainedDatatypes
		{
			get
			{
				//For XML Serialization in .NET
				return constrainedDatatypes;
			}
			set
			{
				IDictionary<string, ConstrainedDatatype> constrainedDatatypes = value;
				this.constrainedDatatypes = constrainedDatatypes;
			}
		}

		/// <summary>Get the component.</summary>
		/// <remarks>Get the component.</remarks>
		/// <returns>the component</returns>
		/// <summary>Set the component.</summary>
		/// <remarks>Set the component.</remarks>
		/// <value>- the new value</value>
		public virtual string Component
		{
			get
			{
				return this.component;
			}
			set
			{
				string component = value;
				this.component = component;
			}
		}

		/// <summary>Get the remixHistory.</summary>
		/// <remarks>Get the remixHistory.</remarks>
		/// <returns>the remixHistory</returns>
		/// <summary>Set the remixHistory.</summary>
		/// <remarks>Set the remixHistory.</remarks>
		/// <value>- the new value</value>
		public virtual IList<MessageSetHistory> RemixHistory
		{
			get
			{
				return remixHistory;
			}
			set
			{
				IList<MessageSetHistory> remixHistory = value;
				this.remixHistory = remixHistory;
			}
		}

		public virtual Ca.Infoway.Messagebuilder.Xml.Vocabulary Vocabulary
		{
			get
			{
				if (this.vocabulary == null)
				{
					this.vocabulary = new Ca.Infoway.Messagebuilder.Xml.Vocabulary();
				}
				return this.vocabulary;
			}
			set
			{
				Ca.Infoway.Messagebuilder.Xml.Vocabulary vocabulary = value;
				this.vocabulary = vocabulary;
			}
		}

		/// <summary>
		/// Get the schema metadata
		/// Only used in the context of CDA documents
		/// </summary>
		/// <returns>the schema metadata</returns>
		public virtual string SchemaVersion
		{
			get
			{
				return schemaVersion;
			}
			set
			{
				string schemaVersion = value;
				this.schemaVersion = schemaVersion;
			}
		}

		public virtual bool VocabularyDataPresent
		{
			get
			{
				return this.vocabulary != null && !(this.vocabulary.ConceptDomains.IsEmpty() && this.vocabulary.ValueSets.IsEmpty());
			}
		}

		public virtual Ca.Infoway.Messagebuilder.Xml.SchemaMetadata SchemaMetadata
		{
			get
			{
				return schemaMetadata;
			}
			set
			{
				Ca.Infoway.Messagebuilder.Xml.SchemaMetadata schemaMetadata = value;
				this.schemaMetadata = schemaMetadata;
			}
		}

		public virtual string GeneratedBy
		{
			get
			{
				return generatedBy;
			}
			set
			{
				string generatedBy = value;
				this.generatedBy = generatedBy;
			}
		}

		public virtual string DescriptiveName
		{
			get
			{
				return descriptiveName;
			}
			set
			{
				string descriptiveName = value;
				this.descriptiveName = descriptiveName;
			}
		}

		public virtual string RealmCode
		{
			get
			{
				return realmCode;
			}
			set
			{
				string realmCode = value;
				this.realmCode = realmCode;
			}
		}

		public virtual IList<SchematronContext> SchematronContexts
		{
			get
			{
				return schematronContexts;
			}
		}

		public virtual void AddSchematronContext(SchematronContext context)
		{
			this.schematronContexts.Add(context);
		}
	}
}
