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
using Ca.Infoway.Messagebuilder;

namespace Ca.Infoway.Messagebuilder.Xml
{
	/// <summary>The type name.</summary>
	/// <remarks>
	/// The type name.
	/// A typical name looks like this: REPC_IN002620.ControlActProcess .
	/// The parent of this name would be REPC_IN002620
	/// </remarks>
	/// <author>Intelliware Development</author>
	public class TypeName
	{
		public static readonly string PART_SEPARATOR = ".";

		private readonly string name;

		private readonly Boolean? isInteraction;

		private readonly bool isCdaDocumentRoot;

		/// <summary>Standard constructor.</summary>
		/// <remarks>Standard constructor.</remarks>
		/// <param name="name">- the name of the type</param>
		public TypeName(string name) : this(name, null, false)
		{
		}

		public TypeName(string name, Boolean? isInteraction) : this(name, isInteraction, false)
		{
		}

		public TypeName(string name, Boolean? isInteraction, bool isCdaDocumentRoot)
		{
			// EXPERIMENT
			this.name = name != null ? name.Replace('$', '.') : name;
			this.isInteraction = isInteraction;
			this.isCdaDocumentRoot = isCdaDocumentRoot;
		}

		/// <summary>The number of parts (separated by the period character) in the name.</summary>
		/// <remarks>The number of parts (separated by the period character) in the name.</remarks>
		/// <returns>- the number of parts</returns>
		public virtual int PartCount
		{
			get
			{
				return StringUtils.Split(this.name, PART_SEPARATOR).Length;
			}
		}

		/// <summary>Get a flag indicating whether or not the type name represents a top-most type.</summary>
		/// <remarks>Get a flag indicating whether or not the type name represents a top-most type.</remarks>
		/// <returns>true if the relationship is a top-level type; false otherwise.</returns>
		public virtual bool Root
		{
			get
			{
				return RootName == this;
			}
		}

		/// <summary>Get the name of the top-level type.</summary>
		/// <remarks>
		/// Get the name of the top-level type.  For example the root name of
		/// "PRPA_MT101103CA.ParameterList" is "PRPA_MT101103CA".  The root name
		/// of "PRPA_MT101103CA" is "PRPA_MT101103CA".
		/// </remarks>
		/// <returns>the root name.</returns>
		public virtual Ca.Infoway.Messagebuilder.Xml.TypeName RootName
		{
			get
			{
				if (this.name.Contains(PART_SEPARATOR))
				{
					return new Ca.Infoway.Messagebuilder.Xml.TypeName(StringUtils.SubstringBefore(this.name, PART_SEPARATOR));
				}
				else
				{
					return this;
				}
			}
		}

		/// <summary>Get the name of the parent type.</summary>
		/// <remarks>
		/// Get the name of the parent type.  For example the parent name of
		/// "PRPA_MT101103CA.ParameterList" is "PRPA_MT101103CA".  The parent name
		/// of "PRPA_MT101103CA" is "".
		/// </remarks>
		/// <returns>- the parent name</returns>
		public virtual Ca.Infoway.Messagebuilder.Xml.TypeName Parent
		{
			get
			{
				if (this.name.Contains(PART_SEPARATOR))
				{
					return new Ca.Infoway.Messagebuilder.Xml.TypeName(StringUtils.SubstringBeforeLast(this.name, PART_SEPARATOR));
				}
				else
				{
					return new Ca.Infoway.Messagebuilder.Xml.TypeName(string.Empty);
				}
			}
		}

		/// <summary>Standard equals method.</summary>
		/// <remarks>Standard equals method.</remarks>
		/// <param name="obj">- the other object</param>
		/// <returns>true if this object equals the parameter; false otherwise.</returns>
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
					Ca.Infoway.Messagebuilder.Xml.TypeName that = (Ca.Infoway.Messagebuilder.Xml.TypeName)obj;
					return new EqualsBuilder().Append(this.name, that.name).IsEquals();
				}
			}
		}

		/// <summary>Standard hash code method.</summary>
		/// <remarks>Standard hash code method.</remarks>
		/// <returns>the hash code</returns>
		public override int GetHashCode()
		{
			return new HashCodeBuilder().Append(this.name).ToHashCode();
		}

		/// <summary>Get the name.</summary>
		/// <remarks>Get the name.</remarks>
		/// <returns>the name</returns>
		public virtual string Name
		{
			get
			{
				return this.name;
			}
		}

		/// <summary>Gets the unqualified part name.</summary>
		/// <remarks>
		/// Gets the unqualified part name.  For example the unqualified name of
		/// "PRPA_MT101103CA.ParameterList" is "ParameterList".  The unqualified name
		/// of "PRPA_MT101103CA" is "PRPA_MT101103CA".
		/// </remarks>
		/// <returns>the unqualified name</returns>
		public virtual string UnqualifiedName
		{
			get
			{
				if (PartCount > 1)
				{
					return StringUtils.SubstringAfterLast(this.name, PART_SEPARATOR);
				}
				else
				{
					if (PartCount == 1)
					{
						return this.name;
					}
					else
					{
						return string.Empty;
					}
				}
			}
		}

		/// <summary>Standard toString method.</summary>
		/// <remarks>Standard toString method.</remarks>
		/// <returns>the type name</returns>
		public override string ToString()
		{
			return Name;
		}

		/// <summary>Get a flag indicating whether or not a type name is an interaction.</summary>
		/// <remarks>
		/// Get a flag indicating whether or not a type name is an interaction.
		/// Interactions tend to have '_IN' in the middle of the name.  For example,
		/// "PRPA_IN101103CA" is an interaction name.
		/// </remarks>
		/// <returns>true if the type name is an interaction; false otherwise.</returns>
		[System.ObsoleteAttribute(@"this naming convention is not always followed. Do NOT depend on this method to definitively determine if a type name is an interaction."
			)]
		public virtual bool IsInteraction()
		{
			// TM - hack to allow CDA procssing to mark some names as interactions
			if (this.isInteraction != null && (bool)this.isInteraction)
			{
				//Cast for .NET
				return true;
			}
			return PartCount == 1 && this.name.Length >= 7 && "_IN".Equals(Ca.Infoway.Messagebuilder.StringUtils.Substring(this.name, 
				4, 7));
		}

		/// <returns>true if the type name is a package location; false otherwise.</returns>
		[Obsolete]
		public virtual bool PackageLocation
		{
			get
			{
				return PartCount == 1 && this.name.Length >= 7 && "_MT".Equals(Ca.Infoway.Messagebuilder.StringUtils.Substring(this.name, 
					4, 7));
			}
		}

		/// <summary>Get the name of the top-level type.</summary>
		/// <remarks>
		/// Get the name of the top-level type.  For example the root name of
		/// "PRPA_MT101103CA.ParameterList" is "PRPA_MT101103CA".  The root name
		/// of "PRPA_MT101103CA" is "PRPA_MT101103CA".
		/// </remarks>
		/// <returns>the root name.</returns>
		public static string DetermineRootName(string name)
		{
			Ca.Infoway.Messagebuilder.Xml.TypeName typeName = new Ca.Infoway.Messagebuilder.Xml.TypeName(name);
			return typeName.RootName.Name;
		}

		public virtual bool IsCdaDocumentRoot()
		{
			return this.isCdaDocumentRoot;
		}
	}
}
