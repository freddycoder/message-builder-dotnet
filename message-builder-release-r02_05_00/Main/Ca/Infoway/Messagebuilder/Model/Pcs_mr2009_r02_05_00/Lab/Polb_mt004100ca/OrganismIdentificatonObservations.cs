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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Polb_mt004100ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Merged;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: Organism Identificaton Observations</summary>
     * 
     * <p>Describes the observation associated with the 
     * identification of the organism.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"POLB_MT004100CA.OrganismIdentificationEvent"})]
    public class OrganismIdentificatonObservations : MessagePartBean {

        private CD code;
        private CS statusCode;
        private IVL<TS, Interval<PlatformDate>> effectiveTime;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Polb_mt004100ca.IsolateParticipation specimen;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged.Includes> subjectOf1;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Merged.ResultStatusProcessStep subjectOf2ResultStatusProcessStep;

        public OrganismIdentificatonObservations() {
            this.code = new CDImpl();
            this.statusCode = new CSImpl();
            this.effectiveTime = new IVLImpl<TS, Interval<PlatformDate>>();
            this.subjectOf1 = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged.Includes>();
        }
        /**
         * <summary>Business Name: Organism Identification Type</summary>
         * 
         * <remarks>Relationship: 
         * POLB_MT004100CA.OrganismIdentificationEvent.code 
         * Conformance/Cardinality: REQUIRED (1) <p>Describes the type 
         * of organism identification observation and is bound to the 
         * LOINC code domain (e.g. 612-2).</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public CultureObservationType Code {
            get { return (CultureObservationType) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: Organsim Identification Observation 
         * Status</summary>
         * 
         * <remarks>Relationship: 
         * POLB_MT004100CA.OrganismIdentificationEvent.statusCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Status associated 
         * with the organism identification observation.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"statusCode"})]
        public ActStatus StatusCode {
            get { return (ActStatus) this.statusCode.Value; }
            set { this.statusCode.Value = value; }
        }

        /**
         * <summary>Business Name: Organism Observation Effective Time</summary>
         * 
         * <remarks>Relationship: 
         * POLB_MT004100CA.OrganismIdentificationEvent.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Effective time of 
         * the Organism Observation.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"effectiveTime"})]
        public Interval<PlatformDate> EffectiveTime {
            get { return this.effectiveTime.Value; }
            set { this.effectiveTime.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * POLB_MT004100CA.OrganismIdentificationEvent.specimen</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"specimen"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Polb_mt004100ca.IsolateParticipation Specimen {
            get { return this.specimen; }
            set { this.specimen = value; }
        }

        /**
         * <summary>Relationship: 
         * POLB_MT004100CA.OrganismIdentificationEvent.subjectOf1</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-100)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf1"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged.Includes> SubjectOf1 {
            get { return this.subjectOf1; }
        }

        /**
         * <summary>Relationship: 
         * POLB_MT004100CA.Subject3.resultStatusProcessStep</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf2/resultStatusProcessStep"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Merged.ResultStatusProcessStep SubjectOf2ResultStatusProcessStep {
            get { return this.subjectOf2ResultStatusProcessStep; }
            set { this.subjectOf2ResultStatusProcessStep = value; }
        }

    }

}