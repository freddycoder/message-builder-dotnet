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
namespace Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Pr.Prpm_mt303011ab {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Pr.Merged;
    using System;


    /**
     * <summary>Business Name: Healthcare Worker</summary>
     * 
     * <p>HealthcareWorker MUST have a relatedTo relationship if it 
     * is the &quot;root&quot; (has no ancestor HealthCareWorker 
     * classes) and MUST NOT have a relatedTo relationship if it is 
     * not the &quot;root&quot;.</p> <p>Identifies the providers 
     * being linked</p> <p>Identifies either the source or the 
     * target of the link (depending on which end of the relatedTo 
     * association it's on)</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PRPM_MT303011AB.HealthcareWorker"})]
    public class HealthcareWorker : MessagePartBean {

        private II id;
        private IVL<TS, Interval<PlatformDate>> relatedToEffectiveTime;
        private Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Pr.Prpm_mt303011ab.HealthcareWorker relatedToHealthcareWorker;
        private Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Pr.Merged.HealthcareProvider indirectAuthorityHealthCareProvider;

        public HealthcareWorker() {
            this.id = new IIImpl();
            this.relatedToEffectiveTime = new IVLImpl<TS, Interval<PlatformDate>>();
        }
        /**
         * <summary>Business Name: A: Healthcare Worker Identifier</summary>
         * 
         * <remarks>Relationship: PRPM_MT303011AB.HealthcareWorker.id 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows unique 
         * identification of the person which can be critical for 
         * authentication, permissions, drill-down and traceability and 
         * is therefore mandatory.</p> <p>Unique identifier the person 
         * involved in the action.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Business Name: Link Time</summary>
         * 
         * <remarks>Relationship: 
         * PRPM_MT303011AB.RelatedTo.effectiveTime 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows the fact 
         * that this transaction is establishing a link to be clearly 
         * communicated.</p> <p>Indicates the date and time at which 
         * the link from target provider role is considered to be 
         * created to the source provider role</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"relatedTo/effectiveTime"})]
        public Interval<PlatformDate> RelatedToEffectiveTime {
            get { return this.relatedToEffectiveTime.Value; }
            set { this.relatedToEffectiveTime.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * PRPM_MT303011AB.RelatedTo.healthcareWorker</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"relatedTo/healthcareWorker"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Pr.Prpm_mt303011ab.HealthcareWorker RelatedToHealthcareWorker {
            get { return this.relatedToHealthcareWorker; }
            set { this.relatedToHealthcareWorker = value; }
        }

        /**
         * <summary>Relationship: 
         * PRPM_MT303011AB.IndirectAuthorithyOver.healthCareProvider</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"indirectAuthority/healthCareProvider"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Pr.Merged.HealthcareProvider IndirectAuthorityHealthCareProvider {
            get { return this.indirectAuthorityHealthCareProvider; }
            set { this.indirectAuthorityHealthCareProvider = value; }
        }

    }

}