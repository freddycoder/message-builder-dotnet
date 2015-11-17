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
namespace Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Merged {
    using Ca.Infoway.Messagebuilder;
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Instructions;
    using System;
    using System.Collections.Generic;


    [Hl7PartTypeMappingAttribute(new string[] {"ImmunizationActivity.InstructionsEntryRelationship","MedicationActivity.InstructionsEntryRelationship","ProcedureActivityAct.InstructionsEntryRelationship","ProcedureActivityObservation.InstructionsEntryRelationship","ProcedureActivityProcedure.InstructionsEntryRelationship"})]
    public class InstructionsEntryRelationship : MessagePartBean, Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Merged.IEntryRelationshipChoice_6, Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Immunizationactivity.IEntryRelationshipChoice, Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Medicationactivity.IEntryRelationshipChoice, Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Procedureactivityobservation.IEntryRelationshipChoice {

        private BL contextConductionInd;
        private BL negationInd;
        private LIST<CS, Code> realmCode;
        private II typeId;
        private LIST<II, Identifier> templateId;
        private INT sequenceNumber;
        private BL seperatableInd;
        private Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Instructions.Act act;

        public InstructionsEntryRelationship() {
            this.contextConductionInd = new BLImpl();
            this.negationInd = new BLImpl();
            this.realmCode = new LISTImpl<CS, Code>(typeof(CSImpl));
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
         * MedicationActivity.InstructionsEntryRelationship.contextConductionInd 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProcedureActivityProcedure.InstructionsEntryRelationship.contextConductionInd 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ImmunizationActivity.InstructionsEntryRelationship.contextConductionInd 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProcedureActivityObservation.InstructionsEntryRelationship.contextConductionInd 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProcedureActivityAct.InstructionsEntryRelationship.contextConductionInd 
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
         * MedicationActivity.InstructionsEntryRelationship.negationInd 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProcedureActivityProcedure.InstructionsEntryRelationship.negationInd 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ImmunizationActivity.InstructionsEntryRelationship.negationInd 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProcedureActivityObservation.InstructionsEntryRelationship.negationInd 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProcedureActivityAct.InstructionsEntryRelationship.negationInd 
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
         * MedicationActivity.InstructionsEntryRelationship.realmCode 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProcedureActivityProcedure.InstructionsEntryRelationship.realmCode 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ImmunizationActivity.InstructionsEntryRelationship.realmCode 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProcedureActivityObservation.InstructionsEntryRelationship.realmCode 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProcedureActivityAct.InstructionsEntryRelationship.realmCode 
         * Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"realmCode"})]
        public IList<Code> RealmCode {
            get { return this.realmCode.RawList<Code>(); }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * MedicationActivity.InstructionsEntryRelationship.typeId 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProcedureActivityProcedure.InstructionsEntryRelationship.typeId 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ImmunizationActivity.InstructionsEntryRelationship.typeId 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProcedureActivityObservation.InstructionsEntryRelationship.typeId 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProcedureActivityAct.InstructionsEntryRelationship.typeId 
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
         * MedicationActivity.InstructionsEntryRelationship.templateId 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProcedureActivityProcedure.InstructionsEntryRelationship.templateId 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ImmunizationActivity.InstructionsEntryRelationship.templateId 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProcedureActivityObservation.InstructionsEntryRelationship.templateId 
         * Conformance/Cardinality: OPTIONAL (0-*) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProcedureActivityAct.InstructionsEntryRelationship.templateId 
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
         * MedicationActivity.InstructionsEntryRelationship.sequenceNumber 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProcedureActivityProcedure.InstructionsEntryRelationship.sequenceNumber 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ImmunizationActivity.InstructionsEntryRelationship.sequenceNumber 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProcedureActivityObservation.InstructionsEntryRelationship.sequenceNumber 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProcedureActivityAct.InstructionsEntryRelationship.sequenceNumber 
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
         * MedicationActivity.InstructionsEntryRelationship.seperatableInd 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProcedureActivityProcedure.InstructionsEntryRelationship.seperatableInd 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ImmunizationActivity.InstructionsEntryRelationship.seperatableInd 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProcedureActivityObservation.InstructionsEntryRelationship.seperatableInd 
         * Conformance/Cardinality: OPTIONAL (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProcedureActivityAct.InstructionsEntryRelationship.seperatableInd 
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
         * MedicationActivity.InstructionsEntryRelationship.act 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProcedureActivityProcedure.InstructionsEntryRelationship.act 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ImmunizationActivity.InstructionsEntryRelationship.act 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProcedureActivityObservation.InstructionsEntryRelationship.act 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * ProcedureActivityAct.InstructionsEntryRelationship.act 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"act"})]
        public Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Instructions.Act Act {
            get { return this.act; }
            set { this.act = value; }
        }

    }

}