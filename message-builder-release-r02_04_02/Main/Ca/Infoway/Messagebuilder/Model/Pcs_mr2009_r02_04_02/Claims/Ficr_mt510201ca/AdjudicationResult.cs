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
 * Author:        $LastChangedBy: jmis $
 * Last modified: $LastChangedDate: 2015-09-15 11:09:53 -0400 (Tue, 15 Sep 2015) $
 * Revision:      $LastChangedRevision: 9796 $
 */
/* This class was auto-generated by the message builder generator tools. */
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Ficr_mt510201ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Merged;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Coct_mt260020ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Domainvalue;
    using System.Collections.Generic;


    [Hl7PartTypeMappingAttribute(new string[] {"FICR_MT510201CA.AdjudicationResult"})]
    public class AdjudicationResult : MessagePartBean {

        private CV code;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Merged.Trigger2> trigger;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Ficr_mt510201ca.IInvoiceElementChoice> referenceInvoiceElementChoice;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Ficr_mt510201ca.IAdjudicationCodeChoice> pertinentInformationAdjudicationCodeChoice;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Coct_mt260020ca.DetectedIssueEvent> reasonOfDetectedIssueEvent;

        public AdjudicationResult() {
            this.code = new CVImpl();
            this.trigger = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Merged.Trigger2>();
            this.referenceInvoiceElementChoice = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Ficr_mt510201ca.IInvoiceElementChoice>();
            this.pertinentInformationAdjudicationCodeChoice = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Ficr_mt510201ca.IAdjudicationCodeChoice>();
            this.reasonOfDetectedIssueEvent = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Coct_mt260020ca.DetectedIssueEvent>();
        }
        /**
         * <summary>Business Name: Adjudication Results Adjudication 
         * Code</summary>
         * 
         * <remarks>Relationship: 
         * FICR_MT510201CA.AdjudicationResult.code 
         * Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ActAdjudicationType Code {
            get { return (ActAdjudicationType) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * FICR_MT510201CA.AdjudicationResult.trigger</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-10)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"trigger"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Merged.Trigger2> Trigger {
            get { return this.trigger; }
        }

        /**
         * <summary>Relationship: 
         * FICR_MT510201CA.Reference.invoiceElementChoice</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"reference/invoiceElementChoice"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Ficr_mt510201ca.IInvoiceElementChoice> ReferenceInvoiceElementChoice {
            get { return this.referenceInvoiceElementChoice; }
        }

        /**
         * <summary>Relationship: 
         * FICR_MT510201CA.PertinentInformation1.adjudicationCodeChoice</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"pertinentInformation/adjudicationCodeChoice"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Claims.Ficr_mt510201ca.IAdjudicationCodeChoice> PertinentInformationAdjudicationCodeChoice {
            get { return this.pertinentInformationAdjudicationCodeChoice; }
        }

        /**
         * <summary>Relationship: 
         * FICR_MT510201CA.Reason1.detectedIssueEvent</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"reasonOf/detectedIssueEvent"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Coct_mt260020ca.DetectedIssueEvent> ReasonOfDetectedIssueEvent {
            get { return this.reasonOfDetectedIssueEvent; }
        }

    }

}