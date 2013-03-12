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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Coct_mt120402ca;
    using System;


    /**
     * <summary>REPC_MT230003CA.Reason: *m:because of Indications</summary>
     * 
     * <p> <i>Essential for understanding the context in which the 
     * action was performed. Also frequently used in searching and 
     * filtering and can impact whether the record will be 
     * automatically masked. Multiple indications are supported for 
     * circumstances where the Clinical Observation Document is 
     * being done for multiple reasons.</i> </p> <p> <i>Identifies 
     * the clinical reason(s) for performing the action described 
     * by the record.</i> </p> REPC_MT410001CA.Reason: *j:because 
     * of <p> <i>Essential for understanding the context in which 
     * the action was performed. Also frequently used in searching 
     * and filtering and can impact whether the record will be 
     * automatically masked. Multiple indications are supported for 
     * circumstances where the Measured Observation is being done 
     * for multiple reasons.</i> </p> <p> <i>Identifies the 
     * clinical reason(s) for performing the action described by 
     * the record.</i> </p> POME_MT010040CA.Reason: recommended for 
     * <p>Useful in prescribing by narrowing selectable drugs based 
     * on specified indication.</p> <p>Recommends which drugs are 
     * to be used for which indications.</p> 
     * PORX_MT060190CA.Reason: d:prescribed because of <p>Helps 
     * providers evaluate the appropriateness of the dosage 
     * instructions for the medication, and may influence education 
     * or literature provided to the patient on the use of the 
     * medication.</p><p>Provided at the discretion of the 
     * prescriber to enhance patient care. E.g., take 1 tab bid for 
     * migraine. Also needed for drug-disease interaction checking 
     * software to work properly.</p><p>This field is marked as 
     * populated because of its high clinical importance, however 
     * 'Nulls' are allowed because the individual recording the 
     * prescription (e.g. pharmacist) may not be aware of the 
     * indication or the prescriber may choose to withhold (mask) 
     * the information due to patient sensitivity.</p> <p>Denotes 
     * the reason(s) for this specific prescription; it must not be 
     * interpreted as a permanent diagnosis.</p> 
     * REPC_MT230001CA.Reason: *m:because of Indications <p> 
     * <i>Essential for understanding the context in which the 
     * action was performed. Also frequently used in searching and 
     * filtering and can impact whether the record will be 
     * automatically masked. Multiple indications are supported for 
     * circumstances where the Clinical Observation Document is 
     * being done for multiple reasons.</i> </p> <p> <i>Identifies 
     * the clinical reason(s) for performing the action described 
     * by the record.</i> </p> REPC_MT220003CA.Reason: *m:because 
     * of Indications <p> <i>Essential for understanding the 
     * context in which the action was performed. Also frequently 
     * used in searching and filtering and can impact whether the 
     * record will be automatically masked. Multiple indications 
     * are supported for circumstances where the Discharge-Care 
     * Summary is being done for multiple reasons.</i> </p> <p> 
     * <i>Identifies the clinical reason(s) for performing the 
     * action described by the record.</i> </p> 
     * REPC_MT220002CA.Reason: *m:because of Indications <p> 
     * <i>Essential for understanding the context in which the 
     * action was performed. Also frequently used in searching and 
     * filtering and can impact whether the record will be 
     * automatically masked. Multiple indications are supported for 
     * circumstances where the Discharge-Care Summary is being done 
     * for multiple reasons.</i> </p> <p> <i>Identifies the 
     * clinical reason(s) for performing the action described by 
     * the record.</i> </p> REPC_MT230002CA.Reason: *m:because of 
     * Indications <p> <i>Essential for understanding the context 
     * in which the action was performed. Also frequently used in 
     * searching and filtering and can impact whether the record 
     * will be automatically masked. Multiple indications are 
     * supported for circumstances where the Clinical Observation 
     * Document is being done for multiple reasons.</i> </p> <p> 
     * <i>Identifies the clinical reason(s) for performing the 
     * action described by the record.</i> </p> 
     * PORX_MT060040CA.Reason2: d:prescribed because of <p>Helps 
     * providers evaluate the appropriateness of the instructions 
     * for the device, and may influence education or literature 
     * provided to the patient on the use of the 
     * device.</p><p>Provided at the discretion of the prescriber 
     * to enhance patient care. E.g., take 1 tab bid for migraine. 
     * Also needed for drug-disease interaction checking software 
     * to work properly.</p><p>This field is marked as populated 
     * because of its high clinical importance, however 'Nulls' are 
     * allowed because the individual recording the prescription 
     * (e.g. pharmacist) may not be aware of the indication or the 
     * prescriber may choose to withhold (mask) the information due 
     * to patient sensitivity.</p> <p>Denotes the reason(s) for 
     * this specific prescription; it must not be interpreted as a 
     * permanent diagnosis.</p> REPC_MT210002CA.Reason: *m:because 
     * of Indications <p> <i>Essential for understanding the 
     * context in which the action was performed. Also frequently 
     * used in searching and filtering and can impact whether the 
     * record will be automatically masked. Multiple indications 
     * are supported for circumstances where the Referral is being 
     * done for multiple reasons.</i> </p> <p> <i>Identifies the 
     * clinical reason(s) for performing the action described by 
     * the record.</i> </p> REPC_MT420003CA.Reason: *j:because of 
     * <p> <i>Essential for understanding the context in which the 
     * action was performed. Also frequently used in searching and 
     * filtering and can impact whether the record will be 
     * automatically masked. Multiple indications are supported for 
     * circumstances where the Coded Observation is being done for 
     * multiple reasons.</i> </p> <p> <i>Identifies the clinical 
     * reason(s) for performing the action described by the 
     * record.</i> </p> PORX_MT060340CA.Reason2: d:prescribed 
     * because of <p>Helps providers evaluate the appropriateness 
     * of the dosage instructions for the medication, and may 
     * influence education or literature provided to the patient on 
     * the use of the medication.</p><p>Provided at the discretion 
     * of the prescriber to enhance patient care. E.g., take 1 tab 
     * bid for migraine. Also needed for drug-disease interaction 
     * checking software to work properly.</p><p>This field is 
     * marked as populated because of its high clinical importance, 
     * however 'Nulls' are allowed because the individual recording 
     * the prescription (e.g. pharmacist) may not be aware of the 
     * indication or the prescriber may choose to withhold (mask) 
     * the information due to patient sensitivity.</p> <p>Denotes 
     * the reason(s) for this specific prescription; it must not be 
     * interpreted as a permanent diagnosis.</p> 
     * PORX_MT030040CA.Reason: d:prescribed because of <p>Helps 
     * providers evaluate the appropriateness of the dosage 
     * instructions for the medication, and may influence education 
     * or literature provided to the patient on the use of the 
     * medication.</p><p>Provided at the discretion of the 
     * prescriber to enhance patient care. E.g., take 1 tab bid for 
     * migraine. Also needed for drug-disease interaction checking 
     * software to work properly.</p><p>This field is marked as 
     * populated because of its high clinical importance, however 
     * 'Nulls' are allowed because the individual recording the 
     * prescription (e.g. pharmacist) may not be aware of the 
     * indication or the prescriber may choose to withhold (mask) 
     * the information due to patient sensitivity.</p> <p>Denotes 
     * the reason(s) for this specific prescription; it must not be 
     * interpreted as a permanent diagnosis.</p> 
     * REPC_MT500001CA.Reason: k:because of <p>Association is 
     * mandatory, 1..1 when Care Composition Type is Episode 
     * (Health Condition-based) or a specialization there-of</p> 
     * <p> <i>Essential for understanding the context in which the 
     * action was performed. Also frequently used in searching and 
     * filtering and can impact whether the record will be 
     * automatically masked. Multiple indications are supported for 
     * circumstances where the Care Composition is being done for 
     * multiple reasons.</i> </p> <p>For health condition-based 
     * (episode) collections, there must be exactly one indication 
     * (the 'definitional' problem for the episode). For care-based 
     * collections, there should not be any indications. (Problems 
     * are captured as part of the overall care, not as the reason 
     * for care.)</p> <p> <i>Identifies the clinical reason(s) for 
     * performing the action described by the record.</i> </p> 
     * REPC_MT420001CA.Reason: *j:because of <p> <i>Essential for 
     * understanding the context in which the action was performed. 
     * Also frequently used in searching and filtering and can 
     * impact whether the record will be automatically masked. 
     * Multiple indications are supported for circumstances where 
     * the Coded Observation is being done for multiple 
     * reasons.</i> </p> <p> <i>Iden
     * ... [rest of documentation truncated due to excessive length]
     */
    [Hl7PartTypeMappingAttribute(new string[] {"POME_MT010040CA.Reason","PORX_MT010110CA.Reason2","PORX_MT010120CA.Reason2","PORX_MT030040CA.Reason","PORX_MT060040CA.Reason2","PORX_MT060060CA.Reason","PORX_MT060160CA.Reason2","PORX_MT060190CA.Reason","PORX_MT060340CA.Reason2","REPC_MT210001CA.Reason","REPC_MT210002CA.Reason","REPC_MT210003CA.Reason","REPC_MT220001CA.Reason","REPC_MT220002CA.Reason","REPC_MT220003CA.Reason","REPC_MT230001CA.Reason","REPC_MT230002CA.Reason","REPC_MT230003CA.Reason","REPC_MT410001CA.Reason","REPC_MT410003CA.Reason","REPC_MT420001CA.Reason","REPC_MT420003CA.Reason","REPC_MT500001CA.Reason","REPC_MT500002CA.Reason","REPC_MT500003CA.Reason","REPC_MT500004CA.Reason","REPC_MT610001CA.Reason","REPC_MT610002CA.Reason"})]
    public class BecauseOf : MessagePartBean {

        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Coct_mt120402ca.IIndications indications;
        private INT priorityNumber;

        public BecauseOf() {
            this.priorityNumber = new INTImpl();
        }
        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: REPC_MT410003CA.Reason.indications 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT230003CA.Reason.indications Conformance/Cardinality: 
         * POPULATED (1) Un-merged Business Name: (no business name 
         * specified) Relationship: REPC_MT410001CA.Reason.indications 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * POME_MT010040CA.Reason.indications Conformance/Cardinality: 
         * POPULATED (1) Un-merged Business Name: (no business name 
         * specified) Relationship: REPC_MT230001CA.Reason.indications 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060190CA.Reason.indications Conformance/Cardinality: 
         * POPULATED (1) Un-merged Business Name: (no business name 
         * specified) Relationship: REPC_MT220003CA.Reason.indications 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT210001CA.Reason.indications Conformance/Cardinality: 
         * POPULATED (1) Un-merged Business Name: (no business name 
         * specified) Relationship: REPC_MT220002CA.Reason.indications 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT230002CA.Reason.indications Conformance/Cardinality: 
         * POPULATED (1) Un-merged Business Name: (no business name 
         * specified) Relationship: PORX_MT060040CA.Reason2.indications 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT210002CA.Reason.indications Conformance/Cardinality: 
         * POPULATED (1) Un-merged Business Name: (no business name 
         * specified) Relationship: REPC_MT420003CA.Reason.indications 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060340CA.Reason2.indications Conformance/Cardinality: 
         * POPULATED (1) Un-merged Business Name: (no business name 
         * specified) Relationship: PORX_MT030040CA.Reason.indications 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT500001CA.Reason.indications Conformance/Cardinality: 
         * POPULATED (1) Un-merged Business Name: (no business name 
         * specified) Relationship: REPC_MT420001CA.Reason.indications 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060060CA.Reason.indications Conformance/Cardinality: 
         * POPULATED (1) Un-merged Business Name: (no business name 
         * specified) Relationship: REPC_MT500004CA.Reason.indications 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT220001CA.Reason.indications Conformance/Cardinality: 
         * POPULATED (1) Un-merged Business Name: (no business name 
         * specified) Relationship: PORX_MT010120CA.Reason2.indications 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT500003CA.Reason.indications Conformance/Cardinality: 
         * POPULATED (1) Un-merged Business Name: (no business name 
         * specified) Relationship: REPC_MT210003CA.Reason.indications 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060160CA.Reason2.indications Conformance/Cardinality: 
         * POPULATED (1) Un-merged Business Name: (no business name 
         * specified) Relationship: REPC_MT500002CA.Reason.indications 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT010110CA.Reason2.indications Conformance/Cardinality: 
         * POPULATED (1) Un-merged Business Name: (no business name 
         * specified) Relationship: REPC_MT610002CA.Reason.indications 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT610001CA.Reason.indications Conformance/Cardinality: 
         * POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"indications"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Coct_mt120402ca.IIndications Indications {
            get { return this.indications; }
            set { this.indications = value; }
        }

        /**
         * <summary>Business Name: IndicationPriority</summary>
         * 
         * <remarks>Un-merged Business Name: IndicationPriority 
         * Relationship: PORX_MT060060CA.Reason.priorityNumber 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Allows providers 
         * to indicate whether indication is the primary or secondary 
         * target of the therapy. E.g., Terazosin for Benign Prostatic 
         * Hypertrophy as primary and Hypertension as secondary or 
         * vice-versa.</p> <p>Ordering of prescribing indications from 
         * primary indication (low number) to minor indication (higher 
         * number). Multiple indications are permitted to have the same 
         * priority if they're considered of equivalent importance.</p> 
         * Un-merged Business Name: IndicationPriority Relationship: 
         * PORX_MT010120CA.Reason2.priorityNumber 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Allows providers 
         * to indicate whether indication is the primary or secondary 
         * target of the therapy. E.g., Terazosin for Benign Prostatic 
         * Hypertrophy as primary and Hypertension as secondary or 
         * vice-versa.</p> <p>Ordering of prescribing indications from 
         * primary indication (low number) to minor indication (higher 
         * number). Multiple indications are permitted to have the same 
         * priority if they're considered of equivalent importance.</p> 
         * Un-merged Business Name: IndicationPriority Relationship: 
         * PORX_MT030040CA.Reason.priorityNumber 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Allows providers 
         * to indicate whether indication is the primary or secondary 
         * target of the therapy. E.g., Terazosin for Benign Prostatic 
         * Hypertrophy as primary and Hypertension as secondary or 
         * vice-versa.</p> <p>Ordering of prescribing indications from 
         * primary indication (low number) to minor indication (higher 
         * number). Multiple indications are permitted to have the same 
         * priority if they're considered of equivalent importance.</p> 
         * Un-merged Business Name: IndicationPriority Relationship: 
         * PORX_MT060340CA.Reason2.priorityNumber 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Allows providers 
         * to indicate whether indication is the primary or secondary 
         * target of the therapy. E.g., Terazosin for Benign Prostatic 
         * Hypertrophy as primary and Hypertension as secondary or 
         * vice-versa.</p> <p>Ordering of prescribing indications from 
         * primary indication (low number) to minor indication (higher 
         * number). Multiple indications are permitted to have the same 
         * priority if they're considered of equivalent importance.</p> 
         * Un-merged Business Name: IndicationPriority Relationship: 
         * PORX_MT060040CA.Reason2.priorityNumber 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Allows providers 
         * to indicate whether indication is the primary or secondary 
         * target of the therapy. E.g., Terazosin for Benign Prostatic 
         * Hypertrophy as primary and Hypertension as secondary or 
         * vice-versa.</p> <p>Ordering of prescribing indications from 
         * primary indication (low number) to minor indication (higher 
         * number). Multiple indications are permitted to have the same 
         * priority if they're considered of equivalent importance.</p> 
         * Un-merged Business Name: IndicationPriority Relationship: 
         * PORX_MT060160CA.Reason2.priorityNumber 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Allows providers 
         * to indicate whether indication is the primary or secondary 
         * target of the therapy. E.g., Terazosin for Benign Prostatic 
         * Hypertrophy as primary and Hypertension as secondary or 
         * vice-versa.</p> <p>Ordering of prescribing indications from 
         * primary indication (low number) to minor indication (higher 
         * number). Multiple indications are permitted to have the same 
         * priority if they're considered of equivalent importance.</p> 
         * Un-merged Business Name: IndicationPriority Relationship: 
         * PORX_MT060190CA.Reason.priorityNumber 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Allows providers 
         * to indicate whether indication is the primary or secondary 
         * target of the therapy. E.g., Terazosin for Benign Prostatic 
         * Hypertrophy as primary and Hypertension as secondary or 
         * vice-versa.</p> <p>Ordering of prescribing indications from 
         * primary indication (low number) to minor indication (higher 
         * number). Multiple indications are permitted to have the same 
         * priority if they're considered of equivalent importance.</p> 
         * Un-merged Business Name: IndicationPriority Relationship: 
         * PORX_MT010110CA.Reason2.priorityNumber 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Allows providers 
         * to indicate whether indication is the primary or secondary 
         * target of the therapy. E.g., Terazosin for Benign Prostatic 
         * Hypertrophy as primary and Hypertension as secondary or 
         * vice-versa.</p> <p>Ordering of prescribing indications from 
         * primary indication (low number) to minor indication (higher 
         * number). Multiple indications are permitted to have the same 
         * priority if they're considered of equivalent importance.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"priorityNumber"})]
        public int? PriorityNumber {
            get { return this.priorityNumber.Value; }
            set { this.priorityNumber.Value = value; }
        }

    }

}