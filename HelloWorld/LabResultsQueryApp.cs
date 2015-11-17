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

using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Domainvalue.Payload;
using Ca.Infoway.Messagebuilder.Model;
using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Merged;
using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Interaction;
using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Lab.Merged;
using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Quqi_mt020000ca;
using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Lab.Polb_mt001001ca;
using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Lab.Polb_mt004000ca;
using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Lab.Polb_mt004200ca;
using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Lab.Polb_mt310000ca;
using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Lab.Polb_mt004999ca;
using Ca.Infoway.Messagebuilder.Domainvalue.Transport;

namespace Hello_World
{
/**
 * <p>Hello world example for Laboratory Information System Transactions - Lab Test Results Query.</p>
 * <p>This example illustrates the use of the Message Builder library to perform
 *   a Lab Test Results Query.</p> 
 * <p>  
 *   The pan-Canadian specifications supported used are base R02.04.02 release of:
 *   
 *   Transaction: L2.1 Laboratory Results Query 
 *   
 *   Request Message:  POLB_IN354000CA  (POLB_MT310000CA - Lab Result Detail Query Request Message) 
 *   Response Message: POLB_IN364000CA  (POLB_MT004999CA - Lab Result Query Response)
 * </p>
 * 
 */
    class LabResultsQueryApp : HelloWorldApp {

	    protected override void ProcessResponseInteraction(IInteraction interaction) {
		    ResultsQueryResponse response = (ResultsQueryResponse)interaction;
		    // Now we print out some of the response values...
		    Console.WriteLine("Message ID (root):={0}\n", response.Id.Root);
		
		    if (response.ControlActEvent.Subject.Count > 0)
		    {
			    foreach (RefersTo_1<IResultInstancePayloadChoice> result in response.ControlActEvent.Subject) {
				    IResultInstancePayloadChoice act = result.Act;
				
				    Console.WriteLine("Result Payload Class = {0}\n", act.GetType().ToString());
				    if (typeof(ObservationReport) == act.GetType()) {
					    this.ProcessObservationReport(act);
				    }
				    else if (typeof(ResultObservation) == act.GetType()) {
					    //TODO - process result observation 
				    }
                    else if (typeof(Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Lab.Polb_mt004000ca.BatteryEvent) == act.GetType())
                    {
					    //TODO - process battery event 
				    }
				    else if (typeof(Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Lab.Polb_mt004200ca.BatteryEvent) == act.GetType()) {
					    //TODO - process other battery event 
				    }
                    else if (typeof(Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Lab.Polb_mt004100ca.ReportHeader) == act.GetType())
                    {
					    //TODO - process report header
				    }
				    else if (typeof(Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Lab.Polb_mt004200ca.ReportHeader) == act.GetType()) {
					    //TODO - process other report header
				    }
				    else if (typeof(DiagnosisOrInterpretationObservation) == act.GetType()) {
					    //TODO - process diagnosis/interpretation observation 
				    }
			    }
		    }
	    }
	
	    private void ProcessObservationReport(IResultInstancePayloadChoice payloadChoice) {

		    // Observation Report Lab Result.
		    ObservationReport report = (ObservationReport)payloadChoice;
		
		    // id = Report ID [1..1]
		    Console.WriteLine("Report ID = (root={0}, extension={1})\n", 
				    report.Id.Root, 
				    report.Id.Extension);
		
		    // ObservationLabReportType code [1..1]
            // FIXME - TM: the raw code value below is not the correct type and throws a ClassCastException
//		    String reportTypeCode = report.Code.CodeValue;
//		    String reportTypeCodeSystem = report.Code.CodeSystem;
//		    Console.WriteLine("Report Type: = (code={0}, codeSystem={1})\n", reportTypeCode, reportTypeCodeSystem);
	
		    // title [1..1]
		    Console.WriteLine("Report Title:= {0}\n", report.Title);
		
		    // text [0..1] specialization = ED.DOCORREF
		    //TODO - Uncomment the next two lines once CR5 release is provided
		    //EncapsulatedData ed = report.getRenderedReport();
		    //Console.WriteLine("Report Text:= {0}\n", ed.getContent().toString());
		
		    // statusCode
		    Console.WriteLine("Report Status:= {0}\n", report.StatusCode.ToString());
		    //effectiveTime
		    Console.WriteLine("Report Date:= {0}\n", report.EffectiveTime.ToString());
		    //confidentialityCode [0..2]

		    // Who requested this lab test?
            foreach(IFulfillmentChoice choice in report.InFulfillmentOfFulfillmentChoice) {
			    Console.WriteLine("fulfillmentChoice is {0}\n", choice.GetType().Name);
			
			    if (typeof(ObservationRequest) == choice.GetType()) {
				    ObservationRequest observationRequest = (ObservationRequest)choice;
				    Identifier ii = observationRequest.Id;
				    Console.WriteLine("infulfillmentOf/observationRequest/id:= (root={0} extension={1})\n", ii.Root, ii.Extension);
			    }
		    }
		
	    }

