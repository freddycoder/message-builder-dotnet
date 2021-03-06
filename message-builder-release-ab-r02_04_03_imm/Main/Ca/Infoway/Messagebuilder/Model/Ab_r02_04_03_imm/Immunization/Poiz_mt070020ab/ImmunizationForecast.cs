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
namespace Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Immunization.Poiz_mt070020ab {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Domainvalue;
    using System;


    /**
     * <summary>Business Name: Immunization Forecast</summary>
     * 
     * <p>Represents the recommended vaccination schedule for a 
     * patient.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"POIZ_MT070020AB.ImmunizationForecast"})]
    public class ImmunizationForecast : MessagePartBean {

        private IVL<TS, Interval<PlatformDate>> effectiveTime;
        private INT consumableSequenceNumber;
        private CV consumableMedicationAdministrableMedicineCode;
        private CV subjectForecastStatusCode;

        public ImmunizationForecast() {
            this.effectiveTime = new IVLImpl<TS, Interval<PlatformDate>>();
            this.consumableSequenceNumber = new INTImpl();
            this.consumableMedicationAdministrableMedicineCode = new CVImpl();
            this.subjectForecastStatusCode = new CVImpl();
        }
        /**
         * <summary>Business Name: Eligibility Period</summary>
         * 
         * <remarks>Relationship: 
         * POIZ_MT070020AB.ImmunizationForecast.effectiveTime 
         * Conformance/Cardinality: MANDATORY (1) <p>Needed for 
         * informing service providers as to when a patient is eligible 
         * or due for an administration. As such, this attribute is 
         * mandatory.</p> <p>Low date in range represents the earliest 
         * eligible administration date. The high date in the range 
         * represents the date that the patient is due for the vaccine 
         * administration.</p> <p>Represents the dates that the patient 
         * is eligible and due for a vaccine administration.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"effectiveTime"})]
        public Interval<PlatformDate> EffectiveTime {
            get { return this.effectiveTime.Value; }
            set { this.effectiveTime.Value = value; }
        }

        /**
         * <summary>Business Name: Dose Number</summary>
         * 
         * <remarks>Relationship: 
         * POIZ_MT070020AB.Consumable.sequenceNumber 
         * Conformance/Cardinality: OPTIONAL (0-1) <p>Used to provide 
         * additional context to the immunization forecast.</p> 
         * <p>Indicates whether the forecasted event is the initial 
         * immunization (Dose Number = 1) or a specific booster (Dose 
         * Number = 2 means first booster, 3 means second booster, 
         * etc.).</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"consumable/sequenceNumber"})]
        public int? ConsumableSequenceNumber {
            get { return this.consumableSequenceNumber.Value; }
            set { this.consumableSequenceNumber.Value = value; }
        }

        /**
         * <summary>Business Name: Immunizing Agent Code</summary>
         * 
         * <remarks>Relationship: POIZ_MT070020AB.Medicine.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Used to represent 
         * higher-level vaccine information. It is expected that either 
         * the immunizing agent name or code is provided. As a result, 
         * this attribute is populated.</p> <p>A coded attribute which 
         * represents the immunizing agent that is to be 
         * administered.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"consumable/medication/administrableMedicine/code"})]
        public ClinicalDrug ConsumableMedicationAdministrableMedicineCode {
            get { return (ClinicalDrug) this.consumableMedicationAdministrableMedicineCode.Value; }
            set { this.consumableMedicationAdministrableMedicineCode.Value = value; }
        }

        /**
         * <summary>Business Name: Immunization Status</summary>
         * 
         * <remarks>Relationship: POIZ_MT070020AB.ForecastStatus.code 
         * Conformance/Cardinality: REQUIRED (1) <p>Needed to indicate 
         * to a provider if a patient is up to date with their 
         * immunizations according to the schedule and is therefore 
         * mandatory.</p> <p>Used to represent the patient's status 
         * with respect to their immunization schedule.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subject/forecastStatus/code"})]
        public ImmunizationForecastStatus SubjectForecastStatusCode {
            get { return (ImmunizationForecastStatus) this.subjectForecastStatusCode.Value; }
            set { this.subjectForecastStatusCode.Value = value; }
        }

    }

}