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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Iehr.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: Referral</summary>
     * 
     * <remarks>REPC_MT210002CA.PatientCareProvisionRequest: 
     * C:Referral <p>Provides contextual overview information for 
     * searching and filtering</p> <p>Discrete information about 
     * the type of care being requested.</p> 
     * REPC_MT210003CA.PatientCareProvisionRequest: C:Referral 
     * <p>Provides contextual overview information for searching 
     * and filtering</p> <p>Discrete information about the type of 
     * care being requested.</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"REPC_MT210001CA.PatientCareProvisionRequest","REPC_MT210002CA.PatientCareProvisionRequest","REPC_MT210003CA.PatientCareProvisionRequest"})]
    public class Referral : MessagePartBean, Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Iehr.Repc_mt210001ca.IDocumentContent, Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Iehr.Merged.IDocumentContent_1 {

        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged.BecauseOf> reason;
        private CD code;
        private CS statusCode;
        private IVL<TS, Interval<PlatformDate>> effectiveTime;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged.AdministeredBy performer;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged.OccurredAt location;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Iehr.Merged.ActRequest2 componentActRequest;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged.CareCompositions fulfillmentPatientCareProvisionEvent;

        public Referral() {
            this.reason = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged.BecauseOf>();
            this.code = new CDImpl();
            this.statusCode = new CSImpl();
            this.effectiveTime = new IVLImpl<TS, Interval<PlatformDate>>();
        }
        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT210002CA.DocumentContent.reason 
         * Conformance/Cardinality: REQUIRED (0-5) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT210001CA.DocumentContent.reason 
         * Conformance/Cardinality: REQUIRED (0-5) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT210003CA.DocumentContent.reason 
         * Conformance/Cardinality: REQUIRED (0-5)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"reason"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged.BecauseOf> Reason {
            get { return this.reason; }
        }

        /**
         * <summary>Business Name: ReferralType</summary>
         * 
         * <remarks>Un-merged Business Name: ReferralType Relationship: 
         * REPC_MT210002CA.PatientCareProvisionRequest.code 
         * Conformance/Cardinality: MANDATORY (1) <p> <i>Referral Type 
         * is used for searching and for organizing Referral records as 
         * well as sorting them for presentation.</i> </p><p> <i>This 
         * is a key attribute for understanding the type of record and 
         * is therefore mandatory.</i> </p><p> <i>This element makes 
         * use of the CD datatype to allow for use of the SNOMED code 
         * system that in some circumstances requires the use of 
         * post-coordination. Post-coordination is only supported by 
         * the CD datatype.</i> </p> <p>Concepts identifying different 
         * types of referral request document. These codes identify the 
         * general type of care services requested. They are not used 
         * to represent the indication or diagnosis which triggered the 
         * need for the referral.</p> Un-merged Business Name: 
         * ReferralType Relationship: 
         * REPC_MT210001CA.PatientCareProvisionRequest.code 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: ReferralType Relationship: 
         * REPC_MT210003CA.PatientCareProvisionRequest.code 
         * Conformance/Cardinality: MANDATORY (1) <p> <i>Referral Type 
         * is used for searching and for organizing Referral records as 
         * well as sorting them for presentation.</i> </p><p> <i>This 
         * is a key attribute for understanding the type of record and 
         * is therefore mandatory.</i> </p><p> <i>This element makes 
         * use of the CD datatype to allow for use of the SNOMED code 
         * system that in some circumstances requires the use of 
         * post-coordination. Post-coordination is only supported by 
         * the CD datatype.</i> </p> <p>Concepts identifying different 
         * types of referral request document. These codes identify the 
         * general type of care services requested. They are not used 
         * to represent the indication or diagnosis which triggered the 
         * need for the referral.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ActCareProvisionRequestType Code {
            get { return (ActCareProvisionRequestType) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: ReferralStatus</summary>
         * 
         * <remarks>Un-merged Business Name: ReferralStatus 
         * Relationship: 
         * REPC_MT210002CA.PatientCareProvisionRequest.statusCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p> <i>Status is 
         * frequently used to filter query responses as well as to sort 
         * records for presentation. It also affects how the Referral 
         * record is interpreted.</i> </p><p> <i>Because the status 
         * won't always be known, the attribute is marked as 
         * 'populated' to allow the use of null flavors.</i> </p><p>It 
         * is important to note that the EHR is not expected to perform 
         * status management of referrals. Thus it is up to clinicians 
         * to amend the status of a referral when it has changed to 
         * complete.</p> <p> <i>This identifies the current state of 
         * the Referral record.</i> </p><p>If the status is 'active' it 
         * means the request is still outstanding or in progress. If 
         * the status is 'complete' it means that the referral has been 
         * acted upon and the referral is considered closed. If the 
         * status is 'aborted' it means the request made by the 
         * referral has been withdrawn.</p> Un-merged Business Name: 
         * ReferralStatus Relationship: 
         * REPC_MT210001CA.PatientCareProvisionRequest.statusCode 
         * Conformance/Cardinality: REQUIRED (0-1) Un-merged Business 
         * Name: ReferralStatus Relationship: 
         * REPC_MT210003CA.PatientCareProvisionRequest.statusCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p> <i>Status is 
         * frequently used to filter query responses as well as to sort 
         * records for presentation. It also affects how the Referral 
         * record is interpreted.</i> </p><p> <i>Because the status 
         * won't always be known, the attribute is marked as 
         * 'populated' to allow the use of null flavors.</i> </p><p>It 
         * is important to note that the EHR is not expected to perform 
         * status management of referrals. Thus it is up to clinicians 
         * to amend the status of a referral when it has changed to 
         * complete.</p> <p> <i>This identifies the current state of 
         * the Referral record.</i> </p><p>If the status is 'active' it 
         * means the request is still outstanding or in progress. If 
         * the status is 'complete' it means that the referral has been 
         * acted upon and the referral is considered closed. If the 
         * status is 'aborted' it means the request made by the 
         * referral has been withdrawn.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"statusCode"})]
        public x_ActStatusActiveComplete StatusCode {
            get { return (x_ActStatusActiveComplete) this.statusCode.Value; }
            set { this.statusCode.Value = value; }
        }

        /**
         * <summary>Business Name: ReferralRequestedByTime</summary>
         * 
         * <remarks>Un-merged Business Name: ReferralRequestedByTime 
         * Relationship: 
         * REPC_MT210002CA.PatientCareProvisionRequest.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p> <i>Identifies 
         * the time-period of relevance to the record that is useful in 
         * filtering and organizing &quot;time-view&quot; presentations 
         * of data. Because the timing information won't always be 
         * known, this attribute is marked as 'populated'.</i> 
         * </p><p>Identifies the time-period of relevance to the record 
         * which is useful in filtering and organizing 
         * &quot;time-view&quot; presentations of data.</p> 
         * <p>Indicates the target date by which the referring provider 
         * hopes the requested assessment could be completed.</p> 
         * Un-merged Business Name: ReferralRequestedByTime 
         * Relationship: 
         * REPC_MT210001CA.PatientCareProvisionRequest.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1) Un-merged Business 
         * Name: ReferralRequestedByTime Relationship: 
         * REPC_MT210003CA.PatientCareProvisionRequest.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p> <i>Identifies 
         * the time-period of relevance to the record that is useful in 
         * filtering and organizing &quot;time-view&quot; presentations 
         * of data. Because the timing information won't always be 
         * known, this attribute is marked as 'populated'.</i> 
         * </p><p>Identifies the time-period of relevance to the record 
         * which is useful in filtering and organizing 
         * &quot;time-view&quot; presentations of data.</p> 
         * <p>Indicates the target date by which the referring provider 
         * hopes the requested assessment could be completed.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"effectiveTime"})]
        public Interval<PlatformDate> EffectiveTime {
            get { return this.effectiveTime.Value; }
            set { this.effectiveTime.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT210002CA.PatientCareProvisionRequest.performer 
         * Conformance/Cardinality: REQUIRED (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT210001CA.PatientCareProvisionRequest.performer 
         * Conformance/Cardinality: REQUIRED (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT210003CA.PatientCareProvisionRequest.performer 
         * Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"performer"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged.AdministeredBy Performer {
            get { return this.performer; }
            set { this.performer = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT210002CA.PatientCareProvisionRequest.location 
         * Conformance/Cardinality: REQUIRED (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT210001CA.PatientCareProvisionRequest.location 
         * Conformance/Cardinality: REQUIRED (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT210003CA.PatientCareProvisionRequest.location 
         * Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"location"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged.OccurredAt Location {
            get { return this.location; }
            set { this.location = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: REPC_MT210002CA.Component8.actRequest 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT210001CA.Component8.actRequest 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT210003CA.Component8.actRequest 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component/actRequest"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Iehr.Merged.ActRequest2 ComponentActRequest {
            get { return this.componentActRequest; }
            set { this.componentActRequest = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT210002CA.InFulfillmentOf2.patientCareProvisionEvent 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT210001CA.InFulfillmentOf2.patientCareProvisionEvent 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT210003CA.InFulfillmentOf2.patientCareProvisionEvent 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"fulfillment/patientCareProvisionEvent"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged.CareCompositions FulfillmentPatientCareProvisionEvent {
            get { return this.fulfillmentPatientCareProvisionEvent; }
            set { this.fulfillmentPatientCareProvisionEvent = value; }
        }

    }

}