/* This class was auto-generated by the message builder generator tools. */
namespace Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Interaction {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Comt_mt001103ca;
    using Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Mcai_mt700227ab;
    using Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Mcci_mt002300ca;


    /**
     * <summary>Business Name: REPC_IN000074AB: Update care 
     * composition request accepted</summary>
     * 
     * <p>A modification of encounter, episode or similar data for 
     * a particular patient or group of patients, has been 
     * successfully added.</p> Message: MCCI_MT002300CA.Message 
     * Control Act: MCAI_MT700227AB.ControlActEvent --> Payload: 
     * COMT_MT001103CA.ActEvent
     */
    [Hl7PartTypeMappingAttribute(new string[] {"REPC_IN000074AB"})]
    public class UpdateCareCompositionRequestAccepted : HL7Message<Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Mcai_mt700227ab.TriggerEvent<Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Comt_mt001103ca.ReferencedRecord>>, IInteraction {


        public UpdateCareCompositionRequestAccepted() {
        }
    }

}