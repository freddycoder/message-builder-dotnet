/* This class was auto-generated by the message builder generator tools. */
namespace Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt470002ab {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt090102ca;
    using Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt240003ca;


    /**
     * <summary>Business Name: *consent given to</summary>
     * 
     * <p>Indicates who is receiving consent to view 
     * information.</p><p>This participation is marked as 
     * &quot;populated&quot; as receiver must be specified when 
     * keyword is involved.</p> <p>Identifies the beneficiary of 
     * the consent as being a Provider or Service Location.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"COCT_MT470002AB.Receiver"})]
    public class ConsentGivenTo : MessagePartBean {

        private Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt470002ab.IRecipient recipient;

        public ConsentGivenTo() {
        }
        /**
         * <summary>Relationship: COCT_MT470002AB.Receiver.recipient</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"recipient"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt470002ab.IRecipient Recipient {
            get { return this.recipient; }
            set { this.recipient = value; }
        }

        public Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt090102ca.HealthcareWorker RecipientAsAssignedEntity {
            get { return this.recipient is Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt090102ca.HealthcareWorker ? (Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt090102ca.HealthcareWorker) this.recipient : (Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt090102ca.HealthcareWorker) null; }
        }
        public bool HasRecipientAsAssignedEntity() {
            return (this.recipient is Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt090102ca.HealthcareWorker);
        }

        public Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt240003ca.ServiceLocation RecipientAsServiceDeliveryLocation {
            get { return this.recipient is Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt240003ca.ServiceLocation ? (Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt240003ca.ServiceLocation) this.recipient : (Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt240003ca.ServiceLocation) null; }
        }
        public bool HasRecipientAsServiceDeliveryLocation() {
            return (this.recipient is Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt240003ca.ServiceLocation);
        }

    }

}