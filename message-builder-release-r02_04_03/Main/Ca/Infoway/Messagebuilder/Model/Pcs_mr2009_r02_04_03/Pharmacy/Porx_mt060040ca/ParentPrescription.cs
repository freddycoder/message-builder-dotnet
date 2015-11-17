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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Pharmacy.Porx_mt060040ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: Parent Prescription</summary>
     * 
     * <p>Helps link prescriptions together, and subsequently 
     * indications for prescribing.</p> <p>This is the original 
     * prescription that is being renewed. The current prescription 
     * uses the original prescription as the basis for its 
     * information.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PORX_MT060040CA.PriorSupplyRequest"})]
    public class ParentPrescription : MessagePartBean {

        private SET<II, Identifier> id;

        public ParentPrescription() {
            this.id = new SETImpl<II, Identifier>(typeof(IIImpl));
        }
        /**
         * <summary>Business Name: B:Previous Prescription Order Number</summary>
         * 
         * <remarks>Relationship: PORX_MT060040CA.PriorSupplyRequest.id 
         * Conformance/Cardinality: MANDATORY (1-2) <p>Allows a 
         * prescription renewal (this prescription) to note the 
         * previous prescription id that was renewed;</p><p>Allows 
         * tracking a therapy across multiple renewal 
         * prescriptions.</p> <p>A reference to a previous prescription 
         * which the current prescription replaces.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public ICollection<Identifier> Id {
            get { return this.id.RawSet(); }
        }

    }

}