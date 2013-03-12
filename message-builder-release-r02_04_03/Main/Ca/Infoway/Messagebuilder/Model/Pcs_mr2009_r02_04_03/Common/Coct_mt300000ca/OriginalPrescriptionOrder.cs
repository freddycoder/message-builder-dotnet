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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt300000ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Model;


    [Hl7PartTypeMappingAttribute(new string[] {"COCT_MT300000CA.SubstanceAdministrationOrder"})]
    public class OriginalPrescriptionOrder : MessagePartBean {

        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt300000ca.PlayingPrescribePerson authorPresriberRole;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt300000ca.DispenseSubstitution component1Substitution;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt300000ca.OriginalPrescription component2SupplyOrder;

        public OriginalPrescriptionOrder() {
        }
        /**
         * <summary>Relationship: 
         * COCT_MT300000CA.Prescriber.presriberRole</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"author/presriberRole"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt300000ca.PlayingPrescribePerson AuthorPresriberRole {
            get { return this.authorPresriberRole; }
            set { this.authorPresriberRole = value; }
        }

        /**
         * <summary>Relationship: 
         * COCT_MT300000CA.Component2.substitution</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component1/substitution"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt300000ca.DispenseSubstitution Component1Substitution {
            get { return this.component1Substitution; }
            set { this.component1Substitution = value; }
        }

        /**
         * <summary>Relationship: 
         * COCT_MT300000CA.ComponentOrder.supplyOrder</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component2/supplyOrder"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt300000ca.OriginalPrescription Component2SupplyOrder {
            get { return this.component2SupplyOrder; }
            set { this.component2SupplyOrder = value; }
        }

    }

}