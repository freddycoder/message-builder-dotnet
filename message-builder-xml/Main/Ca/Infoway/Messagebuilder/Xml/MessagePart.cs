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
 * Author:        $LastChangedBy: jmis $
 * Last modified: $LastChangedDate: 2015-05-27 08:43:37 -0400 (Wed, 27 May 2015) $
 * Revision:      $LastChangedRevision: 9535 $
 */
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Lang;
using Ca.Infoway.Messagebuilder.Xml;
using Platform.SimpleXml;

namespace Ca.Infoway.Messagebuilder.Xml
{
	/// <summary>A message part.</summary>
	/// <remarks>
	/// A message part.  An example message part might be represent the type
	/// "MCCI_MT700751CA.ControlActEvent".
	/// </remarks>
	/// <author>Intelliware Development</author>
	[RootAttribute]
	public class MessagePart : Documentable, HasDifferences, Named
	{
		[XmlAttributeAttribute(Required = false)]
		private string name;

		[XmlAttributeAttribute(Required = false, Name = "abstract")]
		private bool isAbstract;

		[XmlAttributeAttribute(Required = false)]
		private bool templateParameter;

		[ElementListAttribute(Inline = true, Required = false)]
		[NamespaceAttribute(Prefix = "regen", Reference = "regen_ns")]
		private IList<Difference> differences = new List<Difference>();

		[ElementAttribute(Required = false)]
		private Ca.Infoway.Messagebuilder.Xml.Documentation documentation;

		[XmlAttributeAttribute(Required = false)]
		private string rimClass;

		[XmlAttributeAttribute(Required = false)]
		private string derivedFromClass;

		[ElementListAttribute(Required = false, Inline = true)]
		private IList<Relationship> relationships = new List<Relationship>();

		[ElementListAttribute(Required = false, Inline = true, Entry = "specializationChild")]
		private IList<SpecializationChild> specializationChilds = new List<SpecializationChild>();

		/// <summary>Default constructor.</summary>
		/// <remarks>Default constructor.</remarks>
		public MessagePart()
		{
		}

		/// <summary>Default constructor.</summary>
		/// <remarks>Default constructor.</remarks>
		/// <param name="name">- the part type name</param>
		public MessagePart(string name)
		{
			this.name = name;
		}

		/// <summary>Get the name.</summary>
		/// <remarks>Get the name.</remarks>
		/// <returns>the name.</returns>
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

		/// <summary>Get the documentation.</summary>
		/// <remarks>Get the documentation.</remarks>
		/// <returns>the documentation.</returns>
		/// <summary>Set the documentation.</summary>
		/// <remarks>Set the documentation.</remarks>
		/// <value>- the new documentation value</value>
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

		public virtual string DerivedFromClass
		{
			get
			{
				return derivedFromClass;
			}
			set
			{
				string derivedFromClass = value;
				this.derivedFromClass = derivedFromClass;
			}
		}

		/// <summary>Get the list of relationships.</summary>
		/// <remarks>Get the list of relationships.</remarks>
		/// <returns>- the relationships</returns>
		/// <summary>Set the list of relationships.</summary>
		/// <remarks>Set the list of relationships.</remarks>
		/// <value>- the new value</value>
		public virtual IList<Relationship> Relationships
		{
			get
			{
				foreach (Relationship relationship in this.relationships)
				{
					relationship.ParentType = this.name;
				}
				return this.relationships;
			}
			set
			{
				IList<Relationship> relationships = value;
				this.relationships = relationships;
			}
		}

		/// <summary>Get the abstractness.</summary>
		/// <remarks>Get the abstractness.</remarks>
		/// <returns>true if the message part is abstract; false otherwise.</returns>
		/// <summary>Set the abstractness.</summary>
		/// <remarks>Set the abstractness.</remarks>
		/// <value>- the new abstractness value</value>
		public virtual bool IsAbstract
		{
			get
			{
				return this.isAbstract;
			}
			set
			{
				bool isAbstract = value;
				this.isAbstract = isAbstract;
			}
		}

		/// <summary>Factory method for creating an abstract message part.</summary>
		/// <remarks>Factory method for creating an abstract message part.</remarks>
		/// <param name="name">- the type name of the message part</param>
		/// <returns>- the newly-constructed message part</returns>
		public static Ca.Infoway.Messagebuilder.Xml.MessagePart CreateAbstractPart(string name)
		{
			Ca.Infoway.Messagebuilder.Xml.MessagePart part = new Ca.Infoway.Messagebuilder.Xml.MessagePart(name);
			part.IsAbstract = true;
			return part;
		}

		public virtual bool TemplateParameter
		{
			get
			{
				return templateParameter;
			}
			set
			{
				bool templateParameter = value;
				this.templateParameter = templateParameter;
			}
		}

		/// <summary>Factory method for creating a template parameter.</summary>
		/// <remarks>Factory method for creating a template parameter.</remarks>
		/// <param name="name">- the type name of the message part</param>
		/// <returns>- the newly-constructed message part</returns>
		public static Ca.Infoway.Messagebuilder.Xml.MessagePart CreateTemplateParameter(string name)
		{
			Ca.Infoway.Messagebuilder.Xml.MessagePart part = new Ca.Infoway.Messagebuilder.Xml.MessagePart(name);
			part.TemplateParameter = true;
			return part;
		}

		/// <summary>Get the list of names of the child types.</summary>
		/// <remarks>Get the list of names of the child types.</remarks>
		/// <returns>the child types.</returns>
		public virtual IList<SpecializationChild> SpecializationChilds
		{
			get
			{
				return this.specializationChilds;
			}
		}

