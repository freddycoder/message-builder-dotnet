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
namespace Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Pr.Prpm_mt303013ab {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Pr.Merged;


    /**
     * <summary>Business Name: Healthcare Worker</summary>
     * 
     * <p>The class on which the update is occurring</p> 
     * <p>Identifies either the provider record whose license is 
     * being nullified</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PRPM_MT303013AB.HealthcareWorker"})]
    public class HealthcareWorker : MessagePartBean {

        private II id;
        private Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Pr.Merged.HealthcareProvider indirectAuthorityHealthCareProvider;

        public HealthcareWorker() {
            this.id = new IIImpl();
        }
        /**
         * <summary>Business Name: A: Healthcare Worker Identifier</summary>
         * 
         * <remarks>Relationship: PRPM_MT303013AB.HealthcareWorker.id 
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
         * <summary>Relationship: 
         * PRPM_MT303013AB.IndirectAuthorithyOver.healthCareProvider</summary>
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