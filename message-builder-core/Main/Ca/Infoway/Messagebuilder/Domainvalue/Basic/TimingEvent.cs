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

namespace Ca.Infoway.Messagebuilder.Domainvalue.Basic {
    using System;
    using Ca.Infoway.Messagebuilder;
    using Ca.Infoway.Messagebuilder.Domainvalue.Util;
    using Ca.Infoway.Messagebuilder.Lang;

    /// <summary>
    /// An enum representing all the valid and applicable TimingEvent types used within MessageBuilder.
    /// </summary>
    [Serializable]
    public class TimingEvent : EnumPattern, Ca.Infoway.Messagebuilder.Domainvalue.TimingEvent, Describable {

        public static readonly TimingEvent AC = new TimingEvent("AC");
        public static readonly TimingEvent ACD = new TimingEvent("ACD");
        public static readonly TimingEvent ACM = new TimingEvent("ACM");
        public static readonly TimingEvent ACV = new TimingEvent("ACV");
        public static readonly TimingEvent HS = new TimingEvent("HS");
        public static readonly TimingEvent IC = new TimingEvent("IC");
        public static readonly TimingEvent ICD = new TimingEvent("ICD");
        public static readonly TimingEvent ICM = new TimingEvent("ICM");
        public static readonly TimingEvent ICV = new TimingEvent("ICV");
        public static readonly TimingEvent PC = new TimingEvent("PC");
        public static readonly TimingEvent PCD = new TimingEvent("PCD");
        public static readonly TimingEvent PCM = new TimingEvent("PCM");
        public static readonly TimingEvent PCV = new TimingEvent("PCV");

        //	AC	before meal (from lat. ante cibus)
        //	ACD	ACD	before lunch (from lat. ante cibus diurnus)
        //	ACM	ACM	before breakfast (from lat. ante cibus matutinus)
        //	ACV	ACV	before dinner (from lat. ante cibus vespertinus)
        //	HS	HS	Description: Prior to beginning a regular period of extended sleep (this would exclude naps). Note that this might occur at different times of day depending on a person's regular sleep schedule.
        //	IC	IC	between meals (from lat. inter cibus)
        //	ICD	ICD	between lunch and dinner
        //	ICM	ICM	between breakfast and lunch
        //	ICV	ICV	between dinner and the hour of sleep
        //	PC	PC	after meal (from lat. post cibus)
        //	PCD	PCD	after lunch (from lat. post cibus diurnus)
        //	PCM	PCM	after breakfast (from lat. post cibus matutinus)
        //	PCV	PCV	after dinner (from lat. post cibus vespertinus)    

        private readonly String description;

        public String Description {
            get {
                return this.description;
            }
        }

        public virtual String CodeSystem {
            get {
                return Ca.Infoway.Messagebuilder.Codesystem.CodeSystem.VOCABULARY_TIMING_EVENT.Root;
            }
        }

        public virtual String CodeSystemName {
            get { return null; }
        }

        public virtual String CodeValue {
            get { return Name; }
        }

        private TimingEvent(String codeValue) :
            base(codeValue) {
            this.description = DescribableUtil.GetDefaultDescription(Name);
        }

        private TimingEvent(String codeValue, String description) :
            base(codeValue) {
                this.description = description;
        }
    }
}