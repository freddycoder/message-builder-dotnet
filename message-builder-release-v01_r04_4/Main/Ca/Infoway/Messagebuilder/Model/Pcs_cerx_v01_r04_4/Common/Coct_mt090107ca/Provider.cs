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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Common.Coct_mt090107ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;


    /**
     * <summary>Business Name: Provider</summary>
     * 
     * <p>Important for tracking responsibility for healthcare 
     * events, as well as for identifying appropriate individuals 
     * to contact for further information or follow-up.</p><p>While 
     * an important piece of identifying information, not all 
     * providers will have identifiers, thus this attribute is only 
     * 'populated'.</p> <p>Describes a healthcare provider involved 
     * in the delivery of healthcare services. Encompasses both 
     * professional and non-professional members.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"COCT_MT090107CA.AssignedPerson"})]
    public class Provider : MessagePartBean, Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Iehr.Repc_mt000007ca.IConsenter, Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Pharmacy.Merged.IChangedBy, Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Iehr.Repc_mt000012ca.IChoice, Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Merged.IRecipient, Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Iehr.Merged.IParty {

        private II id;
        private CV code;
        private PN representedPersonName;
        private II representedPersonAsLicensedEntityId;

        public Provider() {
            this.id = new IIImpl();
            this.code = new CVImpl();
            this.representedPersonName = new PNImpl();
            this.representedPersonAsLicensedEntityId = new IIImpl();
        }
        /**
         * <summary>Business Name: A:Provider Id</summary>
         * 
         * <remarks>Relationship: COCT_MT090107CA.AssignedPerson.id 
         * Conformance/Cardinality: REQUIRED (1) <p>ZPB1.6 (Root)</p> 
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
         * Extension)</p> <p>Allows a provider to be uniquely referred 
         * to but will not always be known and is therefore 
         * 'populated'.</p> <p>A unique identifier for a provider (e.g. 
         * the Prescriber on a new prescription).</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Business Name: Provider Type</summary>
         * 
         * <remarks>Relationship: COCT_MT090107CA.AssignedPerson.code 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Necessary for 
         * ascertaining providers' ability/competence in providing 
         * different types of health services.</p> <p>A coded value 
         * indicating the professional category of a provider. This is 
         * usually the discipline of the provider (e.g. physician, 
         * pharmacist, dentist, etc).</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public HealthcareProviderRoleType Code {
            get { return (HealthcareProviderRoleType) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: B:Provider Name</summary>
         * 
         * <remarks>Relationship: COCT_MT090107CA.Person.name 
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
         * <p>Used when contacting the provider. Also used by others to 
         * recognize a provider and then evaluate the information 
         * provided by a particular provider. This is the one piece of 
         * provider information which should always be known and is 
         * therefore mandatory.</p> <p>The name by which the provider 
         * is known (e.g. the Prescriber on a new prescription).</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"representedPerson/name"})]
        public PersonName RepresentedPersonName {
            get { return this.representedPersonName.Value; }
            set { this.representedPersonName.Value = value; }
        }

        /**
         * <summary>Business Name: D:Provider License Number</summary>
         * 
         * <remarks>Relationship: COCT_MT090107CA.LicensedEntity.id 
         * Conformance/Cardinality: MANDATORY (1) <p>License Number</p> 
         * <p>ZDP.18.6</p> <p>ZDP.19.6</p> <p>ZPS.10.6</p> <p>Allows 
         * providers to verify/ascertain authority for clinical 
         * services.</p> <p>If a provider possesses multiple licenses, 
         * this is the license that applies to the current action.</p> 
         * <p>The identifier of a professional license issued to the 
         * provider by a licensing body.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"representedPerson/asLicensedEntity/id"})]
        public Identifier RepresentedPersonAsLicensedEntityId {
            get { return this.representedPersonAsLicensedEntityId.Value; }
            set { this.representedPersonAsLicensedEntityId.Value = value; }
        }

    }

}