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
 * Last modified: $LastChangedDate: 2013-03-05 17:07:40 -0500 (Tue, 05 Mar 2013) $
 * Revision:      $LastChangedRevision: 6681 $
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Ca.Infoway.Messagebuilder.Xml;
using Ca.Infoway.Messagebuilder.Lang;

namespace Platform.SimpleXml
{
    public abstract class Helpers
    {
        private static Dictionary<Char, String>     encodingMap;
        private static char[]                       encodingCriteria;
        private static IDictionary<String, Boolean> serailizableCache;

        /// <summary>
        /// Static initializer
        /// </summary>
        static Helpers()
        {
            encodingCriteria = new char[] { '\'', '\"', '<', '>', '&' };

            encodingMap = new Dictionary<char, string>();
            encodingMap.Add('\'', "&apos;");
            encodingMap.Add('\"', "&quot;");
            encodingMap.Add('<', "&lt;");
            encodingMap.Add('>', "&gt;");
            encodingMap.Add('&', "&amp;");
        }

        /// <summary>
        /// Returns a camel case version of the specified string
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static String ToCamelCase(String str)
        {
            String res = str;

            if (str.Length > 0 && Char.IsUpper(str[0]))
                res = String.Format("{0}{1}", Char.ToLower(str[0]), str.Substring(1));

            return res;
        }

        /// <summary>
        /// Returns a pascal case version of the specified string
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static String ToPascalCase(String str)
        {
            String res = str;

            if (str.Length > 0 && Char.IsLower(str[0]))
                res = String.Format("{0}{1}", Char.ToUpper(str[0]), str.Substring(1));

            return res;
        }

        /// <summary>
        /// Sets the value of an entity by invoking the setter in the specified reflection object
        /// </summary>
        /// <param name="invoker">Can be FieldInfo, PropertyInfo, or MethodInfo object</param>
        /// <param name="arg">The value to pass to the invoker</param>
        /// <param name="targetType">The value type as expected by the invoker</param>
        /// <param name="onInst">Instance to run the invoker against</param>
        /// <returns></returns>
        public static bool InvokeSet(Object invoker, Object arg, Type targetType, Object onInst)
        {
            bool invoked = true;

            FieldInfo fi = null;
            MethodInfo mi = null;
            PropertyInfo pi = null;

            Object valueToSet = arg;

            if (targetType != arg.GetType()) // Convert the value if necessary
                valueToSet = ChangeType(arg, targetType);

            if (null != (fi = invoker as FieldInfo))
                fi.SetValue(onInst, valueToSet);
            else if (null != (pi = invoker as PropertyInfo))
                pi.SetValue(onInst, valueToSet, null);
            else if (null != (mi = invoker as MethodInfo))
                mi.Invoke(onInst, new object[] { valueToSet });
            else
                invoked = false;

            return invoked;
        }

        /// <summary>
        /// Returns the value of an entity by invoking the getter in the specified reflection object
        /// </summary>
        /// <param name="invoker">Can be FieldInfo, PropertyInfo, or MethodInfo object</param>
        /// <param name="targetType">The value type as expected by the caller</param>
        /// <param name="valueAsType">The value type as returned by the invoker</param>
        /// <param name="onInst">The instance to run the invoker against</param>
        /// <returns></returns>
        public static Object InvokeGet(Object invoker, Type targetType, Type valueAsType, Object onInst)
        {
            FieldInfo fi = null;
            MethodInfo mi = null;
            PropertyInfo pi = null;

            Object value = null;

            if (null != (fi = invoker as FieldInfo))
                value = fi.GetValue(onInst);
            else if (null != (pi = invoker as PropertyInfo))
                value = pi.GetValue(onInst, null);
            else if (null != (mi = invoker as MethodInfo))
                value = mi.Invoke(onInst, null);

            if (null != value && targetType != valueAsType) // Convert the value if necessary
                value = ChangeType(value, targetType);

            return value;
        }

        /// <summary>
        /// Sets the value of field with specified name inside specified instance with specified type
        /// </summary>
        /// <param name="fieldName">Name of field</param>
        /// <param name="fieldValue">Value to set</param>
        /// <param name="contType">Type of containing object</param>
        /// <param name="contInst">Containing object</param>
        /// <returns></returns>
        public static bool SetFieldValue(String fieldName, Object fieldValue, Type contType, Object contInst)
        {
            bool written = false;

            String name = Helpers.ToPascalCase(fieldName);

            PropertyInfo pi = null;

            //
            // We look first for a write property with a pascal case version
            // of the field name (e.g. Documentation).
            //
            if (null != (pi = contType.GetProperty(name)) && pi.CanWrite)
            {
                Object valueToSet = fieldValue;
                Type valueType = fieldValue.GetType();
                if (valueType == typeof(String) && pi.PropertyType != valueType)
                    valueToSet = ChangeType(fieldValue, pi.PropertyType);

                pi.SetValue(contInst, valueToSet, null);
                written = true;
            }
            else
            {
                Console.WriteLine(String.Format("Cannot find {0} write property in {1}",
                    name, contInst.GetType()));
            }

            return written;
        }

