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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Ficr_mt490003ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using System;


    [Hl7PartTypeMappingAttribute(new string[] {"FICR_MT490003CA.SpecialAuthorizationAdditionalInformationRequest"})]
    public class SpecialAuthorizationAdditionalInformationRequest : MessagePartBean {

        private II id;
        private ST text;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Ficr_mt490003ca.SpecialAuthorizationRequest referenceSpecialAuthorizationRequest;

        public SpecialAuthorizationAdditionalInformationRequest() {
            this.id = new IIImpl();
            this.text = new STImpl();
        }
        /**
         * <summary>Business Name: Additional Information Request ID</summary>
         * 
         * <remarks>Relationship: 
         * FICR_MT490003CA.SpecialAuthorizationAdditionalInformationRequest.id 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Business Name: Additional Information Question</summary>
         * 
         * <remarks>Relationship: 
         * FICR_MT490003CA.SpecialAuthorizationAdditionalInformationRequest.text 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"text"})]
        public String Text {
            get { return this.text.Value; }
            set { this.text.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * FICR_MT490003CA.Reference.specialAuthorizationRequest</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"reference/specialAuthorizationRequest"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Ficr_mt490003ca.SpecialAuthorizationRequest ReferenceSpecialAuthorizationRequest {
            get { return this.referenceSpecialAuthorizationRequest; }
            set { this.referenceSpecialAuthorizationRequest = value; }
        }

    }

}