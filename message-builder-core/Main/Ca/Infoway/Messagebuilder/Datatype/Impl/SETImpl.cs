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
 * Last modified: $LastChangedDate: 2011-09-21 11:11:24 -0400 (Wed, 21 Sep 2011) $
 * Revision:      $LastChangedRevision: 3001 $
 */

/// ---------------------------------------------------------------------------------------------------
///  This file was automatically generated by J2CS Translator (http://j2cstranslator.sourceforge.net/). 
///  Version 1.0.0                                                                                      
/// ---------------------------------------------------------------------------------------------------
 
namespace Ca.Infoway.Messagebuilder.Datatype.Impl {
	
	using Ca.Infoway.Messagebuilder;
	using Ca.Infoway.Messagebuilder.Datatype;
	using Ca.Infoway.Messagebuilder.Domainvalue;
	using Ca.Infoway.Messagebuilder.Platform;
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Runtime.CompilerServices;
	
	/// <summary>
	/// HL7 datatype SET. Backed by a   Set.
	/// Used when multiple repetitions are allowed, order is irrelevant and duplicates are prohibited.
	/// </summary>
	///
	/// <param name="T"> the HL7 datatype held by the SET</param>
	/// <param name="V"> the underlying   datatype held by the underlying   Set</param>
	public class SETImpl<T, V> : ANYImpl<ICollection<T>>, BareCollection, CollectionHelper, SET<T, V>  where T : ANY<V> {
	
		private const long serialVersionUID = -6170605246120245157L;
	
		private readonly Type hl7Class;
	
		/// <summary>
		/// Builds an HL7 SET from an existing   Set.
		/// </summary>
		///
		/// <param name="T"> the HL7 datatype held by the SET</param>
		/// <param name="V"> the underlying   datatype held by the underlying   Set</param>
		/// <param name="rawElementType">the class of the underlying   datatype held by the set</param>
		/// <param name="rawElements">a set of   datatype values</param>
		/// <returns>the constructed SET</returns>
		/* @SuppressWarnings("unchecked")*/
		public static SET<TS, VS> Create<TS,VS>(Type rawElementType, ICollection<VS> rawElements)  where TS : ANY<VS> {
			SETImpl<TS, VS> list = new SETImpl<TS, VS>(rawElementType);
			list.RawSet().AddAll(rawElements);
			return list;
		}
	
		/// <summary>
		/// Constructs an empty SET of the given HL7 datatype.
		/// </summary>
		///
		/// <param name="hl7Class_0">the HL7 datatype class</param>
		/* @SuppressWarnings("unchecked")*/
		public SETImpl(Type hl7Class_0) : this(hl7Class_0, new LinkedSet<T>()) {
		}
	
		/// <summary>
		/// Constructs a SET of the given HL7 datatype with a null flavor.
		/// </summary>
		///
		/// <param name="hl7Class_0">the HL7 datatype class</param>
		/// <param name="nullFlavor">a null flavor</param>
		/* @SuppressWarnings("unchecked")*/
		public SETImpl(Type hl7Class_0, NullFlavor nullFlavor) : this(hl7Class_0, new HashSet<T>()) {
			NullFlavor = nullFlavor;
		}
	
		/// <summary>
		/// Constructs a SET of the given HL7 datatype with the supplied initial value.
		/// </summary>
		///
		/// <param name="hl7Class_0">the HL7 datatype class</param>
		/// <param name="defaultValue">the initial value</param>
		/* @SuppressWarnings("unchecked")*/
		public SETImpl(Type hl7Class_0, ICollection<T> defaultValue) : base(typeof(ICollection), defaultValue, null, Ca.Infoway.Messagebuilder.Datatype.StandardDataType.SET) {
			this.hl7Class = hl7Class_0;
		}
	
		/// <summary>
		/// Returns an empty Set.
		/// </summary>
		///
		/// <returns>an empty Set</returns>
		protected internal override ICollection<T> NullValue {
		/// <summary>
		/// Returns an empty Set.
		/// </summary>
		///
		/// <returns>an empty Set</returns>
		  get {
				return new HashSet<T>();
			}
		}
		
	
		/// <summary>
		/// Returns the underlying   Set containing values in the underlying   datatype.
		/// </summary>
		///
		/// <returns>the underlying   Set containing values in the underlying   datatype</returns>
		public virtual ICollection<V> RawSet() {
			return new RawSetWrapper<T, V>(Value, Hl7Class);
		}
	
		public virtual ICollection<U> RawSet<U>() where U : V {
			return new RawSetWrapper<T, U>(Value, Hl7Class);
		}
		
		private Type Hl7Class {
		  get {
				return this.hl7Class;
			}
		}
		
	
		/// <summary>
		/// Returns the underlying   Collection containing values in the underlying   datatype.
		/// </summary>
		///
		/// <returns>the underlying   Collection containing values in the underlying   datatype</returns>
		public virtual ICollection<object> RawCollection() {
            return new RawSetWrapper<T, object>(Value, Hl7Class);
		}
	
		/// <summary>
		/// Returns the HL7 datatype class.
		/// </summary>
		///
		/// <returns>the HL7 datatype class.</returns>
		public virtual Type ElementType {
		/// <summary>
		/// Returns the HL7 datatype class.
		/// </summary>
		///
		/// <returns>the HL7 datatype class.</returns>
		  get {
				return this.hl7Class;
			}
		}
		
		public void Add(BareANY any) {
			Value.Add((T) any);
		}
		
		public ICollection<BareANY> GetBareCollectionValue() {
			ICollection<BareANY> result = new List<BareANY>();
			foreach (T t in Value) {
				result.Add(t);
			}
			return result;
		}
	
	}
}
