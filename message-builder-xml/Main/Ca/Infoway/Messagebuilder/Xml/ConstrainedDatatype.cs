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
	/// <summary>Specification of cardinality and fixed value constraints on fields inside a standard datatype.</summary>
	/// <remarks>
	/// Specification of cardinality and fixed value constraints on fields inside a standard datatype.
	/// Only used in the context of CDA documents
	/// </remarks>
	/// <author>Intelliware Development</author>
	[RootAttribute]
	public class ConstrainedDatatype
	{
		private static readonly string CONSTRAINT_TYPE_RESTRICTION = "RES";

		private static readonly string CONSTRAINT_TYPE_EXTENSION = "EXT";

		[XmlAttributeAttribute]
		private string name;

		[XmlAttributeAttribute(Required = false)]
		private string baseType;

		[XmlAttributeAttribute]
		private string constraintType = CONSTRAINT_TYPE_RESTRICTION;

		[ElementListAttribute(Required = false, Inline = true)]
		private IList<Relationship> relationships = new List<Relationship>();

		/// <summary>Default constructor.</summary>
		/// <remarks>Default constructor.</remarks>
		public ConstrainedDatatype()
		{
		}

		/// <summary>Standard constructor.</summary>
		/// <remarks>Standard constructor.</remarks>
		/// <param name="name">- the relationship name</param>
		/// <param name="type">- the relationship type</param>
		/// <param name="cardinality">- the cardinality.</param>
		public ConstrainedDatatype(string name, string baseType)
		{
			this.name = name;
			this.baseType = baseType;
		}

		/// <summary>Get the name.</summary>
		/// <remarks>Get the name.</remarks>
		/// <returns>the name</returns>
		/// <summary>Set the name.</summary>
		/// <remarks>Set the name.</remarks>
		/// <value>- the new value.</value>
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

		/// <summary>Get the standard type that is being constrained.</summary>
		/// <remarks>Get the standard type that is being constrained.</remarks>
		/// <returns>the type</returns>
		/// <summary>Set the standard type that is being constrained.</summary>
		/// <remarks>Set the standard type that is being constrained.</remarks>
		/// <value>- the new value</value>
		public virtual string BaseType
		{
			get
			{
				return this.baseType;
			}
			set
			{
				string baseType = value;
				this.baseType = baseType;
			}
		}

		public virtual IList<Relationship> Relationships
		{
			get
			{
				return relationships;
			}
		}

        //For simple xml framework
        public virtual void setConstraintType(string value) {
            this.constraintType = value;
        }

		/// <summary>Set the constraint type to be restriction</summary>
		public virtual void SetRestriction()
		{
			this.constraintType = CONSTRAINT_TYPE_RESTRICTION;
		}

		public virtual bool IsRestriction()
		{
			return CONSTRAINT_TYPE_RESTRICTION.Equals(this.constraintType);
		}

		/// <summary>Set the constraint type to be extension</summary>
		public virtual void SetExtension()
		{
			this.constraintType = CONSTRAINT_TYPE_EXTENSION;
		}

		public virtual bool IsExtension()
		{
			return CONSTRAINT_TYPE_EXTENSION.Equals(this.constraintType);
		}

		public virtual Relationship GetRelationship(string name)
		{
			foreach (Relationship relationship in this.relationships)
			{
				if (StringUtils.Equals(name, relationship.Name))
				{
					return relationship;
				}
			}
			return null;
		}
	}
}
