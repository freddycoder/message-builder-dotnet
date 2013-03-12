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
 * Last modified: $LastChangedDate: 2013-03-08 11:06:36 -0500 (Fri, 08 Mar 2013) $
 * Revision:      $LastChangedRevision: 6699 $
 */
/* This class was auto-generated by the message builder generator tools. */
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Claims.Ficr_mt600201ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;


    /**
     * <summary>Business Name: Cross Reference Identifier</summary>
     * 
     * <p>Identifier required to link invoices.</p> <p>Unique 
     * identifier used for cross-referrence.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"FICR_MT600201CA.InvoiceElementCrossReference"})]
    public class CrossReferenceIdentifier : MessagePartBean {

        private II id;

        public CrossReferenceIdentifier() {
            this.id = new IIImpl();
        }
        /**
         * <summary>Business Name: Cross Reference Identifier</summary>
         * 
         * <remarks>Relationship: 
         * FICR_MT600201CA.InvoiceElementCrossReference.id 
         * Conformance/Cardinality: MANDATORY (1) <p>Includes 
         * references to authorization, coverage extension and 
         * pre-determination results. The identifier is the Root 
         * Adjudicated Invoice Element Group ID, returned on the 
         * previous authorization, coverage extension or 
         * pre-determination results.</p><p>In some situations, the 
         * authorization, coverage extension and pre-determination 
         * number may not be available to the submitter electronically. 
         * Therefore, the OID root may not be available. Current action 
         * item raised to determine if the OID root can be optional for 
         * this situation.</p><p>Previous adjudication results are not 
         * referenced with this mechanism</p><p>May also be used for 
         * other identifiers that have been assigned by external 
         * agencies through a manual process, that if supplied on an 
         * Invoice, would result in payment.</p> <p>RxS1: Not permitted 
         * for this scenario.</p> <p>Includes references to 
         * authorization, coverage extension and pre-determination 
         * results. Previous adjudication results are not referenced 
         * with this mechanism</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

    }

}