        /// <summary>
        /// Sets the value of field referred to by specified mapping, inside specified
        /// instance with specified type
        /// </summary>
        /// <param name="desc">FieldMapping object representing the field</param>
        /// <param name="fieldValue">Value to set</param>
        /// <param name="contType">Type of containing object</param>
        /// <param name="contInst">Containing object</param>
        /// <returns></returns>
        public static bool SetFieldValue(FieldMapping desc, Object fieldValue, Type contType, Object contInst)
        {
            bool written = false;

            if (null == desc.ValueSetter) // We haven't figured this out before?
            {
                PropertyInfo pi = null;
                MethodInfo mi = null;

                //
                // If the field is public, then that's what we'll use to set the value!
                //
                if (desc.FieldInfo.IsPublic)
                {
                    desc.ValueSetter = desc.FieldInfo;
                    desc.ValueSetType = desc.FieldInfo.FieldType;
                }
                else
                {
                    String pascalName = Helpers.ToPascalCase(desc.ObjBindingName);

                    //
                    // Now we look for a write-access property with a pascal case version
                    // of the field name (e.g. Documentation). //! What about overloads?
                    //
                    if (null != (pi = contType.GetProperty(pascalName)) && pi.CanWrite)
                    {
                        desc.ValueSetter = pi;
                        desc.ValueSetType = pi.PropertyType;

                    }
                    else if (null != (mi = contType.GetMethod("set" + pascalName,
                        new Type[] {desc.FieldInfo.FieldType})))
                    {
                        desc.ValueSetter = mi;
                        desc.ValueSetType = desc.FieldInfo.FieldType;
                    }
                    else
                    {
                        Console.WriteLine(String.Format("Cannot find {0} write property in {1}",
                            pascalName, contInst.GetType()));
                    }
                }
            }

            if (null == desc.ValueSetter)
                throw new Exception(String.Format("Unable to find a way to populate value of {0} in {1}",
                    desc.XmlName, null != contInst ? contInst.ToString() : "null"));

            written = InvokeSet(desc.ValueSetter, fieldValue, desc.ValueSetType, contInst);
            return written;
        }

        /// <summary>
        /// Returns the value of field referred to be specified mapping, inside specified
        /// instance with specified type
        /// </summary>
        /// <param name="desc">FieldMapping object representing the field</param>
        /// <param name="contType">Type of containing object</param>
        /// <param name="contInst">Contianing object</param>
        /// <param name="valueAsType"></param>
        /// <returns></returns>
        public static Object GetFieldValue(FieldMapping desc, Type contType, Object contInst, Type valueAsType)
        {
            Object res = null;

            if (null == desc.ValueGetter) // We haven't figured this out before?
            {
                PropertyInfo pi = null;
                MethodInfo mi = null;

                //
                // If the field is public, then that's what we'll use to get the value!
                //
                if (desc.FieldInfo.IsPublic)
                {
                    desc.ValueGetter = desc.FieldInfo;
                    desc.ValueGetType = desc.FieldInfo.FieldType;
                }
                else
                {
                    String pascalName = Helpers.ToPascalCase(desc.ObjBindingName);

                    //
                    // Now we look for a read-access property with a pascal case version
                    // of the field name (e.g. Documentation). //! What about overloads?
                    //
                    if (null != (pi = contType.GetProperty(pascalName)) && pi.CanRead)
                    {
                        desc.ValueGetter = pi;
                        desc.ValueGetType = pi.PropertyType;

                    }
                    else if (null != (mi = contType.GetMethod("get" + pascalName)))
                    {
                        desc.ValueGetter = mi;
                        desc.ValueGetType = desc.FieldInfo.FieldType;
                    }
                    else
                    {
                        Console.WriteLine(String.Format("Cannot find {0} read property in {1}",
                            pascalName, contInst.GetType()));
                    }
                }
            }

            if (null == desc.ValueGetter)
                throw new Exception(String.Format("Unable to find a way to read value of {0} in {1}",
                    desc.ObjBindingName, null != contInst ? contInst.ToString() : "null"));

            res = InvokeGet(desc.ValueGetter, desc.ValueType, valueAsType, contInst);

            if (null != res && !IsTypeDescendantOf(res, valueAsType))
            {
                if (res is Boolean)
                    res = ((Boolean) res) ? "true" : "false";
                else
                    res = ChangeType(res, valueAsType);
            }
            
            return res;
        }

