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
	/// Set Component (SXCM) HL7 datatype. Backed by the   datatype SetComponent. 
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-SXCM
	/// Definition: An ITS-defined generic type extension for the base data type of a
	/// set, representing a component of a general set over a discrete or continuous
	/// value domain. Its use is mainly for continuous value domains. Discrete
	/// (enumerable) set components are the individual elements of the base data
	/// type.
	/// </summary>
	///
	/// <param name="T"> the underlying   datatype</param>
	public class SXCMImpl<T> : ANYImpl<SetComponent<T>>, SXCM<T> {
	
		/// <summary>
		/// Constructs an empty SXCM.
		/// </summary>
		///
		/* @SuppressWarnings("unchecked")*/
		public SXCMImpl() : this((SetComponent<T>)null) {
		}
	
		/// <summary>
		/// Constructs an SXCM using the supplied value.
		/// </summary>
		///
		/// <param name="defaultValue">the initial value</param>
		public SXCMImpl(SetComponent<T> defaultValue) : base(typeof(SetComponent<T>), defaultValue, null, Ca.Infoway.Messagebuilder.Datatype.StandardDataType.SXCM) {
		}
	
		/// <summary>
		/// Constructs an SXCM with the supplied null flavor.
		/// </summary>
		///
		/// <param name="nullFlavor">a null flavor</param>
		public SXCMImpl(NullFlavor nullFlavor) : base(typeof(SetComponent<T>), null, nullFlavor, Ca.Infoway.Messagebuilder.Datatype.StandardDataType.SXCM) {
		}
	
	}
}
