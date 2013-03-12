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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Model;


    /**
     * <summary>Business Name: ConsentGivenTo</summary>
     * 
     * <remarks>RCMR_MT010001CA.Receiver: *consent given to 
     * <p>Indicates who is being authorized to receive the 
     * information, and is therefore populated.</p> <p>Identifies 
     * the beneficiary of the consent as being a Provider or 
     * Service Location.</p> COCT_MT470012CA.Receiver: *consent 
     * given to <p>Indicates who is receiving consent to view 
     * information.</p><p>This participation is marked as 
     * &quot;populated&quot; as receiver must be specified when 
     * keyword is involved.</p> <p>Identifies the beneficiary of 
     * the consent as being a Provider or Service Location.</p> 
     * COCT_MT470002CA.Receiver: *consent given to <p>Indicates who 
     * is receiving consent to view information.</p><p>This 
     * participation is marked as &quot;populated&quot; as receiver 
     * must be specified when keyword is involved.</p> 
     * <p>Identifies the beneficiary of the consent as being a 
     * Provider or Service Location.</p> POIZ_MT030060CA.Receiver: 
     * (no business name) <p>Indicates who is receiving consent to 
     * administer the vaccine. This information may not always be 
     * known. As a result, this association is required.</p> 
     * <p>Identifies the beneficiary of the consent.</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"COCT_MT470002CA.Receiver","COCT_MT470012CA.Receiver","POIZ_MT030050CA.Receiver","POIZ_MT030060CA.Receiver","POIZ_MT060150CA.Receiver","RCMR_MT010001CA.Receiver"})]
    public class ConsentGivenTo : MessagePartBean {

        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged.IRecipient recipient;

        public ConsentGivenTo() {
        }
        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: RCMR_MT010001CA.Receiver.recipient 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * COCT_MT470012CA.Receiver.recipient Conformance/Cardinality: 
         * POPULATED (1) Un-merged Business Name: (no business name 
         * specified) Relationship: COCT_MT470002CA.Receiver.recipient 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * POIZ_MT030060CA.Receiver.recipient Conformance/Cardinality: 
         * POPULATED (1) Un-merged Business Name: (no business name 
         * specified) Relationship: POIZ_MT060150CA.Receiver.recipient 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * POIZ_MT030050CA.Receiver.recipient Conformance/Cardinality: 
         * POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"recipient"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged.IRecipient Recipient {
            get { return this.recipient; }
            set { this.recipient = value; }
        }

    }

}