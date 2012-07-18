using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Xml;
using ILOG.J2CsMapping.Collections.Generics;
using Platform.SimpleXml;

namespace Ca.Infoway.Messagebuilder.Xml
{
	/// <summary>Documentation about a particular HL7 construct.</summary>
	/// <remarks>Documentation about a particular HL7 construct.</remarks>
	/// <author>Intelliware Development</author>
	[RootAttribute(Strict = false)]
	public class Documentation
	{
		[ElementAttribute(Required = false)]
		private string title;

		[ElementAttribute(Required = false)]
		private string businessName;

		[ElementListAttribute(Required = false, Inline = true, Entry = "annotation")]
		private IList<Annotation> annotations = new List<Annotation>();

		/// <summary>Standard constructor.</summary>
		/// <remarks>Standard constructor.</remarks>
		public Documentation()
		{
		}

		/// <summary>Standard constructor.</summary>
		/// <remarks>Standard constructor.</remarks>
		/// <param name="annotations">- annotations of documentation.</param>
		public Documentation(IList<Annotation> annotations)
		{
			this.annotations = annotations;
		}

		/// <summary>Standard constructor.</summary>
		/// <remarks>Standard constructor.</remarks>
		/// <param name="paragraphs">- annotations of documentation.</param>
		public Documentation(params Annotation[] annotations)
		{
			if (!ArrayUtils.IsEmpty(annotations))
			{
				this.annotations.AddAll(Arrays.AsList(annotations));
			}
		}

		/// <summary>Get the title.</summary>
		/// <remarks>Get the title.</remarks>
		/// <returns>- the title.</returns>
		/// <summary>Set the title.</summary>
		/// <remarks>Set the title.</remarks>
		/// <value>- the new title</value>
		public virtual string Title
		{
			get
			{
				return this.title;
			}
			set
			{
				string title = value;
				this.title = title;
			}
		}

		/// <summary>Get the business name.</summary>
		/// <remarks>Get the business name.</remarks>
		/// <returns>the business name</returns>
		/// <summary>Set the business name.</summary>
		/// <remarks>Set the business name.</remarks>
		/// <value>- the new business name</value>
		public virtual string BusinessName
		{
			get
			{
				return this.businessName;
			}
			set
			{
				string businessName = value;
				this.businessName = businessName;
			}
		}

		/// <summary>Standard equals implementation.</summary>
		/// <remarks>Standard equals implementation.</remarks>
		/// <param name="obj">- the other object</param>
		/// <returns>true if the objects are equal; false otherwise</returns>
		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			else
			{
				if (GetType() != obj.GetType())
				{
					return false;
				}
				else
				{
					Ca.Infoway.Messagebuilder.Xml.Documentation that = (Ca.Infoway.Messagebuilder.Xml.Documentation)obj;
					return new EqualsBuilder().Append(this.businessName, that.businessName).Append(this.title, that.title).Append(this.Annotations
						, that.Annotations).IsEquals();
				}
			}
		}

		/// <summary>Standard hash code method.</summary>
		/// <remarks>Standard hash code method.</remarks>
		/// <returns>the hash code</returns>
		public override int GetHashCode()
		{
			return new HashCodeBuilder().Append(this.businessName).Append(this.title).Append(this.Annotations).ToHashCode();
		}

		/// <summary>Get all annotations of documentation.</summary>
		/// <remarks>Get all annotations of documentation.</remarks>
		/// <returns>- the annotations of documentation.</returns>
		/// <summary>Set the annotations for one annotation type.</summary>
		/// <remarks>Set the annotations for one annotation type.</remarks>
		/// <value>- the new annotations of documentation.</value>
		public virtual IList<Annotation> Annotations
		{
			get
			{
				return annotations;
			}
			set
			{
				IList<Annotation> annotations = value;
				this.annotations = annotations;
			}
		}
	}
}
