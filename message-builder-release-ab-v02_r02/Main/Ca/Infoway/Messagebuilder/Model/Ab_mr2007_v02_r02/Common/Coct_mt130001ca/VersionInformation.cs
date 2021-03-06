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
/* This class was auto-generated by the message builder generator tools. */
namespace Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Coct_mt130001ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Coct_mt090108ca;
    using Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Coct_mt090508ca;
    using Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Coct_mt910108ca;
    using Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Coct_mt911108ca;
    using System;


    /**
     * <summary>Business Name: Version Information</summary>
     * 
     * <p>This records the history of changes that have been made 
     * to the record, including why the changes were made, who made 
     * them and when.</p> <p>Provides a record changes, providing 
     * deeper clinical understanding, particularly of past clinical 
     * decisions.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"COCT_MT130001CA.ControlActEvent"})]
    public class VersionInformation : MessagePartBean {

        private II id;
        private CV code;
        private IVL<TS, Interval<PlatformDate>> effectiveTime;
        private CV reasonCode;
        private TS authorTime;
        private Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Coct_mt911108ca.IActingPerson authorActingPerson;

        public VersionInformation() {
            this.id = new IIImpl();
            this.code = new CVImpl();
            this.effectiveTime = new IVLImpl<TS, Interval<PlatformDate>>();
            this.reasonCode = new CVImpl();
            this.authorTime = new TSImpl();
        }
        /**
         * <summary>Business Name: B:Change Identifier</summary>
         * 
         * <remarks>Relationship: COCT_MT130001CA.ControlActEvent.id 
         * Conformance/Cardinality: MANDATORY (1) <p>A unique 
         * identifier for this particular change.</p> <p>Allows 
         * referencing (and potentially undoing) a specific change. 
         * Every status change has an identifier, thus this attribute 
         * is mandatory.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Business Name: A:Change Type</summary>
         * 
         * <remarks>Relationship: COCT_MT130001CA.ControlActEvent.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Identifies what 
         * kind of change occurred.</p> <p>This attribute is mandatory 
         * to ensure that change types are distinguishable.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public HL7TriggerEventCode Code {
            get { return (HL7TriggerEventCode) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: C:Change Effective Date and End Date</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT130001CA.ControlActEvent.effectiveTime 
         * Conformance/Cardinality: MANDATORY (1) <p>The date on which 
         * the various changes of an event become valid and applicable 
         * and potentially when the change is supposed to cease.</p> 
         * <p>Allows applications to sort and filter by time. The date 
         * on which a change is effective should always be known and 
         * thus is mandatory. The end date may be left unspecified if 
         * there isn't a specific targetted end date (e.g. with a 
         * suspend including a planned release date).</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"effectiveTime"})]
        public Interval<PlatformDate> EffectiveTime {
            get { return this.effectiveTime.Value; }
            set { this.effectiveTime.Value = value; }
        }

        /**
         * <summary>Business Name: D:Change Reason</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT130001CA.ControlActEvent.reasonCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Denotes the 
         * reason the record was modified.</p> <p>Ensures consistent 
         * terminology in capturing and interpreting reasons for 
         * change. Allows CWE because not all reasons will correspond 
         * to a pre-defined code.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"reasonCode"})]
        public ControlActReason ReasonCode {
            get { return (ControlActReason) this.reasonCode.Value; }
            set { this.reasonCode.Value = value; }
        }

        /**
         * <summary>Business Name: Change Datetime</summary>
         * 
         * <remarks>Relationship: COCT_MT130001CA.Author3.time 
         * Conformance/Cardinality: MANDATORY (1) <p>The date on which 
         * the change was made. Note that this may be earlier or 
         * occassionally later than when the change is actually 
         * effective.</p> <p>Gives other providers the frame of 
         * reference in evaluating any post-change issues with the 
         * event. Also used for sorting and audit purposes. Time of 
         * change is always known and thus the attribute is 
         * mandatory.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"author/time"})]
        public PlatformDate AuthorTime {
            get { return this.authorTime.Value; }
            set { this.authorTime.Value = value; }
        }

        /**
         * <summary>Relationship: COCT_MT130001CA.Author3.actingPerson</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"author/actingPerson"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Coct_mt911108ca.IActingPerson AuthorActingPerson {
            get { return this.authorActingPerson; }
            set { this.authorActingPerson = value; }
        }

        public Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Coct_mt090108ca.HealthcareWorker AuthorActingPersonAsAssignedEntity1 {
            get { return this.authorActingPerson is Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Coct_mt090108ca.HealthcareWorker ? (Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Coct_mt090108ca.HealthcareWorker) this.authorActingPerson : (Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Coct_mt090108ca.HealthcareWorker) null; }
        }
        public bool HasAuthorActingPersonAsAssignedEntity1() {
            return (this.authorActingPerson is Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Coct_mt090108ca.HealthcareWorker);
        }

        public Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Coct_mt090508ca.HealthcareOrganization AuthorActingPersonAsAssignedEntity2 {
            get { return this.authorActingPerson is Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Coct_mt090508ca.HealthcareOrganization ? (Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Coct_mt090508ca.HealthcareOrganization) this.authorActingPerson : (Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Coct_mt090508ca.HealthcareOrganization) null; }
        }
        public bool HasAuthorActingPersonAsAssignedEntity2() {
            return (this.authorActingPerson is Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Coct_mt090508ca.HealthcareOrganization);
        }

        public Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Coct_mt910108ca.RelatedPerson AuthorActingPersonAsPersonalRelationship {
            get { return this.authorActingPerson is Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Coct_mt910108ca.RelatedPerson ? (Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Coct_mt910108ca.RelatedPerson) this.authorActingPerson : (Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Coct_mt910108ca.RelatedPerson) null; }
        }
        public bool HasAuthorActingPersonAsPersonalRelationship() {
            return (this.authorActingPerson is Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Coct_mt910108ca.RelatedPerson);
        }

    }

}