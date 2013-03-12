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
	/// Uncertain Range. URG HL7 datatype backed by the UncertainRange datatype.
	/// This data type is used when a continuous range needs to be expressed. 
	/// For URG(TS.DATE) This data type is used when an occurrence is tied to a specific date, 
	/// but the actual date is not known, merely the range of dates within which the date falls. 
	/// This differs from IVL(TS.DATE) in that it refers to a single occurrence rather than a period 
	/// covering multiple days.
	/// For URG(PQ.x): This is used to express a single quantity whose specific value is not known, but 
	/// whose upper and lower bounds are known. The URG data type already places implicit constraints on 
	/// probability. Outside the range, probability is 0, within the range, probability is unknown. PQ.x 
	/// implies any of the PQ.x data types in the specification (e.g. PQ.LAB, PQ.DISTANCE), not the PQ data type by itself.                             
	/// </summary>
	///
	/// <param name="T"> any quantity(QTY)-based HL7 datatype</param>
	/// <param name="V"> the underlying quantity datatype</param>
	public class URGImpl<T, V> : IVLImpl<T, UncertainRange<V>>
		, URG<T, V>  where T : QTY<V> {
	
		private const long serialVersionUID = 4137576211765438292L;
	
		/// <summary>
		/// Constructs an empty uncertain range HL7 datatype.
		/// </summary>
		///
		public URGImpl() : this((UncertainRange<V>)null) {
		}
	
		/// <summary>
		/// Constructs an uncertain range HL7 datatype using a given UncertainRange datatype.
		/// </summary>
		///
		/// <param name="defaultValue">the starting value for the uncertain range</param>
		public URGImpl(UncertainRange<V> defaultValue) : base(typeof(UncertainRange<V>), defaultValue, null, Ca.Infoway.Messagebuilder.Datatype.StandardDataType.URG) {
		}
	
		/// <summary>
		/// Constructs a null uncertain range HL7 datatype using a given null flavor.
		/// </summary>
		///
		/// <param name="nullFlavor">the null flavor the uncertain range HL7 datatype should start with.</param>
		public URGImpl(NullFlavor nullFlavor) : base(typeof(UncertainRange<V>), null, nullFlavor, Ca.Infoway.Messagebuilder.Datatype.StandardDataType.URG) {
		}
	
	}
}
