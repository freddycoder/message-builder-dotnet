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
using System.Collections.Generic;
using Platform.SimpleXml;

namespace Ca.Infoway.Messagebuilder.Xml
{
	/// <summary>Tracks metadata necessary for generating an XSD schema.</summary>
	/// <remarks>
	/// Tracks metadata necessary for generating an XSD schema.
	/// Only used in the context of CDA documents
	/// </remarks>
	/// <author>Intelliware Development</author>
	[RootAttribute]
	public class SchemaMetadata
	{
		[XmlAttributeAttribute]
		private string targetNamespace;

		[XmlAttributeAttribute]
		private string elementFormDefault;

		[ElementListAttribute(Inline = true, Entry = "documentation")]
		private IList<string> documentation = new List<string>();

		[ElementListAttribute(Inline = true, Entry = "includeSchemaLocation")]
		private IList<string> schemaLocations = new List<string>();

		/// <summary>Default constructor.</summary>
		/// <remarks>Default constructor.</remarks>
		public SchemaMetadata()
		{
		}

		public virtual string TargetNamespace
		{
			get
			{
				return targetNamespace;
			}
			set
			{
				string targetNamespace = value;
				this.targetNamespace = targetNamespace;
			}
		}

		public virtual string ElementFormDefault
		{
			get
			{
				return elementFormDefault;
			}
			set
			{
				string elementFormDefault = value;
				this.elementFormDefault = elementFormDefault;
			}
		}

		public virtual IList<string> Documentation
		{
			get
			{
				return documentation;
			}
		}

		public virtual void AddDocumentation(string documentation)
		{
			this.documentation.Add(documentation);
		}

		public virtual IList<string> SchemaLocations
		{
			get
			{
				return schemaLocations;
			}
			set
			{
				IList<string> schemaLocations = value;
				this.schemaLocations = schemaLocations;
			}
		}
	}
}
