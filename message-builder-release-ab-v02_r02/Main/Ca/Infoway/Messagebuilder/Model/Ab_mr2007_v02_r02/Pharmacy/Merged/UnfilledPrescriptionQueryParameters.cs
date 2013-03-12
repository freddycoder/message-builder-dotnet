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
namespace Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pharmacy.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: UnfilledPrescriptionQueryParameters</summary>
     * 
     * <remarks>PORX_MT060270CA.ParameterList: (no business name) 
     * <p>Defines the set of parameters that may be used to filter 
     * the query response.</p> <p>Root class for query 
     * definition</p> PORX_MT060240CA.ParameterList: Unfilled 
     * Prescription Query Parameters <p>Defines the set of 
     * parameters that may be used to filter the query 
     * response.</p> <p>Root class for query definition</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PORX_MT060240CA.ParameterList","PORX_MT060270CA.ParameterList"})]
    public class UnfilledPrescriptionQueryParameters : MessagePartBean {

        private IVL<TS, Interval<PlatformDate>> administrationEffectivePeriodValue;
        private II prescriberProviderIDValue;
        private IList<CV> prescriptionStatusValue;
        private CV rxDispenseIndicatorValue;

        public UnfilledPrescriptionQueryParameters() {
            this.administrationEffectivePeriodValue = new IVLImpl<TS, Interval<PlatformDate>>();
            this.prescriberProviderIDValue = new IIImpl();
            this.prescriptionStatusValue = new List<CV>();
            this.rxDispenseIndicatorValue = new CVImpl();
        }
        /**
         * <summary>Business Name: AdministrationEffectivePeriod</summary>
         * 
         * <remarks>Un-merged Business Name: 
         * AdministrationEffectivePeriod Relationship: 
         * PORX_MT060270CA.AdministrationEffectivePeriod.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Indicates the 
         * administration period for which the request/query 
         * applies.</p><p>Filter the result set to include only those 
         * medication records (prescription order, prescription 
         * dispense and other active medication) for which the patient 
         * was deemed to be taking the drug within the specified 
         * period.</p> <p>Indicates the administration period for which 
         * the request/query applies.</p><p>Filter the result set to 
         * include only those medication records (prescription order, 
         * prescription dispense and other active medication) for which 
         * the patient was deemed to be taking the drug within the 
         * specified period.</p> <p>Allows the requester to specify the 
         * administration period of interest for the retrieval. Useful 
         * for constraining run-away queries.</p> Un-merged Business 
         * Name: AdministrationEffectivePeriod Relationship: 
         * PORX_MT060240CA.AdministrationEffectivePeriod.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Indicates the 
         * administration period for which the request/query 
         * applies.</p><p>Filter the result set to include only those 
         * medication records (prescription order, prescription 
         * dispense and other active medication) for which the patient 
         * was deemed to be taking the drug within the specified 
         * period.</p> <p>Indicates the administration period for which 
         * the request/query applies.</p><p>Filter the result set to 
         * include only those medication records (prescription order, 
         * prescription dispense and other active medication) for which 
         * the patient was deemed to be taking the drug within the 
         * specified period.</p> <p>Allows the requester to specify the 
         * administration period of interest for the retrieval. Useful 
         * for constraining run-away queries.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"administrationEffectivePeriod/value"})]
        public Interval<PlatformDate> AdministrationEffectivePeriodValue {
            get { return this.administrationEffectivePeriodValue.Value; }
            set { this.administrationEffectivePeriodValue.Value = value; }
        }

        /**
         * <summary>Business Name: PrescriberProviderID</summary>
         * 
         * <remarks>Un-merged Business Name: PrescriberProviderID 
         * Relationship: PORX_MT060270CA.PrescriberProviderID.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Identifier of the 
         * prescriber who created and/or supervised the prescriptions 
         * being retrieved.</p><p>The result set will be filtered to 
         * only include records which were either directly created by 
         * this provider, or were created 'under the supervision' of 
         * this provider.</p> <p>Identifier of the prescriber who 
         * created and/or supervised the prescriptions being 
         * retrieved.</p><p>The result set will be filtered to only 
         * include records which were either directly created by this 
         * provider, or were created 'under the supervision' of this 
         * provider.</p> <p>Allows for the retrieval of prescriptions 
         * based on a specific prescriber.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"prescriberProviderID/value"})]
        public Identifier PrescriberProviderIDValue {
            get { return this.prescriberProviderIDValue.Value; }
            set { this.prescriberProviderIDValue.Value = value; }
        }

        /**
         * <summary>Business Name: PrescriptionStatuses</summary>
         * 
         * <remarks>Un-merged Business Name: PrescriptionStatuses 
         * Relationship: PORX_MT060240CA.PrescriptionStatus.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Indicates that 
         * prescriptions of a specific statuses are to be included in 
         * the result set. Allowable prescription status codes are: 
         * 'ABORTED, ACTIVE', 'COMPLETED', and 'SUSPENDED'.</p> 
         * <p>Allows for the retrieval of patient prescriptions and 
         * dispenses based on the lifecycle state of the 
         * prescription.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"prescriptionStatus/value"})]
        public IList<ActStatus> PrescriptionStatusValue {
            get { return new RawListWrapper<CV, ActStatus>(prescriptionStatusValue, typeof(CVImpl)); }
        }

        /**
         * <summary>Business Name: RxDispenseIndicator</summary>
         * 
         * <remarks>Un-merged Business Name: RxDispenseIndicator 
         * Relationship: PORX_MT060240CA.RxDispenseIndicator.value 
         * Conformance/Cardinality: MANDATORY (1) <p>A coded value 
         * indicating the dispensing (fill) status of the prescription 
         * to be included in the result set. The only allowable Rx 
         * Dispense Indicators is ND (Never Dispensed).</p> <p>Allows 
         * for finer sub-set of prescriptions to be retrieved based on 
         * the fill status of the prescription.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"rxDispenseIndicator/value"})]
        public PrescriptionDispenseFilterCode RxDispenseIndicatorValue {
            get { return (PrescriptionDispenseFilterCode) this.rxDispenseIndicatorValue.Value; }
            set { this.rxDispenseIndicatorValue.Value = value; }
        }

    }

}