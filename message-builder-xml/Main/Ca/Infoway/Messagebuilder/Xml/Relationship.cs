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
	public class Relationship : ChoiceSupport, Documentable, HasDifferences, NamedAndTyped
	{
		[XmlAttributeAttribute]
		private string name;

		[XmlAttributeAttribute(Required = false)]
		private string type;

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

		/// <summary>Get a flag indicating whether or not the relationship is an attribute.</summary>
		/// <remarks>Get a flag indicating whether or not the relationship is an attribute.</remarks>
		/// <returns>true if the relationship is an attribute; false otherwise.</returns>
		public virtual bool Attribute
		{
			get
			{
				// BCH/TM: TODO: This might not be the best algorithm...
				if (HasFixedValue())
				{
					return true;
				}
				else
				{
					if (CodedType)
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
							if (StringUtils.IsNotBlank(this.type) && (this.type.Length < 5 || this.type[4] != '_'))
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

		/// <summary>Get a flag indicating whether or not the relationship is a choice association.</summary>
		/// <remarks>Get a flag indicating whether or not the relationship is a choice association.</remarks>
		/// <returns>true if the relationship is a choice association; false otherwise</returns>
		public virtual bool Choice
		{
			get
			{
				return !CollUtils.IsEmpty(this.choices);
			}
		}

		/// <summary>Get a flag indicating whether or not the relationship is a fixed value and is mandatory.</summary>
		/// <remarks>Get a flag indicating whether or not the relationship is a fixed value and is mandatory.</remarks>
		/// <returns>true if the relationship has a fixed value and is mandatory; false otherwise</returns>
		public virtual bool Fixed
		{
			get
			{
				return HasFixedValue() && Mandatory;
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

		/// <summary>Get a flag indicating whether or not the relationship is mandatory.</summary>
		/// <remarks>Get a flag indicating whether or not the relationship is mandatory.</remarks>
		/// <returns>true if the relationship is mandatory; false otherwise.</returns>
		public virtual bool Mandatory
		{
			get
			{
				return Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY.Equals(Conformance);
			}
		}

		/// <summary>Get a flag indicating whether or not the relationship is populated.</summary>
		/// <remarks>Get a flag indicating whether or not the relationship is populated.</remarks>
		/// <returns>true if the relationship is populated; false otherwise.</returns>
		public virtual bool Populated
		{
			get
			{
				return Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.POPULATED.Equals(Conformance);
			}
		}

		/// <summary>Get a flag indicating whether or not the relationship is a coded type.</summary>
		/// <remarks>Get a flag indicating whether or not the relationship is a coded type.</remarks>
		/// <returns>true if the relationship is a coded type; false otherwise.</returns>
		public virtual bool CodedType
		{
			get
			{
				return StringUtils.IsNotBlank(this.domainType);
			}
		}

		/// <summary>Get a flag indicating whether or not the relationship is a template relationship.</summary>
		/// <remarks>
		/// Get a flag indicating whether or not the relationship is a template relationship.
		/// The implementation of this method is based on knowledge that sometimes message
		/// sets have been complete.  In a perfect world, a relationship would be a template
		/// relationship if there is a template parameter name.  In fact, some XSD-generated
		/// message set files are missing the type of the choice.
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
					if (Choice && Association && StringUtils.IsBlank(Type))
					{
						return false;
					}
					else
					{
						return Association && StringUtils.IsBlank(Type);
					}
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
	}
}
