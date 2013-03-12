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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;


    /**
     * <summary>Business Name: AllergyIntoleranceSeverityLevel</summary>
     * 
     * <remarks>REPC_MT000002CA.SeverityObservation: 
     * Allergy/Intolerance Severity Level <p>Allows providers to 
     * determine appropriate managements for contraindications 
     * involving such medical conditions.</p> <p>This is a ranking/ 
     * an assertion of the seriouness of the diagnosed/reported 
     * medical condition.</p> REPC_MT000009CA.SeverityObservation: 
     * Allergy/Intolerance Severity Level <p>Allows providers to 
     * determine appropriate managements for contraindications 
     * involving such medical conditions.</p> <p>This is a ranking/ 
     * an assertion of the seriouness of the diagnosed/reported 
     * medical condition.</p> REPC_MT000001CA.SeverityObservation: 
     * Allergy/Intolerance Severity Level <p>Allows providers to 
     * determine appropriate managements for contraindications 
     * involving such medical conditions.</p> <p>This is a ranking/ 
     * an assertion of the seriouness of the diagnosed/reported 
     * medical condition.</p> REPC_MT000006CA.SeverityObservation: 
     * Allergy/Intolerance Severity Level <p>Allows providers to 
     * determine appropriate managements for contraindications 
     * involving such medical conditions.</p> <p>This is a ranking/ 
     * an assertion of the seriouness of the diagnosed/reported 
     * medical condition.</p> REPC_MT000013CA.SeverityObservation: 
     * Allergy/Intolerance Severity Level <p>Indicates both the 
     * product and how related they are determined to be to the 
     * reaction.</p> <p>Allows providers to determine appropriate 
     * managements for contraindications involving such medical 
     * conditions.</p> <p>This is a ranking/ an assertion of the 
     * seriouness of the diagnosed/reported medical condition.</p> 
     * REPC_MT000012CA.SeverityObservation: Allergy/Intolerance 
     * Severity Level <p>Allows providers to determine appropriate 
     * managements for contraindications involving such medical 
     * conditions.</p> <p>This is a ranking/ an assertion of the 
     * seriouness of the diagnosed/reported medical condition.</p> 
     * REPC_MT000005CA.SeverityObservation: Allergy/Intolerance 
     * Severity Level <p>Allows providers to determine appropriate 
     * managements for contraindications involving such medical 
     * conditions.</p> <p>This is a ranking/ an assertion of the 
     * seriouness of the diagnosed/reported medical condition.</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"REPC_MT000001CA.SeverityObservation","REPC_MT000002CA.SeverityObservation","REPC_MT000005CA.SeverityObservation","REPC_MT000006CA.SeverityObservation","REPC_MT000009CA.SeverityObservation","REPC_MT000012CA.SeverityObservation","REPC_MT000013CA.SeverityObservation"})]
    public class AllergyIntoleranceSeverityLevel : MessagePartBean {

        private CV value;

        public AllergyIntoleranceSeverityLevel() {
            this.value = new CVImpl();
        }
        /**
         * <summary>Business Name: SeverityLevel</summary>
         * 
         * <remarks>Un-merged Business Name: SeverityLevel 
         * Relationship: REPC_MT000002CA.SeverityObservation.value 
         * Conformance/Cardinality: MANDATORY (1) 
         * <p>AllergyIntolerance.severity</p> <p>Allows for sorting of 
         * reactions. May influence whether contraindications must be 
         * managed. Because SNOMED pre-coordinates this concept into 
         * code, the association is optional</p> <p>Indicates the 
         * gravity of the allergy, intolerance or reaction in terms of 
         * its actual or potential impact on the patient.</p> Un-merged 
         * Business Name: SeverityLevel Relationship: 
         * REPC_MT000009CA.SeverityObservation.value 
         * Conformance/Cardinality: MANDATORY (1) 
         * <p>AllergyIntolerance.severity</p> <p>Allows for sorting of 
         * allergy records. May influence whether contraindications 
         * must be managed.</p><p>Because SNOMED handles this concept 
         * by pre-coordinating it into code, this association is 
         * optional.</p> <p>Indicates the gravity of the allergy, 
         * intolerance or reaction in terms of its actual or potential 
         * impact on the patient.</p> Un-merged Business Name: 
         * SeverityLevel Relationship: 
         * REPC_MT000001CA.SeverityObservation.value 
         * Conformance/Cardinality: MANDATORY (1) 
         * <p>AllergyIntolerance.severity</p> <p>Allows for sorting of 
         * allergy records. May influence whether contraindications 
         * must be managed. Because SNOMED pre-coordinates severity 
         * into 'code', the attribute is optional.</p> <p>Indicates the 
         * gravity of the allergy, intolerance or reaction in terms of 
         * its actual or potential impact on the patient.</p> Un-merged 
         * Business Name: SeverityLevel Relationship: 
         * REPC_MT000006CA.SeverityObservation.value 
         * Conformance/Cardinality: MANDATORY (1) 
         * <p>AllergyIntolerance.severity</p> <p>Allows for sorting of 
         * reactions. May influence whether contraindications must be 
         * managed. Because SNOMED pre-coordinates this concept with 
         * code, the association is optional.</p> <p>Indicates the 
         * gravity of the allergy, intolerance or reaction in terms of 
         * its actual or potential impact on the patient.</p> Un-merged 
         * Business Name: SeverityLevel Relationship: 
         * REPC_MT000013CA.SeverityObservation.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows for sorting 
         * of allergy records. May influence whether contraindications 
         * must be managed.</p><p>Because SNOMED pre-coordinates 
         * severity into code, this association is optional</p> 
         * <p>Indicates the gravity of the allergy, intolerance or 
         * reaction in terms of its actual or potential impact on the 
         * patient.</p> Un-merged Business Name: SeverityLevel 
         * Relationship: REPC_MT000012CA.SeverityObservation.value 
         * Conformance/Cardinality: MANDATORY (1) 
         * <p>AllergyIntolerance.severity</p> <p>Allows for sorting of 
         * reactions. May influence whether contraindications must be 
         * managed.</p><p>Because SNOMED pre-coordinates severity into 
         * code, this association is optional</p> <p>Indicates the 
         * gravity of the allergy, intolerance or reaction in terms of 
         * its actual or potential impact on the patient.</p> Un-merged 
         * Business Name: SeverityLevel Relationship: 
         * REPC_MT000005CA.SeverityObservation.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows for sorting 
         * of allergy records. May influence whether contraindications 
         * must be managed. Because this concept is pre-coordinated 
         * with code for SNOMED, the association is optional.</p> 
         * <p>Indicates the gravity of the allergy, intolerance or 
         * reaction in terms of its actual or potential impact on the 
         * patient.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"value"})]
        public SeverityObservation Value {
            get { return (SeverityObservation) this.value.Value; }
            set { this.value.Value = value; }
        }

    }

}