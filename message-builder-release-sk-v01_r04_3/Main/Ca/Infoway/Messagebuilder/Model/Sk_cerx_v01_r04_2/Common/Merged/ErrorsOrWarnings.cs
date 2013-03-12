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
namespace Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Common.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: ErrorsOrWarnings</summary>
     * 
     * <remarks>MCCI_MT000200CA.AcknowledgementDetail: Errors or 
     * Warnings <p>An error, warning or information message 
     * associated with the message being acknowledged.</p> 
     * <p>Allows identification issues related to the parsing and 
     * low-level processing of the message.</p> 
     * MCCI_MT000300CA.AcknowledgementDetail: Errors or Warnings 
     * <p>An error, warning or information message associated with 
     * the message being acknowledged.</p> <p>Allows identification 
     * issues related to the parsing and low-level processing of 
     * the message.</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"MCCI_MT000200CA.AcknowledgementDetail","MCCI_MT000300CA.AcknowledgementDetail"})]
    public class ErrorsOrWarnings : MessagePartBean {

        private CS typeCode;
        private CV code;
        private ST text;
        private SET<ST, String> location;

        public ErrorsOrWarnings() {
            this.typeCode = new CSImpl();
            this.code = new CVImpl();
            this.text = new STImpl();
            this.location = new SETImpl<ST, String>(typeof(STImpl));
        }
        /**
         * <summary>Business Name: MessageType</summary>
         * 
         * <remarks>Un-merged Business Name: MessageType Relationship: 
         * MCCI_MT000200CA.AcknowledgementDetail.typeCode 
         * Conformance/Cardinality: MANDATORY (1) <p>Distinguishes 
         * between errors, warnings and information messages.</p> 
         * <p>Different types of messages have substantially different 
         * ramifications. As a result, the element is mandatory.</p> 
         * Un-merged Business Name: MessageType Relationship: 
         * MCCI_MT000300CA.AcknowledgementDetail.typeCode 
         * Conformance/Cardinality: MANDATORY (1) <p>Distinguishes 
         * between errors, warnings and information messages.</p> 
         * <p>Different types of messages have substantially different 
         * ramifications.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"typeCode"})]
        public AcknowledgementDetailType TypeCode {
            get { return (AcknowledgementDetailType) this.typeCode.Value; }
            set { this.typeCode.Value = value; }
        }

        /**
         * <summary>Business Name: ResponseCode</summary>
         * 
         * <remarks>Un-merged Business Name: ResponseCode Relationship: 
         * MCCI_MT000200CA.AcknowledgementDetail.code 
         * Conformance/Cardinality: POPULATED (1) <p>Indicates the 
         * specific issue represented by this message.</p> <p>By 
         * providing coded identification of issues and errors, allows 
         * applications to have logic that manages particular errors 
         * and warnings automatically. However in some circumstances, a 
         * code may not be available. Therefore the attribute is marked 
         * as 'populated'.</p> Un-merged Business Name: ResponseCode 
         * Relationship: MCCI_MT000300CA.AcknowledgementDetail.code 
         * Conformance/Cardinality: POPULATED (1) <p>Indicates the 
         * specific issue represented by this message.</p> <p>By 
         * providing coded identification of issues and errors, allows 
         * applications to have logic that manages particular errors 
         * and warnings automatically. However in some circumstances, a 
         * code may not be available. Therefore the attribute is marked 
         * as 'populated'.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public AcknowledgementDetailCode Code {
            get { return (AcknowledgementDetailCode) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: MessageDescription</summary>
         * 
         * <remarks>Un-merged Business Name: MessageDescription 
         * Relationship: MCCI_MT000200CA.AcknowledgementDetail.text 
         * Conformance/Cardinality: REQUIRED (0-1) <p>The 
         * human-readable description of the error, warning or 
         * information message. May convey additional details not 
         * present in the 'code', but is not intended to be 
         * human-processable.</p> <p>Allows supplementing the 
         * 'computer' information for human-readability.</p> Un-merged 
         * Business Name: MessageDescription Relationship: 
         * MCCI_MT000300CA.AcknowledgementDetail.text 
         * Conformance/Cardinality: REQUIRED (0-1) <p>The 
         * human-readable description of the error, warning or 
         * information message. May convey additional details not 
         * present in the 'code', but is not intended to be 
         * human-processable.</p> <p>Allows supplementing the 
         * 'computer' information for human-readability.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"text"})]
        public String Text {
            get { return this.text.Value; }
            set { this.text.Value = value; }
        }

        /**
         * <summary>Business Name: ReferencedMessageLocations</summary>
         * 
         * <remarks>Un-merged Business Name: ReferencedMessageLocations 
         * Relationship: MCCI_MT000200CA.AcknowledgementDetail.location 
         * Conformance/Cardinality: REQUIRED (0-5) <p>Indicates the 
         * location of the elements within the message instance that 
         * triggered this error, warning or information message.</p> 
         * <p>Allows syntax and other messages to be linked to 
         * particular fields within the message.</p> <p>I.e. only the 
         * default 'child' axis is permitted, occurrence numbers are 
         * always specified, and no other predicates are permitted.</p> 
         * Un-merged Business Name: ReferencedMessageLocations 
         * Relationship: MCCI_MT000300CA.AcknowledgementDetail.location 
         * Conformance/Cardinality: REQUIRED (0-5) <p>Indicates the 
         * location of the elements within the message instance that 
         * triggered this error, warning or information message.</p> 
         * <p>Allows syntax and other messages to be linked to 
         * particular fields within the message.</p> <p>I.e. only the 
         * default 'child' axis is permitted, occurrence numbers are 
         * always specified, and no other predicates are permitted.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"location"})]
        public ICollection<String> Location {
            get { return this.location.RawSet(); }
        }

    }

}