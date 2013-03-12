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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Pr.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;


    [Hl7PartTypeMappingAttribute(new string[] {"PRPM_MT306011CA.PrimaryPerformer3","PRPM_MT309000CA.PrimaryPerformer3"})]
    public class PrimaryPerformer3 : MessagePartBean {

        private CS typeCode;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Pr.Merged.ActDefinitionOrEventName_2 actDefinitionOrEvent;

        public PrimaryPerformer3() {
            this.typeCode = new CSImpl();
        }
        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PRPM_MT306011CA.PrimaryPerformer3.typeCode 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PRPM_MT309000CA.PrimaryPerformer3.typeCode 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"typeCode"})]
        public ParticipationType TypeCode {
            get { return (ParticipationType) this.typeCode.Value; }
            set { this.typeCode.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PRPM_MT306011CA.PrimaryPerformer3.actDefinitionOrEvent 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PRPM_MT309000CA.PrimaryPerformer3.actDefinitionOrEvent 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"actDefinitionOrEvent"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Pr.Merged.ActDefinitionOrEventName_2 ActDefinitionOrEvent {
            get { return this.actDefinitionOrEvent; }
            set { this.actDefinitionOrEvent = value; }
        }

    }

}