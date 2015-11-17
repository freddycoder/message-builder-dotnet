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

namespace Ca.Infoway.Messagebuilder.Datatype.Lang
{
    using System;
    using Ca.Infoway.Messagebuilder.Domainvalue;

    /// <summary>
    /// EIVL_TS
    /// </summary>
    [Serializable]
    public class EventRelatedPeriodicIntervalTime : MbDate {
        public Interval<PhysicalQuantity> Offset {
            get;
            set;
        }
        public TimingEvent Event {
            get;
            set;
        }

        public EventRelatedPeriodicIntervalTime() {
        }

        public EventRelatedPeriodicIntervalTime(Interval<PhysicalQuantity> offset, TimingEvent timingEvent) {
            Offset = offset;
            Event = timingEvent;
        }

        public bool IsEmpty() {
            return Event == null && Offset == null;
        }

        public override int GetHashCode() {
            return new HashCodeBuilder()
                .Append(Offset)
                .Append(Event)
                .ToHashCode();
        }

        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            } else if (obj.GetType() != GetType()) {
                return false;
            } else {
                return Equals((EventRelatedPeriodicIntervalTime)obj);
            }
        }

        private bool Equals(EventRelatedPeriodicIntervalTime that) {
            return new EqualsBuilder()
                .Append(this.Offset, that.Offset)
                .Append(this.Event, that.Event)
                .IsEquals();
        }
    }
}