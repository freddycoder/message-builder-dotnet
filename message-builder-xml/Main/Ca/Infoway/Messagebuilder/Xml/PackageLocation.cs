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
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Xml;
using Platform.SimpleXml;

namespace Ca.Infoway.Messagebuilder.Xml
{
	/// <summary>The package location.</summary>
	/// <remarks>The package location.  Each package location corresponds with one MIF file.</remarks>
	/// <author>Intelliware Development</author>
	[RootAttribute]
	public class PackageLocation : Categorizable, HasDifferences, Named, Documentable
	{
		[XmlAttributeAttribute]
		private string name;

		[XmlAttributeAttribute(Name = "desc", Required = false)]
		private string descriptiveName;

		[XmlAttributeAttribute(Required = false)]
		private string rootType;

		[ElementAttribute(Required = false)]
		private ImportedPackage derivedFromStaticModel;

		[ElementAttribute(Required = false)]
		private ImportedPackage datatypeModel;

		[ElementAttribute(Required = false)]
		private ImportedPackage vocabularyModel;

		[ElementAttribute(Required = false)]
		private ImportedPackage commonModelElement;

		[ElementListAttribute(Inline = true, Entry = "cmetBinding", Required = false)]
		private IList<CmetBinding> cmetBindings = new List<CmetBinding>();

		[ElementAttribute(Required = false)]
		private Ca.Infoway.Messagebuilder.Xml.Documentation documentation;

		[ElementListAttribute(Inline = true, Required = false)]
		[NamespaceAttribute(Prefix = "regen", Reference = "regen_ns")]
		private IList<Difference> differences = new List<Difference>();

		[ElementMapAttribute(Name = "messagePart", Key = "name", Required = false, Inline = true, Attribute = true)]
		private IDictionary<string, MessagePart> messageParts = new SortedList<string, MessagePart>();

		[XmlAttributeAttribute(Required = false)]
		private string category;

		[XmlAttributeAttribute(Required = false)]
		private string templateOid;

		[XmlAttributeAttribute(Required = false)]
		private string impliedTemplateOid;

		[ElementListAttribute(Inline = true, Required = false, Entry = "containedTemplate")]
		private IList<ContainedTemplate> containedTemplateConstraints = new List<ContainedTemplate>();

		/// <summary>The default constructor.</summary>
		/// <remarks>The default constructor.</remarks>
		public PackageLocation()
		{
		}

		/// <summary>Standard constructor.</summary>
		/// <remarks>Standard constructor.</remarks>
		/// <param name="name">the name of the package location</param>
		public PackageLocation(string name)
		{
			this.name = name;
		}

		/// <summary>Get the name.</summary>
		/// <remarks>Get the name.  e.g. "PRPA_MT101103CA"</remarks>
		/// <returns>the name</returns>
		/// <summary>Set the name.</summary>
		/// <remarks>Set the name.</remarks>
		/// <value>- the new name</value>
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

		/// <summary>The name of the top-level class defined by the MIF file.</summary>
		/// <remarks>The name of the top-level class defined by the MIF file.</remarks>
		/// <returns>the root type name.</returns>
		/// <summary>Set the name of the top-level class defined by the MIF file.</summary>
		/// <remarks>Set the name of the top-level class defined by the MIF file.</remarks>
		/// <value>- the root type name.</value>
		public virtual string RootType
		{
			get
			{
				return this.rootType;
			}
			set
			{
				string rootType = value;
				this.rootType = rootType;
			}
		}

		/// <summary>Get a map of all message parts, keyed by fully-qualified type name.</summary>
		/// <remarks>Get a map of all message parts, keyed by fully-qualified type name.</remarks>
		/// <returns>- the map</returns>
		/// <summary>Set the map of all message parts.</summary>
		/// <remarks>Set the map of all message parts.</remarks>
		/// <value>- the new value</value>
		public virtual IDictionary<string, MessagePart> MessageParts
		{
			get
			{
				return this.messageParts;
			}
			set
			{
				IDictionary<string, MessagePart> messageParts = value;
				this.messageParts = messageParts;
			}
		}

		/// <summary>Get the descriptive name.</summary>
		/// <remarks>Get the descriptive name.</remarks>
		/// <returns>the descriptive name.</returns>
		/// <summary>Set the descriptive name.</summary>
		/// <remarks>Set the descriptive name.</remarks>
		/// <value>- the new value</value>
		public virtual string DescriptiveName
		{
			get
			{
				return this.descriptiveName;
			}
			set
			{
				string descriptiveName = value;
				this.descriptiveName = descriptiveName;
			}
		}

		/// <summary>Set the category, such as "cr" (Client Registry).</summary>
		/// <remarks>Set the category, such as "cr" (Client Registry).</remarks>
		/// <value>- the new value</value>
		/// <summary>Get the category.</summary>
		/// <remarks>Get the category.</remarks>
		/// <returns>the category</returns>
		public virtual string Category
		{
			get
			{
				return this.category;
			}
			set
			{
				string category = value;
				this.category = category;
			}
		}

		public virtual string TemplateOid
		{
			get
			{
				return templateOid;
			}
			set
			{
				string templateOid = value;
				this.templateOid = templateOid;
			}
		}

		public virtual string ImpliedTemplateOid
		{
			get
			{
				return impliedTemplateOid;
			}
			set
			{
				string impliedTemplateOid = value;
				this.impliedTemplateOid = impliedTemplateOid;
			}
		}

		public virtual IList<ContainedTemplate> ContainedTemplateConstraints
		{
			get
			{
				return containedTemplateConstraints;
			}
		}

		/// <summary>Tracks package location differences for regen</summary>
		/// <returns>the differences</returns>
		public virtual IList<Difference> Differences
		{
			get
			{
				return this.differences;
			}
			set
			{
				IList<Difference> differences = value;
				this.differences = differences;
			}
		}

		public virtual void AddDifference(Difference difference)
		{
			this.differences.Add(difference);
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

		public virtual ImportedPackage DerivedFromStaticModel
		{
			get
			{
				return derivedFromStaticModel;
			}
			set
			{
				ImportedPackage derivedFromStaticModel = value;
				this.derivedFromStaticModel = derivedFromStaticModel;
			}
		}

		public virtual ImportedPackage DatatypeModel
		{
			get
			{
				return datatypeModel;
			}
			set
			{
				ImportedPackage datatypeModel = value;
				this.datatypeModel = datatypeModel;
			}
		}

		public virtual ImportedPackage VocabularyModel
		{
			get
			{
				return vocabularyModel;
			}
			set
			{
				ImportedPackage vocabularyModel = value;
				this.vocabularyModel = vocabularyModel;
			}
		}

		public virtual ImportedPackage CommonModelElement
		{
			get
			{
				return commonModelElement;
			}
			set
			{
				ImportedPackage commonModelElement = value;
				this.commonModelElement = commonModelElement;
			}
		}

		public virtual IList<CmetBinding> CmetBindings
		{
			get
			{
				return this.cmetBindings;
			}
		}

		public virtual CmetBinding GetCmetBinding(string name)
		{
			CmetBinding result = null;
			foreach (CmetBinding cmetBinding in this.cmetBindings)
			{
				if (cmetBinding.CmetName.Equals(name))
				{
					result = cmetBinding;
				}
			}
			return result;
		}

		public virtual void AddCmetBinding(CmetBinding cmetbinding)
		{
			this.cmetBindings.Add(cmetbinding);
		}

		public virtual bool Cmet
		{
			get
			{
				return !this.cmetBindings.IsEmpty();
			}
		}
	}
}
