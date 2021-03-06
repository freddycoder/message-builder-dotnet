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


using System.Collections.Generic;
using System.Globalization;

namespace Ca.Infoway.Messagebuilder.Lang {
	
	using ILOG.J2CsMapping.Collections;
	using ILOG.J2CsMapping.Collections.Generics;
	using System;
	using System.Collections;
	//using System.Collections.Generic;
	using System.ComponentModel;
	using System.Reflection;
	using System.Runtime.CompilerServices;
	using System.Runtime.Serialization;
	
	/// <summary>
	/// Abstract superclass for type-safe enums.
	/// </summary>
	///
	[Serializable]
	abstract public class                          Enum : IComparable {
	
		/// <summary>
		/// Required for serialization support.
		/// </summary>
		///
		/// <seealso cref="System.Runtime.Serialization.ISerializable"/>
		private const long serialVersionUID = -487045951170455942L;
	
		// After discussion, the default size for HashMaps is used, as the
		// sizing algorithm changes across the JDK versions
		/// <summary>
		/// An empty <c>Map</c>, as JDK1.2 didn't have an empty map.
		/// </summary>
		///
		private static readonly IDictionary EMPTY_MAP = ILOG.J2CsMapping.Collections.Collections.UnmodifiableMap(new Hashtable(0));
	
		/// <summary>
		/// <c>Map</c>, key of class name, value of <c>Entry</c>.
		/// </summary>
		///
		private static IDictionary cEnumClasses
		// LANG-334: To avoid exposing a mutating map,
		// we copy it each time we add to it. This is cheaper than
		// using a synchronized map since we are almost entirely reads
		= new Hashtable();
	
		/// <summary>
		/// The string representation of the Enum.
		/// </summary>
		///
		private readonly String iName;
	
		/// <summary>
		/// The hashc representation of the Enum.
		/// </summary>
		///
		private readonly int iHashCode;
	
		/// <summary>
		/// The toString representation of the Enum.
		/// </summary>
		///
		protected internal String iToString;

        
		/// <summary>
		/// Enable the iterator to retain the source c order.
		/// </summary>
		///
		private class Entry {
			/// <summary>
			/// Map of Enum name to Enum.
			/// </summary>
			///
			internal readonly IDictionary map;
			/// <summary>
			/// Map of Enum name to Enum.
			/// </summary>
			///
			internal readonly IDictionary unmodifiableMap;
			/// <summary>
			/// List of Enums in source c order.
			/// </summary>
			///
			internal readonly IList list;
			/// <summary>
			/// Map of Enum name to Enum.
			/// </summary>
			///
			internal readonly IList unmodifiableList;
	
			/// <summary>
			/// Restrictive constructor.
			/// </summary>
			///
			protected internal Entry() : base() {
				this.map = new Hashtable();
				this.unmodifiableMap = ILOG.J2CsMapping.Collections.Collections.UnmodifiableMap(map);
				this.list = new ArrayList(25);
				this.unmodifiableList = ILOG.J2CsMapping.Collections.Collections.UnmodifiableList(list);
			}
		}
	
		/// <summary>
		/// Constructor to add a new named item to the enumeration.
		/// </summary>
		///
		/// <param name="name">the name of the enum object,must not be empty or <c>null</c></param>
		/// <exception cref="IllegalArgumentException if the name is <c>null</c>or an empty string"/>
		/// <exception cref="IllegalArgumentException if the getEnumClass() method returnsa null or invalid Class"/>
		protected internal Enum(String name) : base() {
			if (name==null) {
				//allow the enum class to be forcibly loaded. See method forciblyLoadClass.
			} else {
				this.iToString = null;
				Init(name);
				iName = name;
				iHashCode = 7 + EnumClass.GetHashCode() + 3 * name.GetHashCode();
				// cannot create toString here as subclasses may want to include other data
			}
		}
	
