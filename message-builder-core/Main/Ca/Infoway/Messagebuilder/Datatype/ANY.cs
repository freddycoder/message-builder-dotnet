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
 
namespace Ca.Infoway.Messagebuilder.Datatype {
	
	using Ca.Infoway.Messagebuilder.Datatype.Nullflavor;
	using Ca.Infoway.Messagebuilder.Domainvalue;
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Runtime.CompilerServices;
	
	/// <summary>
	/// ANY Hl7 datatype.
	/// Defines the basic properties of every data value.
	/// This is an abstract type, meaning that no value can be just a data value
	/// without belonging to any concrete type. Every concrete type is a
	/// specialization of this general abstract DataValue type.
	/// </summary>
	///
	/// <param name="V"> the underlying   datatype</param>
	public interface ANY<V> : BareANY, NullFlavorSupport {
	
		/// <summary>
		/// Sets a value on the ANY object.
		/// </summary>
		///
		/// <param name="value">the value to set on this ANY object</param>
		V Value {
		/// <summary>
		/// Returns the value.
		/// </summary>
		///
		/// <returns>the underlying   datatype value</returns>
		  get;
		/// <summary>
		/// Sets a value on the ANY object.
		/// </summary>
		///
		/// <param name="value">the value to set on this ANY object</param>
		  set;
		}
		
	
		/// <summary>
		/// Indicates that a value is a non-exceptional value of the data type.
		/// When a property, RIM attribute, or message field is called mandatory this means 
		/// that any non-NULL value of the type to which the property belongs has a non-NULL 
		/// value for that property, in other words, a field may not be NULL, providing that 
		/// its container (object, segment, etc.) is to have a non-NULL value.
		/// </summary>
		///
		/// <returns>whether this object has no null flavor</returns>
		bool NonNull();
	
		/// <summary>
		/// Sets a null flavor on the object.
		/// </summary>
		///
		/// <param name="nullFlavor">the null flavor to set</param>
		new NullFlavor NullFlavor {
		/// <summary>
		/// If a value is an exceptional value (NULL-value), this specifies in what way and why proper information is missing.
		/// The null flavors are a general domain extension of all normal data types. Note the distinction between 
		/// value domain of any data type and the vocabulary domain of cd data types. A vocabulary domain is a 
		/// value domain for cd values, but not all value domains are vocabulary domains.
		/// The null flavor "other" is used whenever the actual value is not in the required value domain, 
		/// this may be, for example, when the value exceeds some constraints that are defined too 
		/// restrictive (e.g., age less than 100 years.)
		/// NOTE: NULL-flavors are applicable to any property of a data value or a higher-level object attribute. 
		/// Where the difference of null flavors is not significant, ITS are not required to represent them. If nothing 
		/// else is noted in this specification, ITS need not represent general NULL-flavors for data-value properties.
		/// Some of these null flavors are associated with named properties that can be used as simple predicates 
		/// for all data values. This is done to simplify the formulation of invariants in the remainder of this specification.
		/// Remember the difference between semantic properties and representational "components" of data values. 
		/// An ITS must only represent those components that are needed to infer the semantic properties.
		/// The null-flavor predicates nonNull, isNull, notApplicable, unknown, and other can all be 
		/// inferred from the nullFlavor property.
		/// </summary>
		///
		/// <returns>the null flavor</returns>
		  get;
		/// <summary>
		/// Sets a null flavor on the object.
		/// </summary>
		///
		/// <param name="nullFlavor">the null flavor to set</param>
		  set;
		}
		
	
		/// <summary>
		/// Indicates that a value is an exceptional value, or a NULL-value. A null value means that 
		/// the information does not exist, is not available or cannot be expressed in the data type's 
		/// normal value set.
		/// Every data element has either a proper value or it is considered NULL. If (and only if) 
		/// it is NULL, the isNull provides more detail as to in what way or why no proper value is supplied.
		/// </summary>
		///
		/// <returns>whether this object has a null flavor</returns>
		bool Null {
		/// <summary>
		/// Indicates that a value is an exceptional value, or a NULL-value. A null value means that 
		/// the information does not exist, is not available or cannot be expressed in the data type's 
		/// normal value set.
		/// Every data element has either a proper value or it is considered NULL. If (and only if) 
		/// it is NULL, the isNull provides more detail as to in what way or why no proper value is supplied.
		/// </summary>
		///
		/// <returns>whether this object has a null flavor</returns>
		  get;
		}
		
	
		/// <summary>
		/// A predicate indicating that this exceptional value is of nullFlavor not-applicable (NA), i.e.,  
		/// that a proper value is not meaningful in the given context.
		/// </summary>
		///
		/// <returns>whether this ANY object has a null flavor of "Not applicable"</returns>
		bool NotApplicable();
	
		/// <summary>
		/// A predicate indicating that this exceptional value is of nullFlavor unknown (UNK).
		/// </summary>
		///
		/// <returns>whether this ANY object has a null flavor of "unknown"</returns>
		bool Unknown();
	
		/// <summary>
		/// A predicate indicating that this exceptional value is of nullFlavor other (OTH), i.e., that the required 
		/// value domain does not contain the appropriate value.
		/// </summary>
		///
		/// <returns>whether this ANY object has a null flavor of "other"</returns>
		bool Other();
	
		/// <summary>
		/// Shallow clone.
		/// </summary>
		///
		/// <returns>a clone of this object</returns>
		/// <exception cref="CloneNotSupportedException if cloning encountered problems"/>
		new ANY<V> Clone();
	
	
	}
}
