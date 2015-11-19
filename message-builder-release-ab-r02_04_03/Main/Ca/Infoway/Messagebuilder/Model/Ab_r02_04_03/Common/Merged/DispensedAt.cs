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
namespace Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Common.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Common.Coct_mt240003ca;


    /**
     * <summary>Business Name: DispensedAt</summary>
     * 
     * <remarks>COCT_MT260010CA.Location: *b:dispensed at 
     * <p>A_DetectedMedicationIssue</p> <p>Used for contacting the 
     * pharmacy or pharmacist involved in the dispense.</p><p>The 
     * association is marked as populated because it may be 
     * masked.</p> <p>Indicates the facility where the dispense 
     * event was performed</p> COCT_MT260030CA.Location: 
     * *b:dispensed at <p>A_DetectedMedicationIssue</p> <p>Used for 
     * contacting the pharmacy or pharmacist involved in the 
     * dispense.</p><p>The association is marked as populated 
     * because it may be masked.</p> <p>Indicates the facility 
     * where the dispense event was performed</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"COCT_MT260010CA.Location","COCT_MT260020CA.Location","COCT_MT260030CA.Location"})]
    public class DispensedAt : MessagePartBean {

        private Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Common.Coct_mt240003ca.ServiceLocation serviceDeliveryLocation;

        public DispensedAt() {
        }
        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT260010CA.Location.serviceDeliveryLocation 
         * Conformance/Cardinality: REQUIRED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * COCT_MT260030CA.Location.serviceDeliveryLocation 
         * Conformance/Cardinality: REQUIRED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * COCT_MT260020CA.Location.serviceDeliveryLocation 
         * Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"serviceDeliveryLocation"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Common.Coct_mt240003ca.ServiceLocation ServiceDeliveryLocation {
            get { return this.serviceDeliveryLocation; }
            set { this.serviceDeliveryLocation = value; }
        }

    }

}