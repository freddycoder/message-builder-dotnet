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
 * Last modified: $LastChangedDate: 2013-03-08 11:06:36 -0500 (Fri, 08 Mar 2013) $
 * Revision:      $LastChangedRevision: 6699 $
 */
/* This class was auto-generated by the message builder generator tools. */
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Pharmacy.Pome_mt010040ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using System;


    /**
     * <summary>Business Name: Drug Validity Period</summary>
     * 
     * <p>Allows for business rules regarding dispenses against a 
     * prescription. Controlled and monitored drugs have shorter 
     * prescription lifespans that other drugs.</p> <p>Defines 
     * upper limits for period in which a prescribed drug may be 
     * dispensed. Although an attempt will be made to obtain and 
     * define panCanadian validity periods for drug, it is possible 
     * that drug validity periods wii be jurisdiction-specific</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"POME_MT010040CA.InitialDispense"})]
    public class DrugValidityPeriod : MessagePartBean {

        private IVL<TS, Interval<PlatformDate>> effectiveTime;

        public DrugValidityPeriod() {
            this.effectiveTime = new IVLImpl<TS, Interval<PlatformDate>>();
        }
        /**
         * <summary>Business Name: First Fill Period</summary>
         * 
         * <remarks>Relationship: 
         * POME_MT010040CA.InitialDispense.effectiveTime 
         * Conformance/Cardinality: MANDATORY (1) <p>Certain 
         * prescribers have time limitations or certain drugs must be 
         * filled in a finite period of time.</p> <p>The period within 
         * which the prescribed drug has to be dispensed for the first 
         * time.</p><p>This is usually jurisdiction-specific, and for 
         * the most part, it is set at the drug class level.</p><p>For 
         * instance, the first fill period of validity for narcotic 
         * drugs is 3 days in most jurisdiction, where as it is between 
         * 18 and 24 months for other non-controlled drugs.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"effectiveTime"})]
        public Interval<PlatformDate> EffectiveTime {
            get { return this.effectiveTime.Value; }
            set { this.effectiveTime.Value = value; }
        }

    }

}