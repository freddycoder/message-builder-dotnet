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
     * <summary>Business Name: Provider ID</summary>
     * 
     * <p>Provider is the health care practitioner or goods 
     * provider that is providing the service or good that is being 
     * invoiced (e.g. Pharmacist and not Ordering Physician).</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"QUCR_MT810201CA.AdjudResultsProviderRole"})]
    public class ProviderID : MessagePartBean {

        private II id;

        public ProviderID() {
            this.id = new IIImpl();
        }
        /**
         * <summary>Business Name: Summary Breakdown Provider ID</summary>
         * 
         * <remarks>Relationship: 
         * QUCR_MT810201CA.AdjudResultsProviderRole.id 
         * Conformance/Cardinality: MANDATORY (1) <p>Identity of 
         * provider for summary breakdowns.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

    }

}