        protected override IInteraction CreateRequestInteraction()
        {
		    // Interaction ID: POLB_IN354000CA
		    // Interaction Business Name: Request Query Results
		    // Message Type: POLB_MT310000CA
		    // Message Type Name: Laboratory Result Detail Query Request
		    // Control Act Wrapper:  QUQI_MT020000CA - Query Request Wrapper - human initiated patient-specfic
		    // Transport Wrapper: MCCI_MT002100CA - Send Message Payload
		    //
		    // Trigger Event ID: POLB_TE304000CA
		    // Note: the vague  name is derived from the Business Name defined
		    // by the pan-Canadian Standards Collaborative. 
		
            this.responseExampleResourceFileName = "Resources.POLB_EX364000CA.xml";

            RequestQueryResults message = new RequestQueryResults();

		    this.SetTransportWrapperValues(message);
		    message.ControlActEvent = this.CreateControlActEvent();

		    // Set the Record Target (i.e the patient)
		    message.ControlActEvent.RecordTargetPatient1 = this.CreateRecordTarget();

		    QueryByParameter<ParameterList> query = new QueryByParameter<ParameterList>();
		    message.ControlActEvent.QueryByParameter = query;
		
		    // Set the Query Identifier
		    Identifier queryIdentifier = new Identifier(Guid.NewGuid().ToString());
		    message.ControlActEvent.QueryByParameter.QueryId = queryIdentifier;
		
		    // Lastly, set the Query Parameters		
		    message.ControlActEvent.QueryByParameter.ParameterList = this.CreateQueryParameters();
		
		    return message;
	    }

        private ParameterList CreateQueryParameters()
        {
            // Lastly, set the Query Parameters
		    ParameterList parameterList = new ParameterList();
		    // Focus of the query .. look up lab test results for this lab test record:
		    Identifier resultId = new Identifier("2.16.840.1.113883.19.3.207.15.2.13", "R2CBJU7LUAGYP");
		
		    // Specific Lab Test 
		    parameterList.ObservationIdentifierValue = resultId;
		
		    // Now set corroborating patient information
            parameterList.PatientDateofBirthValue = new PlatformDate(new DateTime(1949, 11, 05));
		    parameterList.PatientGenderValue = AdministrativeGender.MALE;
		
		    // Set a patient identifier - This is a MANDATORY parameter.
		    Identifier patientID = new Identifier("2.16.840.1.113883.3.19.3.163.1", "9880897949");
		    parameterList.PatientIDValue = patientID;
		    // For Corroborating the Patient ID
		    parameterList.PatientNameValue = PersonName.CreateFirstNameLastName("Cyril", "Lambert");
		    return parameterList;
	    }


        private TriggerEvent<ParameterList> CreateControlActEvent()
        {
            TriggerEvent<ParameterList> cae = new TriggerEvent<ParameterList>();
		
		    cae.Id = new Identifier("2.16.840.1.113883.1.6", "8141234");	
		    cae.Code = HL7TriggerEventCode.LAB_TEST_RESULTS_QUERY;
		    cae.EffectiveTime = IntervalFactory.CreateLow(new PlatformDate());
		    cae.Author = this.CreateAuthor_1();
		    cae.DataEntryLocationServiceDeliveryLocation = this.CreateServiceLocation2();
		    return cae;
	    }	
    }
}