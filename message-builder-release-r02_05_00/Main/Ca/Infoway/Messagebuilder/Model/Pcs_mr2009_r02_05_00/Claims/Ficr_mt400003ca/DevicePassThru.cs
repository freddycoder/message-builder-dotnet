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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Claims.Ficr_mt400003ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged;


    [Hl7PartTypeMappingAttribute(new string[] {"FICR_MT400003CA.DevicePassThru"})]
    public class DevicePassThru : MessagePartBean, Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Claims.Merged.ISpecialAuthorizationChoice_2 {

        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged.ClinicalDevice directTargetManufacturedProductManufacturedClinicalDevice;

        public DevicePassThru() {
        }
        /**
         * <summary>Relationship: 
         * FICR_MT400003CA.ManufacturedProduct.manufacturedClinicalDevice</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"directTarget/manufacturedProduct/manufacturedClinicalDevice"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged.ClinicalDevice DirectTargetManufacturedProductManufacturedClinicalDevice {
            get { return this.directTargetManufacturedProductManufacturedClinicalDevice; }
            set { this.directTargetManufacturedProductManufacturedClinicalDevice = value; }
        }

    }

}