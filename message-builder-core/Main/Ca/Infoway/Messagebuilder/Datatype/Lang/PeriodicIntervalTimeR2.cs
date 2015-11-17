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
 * Last modified: $LastChangedDate: 2011-05-04 15:47:15 -0400 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */

namespace Ca.Infoway.Messagebuilder.Datatype.Lang {
    using System;
    using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;

    /// <summary>
    /// Periodic Interval of Time (PIVL_TS; R2)
    /// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-PIVL
    /// Definition: An interval of time that recurs periodically. Periodic intervals
    /// have two properties, phase and period. The phase specifies the "interval
    /// prototype" that is repeated every period.
    /// </summary>
    [Serializable]
    public class PeriodicIntervalTimeR2 : MbDate {
        public Interval<PlatformDate> Phase {
            get;
            set;
        }
        public PhysicalQuantity Period {
            get;
            set;
        }
        public CalendarCycle Alignment {
            get;
            set;
        }
        public Boolean? InstitutionSpecified {
            get;
            set;
        }
        public Int32? FrequencyRepetitions {
            get;
            set;
        }
        public PhysicalQuantity FrequencyQuantity {
            get;
            set;
        }
        public PeriodicIntervalTimeR2(Interval<PlatformDate> phase, PhysicalQuantity period) :
            this(phase, period, null, null, null, null) {
        }
        public PeriodicIntervalTimeR2(Int32? frequencyRepetitions, PhysicalQuantity frequencyQuantity) :
            this(null, null, null, null, frequencyRepetitions, frequencyQuantity) {
        }
        public PeriodicIntervalTimeR2(Interval<PlatformDate> phase, PhysicalQuantity period, CalendarCycle alignment, 
            Boolean? institutionSpecified, Int32? frequencyRepetitions, PhysicalQuantity frequencyQuantity) {
                Phase = phase;
                Period = period;
                Alignment = alignment;
                InstitutionSpecified = institutionSpecified;
                FrequencyRepetitions = frequencyRepetitions;
                FrequencyQuantity = frequencyQuantity;
        }
        public static PeriodicIntervalTimeR2 CreateFromPivlR1(PeriodicIntervalTime pivlR1) {
            DateDiff period = pivlR1.Period;
            PhysicalQuantity periodPq = (period != null ? period.ValueAsPhysicalQuantity : null);
            Interval<PlatformDate> phase = pivlR1.Phase;
            PhysicalQuantity quantity = pivlR1.Quantity;
            Int32? repetitions = pivlR1.Repetitions;
            return new PeriodicIntervalTimeR2(phase, periodPq, null, null, repetitions, quantity);
        }
        public override int GetHashCode() {
            return new HashCodeBuilder()
                .Append(Period)
                .Append(Phase)
                .Append(Alignment)
                .Append(InstitutionSpecified)
                .Append(FrequencyRepetitions)
                .Append(FrequencyQuantity == null ? null : "" + FrequencyQuantity.GetHashCode() + "") //Can't get this to compile using just FrequencyQuantity
                .ToHashCode();
        }
        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            } else if (obj.GetType() != GetType()) {
                return false;
            } else {
                return Equals((PeriodicIntervalTimeR2) obj);
            }
        }
        private bool Equals(PeriodicIntervalTimeR2 that) {
            return new EqualsBuilder()
                .Append(this.Period, that.Period)
                .Append(this.Phase, that.Phase)
                .Append(this.Alignment, that.Alignment)
                .Append(this.InstitutionSpecified, that.InstitutionSpecified)
                .Append(this.FrequencyRepetitions, that.FrequencyRepetitions)
                .Append(this.FrequencyQuantity, that.FrequencyQuantity)
                .IsEquals();
        }
    }
}