		/// <summary>
		/// Determines whether the message part has a specialization child
		/// matching the given name
		/// </summary>
		/// <param name="the">name to test</param>
		/// <returns>true if the name matches</returns>
		public virtual SpecializationChild GetSpecializationChild(string childName)
		{
			SpecializationChild result = null;
			foreach (SpecializationChild child in this.specializationChilds)
			{
				if (child.Name.Equals(childName))
				{
					result = child;
					break;
				}
			}
			return result;
		}

		/// <summary>Add a child to the list of child types.</summary>
		/// <remarks>Add a child to the list of child types.</remarks>
		/// <param name="specializationChild">- the new child</param>
		public virtual void AddSpecializationChild(SpecializationChild specializationChild)
		{
			this.specializationChilds.Add(specializationChild);
		}

		/// <summary>Remove a specialization child from the list by name</summary>
		/// <param name="childName">the name of the child to remove</param>
		public virtual void RemoveSpecializationChild(string childName)
		{
			// TM - modified to remove usage of iterator.remove() to facilitate translation
			int index = -1;
			for (int i = 0; i < this.specializationChilds.Count; i++)
			{
				if (this.specializationChilds[i].Name.Equals(childName))
				{
					index = i;
					break;
				}
			}
			if (index >= 0)
			{
				this.specializationChilds.RemoveAt(index);
			}
		}

		/// <summary>
		/// Determines whether the message part has a specialization child
		/// matching the given name
		/// </summary>
		/// <param name="the">name to test</param>
		/// <returns>true if the name matches</returns>
		public virtual bool HasSpecializationChild(string childName)
		{
			return GetSpecializationChild(childName) != null;
		}

		/// <summary>Get a specific relationship by name.</summary>
		/// <remarks>Get a specific relationship by name.</remarks>
		/// <param name="name">- the name of the relationship</param>
		/// <returns>- the relationship</returns>
		public virtual Relationship GetRelationship(string name)
		{
			return GetRelationship(name, null, null);
		}

		/// <summary>Get a specific relationship by name.</summary>
		/// <remarks>Get a specific relationship by name.</remarks>
		/// <param name="name">- the name of the relationship</param>
		/// <returns>- the relationship</returns>
		public virtual Relationship GetRelationship(string name, string namespaze)
		{
			return GetRelationship(name, namespaze, null);
		}

		/// <summary>Get a specific relationship by name.</summary>
		/// <remarks>Get a specific relationship by name.</remarks>
		/// <param name="name">- the name of the relationship</param>
		/// <param name="interaction">- the interaction (used to resolve names of template parameters) or null</param>
		/// <returns>- the relationship</returns>
		public virtual Relationship GetRelationship(string name, string namespaze, Interaction interaction)
		{
			Relationship result = null;
			//First look for children matching 'name'
			foreach (Relationship relationship in this.relationships)
			{
				if (MatchesRelationshipByName(name, namespaze, relationship) || MatchesRelationshipByTraversalName(name, relationship, interaction
					))
				{
					result = relationship;
					break;
				}
			}
			//If that doesn't work, check inside any child relationships that are choices
			if (result == null)
			{
				foreach (Relationship relationship in this.relationships)
				{
					if (MatchesRelationshipByChoiceOptionName(name, relationship))
					{
						result = relationship;
						break;
					}
				}
			}
			if (result != null)
			{
				result.ParentType = this.name;
			}
			return result;
		}

		private bool MatchesRelationshipByChoiceOptionName(string name, Relationship relationship)
		{
			return relationship.Choice && relationship.FindChoiceOption(ChoiceSupport.ChoiceOptionNamePredicate(name)) != null;
		}

		private bool MatchesRelationshipByName(string name, string namespaze, Relationship relationship)
		{
			// TM - removing check against namespace; this may eventually be reinstated
			return StringUtils.IsNotBlank(name) && name.Equals(relationship.Name);
		}

		// && (StringUtils.equals(namespace, relationship.getNamespace()));
		private bool MatchesRelationshipByTraversalName(string name, Relationship relationship, Interaction interaction)
		{
			if (interaction != null && relationship.TemplateRelationship)
			{
				return MatchesRelationshipByTraversalName(name, relationship, interaction.Arguments);
			}
			else
			{
				return false;
			}
		}

		private bool MatchesRelationshipByTraversalName(string name, Relationship relationship, IList<Argument> arguments)
		{
			bool result = false;
			foreach (Argument argument in arguments)
			{
				if (StringUtils.IsNotBlank(name) && StringUtils.IsNotBlank(relationship.TemplateParameterName))
				{
					if (relationship.TemplateParameterName.Equals(argument.TemplateParameterName) && name.Equals(argument.TraversalName))
					{
						result = true;
					}
					else
					{
						result = MatchesRelationshipByTraversalName(name, relationship, argument.Arguments);
					}
					if (!result)
					{
						Relationship choice = argument.FindChoiceOption(ChoiceSupport.ChoiceOptionNamePredicate(name));
						if (choice != null)
						{
							result = true;
						}
					}
				}
				if (result)
				{
					break;
				}
			}
			return result;
		}

		/// <summary>Records the differences between message parts of different release versions during regen.</summary>
		/// <remarks>Records the differences between message parts of different release versions during regen.</remarks>
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

		public virtual Ca.Infoway.Messagebuilder.Xml.RimClass RimClass
		{
			get
			{
				if (this.rimClass != null)
				{
					return EnumPattern.ValueOf<Ca.Infoway.Messagebuilder.Xml.RimClass>(this.rimClass);
				}
				return null;
			}
			set
			{
				Ca.Infoway.Messagebuilder.Xml.RimClass rimClass = value;
				this.rimClass = rimClass == null ? null : rimClass.Name;
			}
		}
	}
}