		/// <summary>
		/// Initializes the enumeration.
		/// </summary>
		///
		/// <param name="name">the enum name</param>
		/// <exception cref="IllegalArgumentException if the name is null or empty or duplicate"/>
		/// <exception cref="IllegalArgumentException if the enumClass is null or invalid"/>
		private void Init(String name) {

			if (name == null || name.Length == 0) {
				throw new ArgumentException("The Enum name must not be empty or null");
			}
	
			Type enumClass = EnumClass;

			if (enumClass == null) {
				throw new ArgumentException("getEnumClass() must not be null");
			}

			Type cls = GetType();
			bool ok = false;

			while (cls != null && (Object) cls != (Object) typeof(Enum)) {
				if (cls == enumClass) {
					ok = true;
					break;
				}
				cls = cls.BaseType;
			}
			if (ok == false) {
				throw new ArgumentException(
						"getEnumClass() must return a superclass of this class");
			}
	
			Enum.Entry entry;
			 lock (typeof(Enum)) { // LANG-334
						// create entry
						entry = (Enum.Entry) ILOG.J2CsMapping.Collections.Collections.Get(cEnumClasses,enumClass);
						if (entry == null) {
							entry = CreateEntry(enumClass);
							IDictionary myMap = new Hashtable(); // we avoid the (Map) constructor to achieve JDK 1.2 support
							ILOG.J2CsMapping.Collections.Collections.PutAll(myMap,cEnumClasses);
							ILOG.J2CsMapping.Collections.Collections.Put(myMap,enumClass,entry);
							cEnumClasses = myMap;
						}
					}
			if (entry.map.Contains(name)) {
				throw new ArgumentException(
						"The Enum name must be unique, '" + name
								+ "' has already been added");
			}
			ILOG.J2CsMapping.Collections.Collections.Put(entry.map,name,this);
			ILOG.J2CsMapping.Collections.Collections.Add(entry.list,this);
		}
	
		/// <summary>
		/// Handle the deserialization of the class to ensure that multiple
		/// copies are not wastefully created, or illegal enum types created.
		/// </summary>
		///
		/// <returns>the resolved object</returns>
		protected internal Object ReadResolve() {
			Enum.Entry entry = (Enum.Entry) ILOG.J2CsMapping.Collections.Collections.Get(cEnumClasses,EnumClass);
			if (entry == null) {
				return null;
			}
			return ILOG.J2CsMapping.Collections.Collections.Get(entry.map,Name);
		}
	
		//--------------------------------------------------------------------------------
	
		/// <summary>
		/// Gets an <c>Enum</c> object by class and name.
		/// </summary>
		///
		/// <param name="enumClass">the class of the Enum to get, must notbe <c>null</c></param>
		/// <param name="name">the name of the <c>Enum</c> to get,may be <c>null</c></param>
		/// <returns>the enum object, or <c>null</c> if the enum does not exist</returns>
		/// <exception cref="IllegalArgumentException if the enum classis <c>null</c>"/>
		protected static internal Enum GetEnum(Type enumClass, String name) {
			Enum.Entry entry = GetEntry(enumClass);
			if (entry == null) {
				return null;
			}
			return (Enum) ILOG.J2CsMapping.Collections.Collections.Get(entry.map,name);
		}
	
		/// <summary>
		/// Gets the <c>Map</c> of <c>Enum</c> objects by
		/// name using the <c>Enum</c> class.
		/// If the requested class has no enum objects an empty
		/// <c>Map</c> is returned.
		/// </summary>
		///
		/// <param name="enumClass">the class of the <c>Enum</c> to get,must not be <c>null</c></param>
		/// <returns>the enum object Map</returns>
		/// <exception cref="IllegalArgumentException if the enum class is <c>null</c>"/>
		/// <exception cref="IllegalArgumentException if the enum class is not a subclass of Enum"/>
		protected static internal IDictionary GetEnumMap(Type enumClass) {
			Enum.Entry entry = GetEntry(enumClass);
			if (entry == null) {
				return EMPTY_MAP;
			}
			return entry.unmodifiableMap;
		}
	
		/// <summary>
		/// Gets the <c>List</c> of <c>Enum</c> objects using the
		/// <c>Enum</c> class.
		/// The list is in the order that the objects were created (source c order).
		/// If the requested class has no enum objects an empty <c>List</c> is
		/// returned.
		/// </summary>
		///
		/// <param name="enumClass">the class of the <c>Enum</c> to get,must not be <c>null</c></param>
		/// <returns>the enum object Map</returns>
		/// <exception cref="IllegalArgumentException if the enum class is <c>null</c>"/>
		/// <exception cref="IllegalArgumentException if the enum class is not a subclass of Enum"/>
		//protected static internal IList<T> GetEnumList(Type enumClass) {
        protected static internal IList GetEnumList(Type enumClass)
        {
			
            Entry entry = GetEntry(enumClass);

			if (entry == null) {
                return new List<object>();
			}

			return entry.unmodifiableList;
		}
	
