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
    using Ca.Infoway.Messagebuilder.Model;
    using System;


    [Hl7PartTypeMappingAttribute(new string[] {"PRPM_MT301010CA.SequelTo","PRPM_MT303010CA.SequelTo"})]
    public class SequelTo : MessagePartBean {

        private INT sequenceNumber;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Pr.Merged.InformRequest informRequest;

        public SequelTo() {
            this.sequenceNumber = new INTImpl();
        }
        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PRPM_MT301010CA.SequelTo.sequenceNumber 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Required</p> 
         * Un-merged Business Name: (no business name specified) 
         * Relationship: PRPM_MT303010CA.SequelTo.sequenceNumber 
         * Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"sequenceNumber"})]
        public int? SequenceNumber {
            get { return this.sequenceNumber.Value; }
            set { this.sequenceNumber.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PRPM_MT301010CA.SequelTo.informRequest 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PRPM_MT303010CA.SequelTo.informRequest 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"informRequest"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Pr.Merged.InformRequest InformRequest {
            get { return this.informRequest; }
            set { this.informRequest = value; }
        }

    }

}