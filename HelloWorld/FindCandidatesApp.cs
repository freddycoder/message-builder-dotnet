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
﻿using System;
using System.Collections.Generic;

using Ca.Infoway.Messagebuilder.Model;
using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Interaction;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Domainvalue.Transport;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Mfmi_mt700751ca;
using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Cr.Prpa_mt101103ca;
using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Cr.Prpa_mt101104ca;

using Ca.Infoway.Messagebuilder.Domainvalue.Payload;
using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Merged;


namespace Hello_World
{
/**
 * <p>Hello world example for Client Registry Transactions - Find Candidates Query.</p>
 * <p>This example illustrates the use of the Message Builder library to perform
 *   a Find Candidates Query.</p> 
 * <p>  
 *   
 *   Transaction: N2.1 Find Candidates Query
 *   
 *   Request Message:  PRPA_IN101103CA   
 *   Response Message: PRPA_IN101104CA
 * </p>
 * 
 */
    class FindCandidatesQueryApp : HelloWorldApp
    {
        protected override IInteraction CreateRequestInteraction()
        {
            this.responseExampleResourceFileName = "Resources.PRPA_EX101104CA.xml";

            FindCandidatesQuery msg = new FindCandidatesQuery();

            this.SetTransportWrapperValues(msg);
            
            msg.ControlActEvent = this.CreateControlActEvent();

            msg.ControlActEvent.QueryByParameter = new Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Merged.QueryByParameter<ParameterList>();

            // Set unique query identifier
            msg.ControlActEvent.QueryByParameter.QueryId = new Identifier(System.Guid.NewGuid().ToString());

            // Setup the query parameters
            ParameterList parameters = new ParameterList();

            // person name query parameter	
            parameters.PersonNameValue.Add(PersonName.CreateFirstNameLastName("Cyril", "Lambert"));
            // Set the birth date of the person...
            parameters.PersonBirthtimeValue = new PlatformDate(new DateTime(1949, 11, 05)); // client birth date
            // Set the gender	
            parameters.AdministrativeGenderValue = AdministrativeGender.MALE;

            msg.ControlActEvent.QueryByParameter.ParameterList = parameters;

            return msg;
        }

        protected override void ProcessResponseInteraction(IInteraction message)
        {
            FindCandidatesResponse response = (FindCandidatesResponse) message;
		    // Now we print out some of the response values...
		    Console.WriteLine("Message ID (root):={0}\n", response.Id.Root);
		    Console.WriteLine("Query ID:={0}\n", response.ControlActEvent.QueryAck.QueryId.Root);
		    Console.WriteLine("Query Result count:={0}\n", response.ControlActEvent.QueryAck.ResultTotalQuantity);

		    // Checking the message ID matches the query.
		    Console.WriteLine("Acknowledges Message ID (root):={0}\n", response.Acknowledgement.TargetMessageId.Root);

		    if (response.ControlActEvent.QueryAck.ResultCurrentQuantity > 0) {
			    // Now print out the first result record returned...

			    IList<RegistrationEvent<IdentifiedPerson>> records = response.ControlActEvent.SubjectRegistrationEvent;

			    foreach (RegistrationEvent<IdentifiedPerson> record in records) {
				    IdentifiedPerson person = record.Subject.RegisteredRole;

				    foreach (Identifier id in person.Id) {
					    // Identifier doesn't support extracting 'use' or
					    // 'specializationType'
					    Console.WriteLine("Person id := (root = {0}, extension = {1})\n", id.Root, id.Extension);
				    }
				    // Print out the person's name(s)
				    foreach (PersonName name in person.IdentifiedPersonName) {
					    Console.WriteLine("Person name := {0} {1}\n", name.GivenName, name.FamilyName);
				    }
			    }
		    }

        }

        private TriggerEvent<ParameterList> CreateControlActEvent()
        {
            TriggerEvent<ParameterList> controlActEvent = new TriggerEvent<ParameterList>();

            // Set the control act identifier
            controlActEvent.Id = new Identifier(System.Guid.NewGuid().ToString());

            // Set the event type
            controlActEvent.Code = HL7TriggerEventCode.FIND_CANDIDATES_QUERY;
            
            // Setting the event timestamp
            Interval<PlatformDate> eventEffectivePeriod = Interval<PlatformDate>.CreateLow(new PlatformDate());            
            controlActEvent.EffectiveTime = eventEffectivePeriod;
            controlActEvent.DataEntryLocationServiceDeliveryLocation = this.CreateServiceLocation();

            // Setting the  author
            controlActEvent.Author = this.CreateAuthor_2();

            return controlActEvent;
        }
    }
}
