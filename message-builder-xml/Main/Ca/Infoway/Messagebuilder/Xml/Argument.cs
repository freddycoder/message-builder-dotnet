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
 * Last modified: $LastChangedDate: 2014-05-01 12:01:41 -0400 (Thu, 01 May 2014) $
 * Revision:      $LastChangedRevision: 8549 $
 */
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Xml;
using Platform.SimpleXml;

namespace Ca.Infoway.Messagebuilder.Xml
{
	/// <summary>
	/// The specific type argument for a template parameter.
	/// When an interaction is defined, it is composed of various specific
	/// parts (e.g.
	/// </summary>
	/// <remarks>
	/// The specific type argument for a template parameter.
	/// When an interaction is defined, it is composed of various specific
	/// parts (e.g. the base message part) with template parameters specified by
	/// a particular template argument.  This class models the information that
	/// is specified in the template argument.
	/// For example, the parameters for Find Candidates look like this:
	/// 
	/// &lt;mif:argumentMessage root="DEFN" section="IM" subSection="MC" domain="CI" artifact="MT"
	/// realmNamespace="CA"
	/// id="002100"&gt;
	/// &lt;mif:parameterModel parameterName="ControlActEvent" root="DEFN" section="IM"
	/// subSection="MF"
	/// domain="MI"
	/// artifact="MT"
	/// realmNamespace="CA"
	/// id="700751"
	/// traversalName="controlActEvent"&gt;
	/// &lt;mif:parameterModel parameterName="ParameterList" root="DEFN" section="AM" subSection="PR"
	/// domain="PA"
	/// artifact="MT"
	/// realmNamespace="CA"
	/// id="101103"
	/// traversalName="parameterList"/&gt;
	/// 
	/// Each parameterModel represents one argument.
	/// </remarks>
	/// <author>Intelliware Development</author>
	[RootAttribute]
	public class Argument : ChoiceSupport, HasDifferences, Named
	{
		[XmlAttributeAttribute]
		private string name;

		[ElementListAttribute(Inline = true, Required = false)]
		[NamespaceAttribute(Prefix = "regen", Reference = "regen_ns")]
		private IList<Difference> differences = new List<Difference>();

		[ElementListAttribute(Inline = true, Required = false, Name = "argument")]
		private IList<Argument> arguments = new List<Argument>();

		[XmlAttributeAttribute(Required = false)]
		private string templateParameterName;

		[XmlAttributeAttribute(Required = false)]
		private string traversalName;

		[ElementListAttribute(Entry = "choice", Inline = true, Required = false)]
		private IList<Relationship> choices = new List<Relationship>();

		/// <summary>The name of the type that the argument defines.</summary>
		/// <remarks>
		/// The name of the type that the argument defines.  For example, a name
		/// might return "MCCI_MT700751CA.ControlActEvent".
		/// </remarks>
		/// <returns>the type name of the argument.</returns>
		/// <summary>Set the name.</summary>
		/// <remarks>Set the name.</remarks>
		/// <value>- the new name.</value>
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

		/// <summary>Sub-arguments.</summary>
		/// <remarks>
		/// Sub-arguments.
		/// Arguments can, themselves, have arguments.  Usually used in the case of a
		/// control act type, the argument of which is the payload.
		/// </remarks>
		/// <returns>the sub-arguments</returns>
		/// <summary>Set the sub-arguments.</summary>
		/// <remarks>Set the sub-arguments.</remarks>
		/// <value>- sets the sub-arguments.</value>
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

		/// <summary>The template parameter name.</summary>
		/// <remarks>
		/// The template parameter name.  Each message part with template parameters
		/// will name the parameter (e.g. "RegisteredRole" or "Act").  This maps to the
		/// templateParameterName attribute of the parameterModel element
		/// </remarks>
		/// <returns>the template parameter name.</returns>
		/// <summary>Sets the template parameter name.</summary>
		/// <remarks>Sets the template parameter name.</remarks>
		/// <value>- the new templateParameterName</value>
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

		/// <summary>Gets the traversal name.</summary>
		/// <remarks>
		/// Gets the traversal name.  The traversal name is used to describe the
		/// element name when the message is rendered to XML.
		/// </remarks>
		/// <returns>- the traversal name.</returns>
		/// <summary>Sets the traversal name.</summary>
		/// <remarks>Sets the traversal name.</remarks>
		/// <value>- the new traversal name.</value>
		public virtual string TraversalName
		{
			get
			{
				return this.traversalName;
			}
			set
			{
				string traversalName = value;
				this.traversalName = traversalName;
			}
		}

		/// <summary>The possible choices when an argument is defined as an abstract type.</summary>
		/// <remarks>The possible choices when an argument is defined as an abstract type.</remarks>
		/// <returns>the list of choices.</returns>
		public override IList<Relationship> Choices
		{
			get
			{
				return this.choices;
			}
		}

		/// <summary>Records the differences between arguments of different release versions during regen.</summary>
		/// <remarks>Records the differences between arguments of different release versions during regen.</remarks>
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
	}
}
