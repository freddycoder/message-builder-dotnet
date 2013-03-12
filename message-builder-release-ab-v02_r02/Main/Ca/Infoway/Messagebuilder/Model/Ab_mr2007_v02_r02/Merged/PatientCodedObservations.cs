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
namespace Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;


    /**
     * <summary>Business Name: PatientCodedObservations</summary>
     * 
     * <remarks>PORX_MT980030CA.ObservationCodedEvent: Patient 
     * Coded Observations <p>This is the recorded observation (e.g. 
     * allergy, medical condition, lab result, pregnancy status, 
     * etc.) of the patient that contributed to the issue being 
     * raised.</p> <p>Useful for determining appropriate management 
     * and for drilling down for more information.</p> 
     * PORX_MT980010CA.ObservationCodedEvent: Patient Coded 
     * Observations <p>This is the recorded observation (e.g. 
     * allergy, medical condition, lab result, pregnancy status, 
     * etc.) of the patient that contributed to the issue being 
     * raised.</p> <p>Useful for determining appropriate management 
     * and for drilling down for more information.</p> 
     * PORX_MT980020CA.ObservationCodedEvent: Patient Coded 
     * Observations <p>This is the recorded observation (e.g. 
     * allergy, medical condition, lab result, pregnancy status, 
     * etc.) of the patient that contributed to the issue being 
     * raised.</p> <p>Useful for determining appropriate management 
     * and for drilling down for more information.</p> 
     * COCT_MT260010CA.ObservationCodedEvent: Patient Coded 
     * Observations <p>This is the recorded observation (e.g. 
     * allergy, medical condition, lab result, pregnancy status, 
     * etc.) of the patient that contributed to the issue being 
     * raised.</p> <p>Useful for determining appropriate management 
     * and for drilling down for more information.</p> 
     * COCT_MT260030CA.ObservationCodedEvent: Patient Coded 
     * Observations <p>This is the recorded observation (e.g. 
     * allergy, medical condition, lab result, pregnancy status, 
     * etc.) of the patient that contributed to the issue being 
     * raised.</p> <p>Useful for determining appropriate management 
     * and for drilling down for more information.</p> 
     * COCT_MT260020CA.ObservationCodedEvent: Patient Coded 
     * Observations <p>This is the recorded observation (e.g. 
     * allergy, medical condition, lab result, pregnancy status, 
     * etc.) of the patient that contributed to the issue being 
     * raised.</p> <p>Useful for determining appropriate management 
     * and for drilling down for more information.</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"COCT_MT260010CA.ObservationCodedEvent","COCT_MT260020CA.ObservationCodedEvent","COCT_MT260030CA.ObservationCodedEvent","PORX_MT980010CA.ObservationCodedEvent","PORX_MT980020CA.ObservationCodedEvent","PORX_MT980030CA.ObservationCodedEvent"})]
    public class PatientCodedObservations : MessagePartBean, Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged.ICausalActs {

        private II id;
        private CD code;
        private CV confidentialityCode;
        private CV value;

        public PatientCodedObservations() {
            this.id = new IIImpl();
            this.code = new CDImpl();
            this.confidentialityCode = new CVImpl();
            this.value = new CVImpl();
        }
        /**
         * <summary>Business Name: ObservationIdentifier</summary>
         * 
         * <remarks>Un-merged Business Name: ObservationIdentifier 
         * Relationship: PORX_MT980030CA.ObservationCodedEvent.id 
         * Conformance/Cardinality: POPULATED (1) <p>Unique identifier 
         * for the record of the coded observation (e.g. allergy, 
         * medical condition, pregnancy status, etc.) that contributed 
         * to the issue.</p> <p>Allows lookup of the specific coded 
         * observation (e.g. allergy, medical condition, pregnancy 
         * status, etc.) for additional details when evaluating 
         * appropriateness of issue management.</p> Un-merged Business 
         * Name: ObservationIdentifier Relationship: 
         * PORX_MT980010CA.ObservationCodedEvent.id 
         * Conformance/Cardinality: POPULATED (1) <p>Unique identifier 
         * for the record of the coded observation (e.g. allergy, 
         * medical condition, pregnancy status, etc.) that contributed 
         * to the issue.</p> <p>Allows lookup of the specific coded 
         * observation (e.g. allergy, medical condition, pregnancy 
         * status, etc.) for additional details when evaluating 
         * appropriateness of issue management.</p> Un-merged Business 
         * Name: ObservationIdentifier Relationship: 
         * PORX_MT980020CA.ObservationCodedEvent.id 
         * Conformance/Cardinality: POPULATED (1) <p>Unique identifier 
         * for the record of the coded observation (e.g. allergy, 
         * medical condition, pregnancy status, etc.) that contributed 
         * to the issue.</p> <p>Allows lookup of the specific coded 
         * observation (e.g. allergy, medical condition, pregnancy 
         * status, etc) for additional details when evaluating 
         * appropriateness of issue management.</p> Un-merged Business 
         * Name: ObservationIdentifier Relationship: 
         * COCT_MT260010CA.ObservationCodedEvent.id 
         * Conformance/Cardinality: POPULATED (1) <p>Unique identifier 
         * for the record of the coded observation (e.g. allergy, 
         * medical condition, pregnancy status, etc.) that contributed 
         * to the issue.</p> <p>Allows lookup of the specific coded 
         * observation (e.g. allergy, medical condition, pregnancy 
         * status, etc.) for additional details when evaluating 
         * appropriateness of issue management.</p> Un-merged Business 
         * Name: ObservationIdentifier Relationship: 
         * COCT_MT260030CA.ObservationCodedEvent.id 
         * Conformance/Cardinality: POPULATED (1) <p>Unique identifier 
         * for the record of the coded observation (e.g. allergy, 
         * medical condition, pregnancy status, etc.) that contributed 
         * to the issue.</p> <p>Allows lookup of the specific coded 
         * observation (e.g. allergy, medical condition, pregnancy 
         * status, etc.) for additional details when evaluating 
         * appropriateness of issue management.</p> Un-merged Business 
         * Name: ObservationIdentifier Relationship: 
         * COCT_MT260020CA.ObservationCodedEvent.id 
         * Conformance/Cardinality: POPULATED (1) <p>Unique identifier 
         * for the record of the coded observation (e.g. allergy, 
         * medical condition, pregnancy status, etc.) that contributed 
         * to the issue.</p> <p>Allows lookup of the specific coded 
         * observation (e.g. allergy, medical condition, pregnancy 
         * status, etc) for additional details when evaluating 
         * appropriateness of issue management.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Business Name: ObservationType</summary>
         * 
         * <remarks>Un-merged Business Name: ObservationType 
         * Relationship: PORX_MT980030CA.ObservationCodedEvent.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Distinguishes the 
         * kinds of coded observation that could be the trigger for 
         * clinical issue detection. Coded Observation types include: 
         * Allergy, Intolerance, Medical Condition, Indication, 
         * Pregnancy status, Lactation status and other observable 
         * information about a person that may be deemed as a possible 
         * trigger for clinical issue detection.</p> <p>Differentiates 
         * DAI from DPD Contraindications</p><p>DRU.100-04 
         * (mnemonic)</p><p>DRU.100-05 (code system)</p> 
         * <p>Differentiates DAI from DPD 
         * Contraindications</p><p>DRU.100-04 
         * (mnemonic)</p><p>DRU.100-05 (code system)</p> 
         * <p>Differentiates DAI from DPD 
         * Contraindications</p><p>DRU.100-04 
         * (mnemonic)</p><p>DRU.100-05 (code system)</p> <p>Indicates 
         * the type of recorded observation being referenced. The 
         * attribute is mandatory because it is essential to 
         * interpreting the rest of the information on the class.</p> 
         * Un-merged Business Name: ObservationType Relationship: 
         * PORX_MT980010CA.ObservationCodedEvent.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Distinguishes the 
         * kinds of coded observation that could be the trigger for 
         * clinical issue detection. Coded Observation types include: 
         * Allergy, Intolerance, Medical Condition, Indication, 
         * Pregnancy status, Lactation status and other observable 
         * information about a person that may be deemed as a possible 
         * trigger for clinical issue detection.</p> <p>Differentiates 
         * DAI from DPD Contraindications</p><p>DRU.100-04 
         * (mnemonic)</p><p>DRU.100-05 (code system)</p> 
         * <p>Differentiates DAI from DPD 
         * Contraindications</p><p>DRU.100-04 
         * (mnemonic)</p><p>DRU.100-05 (code system)</p> 
         * <p>Differentiates DAI from DPD 
         * Contraindications</p><p>DRU.100-04 
         * (mnemonic)</p><p>DRU.100-05 (code system)</p> <p>Indicates 
         * the type of recorded observation being referenced. The 
         * attribute is mandatory because it is essential to 
         * interpreting the rest of the information on the class.</p> 
         * Un-merged Business Name: ObservationType Relationship: 
         * PORX_MT980020CA.ObservationCodedEvent.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Distinguishes the 
         * kinds of coded observation that could be the trigger for 
         * clinical issue detection. Coded Observation types include: 
         * Allergy, Intolerance, Medical Condition, Indication, 
         * Pregnancy status, Lactation status and other observable 
         * information about a person that may be deemed as a possible 
         * trigger for clinical issue detection.</p> <p>Differentiates 
         * DAI from DPD Contraindications</p><p>DRU.100-04 
         * (mnemonic)</p><p>DRU.100-05 (code system)</p> 
         * <p>Differentiates DAI from DPD 
         * Contraindications</p><p>DRU.100-04 
         * (mnemonic)</p><p>DRU.100-05 (code system)</p> 
         * <p>Differentiates DAI from DPD 
         * Contraindications</p><p>DRU.100-04 
         * (mnemonic)</p><p>DRU.100-05 (code system)</p> <p>Indicates 
         * the type of recorded observation being referenced. The 
         * attribute is mandatory because it is essential to 
         * interpreting the rest of the information on the class.</p> 
         * Un-merged Business Name: ObservationType Relationship: 
         * COCT_MT260010CA.ObservationCodedEvent.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Distinguishes the 
         * kinds of coded observation that could be the trigger for 
         * clinical issue detection. Coded Observation types include: 
         * Allergy, Intolerance, Medical Condition, Indication, 
         * Pregnancy status, Lactation status and other observable 
         * information about a person that may be deemed as a possible 
         * trigger for clinical issue detection.</p> <p>Differentiates 
         * DAI from DPD Contraindications</p><p>DRU.100-04 
         * (mnemonic)</p><p>DRU.100-05 (code system)</p> 
         * <p>Differentiates DAI from DPD 
         * Contraindications</p><p>DRU.100-04 
         * (mnemonic)</p><p>DRU.100-05 (code system)</p> 
         * <p>Differentiates DAI from DPD 
         * Contraindications</p><p>DRU.100-04 
         * (mnemonic)</p><p>DRU.100-05 (code system)</p> <p>Indicates 
         * the type of recorded observation being referenced. The 
         * attribute is mandatory because it is essential to 
         * interpreting the rest of the information on the class.</p> 
         * Un-merged Business Name: ObservationType Relationship: 
         * COCT_MT260030CA.ObservationCodedEvent.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Distinguishes the 
         * kinds of coded observation that could be the trigger for 
         * clinical issue detection. Coded Observation types include: 
         * Allergy, Intolerance, Medical Condition, Indication, 
         * Pregnancy status, Lactation status and other observable 
         * information about a person that may be deemed as a possible 
         * trigger for clinical issue detection.</p> <p>Differentiates 
         * DAI from DPD Contraindications</p><p>DRU.100-04 
         * (mnemonic)</p><p>DRU.100-05 (code system)</p> 
         * <p>Differentiates DAI from DPD 
         * Contraindications</p><p>DRU.100-04 
         * (mnemonic)</p><p>DRU.100-05 (code system)</p> 
         * <p>Differentiates DAI from DPD 
         * Contraindications</p><p>DRU.100-04 
         * (mnemonic)</p><p>DRU.100-05 (code system)</p> <p>Indicates 
         * the type of recorded observation being referenced. The 
         * attribute is mandatory because it is essential to 
         * interpreting the rest of the information on the class.</p> 
         * Un-merged Business Name: ObservationType Relationship: 
         * COCT_MT260020CA.ObservationCodedEvent.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Distinguishes the 
         * kinds of coded observation that could be the trigger for 
         * clinical issue detection. Coded Observation types include: 
         * Allergy, Intolerance, Medical Condition, Indication, 
         * Pregnancy status, Lactation status and other observable 
         * information about a person that may be deemed as a possible 
         * trigger for clinical issue detection.</p> <p>Differentiates 
         * DAI from DPD Contraindications</p><p>DRU.100-04 
         * (mnemonic)</p><p>DRU.100-05 (code system)</p> 
         * <p>Differentiates DAI from DPD 
         * Contraindications</p><p>DRU.100-04 
         * (mnemonic)</p><p>DRU.100-05 (code system)</p> 
         * <p>Differentiates DAI from DPD 
         * Contraindications</p><p>DRU.100-04 
         * (mnemonic)</p><p>DRU.100-05 (code system)</p> <p>Indicates 
         * the type of recorded observation being referenced. The 
         * attribute is mandatory because it is essential to 
         * interpreting the rest of the information on the class.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ActCode Code {
            get { return (ActCode) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: 
         * ObservationMaskingIndicator</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT980030CA.ObservationCodedEvent.confidentialityCode 
         * Conformance/Cardinality: OPTIONAL (0-1) <p>An indication of 
         * sensitivity surrounding the related condition, and thus 
         * defines the required sensitivity for the detected issue.</p> 
         * <p>Contraindication.intractingSourceMasked (Normal=false; 
         * Restricted or Very Restricted = True); (Information is 
         * withheld because the prescription is masked will be given a 
         * NULL flavour of 'Masked')</p> <p>Conveys the patient's 
         * wishes relating to the sensitivity of the observation 
         * information.</p><p>The attribute is optional because not all 
         * systems will support masking.</p> <p>Conveys the patient's 
         * wishes relating to the sensitivity of the observation 
         * information.</p><p>The attribute is optional because not all 
         * systems will support masking.</p> Un-merged Business Name: 
         * ObservationMaskingIndicator Relationship: 
         * PORX_MT980010CA.ObservationCodedEvent.confidentialityCode 
         * Conformance/Cardinality: OPTIONAL (0-1) <p>An indication of 
         * sensitivity surrounding the related condition, and thus 
         * defines the required sensitivity for the detected issue.</p> 
         * <p>Contraindication.intractingSourceMasked (Normal=false; 
         * Restricted or Very Restricted = True); (Information is 
         * withheld because the prescription is masked will be given a 
         * NULL flavour of 'Masked')</p> <p>Conveys the patient's 
         * wishes relating to the sensitivity of the observation 
         * information.</p><p>The attribute is optional because not all 
         * systems will support masking.</p> <p>Conveys the patient's 
         * wishes relating to the sensitivity of the observation 
         * information.</p><p>The attribute is optional because not all 
         * systems will support masking.</p> Un-merged Business Name: 
         * ObservationMaskedIndicator Relationship: 
         * PORX_MT980020CA.ObservationCodedEvent.confidentialityCode 
         * Conformance/Cardinality: OPTIONAL (0-1) <p>An indication of 
         * sensitivity surrounding the implicated condition, and thus 
         * defines the required sensitivity for the detected issue.</p> 
         * <p>Contraindication.intractingSourceMasked (Normal=false; 
         * Restricted or Very Restricted = True); (Information is 
         * withheld because the prescription is masked will be given a 
         * NULL flavour of 'Masked')</p> <p>Conveys the patient's 
         * wishes relating to the sensitivity of the 
         * observation.</p><p>The attribute is optional because not all 
         * systems will support masking.</p> <p>Conveys the patient's 
         * wishes relating to the sensitivity of the 
         * observation.</p><p>The attribute is optional because not all 
         * systems will support masking.</p> Un-merged Business Name: 
         * ObservationMaskingIndicator Relationship: 
         * COCT_MT260010CA.ObservationCodedEvent.confidentialityCode 
         * Conformance/Cardinality: OPTIONAL (0-1) <p>An indication of 
         * sensitivity surrounding the related condition, and thus 
         * defines the required sensitivity for the detected issue.</p> 
         * <p>Contraindication.intractingSourceMasked (Normal=false; 
         * Restricted or Very Restricted = True); (Information is 
         * withheld because the prescription is masked will be given a 
         * NULL flavour of 'Masked')</p> <p>Conveys the patient's 
         * wishes relating to the sensitivity of the observation 
         * information.</p><p>The attribute is optional because not all 
         * systems will support masking.</p> <p>Conveys the patient's 
         * wishes relating to the sensitivity of the observation 
         * information.</p><p>The attribute is optional because not all 
         * systems will support masking.</p> Un-merged Business Name: 
         * ObservationMaskingIndicator Relationship: 
         * COCT_MT260030CA.ObservationCodedEvent.confidentialityCode 
         * Conformance/Cardinality: OPTIONAL (0-1) <p>An indication of 
         * sensitivity surrounding the related condition, and thus 
         * defines the required sensitivity for the detected issue.</p> 
         * <p>Contraindication.intractingSourceMasked (Normal=false; 
         * Restricted or Very Restricted = True); (Information is 
         * withheld because the prescription is masked will be given a 
         * NULL flavour of 'Masked')</p> <p>Conveys the patient's 
         * wishes relating to the sensitivity of the observation 
         * information.</p><p>The attribute is optional because not all 
         * systems will support masking.</p> <p>Conveys the patient's 
         * wishes relating to the sensitivity of the observation 
         * information.</p><p>The attribute is optional because not all 
         * systems will support masking.</p> Un-merged Business Name: 
         * ObservationMaskedIndicator Relationship: 
         * COCT_MT260020CA.ObservationCodedEvent.confidentialityCode 
         * Conformance/Cardinality: OPTIONAL (0-1) <p>An indication of 
         * sensitivity surrounding the implicated condition, and thus 
         * defines the required sensitivity for the detected issue.</p> 
         * <p>Contraindication.intractingSourceMasked (Normal=false; 
         * Restricted or Very Restricted = True); (Information is 
         * withheld because the prescription is masked will be given a 
         * NULL flavour of 'Masked')</p> <p>Conveys the patient's 
         * wishes relating to the sensitivity of the 
         * observation.</p><p>The attribute is optional because not all 
         * systems will support masking.</p> <p>Conveys the patient's 
         * wishes relating to the sensitivity of the 
         * observation.</p><p>The attribute is optional because not all 
         * systems will support masking.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"confidentialityCode"})]
        public x_VeryBasicConfidentialityKind ConfidentialityCode {
            get { return (x_VeryBasicConfidentialityKind) this.confidentialityCode.Value; }
            set { this.confidentialityCode.Value = value; }
        }

        /**
         * <summary>Business Name: ObservationValue</summary>
         * 
         * <remarks>Un-merged Business Name: ObservationValue 
         * Relationship: PORX_MT980030CA.ObservationCodedEvent.value 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Denotes a 
         * specific coded observation made about a person that might 
         * have trigger the clinical issue detection.</p> 
         * <p>Containdication.allergenGroupName (PrintName) 
         * PIN:Contraindications.drugAllergy (Inferred from Code System 
         * - if it is a DIN it is probably a 
         * drug)</p><p>Contraindication.indicationDescription</p><p>ZDU.7.1 
         * (Code System)</p><p>ZDU.7.2 (mnemonic)</p><p>ZDU.8.2 (Code 
         * System)</p><p>ZDU.8.3 (mnemonic)</p><p>ZDU.8.1 (Print 
         * Name)</p><p>Disease Code</p> 
         * <p>Containdication.allergenGroupName (PrintName) 
         * PIN:Contraindications.drugAllergy (Inferred from Code System 
         * - if it is a DIN it is probably a 
         * drug)</p><p>Contraindication.indicationDescription</p><p>ZDU.7.1 
         * (Code System)</p><p>ZDU.7.2 (mnemonic)</p><p>ZDU.8.2 (Code 
         * System)</p><p>ZDU.8.3 (mnemonic)</p><p>ZDU.8.1 (Print 
         * Name)</p><p>Disease Code</p> 
         * <p>Containdication.allergenGroupName (PrintName) 
         * PIN:Contraindications.drugAllergy (Inferred from Code System 
         * - if it is a DIN it is probably a 
         * drug)</p><p>Contraindication.indicationDescription</p><p>ZDU.7.1 
         * (Code System)</p><p>ZDU.7.2 (mnemonic)</p><p>ZDU.8.2 (Code 
         * System)</p><p>ZDU.8.3 (mnemonic)</p><p>ZDU.8.1 (Print 
         * Name)</p><p>Disease Code</p> 
         * <p>Containdication.allergenGroupName (PrintName) 
         * PIN:Contraindications.drugAllergy (Inferred from Code System 
         * - if it is a DIN it is probably a 
         * drug)</p><p>Contraindication.indicationDescription</p><p>ZDU.7.1 
         * (Code System)</p><p>ZDU.7.2 (mnemonic)</p><p>ZDU.8.2 (Code 
         * System)</p><p>ZDU.8.3 (mnemonic)</p><p>ZDU.8.1 (Print 
         * Name)</p><p>Disease Code</p> 
         * <p>Containdication.allergenGroupName (PrintName) 
         * PIN:Contraindications.drugAllergy (Inferred from Code System 
         * - if it is a DIN it is probably a 
         * drug)</p><p>Contraindication.indicationDescription</p><p>ZDU.7.1 
         * (Code System)</p><p>ZDU.7.2 (mnemonic)</p><p>ZDU.8.2 (Code 
         * System)</p><p>ZDU.8.3 (mnemonic)</p><p>ZDU.8.1 (Print 
         * Name)</p><p>Disease Code</p> 
         * <p>Containdication.allergenGroupName (PrintName) 
         * PIN:Contraindications.drugAllergy (Inferred from Code System 
         * - if it is a DIN it is probably a 
         * drug)</p><p>Contraindication.indicationDescription</p><p>ZDU.7.1 
         * (Code System)</p><p>ZDU.7.2 (mnemonic)</p><p>ZDU.8.2 (Code 
         * System)</p><p>ZDU.8.3 (mnemonic)</p><p>ZDU.8.1 (Print 
         * Name)</p><p>Disease Code</p> 
         * <p>Containdication.allergenGroupName (PrintName) 
         * PIN:Contraindications.drugAllergy (Inferred from Code System 
         * - if it is a DIN it is probably a 
         * drug)</p><p>Contraindication.indicationDescription</p><p>ZDU.7.1 
         * (Code System)</p><p>ZDU.7.2 (mnemonic)</p><p>ZDU.8.2 (Code 
         * System)</p><p>ZDU.8.3 (mnemonic)</p><p>ZDU.8.1 (Print 
         * Name)</p><p>Disease Code</p> 
         * <p>Containdication.allergenGroupName (PrintName) 
         * PIN:Contraindications.drugAllergy (Inferred from Code System 
         * - if it is a DIN it is probably a 
         * drug)</p><p>Contraindication.indicationDescription</p><p>ZDU.7.1 
         * (Code System)</p><p>ZDU.7.2 (mnemonic)</p><p>ZDU.8.2 (Code 
         * System)</p><p>ZDU.8.3 (mnemonic)</p><p>ZDU.8.1 (Print 
         * Name)</p><p>Disease Code</p> <p>Provides unambiguous 
         * reference to the related coded observation.</p> Un-merged 
         * Business Name: ObservationValue Relationship: 
         * PORX_MT980010CA.ObservationCodedEvent.value 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Denotes a 
         * specific coded observation made about a person that might 
         * have trigger the clinical issue detection.</p> 
         * <p>Containdication.allergenGroupName (PrintName) 
         * PIN:Contraindications.drugAllergy (Inferred from Code System 
         * - if it is a DIN it is probably a 
         * drug)</p><p>Contraindication.indicationDescription</p><p>ZDU.7.1 
         * (Code System)</p><p>ZDU.7.2 (mnemonic)</p><p>ZDU.8.2 (Code 
         * System)</p><p>ZDU.8.3 (mnemonic)</p><p>ZDU.8.1 (Print 
         * Name)</p><p>Disease Code</p> 
         * <p>Containdication.allergenGroupName (PrintName) 
         * PIN:Contraindications.drugAllergy (Inferred from Code System 
         * - if it is a DIN it is probably a 
         * drug)</p><p>Contraindication.indicationDescription</p><p>ZDU.7.1 
         * (Code System)</p><p>ZDU.7.2 (mnemonic)</p><p>ZDU.8.2 (Code 
         * System)</p><p>ZDU.8.3 (mnemonic)</p><p>ZDU.8.1 (Print 
         * Name)</p><p>Disease Code</p> 
         * <p>Containdication.allergenGroupName (PrintName) 
         * PIN:Contraindications.drugAllergy (Inferred from Code System 
         * - if it is a DIN it is probably a 
         * drug)</p><p>Contraindication.indicationDescription</p><p>ZDU.7.1 
         * (Code System)</p><p>ZDU.7.2 (mnemonic)</p><p>ZDU.8.2 (Code 
         * System)</p><p>ZDU.8.3 (mnemonic)</p><p>ZDU.8.1 (Print 
         * Name)</p><p>Disease Code</p> 
         * <p>Containdication.allergenGroupName (PrintName) 
         * PIN:Contraindications.drugAllergy (Inferred from Code System 
         * - if it is a DIN it is probably a 
         * drug)</p><p>Contraindication.indicationDescription</p><p>ZDU.7.1 
         * (Code System)</p><p>ZDU.7.2 (mnemonic)</p><p>ZDU.8.2 (Code 
         * System)</p><p>ZDU.8.3 (mnemonic)</p><p>ZDU.8.1 (Print 
         * Name)</p><p>Disease Code</p> 
         * <p>Containdication.allergenGroupName (PrintName) 
         * PIN:Contraindications.drugAllergy (Inferred from Code System 
         * - if it is a DIN it is probably a 
         * drug)</p><p>Contraindication.indicationDescription</p><p>ZDU.7.1 
         * (Code System)</p><p>ZDU.7.2 (mnemonic)</p><p>ZDU.8.2 (Code 
         * System)</p><p>ZDU.8.3 (mnemonic)</p><p>ZDU.8.1 (Print 
         * Name)</p><p>Disease Code</p> 
         * <p>Containdication.allergenGroupName (PrintName) 
         * PIN:Contraindications.drugAllergy (Inferred from Code System 
         * - if it is a DIN it is probably a 
         * drug)</p><p>Contraindication.indicationDescription</p><p>ZDU.7.1 
         * (Code System)</p><p>ZDU.7.2 (mnemonic)</p><p>ZDU.8.2 (Code 
         * System)</p><p>ZDU.8.3 (mnemonic)</p><p>ZDU.8.1 (Print 
         * Name)</p><p>Disease Code</p> 
         * <p>Containdication.allergenGroupName (PrintName) 
         * PIN:Contraindications.drugAllergy (Inferred from Code System 
         * - if it is a DIN it is probably a 
         * drug)</p><p>Contraindication.indicationDescription</p><p>ZDU.7.1 
         * (Code System)</p><p>ZDU.7.2 (mnemonic)</p><p>ZDU.8.2 (Code 
         * System)</p><p>ZDU.8.3 (mnemonic)</p><p>ZDU.8.1 (Print 
         * Name)</p><p>Disease Code</p> 
         * <p>Containdication.allergenGroupName (PrintName) 
         * PIN:Contraindications.drugAllergy (Inferred from Code System 
         * - if it is a DIN it is probably a 
         * drug)</p><p>Contraindication.indicationDescription</p><p>ZDU.7.1 
         * (Code System)</p><p>ZDU.7.2 (mnemonic)</p><p>ZDU.8.2 (Code 
         * System)</p><p>ZDU.8.3 (mnemonic)</p><p>ZDU.8.1 (Print 
         * Name)</p><p>Disease Code</p> <p>Provides unambiguous 
         * reference to the related coded observation.</p> Un-merged 
         * Business Name: ObservationValue Relationship: 
         * PORX_MT980020CA.ObservationCodedEvent.value 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Denotes a 
         * specific coded observation made about a person that might 
         * have trigger the clinical issue detection.</p> 
         * <p>Containdication.allergenGroupName (PrintName) 
         * PIN:Contraindications.drugAllergy (Inferred from Code System 
         * - if it is a DIN it is probably a 
         * drug)</p><p>Contraindication.indicationDescription</p><p>ZDU.7.1 
         * (Code System)</p><p>ZDU.7.2 (mnemonic)</p><p>ZDU.8.2 (Code 
         * System)</p><p>ZDU.8.3 (mnemonic)</p><p>ZDU.8.1 (Print 
         * Name)</p><p>Disease Code</p> 
         * <p>Containdication.allergenGroupName (PrintName) 
         * PIN:Contraindications.drugAllergy (Inferred from Code System 
         * - if it is a DIN it is probably a 
         * drug)</p><p>Contraindication.indicationDescription</p><p>ZDU.7.1 
         * (Code System)</p><p>ZDU.7.2 (mnemonic)</p><p>ZDU.8.2 (Code 
         * System)</p><p>ZDU.8.3 (mnemonic)</p><p>ZDU.8.1 (Print 
         * Name)</p><p>Disease Code</p> 
         * <p>Containdication.allergenGroupName (PrintName) 
         * PIN:Contraindications.drugAllergy (Inferred from Code System 
         * - if it is a DIN it is probably a 
         * drug)</p><p>Contraindication.indicationDescription</p><p>ZDU.7.1 
         * (Code System)</p><p>ZDU.7.2 (mnemonic)</p><p>ZDU.8.2 (Code 
         * System)</p><p>ZDU.8.3 (mnemonic)</p><p>ZDU.8.1 (Print 
         * Name)</p><p>Disease Code</p> 
         * <p>Containdication.allergenGroupName (PrintName) 
         * PIN:Contraindications.drugAllergy (Inferred from Code System 
         * - if it is a DIN it is probably a 
         * drug)</p><p>Contraindication.indicationDescription</p><p>ZDU.7.1 
         * (Code System)</p><p>ZDU.7.2 (mnemonic)</p><p>ZDU.8.2 (Code 
         * System)</p><p>ZDU.8.3
         * ... [rest of documentation truncated due to excessive length]
         */
        [Hl7XmlMappingAttribute(new string[] {"value"})]
        public IssueTriggerObservationValue Value {
            get { return (IssueTriggerObservationValue) this.value.Value; }
            set { this.value.Value = value; }
        }

    }

}