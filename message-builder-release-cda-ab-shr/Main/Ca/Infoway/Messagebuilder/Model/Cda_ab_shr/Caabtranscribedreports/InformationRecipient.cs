/* This class was auto-generated by the message builder generator tools. */
namespace Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Caabtranscribedreports {
    using Ca.Infoway.Messagebuilder;
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Domainvalue;
    using System.Collections.Generic;


    [Hl7PartTypeMappingAttribute(new string[] {"CAABTranscribedReports.InformationRecipient"})]
    public class InformationRecipient : MessagePartBean {

        private CS_R2<Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Domainvalue.x_InformationRecipient> typeCode;
        private LIST<CS_R2<Code>, CodedTypeR2<Code>> realmCode;
        private II typeId;
        private LIST<II, Identifier> templateId;
        private Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Caabtranscribedreports.IntendedRecipient intendedRecipient;

        public InformationRecipient() {
            this.typeCode = new CS_R2Impl<Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Domainvalue.x_InformationRecipient>();
            this.realmCode = new LISTImpl<CS_R2<Code>, CodedTypeR2<Code>>(typeof(CS_R2Impl<Code>));
            this.typeId = new IIImpl();
            this.templateId = new LISTImpl<II, Identifier>(typeof(IIImpl));
        }
        /**
         * <summary>Relationship: 
         * CAABTranscribedReports.InformationRecipient.typeCode</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"typeCode"})]
        public CodedTypeR2<Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Domainvalue.x_InformationRecipient> TypeCode {
            get { return (CodedTypeR2<Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Domainvalue.x_InformationRecipient>) this.typeCode.Value; }
            set { this.typeCode.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * CAABTranscribedReports.InformationRecipient.realmCode</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"realmCode"})]
        public IList<CodedTypeR2<Code>> RealmCode {
            get { return this.realmCode.RawList<CodedTypeR2<Code>>(); }
        }

        /**
         * <summary>Relationship: 
         * CAABTranscribedReports.InformationRecipient.typeId</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"typeId"})]
        public Identifier TypeId {
            get { return this.typeId.Value; }
            set { this.typeId.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * CAABTranscribedReports.InformationRecipient.templateId</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"templateId"})]
        public IList<Identifier> TemplateId {
            get { return this.templateId.RawList(); }
        }

        /**
         * <summary>Relationship: 
         * CAABTranscribedReports.InformationRecipient.intendedRecipient</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"intendedRecipient"})]
        public Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Caabtranscribedreports.IntendedRecipient IntendedRecipient {
            get { return this.intendedRecipient; }
            set { this.intendedRecipient = value; }
        }

    }

}