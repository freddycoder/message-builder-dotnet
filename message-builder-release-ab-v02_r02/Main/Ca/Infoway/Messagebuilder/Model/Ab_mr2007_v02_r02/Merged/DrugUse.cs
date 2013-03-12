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
 * Last modified: $LastChangedDate: 2011-05-04 16:47:15 -0300 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
/* This class was auto-generated by the message builder generator tools. */
namespace Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;


    /**
     * <summary>Business Name: DrugUse</summary>
     * 
     * <remarks>PORX_MT060340CA.WorkingListEvent: Drug Use 
     * <p>Categorization of prescriptions based on the intended 
     * duration of the prescribed therapy.</p> <p>Useful in 
     * establishing compliance for drug renewals and refills.</p> 
     * PORX_MT060160CA.WorkingListEvent: Drug Use <p>Categorization 
     * of prescriptions based on the intended duration of the 
     * prescribed therapy.</p> <p>Useful in establishing compliance 
     * for drug renewals and refills.</p> 
     * PORX_MT030040CA.WorkingListEvent: Drug Use <p>Categorization 
     * of prescriptions based on the intended duration of the 
     * prescribed therapy.</p> <p>Useful in establishing compliance 
     * for drug renewals and refills.</p> 
     * PORX_MT060190CA.WorkingListEvent: Drug Use <p>Categorization 
     * of prescriptions based on the intended duration of the 
     * prescribed therapy.</p> <p>Useful in establishing compliance 
     * for drug renewals and refills.</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PORX_MT010120CA.WorkingListEvent","PORX_MT030040CA.WorkingListEvent","PORX_MT060160CA.WorkingListEvent","PORX_MT060190CA.WorkingListEvent","PORX_MT060340CA.WorkingListEvent"})]
    public class DrugUse : MessagePartBean {

        private CV code;

        public DrugUse() {
            this.code = new CVImpl();
        }
        /**
         * <summary>Un-merged Business Name: TreatmentType</summary>
         * 
         * <remarks>Relationship: PORX_MT060340CA.WorkingListEvent.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Describes the 
         * categorization of the therapy envisioned by this 
         * prescription (e.g Continuous/Chronic, Short-Term/Acute and 
         * &quot;As-Needed).</p> <p>Prescription 
         * type</p><p>Prescription.drugUseIndicator</p> <p>Prescription 
         * type</p><p>Prescription.drugUseIndicator</p> <p>Allows 
         * categorizing prescription for presentation. May influence 
         * detection of duplicate therapy. May also be used to affect 
         * how DUR processing is completed.</p><p>The field is marked 
         * as &quot;populated&quot; because the intended duration of 
         * the therapy should generally be known at prescribe time. 
         * However in some circumstances, it may not be known whether a 
         * therapy will be short-term or long-term.</p> <p>Allows 
         * categorizing prescription for presentation. May influence 
         * detection of duplicate therapy. May also be used to affect 
         * how DUR processing is completed.</p><p>The field is marked 
         * as &quot;populated&quot; because the intended duration of 
         * the therapy should generally be known at prescribe time. 
         * However in some circumstances, it may not be known whether a 
         * therapy will be short-term or long-term.</p> Un-merged 
         * Business Name: TreatmentType Relationship: 
         * PORX_MT060160CA.WorkingListEvent.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Describes the 
         * categorization of the therapy envisioned by this 
         * prescription (e.g. Continuous/Chronic, Short-Term/Acute and 
         * &quot;As-Needed).</p> <p>Prescription 
         * type</p><p>Prescription.drugUseIndicator</p> <p>Prescription 
         * type</p><p>Prescription.drugUseIndicator</p> <p>Allows 
         * categorizing prescription for presentation. May influence 
         * detection of duplicate therapy. May also be used to affect 
         * how DUR processing is completed. The field is marked as 
         * &quot;populated&quot; because the intended duration of the 
         * therapy should generally be known at prescribe time. However 
         * in some circumstances, it may not be known whether a therapy 
         * will be short-term or long-term.</p> Un-merged Business 
         * Name: PrescriptionTreatmentType Relationship: 
         * PORX_MT030040CA.WorkingListEvent.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Describes the 
         * categorization of the therapy envisioned by this 
         * prescription (e.g. Continuous/Chronic, Short-Term/Acute and 
         * &quot;As-Needed).</p> <p>Allows categorizing prescription 
         * for presentation. May influence detection of duplicate 
         * therapy. May also be used to affect how DUR processing is 
         * completed.</p><p>The field is marked mandatory because the 
         * intended duration of the therapy should be known at 
         * prescribe time.</p> <p>Allows categorizing prescription for 
         * presentation. May influence detection of duplicate therapy. 
         * May also be used to affect how DUR processing is 
         * completed.</p><p>The field is marked mandatory because the 
         * intended duration of the therapy should be known at 
         * prescribe time.</p> Un-merged Business Name: TreatmentType 
         * Relationship: PORX_MT010120CA.WorkingListEvent.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Describes the 
         * categorization of the therapy envisioned by this 
         * prescription (e.g. Continuous/Chronic, Short-Term/Acute and 
         * &quot;As-Needed).</p> <p>Allows categorizing prescription 
         * for presentation. May influence detection of duplicate 
         * therapy. May also be used to affect how DUR processing is 
         * completed. The code is mandatory as this information should 
         * be known at prescribe time.</p> Un-merged Business Name: 
         * PrescriptionTreatmentType Relationship: 
         * PORX_MT060190CA.WorkingListEvent.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Describes the 
         * categorization of the therapy envisioned by this 
         * prescription (e.g. Continuous/Chronic, Short-Term/Acute and 
         * &quot;As-Needed).</p> <p>Allows categorizing prescription 
         * for presentation. May influence detection of duplicate 
         * therapy. May also be used to affect how DUR processing is 
         * completed. The field is marked as &quot;mandatory&quot; 
         * because the intended duration of the therapy should be known 
         * at prescribe time.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ActTherapyDurationWorkingListCode Code {
            get { return (ActTherapyDurationWorkingListCode) this.code.Value; }
            set { this.code.Value = value; }
        }

    }

}