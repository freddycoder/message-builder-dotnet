/* This class was auto-generated by the message builder generator tools. */
namespace Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Domainvalue;


    /**
     * <summary>Business Name: AdministrativeObservation</summary>
     * 
     * <remarks>RCMR_MT000220AB.DocumentObservation: Administrative 
     * Observation <p>Information about the administrative 
     * observations related to the clinical document.</p> 
     * RCMR_MT000210AB.DocumentObservation: Administrative 
     * Observation <p>Information about the administrative 
     * observations related to the clinical document.</p> 
     * RCMR_MT000001AB.DocumentObservation: Administrative 
     * Observation <p>Information about the administrative 
     * observations related to the clinical document.</p> 
     * RCMR_MT000002AB.DocumentObservation: Administrative 
     * Observation <p>Information about the administrative 
     * observations related to the clinical document.</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"RCMR_MT000001AB.DocumentObservation","RCMR_MT000002AB.DocumentObservation","RCMR_MT000210AB.DocumentObservation","RCMR_MT000220AB.DocumentObservation"})]
    public class AdministrativeObservation : MessagePartBean {

        private CV code;
        private CV value;

        public AdministrativeObservation() {
            this.code = new CVImpl();
            this.value = new CVImpl();
        }
        /**
         * <summary>Business Name: AdministrativeObservationType</summary>
         * 
         * <remarks>Un-merged Business Name: 
         * AdministrativeObservationType Relationship: 
         * RCMR_MT000210AB.DocumentObservation.code 
         * Conformance/Cardinality: REQUIRED (0-1) <p>A coded value 
         * indicating the type of administrative observation (e.g. 
         * patient mismatch) that is being communicated.</p> Un-merged 
         * Business Name: AdministrativeObservationType Relationship: 
         * RCMR_MT000220AB.DocumentObservation.code 
         * Conformance/Cardinality: REQUIRED (0-1) <p>A coded value 
         * indicating the type of administrative observation (e.g. 
         * patient mismatch) that is being communicated.</p> Un-merged 
         * Business Name: AdministrativeObservationType Relationship: 
         * RCMR_MT000001AB.DocumentObservation.code 
         * Conformance/Cardinality: REQUIRED (0-1) <p>A coded value 
         * indicating the type of administrative observation (e.g. 
         * patient mismatch) that is being communicated.</p> Un-merged 
         * Business Name: AdministrativeObservationType Relationship: 
         * RCMR_MT000002AB.DocumentObservation.code 
         * Conformance/Cardinality: REQUIRED (0-1) <p>A coded value 
         * indicating the type of administrative observation (e.g. 
         * patient mismatch) that is being communicated.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public DocumentObservationType Code {
            get { return (DocumentObservationType) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: AdministrativeObservationValue</summary>
         * 
         * <remarks>Un-merged Business Name: 
         * AdministrativeObservationValue Relationship: 
         * RCMR_MT000210AB.DocumentObservation.value 
         * Conformance/Cardinality: REQUIRED (0-1) <p>The actual value 
         * of the administrative observation.</p> Un-merged Business 
         * Name: AdministrativeObservationValue Relationship: 
         * RCMR_MT000220AB.DocumentObservation.value 
         * Conformance/Cardinality: REQUIRED (0-1) <p>The actual value 
         * of the administrative observation.</p> Un-merged Business 
         * Name: AdministrativeObservationValue Relationship: 
         * RCMR_MT000001AB.DocumentObservation.value 
         * Conformance/Cardinality: REQUIRED (0-1) <p>The actual value 
         * of the administrative observation.</p> Un-merged Business 
         * Name: AdministrativeObservationValue Relationship: 
         * RCMR_MT000002AB.DocumentObservation.value 
         * Conformance/Cardinality: REQUIRED (0-1) <p>The actual value 
         * of the administrative observation.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"value"})]
        public DocumentObservationTypeValue Value {
            get { return (DocumentObservationTypeValue) this.value.Value; }
            set { this.value.Value = value; }
        }

    }

}