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
 * Last modified: $LastChangedDate: 2011-05-04 16:47:15 -0300 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
using System;

using Ca.Infoway.Messagebuilder.Domainvalue.Transport;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Domainvalue.Payload;
using Ca.Infoway.Messagebuilder.Model;
using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Merged;
using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Immunization.Poiz_mt060140ca;
using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Quqi_mt020000ca;
using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Immunization.Poiz_mt060150ca;
using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Interaction;
using Ca.Infoway.Messagebuilder;

namespace Hello_World
{
/**
 * <p>Hello world example for Immunization Registry Transactions - Immunization Event Detail Query.</p>
 * <p>This example illustrates the use of the Message Builder library to perform
 *   an Immunization Event Detail Query.</p> 
 * <p>  
 *   The pan-Canadian specifications supported used are base R02.04.02 release of:
 *   
 *   Transaction: P07.01 Immunization Event Detail Query/Response
 *   
 *   Request Message:  POIZ_IN020010CA   
 *   Response Message: POIZ_IN020020CA
 * </p>
 * 
 */
    class ImmunizationQueryApp : HelloWorldApp {

	    protected override void ProcessResponseInteraction(IInteraction interaction) {
		    // Now we want to parse (i.e. de-serialize or un-marshal) the response message...
		    ImmunizationsQueryResponse response = (ImmunizationsQueryResponse)interaction;
		    // Now we print out some of the response values...
		    Console.WriteLine("Message ID (root):={0}\n", response.Id.Root);
            Console.WriteLine("Query ID:={0}\n", response.ControlActEvent.QueryAck.QueryId.Root);
            Console.WriteLine("Query Result count:={0}\n", response.ControlActEvent.QueryAck.ResultTotalQuantity);
	
	        //Now let's add  some code to extract an immunization record detail...'
		    foreach (RefersTo_1<Immunizations> immunization in response.ControlActEvent.Subject) {
			    String vaccineCode = immunization.Act.ConsumableAdministerableMedicineAdministerableVaccine.Code.CodeValue;
			    String vocabulary = immunization.Act.ConsumableAdministerableMedicineAdministerableVaccine.Code.CodeSystem;
			    String vaccine = immunization.Act.ConsumableAdministerableMedicineAdministerableVaccine.Name;
			    String aDate = immunization.Act.EffectiveTime.ToString();
                Console.WriteLine("Vaccine: {0} (code= {1} ,codeSystem = {2}) administered: {3}\n", vaccine, vaccineCode, vocabulary, aDate);	
		    }
	    }

	    protected override IInteraction CreateRequestInteraction() {

            this.responseExampleResourceFileName = "Resources.POIZ_EX020020CA.xml";

            // Create a POIZ_IN020010CA Immunization Event Detail Request Message
		    ImmunizationsQuery message = new ImmunizationsQuery();
		    this.SetTransportWrapperValues(message);
		    // Create and setup the control act event wrapper
		    message.ControlActEvent = this.CreateControlActEvent();
		
		    QueryByParameter<ImmunizationQueryParameters> query = new QueryByParameter<ImmunizationQueryParameters>();
		    message.ControlActEvent.QueryByParameter = query;

		    // Set unique query identifier
		    message.ControlActEvent.QueryByParameter.QueryId = new Identifier(Guid.NewGuid().ToString());

		    // Lastly, set the Query Parameters		
		    message.ControlActEvent.QueryByParameter.ParameterList = this.createQueryParameters();

		    return message;
	    }
	
	    private ImmunizationQueryParameters createQueryParameters() {
		    // Lastly, set the Query Parameters
		    ImmunizationQueryParameters parameterList = new ImmunizationQueryParameters();
		    // Focus of the query .. look up immz detail results for this immz record
		    Identifier immunizationId = new Identifier("2.16.840.1.113883.19.3.207.15.1.1", "829SRFGZ80Y6Z");
	
		    parameterList.ImmunizationEventIDValue = immunizationId;

		    // Set the corroborating patient data.
		    parameterList.PatientBirthDateValue = new PlatformDate(new DateTime(1949, 11, 05));

		    parameterList.PatientGenderValue = AdministrativeGender.MALE;

		    Identifier patientID = new Identifier("2.16.840.1.113883.3.19.3.163.1", "9880897949");
		    parameterList.PatientIDValue.Add(patientID);

		    // Set a patient identifier
		    parameterList.PatientNameValue = PersonName.CreateFirstNameLastName("Cyril", "Lambert");

		    return parameterList;
	    }
	
	    private TriggerEvent<ImmunizationQueryParameters> CreateControlActEvent() {
		    TriggerEvent<ImmunizationQueryParameters> controlActEvent = new TriggerEvent<ImmunizationQueryParameters>();

		    controlActEvent.Code = HL7TriggerEventCode.IMMUNIZATION_QUERY;

		    controlActEvent.Id = new Identifier(Guid.NewGuid().ToString());
		    controlActEvent.EffectiveTime = IntervalFactory.CreateLow(new PlatformDate());

		    controlActEvent.RecordTargetPatient1 = this.CreateRecordTarget();
		    controlActEvent.Author = this.CreateAuthor_1();
		    controlActEvent.DataEntryLocationServiceDeliveryLocation = this.CreateServiceLocation2();

		    return controlActEvent;
	    }	
	
    }
}