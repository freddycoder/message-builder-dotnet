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
 * Author:        $LastChangedBy: gng $
 * Last modified: $LastChangedDate: 2015-11-19 18:20:12 -0500 (Fri, 30 Jan 2015) $
 * Revision:      $LastChangedRevision: 9755 $
 */


namespace Ca.Infoway.Messagebuilder.Marshalling {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;

	[Hl7PartTypeMappingAttribute(new string[] {"MOCK_MT898989CA"})]
	public class MockMultiplyCompoundNestedMappedMessagePartBean {
		
		private ST assignedOrganizationName = new STImpl();
	    private II organizationIdentifier = new IIImpl();
	    private II otherOrganizationIdentifier = new IIImpl();
	
	    [Hl7XmlMappingAttribute(new string[] {"assignedOrganization/name","representedOrganization/name"})]
		[Hl7MapByPartType(Name="assignedOrganization",Type="COCT_MT260010CA.Organization")]
		[Hl7MapByPartType(Name="assignedOrganization",Type="COCT_MT260020CA.Organization")]
		[Hl7MapByPartType(Name="assignedOrganization",Type="COCT_MT260030CA.Organization")]
		[Hl7MapByPartType(Name="representedOrganization",Type="COCT_MT090102CA.Organization")]
		[Hl7MapByPartType(Name="representedOrganization",Type="COCT_MT090108CA.Organization")]
	    public string AssignedOrganizationName {
	        get { return this.assignedOrganizationName.Value; }
	        set { this.assignedOrganizationName.Value = value; }
	    }
	
	    [Hl7XmlMappingAttribute(new string[] {"representedOrganization/id"})]
	    public Identifier OrganizationIdentifier {
	        get { return this.organizationIdentifier.Value; }
	        set { this.organizationIdentifier.Value = value; }
	    }
			
	    [Hl7XmlMappingAttribute(new string[] {"assignedOrganization/otherId"})]
	    public Identifier OtherOrganizationIdentifier {
	        get { return this.otherOrganizationIdentifier.Value; }
	        set { this.otherOrganizationIdentifier.Value = value; }
	    }
	}
}
