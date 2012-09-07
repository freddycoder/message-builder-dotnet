using System;
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Annotation;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Nullflavor;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.J5goodies;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Marshalling.Datatypeadapter;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Platform;
using Ca.Infoway.Messagebuilder.Terminology;
using Ca.Infoway.Messagebuilder.Xml;
using ILOG.J2CsMapping.Collections.Generics;
using ILOG.J2CsMapping.Text;
using log4net;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	internal class BeanWrapper
	{
		[Obsolete]
		private readonly IDictionary<string, BeanProperty> map;

		[Obsolete]
		private readonly string contextName;

		private readonly ILog log = log4net.LogManager.GetLogger(typeof(Ca.Infoway.Messagebuilder.Marshalling.BeanWrapper));

		private readonly DataTypeValueAdapterProvider adapterProvider = new DataTypeValueAdapterProvider();

		private RelationshipSorter sorter;

		private readonly Ca.Infoway.Messagebuilder.Marshalling.BeanWrapper parentWrapper;

		internal BeanWrapper(object bean)
		{
			this.map = BeanProperty.GetProperties(bean);
			this.sorter = RelationshipSorter.Create(string.Empty, bean);
			this.contextName = null;
			this.parentWrapper = null;
		}

		private BeanWrapper(Ca.Infoway.Messagebuilder.Marshalling.BeanWrapper parentWrapper, string contextName, RelationshipSorter
			 sorter)
		{
			this.parentWrapper = parentWrapper;
			this.map = parentWrapper.map;
			this.sorter = sorter;
			this.contextName = Concatenate(parentWrapper.contextName, contextName);
		}

		private string Concatenate(string part1, string part2)
		{
			if (StringUtils.IsBlank(part1))
			{
				return part2;
			}
			else
			{
				if (StringUtils.IsBlank(part2))
				{
					return part1;
				}
				else
				{
					return part1 + "/" + part2;
				}
			}
		}

		internal virtual void Write(Relationship relationship, object o)
		{
			if (!relationship.Fixed)
			{
				BeanProperty property = FindBeanProperty(relationship);
				if (property != null)
				{
					if (o != null)
					{
						if (o is BareANY)
						{
							WriteDataType(property, (BareANY)o, relationship.Type);
						}
						else
						{
							WriteNonDataType(relationship.Name, property, o);
						}
					}
				}
				else
				{
					this.log.Info("PROPERTY NOT WRITTEN: could not find property with relationship named " + relationship + " on " + GetWrappedType
						());
				}
			}
		}

		private BeanProperty FindBeanProperty(NamedAndTyped relationshipName)
		{
			return (BeanProperty)this.sorter.Get(relationshipName);
		}

		private void WriteDataType(BeanProperty property, BareANY value, string dataTypeName)
		{
			BareANY field = new DataTypeFieldHelper(property.Bean, property.Name).Get<BareANY>();
			if (field == null)
			{
				//this is required for the case sure when we collapse an association with cardinality > 1
				//into a List of data types. See DevicePrescriptionSummaryQueryCriteriaBean#getRxDispenseIndicator
				if (property.Collection)
				{
					ListElementUtil.AddElement(property.Get(), value.BareValue);
				}
			}
			else
			{
				value = this.adapterProvider.GetAdapter(dataTypeName, field.GetType()).Adapt(value);
				if (value.HasNullFlavor())
				{
					new DataTypeFieldHelper(property.Bean, property.Name).SetNullFlavor(value.NullFlavor);
				}
				if (value is CD)
				{
					((CD)field).OriginalText = ((CD)value).OriginalText;
				}
				((BareANYImpl)field).BareValue = value.BareValue;
				field.DataType = value.DataType;
			}
		}

		private void WriteNonDataType(string relationshipName, BeanProperty property, object @object)
		{
			if (property.Collection)
			{
				if (ListElementUtil.IsCollection(@object))
				{
					ListElementUtil.AddAllElements(property.Get(), @object);
				}
				else
				{
					this.log.Info("Warning mapping HL7 single property to Teal collection. Property=" + relationshipName);
					ListElementUtil.AddElement(property.Get(), @object);
				}
			}
			else
			{
				if (property.Writable)
				{
					if (@object != null)
					{
						property.Set(@object);
					}
				}
				else
				{
					throw new MarshallingException("Cannot write to " + property.Name + " of " + this.sorter.GetBean().GetType());
				}
			}
		}

		public virtual void WriteNodeAttribute(Relationship relationship, string attributeValue, VersionNumber version)
		{
			BeanProperty property = FindBeanProperty(relationship);
			if (property != null)
			{
				if (StringUtils.IsNotBlank(attributeValue))
				{
					if (property.Writable)
					{
						if ("BL".Equals(relationship.Type))
						{
							property.Set(ILOG.J2CsMapping.Util.BooleanUtil.ValueOf(attributeValue));
						}
						else
						{
							if ("CS".Equals(relationship.Type))
							{
								property.Set(ResolveCodeValue(relationship, attributeValue, version));
							}
							else
							{
								this.log.Info("UNSUPPORTED RimType: IGNORING relationhsipName=" + relationship.Name + ", property=" + property.Name);
							}
						}
					}
					else
					{
						this.log.Info("PROPERTY NOT WRITABLE: IGNORING relationhsipName=" + relationship.Name + ", property=" + property.Name);
					}
				}
			}
			else
			{
				if (relationship.Fixed)
				{
				}
				else
				{
					// We don't need to map fixed value codes.
					this.log.Info("PROPERTY NOT FOUND - IGNORED: no relationship named " + relationship.Name + " found on " + GetWrappedType(
						));
				}
			}
		}

		private Code ResolveCodeValue(Relationship relationship, string attributeValue, VersionNumber version)
		{
			return CodeResolverRegistry.Lookup((Type)DomainTypeHelper.GetReturnType(relationship, version), attributeValue);
		}

		public virtual void WriteNullFlavor(Hl7Source source, Relationship relationship, NullFlavor nullFlavor)
		{
			object targetBean = null;
			if (this.parentWrapper != null)
			{
				targetBean = GetOrCreateCollapsedBean(source, relationship);
			}
			else
			{
				targetBean = this.sorter.GetBean();
			}
			if (targetBean is NullFlavorSupport)
			{
				((NullFlavorSupport)targetBean).NullFlavor = nullFlavor;
			}
			else
			{
				this.log.Info(System.String.Format("CAN NOT SET NULL FLAVOR! Bean {0} does not implement {1}.", this.sorter.GetBeanType()
					.Name, typeof(NullFlavorSupport).Name));
			}
		}

		private object GetOrCreateCollapsedBean(Hl7Source source, Relationship relationship)
		{
			BeanProperty property = FindBeanProperty(relationship);
			// TM - fix for bug 13100 - will property always be null?
			if (property == null)
			{
				property = GetPropertyForAssociation();
			}
			object collapsedBean = property.Get();
			if (collapsedBean == null)
			{
				Relationship collapsedRelationship = GetCollapsedRelationship(source, property.GetAnnotation<Hl7XmlMappingAttribute>());
				if (collapsedRelationship != null)
				{
					Hl7PartSource collapsedPartSource = source.CreatePartSource(collapsedRelationship, source.GetCurrentElement());
					collapsedBean = Instantiator.GetInstance().InstantiateMessagePartBean(collapsedPartSource.GetVersion(), collapsedPartSource
						.Type, collapsedPartSource.GetInteraction());
					property.Set(collapsedBean);
				}
				else
				{
					this.log.Info(System.String.Format("UNABLE TO SET NULL FLAVOR - Can not find bean for collapsed property {0}.{1}", this.sorter
						.GetBeanType().Name, this.contextName));
				}
			}
			return collapsedBean;
		}

		private Relationship GetCollapsedRelationship(Hl7Source source, Hl7XmlMappingAttribute mapping)
		{
			Relationship relationship = null;
			if (mapping != null)
			{
				foreach (string path in mapping.Value)
				{
					relationship = source.GetRelationship(System.Text.RegularExpressions.Regex.Replace(path, this.contextName + ".", string.Empty
						));
					if (relationship != null)
					{
						break;
					}
				}
			}
			return relationship;
		}

		private IList<string> GetMapping(BeanProperty property)
		{
			Hl7XmlMappingAttribute annotation = property.GetAnnotation<Hl7XmlMappingAttribute>();
			if (annotation != null)
			{
				return Arrays.AsList(annotation.Value);
			}
			else
			{
				return CollUtils.EmptyList<string>();
			}
		}

		public virtual bool IsAssociationMappedToSameBean(NamedAndTyped relationshipName)
		{
			object @object = this.sorter.Get(relationshipName);
			return @object != null && @object is RelationshipSorter;
		}

		private BeanProperty GetPropertyForAssociation()
		{
			BeanProperty result = null;
			foreach (BeanProperty property in this.map.Values)
			{
				if (IsAssociationMappedToProperty(null, property))
				{
					result = property;
					break;
				}
			}
			return result;
		}

		private bool IsAssociationMappedToProperty(string relationshipName, BeanProperty property)
		{
			IList<string> mappings = GetMapping(property);
			foreach (string mapping in mappings)
			{
				if (StartsWith(mapping, relationshipName))
				{
					return true;
				}
			}
			return false;
		}

		private bool StartsWith(string mapping, string name)
		{
			return mapping.StartsWith(Concatenate(this.contextName, name) + "/");
		}

		public virtual Ca.Infoway.Messagebuilder.Marshalling.BeanWrapper CreateSubWrapper(NamedAndTyped relationshipName)
		{
			return new Ca.Infoway.Messagebuilder.Marshalling.BeanWrapper(this, relationshipName.Name, (RelationshipSorter)this.sorter
				.Get(relationshipName));
		}

		public virtual string GetWrappedType()
		{
			return ClassUtils.GetShortClassName(this.sorter.GetBeanType());
		}

		public virtual bool IsPreInitializedDelegate(NamedAndTyped relationshipName)
		{
			return GetInitializedReadOnlyAssociation(relationshipName) != null;
		}

		public virtual object GetInitializedReadOnlyAssociation(NamedAndTyped relationshipName)
		{
			object @object;
			BeanProperty beanProperty = FindBeanProperty(relationshipName);
			if (beanProperty == null)
			{
				@object = null;
			}
			else
			{
				if (!beanProperty.Readable)
				{
					@object = null;
				}
				else
				{
					if (ListElementUtil.IsCollection((Type)beanProperty.PropertyType))
					{
						//Initialized collections don't count
						@object = null;
					}
					else
					{
						@object = beanProperty.Get();
					}
				}
			}
			return @object;
		}

		public virtual NullFlavor GetNullFlavor()
		{
			//AG: make sure we always traverse down collapsed associations.
			NullFlavor nullFlavor = null;
			if (this.parentWrapper == null)
			{
				if (this.sorter.GetBean() is NullFlavorSupport)
				{
					return ((NullFlavorSupport)this.sorter.GetBean()).NullFlavor;
				}
			}
			return nullFlavor;
		}
	}
}
