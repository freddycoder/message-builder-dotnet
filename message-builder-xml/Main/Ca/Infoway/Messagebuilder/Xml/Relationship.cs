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
using Ca.Infoway.Messagebuilder.Lang;
using Ca.Infoway.Messagebuilder.Xml;
using Platform.SimpleXml;

namespace Ca.Infoway.Messagebuilder.Xml
{
	/// <summary>A message part relationship (either an attribute or an association).</summary>
	/// <remarks>
	/// A message part relationship (either an attribute or an association).
	/// Fundamentally, we think of there being four types of relationships:
	/// 
	/// Attributes
	/// Simple associations
	/// Choice associations
	/// Template associations
	/// 
	/// </remarks>
	/// <author>Intelliware Development</author>
	[RootAttribute]
	public class Relationship : ChoiceSupport, Documentable, HasDifferences, NamedAndTyped, RelationshipComparable, IComparable
		<Ca.Infoway.Messagebuilder.Xml.Relationship>
	{
		private static RelationshipComparator relationshipComparator = new RelationshipComparator();

		[XmlAttributeAttribute]
		private string name;

		[XmlAttributeAttribute(Required = false)]
		private bool attribute;

		[XmlAttributeAttribute(Name = "namespace", Required = false)]
		private string namespaze;

		[XmlAttributeAttribute(Required = false)]
		private string type;

		[XmlAttributeAttribute(Required = false)]
		private string constrainedType;

		[XmlAttributeAttribute(Required = false)]
		private Boolean? structural;

		[XmlAttributeAttribute(Required = false)]
		private string domainType;

		[XmlAttributeAttribute(Required = false)]
		private string domainSource;

		[XmlAttributeAttribute(Required = false)]
		private string conformance;

		[XmlAttributeAttribute(Required = false)]
		private string cardinality;

		[XmlAttributeAttribute(Required = false)]
		private Int32? sortOrder;

		[XmlAttributeAttribute(Required = false)]
		private string fixedValue;

		[XmlAttributeAttribute(Required = false)]
		private string templateParameterName;

		[XmlAttributeAttribute(Required = false)]
		private Int32? length;

		[XmlAttributeAttribute(Required = false)]
		private string codingStrength;

		[XmlAttributeAttribute(Required = false)]
		private string defaultValue;

		[XmlAttributeAttribute(Required = false)]
		private string associationSortKey;

		[XmlAttributeAttribute(Required = false)]
		private string traversableAssociationName;

		[XmlAttributeAttribute(Required = false)]
		private string nontraversableAssociationName;

		[XmlAttributeAttribute(Required = false)]
		private string cmetBindingName;

		[XmlAttributeAttribute(Required = false)]
		private string traversableDerivationClassName;

		[XmlAttributeAttribute(Required = false)]
		private string nontraversableDerivationClassName;

		[XmlAttributeAttribute(Required = false)]
		private string cmetDerivationClassName;

		[XmlAttributeAttribute(Required = false)]
		private string nonFixedVocabularyBinding;

		[XmlAttributeAttribute(Required = false)]
		private Boolean? printDatatype;

		[XmlAttributeAttribute(Required = false)]
		private Boolean? defaultChoice;

		[ElementListAttribute(Inline = true, Required = false)]
		[NamespaceAttribute(Prefix = "regen", Reference = "regen_ns")]
		private IList<Difference> differences = new List<Difference>();

		[ElementAttribute(Required = false)]
		private Ca.Infoway.Messagebuilder.Xml.UpdateMode updateMode;

		[ElementAttribute(Required = false)]
		private Ca.Infoway.Messagebuilder.Xml.Documentation documentation;

		[ElementListAttribute(Entry = "choice", Inline = true, Required = false)]
		private IList<Ca.Infoway.Messagebuilder.Xml.Relationship> choices = new List<Ca.Infoway.Messagebuilder.Xml.Relationship>(
			);

		private string parentType;

		/// <summary>Default constructor.</summary>
		/// <remarks>Default constructor.</remarks>
		public Relationship()
		{
		}

		/// <summary>Standard constructor.</summary>
		/// <remarks>Standard constructor.</remarks>
		/// <param name="name">- the relationship name</param>
		/// <param name="type">- the relationship type</param>
		/// <param name="cardinality">- the cardinality.</param>
		public Relationship(string name, string type, Ca.Infoway.Messagebuilder.Xml.Cardinality cardinality)
		{
			//Reserved word in C#
			// not guaranteed to be populated
			this.name = name;
			this.type = type;
			this.cardinality = cardinality.ToString();
		}

		/// <summary>Get the relationship name.</summary>
		/// <remarks>Get the relationship name.</remarks>
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

		public virtual string Namespaze
		{
			get
			{
				return namespaze;
			}
			set
			{
				string namespaze = value;
				this.namespaze = namespaze;
			}
		}

		public virtual string QualifiedName
		{
			get
			{
				if (this.namespaze == null)
				{
					return this.name;
				}
				else
				{
					return this.namespaze + ":" + this.name;
				}
			}
		}

		/// <summary>Get the relationship type.</summary>
		/// <remarks>
		/// Get the relationship type.
		/// Typical types for an attribute might be "II.OID", "LIST&lt;TS.FULLDATE&gt;"
		/// or "ST".
		/// Typical types for an association might
		/// be "PRPA_MT101103CA.PatientBirthTime".  This property is blank if the relationship
		/// represents a template relationship.
		/// </remarks>
		/// <returns>the type</returns>
		/// <summary>Set the type.</summary>
		/// <remarks>Set the type.</remarks>
		/// <value>- the new value</value>
		public virtual string Type
		{
			get
			{
				return this.type;
			}
			set
			{
				string type = value;
				this.type = type;
			}
		}

		public virtual string ConstrainedType
		{
			get
			{
				return constrainedType;
			}
			set
			{
				string constrainedType = value;
				this.constrainedType = constrainedType;
			}
		}

		/// <summary>Get the structural flag.</summary>
		/// <remarks>Get the structural flag.</remarks>
		/// <returns>- the structural flag</returns>
		/// <summary>Set the structural flag.</summary>
		/// <remarks>Set the structural flag.</remarks>
		/// <value>- the new value</value>
		public virtual bool Structural
		{
			get
			{
				return this.structural == null ? false : this.structural.Value;
			}
			set
			{
				bool structural = value;
				this.structural = structural;
			}
		}

		/// <summary>The domain type.</summary>
		/// <remarks>
		/// The domain type.  If a relationship is an attribute and the type is a
		/// coded type (e.g. "CD"), then the domain type represents the domain information
		/// (e.g. "ProcessingMode").
		/// </remarks>
		/// <returns>the domain type.</returns>
		/// <summary>Set the domain type.</summary>
		/// <remarks>Set the domain type.</remarks>
		/// <value>- the new value</value>
		public virtual string DomainType
		{
			get
			{
				return this.domainType;
			}
			set
			{
				string domainType = value;
				this.domainType = domainType;
			}
		}

		/// <summary>Checks if has a domain types.</summary>
		/// <remarks>Checks if has a domain types.  Only attributes can have domain types.</remarks>
		/// <returns>- whether this relationship has a domain type</returns>
		public virtual bool HasDomainType()
		{
			return StringUtils.IsNotBlank(this.domainType);
		}

		/// <summary>Get the conformance level.</summary>
		/// <remarks>Get the conformance level.</remarks>
		/// <returns>the conformance level.</returns>
		/// <summary>Set the conformance level.</summary>
		/// <remarks>Set the conformance level.</remarks>
		/// <value>the conformance level.</value>
		public virtual Ca.Infoway.Messagebuilder.Xml.ConformanceLevel Conformance
		{
			get
			{
				if (this.conformance != null)
				{
					return EnumPattern.ValueOf<Ca.Infoway.Messagebuilder.Xml.ConformanceLevel>(this.conformance);
				}
				else
				{
					if (HasFixedValue())
					{
						// TM - should this also return MANDATORY if min cardinality > 0?
						return Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY;
					}
					else
					{
						return Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL;
					}
				}
			}
			set
			{
				Ca.Infoway.Messagebuilder.Xml.ConformanceLevel conformance = value;
				this.conformance = conformance == null ? null : conformance.Name;
			}
		}

		/// <summary>Get the cardinality.</summary>
		/// <remarks>Get the cardinality.</remarks>
		/// <returns>the cardinality</returns>
		/// <summary>Set the cardinality.</summary>
		/// <remarks>Set the cardinality.</remarks>
		/// <value>- the new value</value>
		public virtual Ca.Infoway.Messagebuilder.Xml.Cardinality Cardinality
		{
			get
			{
				Ca.Infoway.Messagebuilder.Xml.Cardinality temp = Ca.Infoway.Messagebuilder.Xml.Cardinality.Create(this.cardinality);
				if (temp != null)
				{
					return temp;
				}
				else
				{
					// specifically using direct check of conformance value instead of using isMandatory or isPopulated to avoid logic errors
					if (Conformance == Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY || Conformance == Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
						.POPULATED)
					{
						return Ca.Infoway.Messagebuilder.Xml.Cardinality.Create("1");
					}
					else
					{
						return Ca.Infoway.Messagebuilder.Xml.Cardinality.Create("0-1");
					}
				}
			}
			set
			{
				Ca.Infoway.Messagebuilder.Xml.Cardinality cardinality = value;
				this.cardinality = cardinality == null ? null : cardinality.ToString();
			}
		}

		public virtual string RawCardinality
		{
			get
			{
				return this.cardinality;
			}
		}

		/// <summary>Get the sort order.</summary>
		/// <remarks>
		/// Get the sort order.  The sort order represents the order that the
		/// XML elements appear in.
		/// </remarks>
		/// <returns>- the sort order</returns>
		/// <summary>Set the sort order.</summary>
		/// <remarks>Set the sort order.</remarks>
		/// <value>- the new value</value>
		public virtual int SortOrder
		{
			get
			{
				return this.sortOrder == null ? 0 : this.sortOrder.Value;
			}
			set
			{
				int sortOrder = value;
				this.sortOrder = sortOrder;
			}
		}

		/// <summary>Get the fixed value.</summary>
		/// <remarks>
		/// Get the fixed value.  Only attributes can have fixed values.  Typically,
		/// fixed values are either code values (e.g. classCode="SBJ") or booleans ("true" or
		/// "false").
		/// </remarks>
		/// <returns>- the string representation of the fixed value</returns>
		/// <summary>Set the fixed value.</summary>
		/// <remarks>Set the fixed value.</remarks>
		/// <value>- the new value</value>
		public virtual string FixedValue
		{
			get
			{
				return this.fixedValue;
			}
			set
			{
				string fixedValue = value;
				this.fixedValue = fixedValue;
			}
		}

		/// <summary>Checks if has fixed value.</summary>
		/// <remarks>
		/// Checks if has fixed value.  Only attributes can have fixed values.  Typically,
		/// fixed values are either code values (e.g. classCode="SBJ") or booleans ("true" or
		/// "false").
		/// </remarks>
		/// <returns>- whether this relationship has a fixed value</returns>
		public virtual bool HasFixedValue()
		{
			return StringUtils.IsNotBlank(this.fixedValue);
		}

		/// <summary>Get the vocabulary binding</summary>
		public virtual string VocabularyBinding
		{
			get
			{
				if (this.HasFixedValue())
				{
					return this.FixedValue;
				}
				else
				{
					return this.NonFixedVocabularyBinding;
				}
			}
		}

		/// <summary>Get the documentation.</summary>
		/// <remarks>Get the documentation.</remarks>
		/// <returns>the documentation.</returns>
		/// <summary>Set the documentation.</summary>
		/// <remarks>Set the documentation.</remarks>
		/// <value>- the new value</value>
		public virtual Ca.Infoway.Messagebuilder.Xml.Documentation Documentation
		{
			get
			{
				return this.documentation;
			}
			set
			{
				Ca.Infoway.Messagebuilder.Xml.Documentation documentation = value;
				this.documentation = documentation;
			}
		}

		/// <summary>Set the flag indicating whether the relationship represents an attribute;</summary>
		/// <summary>Get a flag indicating whether or not the relationship is an attribute.</summary>
		/// <remarks>Get a flag indicating whether or not the relationship is an attribute.</remarks>
		/// <returns>true if the relationship is an attribute; false otherwise.</returns>
		public virtual bool Attribute
		{
			get
			{
				// BCH/TM: This might not be the best algorithm...
				if (this.attribute)
				{
					return true;
				}
				else
				{
					// everything below this point should be considered deprecated, but must be maintained for now to support legacy message sets
					if (HasFixedValue())
					{
						return true;
					}
					else
					{
						if (HasDomainType())
						{
							return true;
						}
						else
						{
							if (Structural)
							{
								return true;
							}
							else
							{
								if (StringUtils.IsNotBlank(this.type) && (this.type.Length < 5 || this.type[4] != '_') && this.type.ToUpper().Equals(this
									.type))
								{
									return true;
								}
								else
								{
									return false;
								}
							}
						}
					}
				}
			}
			set
			{
				bool attribute = value;
				this.attribute = attribute;
			}
		}

		/// <summary>Get a flag indicating whether or not the relationship is an association.</summary>
		/// <remarks>Get a flag indicating whether or not the relationship is an association.</remarks>
		/// <returns>true if the relationship is an association; false otherwise.</returns>
		public virtual bool Association
		{
			get
			{
				return !Attribute;
			}
		}

		/// <summary>Get a flag indicating whether or not the relationship is a coded type.</summary>
		/// <remarks>Get a flag indicating whether or not the relationship is a coded type.</remarks>
		/// <returns>true if the relationship is a coded type; false otherwise.</returns>
		public virtual bool CodedType
		{
			get
			{
				// this check was originally based solely on whether the Relationship had a domainType
				return CodedTypeEvaluator.IsCodedType(this.type);
			}
		}

		/// <summary>Get a flag indicating whether or not the relationship is a template relationship.</summary>
		/// <remarks>
		/// Get a flag indicating whether or not the relationship is a template relationship.
		/// The implementation of this method used to contain special handling for some
		/// cases where the message set was incomplete. However, message set generation is
		/// much more reliable these days, and the special handling was causing more problems
		/// than it solved, so we took it out. JR - 20130325
		/// </remarks>
		/// <returns>true if the relationship is a template relationship; false otherwise.</returns>
		public virtual bool TemplateRelationship
		{
			get
			{
				if (StringUtils.IsNotBlank(this.templateParameterName))
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		}

		/// <summary>Get a list of all choices.</summary>
		/// <remarks>Get a list of all choices.</remarks>
		/// <returns>the list of choice relationships</returns>
		public override IList<Ca.Infoway.Messagebuilder.Xml.Relationship> Choices
		{
			get
			{
				return this.choices;
			}
		}

		/// <summary>Get the template parameter name.</summary>
		/// <remarks>
		/// Get the template parameter name.  Only template associations should
		/// have a template parameter name.
		/// </remarks>
		/// <returns>the template parameter name.</returns>
		/// <summary>Set the template parameter name.</summary>
		/// <remarks>Set the template parameter name.</remarks>
		/// <value>- the new value.</value>
		public virtual string TemplateParameterName
		{
			get
			{
				return this.templateParameterName;
			}
			set
			{
				string templateParameterName = value;
				this.templateParameterName = templateParameterName;
			}
		}

		/// <summary>Get the maximum string length.</summary>
		/// <remarks>Get the maximum string length.</remarks>
		/// <returns>the length</returns>
		/// <summary>Set the maximum string length.</summary>
		/// <remarks>Set the maximum string length.</remarks>
		/// <value>- the new value</value>
		public virtual Int32? Length
		{
			get
			{
				return this.length;
			}
			set
			{
				Int32? length = value;
				this.length = length;
			}
		}

		/// <summary>Get the coding strength.</summary>
		/// <remarks>Get the coding strength.</remarks>
		/// <returns>the coding strength</returns>
		/// <summary>Set the codeing strength.</summary>
		/// <remarks>Set the codeing strength.</remarks>
		/// <value>- the new value.</value>
		public virtual Ca.Infoway.Messagebuilder.Xml.CodingStrength CodingStrength
		{
			get
			{
				return EnumPattern.ValueOf<Ca.Infoway.Messagebuilder.Xml.CodingStrength>(this.codingStrength);
			}
			set
			{
				Ca.Infoway.Messagebuilder.Xml.CodingStrength codingStrength = value;
				this.codingStrength = codingStrength == null ? null : codingStrength.Name;
			}
		}

		/// <summary>Checks if has default value.</summary>
		/// <remarks>
		/// Checks if has default value.  Only attributes can have default values.  Typically,
		/// default values are for code values (e.g. classCode="SBJ") or booleans ("true" or
		/// "false").
		/// </remarks>
		/// <returns>- whether this relationship has a default value</returns>
		public virtual bool HasDefaultValue()
		{
			return StringUtils.IsNotBlank(this.defaultValue);
		}

		/// <summary>Get the default value.</summary>
		/// <remarks>Get the default value.  Typically, only boolean fields have default values.</remarks>
		/// <returns>- the default value.</returns>
		/// <summary>Set the default value.</summary>
		/// <remarks>Set the default value.</remarks>
		/// <value>- the new value</value>
		public virtual string DefaultValue
		{
			get
			{
				return this.defaultValue;
			}
			set
			{
				string defaultValue = value;
				this.defaultValue = defaultValue;
			}
		}

		public virtual string AssociationSortKey
		{
			get
			{
				return associationSortKey;
			}
			set
			{
				string associationSortKey = value;
				this.associationSortKey = associationSortKey;
			}
		}

		/// <summary>Standard toString method.</summary>
		/// <remarks>Standard toString method.</remarks>
		/// <returns>a debug string.</returns>
		public override string ToString()
		{
			return (Attribute ? "Attribute: " : "Association: ") + Name;
		}

		/// <summary>Records the differences between relationships of different release versions during regen.</summary>
		/// <remarks>Records the differences between relationships of different release versions during regen.</remarks>
		/// <returns>list of differences</returns>
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

		/// <summary>Get the vocabulary source.</summary>
		/// <remarks>Get the vocabulary source.</remarks>
		/// <returns>the vocabulary source</returns>
		/// <summary>Set the vocabulary source.</summary>
		/// <remarks>Set the vocabulary source.</remarks>
		/// <value>source - the new value.</value>
		public virtual Ca.Infoway.Messagebuilder.Xml.DomainSource DomainSource
		{
			get
			{
				return EnumPattern.ValueOf<Ca.Infoway.Messagebuilder.Xml.DomainSource>(this.domainSource);
			}
			set
			{
				Ca.Infoway.Messagebuilder.Xml.DomainSource domainSource = value;
				this.domainSource = domainSource == null ? null : domainSource.Name;
			}
		}

		/// <summary>Gets the update mode information that may be used for this element.</summary>
		/// <remarks>Gets the update mode information that may be used for this element.</remarks>
		/// <returns>updateMode;</returns>
		/// <summary>Gets the update mode information that may be used for this element.</summary>
		/// <remarks>Gets the update mode information that may be used for this element.</remarks>
		/// <value></value>
		public virtual Ca.Infoway.Messagebuilder.Xml.UpdateMode UpdateMode
		{
			get
			{
				return updateMode;
			}
			set
			{
				Ca.Infoway.Messagebuilder.Xml.UpdateMode updateMode = value;
				this.updateMode = updateMode;
			}
		}

		/// <summary>The type containing this relationship</summary>
		/// <returns>parent type</returns>
		/// <summary>The type containing this relationship</summary>
		/// <value></value>
		public virtual string ParentType
		{
			get
			{
				return parentType;
			}
			set
			{
				string parentType = value;
				this.parentType = parentType;
			}
		}

		public virtual string TraversableAssociationName
		{
			get
			{
				return traversableAssociationName;
			}
			set
			{
				string traversableAssociationName = value;
				this.traversableAssociationName = traversableAssociationName;
			}
		}

		public virtual string NontraversableAssociationName
		{
			get
			{
				return nontraversableAssociationName;
			}
			set
			{
				string nontraversableAssociationName = value;
				this.nontraversableAssociationName = nontraversableAssociationName;
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

		public virtual string TraversableDerivationClassName
		{
			get
			{
				return traversableDerivationClassName;
			}
			set
			{
				string traversableDerivationClassName = value;
				this.traversableDerivationClassName = traversableDerivationClassName;
			}
		}

		public virtual string NontraversableDerivationClassName
		{
			get
			{
				return nontraversableDerivationClassName;
			}
			set
			{
				string nontraversableDerivationClassName = value;
				this.nontraversableDerivationClassName = nontraversableDerivationClassName;
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

		public virtual string NonFixedVocabularyBinding
		{
			get
			{
				return nonFixedVocabularyBinding;
			}
			set
			{
				string nonFixedVocabularyBinding = value;
				this.nonFixedVocabularyBinding = nonFixedVocabularyBinding;
			}
		}

		public virtual bool PrintDatatype
		{
			get
			{
				return this.printDatatype == null ? false : this.printDatatype.Value;
			}
			set
			{
				bool printDatatype = value;
				this.printDatatype = printDatatype;
			}
		}

		public virtual bool DefaultChoice
		{
			get
			{
				return defaultChoice == null ? false : (bool)defaultChoice;
			}
			set
			{
				bool defaultChoice = value;
				//Cast for .NET
				this.defaultChoice = defaultChoice;
			}
		}

		public virtual int CompareTo(Ca.Infoway.Messagebuilder.Xml.Relationship rel)
		{
			return relationshipComparator.Compare(this, rel);
		}
	}
}
