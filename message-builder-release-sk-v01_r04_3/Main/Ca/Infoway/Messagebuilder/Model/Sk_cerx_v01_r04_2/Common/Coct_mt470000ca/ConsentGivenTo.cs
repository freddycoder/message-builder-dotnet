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
namespace Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Common.Coct_mt470000ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Common.Coct_mt090107ca;
    using Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Common.Coct_mt240003ca;
    using Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Merged;


    /**
     * <summary>Business Name: *consent given to</summary>
     * 
     * <p>Identifies the beneficiary of the consent as being a 
     * Provider or Service Location.</p> <p>Indicates who is 
     * receiving consent to view information.</p><p>This 
     * participation is marked as &quot;populated&quot; as receiver 
     * must be specified when keyword is involved.</p> <p>Indicates 
     * who is receiving consent to view information.</p><p>This 
     * participation is marked as &quot;populated&quot; as receiver 
     * must be specified when keyword is involved.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"COCT_MT470000CA.Receiver"})]
    public class ConsentGivenTo : MessagePartBean {

        private Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Merged.IRecipient recipient;

        public ConsentGivenTo() {
        }
        /**
         * <summary>Relationship: COCT_MT470000CA.Receiver.recipient</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"recipient"})]
        public Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Merged.IRecipient Recipient {
            get { return this.recipient; }
            set { this.recipient = value; }
        }

        public Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Common.Coct_mt090107ca.Provider RecipientAsAssignedPerson {
            get { return this.recipient is Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Common.Coct_mt090107ca.Provider ? (Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Common.Coct_mt090107ca.Provider) this.recipient : (Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Common.Coct_mt090107ca.Provider) null; }
        }
        public bool HasRecipientAsAssignedPerson() {
            return (this.recipient is Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Common.Coct_mt090107ca.Provider);
        }

        public Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Common.Coct_mt240003ca.ServiceLocation RecipientAsServiceDeliveryLocation {
            get { return this.recipient is Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Common.Coct_mt240003ca.ServiceLocation ? (Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Common.Coct_mt240003ca.ServiceLocation) this.recipient : (Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Common.Coct_mt240003ca.ServiceLocation) null; }
        }
        public bool HasRecipientAsServiceDeliveryLocation() {
            return (this.recipient is Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Common.Coct_mt240003ca.ServiceLocation);
        }

    }

}