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
namespace Ca.Infoway.Messagebuilder.Datatype {
	
	using Ca.Infoway.Messagebuilder.Datatype;
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
	public interface BareANY : NullFlavorSupport {
        Object BareValue
        {
            get;
            set;
        }
	
		/// <summary>
		/// Sets this ANY's datatype.
		/// </summary>
		///
		/// <param name="dataType">an hl7 datatype</param>
		StandardDataType DataType {
		/// <summary>
		/// Represents the fact that every data value implicitly carries information about its own data type. 
		/// Thus, given a data value one can inquire about its data type.
		/// </summary>
		///
		/// <returns>the underlying enum datatype</returns>
		  get;
		/// <summary>
		/// Sets this ANY's datatype.
		/// </summary>
		///
		/// <param name="dataType">an hl7 datatype</param>
		  set;
		}
	}
}
