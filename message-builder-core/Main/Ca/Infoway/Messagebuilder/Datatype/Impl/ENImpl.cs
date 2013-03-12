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
	
	using Ca.Infoway.Messagebuilder.Datatype;
	using Ca.Infoway.Messagebuilder.Datatype.Lang;
	using Ca.Infoway.Messagebuilder.Domainvalue;
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Runtime.CompilerServices;
	
	/// <summary>
	/// Super class for HL7 name-based datatypes. Backed by a   datatype that must be an extension of EntityName.
	/// </summary>
	///
	/// <param name="V"> the underlying   entity name type</param>
	public class ENImpl<V> : ANYImpl<V>, EN<V>  where V : EntityName {
	
		private const long serialVersionUID = -7224412497518261363L;
	
		/// <summary>
		/// Constructs an empty EN.
		/// </summary>
		///
		public ENImpl() : this((V)null) {
		}
	
		/// <summary>
		/// Constructs an EN with the given initial value.
		/// </summary>
		///
		/// <param name="defaultValue">the initial value</param>
		public ENImpl(V defaultValue) : this(typeof(EntityName), defaultValue, null, Ca.Infoway.Messagebuilder.Datatype.StandardDataType.EN) {
		}
	
		/// <summary>
		/// Constructs an EN with the given null flavor.
		/// </summary>
		///
		/// <param name="nullFlavor">a null flavor</param>
		public ENImpl(NullFlavor nullFlavor) : this(typeof(EntityName),  default(V), nullFlavor, Ca.Infoway.Messagebuilder.Datatype.StandardDataType.EN) {
		}
	
		/// <summary>
		/// Constructs an EN given the supplied parameters.
		/// </summary>
		///
		/// <param name="rawType">the underlying   datatype</param>
		/// <param name="value">an initial value (based on EntityName)</param>
		/// <param name="nullFlavor">a null flavor</param>
		/// <param name="dataType">a data type enum</param>
		public ENImpl(Type rawType, V value_ren, NullFlavor nullFlavor,
				StandardDataType dataType) : base(rawType, value_ren, nullFlavor, dataType) {
		}
	}
}
