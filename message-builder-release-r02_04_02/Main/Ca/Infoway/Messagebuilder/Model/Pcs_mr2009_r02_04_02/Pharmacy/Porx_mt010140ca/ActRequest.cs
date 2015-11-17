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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Pharmacy.Porx_mt010140ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using System;
    using System.Collections.Generic;


    [Hl7PartTypeMappingAttribute(new string[] {"PORX_MT010140CA.ActRequest"})]
    public class ActRequest : MessagePartBean {

        private SET<II, Identifier> id;
        private BL preconditionVerificationEventCriterion;

        public ActRequest() {
            this.id = new SETImpl<II, Identifier>(typeof(IIImpl));
            this.preconditionVerificationEventCriterion = new BLImpl(false);
        }
        /**
         * <summary>Business Name: A:Prescription Order Number</summary>
         * 
         * <remarks>Relationship: PORX_MT010140CA.ActRequest.id 
         * Conformance/Cardinality: MANDATORY (1-2) <p>Allows 
         * prescriptions to be uniquely referenced. Multiple 
         * identifiers are allowed to support assigning of prescription 
         * ids by the prescriber, EHR, and potentially by 
         * pharmacies.</p><p>The ID is mandatory to allow every 
         * prescription record to be uniquely identified.</p> <p>This 
         * is an identifier assigned to a specific medication order. 
         * The number remains constant across the lifetime of the 
         * order, regardless of the number of providers or pharmacies 
         * involved in fulfilling the order.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public ICollection<Identifier> Id {
            get { return this.id.RawSet(); }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT010140CA.Precondition.verificationEventCriterion</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"precondition/verificationEventCriterion"})]
        public bool? PreconditionVerificationEventCriterion {
            get { return this.preconditionVerificationEventCriterion.Value; }
            set { this.preconditionVerificationEventCriterion.Value = value; }
        }

    }

}