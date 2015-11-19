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
	/// Periodic Interval of Time (PIVL) specializes SXCM. Back by   datatype PeriodicIntervalTime.
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-PIVL
	/// Definition: An interval of time that recurs periodically. Periodic intervals
	/// have two properties, phase and period. The phase specifies the "interval
	/// prototype" that is repeated every period.
	/// </summary>
	///
	public class PIVLImpl : ANYImpl<PeriodicIntervalTime>, PIVL {
	
		private const long serialVersionUID = 159190145107996467L;
	
		/// <summary>
		/// Constructs an empty PIVL.
		/// </summary>
		///
		public PIVLImpl() : this((PeriodicIntervalTime)null) {
		}
	
		/// <summary>
		/// Constructs a PIVL with the supplied value.
		/// </summary>
		///
		/// <param name="defaultValue">initial value</param>
		public PIVLImpl(PeriodicIntervalTime defaultValue) : base(typeof(PeriodicIntervalTime), defaultValue, null, Ca.Infoway.Messagebuilder.Datatype.StandardDataType.PIVL_TS_DATETIME) {
		}
	
		/// <summary>
		/// Constructs a PIVL with the supplied null flavor.
		/// </summary>
		///
		/// <param name="nullFlavor">a null flavor</param>
		public PIVLImpl(NullFlavor nullFlavor) : base(typeof(PeriodicIntervalTime), null, nullFlavor, Ca.Infoway.Messagebuilder.Datatype.StandardDataType.PIVL_TS_DATETIME) {
		}
	
	}
}
