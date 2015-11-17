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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pharmacy.Porx_mt060180ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using System.Collections.Generic;


    [Hl7PartTypeMappingAttribute(new string[] {"PORX_MT060180CA.OtherMedicationRecordId"})]
    public class OtherMedicationRecordId : MessagePartBean {

        private SET<II, Identifier> value;

        public OtherMedicationRecordId() {
            this.value = new SETImpl<II, Identifier>(typeof(IIImpl));
        }
        /**
         * <summary>Business Name: E:Other Medication Record Id</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060180CA.OtherMedicationRecordId.value 
         * Conformance/Cardinality: MANDATORY (1-2) <p>Allows for the 
         * retrieval of medication records based on a specific active 
         * medication record.</p> <p>Identifier of the other active 
         * medication record for which detailed information is to be 
         * retrieved.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"value"})]
        public ICollection<Identifier> Value {
            get { return this.value.RawSet(); }
        }

    }

}