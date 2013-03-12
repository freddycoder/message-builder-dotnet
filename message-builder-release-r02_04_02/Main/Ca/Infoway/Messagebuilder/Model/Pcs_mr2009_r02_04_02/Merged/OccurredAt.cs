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
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Merged;
    using System;


    /**
     * <summary>COMT_MT300003CA.Location: *c:recorded at</summary>
     * 
     * <p>Important for performing follow-up and is therefore 
     * mandatory.</p> <p>Indicates the facility/location where the 
     * patient note was recorded.</p> PORX_MT060060CA.Location2: 
     * *c:targeted to pharmacy <p>Allows prescriptions to be 
     * directed on the request of the patient or by legal 
     * requirement. Also allows indication of which pharmacy is the 
     * current 'custodian' of the prescription.</p><p>This should 
     * always be known or should have an explicit null flavor of 
     * 'NA' (non-assigned) or 'UNK' (paper prescription). Thus the 
     * association is 'populated'.</p> <p>Indicates the pharmacy to 
     * which the prescription has been directed or which has 
     * currently assumed responsibility for dispensing the 
     * prescription.</p> REPC_MT230001CA.Location: i:occurred at 
     * <p>The site of the actual event provides context for 
     * interpreting the record. In some cases, it may also provide 
     * follow-up information</p> <p>This identifies the location 
     * where the actual clinical event (observation or 
     * discharge/care) occurred. E.g. Patient's residence, clinic, 
     * work site, etc. It only needs to be specified when the 
     * occurrence location differs from the official record 
     * location. For referral report, it indicates the location 
     * where the referred service is to be performed.</p> 
     * PORX_MT030040CA.Location2: *c:targeted to pharmacy <p>Allows 
     * prescriptions to be directed on the request of the patient 
     * or by legal requirement. Also allows indication of which 
     * pharmacy is the current 'custodian' of the 
     * prescription.</p><p>This should always be known or should 
     * have an explicit null flavor of 'NA' (non-assigned) or 'UNK' 
     * (paper prescription). Thus the association is 
     * 'populated'.</p> <p>Indicates the pharmacy to which the 
     * prescription has been directed or which has currently 
     * assumed responsibility for dispensing the prescription.</p> 
     * REPC_MT500003CA.Location: h:occurred at <p>Must not be 
     * specified when Care Composition Type is 
     * 'Condition-based'</p> <p> <i>The site of the actual event 
     * provides context for interpreting the record. In some cases, 
     * it may also provide follow-up information</i> 
     * </p><p>Multiple repetitions are allowed for telehealth and 
     * other remote encounters.</p> <p> <i>This identifies the 
     * location where the Care Composition actually occurred. E.g. 
     * Patient's residence, clinic, work site, etc. It only needs 
     * to be specified when the occurrence location differs from 
     * the official record location.</i> </p><p>In circumstances 
     * where number of locations involved is greater than the limit 
     * supported by the message, multiple encounters should be 
     * used.</p> REPC_MT230003CA.Location: i:occurred at <p>The 
     * site of the actual event provides context for interpreting 
     * the record. In some cases, it may also provide follow-up 
     * information</p> <p>This identifies the location where the 
     * actual clinical event (observation or discharge/care) 
     * occurred. E.g. Patient's residence, clinic, work site, etc. 
     * It only needs to be specified when the occurrence location 
     * differs from the official record location. For referral 
     * report, it indicates the location where the referred service 
     * is to be performed.</p> REPC_MT220002CA.Location2: 
     * i:occurred at <p>The site of the actual event provides 
     * context for interpreting the record. In some cases, it may 
     * also provide follow-up information</p> <p>This identifies 
     * the location where the actual discharge/care event occurred. 
     * E.g. Patient's residence, clinic, work site, hospital, etc. 
     * It only needs to be specified when the occurrence location 
     * differs from the official record location.</p><p>The site of 
     * the actual event provides context for interpreting the 
     * record. In some cases, it may also provide follow-up 
     * information</p> PORX_MT060160CA.Location: *d:dispensed from 
     * <p>Important for performing follow-up and therefore 
     * mandatory.</p> <p>Indicates the facility/location where the 
     * dispensing was performed.</p> REPC_MT230002CA.Location: 
     * i:occurred at <p>The site of the actual event provides 
     * context for interpreting the record. In some cases, it may 
     * also provide follow-up information</p> <p>This identifies 
     * the location where the actual clinical event (observation or 
     * discharge/care) occurred. E.g. Patient's residence, clinic, 
     * work site, etc. It only needs to be specified when the 
     * occurrence location differs from the official record 
     * location. For referral report, it indicates the location 
     * where the referred service is to be performed.</p> 
     * REPC_MT000005CA.Location: *i:recorded at <p>Indicates where 
     * records are likely kept for follow-up. May also be useful in 
     * understanding the context in which the allergy/intolerance 
     * was recorded. The location of entry should always be known, 
     * and is therefore mandatory.</p> <p>Indicates the service 
     * delivery location where the allergy was recorded.</p> 
     * REPC_MT210003CA.Location3: v:referred to <p>If the referral 
     * was targeted to a service delivery location then the 
     * identity of the location must be known.</p> <p>Indicates the 
     * service Delivery Location where the referral service is 
     * targeted to be preformed.</p><p>The target site of the 
     * referral service provides context for interpreting the 
     * record. In some cases, it may also provide follow-up 
     * information</p> PORX_MT010110CA.Location2: *c:targeted to 
     * pharmacy <p>Allows prescriptions to be directed on the 
     * request of the patient or by legal requirement. Also allows 
     * indication of which pharmacy is the current 'custodian' of 
     * the prescription.</p><p>This should always be known or 
     * should have an explicit null flavor of 'NA' (non-assigned) 
     * or 'UNK' (paper prescription). Thus the association is 
     * 'populated'.</p> <p>Indicates the pharmacy to which the 
     * prescription has been directed or which has currently 
     * assumed responsibility for dispensing the prescription.</p> 
     * REPC_MT000006CA.Location: *i:recorded at <p>Indicates where 
     * records are likely kept for follow-up. May also be useful in 
     * understanding the context in which the adverse reaction was 
     * recorded. The location of entry should always be known, and 
     * is therefore mandatory.</p> <p>Indicates the service 
     * delivery location where the adverse reaction was 
     * recorded.</p> PORX_MT060100CA.Location: *dispensed from 
     * <p>Used for follow-up communication on the dispensed 
     * product, and therefore mandatory.</p> <p>Identification of 
     * the service delivery location where the medication was 
     * dispensed.</p> PORX_MT060160CA.Location5: *c:targeted to 
     * pharmacy <p>Allows prescriptions to be directed on the 
     * request of the patient or by legal requirement. Also allows 
     * indication of which pharmacy is the current 'custodian' of 
     * the prescription.</p><p>This should always be known or 
     * should have an explicit null flavor of 'NA' (non-assigned) 
     * or 'UNK' (paper prescription). Thus the association is 
     * 'populated'.</p> <p>Indicates the pharmacy to which the 
     * prescription has been directed or which has currently 
     * assumed responsibility for dispensing the prescription.</p> 
     * REPC_MT210002CA.Location3: v:referred to <p>If the referral 
     * was targeted to a service delivery location then the 
     * identity of the location must be known.</p> <p>Indicates the 
     * service Delivery Location where the referral service is 
     * targeted to be preformed.</p><p>The target site of the 
     * referral service provides context for interpreting the 
     * record. In some cases, it may also provide follow-up 
     * information</p> PORX_MT060160CA.Location4: *refused at 
     * <p>Allows follow-up and traceability of the 
     * refusal.</p><p>Association is mandatory as the dispensing 
     * facility refusing the fill must be known.</p> <p>Identifies 
     * the location where the refusal occurred</p> 
     * REPC_MT500002CA.Location: h:occurred at <p>Must not be 
     * specified when Care Composition Type is 
     * 'Condition-based'</p> <p> <i>The site of the actual event 
     * provides context for interpreting the record. In some cases, 
     * it may also provide follow-up information</i> 
     * </p><p>Multiple repetitions are allowed for telehealth and 
     * other remote encounters.</p> <p> <i>This identifies the 
     * location where the Care Composition actually occurred. E.g. 
     * Patient's residence, clinic, work site, etc. It only needs 
     * to be specified when the occurrence location differs from 
     * the official record location.</i> </p><p>In circumstances 
     * where number of locations involved is greater than the limit 
     * supported by the message, multiple encounters should be 
     * used.</p> PORX_MT060010CA.Location: *d:dispensed from 
     * <p>Important for performing follow-up and therefore 
     * mandatory.</p> <p>Indicates the facility/location where the 
     * dispensing was performed.</p> PORX_MT060160CA.Location3: 
     * *prescribed at <p>Identifies where paper records are likely 
     * located for follow-up. This is marked as 'populated' because 
     * it won't always be known
     * ... [rest of documentation truncated due to excessive length]
     */
    [Hl7PartTypeMappingAttribute(new string[] {"COCT_MT011001CA.Location","COCT_MT260010CA.Location","COCT_MT260020CA.Location","COCT_MT260030CA.Location","COMT_MT300003CA.Location","POIZ_MT030050CA.Location","POIZ_MT030060CA.Location","POIZ_MT060150CA.Location","PORX_MT010110CA.Location2","PORX_MT010120CA.Location2","PORX_MT010140CA.Location","PORX_MT030040CA.Location","PORX_MT030040CA.Location2","PORX_MT060010CA.Location","PORX_MT060020CA.Location","PORX_MT060040CA.Location","PORX_MT060040CA.Location2","PORX_MT060040CA.Location3","PORX_MT060040CA.Location4","PORX_MT060060CA.Location","PORX_MT060060CA.Location2","PORX_MT060090CA.Location","PORX_MT060100CA.Location","PORX_MT060160CA.Location","PORX_MT060160CA.Location2","PORX_MT060160CA.Location3","PORX_MT060160CA.Location4","PORX_MT060160CA.Location5","PORX_MT060190CA.Location","PORX_MT060190CA.Location2","PORX_MT060190CA.Location3","PORX_MT060190CA.Location4","PORX_MT060210CA.Location2","PORX_MT060340CA.Location","PORX_MT060340CA.Location2","PORX_MT060340CA.Location3","PORX_MT060340CA.Location4","REPC_MT000005CA.Location","REPC_MT000006CA.Location","REPC_MT000009CA.Location","REPC_MT210001CA.Location3","REPC_MT210002CA.Location3","REPC_MT210003CA.Location3","REPC_MT220001CA.Location2","REPC_MT220002CA.Location2","REPC_MT220003CA.Location2","REPC_MT230001CA.Location","REPC_MT230002CA.Location","REPC_MT230003CA.Location","REPC_MT410001CA.Location","REPC_MT410003CA.Location","REPC_MT420001CA.Location","REPC_MT420003CA.Location","REPC_MT500001CA.Location","REPC_MT500002CA.Location","REPC_MT500003CA.Location","REPC_MT500004CA.Location","REPC_MT610001CA.Location","REPC_MT610002CA.Location"})]
    public class OccurredAt : MessagePartBean {

        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Merged.ServiceLocation serviceDeliveryLocation;
        private IVL<TS, Interval<PlatformDate>> time;
        private CV substitutionConditionCode;
        private CS contextControlCode;

        public OccurredAt() {
            this.time = new IVLImpl<TS, Interval<PlatformDate>>();
            this.substitutionConditionCode = new CVImpl();
            this.contextControlCode = new CSImpl();
        }
        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * COMT_MT300003CA.Location.serviceDeliveryLocation 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060060CA.Location2.serviceDeliveryLocation 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT230001CA.Location.serviceDeliveryLocation 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060060CA.Location.serviceDeliveryLocation 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT030040CA.Location2.serviceDeliveryLocation 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT500003CA.Location.serviceDeliveryLocation 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * COCT_MT260020CA.Location.serviceDeliveryLocation 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT410003CA.Location.serviceDeliveryLocation 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT230003CA.Location.serviceDeliveryLocation 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT220002CA.Location2.serviceDeliveryLocation 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT210001CA.Location3.serviceDeliveryLocation 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060160CA.Location.serviceDeliveryLocation 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT230002CA.Location.serviceDeliveryLocation 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT000005CA.Location.serviceDeliveryLocation 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT210003CA.Location3.serviceDeliveryLocation 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT010110CA.Location2.serviceDeliveryLocation 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT000006CA.Location.serviceDeliveryLocation 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060100CA.Location.serviceDeliveryLocation 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT210002CA.Location3.serviceDeliveryLocation 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060160CA.Location5.serviceDeliveryLocation 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060160CA.Location4.serviceDeliveryLocation 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * POIZ_MT060150CA.Location.serviceDeliveryLocation 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060160CA.Location3.serviceDeliveryLocation 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060010CA.Location.serviceDeliveryLocation 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT500002CA.Location.serviceDeliveryLocation 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT500004CA.Location.serviceDeliveryLocation 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060160CA.Location2.serviceDeliveryLocation 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * COCT_MT260010CA.Location.serviceDeliveryLocation 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * COCT_MT260030CA.Location.serviceDeliveryLocation 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060190CA.Location.serviceDeliveryLocation 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT030040CA.Location.serviceDeliveryLocation 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT220003CA.Location2.serviceDeliveryLocation 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT010140CA.Location.serviceDeliveryLocation 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT420001CA.Location.serviceDeliveryLocation 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * COCT_MT011001CA.Location.serviceDeliveryLocation 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060190CA.Location2.serviceDeliveryLocation 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060190CA.Location4.serviceDeliveryLocation 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060190CA.Location3.serviceDeliveryLocation 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT420003CA.Location.serviceDeliveryLocation 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT610001CA.Location.serviceDeliveryLocation 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060340CA.Location.serviceDeliveryLocation 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT000009CA.Location.serviceDeliveryLocation 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT500001CA.Location.serviceDeliveryLocation 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * POIZ_MT030060CA.Location.serviceDeliveryLocation 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT410001CA.Location.serviceDeliveryLocation 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT010120CA.Location2.serviceDeliveryLocation 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060020CA.Location.serviceDeliveryLocation 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060210CA.Location2.serviceDeliveryLocation 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT220001CA.Location2.serviceDeliveryLocation 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060090CA.Location.serviceDeliveryLocation 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * POIZ_MT030050CA.Location.serviceDeliveryLocation 
         *
         * ... [rest of documentation truncated due to excessive length]
         */
        [Hl7XmlMappingAttribute(new string[] {"serviceDeliveryLocation"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Merged.ServiceLocation ServiceDeliveryLocation {
            get { return this.serviceDeliveryLocation; }
            set { this.serviceDeliveryLocation = value; }
        }

        /**
         * <summary>Business Name: ToBePickedUpWhen</summary>
         * 
         * <remarks>Un-merged Business Name: ToBePickedUpWhen 
         * Relationship: PORX_MT010110CA.Location2.time 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Allows a 
         * prescriber to indicate to the targeted pharmacy, when 
         * patient will be expecting to pick up the dispensed 
         * device.</p> <p>The date and time on which the dispense is 
         * expected to be picked up.</p> Un-merged Business Name: 
         * ToBePickedUpWhen Relationship: 
         * PORX_MT060040CA.Location4.time Conformance/Cardinality: 
         * REQUIRED (0-1) <p>Allows a prescriber to indicate to the 
         * targeted pharmacy, when patient will be expecting to pick up 
         * the dispensed device.</p> <p>The date and time on which the 
         * dispense is expected to be picked up.</p> Un-merged Business 
         * Name: ToBePickedUpWhen Relationship: 
         * PORX_MT060060CA.Location2.time Conformance/Cardinality: 
         * REQUIRED (0-1) <p>Allows a prescriber to indicate to the 
         * targeted pharmacy, when patient will be expecting to pick up 
         * the dispensed device.</p> <p>The date and time on which the 
         * dispense is expected to be picked up.</p> Un-merged Business 
         * Name: ToBePickedUpWhen Relationship: 
         * PORX_MT060340CA.Location4.time Conformance/Cardinality: 
         * REQUIRED (0-1) <p>Allows a prescriber to indicate to the 
         * targeted pharmacy, when patient will be expecting to pick up 
         * the dispensed medication.</p> <p>The date and time on which 
         * the dispense is expected to be picked up.</p> Un-merged 
         * Business Name: ToBePickedUpWhen Relationship: 
         * PORX_MT060160CA.Location5.time Conformance/Cardinality: 
         * REQUIRED (0-1) <p>Allows a prescriber to indicate to the 
         * targeted pharmacy, when patient will be expecting to pick up 
         * the dispensed medication.</p> <p>The date and time on which 
         * the dispense is expected to be picked up.</p> Un-merged 
         * Business Name: ToBePickedUpWhen Relationship: 
         * PORX_MT010120CA.Location2.time Conformance/Cardinality: 
         * REQUIRED (0-1) <p>Allows a prescriber to indicate to the 
         * targeted pharmacy, when patient will be expecting to pick up 
         * the dispensed medication.</p> <p>The date and time on which 
         * the dispense is expected to be picked up.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"time"})]
        public Interval<PlatformDate> Time {
            get { return this.time.Value; }
            set { this.time.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: 
         * DispenseFacilityNotAssignableIndicator</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT030040CA.Location2.substitutionConditionCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Influences 
         * whether the prescription may be transferred to a service 
         * delivery location other than the targeted dispenser.</p> 
         * <p>Indicates a 'hard' or 'soft' assignment of dispensing 
         * priviledged to the targetted facility.</p><p>'Hard' 
         * assignment (mandated facility) indicates that the 
         * prescription can be dispensed only at that 
         * facility.</p><p>'Soft' assignment (usually as a patient 
         * directive) indicates that the prescription may be dispensed 
         * at facilities other than the targeted facility.</p> 
         * Un-merged Business Name: 
         * AssignedFacilityNotReassignableIndicator Relationship: 
         * PORX_MT060340CA.Location4.substitutionConditionCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Influences 
         * whether the prescription may be transferred to a service 
         * delivery location other than the targeted dispenser.</p> 
         * <p>Indicates whether a dispenser to whom the prescription is 
         * targeted is a mandated or patient-preferred pharmacy.</p> 
         * Un-merged Business Name: 
         * AssignedFacilityNotReassignableIndicator Relationship: 
         * PORX_MT060160CA.Location5.substitutionConditionCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Influences 
         * whether the prescription may be transferred to a service 
         * delivery location other than the targeted dispenser.</p> 
         * <p>Indicates whether a dispenser to whom the prescription is 
         * targeted is a mandated or patient-preferred pharmacy.</p> 
         * Un-merged Business Name: 
         * DispenseFacilityNotAssignableIndicator Relationship: 
         * PORX_MT060190CA.Location3.substitutionConditionCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Influences 
         * whether the prescription may be transferred to a service 
         * delivery location other than the targeted dispenser.</p> 
         * <p>Indicates a 'hard' or 'soft' assignment of dispensing 
         * priviledged to the targeted facility.</p><p>'Hard' 
         * assignment (mandated facility) indicates that the 
         * prescription can be dispensed only at that 
         * facility.</p><p>'Soft' assignment (usually as a patient 
         * directive) indicates that the prescription may be dispensed 
         * at facilities other than the targeted facility.</p> 
         * Un-merged Business Name: DispenseFacilityNotReassignable 
         * Relationship: 
         * PORX_MT010120CA.Location2.substitutionConditionCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Influences 
         * whether the prescription may be transferred to a service 
         * delivery location other than the targeted dispenser.</p> 
         * <p>Indicates a 'hard' or 'soft' assignment of dispensing 
         * priviledged to the targetted facility.</p><p>'Hard' 
         * assignment (mandated facility) indicates that the 
         * prescription can be dispensed only at that 
         * facility.</p><p>'Soft' assignment (usually as a patient 
         * directive) indicates that the prescription may be dispensed 
         * at facilities other than the targeted facility.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"substitutionConditionCode"})]
        public x_SubstitutionConditionNoneOrUnconditional SubstitutionConditionCode {
            get { return (x_SubstitutionConditionNoneOrUnconditional) this.substitutionConditionCode.Value; }
            set { this.substitutionConditionCode.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT210003CA.Location3.contextControlCode 
         * Conformance/Cardinality: REQUIRED (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT210002CA.Location3.contextControlCode 
         * Conformance/Cardinality: REQUIRED (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT210001CA.Location3.contextControlCode 
         * Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"contextControlCode"})]
        public ContextControl ContextControlCode {
            get { return (ContextControl) this.contextControlCode.Value; }
            set { this.contextControlCode.Value = value; }
        }

    }

}