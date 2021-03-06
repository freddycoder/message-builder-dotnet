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
namespace Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Si.Rcmr_mt010001ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: Information Access</summary>
     * 
     * <p>Describes the type of information access being consented 
     * to.</p> <p>Allows fine-grained control over the types of 
     * information access is granted to and who is granted 
     * access.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"RCMR_MT010001CA.PermissionToInform"})]
    public class InformationAccess : MessagePartBean {

        private Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Si.Rcmr_mt010001ca.ConsentGivenTo receiver;
        private IList<CV> subjectRecordTypeCode;

        public InformationAccess() {
            this.subjectRecordTypeCode = new List<CV>();
        }
        /**
         * <summary>Relationship: 
         * RCMR_MT010001CA.PermissionToInform.receiver</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1) 
         * <p>&nbsp;Identifies the beneficiary of the consent as being 
         * a</p> <div>Provider or Service Location.</div></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"receiver"})]
        public Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Si.Rcmr_mt010001ca.ConsentGivenTo Receiver {
            get { return this.receiver; }
            set { this.receiver = value; }
        }

        /**
         * <summary>Business Name: B:Consent Information Types</summary>
         * 
         * <remarks>Relationship: RCMR_MT010001CA.RecordType.code 
         * Conformance/Cardinality: MANDATORY (1) <p>The type of 
         * patient information that can be accessed or modified.</p> 
         * <p>Different consents may need access to different types of 
         * patient information (e.g. demographics, medications, 
         * allergies, lab results). Understanding the type of 
         * information the consent applies to is critical to 
         * controlling access, and therefore the attribute is 
         * mandatory.</p> <p>Must be either ACALLG or ACMED.&nbsp;</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subject/recordType/code"})]
        public IList<ActInformationAccessTypeCode> SubjectRecordTypeCode {
            get { return new RawListWrapper<CV, ActInformationAccessTypeCode>(subjectRecordTypeCode, typeof(CVImpl)); }
        }

    }

}