		/// <summary>
		/// Gets an <c>Iterator</c> over the <c>Enum</c> objects in
		/// an <c>Enum</c> class.
		/// The <c>Iterator</c> is in the order that the objects were
		/// created (source c order). If the requested class has no enum
		/// objects an empty <c>Iterator</c> is returned.
		/// </summary>
		///
		/// <param name="enumClass">the class of the <c>Enum</c> to get,must not be <c>null</c></param>
		/// <returns>an iterator of the Enum objects</returns>
		/// <exception cref="IllegalArgumentException if the enum class is <c>null</c>"/>
		/// <exception cref="IllegalArgumentException if the enum class is not a subclass of Enum"/>
		protected static internal IIterator Iterator(Type enumClass) {
			return new ILOG.J2CsMapping.Collections.IteratorAdapter(GetEnumList(enumClass).GetEnumerator());
		}
	
		//-----------------------------------------------------------------------
		/// <summary>
		/// Gets an <c>Entry</c> from the map of Enums.
		/// </summary>
		///
		/// <param name="enumClass">the class of the <c>Enum</c> to get</param>
		/// <returns>the enum entry</returns>
		private static Enum.Entry GetEntry(Type enumClass) {
			if (enumClass == null) {
				throw new ArgumentException("The Enum Class must not be null");
			}
			if (typeof(Enum).IsAssignableFrom(enumClass) == false) {
				throw new ArgumentException("The Class must be a subclass of Enum");
			}
			if (!cEnumClasses.Contains(enumClass)) {
				ForciblyLoadClass(enumClass);
			}
			Enum.Entry entry = (Enum.Entry) ILOG.J2CsMapping.Collections.Collections.Get(cEnumClasses,enumClass);
			return entry;
		}
	
