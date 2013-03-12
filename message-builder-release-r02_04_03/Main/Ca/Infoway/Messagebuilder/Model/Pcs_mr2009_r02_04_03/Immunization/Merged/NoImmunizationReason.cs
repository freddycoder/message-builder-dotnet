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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Immunization.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using System;


    /**
     * <summary>POIZ_MT030060CA.NoImmunizationReason: (no business 
     * name)</summary>
     * 
     * <p>Needed for explicitly communicating the reason why a 
     * patient was not administered as vaccine.</p> <p>Identifies 
     * the reason why an immunization event did not occur.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"POIZ_MT030050CA.NoImmunizationReason","POIZ_MT030060CA.NoImmunizationReason","POIZ_MT060150CA.NoImmunizationReason"})]
    public class NoImmunizationReason : MessagePartBean, Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged.IChoice {

        private ST text;
        private CV reasonCode;

        public NoImmunizationReason() {
            this.text = new STImpl();
            this.reasonCode = new CVImpl();
        }
        /**
         * <summary>Business Name: ImmunizationRefusalReasonText</summary>
         * 
         * <remarks>Un-merged Business Name: 
         * ImmunizationRefusalReasonText Relationship: 
         * POIZ_MT030060CA.NoImmunizationReason.text 
         * Conformance/Cardinality: OPTIONAL (0-1) <p>Provides 
         * additional context and description relating to the reason 
         * for not immunizing. Not all implementations will support 
         * text. As a result, this attribute is optional.</p> <p>A 
         * textual or multimedia description (or reference to a 
         * description) of the reason.</p> Un-merged Business Name: 
         * ImmunizationRefusalReasonText Relationship: 
         * POIZ_MT030050CA.NoImmunizationReason.text 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: ImmunizationRefusalReasonText Relationship: 
         * POIZ_MT060150CA.NoImmunizationReason.text 
         * Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"text"})]
        public String Text {
            get { return this.text.Value; }
            set { this.text.Value = value; }
        }

        /**
         * <summary>Business Name: ImmunizationRefusalReason</summary>
         * 
         * <remarks>Un-merged Business Name: ImmunizationRefusalReason 
         * Relationship: 
         * POIZ_MT030060CA.NoImmunizationReason.reasonCode 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows sorting and 
         * categorizing different kinds of refusal reasons. Ensures 
         * that reasons are gathered in a consistent analyzable manner. 
         * As a result, this attribute is mandatory.</p> <p>A coded 
         * value denoting a patient's reason for refusing to be 
         * immunized.</p><p>Typical reasons include: Parental decision, 
         * Religious exemption, Patient decision, previous adverse 
         * event etc.</p> Un-merged Business Name: 
         * ImmunizationRefusalReason Relationship: 
         * POIZ_MT030050CA.NoImmunizationReason.reasonCode 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: ImmunizationRefusalReason Relationship: 
         * POIZ_MT060150CA.NoImmunizationReason.reasonCode 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"reasonCode"})]
        public ActNoImmunizationReason ReasonCode {
            get { return (ActNoImmunizationReason) this.reasonCode.Value; }
            set { this.reasonCode.Value = value; }
        }

    }

}