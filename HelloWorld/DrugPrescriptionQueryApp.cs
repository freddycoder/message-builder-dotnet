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
using System.Collections.Generic;

using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Domainvalue.Payload;
using Ca.Infoway.Messagebuilder.Domainvalue.Transport;
using Ca.Infoway.Messagebuilder.Model;
using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Coct_mt090108ca;
using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Merged;
using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Quqi_mt020000ca;
using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Interaction;
using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Pharmacy.Porx_mt030040ca;
using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Pharmacy.Porx_mt060130ca;
using Ca.Infoway.Messagebuilder;


/**
 * <p>Hello world example for Pharmacy Transactions - Prescription Summary Query.</p>
 * <p>This example illustrates the use of the Message Builder library to perform
 *   a Patient Drug Prescription Summary Query.</p> 
 * <p>  
 *   The pan-Canadian specifications supported used are base R02.04.02 release of:
 *   
 *   Transaction: C01.07 Get Patient Drug Prescription Order Summary
 *   
 *   Request Message: PORX_IN060290CA   (PORX_MT060130CA Drug Prescription Summary Request)
 *   Response Message: PORX_IN060300CA  (PORX_MT030040CA Drug Prescription summary)
 *   
 *   requests retrieval of basic information about all medication 
 *   prescriptions provided to a single patient, d
 *   optionally filtered by date and status.</p>
 * 
 */
namespace Hello_World
{
    class DrugPrescriptionQueryApp : HelloWorldApp {

        protected override void ProcessResponseInteraction(IInteraction interaction)
        {
		
		    MedicationPrescriptionSummaryQueryResponse response = (MedicationPrescriptionSummaryQueryResponse)interaction;
		    // Now we print out some of the response values...
		
		    if (response == null){
			    Console.WriteLine("Could not cast response to MedicationPrescriptionSummaryQueryResponse");
		    }
		
		    Console.WriteLine("Message ID (root):={0}\n", response.Id.Root);
		    Console.WriteLine("Query ID:={0}\n", response.ControlActEvent.QueryAck.QueryId.Root);
		    Console.WriteLine("Query Result count:={0}\n", response.ControlActEvent.QueryAck.ResultTotalQuantity);

		    // Checking the message ID matches the query.
		    Console.WriteLine("Acknowledges Message ID (root):={0}\n",
				    response.Acknowledgement.TargetMessageId.Root);

		    if (response.ControlActEvent.QueryAck.ResultCurrentQuantity > 0) {
			    // Now print out some information for  result records returned...
			    IList<RefersTo_1<Prescription>> records = response.ControlActEvent.Subject; 
			    for (int index=0; index < records.Count; index++) {
				    RefersTo_1<Prescription> subject = records[index];
				    Prescription script = subject.Act;
				    HealthcareWorker provider = script.Author.AssignedEntity;
				    String family = provider.AssignedPerson.Name.FamilyName;
				    String given = provider.AssignedPerson.Name.GivenName;
				    Console.WriteLine("Prescriber:= {0} {1}\n", given, family);
				    Console.WriteLine("prescribed date:= {0}\n", script.Author.Time.ToString());
			    }
		    }
	    }

	    protected override IInteraction CreateRequestInteraction() {
            this.responseExampleResourceFileName = "Resources.PORX_EX060300CA.xml";

		    MedicationPrescriptionSummaryQuery message = new MedicationPrescriptionSummaryQuery();

		    this.SetTransportWrapperValues(message);
		
		    message.ControlActEvent = this.CreateControlActEvent();
		    // Set the Record Target (i.e the patient)
		    message.ControlActEvent.RecordTargetPatient1 = this.CreateRecordTarget();
		
		    QueryByParameter<ParameterList> queryCriteria = new QueryByParameter<ParameterList>();
		    message.ControlActEvent.QueryByParameter = queryCriteria;
		 
		    queryCriteria.QueryId = new Identifier(System.Guid.NewGuid().ToString());
		    queryCriteria.ParameterList = this.CreateQueryParameters();
		    return message;
	    }
	
	    private ParameterList CreateQueryParameters() {

		    ParameterList parameterList = new ParameterList();
		
		    parameterList.MostRecentByDrugIndicatorValue = false;
		    parameterList.IssueFilterCodeValue = IssueFilterCode.ALL;
		    Interval<PlatformDate> fromDate = IntervalFactory.CreateLow(new PlatformDate(0));
		    parameterList.AdministrationEffectivePeriodValue = fromDate;
		    return parameterList;
	    }

	    private TriggerEvent<ParameterList> CreateControlActEvent() {

		    TriggerEvent<ParameterList> cae = new TriggerEvent<ParameterList>();
		    cae.Id = new Identifier("2.16.840.1.113883.1.6", "8141234");
		    cae.Code = HL7TriggerEventCode.MEDICATION_PRESCRIPTION_SUMMARY_QUERY;

		    cae.EffectiveTime = IntervalFactory.CreateLow(new PlatformDate());
		    cae.LocationServiceDeliveryLocation = this.CreateServiceLocation2();
		    cae.Author = this.CreateAuthor_1();
		    return cae;
	    }
    }
}