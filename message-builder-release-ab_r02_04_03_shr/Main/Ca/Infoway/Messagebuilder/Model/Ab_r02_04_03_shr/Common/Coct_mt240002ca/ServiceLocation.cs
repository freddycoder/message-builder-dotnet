/* This class was auto-generated by the message builder generator tools. */
namespace Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt240002ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt960002ca;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: Service Location</summary>
     * 
     * <p>Used for tracking service delivery responsibility, to 
     * provide contact information for follow-up and for 
     * statistical analysis. Also important for indicating where 
     * paper records can be located.</p> <p>An identification of a 
     * service location (or facility) that can be found in the 
     * service delivery location. E.g. Pharmacy, Medical Clinic, 
     * Hospital</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"COCT_MT240002CA.ServiceDeliveryLocation"})]
    public class ServiceLocation : MessagePartBean {

        private II id;
        private ST locationName;
        private IList<Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt960002ca.GeographicCoordinates> subjectOfPosition;

        public ServiceLocation() {
            this.id = new IIImpl();
            this.locationName = new STImpl();
            this.subjectOfPosition = new List<Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt960002ca.GeographicCoordinates>();
        }
        /**
         * <summary>Business Name: C:Service Location Identifier</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT240002CA.ServiceDeliveryLocation.id 
         * Conformance/Cardinality: MANDATORY (1) <p>PVD.020-01 
         * (extension)</p> <p>PVD.020-02 (root)</p> <p>Dispensing 
         * Pharmacy number</p> <p>Pharmacy Identifier</p> 
         * <p>Facility.facilityKey</p> <p>DispensedItem.facilityKey</p> 
         * <p>Allows for lookup and retrieval of detailed information 
         * about a specific service location. Also ensures unique 
         * identification of service location and is therefore 
         * mandatory.</p><p>The identifier is mandatory because it is 
         * the principal mechanism for uniquely identifying the 
         * facility.</p> <p>Unique identifier for a healthcare service 
         * location.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Business Name: B:Service Location Name</summary>
         * 
         * <remarks>Relationship: COCT_MT240002CA.Place.name 
         * Conformance/Cardinality: MANDATORY (1) <p>PVD.070</p> 
         * <p>Dispensing Pharmacy Name</p> <p>Facility.name</p> <p>Used 
         * for human communication, and for cross-checking of location 
         * Id and is therefore mandatory</p> <p>The name assigned to 
         * the service location.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"location/name"})]
        public String LocationName {
            get { return this.locationName.Value; }
            set { this.locationName.Value = value; }
        }

        /**
         * <summary>Relationship: COCT_MT240002CA.Subject.position</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf/position"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt960002ca.GeographicCoordinates> SubjectOfPosition {
            get { return this.subjectOfPosition; }
        }

    }

}