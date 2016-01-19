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
using Ca.Infoway.Messagebuilder.J5goodies;
using Ca.Infoway.Messagebuilder.Marshalling;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	/// <summary>
	/// This class maps the individual HL7 relationships to either a
	/// bean property or to an instance of a relationship sorter.
	/// </summary>
	/// <remarks>
	/// This class maps the individual HL7 relationships to either a
	/// bean property or to an instance of a relationship sorter.  If the
	/// bean's representation of the relationship is nested, then we get a
	/// relationship sorter; otherwise it's a bean property.
	/// </remarks>
	/// <author>Intelliware Development</author>
	internal class RelationshipMap
	{
		internal class Key : NamedAndTyped
		{
			private readonly string name;

			private readonly string type;

			internal Key(NamedAndTyped namedAndTyped)
			{
				this.name = namedAndTyped.Name;
				this.type = namedAndTyped.Type;
			}

			internal Key(string name, string type)
			{
				this.name = name;
				this.type = type;
			}

			internal Key(string name)
			{
				this.name = name;
				this.type = null;
			}

			public virtual string Name
			{
				get
				{
					return this.name;
				}
			}

			public virtual string Type
			{
				get
				{
					return this.type;
				}
			}

			public override int GetHashCode()
			{
				return new HashCodeBuilder().Append(this.name).Append(this.type).ToHashCode();
			}

			public override bool Equals(object obj)
			{
				if (obj == null)
				{
					return false;
				}
				else
				{
					if (obj == this)
					{
						return true;
					}
					else
					{
						if (obj.GetType() != GetType())
						{
							return false;
						}
						else
						{
							RelationshipMap.Key that = (RelationshipMap.Key)obj;
							return new EqualsBuilder().Append(this.name, that.name).Append(this.type, that.type).IsEquals();
						}
					}
				}
			}

			public override string ToString()
			{
				return "Key: " + this.name + " (" + this.type + ")";
			}
		}

		private readonly IDictionary<RelationshipMap.Key, object> relationships = new Dictionary<RelationshipMap.Key, object>();

		internal virtual void Put(Mapping mapping, BeanProperty beanProperty)
		{
			foreach (NamedAndTyped namedAndTyped in mapping.GetAllTypes())
			{
				this.relationships[new RelationshipMap.Key(namedAndTyped)] = beanProperty;
			}
		}

		internal virtual void Put(Mapping mapping, RelationshipSorter sorter)
		{
			foreach (NamedAndTyped namedAndTyped in mapping.GetAllTypes())
			{
				this.relationships[new RelationshipMap.Key(namedAndTyped)] = sorter;
			}
		}

		[Obsolete]
		internal virtual object Get(string relationshipName)
		{
			return this.relationships.SafeGet(new RelationshipMap.Key(relationshipName));
		}

		internal virtual IList<RelationshipMap.Key> GetAllTypeBased(string relationshipName)
		{
			IList<RelationshipMap.Key> result = new List<RelationshipMap.Key>();
			ICollection<RelationshipMap.Key> keySet = this.relationships.Keys;
			foreach (RelationshipMap.Key key in keySet)
			{
				if (relationshipName.Equals(key.Name) && key.Type != null)
				{
					result.Add(key);
				}
			}
			return result;
		}

		internal virtual bool ContainsMapping(Mapping mapping)
		{
			return this.relationships.ContainsKey(new RelationshipMap.Key(mapping.GetAllTypes()[0]));
		}

		internal virtual object Get(NamedAndTyped relationship)
		{
			object result = this.relationships.SafeGet(new RelationshipMap.Key(relationship));
			if (result == null)
			{
				result = this.relationships.SafeGet(new RelationshipMap.Key(relationship.Name));
			}
			return result;
		}
	}
}