		private static void ForciblyLoadClass(Type enumClass) {
			try {

                //invoke first available constructor passing null in all parameters
                
                var constructorInfos = enumClass.GetConstructors(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

			    foreach(var constructor in constructorInfos)
                {
                    constructor.Invoke(new object[constructor.GetParameters().Length]);

                    break;
                }

				ILOG.J2CsMapping.Reflect.Helper.GetNativeType(enumClass.FullName);
                
			} 
            catch (/*TypeLoadException*/ Exception e) 
            {
			}
		}
	
		/// <summary>
		/// Creates an <c>Entry</c> for storing the Enums.
		/// This accounts for subclassed Enums.
		/// </summary>
		///
		/// <param name="enumClass">the class of the <c>Enum</c> to get</param>
		/// <returns>the enum entry</returns>
		private static Enum.Entry CreateEntry(Type enumClass) {
			Enum.Entry entry = new Enum.Entry();
			Type cls = enumClass.BaseType;
			while (cls != null && (Object) cls != (Object) typeof(Enum)) {
				Enum.Entry loopEntry = (Enum.Entry) ILOG.J2CsMapping.Collections.Collections.Get(cEnumClasses,cls);
				if (loopEntry != null) {
					ILOG.J2CsMapping.Collections.Collections.AddAll(loopEntry.list,entry.list);
					ILOG.J2CsMapping.Collections.Collections.PutAll(entry.map,loopEntry.map);
					break; // stop here, as this will already have had superclasses added
				}
				cls = cls.BaseType;
			}
			return entry;
		}
	
		/// <summary>
		/// Retrieve the name of this Enum item, set in the constructor.
		/// </summary>
		///
		/// <returns>the <c>String</c> name of this Enum item</returns>
		public String Name {
		/// <summary>
		/// Retrieve the name of this Enum item, set in the constructor.
		/// </summary>
		///
		/// <returns>the <c>String</c> name of this Enum item</returns>
		  get {
				return iName;
			}
		}
		
	
		/// <summary>
		/// Retrieves the Class of this Enum item, set in the constructor.
		/// This is normally the same as <c>getClass()</c>, but for
		/// advanced Enums may be different. If overridden, it must return a
		/// constant value.
		/// </summary>
		///
		/// <returns>the <c>Class</c> of the enum</returns>
		public Type EnumClass {
		/// <summary>
		/// Retrieves the Class of this Enum item, set in the constructor.
		/// This is normally the same as <c>getClass()</c>, but for
		/// advanced Enums may be different. If overridden, it must return a
		/// constant value.
		/// </summary>
		///
		/// <returns>the <c>Class</c> of the enum</returns>
		  get {
				return GetType();
			}
		}
		
	
		/// <summary>
		/// Tests for equality.
		/// Two Enum objects are considered equal
		/// if they have the same class names and the same names.
		/// Identity is tested for first, so this method usually runs fast.
		/// If the parameter is in a different class loader than this instance,
		/// reflection is used to compare the names.
		/// </summary>
		///
		/// <param name="other">the other object to compare for equality</param>
		/// <returns><c>true</c> if the Enums are equal</returns>
		public sealed override bool Equals(Object other) {
			if (other == (Object) this) {
				return true;
			} else if (other == null) {
				return false;
			} else if ((Object) other.GetType() == (Object) this.GetType()) {
				// Ok to do a class cast to Enum here since the test above
				// guarantee both
				// classes are in the same class loader.
				return iName.Equals(((Enum) other).iName);
			} else {
				// This and other are in different class loaders, we must check indirectly
				if (other.GetType().FullName.Equals(this.GetType().FullName) == false) {
					return false;
				}
				return iName.Equals(GetNameInOtherClassLoader(other));
			}
		}
	
		/// <summary>
		/// Returns a suitable hashCode for the enumeration.
		/// </summary>
		///
		/// <returns>a hashc based on the name</returns>
		public sealed override int GetHashCode() {
			return iHashCode;
		}
	
		/// <summary>
		/// Tests for order.
		/// The default ordering is alphabetic by name, but this
		/// can be overridden by subclasses.
		/// If the parameter is in a different class loader than this instance,
		/// reflection is used to compare the names.
		/// </summary>
		///
		/// <param name="other">the other object to compare to</param>
		/// <returns>-ve if this is less than the other object, +ve if greaterthan, <c>0</c> of equal</returns>
		/// <exception cref="ClassCastException if other is not an Enum"/>
		/// <exception cref="NullPointerException if other is <c>null</c>"/>
		public virtual int CompareTo(Object other) {
			if (other == (Object) this) {
				return 0;
			}
			if ((Object) other.GetType() != (Object) this.GetType()) {
				if (other.GetType().FullName.Equals(this.GetType().FullName)) {
					return String.CompareOrdinal(iName,GetNameInOtherClassLoader(other));
				}
				throw new InvalidCastException("Different enum class '"
						+ Enum.GetShortClassName(other.GetType()) + "'");
			}
			return String.CompareOrdinal(iName,((Enum) other).iName);
		}
	
		/// <summary>
		/// Use reflection to return an objects class name.
		/// </summary>
		///
		/// <param name="other">The object to determine the class name for</param>
		/// <returns>The class name</returns>
		private String GetNameInOtherClassLoader(Object other) {
			try {
				MethodInfo mth = ILOG.J2CsMapping.Reflect.Helper.GetMethod(other.GetType(),"getName",null);
				String name = (String) ILOG.J2CsMapping.Reflect.Helper.Invoke(mth,other,null);
				return name;
			} catch (AmbiguousMatchException e) {
				// ignore - should never happen
			} catch (MemberAccessException e_0) {
				// ignore - should never happen
			} catch (TargetInvocationException e_1) {
				// ignore - should never happen
			}
			throw new InvalidOperationException("This should not happen");
		}
	
		/// <summary>
		/// Human readable description of this Enum item.
		/// </summary>
		///
		/// <returns>String in the form <c>type[name]</c>, for example:<c>Color[Red]</c>. Note that the package name is stripped fromthe type name.</returns>
		public override  System.String ToString() {
			if (iToString == null) {
				String shortName = Enum.GetShortClassName(EnumClass);
				iToString = shortName + "[" + Name + "]";
			}
			return iToString;
		}
	
		public const char PACKAGE_SEPARATOR_CHAR = '.';
		public const char INNER_CLASS_SEPARATOR_CHAR = '$';
		private static readonly String EMPTY_STRING = null;
	
		/// <summary>
		/// Gets the class name minus the package name from a <c>Class</c>.
		/// </summary>
		///
		/// <param name="cls">the class to get the short name for.</param>
		/// <returns>the class name without the package name or an empty string</returns>
		public static String GetShortClassName(Type cls) {
			if (cls == null) {
				return EMPTY_STRING;
			}
			return GetShortClassName(cls.FullName);
		}
	
		/// <summary>
		/// Gets the class name minus the package name from a String.
		/// The string passed in is assumed to be a class name - it is not checked.
		/// </summary>
		///
		/// <param name="className">the className to get the short name for</param>
		/// <returns>the class name of the class without the package name or an empty string</returns>
		public static String GetShortClassName(String className) {
			if (className == null) {
				return EMPTY_STRING;
			}
			if (className.Length == 0) {
				return EMPTY_STRING;
			}
	
			int lastDotIdx = className.LastIndexOf(PACKAGE_SEPARATOR_CHAR);
			int innerIdx = className.IndexOf(INNER_CLASS_SEPARATOR_CHAR,
					(lastDotIdx == -1) ? 0 : lastDotIdx + 1);
			String xout = className.Substring(lastDotIdx + 1);
			if (innerIdx != -1) {
				xout = xout.Replace(INNER_CLASS_SEPARATOR_CHAR,
						PACKAGE_SEPARATOR_CHAR);
			}
			return xout;
		}
	
	}
}
