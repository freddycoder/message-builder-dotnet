using System;
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Xml;
using Platform.SimpleXml;

namespace Ca.Infoway.Messagebuilder.Xml
{
	/// <summary>A class that models the interaction.</summary>
	/// <remarks>A class that models the interaction.</remarks>
	/// <author>Intelliware Development</author>
	[RootAttribute]
	public class Interaction : Categorizable, HasDifferences, Named, Documentable
	{
		[XmlAttributeAttribute]
		private string name;

		[ElementListAttribute(Inline = true, Required = false)]
		[NamespaceAttribute(Prefix = "regen", Reference = "regen_ns")]
		private IList<Difference> differences = new List<Difference>();

		[ElementAttribute(Required = false)]
		[Obsolete]
		private string businessName;

		[XmlAttributeAttribute]
		private string superTypeName;

		[ElementListAttribute(Inline = true, Required = false)]
		private IList<Argument> arguments = new List<Argument>();

		[ElementAttribute(Required = false)]
		private Ca.Infoway.Messagebuilder.Xml.Documentation documentation;

		[XmlAttributeAttribute(Required = false)]
		private string category;

		/// <summary>Get the type name of the interaction.</summary>
		/// <remarks>
		/// Get the type name of the interaction.  For example, a name might be
		/// PRPA_IN101103CA.
		/// </remarks>
		/// <returns>the name</returns>
		/// <summary>Set the name.</summary>
		/// <remarks>Set the name.</remarks>
		/// <value>- the new value</value>
		public virtual string Name
		{
			get
			{
				// businessName field no longer used; setter/getter delegates to documentation property
				// however, older message sets, when read in, will have this field populated 
				return this.name;
			}
			set
			{
				string name = value;
				this.name = name;
			}
		}

		/// <summary>Get the type name of the parent type (or super type).</summary>
		/// <remarks>Get the type name of the parent type (or super type).</remarks>
		/// <returns>the type name of the parent type</returns>
		/// <summary>Set the type name of the parent type.</summary>
		/// <remarks>Set the type name of the parent type.</remarks>
		/// <value>- the new parent type name.</value>
		public virtual string SuperTypeName
		{
			get
			{
				return this.superTypeName;
			}
			set
			{
				string superTypeName = value;
				this.superTypeName = superTypeName;
			}
		}

		/// <summary>Get the list of template arguments.</summary>
		/// <remarks>Get the list of template arguments.</remarks>
		/// <returns>the template arguments</returns>
		/// <summary>Set the list of template arguments.</summary>
		/// <remarks>Set the list of template arguments.</remarks>
		/// <value>- the template arguments</value>
		public virtual IList<Argument> Arguments
		{
			get
			{
				return this.arguments;
			}
			set
			{
				IList<Argument> arguments = value;
				this.arguments = arguments;
			}
		}

		/// <summary>Get the business name.</summary>
		/// <remarks>Get the business name.  A business name might be "Find Candidates Query".</remarks>
		/// <returns>the business name</returns>
		/// <summary>Set the business name.</summary>
		/// <remarks>Set the business name.</remarks>
		/// <value>- the new business name.</value>
		public virtual string BusinessName
		{
			get
			{
				// first pull out proper value
				string docBusinessName = this.documentation == null ? null : this.documentation.BusinessName;
				// if no proper value, but we have a deprecated field value, return the deprecated field value and set it in the correct field
				if (docBusinessName == null && this.businessName != null)
				{
					docBusinessName = this.businessName;
					BusinessName = this.businessName;
				}
				// side effect: clear out the deprecated field regardless, in case it was populated from an older message set
				this.businessName = null;
				return docBusinessName;
			}
			set
			{
				string businessName = value;
				// side effect: clear out the deprecated field regardless, in case it was populated from an older message set
				this.businessName = null;
				if (this.documentation == null && businessName != null)
				{
					this.documentation = new Ca.Infoway.Messagebuilder.Xml.Documentation();
				}
				if (this.documentation != null)
				{
					this.documentation.BusinessName = businessName;
				}
			}
		}

		/// <summary>Get the documentation.</summary>
		/// <remarks>Get the documentation.</remarks>
		/// <returns>- the documentation</returns>
		/// <summary>Set the documentation.</summary>
		/// <remarks>Set the documentation.</remarks>
		/// <value>- the new documentation</value>
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

		/// <summary>Locate a particular template parameter argument by template parameter name.</summary>
		/// <remarks>Locate a particular template parameter argument by template parameter name.</remarks>
		/// <param name="templateParameterName">- the template parameter name</param>
		/// <returns>- the argument that corresponds to the name.</returns>
		public virtual Argument GetArgumentByTemplateParameterName(string templateParameterName)
		{
			return GetArgumentByTemplateParameterName(templateParameterName, Arguments);
		}

		private Argument GetArgumentByTemplateParameterName(string templateParameterName, IList<Argument> arguments)
		{
			Argument result = null;
			foreach (Argument argument in arguments)
			{
				if (StringUtils.Equals(templateParameterName, argument.TemplateParameterName))
				{
					result = argument;
				}
				else
				{
					result = GetArgumentByTemplateParameterName(templateParameterName, argument.Arguments);
				}
				if (result != null)
				{
					break;
				}
			}
			return result;
		}

		/// <summary>Get the category.</summary>
		/// <remarks>Get the category.</remarks>
		/// <returns>the category</returns>
		/// <summary>Set the category.</summary>
		/// <remarks>Set the category.</remarks>
		/// <value>- the new category</value>
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

		/// <summary>Tracks an interaction difference for regen</summary>
		/// <returns>the difference</returns>
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
	}
}
