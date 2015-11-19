/* This class was auto-generated by the message builder generator tools. */
namespace Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Domainvalue;


    /**
     * <summary>Business Name: DischargeDiagnosis</summary>
     * 
     * <remarks>REPC_MT500004AB.DiagnosisEvent: Discharge Diagnosis 
     * <p>These are key elements in defining the encounter.</p> 
     * <p>Describes the health conditions which were identified or 
     * determined as part of the encounter.</p> 
     * REPC_MT500003AB.DiagnosisEvent: Discharge Diagnosis <p>These 
     * are key elements in defining the encounter.</p> <p>Describes 
     * the health conditions which were identified or determined as 
     * part of the encounter.</p> REPC_MT500002AB.DiagnosisEvent: 
     * Discharge Diagnosis <p>These are key elements in defining 
     * the encounter.</p> <p>Describes the health conditions which 
     * were identified or determined as part of the encounter.</p> 
     * REPC_MT500001AB.DiagnosisEvent: Discharge Diagnosis <p>These 
     * are key elements in defining the encounter.</p> <p>Describes 
     * the health conditions which were identified or determined as 
     * part of the encounter.</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"REPC_MT500001AB.DiagnosisEvent","REPC_MT500002AB.DiagnosisEvent","REPC_MT500003AB.DiagnosisEvent","REPC_MT500004AB.DiagnosisEvent"})]
    public class DischargeDiagnosis : MessagePartBean {

        private CD code;
        private CV value;

        public DischargeDiagnosis() {
            this.code = new CDImpl();
            this.value = new CVImpl();
        }
        /**
         * <summary>Business Name: DiagnosisType</summary>
         * 
         * <remarks>Un-merged Business Name: DiagnosisType 
         * Relationship: REPC_MT500002AB.DiagnosisEvent.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Code is fixed to 
         * DX if not using SNOMED</p> <p>Identifies this observation as 
         * a type of diagnosis and is therefore mandatory.</p><p>This 
         * element makes use of the CD datatype to allow for use of the 
         * SNOMED code system that in some circumstances requires the 
         * use of post-coordination. Post-coordination is only 
         * supported by the CD datatype.</p> <p>Identifies the type of 
         * diagnosis</p> Un-merged Business Name: DiagnosisType 
         * Relationship: REPC_MT500003AB.DiagnosisEvent.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Code is fixed to 
         * DX if not using SNOMED</p> <p>Identifies this observation as 
         * a type of diagnosis and is therefore mandatory.</p><p>This 
         * element makes use of the CD datatype to allow for use of the 
         * SNOMED code system that in some circumstances requires the 
         * use of post-coordination. Post-coordination is only 
         * supported by the CD datatype.</p> <p>Identifies the type of 
         * diagnosis</p> Un-merged Business Name: DiagnosisType 
         * Relationship: REPC_MT500004AB.DiagnosisEvent.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Code is fixed to 
         * DX if not using SNOMED</p> <p>Identifies this observation as 
         * a type of diagnosis and is therefore mandatory.</p><p>This 
         * element makes use of the CD datatype to allow for use of the 
         * SNOMED code system that in some circumstances requires the 
         * use of post-coordination. Post-coordination is only 
         * supported by the CD datatype.</p> <p>Identifies the type of 
         * diagnosis</p> Un-merged Business Name: DiagnosisType 
         * Relationship: REPC_MT500001AB.DiagnosisEvent.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Code is fixed to 
         * DX if not using SNOMED</p> <p>Identifies this observation as 
         * a type of diagnosis and is therefore mandatory.</p><p>This 
         * element makes use of the CD datatype to allow for use of the 
         * SNOMED code system that in some circumstances requires the 
         * use of post-coordination. Post-coordination is only 
         * supported by the CD datatype.</p> <p>Identifies the type of 
         * diagnosis</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ActDiagnosisCode Code {
            get { return (ActDiagnosisCode) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: DiagnosisCode</summary>
         * 
         * <remarks>Un-merged Business Name: DiagnosisCode 
         * Relationship: REPC_MT500002AB.DiagnosisEvent.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows tracking 
         * outcomes and provides key information about the 
         * encounter</p><p>This element makes use of the CD datatype to 
         * allow for use of the SNOMED code system that in some 
         * circumstances requires the use of post-coordination. 
         * Post-coordination is only supported by the CD datatype.</p> 
         * <p>A coded form of the condition that was identified as part 
         * of the care delivery described by this care composition.</p> 
         * Un-merged Business Name: DiagnosisCode Relationship: 
         * REPC_MT500003AB.DiagnosisEvent.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows tracking 
         * outcomes and provides key information about the 
         * encounter</p><p>This element makes use of the CD datatype to 
         * allow for use of the SNOMED code system that in some 
         * circumstances requires the use of post-coordination. 
         * Post-coordination is only supported by the CD datatype.</p> 
         * <p>A coded form of the condition that was identified as part 
         * of the care delivery described by this Care Composition.</p> 
         * Un-merged Business Name: DiagnosisCode Relationship: 
         * REPC_MT500004AB.DiagnosisEvent.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows tracking 
         * outcomes and provides key information about the 
         * encounter</p><p>This element makes use of the CD datatype to 
         * allow for use of the SNOMED code system that in some 
         * circumstances requires the use of post-coordination. 
         * Post-coordination is only supported by the CD datatype.</p> 
         * <p>A coded form of the condition that was identified as part 
         * of the care delivery described by this care composition.</p> 
         * Un-merged Business Name: DiagnosisCode Relationship: 
         * REPC_MT500001AB.DiagnosisEvent.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows tracking 
         * outcomes and provides key information about the 
         * encounter</p><p>This element makes use of the CD datatype to 
         * allow for use of the SNOMED code system that in some 
         * circumstances requires the use of post-coordination. 
         * Post-coordination is only supported by the CD datatype.</p> 
         * <p>A coded form of the condition that was identified as part 
         * of the care delivery described by this care composition.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"value"})]
        public DiagnosisValue Value {
            get { return (DiagnosisValue) this.value.Value; }
            set { this.value.Value = value; }
        }

    }

}