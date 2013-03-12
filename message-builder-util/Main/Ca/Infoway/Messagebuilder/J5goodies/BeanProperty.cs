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
 * Last modified: $LastChangedDate: 2013-03-01 17:48:17 -0500 (Fri, 01 Mar 2013) $
 * Revision:      $LastChangedRevision: 6663 $
 */

namespace Ca.Infoway.Messagebuilder.J5goodies {
	
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Reflection;
	using System.Runtime.CompilerServices;
	using System.Security;
	
	public class BeanProperty {
	
		private readonly PropertyInfo descriptor;
		private readonly Object bean;
	
		private BeanProperty(Object bean_0, PropertyInfo descriptor_1) {
			this.bean = bean_0;
			this.descriptor = descriptor_1;
		}
	
		
		public Type BeanType {
		  get {
				return this.bean.GetType();
			}
		}
		
		public bool Collection {
		  get {
				return !typeof(String).IsAssignableFrom(descriptor.PropertyType) &&
					typeof(IEnumerable).IsAssignableFrom(descriptor.PropertyType);
			}
		}	
		
		public String Name {
		  get {
				return this.descriptor.Name;
			}
		}
		
	
		
		public Type PropertyType {
		  get {
				return this.descriptor.PropertyType;
			}
		}
		
	
		
		public bool Readable {
		  get {
				return this.descriptor.GetGetMethod() != null;
			}
		}
		
	
		
		public bool Writable {
		  get {
				return WriteMethod != null;
			}
		}
		
	
		
		public MethodInfo ReadMethod {
		  get {
				MethodInfo readMethod = this.descriptor.GetGetMethod();
                /*
				if (readMethod != null && readMethod.IsBridge()) {
					readMethod = FindNonBridgeMethod(readMethod);
				}
                */
				return readMethod;
			}
		}
		
	
		private MethodInfo FindNonBridgeMethod(MethodInfo bridgeMethod) {
			MethodInfo method = bridgeMethod;
			try {
				method = ILOG.J2CsMapping.Reflect.Helper.GetMethod(bridgeMethod.DeclaringType,bridgeMethod.Name,new ILOG.J2CsMapping.Reflect.IlrMethodInfoAdapter(bridgeMethod.GetParameters()).GetTypes());
			} catch (SecurityException e) {
			} catch (AmbiguousMatchException e_0) {
			}
			return method;
		}
	
		
		public MethodInfo WriteMethod {
		  get {
				return this.descriptor.GetSetMethod();
			}
		}
		
	
		public void Set(Object value_ren) {
			try {
				ILOG.J2CsMapping.Reflect.Helper.Invoke(this.descriptor.GetSetMethod(),this.bean,new Object[] { value_ren });
			} catch (MemberAccessException e) {
				throw new BeanReflectionException(this, e);
			} catch (TargetInvocationException e_0) {
				throw new BeanReflectionException(this, e_0);
			}
		}
	
		public Object Get() {
			try {
				return ILOG.J2CsMapping.Reflect.Helper.Invoke(this.descriptor.GetGetMethod(),this.bean,new Object[0]);
			} catch (MemberAccessException e) {
				throw new BeanReflectionException(this, e);
			} catch (TargetInvocationException e_0) {
				throw new BeanReflectionException(this, e_0);
			}
		}
	
		public static IDictionary<String, BeanProperty> GetProperties(Object bean_0) {
			IDictionary<String, BeanProperty> properties = new Dictionary<String, BeanProperty>();
			try {
				if (bean_0 != null) {
					PropertyInfo[] descriptors = bean_0.GetType().GetProperties();
					/* foreach */
					foreach (PropertyInfo descriptor_1  in  descriptors) {
						properties[descriptor_1.Name] = new BeanProperty(bean_0, descriptor_1);
					}
				}
			} catch (Exception e) {
			}
			return properties;
		}
	
		public static BeanProperty GetProperty(Object bean_0, String propertyName) {
			IDictionary<String, BeanProperty> properties = GetProperties(bean_0);
			return properties.ContainsKey(propertyName) ? properties[propertyName] : null;
		}
	
		
		public PropertyInfo Descriptor {
		  get {
				return this.descriptor;
			}
		}
		
	
		
		public Object Bean {
		  get {
				return this.bean;
			}
		}
		
		public T GetAnnotation<T>()
        {
			Type attributeType = typeof(T);
			object[] attributes = this.descriptor.GetCustomAttributes(attributeType, false);
			if (attributes.Length>0) 
			{
				return (T) attributes[0];
			} else {
				return default(T);
			}
        }
		
		public T[] GetAnnotations<T>()
        {
			Type attributeType = typeof(T);
			object[] attributes = this.descriptor.GetCustomAttributes(attributeType, false);
			T[] result = new T[attributes.Length];
			for (int i = 0; i < attributes.Length; i++)
			{
				result[i] = (T) attributes[i];
			}
			return result;
        }
	}
}
