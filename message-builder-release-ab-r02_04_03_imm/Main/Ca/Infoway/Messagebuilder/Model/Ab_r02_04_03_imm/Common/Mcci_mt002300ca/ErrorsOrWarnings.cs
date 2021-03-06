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
namespace Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Mcci_mt002300ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: Errors or Warnings</summary>
     * 
     * <p>Allows identification issues related to the parsing and 
     * low-level processing of the message.</p> <p>An error, 
     * warning or information message associated with the message 
     * being acknowledged.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"MCCI_MT002300CA.AcknowledgementDetail"})]
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
         * <summary>Business Name: Message type</summary>
         * 
         * <remarks>Relationship: 
         * MCCI_MT002300CA.AcknowledgementDetail.typeCode 
         * Conformance/Cardinality: MANDATORY (1) <p>Different types of 
         * messages have substantially different ramifications.</p> 
         * <p>Distinguishes between errors, warnings and information 
         * messages.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"typeCode"})]
        public AcknowledgementDetailType TypeCode {
            get { return (AcknowledgementDetailType) this.typeCode.Value; }
            set { this.typeCode.Value = value; }
        }

        /**
         * <summary>Business Name: A:Response Code</summary>
         * 
         * <remarks>Relationship: 
         * MCCI_MT002300CA.AcknowledgementDetail.code 
         * Conformance/Cardinality: REQUIRED (1) <p>By providing coded 
         * identification of issues and errors, allows applications to 
         * have logic that manages particular errors and warnings 
         * automatically. However in some circumstances, a code may not 
         * be available. Therefore the attribute is marked as 
         * 'populated'.</p><p>The coding strength is CWE (coded with 
         * extensions). The use of local codes is only permitted when 
         * those codes are submitted to the SC for consideration and if 
         * the SC makes a recommendation other then adoption of the 
         * local code, jurisdictions are bound to adopt the 
         * recommendation.</p> <p>Indicates the specific issue 
         * represented by this message.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public AcknowledgementDetailCode Code {
            get { return (AcknowledgementDetailCode) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: C:Message Description</summary>
         * 
         * <remarks>Relationship: 
         * MCCI_MT002300CA.AcknowledgementDetail.text 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Allows 
         * supplementing the 'computer' information for 
         * human-readability.</p> <p>The human-readable description of 
         * the error, warning or information message. May convey 
         * additional details not present in the 'code', but is not 
         * intended to be human-processable.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"text"})]
        public String Text {
            get { return this.text.Value; }
            set { this.text.Value = value; }
        }

        /**
         * <summary>Business Name: B:Referenced Message Locations</summary>
         * 
         * <remarks>Relationship: 
         * MCCI_MT002300CA.AcknowledgementDetail.location 
         * Conformance/Cardinality: REQUIRED (0-5) <p>Allows syntax and 
         * other messages to be linked to particular fields within the 
         * message.</p> <p>For XML, the string will be the simple XPath 
         * needed to reach the message element. Simple XPath has the 
         * format: (&quot;/&quot; &quot;@&quot;?elementName 
         * &quot;[&quot; occurrence &quot;]&quot;)+</p><p>I.e. only the 
         * default 'child' axis is permitted, occurrence numbers are 
         * always specified, and no other predicates are permitted.</p> 
         * <p>Indicates the location of the elements within the message 
         * instance that triggered this error, warning or information 
         * message.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"location"})]
        public ICollection<String> Location {
            get { return this.location.RawSet(); }
        }

    }

}