        /// <summary>
        /// Returns whether specified object is descendant of specified type
        /// </summary>
        /// <param name="obj">Object to check</param>
        /// <param name="ancestor">Type to check whether object is descendant of</param>
        /// <returns></returns>
        public static bool IsTypeDescendantOf(Object obj, Type ancestor)
        {
            Type t = obj.GetType();

            if (t == ancestor || t.IsSubclassOf(ancestor) || null != t.GetInterface(ancestor.Name))
                return true;

            return false;
        }

        /// <summary>
        /// Returns a BaseAttribute based attribute given a FieldInfo object
        /// </summary>
        /// <param name="fi"></param>
        /// <returns></returns>
        public static BaseAttribute ExtractAttribute(FieldInfo fi)
        {
            BaseAttribute attr = null;

            Object[] attrs = fi.GetCustomAttributes(false);

            for (int i = 0, length = null != attrs ? attrs.Length : 0; i < length; i++)
            {
                if (!(attrs[i] is BaseAttribute))
                {
                    continue;
                }
                // the .Net version of the Simple Xml parser does not support Namespaces 
                else if (attrs[i] is NamespaceAttribute)
                {
                    continue;
                }

                attr = attrs[i] as BaseAttribute;
            }

            return attr;
        }

        /// <summary>
        /// Extracts XML element name from specified type (taking into account possible [Root]
        /// attribute decoration).
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static String ExtractElementName(Type t)
        {
            String name = Helpers.ToCamelCase(t.Name); // By default, name is the class name

            //
            // [Root] attribute can specify a name.
            //
            object[] typeAttrs = t.GetCustomAttributes(typeof(RootAttribute), false);
            RootAttribute ra = null;
            if (null != typeAttrs && typeAttrs.Length > 0 && null != (ra = typeAttrs[0] as RootAttribute))
                name = null != ra.Name ? ra.Name : name;

            return name;
        }

        /// <summary>
        /// Returns whether the specified type is serializable. Type is considered seializable
        /// if it is decorated with [Root] attribute.
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool IsSerializable(Type t)
        {
            Boolean serializable;

            if (null == serailizableCache)
                serailizableCache = new Dictionary<String, Boolean>();

            if (!serailizableCache.TryGetValue(t.FullName, out serializable))
            {
                object[] attrs = t.GetCustomAttributes(typeof(RootAttribute), false);
                serializable = null != attrs && attrs.Length > 0;

                serailizableCache.Add(t.FullName, serializable);
            }

            return serializable;
        }

        /// <summary>
        /// Returns an XML encoded version of the specified string. Note that if the string does
        /// not contain any of the non XML friendly characters then it will be returned as is.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static String XmlEncode(String str)
        {
            int pos = str.IndexOfAny(encodingCriteria);

            if (pos < 0)
                return str;

            StringBuilder sb = new StringBuilder(str.Length + 30);
           
            int start = 0;
            
            while (pos >= 0)
            {
                String replacement = encodingMap[str[pos]];
                sb.Append(str.Substring(start, pos - start) + replacement);
                start = pos + 1;
                pos = str.IndexOfAny(encodingCriteria, start);
            }

            if (start < str.Length) // Copy the rest if any
                sb.Append(str.Substring(start));

            return sb.ToString();
        }

        /// <summary>
        /// Wrapper for Convert.ChangeType, to get around the issue of the said method not supporting
        /// Nullable types. This method simple extracts the unerlying type if it's Nullable based and
        /// then pass through to Convert.ChangeType.
        /// </summary>
        /// <param name="value">Value to be converted</param>
        /// <param name="conversionType">Type to convert to</param>
        /// <returns></returns>
        public static object ChangeType(object o, Type conversionType)
        {
            if (conversionType == null)
                throw new ArgumentNullException("conversionType");

			if (o == null) {
				return null;
			} else if (conversionType.IsEnum) {
				string s = (string) o;
				return System.Enum.Parse(conversionType, s);
			} else if (conversionType.Equals(typeof(Cardinality))) {
				string s = (string) o;
				return Cardinality.Create(s);
			} else if (conversionType.IsSubclassOf(typeof(EnumPattern))) {
				return EnumPattern.ValueOf<EnumPattern>(conversionType, (string)o);
			} else 
            //
            // If it's not a nullable type, just pass through the parameters to Convert.ChangeType.
            //
            if (conversionType.IsGenericType &&
              conversionType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                if (o == null)
                    return null;

                conversionType =  Nullable.GetUnderlyingType(conversionType);
            }

            return Convert.ChangeType(o, conversionType);
        }
    }
}
