using System;
using System.Collections.Generic;
using System.Reflection;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.DevTools;
using Ca.Infoway.Messagebuilder.J5goodies;
using Ca.Infoway.Messagebuilder.Model;
using Ca.Infoway.Messagebuilder.Platform;

namespace Ca.Infoway.Messagebuilder.DevTools
{
	public class MessageBeanFactory
	{
		private readonly ValueHolder valueHolder;

		public MessageBeanFactory(ValueHolder valueHolder)
		{
			this.valueHolder = valueHolder;
		}

		public virtual T Populate<T>(T hl7MessageBean) where T : IInteraction
		{
			AssignAllDefaults(hl7MessageBean, this.valueHolder);
			return hl7MessageBean;
		}

		private void AssignAllDefaults(object hl7MessageBean, object defaultValues)
		{
			IDictionary<string, BeanProperty> properties = BeanProperty.GetProperties(hl7MessageBean);
			foreach (string propertyName in properties.Keys)
			{
				BeanProperty property = properties.SafeGet(propertyName);
				if (IsDefaultPresent(propertyName, defaultValues))
				{
					AssignValue(property, hl7MessageBean, defaultValues);
				}
			}
		}

		private void AssignValue(BeanProperty property, object hl7MessageBean, object defaultValues)
		{
			BeanProperty defaultProperty = BeanProperty.GetProperty(defaultValues, property.Name);
			object value = defaultProperty.Get();
			SetValue(property, value);
		}

		private void SetValue(BeanProperty property, object value)
		{
			if (value == null)
			{
			}
			else
			{
				// do nothing
				if (typeof(ICollection<object>).IsAssignableFrom(value.GetType()) && property.Collection)
				{
					foreach (object o in ((ICollection<object>)value))
					{
						Type clazz = GenericClassUtil.GetCollectionContentsType(property);
						if (clazz == null || clazz.IsAssignableFrom(o.GetType()))
						{
							((ICollection<object>)property.Get()).Add(o);
						}
						else
						{
							object newInstance = ClassUtil.NewInstance(clazz);
							AssignAllDefaults(newInstance, o);
							((ICollection<object>)property.Get()).Add(newInstance);
						}
					}
				}
				else
				{
					if (property.Collection)
					{
						((ICollection<object>)property.Get()).Add(value);
					}
					else
					{
						if (typeof(ICollection<object>).IsAssignableFrom(value.GetType()))
						{
							foreach (object o in ((ICollection<object>)value))
							{
								property.Set(o);
							}
						}
						else
						{
							if (!IsStandardDataType(property))
							{
								CreateBeanInstanceForProperty(property);
								AssignAllDefaults(property.Get(), value);
							}
							else
							{
								if (property.Writable)
								{
									property.Set(value);
								}
							}
						}
					}
				}
			}
		}

		private void CreateBeanInstanceForProperty(BeanProperty property)
		{
			if (property.Get() == null)
			{
				try
				{
					property.Set(System.Activator.CreateInstance(property.PropertyType));
				}
				catch (MemberAccessException e)
				{
					Ca.Infoway.Messagebuilder.Runtime.PrintStackTrace(e);
				}
				catch (Exception e)
				{
					Ca.Infoway.Messagebuilder.Runtime.PrintStackTrace(e);
				}
			}
		}

		private bool IsStandardDataType(BeanProperty property)
		{
			string packageName = ClassUtils.GetPackageName(property.PropertyType);
			if (packageName.StartsWith("java."))
			{
				return true;
			}
			else
			{
				if (StringUtils.Equals(packageName, ClassUtils.GetPackageName(typeof(Identifier))))
				{
					return true;
				}
				else
				{
					if (typeof(Code).IsAssignableFrom(property.PropertyType))
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

		private bool IsDefaultPresent(string propertyName, object defaultValues)
		{
			return BeanProperty.GetProperty(defaultValues, propertyName) != null;
		}
	}
}
