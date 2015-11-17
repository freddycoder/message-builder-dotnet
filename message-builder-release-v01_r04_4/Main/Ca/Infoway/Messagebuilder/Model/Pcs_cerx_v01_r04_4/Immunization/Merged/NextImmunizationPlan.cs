/**
 * Copyright 2015 Canada Health Infoway, Inc.
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
/* This class was auto-generated by the message builder generator tools. */
namespace Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Immunization.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Model;
    using System;


    /**
     * <summary>POIZ_MT030060CA.NextImmunizationPlan: (no business 
     * name)</summary>
     * 
     * <p>The NextImmunizationPlan is when you need your next 
     * &quot;series&quot; of immunizations, often referred to as 
     * booster shots.</p> POIZ_MT030050CA.NextImmunizationPlan: (no 
     * business name) <p>The NextImmunizationPlan is when you need 
     * your next &quot;series&quot; of immunizations, often 
     * referred to as booster shots.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"POIZ_MT030050CA.NextImmunizationPlan","POIZ_MT030060CA.NextImmunizationPlan","POIZ_MT060150CA.NextImmunizationPlan"})]
    public class NextImmunizationPlan : MessagePartBean {

        private TS effectiveTime;

        public NextImmunizationPlan() {
            this.effectiveTime = new TSImpl();
        }
        /**
         * <summary>Un-merged Business Name: RenewalDate</summary>
         * 
         * <remarks>Relationship: 
         * POIZ_MT060150CA.NextImmunizationPlan.effectiveTime 
         * Conformance/Cardinality: MANDATORY (1) <p>Necessary reminder 
         * to a patient and his/or provider for a follow-up 
         * therapy.</p> <p>Indicates the date on which the next course 
         * of immunization is to be undertaken.</p> Un-merged Business 
         * Name: NextPlannedSeriesRepeatDate Relationship: 
         * POIZ_MT030060CA.NextImmunizationPlan.effectiveTime 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows for 
         * immunization therapy planning for a patient.</p> <p>The date 
         * on which the overall immunization therapy is to be 
         * repeated.</p> Un-merged Business Name: 
         * NextPlannedSeriesRepeatDate Relationship: 
         * POIZ_MT030050CA.NextImmunizationPlan.effectiveTime 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows for the 
         * scheduling of a multi-dose immunization course.</p> 
         * <p>Indicates the date on which the next series is scheduled 
         * to be administered.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"effectiveTime"})]
        public PlatformDate EffectiveTime {
            get { return this.effectiveTime.Value; }
            set { this.effectiveTime.Value = value; }
        }

    }

}