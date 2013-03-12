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
 * Last modified: $LastChangedDate: 2011-09-26 09:35:09 -0400 (Mon, 26 Sep 2011) $
 * Revision:      $LastChangedRevision: 3016 $
 */

/// ---------------------------------------------------------------------------------------------------
///  This file was automatically generated by J2CS Translator (http://j2cstranslator.sourceforge.net/). 
///  Version 1.0.0                                                                                      
/// ---------------------------------------------------------------------------------------------------
 
namespace Ca.Infoway.Messagebuilder.Datatype.Lang {

    using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
	using Ca.Infoway.Messagebuilder;
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Runtime.CompilerServices;
	
	/// <summary>
	/// Periodic Interval of Time (PIVL) specializes SXCM. Backed by a   Date.
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-PIVL
	/// Definition: An interval of time that recurs periodically. Periodic intervals
	/// have two properties, phase and period. The phase specifies the "interval
	/// prototype" that is repeated every period.
	/// </summary>
	///
	public class PeriodicIntervalTime : SetComponent<Ca.Infoway.Messagebuilder.PlatformDate> {
	
		private readonly DateDiff period;
		private readonly Interval<Ca.Infoway.Messagebuilder.PlatformDate> phase;
		private readonly Representation representation;
		private readonly Int32? repetitions;
		private readonly PhysicalQuantity quantity;
	
		protected PeriodicIntervalTime(DateDiff period_0, Interval<Ca.Infoway.Messagebuilder.PlatformDate> phase_1,
				Int32? repetitions_2, PhysicalQuantity quantity_3,
				Representation representation_4) {
			this.period = period_0;
			this.phase = phase_1;
			this.repetitions = repetitions_2;
			this.quantity = quantity_3;
			this.representation = representation_4;
		}
	
		/// <summary>
		/// Constructs a PeriodicIntervalTime using the supplied parameters.
		/// </summary>
		///
		/// <param name="period_0">DateDiff period</param>
		/// <returns>the constructed PeriodicIntervalTime</returns>
		public static PeriodicIntervalTime CreatePeriod(DateDiff period_0) {
			Ca.Infoway.Messagebuilder.Validate.NotNull(period_0);
			return new PeriodicIntervalTime(period_0, null, null, null, Representation.PERIOD);
		}
	
		/// <summary>
		/// Constructs a PeriodicIntervalTime using the supplied parameters.
		/// </summary>
		///
		/// <param name="phase_0">phase Interval</param>
		/// <returns>the constructed PeriodicIntervalTime</returns>
		public static PeriodicIntervalTime CreatePhase(Interval<Ca.Infoway.Messagebuilder.PlatformDate> phase_0) {
			Ca.Infoway.Messagebuilder.Validate.NotNull(phase_0);
			return new PeriodicIntervalTime(null, phase_0, null, null, Representation.PHASE);
		}
	
		/// <summary>
		/// Constructs a PeriodicIntervalTime using the supplied parameters.
		/// </summary>
		///
		/// <param name="period_0">DateDiff period</param>
		/// <param name="phase_1">phase Interval</param>
		/// <returns>the constructed PeriodicIntervalTime</returns>
		public static PeriodicIntervalTime CreatePeriodPhase(DateDiff period_0,
				Interval<Ca.Infoway.Messagebuilder.PlatformDate> phase_1) {
			Ca.Infoway.Messagebuilder.Validate.NotNull(phase_1);
			return new PeriodicIntervalTime(period_0, phase_1, null, null, Representation.PERIOD_PHASE);
		}
	
		/// <summary>
		/// Constructs a PeriodicIntervalTime using the supplied parameters.
		/// </summary>
		///
		/// <param name="repetitions_0">number of repetitions</param>
		/// <param name="quantity_1">a physical quantity</param>
		/// <returns>the constructed PeriodicIntervalTime</returns>
		public static PeriodicIntervalTime CreateFrequency(Int32? repetitions_0,
				PhysicalQuantity quantity_1) {
			return new PeriodicIntervalTime(null, null, repetitions_0, quantity_1,
					Representation.FREQUENCY);
		}
	
		/// <summary>
		/// Gets the period.
		/// </summary>
		///
		/// <returns>the period</returns>
		public DateDiff Period {
		/// <summary>
		/// Gets the period.
		/// </summary>
		///
		/// <returns>the period</returns>
		  get {
				return this.period;
			}
		}
		
	
		/// <summary>
		/// Returns the phase.
		/// </summary>
		///
		/// <returns>the phase</returns>
		public Interval<Ca.Infoway.Messagebuilder.PlatformDate> Phase {
		/// <summary>
		/// Returns the phase.
		/// </summary>
		///
		/// <returns>the phase</returns>
		  get {
				return this.phase;
			}
		}
		
	
		/// <summary>
		/// Returns the representation.
		/// </summary>
		///
		/// <returns>the representation.</returns>
		public Representation Representation {
		/// <summary>
		/// Returns the representation.
		/// </summary>
		///
		/// <returns>the representation.</returns>
		  get {
				return this.representation;
			}
		}
		
	
		/// <summary>
		/// Returns the number of repetitions.
		/// </summary>
		///
		/// <returns>the number of repetitions</returns>
		public Int32? Repetitions {
		/// <summary>
		/// Returns the number of repetitions.
		/// </summary>
		///
		/// <returns>the number of repetitions</returns>
		  get {
				return this.repetitions;
			}
		}
		
	
		/// <summary>
		/// Returns the physical quantity. 
		/// </summary>
		///
		/// <returns>the quantity</returns>
		public PhysicalQuantity Quantity {
		/// <summary>
		/// Returns the physical quantity. 
		/// </summary>
		///
		/// <returns>the quantity</returns>
		  get {
				return this.quantity;
			}
		}
		
	}
}
