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


namespace Ca.Infoway.Messagebuilder.Lang {
	
	using ILOG.J2CsMapping.Collections;
	using ILOG.J2CsMapping.Collections.Generics;
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Runtime.CompilerServices;
	
	/// <summary>
	/// Utility class for accessing and manipulating {@link Enum}s.
	/// </summary>
	///
	/// <seealso cref="Enum"/>
	/// <seealso cref="ValuedEnum"/>
	internal class EnumUtils {
	
		/// <summary>
		/// Public constructor. This class should not normally be instantiated.
		/// </summary>
		///
		public EnumUtils() : base() {
		}
	
		/// <summary>
		/// Gets an <c>Enum</c> object by class and name.
		/// </summary>
		///
		/// <param name="enumClass">the class of the <c>Enum</c> to get</param>
		/// <param name="name">the name of the Enum to get, may be <c>null</c></param>
		/// <returns>the enum object</returns>
		/// <exception cref="IllegalArgumentException if the enum class is <c>null</c>"/>
		public static Enum GetEnum(Type enumClass, String name) {
			return Ca.Infoway.Messagebuilder.Lang.Enum.GetEnum(enumClass, name);
		}
	
		/// <summary>
		/// Gets the <c>Map</c> of <c>Enum</c> objects by
		/// name using the <c>Enum</c> class.
		/// If the requested class has no enum objects an empty
		/// <c>Map</c> is returned. The <c>Map</c> is unmodifiable.
		/// </summary>
		///
		/// <param name="enumClass">the class of the <c>Enum</c> to get</param>
		/// <returns>the enum object Map</returns>
		/// <exception cref="IllegalArgumentException if the enum class is <c>null</c>"/>
		/// <exception cref="IllegalArgumentException if the enum class is not a subclassof <c>Enum</c>"/>
		public static IDictionary GetEnumMap(Type enumClass) {
			return Ca.Infoway.Messagebuilder.Lang.Enum.GetEnumMap(enumClass);
		}
	
		/// <summary>
		/// Gets the <c>List</c> of <c>Enum</c> objects using
		/// the <c>Enum</c> class.
		/// The list is in the order that the objects were created
		/// (source c order).
		/// If the requested class has no enum objects an empty
		/// <c>List</c> is returned. The <c>List</c> is unmodifiable.
		/// </summary>
		///
		/// <param name="enumClass">the class of the Enum to get</param>
		/// <returns>the enum object Map</returns>
		/// <exception cref="IllegalArgumentException if the enum class is <c>null</c>"/>
		/// <exception cref="IllegalArgumentException if the enum class is not a subclassof <c>Enum</c>"/>
		public static IList GetEnumList(Type enumClass) {
			return Ca.Infoway.Messagebuilder.Lang.Enum.GetEnumList(enumClass);
		}
	
		/// <summary>
		/// Gets an <c>Iterator</c> over the <c>Enum</c> objects
		/// in an <c>Enum</c> class.
		/// The iterator is in the order that the objects were created
		/// (source c order).
		/// If the requested class has no enum objects an empty
		/// <c>Iterator</c> is returned. The <c>Iterator</c>
		/// is unmodifiable.
		/// </summary>
		///
		/// <param name="enumClass">the class of the <c>Enum</c> to get</param>
		/// <returns>an <c>Iterator</c> of the <c>Enum</c> objects</returns>
		/// <exception cref="IllegalArgumentException if the enum class is <c>null</c>"/>
		/// <exception cref="IllegalArgumentException if the enum class is not a subclass of <c>Enum</c>"/>
		public static IIterator Iterator(Type enumClass) {
			return new ILOG.J2CsMapping.Collections.IteratorAdapter(Ca.Infoway.Messagebuilder.Lang.Enum.GetEnumList(enumClass).GetEnumerator());
		}
	
	}
}
