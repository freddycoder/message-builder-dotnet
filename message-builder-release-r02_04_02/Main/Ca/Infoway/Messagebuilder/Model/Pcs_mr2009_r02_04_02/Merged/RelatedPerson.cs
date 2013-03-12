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
 * Last modified: $LastChangedDate: 2013-03-08 11:06:36 -0500 (Fri, 08 Mar 2013) $
 * Revision:      $LastChangedRevision: 6699 $
 */
/* This class was auto-generated by the message builder generator tools. */
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: RelatedPerson</summary>
     * 
     * <remarks>COCT_MT910107CA.PersonalRelationship: Related 
     * Person <p>Important for tracking source of information for 
     * decision making and other actions taken on behalf of a 
     * patient.</p> <p>Describes a person (other than a health-care 
     * provider or employee) who is providing information and 
     * making decision on behalf of the patient, in relation to the 
     * delivery of healthcare for the patient. E.g. Patient's 
     * mother.</p><p>Used when the person cannot be found in the 
     * Client registry.</p> COCT_MT910102CA.PersonalRelationship: 
     * Related Person <p>Important for tracking source of 
     * information for decision making and other actions taken on 
     * behalf of a patient.</p> <p>Describes a person (other than a 
     * health-care provider or employee) who is providing 
     * information and making decision on behalf of the patient, in 
     * relation to the delivery of healthcare for the patient. E.g. 
     * Patient's mother. Also used with a relationship of 
     * &quot;self&quot; when the patient themselves is providing 
     * the care.</p><p>The expectation is that the person can be 
     * found in the client registry.</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"COCT_MT910102CA.PersonalRelationship","COCT_MT910107CA.PersonalRelationship","FICR_MT400001CA.PersonalRelationship","FICR_MT400003CA.PersonalRelationship","FICR_MT400004CA.PersonalRelationship","FICR_MT490101CA.PersonalRelationship","FICR_MT490102CA.PersonalRelationship","FICR_MT500201CA.PersonalRelationship","FICR_MT510201CA.PersonalRelationship","FICR_MT600201CA.PersonalRelationship","FICR_MT610201CA.PersonalRelationship"})]
    public class RelatedPerson : MessagePartBean, Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Iehr.Merged.IParty, Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged.IConsenter, Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged.IChoice, Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Merged.IActingPerson, Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Coct_mt120600ca.IAssignedPerson {

        private CV code;
        private II id;
        private PN relationshipHolderName;
        private SET<TEL, TelecommunicationAddress> relationshipHolderTelecom;
        private AD relationshipHolderAddr;

        public RelatedPerson() {
            this.code = new CVImpl();
            this.id = new IIImpl();
            this.relationshipHolderName = new PNImpl();
            this.relationshipHolderTelecom = new SETImpl<TEL, TelecommunicationAddress>(typeof(TELImpl));
            this.relationshipHolderAddr = new ADImpl();
        }
        /**
         * <summary>Un-merged Business Name: PersonalRelationshipType</summary>
         * 
         * <remarks>Relationship: 
         * FICR_MT490102CA.PersonalRelationship.code 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: PersonalRelationshipType Relationship: 
         * FICR_MT400003CA.PersonalRelationship.code 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: ExamplesAreSpouseChild Relationship: 
         * FICR_MT600201CA.PersonalRelationship.code 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: RelatedPersonType Relationship: 
         * COCT_MT910107CA.PersonalRelationship.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Essential for 
         * understanding the authority to perform certain actions as 
         * well as the context of the information and is therefore 
         * mandatory. E.g. A 'friend' may not be able to make consent 
         * decisions, but may be able to pick up dispenses.</p><p> 
         * <i>The element uses CWE to allow for the capture of Related 
         * Person Type concepts not presently supported by the approved 
         * code system(s). In this case, the human-to-human benefit of 
         * capturing additional non-coded values outweighs the 
         * penalties of capturing some information that will not be 
         * amenable to searching or categorizing.</i> </p> <p>A coded 
         * value indicating how the related person is related to the 
         * patient.</p> Un-merged Business Name: 
         * PersonalRelationshipType Relationship: 
         * FICR_MT400004CA.PersonalRelationship.code 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: PersonalRelationshipType Relationship: 
         * FICR_MT490101CA.PersonalRelationship.code 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: PersonalRelationshipCode Relationship: 
         * FICR_MT610201CA.PersonalRelationship.code 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * FICR_MT510201CA.PersonalRelationship.code 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: ExamplesAreSpouseChild Relationship: 
         * FICR_MT500201CA.PersonalRelationship.code 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: PersonalRelationshipType Relationship: 
         * FICR_MT400001CA.PersonalRelationship.code 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: ResponsiblePersonType Relationship: 
         * COCT_MT910102CA.PersonalRelationship.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Essential for 
         * understanding the authority to perform certain actions as 
         * well as the context of the information and is therefore 
         * mandatory. E.g. A 'friend' may not be able to make consent 
         * decisions, but may be able to pick up dispenses.</p><p> 
         * <i>The element uses CWE to allow for the capture of 
         * Responsible Person Type concepts not presently supported by 
         * the approved code system(s). In this case, the 
         * human-to-human benefit of capturing additional non-coded 
         * values outweighs the penalties of capturing some information 
         * that will not be amenable to searching or categorizing.</i> 
         * </p> <p>A coded value indicating how the responsible person 
         * is related to the patient. If the code is &quot;SELF&quot;, 
         * it indicates that the action was performed by the patient 
         * themselves.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public x_SimplePersonalRelationship Code {
            get { return (x_SimplePersonalRelationship) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: RelatedPersonIdentifier</summary>
         * 
         * <remarks>Un-merged Business Name: RelatedPersonIdentifier 
         * Relationship: COCT_MT910107CA.PersonalRelationship.id 
         * Conformance/Cardinality: REQUIRED (0-1) <p>ZPB1.6 (Root)</p> 
         * <p>ZPB1.7 (EXtension)</p> <p>ZPB2.8 (Root)</p> <p>ZPB2.9 
         * (EXtension)</p> <p>ZPB3.11 (Root)</p> <p>ZPB3.12 
         * (EXtension)</p> <p>ZPB3.18 (Root)</p> <p>ZPB3.19 
         * (EXtension)</p> <p>D60 (Root)</p> <p>D61 (Extension)</p> 
         * <p>D76</p> <p>PVD.020-01 (Extension)</p> <p>PVD.020-02 
         * (Root)</p> <p>PharmacyProvider.444-E9 (Extension)</p> 
         * <p>PharmacyProvider.465-E7 (Root)</p> <p>Prescriber.446-EZ 
         * (Extension)</p> <p>PharmacyProvider.411-DB (Root)</p> 
         * <p>ZDP.18.1 (Extension)</p> <p>ZDP.18.2 (Root)</p> 
         * <p>ZDP.19.1 (Extension)</p> <p>ZDP.19.2 (Root)</p> 
         * <p>ZDP.10.1 (Extension)</p> <p>ZDP.10.2 (Root)</p> 
         * <p>Provider.PproviderExternalKey (Extension)</p> 
         * <p>Provider.providerKey (Extension)</p> 
         * <p>Provider.wellnetProviderId (Extension)</p> 
         * <p>ProviderRegistration.Identifier (Extension)</p> 
         * <p>ProviderRegistration.IdentifierDomain (part of 
         * Extension)</p> <p>ProviderRegistrationjurisdiction (part of 
         * Extension)</p> <p>Allows a person to be uniquely referred 
         * to.</p> <p>A unique identifier for the related person. May 
         * include PHNs, drivers license or other identifiers.</p> 
         * Un-merged Business Name: RelatedPersonIdentifier 
         * Relationship: COCT_MT910102CA.PersonalRelationship.id 
         * Conformance/Cardinality: MANDATORY (1) <p>ZPB1.6 (Root)</p> 
         * <p>ZPB1.7 (EXtension)</p> <p>ZPB2.8 (Root)</p> <p>ZPB2.9 
         * (EXtension)</p> <p>ZPB3.11 (Root)</p> <p>ZPB3.12 
         * (EXtension)</p> <p>ZPB3.18 (Root)</p> <p>ZPB3.19 
         * (EXtension)</p> <p>D60 (Root)</p> <p>D61 (Extension)</p> 
         * <p>D76</p> <p>PVD.020-01 (Extension)</p> <p>PVD.020-02 
         * (Root)</p> <p>PharmacyProvider.444-E9 (Extension)</p> 
         * <p>PharmacyProvider.465-E7 (Root)</p> <p>Prescriber.446-EZ 
         * (Extension)</p> <p>PharmacyProvider.411-DB (Root)</p> 
         * <p>ZDP.18.1 (Extension)</p> <p>ZDP.18.2 (Root)</p> 
         * <p>ZDP.19.1 (Extension)</p> <p>ZDP.19.2 (Root)</p> 
         * <p>ZDP.10.1 (Extension)</p> <p>ZDP.10.2 (Root)</p> 
         * <p>Provider.PproviderExternalKey (Extension)</p> 
         * <p>Provider.providerKey (Extension)</p> 
         * <p>Provider.wellnetProviderId (Extension)</p> 
         * <p>ProviderRegistration.Identifier (Extension)</p> 
         * <p>ProviderRegistration.IdentifierDomain (part of 
         * Extension)</p> <p>ProviderRegistrationjurisdiction (part of 
         * Extension)</p> <p>Allows a person to be uniquely referred to 
         * and retrieved from the client registry and is therefore 
         * mandatory.</p> <p>A unique identifier for the responsible 
         * person (as found in a client registry).</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Business Name: RelatedPersonName</summary>
         * 
         * <remarks>Un-merged Business Name: RelatedPersonName 
         * Relationship: COCT_MT910107CA.RelatedPerson.name 
         * Conformance/Cardinality: MANDATORY (1) <p>ZPB3.13</p> 
         * <p>PVD.050-01 (PartType = Family)</p> <p>PVD.050-02 
         * (PartType = Given - 1st rep)</p> <p>PVD.050-03 PartType = 
         * Given - any rep other than the first)</p> <p>PVD.050-04 
         * (PartType = Suffix)</p> <p>PVD.050-05 (PartType = 
         * Prefix)</p> <p>PVD.100-01 (PartType = Family; 
         * author/performer when supervisor is also specified)</p> 
         * <p>PVD.100-02 (PartType = Given - 1st rep; author/performer 
         * when supervisor is also specified )</p> <p>PVD.100-03 
         * PartType = Given - any rep other than the first; 
         * author/performer when supervisor is also specified)</p> 
         * <p>PVD.100-04 (PartType = Suffix; author/performer when 
         * supervisor is also specified)</p> <p>PVD.100-05 (PartType = 
         * Prefix; author/performer when supervisor is also 
         * specified)</p> <p>D1a</p> <p>Practitioner's Name</p> 
         * <p>04.03</p> <p>Prescriber.427-DR</p> <p>Prescribing 
         * Physician Name</p> <p>ZPS.18.3</p> <p>ZPS.18.4</p> 
         * <p>ZPS.18.5</p> <p>ZPS.19.3</p> <p>ZPS.19.4</p> 
         * <p>ZPS.19.5</p> <p>ZPS.10.3</p> <p>ZPS.10.4</p> 
         * <p>ZPS.10.5</p> <p>ProviderPreviewInfo.ProviderName</p> 
         * <p>Used when contacting or addressing the responsible 
         * person. Because this will be the principle means of 
         * identifying the responsible person, it is mandatory.</p> 
         * <p>The name by which the responsible person is known</p> 
         * Un-merged Business Name: RelatedPersonName Relationship: 
         * COCT_MT910102CA.RelatedPerson.name Conformance/Cardinality: 
         * MANDATORY (1) <p>ZPB3.13</p> <p>PVD.050-01 (PartType = 
         * Family)</p> <p>PVD.050-02 (PartType = Given - 1st rep)</p> 
         * <p>PVD.050-03 PartType = Given - any rep other than the 
         * first)</p> <p>PVD.050-04 (PartType = Suffix)</p> 
         * <p>PVD.050-05 (PartType = Prefix)</p> <p>PVD.100-01 
         * (PartType = Family; author/performer when supervisor is also 
         * specified)</p> <p>PVD.100-02 (PartType = Given - 1st rep; 
         * author/performer when supervisor is also specified )</p> 
         * <p>PVD.100-03 PartType = Given - any rep other than the 
         * first; author/performer when supervisor is also 
         * specified)</p> <p>PVD.100-04 (PartType = Suffix; 
         * author/performer when supervisor is also specified)</p> 
         * <p>PVD.100-05 (PartType = Prefix; author/performer when 
         * supervisor is also specified)</p> <p>D1a</p> 
         * <p>Practitioner's Name</p> <p>04.03</p> 
         * <p>Prescriber.427-DR</p> <p>Prescribing Physician Name</p> 
         * <p>ZPS.18.3</p> <p>ZPS.18.4</p> <p>ZPS.18.5</p> 
         * <p>ZPS.19.3</p> <p>ZPS.19.4</p> <p>ZPS.19.5</p> 
         * <p>ZPS.10.3</p> <p>ZPS.10.4</p> <p>ZPS.10.5</p> 
         * <p>ProviderPreviewInfo.ProviderName</p> <p>Used when 
         * contacting or addressing the responsible person. Because 
         * this will be the principle means of identifying the 
         * responsible person, it is mandatory.</p> <p>The name by 
         * which the responsible person is known</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"relationshipHolder/name"})]
        public PersonName RelationshipHolderName {
            get { return this.relationshipHolderName.Value; }
            set { this.relationshipHolderName.Value = value; }
        }

        /**
         * <summary>Business Name: RelatedPersonPhonesAndEmails</summary>
         * 
         * <remarks>Un-merged Business Name: 
         * RelatedPersonPhonesAndEmails Relationship: 
         * COCT_MT910107CA.RelatedPerson.telecom 
         * Conformance/Cardinality: REQUIRED (0-5) <p>Used to contact 
         * the related person.</p> <p>The phone number(s) and email 
         * address(s) by which a related person may be contacted.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"relationshipHolder/telecom"})]
        public ICollection<TelecommunicationAddress> RelationshipHolderTelecom {
            get { return this.relationshipHolderTelecom.RawSet(); }
        }

        /**
         * <summary>Business Name: RelatedPersonAddress</summary>
         * 
         * <remarks>Un-merged Business Name: RelatedPersonAddress 
         * Relationship: COCT_MT910107CA.RelatedPerson.addr 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Used to contact 
         * the related person.</p> <p>The mail and/or physical address 
         * associated with a related person.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"relationshipHolder/addr"})]
        public PostalAddress RelationshipHolderAddr {
            get { return this.relationshipHolderAddr.Value; }
            set { this.relationshipHolderAddr.Value = value; }
        }

    }

}