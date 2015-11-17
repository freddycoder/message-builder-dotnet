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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Ra.Rcmr_mt010001ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged;
    using System;


    /**
     * <summary>Business Name: Consent</summary>
     * 
     * <p>If code is INFA, then InformDefinition must be present, 
     * otherwise it must be absent</p> <p>One and only one of 
     * author1 (Consenter) and author2 (Provider) must be 
     * specified</p> <p>If author2 (provider) is specified, 
     * reasonCode must be specified</p> <p>Provides authorization 
     * to record and/or view patient information.</p> 
     * <p>Information pertaining to a patient's 
     * agreement/acceptance to have his/her clinical information 
     * electronically stored and shared.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"RCMR_MT010001CA.ConsentEvent"})]
    public class Consent : MessagePartBean {

        private II id;
        private CV code;
        private BL negationInd;
        private IVL<TS, Interval<PlatformDate>> effectiveTime;
        private CV reasonCode;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Ra.Rcmr_mt010001ca.ConsentedToBy author1;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged.PrescribedBy author2;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Ra.Rcmr_mt010001ca.InformationAccess componentPermissionToInform;

        public Consent() {
            this.id = new IIImpl();
            this.code = new CVImpl();
            this.negationInd = new BLImpl();
            this.effectiveTime = new IVLImpl<TS, Interval<PlatformDate>>();
            this.reasonCode = new CVImpl();
        }
        /**
         * <summary>Business Name: D:Consent Form Number</summary>
         * 
         * <remarks>Relationship: RCMR_MT010001CA.ConsentEvent.id 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Provides a 
         * traceable audit link between a physical consent form and its 
         * electronic record</p> <p>A unique identifier for a specific 
         * consent for a patient.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Business Name: A:Consent Type</summary>
         * 
         * <remarks>Relationship: RCMR_MT010001CA.ConsentEvent.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Distinguishes what 
         * type of consent is being dealt with and is therefore 
         * mandatory.</p> <p>Indicates the type of consent being given: 
         * Information access or Information maintenance.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ActConsentType Code {
            get { return (ActConsentType) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: B:Consent Refused Indicator</summary>
         * 
         * <remarks>Relationship: 
         * RCMR_MT010001CA.ConsentEvent.negationInd 
         * Conformance/Cardinality: OPTIONAL (0-1) <p>Must be either 
         * not present or non-null.</p> <p>Primarily applies for global 
         * &quot;participation&quot; consent, when there is a need to 
         * track whether the patient has consented, not consented, or 
         * has not recorded a decision.</p><p>Because not all 
         * jurisdictions will track &quot;participation&quot; consent, 
         * this attribute is optional. In jurisdictions where it is 
         * supported, the element must always be valued as either true 
         * or false.</p> <p>If true, indicates that consent has 
         * explicitly *not* been given.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"negationInd"})]
        public bool? NegationInd {
            get { return this.negationInd.Value; }
            set { this.negationInd.Value = value; }
        }

        /**
         * <summary>Business Name: C:Consent Effective and End Time</summary>
         * 
         * <remarks>Relationship: 
         * RCMR_MT010001CA.ConsentEvent.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Most consents are 
         * not open-ended, to ensure the patient retains a level of 
         * control</p> <p>Indicates the time that the consent will 
         * expire. 'Low' is effective time and 'High' is end time.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"effectiveTime"})]
        public Interval<PlatformDate> EffectiveTime {
            get { return this.effectiveTime.Value; }
            set { this.effectiveTime.Value = value; }
        }

        /**
         * <summary>Business Name: E:Consent Override Reason</summary>
         * 
         * <remarks>Relationship: 
         * RCMR_MT010001CA.ConsentEvent.reasonCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Important for 
         * audit purposes</p> <p>Indicates a reason for overriding a 
         * patient's consent rules or accessing information without 
         * consent.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"reasonCode"})]
        public ActConsentInformationAccessOverrideReason ReasonCode {
            get { return (ActConsentInformationAccessOverrideReason) this.reasonCode.Value; }
            set { this.reasonCode.Value = value; }
        }

        /**
         * <summary>Relationship: RCMR_MT010001CA.ConsentEvent.author1</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"author1"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Ra.Rcmr_mt010001ca.ConsentedToBy Author1 {
            get { return this.author1; }
            set { this.author1 = value; }
        }

        /**
         * <summary>Relationship: RCMR_MT010001CA.ConsentEvent.author2</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"author2"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged.PrescribedBy Author2 {
            get { return this.author2; }
            set { this.author2 = value; }
        }

        /**
         * <summary>Relationship: 
         * RCMR_MT010001CA.Component.permissionToInform</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component/permissionToInform"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Ra.Rcmr_mt010001ca.InformationAccess ComponentPermissionToInform {
            get { return this.componentPermissionToInform; }
            set { this.componentPermissionToInform = value; }
        }

    }

}