using System;
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.J5goodies;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Model;
using Ca.Infoway.Messagebuilder.Platform;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	/// <summary>
	/// This class exists to make it a bit easier to collate information about
	/// collapsed beans.
	/// </summary>
	/// <remarks>
	/// This class exists to make it a bit easier to collate information about
	/// collapsed beans.
	/// </remarks>
	/// <author>Intelliware Development</author>
	internal class RelationshipSorter
	{
		private readonly RelationshipMap map = new RelationshipMap();

		private readonly IDictionary<string, BeanProperty> properties = new Dictionary<string, BeanProperty>();

		private readonly Type beanType;

		private readonly object bean;

		private readonly string propertyName;

		private readonly bool collapsed;

		internal RelationshipSorter(string propertyName, Type beanType, object bean) : this(propertyName, beanType, bean, false)
		{
		}

		private RelationshipSorter(string propertyName, Type beanType, object bean, bool collapsed)
		{
			this.propertyName = propertyName;
			this.beanType = beanType;
			this.bean = bean;
			this.collapsed = collapsed;
		}

		internal virtual Type GetBeanType()
		{
			return this.beanType;
		}

		private void Add(Mapping mapping, BeanProperty beanProperty)
		{
			this.properties[beanProperty.Name] = beanProperty;
			if (!mapping.IsCompound())
			{
				this.map.Put(mapping, beanProperty);
			}
			else
			{
				if (!this.map.ContainsMapping(mapping.FirstPart()))
				{
					Ca.Infoway.Messagebuilder.Marshalling.RelationshipSorter sorter = new Ca.Infoway.Messagebuilder.Marshalling.RelationshipSorter
						(beanProperty.Name, GetBeanType(), GetBean(), true);
					this.map.Put(mapping.FirstPart(), sorter);
				}
				GetAsRelationshipSorter(mapping.FirstPart()).Add(mapping.Rest(), beanProperty);
			}
		}

		/// <summary>We need to distribute all "common" mappings to every applicable "type-based" mappings</summary>
		/// <param name="mapping"></param>
		/// <param name="beanProperty"></param>
		private void AddDuplicates(Mapping mapping, BeanProperty beanProperty)
		{
			IList<RelationshipMap.Key> allTypeBased = this.map.GetAllTypeBased(mapping.First());
			foreach (RelationshipMap.Key key in allTypeBased)
			{
				object @object = this.map.Get(key);
				if (@object is Ca.Infoway.Messagebuilder.Marshalling.RelationshipSorter)
				{
					Mapping rest = mapping.Rest();
					Ca.Infoway.Messagebuilder.Marshalling.RelationshipSorter innerRelationshipSorter = (Ca.Infoway.Messagebuilder.Marshalling.RelationshipSorter
						)@object;
					if (rest.IsCompound())
					{
						innerRelationshipSorter.properties[beanProperty.Name] = beanProperty;
						// TM - Redmine 10965 - this "if" check fixes bug, might not be sufficient in the long run
						if (innerRelationshipSorter.map.GetAllTypeBased(rest.First()).IsEmpty())
						{
							innerRelationshipSorter.Add(rest, beanProperty);
						}
						else
						{
							innerRelationshipSorter.AddDuplicates(rest, beanProperty);
						}
					}
					else
					{
						// we are at the "bottom" of the chain - now we can add the "duplicate" property to its correct location 
						innerRelationshipSorter.Add(rest, beanProperty);
					}
				}
			}
		}

		internal virtual Ca.Infoway.Messagebuilder.Marshalling.RelationshipSorter GetAsRelationshipSorter(NamedAndTyped relationship
			)
		{
			return (Ca.Infoway.Messagebuilder.Marshalling.RelationshipSorter)this.map.Get(relationship);
		}

		private Ca.Infoway.Messagebuilder.Marshalling.RelationshipSorter GetAsRelationshipSorter(Mapping firstPart)
		{
			return GetAsRelationshipSorter(firstPart.GetAllTypes()[0]);
		}

		internal static Ca.Infoway.Messagebuilder.Marshalling.RelationshipSorter Create(string propertyName, object tealBean)
		{
			Ca.Infoway.Messagebuilder.Marshalling.RelationshipSorter holder = new Ca.Infoway.Messagebuilder.Marshalling.RelationshipSorter
				(propertyName, tealBean == null ? null : tealBean.GetType(), tealBean);
			IDictionary<string, BeanProperty> properties = BeanProperty.GetProperties(tealBean);
			foreach (BeanProperty property in properties.Values)
			{
				IList<Mapping> mappings = Mapping.From(property);
				foreach (Mapping mapping in mappings)
				{
					holder.Add(mapping, property);
				}
			}
			foreach (BeanProperty property in properties.Values)
			{
				IList<Mapping> mappings = Mapping.From(property);
				foreach (Mapping mapping in mappings)
				{
					// if this is an inlined "common" mapping, we need to add it to appropriate "type-based" mappings
					if (mapping.IsCompound() && !mapping.HasPartTypeMappings())
					{
						holder.AddDuplicates(mapping, property);
					}
				}
			}
			return holder;
		}

		internal virtual bool IsCollapsedRelationship(NamedAndTyped relationshipName)
		{
			object o = Get(relationshipName);
			return o != null && o is Ca.Infoway.Messagebuilder.Marshalling.RelationshipSorter;
		}

		internal virtual object Get(NamedAndTyped namedAndTyped)
		{
			return this.map.Get(namedAndTyped);
		}

		[Obsolete]
		internal virtual object Get(string relationshipName)
		{
			return this.map.Get(relationshipName);
		}

		internal virtual object GetField(NamedAndTyped relationship)
		{
			object o = this.map.Get(relationship);
			if (o is BeanProperty)
			{
				return GetMessageBeanPart().GetField(WordUtils.Uncapitalize(((BeanProperty)o).Name));
			}
			else
			{
				throw new MarshallingException("Relationship " + relationship.Name + " of " + ToString() + " does not resolve to a bean property"
					);
			}
		}

		private MessagePartBean GetMessageBeanPart()
		{
			return (MessagePartBean)this.bean;
		}

		// These methods only exist to support one case: the case of the collapsed relationship
		// with cardinality changes
		internal virtual int PropertyCount()
		{
			return this.properties.Count;
		}

		internal virtual int GetSingleCollapsedPropertySize()
		{
			if (PropertyCount() != 1)
			{
				throw new MarshallingException(ToString() + " with cardinality changes cannot handle " + PropertyCount() + " collapsed properties"
					);
			}
			else
			{
				BeanProperty property = (BeanProperty)new List<BeanProperty>(this.properties.Values)[0];
				object value = property.Get();
				if (value == null)
				{
					return 0;
				}
				else
				{
					if (ListElementUtil.IsCollection(value))
					{
						return ListElementUtil.Count(value);
					}
					else
					{
						return 1;
					}
				}
			}
		}

		public virtual object GetBean()
		{
			return this.bean;
		}

		public virtual string GetPropertyName()
		{
			return this.propertyName;
		}

		public override string ToString()
		{
			if (this.collapsed)
			{
				return "Sorter (Components of " + ClassUtils.GetShortClassName(this.beanType) + "): " + this.propertyName;
			}
			else
			{
				return "Sorter (" + ClassUtils.GetShortClassName(this.beanType) + "): " + this.propertyName;
			}
		}
	}
}
