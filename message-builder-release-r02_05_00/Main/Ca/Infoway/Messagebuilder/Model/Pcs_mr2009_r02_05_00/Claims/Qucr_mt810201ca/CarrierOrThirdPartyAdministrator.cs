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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Claims.Qucr_mt810201ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;


    /**
     * <summary>Business Name: Carrier or Third Party Administrator</summary>
     * 
     * <p>An organization that establishes insurance policies, 
     * determines eligibility and benefits under those insurance 
     * policies, and underwrites payments for products and/or 
     * services provided to a beneficiary (person or 
     * organization).</p><p>A Carrier may retain a TPA (Third Party 
     * Administrator) to perform some or all invoice validation, 
     * adjudication and payment.</p><p>This may also be known as 
     * the insurance company or public insurance carrier.</p><p>A 
     * Carrier or TPA (Third Party Administrator) who performs some 
     * or all invoice validation, adjudication and payment.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"QUCR_MT810201CA.AdjudResultsCarrierRole"})]
    public class CarrierOrThirdPartyAdministrator : MessagePartBean {

        private II id;

        public CarrierOrThirdPartyAdministrator() {
            this.id = new IIImpl();
        }
        /**
         * <summary>Business Name: Carrier Id</summary>
         * 
         * <remarks>Relationship: 
         * QUCR_MT810201CA.AdjudResultsCarrierRole.id 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

    }

}