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
namespace Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Common.Coct_mt090508ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Common.Merged;


    /**
     * <summary>Business Name: Healthcare Organization</summary>
     * 
     * <p>Critical to tracking responsibility and performing 
     * follow-up.</p> <p>All attributes other than the various 
     * identifiers are expected to be retrieved from the provider 
     * registry.</p> <p>The organization under whose authority the 
     * associated (linked by a participation) action is 
     * performed</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"COCT_MT090508CA.AssignedEntity"})]
    public class HealthcareOrganization : MessagePartBean, Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Common.Coct_mt911107ca.IActingPerson, Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Common.Coct_mt911108ca.IActingPerson {

        private Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Common.Merged.ResponsibleOrganization representedOrganization;

        public HealthcareOrganization() {
        }
        /**
         * <summary>Relationship: 
         * COCT_MT090508CA.AssignedEntity.representedOrganization</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"representedOrganization"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Common.Merged.ResponsibleOrganization RepresentedOrganization {
            get { return this.representedOrganization; }
            set { this.representedOrganization = value; }
        }

    }

}