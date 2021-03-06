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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Claims.Ficr_mt610201ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Claims.Merged;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt680000ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Domainvalue;
    using System.Collections.Generic;


    [Hl7PartTypeMappingAttribute(new string[] {"FICR_MT610201CA.AdjudicatedInvoiceElementGroup"})]
    public class AdjudicatedInvoiceElementGroup : MessagePartBean, Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Claims.Ficr_mt610201ca.IAdjudicatedInvoiceElementChoice {

        private II id;
        private CV code;
        private CS statusCode;
        private MO netAmt;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Claims.Ficr_mt610201ca.AdjudicatedInvoiceAuthor author;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Claims.Ficr_mt610201ca.AdjudicatedInvoiceElementGroup predecessorAdjudicatedInvoiceElementGroup;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt680000ca.AdjudicatedInvoiceElementGroup> referenceAdjudicatedInvoiceElementGroup;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Claims.Merged.Allowable reference1Allowable;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Claims.Ficr_mt610201ca.AdjudicatedInvoiceCoverage> coverage;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Claims.Ficr_mt610201ca.AdjudicatedInvoiceElementComponent> component;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Claims.Ficr_mt610201ca.AdjudicatedResultOutcome outcomeOf;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Claims.Merged.AdjudicatedResultsGroup referencedByAdjudResultsGroup;

        public AdjudicatedInvoiceElementGroup() {
            this.id = new IIImpl();
            this.code = new CVImpl();
            this.statusCode = new CSImpl();
            this.netAmt = new MOImpl();
            this.referenceAdjudicatedInvoiceElementGroup = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt680000ca.AdjudicatedInvoiceElementGroup>();
            this.coverage = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Claims.Ficr_mt610201ca.AdjudicatedInvoiceCoverage>();
            this.component = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Claims.Ficr_mt610201ca.AdjudicatedInvoiceElementComponent>();
        }
        /**
         * <summary>Business Name: Adjudicated Results Identifier</summary>
         * 
         * <remarks>Relationship: 
         * FICR_MT610201CA.AdjudicatedInvoiceElementGroup.id 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Business Name: Invoice Type</summary>
         * 
         * <remarks>Relationship: 
         * FICR_MT610201CA.AdjudicatedInvoiceElementGroup.code 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ActInvoiceGroupType Code {
            get { return (ActInvoiceGroupType) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: Status of the Adjudicated Invoice</summary>
         * 
         * <remarks>Relationship: 
         * FICR_MT610201CA.AdjudicatedInvoiceElementGroup.statusCode 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"statusCode"})]
        public ActStatus StatusCode {
            get { return (ActStatus) this.statusCode.Value; }
            set { this.statusCode.Value = value; }
        }

        /**
         * <summary>Business Name: Paid Amount</summary>
         * 
         * <remarks>Relationship: 
         * FICR_MT610201CA.AdjudicatedInvoiceElementGroup.netAmt 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"netAmt"})]
        public Money NetAmt {
            get { return this.netAmt.Value; }
            set { this.netAmt.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * FICR_MT610201CA.AdjudicatedInvoiceElementGroup.author</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"author"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Claims.Ficr_mt610201ca.AdjudicatedInvoiceAuthor Author {
            get { return this.author; }
            set { this.author = value; }
        }

        /**
         * <summary>Relationship: 
         * FICR_MT610201CA.AdjudicatedInvoicePredecessor.adjudicatedInvoiceElementGroup</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"predecessor/adjudicatedInvoiceElementGroup"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Claims.Ficr_mt610201ca.AdjudicatedInvoiceElementGroup PredecessorAdjudicatedInvoiceElementGroup {
            get { return this.predecessorAdjudicatedInvoiceElementGroup; }
            set { this.predecessorAdjudicatedInvoiceElementGroup = value; }
        }

        /**
         * <summary>Relationship: 
         * FICR_MT610201CA.Reference.adjudicatedInvoiceElementGroup</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"reference/adjudicatedInvoiceElementGroup"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt680000ca.AdjudicatedInvoiceElementGroup> ReferenceAdjudicatedInvoiceElementGroup {
            get { return this.referenceAdjudicatedInvoiceElementGroup; }
        }

        /**
         * <summary>Relationship: FICR_MT610201CA.Reference2.allowable</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"reference1/allowable"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Claims.Merged.Allowable Reference1Allowable {
            get { return this.reference1Allowable; }
            set { this.reference1Allowable = value; }
        }

        /**
         * <summary>Relationship: 
         * FICR_MT610201CA.AdjudicatedInvoiceElementGroup.coverage</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-10)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"coverage"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Claims.Ficr_mt610201ca.AdjudicatedInvoiceCoverage> Coverage {
            get { return this.coverage; }
        }

        /**
         * <summary>Relationship: 
         * FICR_MT610201CA.AdjudicatedInvoiceElementGroup.component</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1-5)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"component"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Claims.Ficr_mt610201ca.AdjudicatedInvoiceElementComponent> Component {
            get { return this.component; }
        }

        /**
         * <summary>Relationship: 
         * FICR_MT610201CA.AdjudicatedInvoiceElementChoice.outcomeOf</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"outcomeOf"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Claims.Ficr_mt610201ca.AdjudicatedResultOutcome OutcomeOf {
            get { return this.outcomeOf; }
            set { this.outcomeOf = value; }
        }

        /**
         * <summary>Relationship: 
         * FICR_MT610201CA.AdjudResultsRef.adjudResultsGroup</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"referencedBy/adjudResultsGroup"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Claims.Merged.AdjudicatedResultsGroup ReferencedByAdjudResultsGroup {
            get { return this.referencedByAdjudResultsGroup; }
            set { this.referencedByAdjudResultsGroup = value; }
        }

    }

}