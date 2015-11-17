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
 * Last modified: $LastChangedDate: 2011-05-04 15:47:15 -0400 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
/* This class was auto-generated by the message builder generator tools. */
namespace Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Merged {
    using Ca.Infoway.Messagebuilder;
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Indication;
    using System;
    using System.Collections.Generic;


    [Hl7PartTypeMappingAttribute(new string[] {"EncounterActivities.IndicationEntryRelationship","ImmunizationActivity.IndicationEntryRelationship","MedicationActivity.IndicationEntryRelationship","ProcedureActivityAct.IndicationEntryRelationship","ProcedureActivityObservation.IndicationEntryRelationship","ProcedureActivityProcedure.IndicationEntryRelationship"})]
    public class IndicationEntryRelationship : MessagePartBean, Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Encounteractivities.IEntryRelationshipChoice, Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Merged.IEntryRelationshipChoice_6, Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Immunizationactivity.IEntryRelationshipChoice, Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Medicationactivity.IEntryRelationshipChoice, Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Procedureactivityobservation.IEntryRelationshipChoice {

        private BL inversionInd;
        private BL contextConductionInd;
        private BL negationInd;
        private LIST<CS_R2<Code>, CodedTypeR2<Code>> realmCode;
        private II typeId;
        private LIST<II, Identifier> templateId;
        private INT sequenceNumber;
        private BL seperatableInd;
        private Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Indication.Observation observation;

        public IndicationEntryRelationship() {
            this.inversionInd = new BLImpl();
            this.contextConductionInd = new BLImpl();
            this.negationInd = new BLImpl();
            this.realmCode = new LISTImpl<CS_R2<Code>, CodedTypeR2<Code>>(typeof(CS_R2Impl<Code>));
            this.typeId = new IIImpl();
            this.templateId = new LISTImpl<II, Identifier>(typeof(IIImpl));
            this.sequenceNumber = new INTImpl();
            this.seperatableInd = new BLImpl();
        }
        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * ProcedureActivityProcedure.IndicationEntryRelationship.inversionInd 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * EncounterActivities.IndicationEntryRelationship.inversionInd 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProcedureActivityObservation.IndicationEntryRelationship.inversionInd 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * MedicationActivity.IndicationEntryRelationship.inversionInd 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProcedureActivityAct.IndicationEntryRelationship.inversionInd 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ImmunizationActivity.IndicationEntryRelationship.inversionInd 
         * Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"inversionInd"})]
        public bool? InversionInd {
            get { return this.inversionInd.Value; }
            set { this.inversionInd.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * ProcedureActivityProcedure.IndicationEntryRelationship.contextConductionInd 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * EncounterActivities.IndicationEntryRelationship.contextConductionInd 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProcedureActivityObservation.IndicationEntryRelationship.contextConductionInd 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * MedicationActivity.IndicationEntryRelationship.contextConductionInd 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProcedureActivityAct.IndicationEntryRelationship.contextConductionInd 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ImmunizationActivity.IndicationEntryRelationship.contextConductionInd 
         * Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"contextConductionInd"})]
        public bool? ContextConductionInd {
            get { return this.contextConductionInd.Value; }
            set { this.contextConductionInd.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * ProcedureActivityProcedure.IndicationEntryRelationship.negationInd 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * EncounterActivities.IndicationEntryRelationship.negationInd 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProcedureActivityObservation.IndicationEntryRelationship.negationInd 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * MedicationActivity.IndicationEntryRelationship.negationInd 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProcedureActivityAct.IndicationEntryRelationship.negationInd 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ImmunizationActivity.IndicationEntryRelationship.negationInd 
         * Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"negationInd"})]
        public bool? NegationInd {
            get { return this.negationInd.Value; }
            set { this.negationInd.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * ProcedureActivityProcedure.IndicationEntryRelationship.realmCode 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * EncounterActivities.IndicationEntryRelationship.realmCode 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProcedureActivityObservation.IndicationEntryRelationship.realmCode 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * MedicationActivity.IndicationEntryRelationship.realmCode 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProcedureActivityAct.IndicationEntryRelationship.realmCode 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ImmunizationActivity.IndicationEntryRelationship.realmCode 
         * Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"realmCode"})]
        public IList<CodedTypeR2<Code>> RealmCode {
            get { return this.realmCode.RawList<CodedTypeR2<Code>>(); }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * ProcedureActivityProcedure.IndicationEntryRelationship.typeId 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * EncounterActivities.IndicationEntryRelationship.typeId 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProcedureActivityObservation.IndicationEntryRelationship.typeId 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * MedicationActivity.IndicationEntryRelationship.typeId 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProcedureActivityAct.IndicationEntryRelationship.typeId 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ImmunizationActivity.IndicationEntryRelationship.typeId 
         * Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"typeId"})]
        public Identifier TypeId {
            get { return this.typeId.Value; }
            set { this.typeId.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * ProcedureActivityProcedure.IndicationEntryRelationship.templateId 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * EncounterActivities.IndicationEntryRelationship.templateId 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProcedureActivityObservation.IndicationEntryRelationship.templateId 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * MedicationActivity.IndicationEntryRelationship.templateId 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProcedureActivityAct.IndicationEntryRelationship.templateId 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ImmunizationActivity.IndicationEntryRelationship.templateId 
         * Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"templateId"})]
        public IList<Identifier> TemplateId {
            get { return this.templateId.RawList(); }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * ProcedureActivityProcedure.IndicationEntryRelationship.sequenceNumber 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * EncounterActivities.IndicationEntryRelationship.sequenceNumber 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProcedureActivityObservation.IndicationEntryRelationship.sequenceNumber 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * MedicationActivity.IndicationEntryRelationship.sequenceNumber 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProcedureActivityAct.IndicationEntryRelationship.sequenceNumber 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ImmunizationActivity.IndicationEntryRelationship.sequenceNumber 
         * Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"sequenceNumber"})]
        public int? SequenceNumber {
            get { return this.sequenceNumber.Value; }
            set { this.sequenceNumber.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * ProcedureActivityProcedure.IndicationEntryRelationship.seperatableInd 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * EncounterActivities.IndicationEntryRelationship.seperatableInd 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProcedureActivityObservation.IndicationEntryRelationship.seperatableInd 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * MedicationActivity.IndicationEntryRelationship.seperatableInd 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProcedureActivityAct.IndicationEntryRelationship.seperatableInd 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ImmunizationActivity.IndicationEntryRelationship.seperatableInd 
         * Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"seperatableInd"})]
        public bool? SeperatableInd {
            get { return this.seperatableInd.Value; }
            set { this.seperatableInd.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * ProcedureActivityProcedure.IndicationEntryRelationship.observation 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * EncounterActivities.IndicationEntryRelationship.observation 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProcedureActivityObservation.IndicationEntryRelationship.observation 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * MedicationActivity.IndicationEntryRelationship.observation 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProcedureActivityAct.IndicationEntryRelationship.observation 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ImmunizationActivity.IndicationEntryRelationship.observation 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"observation"})]
        public Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Indication.Observation Observation {
            get { return this.observation; }
            set { this.observation = value; }
        }

    }

}