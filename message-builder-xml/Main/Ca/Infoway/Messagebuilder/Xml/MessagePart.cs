/**
 * Copyright 2012 Canada Health Infoway, Inc.
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
 * Last modified: $LastChangedDate: 2012-07-31 11:05:53 -0400 (Tue, 31 Jul 2012) $
 * Revision:      $LastChangedRevision: 6007 $
 */

using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Xml;
using Platform.SimpleXml;
using Ca.Infoway.Messagebuilder.Lang;

namespace Ca.Infoway.Messagebuilder.Xml
{
	/// <summary>A message part.</summary>
	/// <remarks>
	/// A message part.  An example message part might be represent the type
	/// "MCCI_MT700751CA.ControlActEvent".
	/// </remarks>
	/// <author><a href="http://www.intelliware.ca/">Intelliware Development</a></author>
	[RootAttribute]
	public class MessagePart : Documentable
	{
		[XmlAttributeAttribute(Required = false)]
		private string name;

		[XmlAttributeAttribute(Required = false, Name = "abstract")]
		private bool @abstract;

		[ElementAttribute(Required = false)]
		private Ca.Infoway.Messagebuilder.Xml.Documentation documentation;

        [XmlAttributeAttribute(Required = false)]
        private string rimClass;

		[ElementListAttribute(Required = false, Inline = true)]
		private IList<Relationship> relationships = new List<Relationship>();

		[ElementListAttribute(Required = false, Inline = true, Entry = "specializationChild")]
		private IList<string> specializationChilds = new List<string>();

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

		public virtual string GetName()
		{
			return this.name;
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
		public virtual bool Abstract
		{
			get
			{
				return this.@abstract;
			}
			set
			{
				bool isAbstract = value;
				this.@abstract = isAbstract;
			}
		}

		/// <summary>Factory method for creating an abstract message part.</summary>
		/// <remarks>Factory method for creating an abstract message part.</remarks>
		/// <param name="name">- the type name of the message part</param>
		/// <returns>- the newly-constructed message part</returns>
		public static Ca.Infoway.Messagebuilder.Xml.MessagePart CreateAbstractPart(string name)
		{
			Ca.Infoway.Messagebuilder.Xml.MessagePart part = new Ca.Infoway.Messagebuilder.Xml.MessagePart(name);
			part.Abstract = true;
			return part;
		}

		/// <summary>Get the list of names of the child types.</summary>
		/// <remarks>Get the list of names of the child types.</remarks>
		/// <returns>the child types.</returns>
		/// <summary>Set the list of child types.</summary>
		/// <remarks>Set the list of child types.</remarks>
		/// <value>- the new child types</value>
		public virtual IList<string> SpecializationChilds
		{
			get
			{
				return this.specializationChilds;
			}
			set
			{
				IList<string> specializationChilds = value;
				this.specializationChilds = specializationChilds;
			}
		}

		/// <summary>Get a specific relationship by name.</summary>
		/// <remarks>Get a specific relationship by name.</remarks>
		/// <param name="name">- the name of the relationship</param>
		/// <returns>- the relationship</returns>
		public virtual Relationship GetRelationship(string name)
		{
			return GetRelationship(name, null);
		}

		/// <summary>Get a specific relationship by name.</summary>
		/// <remarks>Get a specific relationship by name.</remarks>
		/// <param name="name">- the name of the relationship</param>
		/// <param name="interaction">- the interaction (used to resolve names of template parameters) or null</param>
		/// <returns>- the relationship</returns>
		public virtual Relationship GetRelationship(string name, Interaction interaction)
		{
			Relationship result = null;
			//First look for children matching 'name'
			foreach (Relationship relationship in this.relationships)
			{
				if (MatchesRelationshipByName(name, relationship) || MatchesRelationshipByTraversalName(name, relationship, interaction))
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
			return result;
		}

		private bool MatchesRelationshipByChoiceOptionName(string name, Relationship relationship)
		{
			return relationship.Choice && relationship.FindChoiceOption(ChoiceSupport.ChoiceOptionNamePredicate(name)) != null;
		}

		private bool MatchesRelationshipByName(string name, Relationship relationship)
		{
			return StringUtils.IsNotBlank(name) && name.Equals(relationship.Name);
		}

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

        /// <summary>Get the conformance level.</summary>
        /// <remarks>Get the conformance level.</remarks>
        /// <returns>the conformance level.</returns>
        /// <summary>Set the conformance level.</summary>
        /// <remarks>Set the conformance level.</remarks>
        /// <value>the conformance level.</value>
        public virtual Ca.Infoway.Messagebuilder.Xml.RimClass RimClass
        {
            get
            {
                if (this.rimClass != null)
                {
                    return EnumPattern.ValueOf<Ca.Infoway.Messagebuilder.Xml.RimClass>(this.rimClass);
                }
                else
                {
                    return null;
                }
            }
            set
            {
                Ca.Infoway.Messagebuilder.Xml.RimClass rimClass = value;
                this.rimClass = rimClass == null ? null : rimClass.Name;
            }
        }
	}
}
